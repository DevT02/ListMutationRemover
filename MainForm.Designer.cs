namespace ConfuserExConstantDecryptor
{
	// Token: 0x02000264 RID: 612
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06001D89 RID: 7561 RVA: 0x0007A5A0 File Offset: 0x000795A0
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001D8A RID: 7562 RVA: 0x0007A5DC File Offset: 0x000795DC
		private void InitializeComponent()
		{
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(393, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 26);
            this.button3.TabIndex = 35;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 26);
            this.button2.TabIndex = 34;
            this.button2.Text = "Decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 26);
            this.button1.TabIndex = 33;
            this.button1.Text = "Browse for assembly";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(112, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "Current status";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(46, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "Name of assembly:";
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(46, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(419, 20);
            this.textBox1.TabIndex = 30;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox1DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox1DragEnter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 152);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "MainForm";
            this.Text = "ListMutationRemover -  by OFF_LINE#6596";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000D96 RID: 3478
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000D97 RID: 3479
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x04000D98 RID: 3480
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000D99 RID: 3481
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000D9A RID: 3482
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000D9B RID: 3483
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000D9C RID: 3484
		private global::System.Windows.Forms.Button button3;
	}
}
