using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace CheatoClient
{
	// Token: 0x02000012 RID: 18
	public class AntiDebugger
	{
		// Token: 0x0600009F RID: 159
		[DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
		internal static extern IntPtr VM34523865(string a);

		// Token: 0x060000A0 RID: 160
		[DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
		internal static extern IntPtr VM89283879(IntPtr a, string b);

		// Token: 0x060000A1 RID: 161
		[DllImport("kernel32.dll", EntryPoint = "VirtualProtect")]
		internal static extern IntPtr VM607063457(IntPtr a, int b, uint c, ref uint d);

		// Token: 0x060000A2 RID: 162
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

		// Token: 0x060000A3 RID: 163 RVA: 0x00008B88 File Offset: 0x00006D88
		[DebuggerStepThrough]
		public static void Start()
		{
			AntiDebugger.<Start>d__9 <Start>d__ = new AntiDebugger.<Start>d__9();
			<Start>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Start>d__.<>1__state = -1;
			<Start>d__.<>t__builder.Start<AntiDebugger.<Start>d__9>(ref <Start>d__);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00008BBC File Offset: 0x00006DBC
		public unsafe static bool CheckKernelDebugInformation()
		{
			SystemKernelDebuggerInformation structure = default(SystemKernelDebuggerInformation);
			int num;
			return AntiDebugger.NtQuerySystemInformation(SystemInformationClass.SystemKernelDebuggerInformation, new IntPtr((void*)(&structure)), Marshal.SizeOf<SystemKernelDebuggerInformation>(structure), out num) == NtStatus.Success && structure.KernelDebuggerEnabled && !structure.KernelDebuggerNotPresent;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00008C10 File Offset: 0x00006E10
		public static void AntiDebuggerAttach()
		{
			IntPtr NtdllModule = AntiDebugger.GetModuleHandle("ntdll.dll");
			IntPtr DbgUiRemoteBreakinAddress = AntiDebugger.GetProcAddress(NtdllModule, "DbgUiRemoteBreakin");
			IntPtr DbgUiConnectToDbgAddress = AntiDebugger.GetProcAddress(NtdllModule, "DbgUiConnectToDbg");
			byte[] Int3InvaildCode = new byte[]
			{
				204
			};
			AntiDebugger.WriteProcessMemory(Process.GetCurrentProcess().Handle, DbgUiRemoteBreakinAddress, Int3InvaildCode, 6U, 0);
			AntiDebugger.WriteProcessMemory(Process.GetCurrentProcess().Handle, DbgUiConnectToDbgAddress, Int3InvaildCode, 6U, 0);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00008C78 File Offset: 0x00006E78
		public static void HideOsThreads()
		{
			foreach (object obj in Process.GetCurrentProcess().Threads)
			{
				ProcessThread thread = (ProcessThread)obj;
				IntPtr intPtr = AntiDebugger.OpenThread(ThreadAccess.SetInformation, false, (uint)thread.Id);
				bool flag = !(intPtr == IntPtr.Zero);
				if (flag)
				{
					AntiDebugger.HideThreadFromDebugger(intPtr);
					AntiDebugger.CloseHandle(intPtr);
				}
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00008D08 File Offset: 0x00006F08
		public static bool HideThreadFromDebugger(IntPtr handle)
		{
			return AntiDebugger.NtSetInformationThread(handle, ThreadInformationClass.ThreadHideFromDebugger, IntPtr.Zero, 0) == NtStatus.Success;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00008D2C File Offset: 0x00006F2C
		public unsafe static bool DetachFromDebuggerProcess()
		{
			uint structure = 0U;
			IntPtr processInformation;
			int num;
			bool flag = AntiDebugger.NtQueryInformationProcess(Process.GetCurrentProcess().Handle, ProcessInfoClass.ProcessDebugObjectHandle, out processInformation, IntPtr.Size, out num) > NtStatus.Success;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = AntiDebugger.NtSetInformationDebugObject(processInformation, DebugObjectInformationClass.DebugObjectFlags, new IntPtr((void*)(&structure)), Marshal.SizeOf<uint>(structure), out num) > NtStatus.Success;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = AntiDebugger.NtRemoveProcessDebug(Process.GetCurrentProcess().Handle, processInformation) > NtStatus.Success;
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = AntiDebugger.NtClose(processInformation) > NtStatus.Success;
						result = !flag4;
					}
				}
			}
			return result;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00008DC4 File Offset: 0x00006FC4
		public static bool CheckRemoteDebugger()
		{
			bool isDebuggerPresent = false;
			return AntiDebugger.CheckRemoteDebuggerPresent(Process.GetCurrentProcess().SafeHandle, ref isDebuggerPresent) && isDebuggerPresent;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00008DEC File Offset: 0x00006FEC
		public static bool CheckDebugPort()
		{
			IntPtr processInformation = new IntPtr(0);
			int num;
			return AntiDebugger.NtQueryInformationProcess(Process.GetCurrentProcess().Handle, ProcessInfoClass.ProcessDebugPort, out processInformation, Marshal.SizeOf<IntPtr>(processInformation), out num) == NtStatus.Success && processInformation == new IntPtr(-1);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00008E3C File Offset: 0x0000703C
		public static bool CloseHandleAntiDebug()
		{
			try
			{
				AntiDebugger.CloseHandle((IntPtr)14258465L);
				AntiDebugger.CloseHandle((IntPtr)19075618L);
				return false;
			}
			catch (Exception ex)
			{
				bool flag = ex.Message == "External component has thrown an exception.";
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000AC RID: 172
		[DllImport("Kernel32.dll", ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool CheckRemoteDebuggerPresent(SafeHandle hProcess, [MarshalAs(UnmanagedType.Bool)] ref bool isDebuggerPresent);

		// Token: 0x060000AD RID: 173
		[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern NtStatus NtQueryInformationProcess([In] IntPtr processHandle, [In] ProcessInfoClass processInformationClass, out IntPtr processInformation, [In] int processInformationLength, [Optional] out int returnLength);

		// Token: 0x060000AE RID: 174
		[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern NtStatus NtClose([In] IntPtr handle);

		// Token: 0x060000AF RID: 175
		[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern NtStatus NtRemoveProcessDebug(IntPtr processHandle, IntPtr debugObjectHandle);

		// Token: 0x060000B0 RID: 176
		[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern NtStatus NtSetInformationDebugObject(IntPtr debugObjectHandle, DebugObjectInformationClass debugObjectInformationClass, IntPtr debugObjectInformation, int debugObjectInformationLength, out int returnLength);

		// Token: 0x060000B1 RID: 177
		[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern NtStatus NtQuerySystemInformation(SystemInformationClass systemInformationClass, IntPtr systemInformation, int systemInformationLength, out int returnLength);

		// Token: 0x060000B2 RID: 178
		[DllImport("ntdll.dll")]
		internal static extern NtStatus NtSetInformationThread(IntPtr threadHandle, ThreadInformationClass threadInformationClass, IntPtr threadInformation, int threadInformationLength);

		// Token: 0x060000B3 RID: 179
		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

		// Token: 0x060000B4 RID: 180
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool CloseHandle(IntPtr handle);

		// Token: 0x060000B5 RID: 181
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr Module, string Function);

		// Token: 0x060000B6 RID: 182
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool WriteProcessMemory(IntPtr ProcHandle, IntPtr BaseAddress, byte[] Buffer, uint size, int NumOfBytes);

		// Token: 0x060000B7 RID: 183
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lib);

		// Token: 0x060000B8 RID: 184 RVA: 0x00008EA4 File Offset: 0x000070A4
		private static void DebuggerThread(object arg)
		{
			AntiDebugger.DEBUG_EVENT evt = new AntiDebugger.DEBUG_EVENT
			{
				bytes = new byte[1024]
			};
			bool flag = !AntiDebugger.DebugActiveProcess((int)arg);
			if (flag)
			{
				throw new Win32Exception();
			}
			for (;;)
			{
				bool flag2 = !AntiDebugger.WaitForDebugEvent(out evt, -1);
				if (flag2)
				{
					break;
				}
				int continueFlag = 65538;
				bool flag3 = evt.dwDebugEventCode == AntiDebugger.DebugEventType.EXCEPTION_DEBUG_EVENT;
				if (flag3)
				{
					continueFlag = -2147418111;
				}
				AntiDebugger.ContinueDebugEvent(evt.dwProcessId, evt.dwThreadId, continueFlag);
			}
			throw new Win32Exception();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00008F34 File Offset: 0x00007134
		public static void DebugSelf(int ppid)
		{
			Console.WriteLine("Debugging {0}", ppid);
			Process self = Process.GetCurrentProcess();
			bool flag = ppid != 0;
			if (flag)
			{
				Console.WriteLine("Child Process");
				Process pdbg = Process.GetProcessById(ppid);
				new Thread(new ParameterizedThreadStart(AntiDebugger.KillOnExit))
				{
					IsBackground = true,
					Name = "KillOnExit"
				}.Start(pdbg);
				AntiDebugger.WaitForDebugger();
				AntiDebugger.DebuggerThread(ppid);
				Environment.Exit(1);
			}
			else
			{
				Console.WriteLine("Parent Process");
				ProcessStartInfo psi = new ProcessStartInfo(Environment.GetCommandLineArgs()[0], self.Id.ToString())
				{
					UseShellExecute = false,
					CreateNoWindow = false,
					ErrorDialog = false
				};
				Process pdbg2 = Process.Start(psi);
				bool flag2 = pdbg2 == null;
				if (flag2)
				{
					throw new ApplicationException("Unable to debug");
				}
				new Thread(new ParameterizedThreadStart(AntiDebugger.KillOnExit))
				{
					IsBackground = true,
					Name = "KillOnExit"
				}.Start(pdbg2);
				new Thread(new ParameterizedThreadStart(AntiDebugger.DebuggerThread))
				{
					IsBackground = true,
					Name = "DebuggerThread"
				}.Start(pdbg2.Id);
				AntiDebugger.WaitForDebugger();
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00009088 File Offset: 0x00007288
		private static void WaitForDebugger()
		{
			DateTime start = DateTime.Now;
			while (!AntiDebugger.IsDebuggerPresent())
			{
				bool flag = (DateTime.Now - start).TotalMinutes > 1.0;
				if (flag)
				{
					throw new TimeoutException("Debug operation timeout.");
				}
				Thread.Sleep(1);
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000090E0 File Offset: 0x000072E0
		private static void KillOnExit(object process)
		{
			((Process)process).WaitForExit();
			Environment.Exit(1);
		}

		// Token: 0x060000BC RID: 188
		[DllImport("Kernel32.dll", SetLastError = true)]
		private static extern bool DebugActiveProcess(int dwProcessId);

		// Token: 0x060000BD RID: 189
		[DllImport("Kernel32.dll", SetLastError = true)]
		private static extern bool WaitForDebugEvent(out AntiDebugger.DEBUG_EVENT lpDebugEvent, int dwMilliseconds);

		// Token: 0x060000BE RID: 190
		[DllImport("Kernel32.dll", SetLastError = true)]
		private static extern bool ContinueDebugEvent(int dwProcessId, int dwThreadId, int dwContinueStatus);

		// Token: 0x060000BF RID: 191
		[DllImport("Kernel32.dll", SetLastError = true)]
		public static extern bool IsDebuggerPresent();

		// Token: 0x04000049 RID: 73
		private static bool isDebuggerPresent = false;

		// Token: 0x0400004A RID: 74
		public static bool KeepAlive = true;

		// Token: 0x0400004B RID: 75
		public static bool Detected = false;

		// Token: 0x0400004C RID: 76
		public static bool KillOnDetection = false;

		// Token: 0x0400004D RID: 77
		public static bool Abort = false;

		// Token: 0x0400004E RID: 78
		private const int DBG_CONTINUE = 65538;

		// Token: 0x0400004F RID: 79
		private const int DBG_EXCEPTION_NOT_HANDLED = -2147418111;

		// Token: 0x0200003E RID: 62
		private enum DebugEventType
		{
			// Token: 0x0400035B RID: 859
			CREATE_PROCESS_DEBUG_EVENT = 3,
			// Token: 0x0400035C RID: 860
			CREATE_THREAD_DEBUG_EVENT = 2,
			// Token: 0x0400035D RID: 861
			EXCEPTION_DEBUG_EVENT = 1,
			// Token: 0x0400035E RID: 862
			EXIT_PROCESS_DEBUG_EVENT = 5,
			// Token: 0x0400035F RID: 863
			EXIT_THREAD_DEBUG_EVENT = 4,
			// Token: 0x04000360 RID: 864
			LOAD_DLL_DEBUG_EVENT = 6,
			// Token: 0x04000361 RID: 865
			OUTPUT_DEBUG_STRING_EVENT = 8,
			// Token: 0x04000362 RID: 866
			RIP_EVENT,
			// Token: 0x04000363 RID: 867
			UNLOAD_DLL_DEBUG_EVENT = 7
		}

		// Token: 0x0200003F RID: 63
		private struct DEBUG_EVENT
		{
			// Token: 0x04000364 RID: 868
			[MarshalAs(UnmanagedType.I4)]
			public AntiDebugger.DebugEventType dwDebugEventCode;

			// Token: 0x04000365 RID: 869
			public int dwProcessId;

			// Token: 0x04000366 RID: 870
			public int dwThreadId;

			// Token: 0x04000367 RID: 871
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
			public byte[] bytes;
		}
	}
}
