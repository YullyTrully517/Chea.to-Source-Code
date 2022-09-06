using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace CheatoClient
{
	// Token: 0x0200001B RID: 27
	public class AntiReverserTools
	{
		// Token: 0x060000C4 RID: 196
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool QueryFullProcessImageName([In] IntPtr hProcess, [In] int dwFlags, [Out] StringBuilder lpExeName, ref int lpdwSize);

		// Token: 0x060000C5 RID: 197
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(AntiReverserTools.ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

		// Token: 0x060000C6 RID: 198 RVA: 0x00009910 File Offset: 0x00007B10
		public static string GetProcessFilename(Process p)
		{
			int capacity = 2000;
			StringBuilder builder = new StringBuilder(capacity);
			IntPtr ptr = AntiReverserTools.OpenProcess(AntiReverserTools.ProcessAccessFlags.QueryLimitedInformation, false, p.Id);
			bool flag = !AntiReverserTools.QueryFullProcessImageName(ptr, 0, builder, ref capacity);
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = builder.ToString();
			}
			return result;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00009964 File Offset: 0x00007B64
		public static void Start()
		{
			AntiReverserTools.ScanProcess();
			AntiReverserTools.ScanService();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00009974 File Offset: 0x00007B74
		[DebuggerStepThrough]
		private static void ScanProcess()
		{
			AntiReverserTools.<ScanProcess>d__18 <ScanProcess>d__ = new AntiReverserTools.<ScanProcess>d__18();
			<ScanProcess>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<ScanProcess>d__.<>1__state = -1;
			<ScanProcess>d__.<>t__builder.Start<AntiReverserTools.<ScanProcess>d__18>(ref <ScanProcess>d__);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000099A8 File Offset: 0x00007BA8
		[DebuggerStepThrough]
		private static void ScanService()
		{
			AntiReverserTools.<ScanService>d__19 <ScanService>d__ = new AntiReverserTools.<ScanService>d__19();
			<ScanService>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<ScanService>d__.<>1__state = -1;
			<ScanService>d__.<>t__builder.Start<AntiReverserTools.<ScanService>d__19>(ref <ScanService>d__);
		}

		// Token: 0x040002B1 RID: 689
		private static Process[] Processes;

		// Token: 0x040002B2 RID: 690
		public static bool Detected = false;

		// Token: 0x040002B3 RID: 691
		private static bool WhiteListed = false;

		// Token: 0x040002B4 RID: 692
		public static bool KeepAlive = true;

		// Token: 0x040002B5 RID: 693
		public static bool KillOnDetection = false;

		// Token: 0x040002B6 RID: 694
		public static string[] BlackList = new string[]
		{
			"dnspy",
			"ollydbg",
			"dumper",
			"wireshark",
			"httpdebugger",
			"http debugger",
			"fiddler",
			"inject",
			"decompiler",
			"unpacker",
			"deobfuscator",
			"de4dot",
			"confuser",
			" /snd",
			"x64dbg",
			"x32dbg",
			"x96dbg",
			"scylla",
			"dbgclr",
			"perfmon",
			"qt5core",
			"[cpu",
			"importREC",
			"hxd",
			"disassembl",
			"codecracker",
			"protection_id",
			"simpleassembly",
			"debugger",
			"netdumper",
			"process hacker",
			"dotpeek",
			".net reflector",
			"ilspy",
			"file monitoring",
			"file monitor",
			"files monitor",
			"netsharemonitor",
			"fileactivitywatcher",
			"fileactivitywatch",
			"windows explorer tracker",
			"process monitor",
			"disk plus",
			"file activity monitor",
			"fileactivitymonitor",
			"file access monitor",
			"mtail",
			"snaketail",
			"tail -n",
			"httpnetworksniffer",
			"microsoft message analyzer",
			"networkmonitor",
			"network monitor",
			"soap monitor",
			"internet traffic agent",
			"socketsniff",
			"networkminer",
			"network debugger",
			"megadumper",
			"notdumper by temnij",
			"procmon",
			"ghidra",
			"sandboxie",
			"tcpview",
			"networkminer",
			"lasso",
			"reflector",
			"unpack",
			"sniff",
			"ida",
			"procdump",
			"vmmap",
			"junction",
			"adinsight",
			"procexp",
			"sigcheck",
			"sysmon",
			"vmpdump",
			"pipelist",
			"streams",
			"dbgview",
			"coreinfo",
			"livekd",
			"rammap",
			"cheat engine",
			"nopde engine",
			"lunar engine",
			"ksdumper",
			"ksdumperclient",
			"xenos",
			"psfile",
			"pslist",
			"decryptor",
			"decrypter",
			"managedjiter",
			"process viewer",
			"knif",
			"cawk",
			"reclass",
			"-bit, .NET Framework",
			"-bit, .NET,",
			"folderchangesview",
			string.Concat(new string[]
			{
				"[",
				Environment.MachineName,
				"\\",
				Environment.UserName,
				"]"
			}),
			"WinObjEx64",
			"xenservice",
			"qemu-ga",
			"vboxservice",
			"vboxtray",
			"vmtoolsd",
			"vmwaretray",
			"vmwareuser",
			"VGAuthService",
			"vmacthlp",
			"vmsrvc",
			"vmusrvc",
			"prl_cc",
			"prl_tools",
			"kdstinker",
			"M*3*G*4",
			"D*u*m*p"
		};

		// Token: 0x040002B7 RID: 695
		public static string[] DirBlacklist = new string[]
		{
			"dnlib.dll",
			"bin\\dnlib.dll",
			"ceregreset.exe",
			"ced3d11hook64.dll",
			"speedhack-x86_64.dll",
			"winhook-x86_64.dll",
			"Mono.Debugger.Soft.dll",
			"ICSharpCode.Decompiler.dll",
			"AsmResolver.dll",
			"bin\\AsmResolver.dll",
			"de4dot.blocks.dll",
			"bin\\de4dot.blocks.dll",
			"0Harmony.dll",
			"bin\\0Harmony.dll",
			"ida64.dll",
			"SharpDisasm.dll",
			"CawkEmulatorV4.dll",
			"bin\\CawkEmulatorV4.dll",
			"Mono.Cecil.dll",
			"bin\\Mono.Cecil.dll",
			"pd.exe",
			"pd64.exe",
			"KsDumperClient.pdb",
			"Driver\\KsDumperDriver.sys",
			"KsDumperDriver.sys",
			"avghookx.dll",
			"avghooka.dll",
			"snxhk.dll",
			"sbiedll.dll",
			"api_log.dll",
			"dir_watch.dll",
			"vmcheck.dll",
			"wpespy.dll",
			"cmdvrt32.dll",
			"cmdvrt64.dll",
			"kdstinker.sys"
		};

		// Token: 0x040002B8 RID: 696
		public static string[] ServiceBlacklist = new string[]
		{
			"ProcessHacker",
			"VBoxWddm",
			"VBoxSF",
			"VBoxMouse",
			"VBoxGuest",
			"vmci",
			"vmhgfs",
			"vmmouse",
			"vmmemctl",
			"vmusb",
			"vmusbmouse",
			"vmx_svga",
			"vmxnet",
			"vmx86",
			"hyperkbd",
			"VMBusHID",
			"vmbus"
		};

		// Token: 0x040002B9 RID: 697
		public static string[] WhiteList = new string[0];

		// Token: 0x040002BA RID: 698
		public static string[] WhitelistTitle = new string[0];

		// Token: 0x040002BB RID: 699
		public static bool Abort = false;

		// Token: 0x040002BC RID: 700
		public static Thread scanThread = new Thread(new ThreadStart(AntiReverserTools.ScanProcess))
		{
			IsBackground = true
		};

		// Token: 0x040002BD RID: 701
		public static Thread scanSvcThread = new Thread(new ThreadStart(AntiReverserTools.ScanService))
		{
			IsBackground = true
		};

		// Token: 0x02000041 RID: 65
		[Flags]
		private enum ProcessAccessFlags : uint
		{
			// Token: 0x0400036C RID: 876
			QueryLimitedInformation = 4096U
		}
	}
}
