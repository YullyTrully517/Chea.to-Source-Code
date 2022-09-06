using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CheatoClient
{
	// Token: 0x0200000C RID: 12
	public class Is64BitChecker
	{
		// Token: 0x06000061 RID: 97
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWow64Process([In] IntPtr hProcess, out bool wow64Process);

		// Token: 0x06000062 RID: 98 RVA: 0x000068EC File Offset: 0x00004AEC
		public static bool GetProcessIsWow64(IntPtr hProcess)
		{
			bool flag = (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) || Environment.OSVersion.Version.Major >= 6;
			bool result;
			if (flag)
			{
				bool retVal;
				bool flag2 = !Is64BitChecker.IsWow64Process(hProcess, out retVal);
				result = (!flag2 && retVal);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000695C File Offset: 0x00004B5C
		public static bool InternalCheckIsWow64()
		{
			bool flag = (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) || Environment.OSVersion.Version.Major >= 6;
			if (flag)
			{
				using (Process p = Process.GetCurrentProcess())
				{
					bool retVal;
					bool flag2 = !Is64BitChecker.IsWow64Process(p.Handle, out retVal);
					if (flag2)
					{
						return false;
					}
					return retVal;
				}
			}
			return false;
		}
	}
}
