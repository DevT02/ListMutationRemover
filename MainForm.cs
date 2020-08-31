using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

namespace ConfuserExConstantDecryptor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			this.InitializeComponent();
		}

		private void TextBox1DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
				if (array != null)
				{
					string text = array.GetValue(0).ToString();
					int num = text.LastIndexOf(".");
					if (num != -1)
					{
						string text2 = text.Substring(num);
						text2 = text2.ToLower();
						if (text2 == ".exe" || text2 == ".dll")
						{
							base.Activate();
							this.textBox1.Text = text;
							int num2 = text.LastIndexOf("\\");
							if (num2 != -1)
							{
								this.DirectoryName = text.Remove(num2, text.Length - num2);
							}
							if (this.DirectoryName.Length == 2)
							{
								this.DirectoryName += "\\";
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		private void TextBox1DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void Button1Click(object sender, EventArgs e)
		{
			this.label2.Text = "";
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Browse for target assembly";
			openFileDialog.InitialDirectory = "c:\\";
			if (this.DirectoryName != "")
			{
				openFileDialog.InitialDirectory = this.DirectoryName;
			}
			openFileDialog.Filter = "All files (*.exe,*.dll)|*.exe;*.dll";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
				this.textBox1.Text = fileName;
				int num = fileName.LastIndexOf("\\");
				if (num != -1)
				{
					this.DirectoryName = fileName.Remove(num, fileName.Length - num);
				}
				if (this.DirectoryName.Length == 2)
				{
					this.DirectoryName += "\\";
				}
			}
		}

		private void Button3Click(object sender, EventArgs e)
		{
			Application.Exit();
		}


			private void Button2Click(object sender, EventArgs e)
			{
				if (File.Exists(this.textBox1.Text))
				{
					AssemblyName assemblyName = AssemblyName.GetAssemblyName(this.textBox1.Text);
					this.assembly = Assembly.Load(assemblyName);
					if (this.assembly == null)
					{
						MessageBox.Show("Failed to load the assembly! Aborting!");
					}
					else
					{
						string text = Path.GetDirectoryName(this.textBox1.Text);
						if (!text.EndsWith("\\"))
						{
							text += "\\";
						}
						string filename = text + Path.GetFileNameWithoutExtension(this.textBox1.Text) + "_constantsdec" + Path.GetExtension(this.textBox1.Text);
						AssemblyDef assemblyDef = AssemblyDef.Load(this.textBox1.Text);
						ModuleDef manifestModule = assemblyDef.ManifestModule;
						if (manifestModule.IsILOnly)
						{
							ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(manifestModule);
							moduleWriterOptions.MetaDataOptions.Flags |= (MetaDataFlags.PreserveTypeRefRids | MetaDataFlags.PreserveTypeDefRids | MetaDataFlags.PreserveFieldRids | MetaDataFlags.PreserveMethodRids | MetaDataFlags.PreserveParamRids | MetaDataFlags.PreserveMemberRefRids | MetaDataFlags.PreserveStandAloneSigRids | MetaDataFlags.PreserveEventRids | MetaDataFlags.PreservePropertyRids | MetaDataFlags.PreserveTypeSpecRids | MetaDataFlags.PreserveMethodSpecRids | MetaDataFlags.PreserveUSOffsets | MetaDataFlags.PreserveBlobOffsets | MetaDataFlags.PreserveExtraSignatureData | MetaDataFlags.KeepOldMaxStack);
							this.methods = new List<MethodDef>();
							if (manifestModule.HasTypes)
							{
								foreach (TypeDef type in manifestModule.Types)
								{
									this.AddMethods(type);
								}
							}
							int actualnum = 0;
							ArrayList abc = new ArrayList();
							for (int j = 0; j < this.methods[0].Body.Instructions.Count; j++)
							{
								
								if (this.methods[0].Body.Instructions[j].OpCode == OpCodes.Ldsfld && this.methods[0].Body.Instructions[j].Operand.ToString().Contains("Int32>") && this.methods[0].Body.Instructions[j + 1].IsLdcI4() && (this.methods[0].Body.Instructions[j + 2].OpCode == OpCodes.Callvirt || this.methods[0].Body.Instructions[j + 2].OpCode == OpCodes.Call) && this.methods[0].Body.Instructions[j + 2].Operand.ToString().Contains("Add"))
								{
									try
									{
										abc.Add(this.methods[0].Body.Instructions[j + 1].GetLdcI4Value());
									}
									catch (Exception ex)
									{
									}
								}

							}
							
							for (int i = 0; i < this.methods.Count; i++)
							{
								for (int j = 0; j < this.methods[i].Body.Instructions.Count; j++)
								{
									if (this.methods[i].Body.Instructions[j].OpCode == OpCodes.Ldsfld && this.methods[i].Body.Instructions[j].Operand.ToString().Contains("Int32>") && this.methods[i].Body.Instructions[j + 1].IsLdcI4() && (this.methods[i].Body.Instructions[j + 2].OpCode == OpCodes.Callvirt || this.methods[i].Body.Instructions[j + 2].OpCode == OpCodes.Call) && (!this.methods[i].Body.Instructions[j + 2].Operand.ToString().Contains("Add")))
									{
										try
										{
											int ldcI4Value = (int)this.methods[i].Body.Instructions[j + 1].GetLdcI4Value();
											int value = (int)abc[ldcI4Value];
											for (int d = 0; d < 3; d++)
											{
												this.methods[i].Body.Instructions[j + d].OpCode = OpCodes.Nop;
											}
											this.methods[i].Body.Instructions[j].OpCode = OpCodes.Ldc_I4;
											this.methods[i].Body.Instructions[j].Operand = (int)value;
											actualnum++;
										}
										catch
										{
										}

									}
								}
							}
							moduleWriterOptions.Logger = DummyLogger.NoThrowInstance;
							manifestModule.Write(filename, moduleWriterOptions);
							this.label2.Text = actualnum.ToString() + " Fields!";
						}
					}
				}
			}

		public string DirectoryName = "";
		private List<MethodDef> methods = new List<MethodDef>();
		private Assembly assembly;
	}
}
