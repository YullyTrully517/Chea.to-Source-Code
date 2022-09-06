using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CheatoClient
{
	// Token: 0x0200001C RID: 28
	public class AntiSandBox
	{
		// Token: 0x060000CC RID: 204
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x060000CD RID: 205 RVA: 0x0000A0B0 File Offset: 0x000082B0
		public static bool Check()
		{
			bool result;
			try
			{
				bool flag = AntiSandBox.GetModuleHandle("SbieDll.dll").ToInt32() != 0;
				if (flag)
				{
					result = true;
				}
				else
				{
					File.WriteAllText(Application.StartupPath + "\\sandbox.txt", "isWritten");
					string input = File.ReadAllText(Application.StartupPath + "\\sandbox.txt");
					File.Delete(Application.StartupPath + "\\sandbox.txt");
					bool flag2 = input != "isWritten";
					if (flag2)
					{
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			catch
			{
				result = true;
			}
			return result;
		}
	}
}
