using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;

namespace CheatoClient
{
	// Token: 0x02000026 RID: 38
	[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
	public class RunningProcess
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000D7A4 File Offset: 0x0000B9A4
		public static bool IsOSVersionSupported
		{
			get
			{
				return Environment.OSVersion.Version.Major >= 6;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600015F RID: 351 RVA: 0x0000D7CC File Offset: 0x0000B9CC
		public string ProcessName
		{
			get
			{
				return this.diagnosticsProcess.ProcessName;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000160 RID: 352 RVA: 0x0000D7EC File Offset: 0x0000B9EC
		public int Id
		{
			get
			{
				return this.diagnosticsProcess.Id;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000161 RID: 353 RVA: 0x0000D809 File Offset: 0x0000BA09
		// (set) Token: 0x06000162 RID: 354 RVA: 0x0000D811 File Offset: 0x0000BA11
		public bool IsManaged { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000163 RID: 355 RVA: 0x0000D81A File Offset: 0x0000BA1A
		// (set) Token: 0x06000164 RID: 356 RVA: 0x0000D822 File Offset: 0x0000BA22
		public bool IsDotNet4 { get; private set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000165 RID: 357 RVA: 0x0000D82B File Offset: 0x0000BA2B
		// (set) Token: 0x06000166 RID: 358 RVA: 0x0000D833 File Offset: 0x0000BA33
		public bool IsConsole { get; private set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000167 RID: 359 RVA: 0x0000D83C File Offset: 0x0000BA3C
		// (set) Token: 0x06000168 RID: 360 RVA: 0x0000D844 File Offset: 0x0000BA44
		public bool IsWPF { get; private set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000169 RID: 361 RVA: 0x0000D84D File Offset: 0x0000BA4D
		// (set) Token: 0x0600016A RID: 362 RVA: 0x0000D855 File Offset: 0x0000BA55
		public bool Is64BitProcess { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600016B RID: 363 RVA: 0x0000D85E File Offset: 0x0000BA5E
		// (set) Token: 0x0600016C RID: 364 RVA: 0x0000D866 File Offset: 0x0000BA66
		public string Remarks { get; private set; }

		// Token: 0x0600016D RID: 365 RVA: 0x0000D870 File Offset: 0x0000BA70
		public RunningProcess(Process proc)
		{
			this.diagnosticsProcess = proc;
			try
			{
				this.CheckProcess();
			}
			catch (Exception ex)
			{
				this.Remarks = ex.Message;
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000D8BC File Offset: 0x0000BABC
		public void CheckProcess()
		{
			uint procID = (uint)this.diagnosticsProcess.Id;
			try
			{
				bool flag = NativeMethods.AttachConsole(procID);
				if (flag)
				{
					IntPtr handle = NativeMethods.GetStdHandle(-11);
					uint lp;
					this.IsConsole = NativeMethods.GetConsoleMode(handle, out lp);
					NativeMethods.FreeConsole();
				}
			}
			catch (Exception ex)
			{
				this.Remarks += string.Format("| Check IsConsole: {0}", ex.Message);
			}
			try
			{
				List<string> loadedModules = this.GetLoadedModules();
				this.IsManaged = (loadedModules.Count((string m) => m.Equals("MSCOREE.dll", StringComparison.OrdinalIgnoreCase)) > 0);
				bool isManaged = this.IsManaged;
				if (isManaged)
				{
					this.IsDotNet4 = (loadedModules.Count((string m) => m.Equals("CLR.dll", StringComparison.OrdinalIgnoreCase)) > 0);
					this.IsWPF = (loadedModules.Count((string m) => m.Equals("PresentationCore.dll", StringComparison.OrdinalIgnoreCase) || m.Equals("PresentationCore.ni.dll", StringComparison.OrdinalIgnoreCase)) > 0);
				}
			}
			catch (Exception ex2)
			{
				this.Remarks += string.Format("| Check IsManaged: {0}", ex2.Message);
			}
			try
			{
				this.Is64BitProcess = this.Check64BitProcess();
			}
			catch (Exception ex3)
			{
				this.Remarks += string.Format("| Check Is64Bit: {0}", ex3.Message);
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000DA64 File Offset: 0x0000BC64
		public List<string> GetLoadedModules()
		{
			bool flag = Environment.OSVersion.Version.Major < 6;
			if (flag)
			{
				throw new ApplicationException("This application must run on Windows Vista or later versions. ");
			}
			IntPtr[] modulesHandles = new IntPtr[1024];
			int num;
			bool success = NativeMethods.EnumProcessModulesEx(this.diagnosticsProcess.Handle, modulesHandles, Marshal.SizeOf(typeof(IntPtr)) * modulesHandles.Length, out num, NativeMethods.ModuleFilterFlags.LIST_MODULES_ALL);
			bool flag2 = !success;
			if (flag2)
			{
				throw new Win32Exception();
			}
			List<string> moduleNames = new List<string>();
			for (int i = 0; i < modulesHandles.Length; i++)
			{
				bool flag3 = modulesHandles[i] == IntPtr.Zero;
				if (flag3)
				{
					break;
				}
				StringBuilder moduleName = new StringBuilder(1024);
				uint length = NativeMethods.GetModuleFileNameEx(this.diagnosticsProcess.Handle, modulesHandles[i], moduleName, (uint)moduleName.Capacity);
				bool flag4 = length <= 0U;
				if (!flag4)
				{
					string fileName = Path.GetFileName(moduleName.ToString());
					moduleNames.Add(fileName);
				}
			}
			return moduleNames;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000DB70 File Offset: 0x0000BD70
		public bool Check64BitProcess()
		{
			bool flag = false;
			bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
			if (is64BitOperatingSystem)
			{
				flag = (!NativeMethods.IsWow64Process(this.diagnosticsProcess.Handle, out flag) || !flag);
			}
			return flag;
		}

		// Token: 0x040002E5 RID: 741
		private Process diagnosticsProcess;
	}
}
