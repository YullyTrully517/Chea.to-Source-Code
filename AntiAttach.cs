using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Sentry;

namespace CheatoClient
{
	// Token: 0x02000011 RID: 17
	internal class AntiAttach
	{
		// Token: 0x06000098 RID: 152
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandleW(string lib);

		// Token: 0x06000099 RID: 153
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandleA(string lib);

		// Token: 0x0600009A RID: 154
		[DllImport("kernel32.dll")]
		public static extern void FreeLibraryAndExitThread(IntPtr hModule, uint dwExitCode);

		// Token: 0x0600009B RID: 155 RVA: 0x00008378 File Offset: 0x00006578
		[DebuggerStepThrough]
		public static void Start()
		{
			AntiAttach.<Start>d__8 <Start>d__ = new AntiAttach.<Start>d__8();
			<Start>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Start>d__.<>1__state = -1;
			<Start>d__.<>t__builder.Start<AntiAttach.<Start>d__8>(ref <Start>d__);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000083AC File Offset: 0x000065AC
		public static void AntiDLLInjection()
		{
			RunningProcess runningProcess = new RunningProcess(Process.GetCurrentProcess());
			foreach (string loaded in runningProcess.GetLoadedModules())
			{
				bool WhiteListed = false;
				foreach (string whitelisted in AntiAttach.Whitelist)
				{
					bool flag = loaded.Trim().ToLower().Contains(whitelisted.Trim().ToLower());
					if (flag)
					{
						WhiteListed = true;
						break;
					}
				}
				bool flag2 = !WhiteListed;
				if (flag2)
				{
					try
					{
						IntPtr ModuleHandle = AntiAttach.GetModuleHandleA(loaded);
						Console.WriteLine("Unattaching " + loaded.Trim() + " and killing self thread " + Thread.CurrentThread.ManagedThreadId.ToString());
						AntiAttach.FreeLibraryAndExitThread(ModuleHandle, 0U);
						ModuleHandle = AntiAttach.GetModuleHandleA(loaded);
						Process.GetCurrentProcess().Kill();
						bool killOnDetection = AntiAttach.KillOnDetection;
						if (killOnDetection)
						{
							SentrySdk.CaptureMessage("Detected injected module: " + loaded, SentryLevel.Info);
							Process.GetCurrentProcess().Kill();
						}
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x04000044 RID: 68
		public static string[] Whitelist = new string[]
		{
			AppDomain.CurrentDomain.FriendlyName,
			"advapi32.dll",
			"amsi.dll",
			"appresolver.dll",
			"apphelp.dll",
			"appxsip.dll",
			"bcp47langs.dll",
			"bcrypt.dll",
			"bcryptprimitives.dll",
			"cfgmgr32.dll",
			"clbcatq.dll",
			"clr.dll",
			"clrcompression.dll",
			"clrjit.dll",
			"combase.dll",
			"comctl32.dll",
			"CoreMessaging.dll",
			"CoreUIComponents.dll",
			"crypt32.dll",
			"cryptbase.dll",
			"cryptnet.dll",
			"cryptsp.dll",
			"diasymreader.dll",
			"devobj.dll",
			"dhcpcsvc.dll",
			"dhcpcsvc6.dll",
			"dnsapi.dll",
			"DWrite.dll",
			"fastprox.dll",
			"fwpuclnt.dll",
			"gdi32.dll",
			"gdi32full.dll",
			"gdiplus.dll",
			"gpapi.dll",
			"imm32.dll",
			"iphlpapi.dll",
			"kernel.appcore.dll",
			"kernel32.dll",
			"kernelbase.dll",
			"mdnsnsp.dll",
			"microsoft.bcl.asyncinterfaces.ni.dll",
			"microsoft.management.infrastructure.ni.dll",
			"microsoft.powershell.commands.diagnostics.ni.dll",
			"microsoft.powershell.commands.management.ni.dll",
			"microsoft.powershell.commands.utility.ni.dll",
			"microsoft.powershell.consolehost.ni.dll",
			"microsoft.powershell.security.ni.dll",
			"microsoft.secureboot.commands.ni.dll",
			"microsoft.tpm.commands.ni.dll",
			"microsoft.wsman.management.ni.dll",
			"mmdevapi.dll",
			"mpoav.dll",
			"msasn1.dll",
			"mscoree.dll",
			"mscoreei.dll",
			"mscorlib.ni.dll",
			"msctf.dll",
			"msisip.dll",
			"mskeyprotect.dll",
			"msvcp_win.dll",
			"msvcrt.dll",
			"mswsock.dll",
			"msxml6.dll",
			"napinsp.dll",
			"ncrypt.dll",
			"ncryptsslp.dll",
			"nlansp_c.dll",
			"nsi.dll",
			"ntasn1.dll",
			"ntdll.dll",
			"ole32.dll",
			"oleaut32.dll",
			"onecoreuapcommonproxystub.dll",
			"pnrpnsp.dll",
			"profapi.dll",
			"propsys.dll",
			"prxyqry.dll",
			"psapi.dll",
			"pwrshsip.dll",
			"rasadhlp.dll",
			"rasapi32.dll",
			"rasman.dll",
			"rpcrt4.dll",
			"rsaenh.dll",
			"rtutils.dll",
			"schannel.dll",
			"sechost.dll",
			"secur32.dll",
			"shcore.dll",
			"shell32.dll",
			"shlwapi.dll",
			"sspicli.dll",
			"system.buffers.ni.dll",
			"system.configuration.install.ni.dll",
			"system.configuration.ni.dll",
			"system.core.ni.dll",
			"system.data.dll",
			"system.data.ni.dll",
			"system.directoryservices.ni.dll",
			"system.drawing.ni.dll",
			"system.management.automation.ni.dll",
			"system.management.ni.dll",
			"system.memory.ni.dll",
			"system.net.http.ni.dll",
			"system.ni.dll",
			"system.numerics.ni.dll",
			"System.Reflection.Metadata.ni.dll",
			"system.runtime.compilerservices.unsafe.ni.dll",
			"system.runtime.interopservices.runtimeinformation.ni.dll",
			"system.runtime.interopservices.windowsruntime.ni.dll",
			"system.runtime.ni.dll",
			"system.serviceprocess.ni.dll",
			"system.threading.tasks.extensions.ni.dll",
			"system.transactions.dll",
			"system.transactions.ni.dll",
			"system.valuetuple.ni.dll",
			"system.web.extensions.ni.dll",
			"system.web.ni.dll",
			"system.windows.forms.ni.dll",
			"system.xml.ni.dll",
			"textinputframework.dll",
			"TextShaping.dll",
			"tbs.dll",
			"tpmcoreprovisioning.dll",
			"ucrtbase.dll",
			"ucrtbase_clr0400.dll",
			"umpdc.dll",
			"user32.dll",
			"userenv.dll",
			"uxtheme.dll",
			"vcruntime140_clr0400.dll",
			"version.dll",
			"wbemcomn.dll",
			"wbemprox.dll",
			"wbemsvc.dll",
			"webengine4.dll",
			"webio.dll",
			"win32u.dll",
			"windows.applicationmodel.dll",
			"Windows.StateRepositoryPS.dll",
			"windows.storage.dll",
			"windows.storage.ni.dll",
			"windowscodecs.dll",
			"winhttp.dll",
			"winnsi.dll",
			"winrnr.dll",
			"winmmbase.dll",
			"wintrust.dll",
			"wintypes.dll",
			"wldp.dll",
			"wminet_utils.dll",
			"wmiutils.dll",
			"wpnapps.dll",
			"ws2_32.dll",
			"wshbth.dll",
			"wshext.dll",
			"edputil.dll",
			"iertutil.dll",
			"netutils.dll",
			"srvcli.dll",
			"urlmon.dll",
			"vaultcli.dll",
			"ntmarta.dll"
		};

		// Token: 0x04000045 RID: 69
		public static bool KeepAlive = true;

		// Token: 0x04000046 RID: 70
		public static bool Detected = false;

		// Token: 0x04000047 RID: 71
		public static bool KillOnDetection = false;

		// Token: 0x04000048 RID: 72
		public static bool Abort = false;
	}
}
