using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CheatoClient
{
	// Token: 0x02000025 RID: 37
	internal static class NativeMethods
	{
		// Token: 0x06000157 RID: 343
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

		// Token: 0x06000158 RID: 344
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern IntPtr GetStdHandle(int nStdHandle);

		// Token: 0x06000159 RID: 345
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool AttachConsole(uint dwProcessId);

		// Token: 0x0600015A RID: 346
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool FreeConsole();

		// Token: 0x0600015B RID: 347
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

		// Token: 0x0600015C RID: 348
		[DllImport("psapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool EnumProcessModulesEx([In] IntPtr hProcess, [Out] IntPtr[] lphModule, [In] int cb, out int lpcbNeeded, [In] NativeMethods.ModuleFilterFlags dwFilterFlag);

		// Token: 0x0600015D RID: 349
		[DllImport("psapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern uint GetModuleFileNameEx([In] IntPtr hProcess, [In] IntPtr hModule, [MarshalAs(UnmanagedType.LPTStr)] [Out] StringBuilder lpFilename, uint nSize);

		// Token: 0x040002E4 RID: 740
		internal const int STD_OUTPUT_HANDLE = -11;

		// Token: 0x02000055 RID: 85
		[Flags]
		internal enum ModuleFilterFlags
		{
			// Token: 0x040003C9 RID: 969
			LIST_MODULES_32BIT = 1,
			// Token: 0x040003CA RID: 970
			LIST_MODULES_64BIT = 2,
			// Token: 0x040003CB RID: 971
			LIST_MODULES_ALL = 3,
			// Token: 0x040003CC RID: 972
			LIST_MODULES_DEFAULT = 0
		}
	}
}
