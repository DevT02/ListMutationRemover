using System;
using System.Windows.Forms;

namespace ConfuserExConstantDecryptor
{
	// Token: 0x02000265 RID: 613
	internal sealed class Program
	{
		// Token: 0x06001D8B RID: 7563 RVA: 0x0007A9F0 File Offset: 0x000799F0
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
