using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using Sentry;

namespace CheatoClient
{
	// Token: 0x0200001F RID: 31
	internal class Functions
	{
		// Token: 0x060000E2 RID: 226
		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x060000E3 RID: 227
		[DllImport("user32.dll", ExactSpelling = true)]
		public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x060000E4 RID: 228
		[DllImport("gdi32.dll", ExactSpelling = true)]
		public static extern IntPtr BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

		// Token: 0x060000E5 RID: 229
		[DllImport("user32.dll")]
		public static extern IntPtr GetDesktopWindow();

		// Token: 0x060000E6 RID: 230
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr LoadLibrary(string string_0);

		// Token: 0x060000E7 RID: 231
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr LoadLibraryEx(string string_0, IntPtr intptr_0, uint uint_0);

		// Token: 0x060000E8 RID: 232
		[DllImport("user32.dll")]
		public static extern int SetForegroundWindow(IntPtr intptr_0);

		// Token: 0x060000E9 RID: 233
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PrintWindow(IntPtr intptr_0, IntPtr intptr_1, uint uint_0);

		// Token: 0x060000EA RID: 234
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetWindowText(IntPtr intptr_0, string string_0);

		// Token: 0x060000EB RID: 235
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string string_0, string string_1);

		// Token: 0x060000EC RID: 236
		[DllImport("user32.dll", SetLastError = true)]
		public static extern void mouse_event(int int_0, int int_1, int int_2, int int_3, int int_4);

		// Token: 0x060000ED RID: 237
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr GetWindowLong(IntPtr intptr_0, int int_0);

		// Token: 0x060000EE RID: 238
		[DllImport("user32.dll")]
		public static extern IntPtr SetWindowLongPtr(IntPtr intptr_0, int int_0, IntPtr intptr_1);

		// Token: 0x060000EF RID: 239
		[DllImport("user32.dll")]
		public static extern bool SetLayeredWindowAttributes(IntPtr intptr_0, uint uint_0, byte byte_0, uint uint_1);

		// Token: 0x060000F0 RID: 240
		[DllImport("user32.dll")]
		public static extern IntPtr SetWindowPos(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5);

		// Token: 0x060000F1 RID: 241
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int int_0, bool bool_0, int int_1);

		// Token: 0x060000F2 RID: 242
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetModuleHandle(string string_0);

		// Token: 0x060000F3 RID: 243
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr intptr_0, string string_0);

		// Token: 0x060000F4 RID: 244
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr VirtualAllocEx(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, uint uint_1, uint uint_2);

		// Token: 0x060000F5 RID: 245
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, uint uint_0, out UIntPtr uintptr_0);

		// Token: 0x060000F6 RID: 246
		[DllImport("kernel32.dll")]
		public static extern IntPtr CreateRemoteThread(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, IntPtr intptr_2, IntPtr intptr_3, uint uint_1, IntPtr intptr_4);

		// Token: 0x060000F7 RID: 247
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr intptr_0, int int_0);

		// Token: 0x060000F8 RID: 248
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetFileTime(IntPtr intptr_0, ref long long_0, ref long long_1, ref long long_2);

		// Token: 0x060000F9 RID: 249
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CreateFile([MarshalAs(UnmanagedType.LPTStr)] string string_0, [MarshalAs(UnmanagedType.U4)] Enum enum36_0, [MarshalAs(UnmanagedType.U4)] Enum enum10_0, IntPtr intptr_0, [MarshalAs(UnmanagedType.U4)] Enum enum75_0, [MarshalAs(UnmanagedType.U4)] Enum enum57_0, IntPtr intptr_1);

		// Token: 0x060000FA RID: 250
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern IntPtr CreateFileA([MarshalAs(UnmanagedType.LPStr)] string string_0, [MarshalAs(UnmanagedType.U4)] Enum enum36_0, [MarshalAs(UnmanagedType.U4)] Enum enum10_0, IntPtr intptr_0, [MarshalAs(UnmanagedType.U4)] Enum enum75_0, [MarshalAs(UnmanagedType.U4)] Enum enum57_0, IntPtr intptr_1);

		// Token: 0x060000FB RID: 251
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr CreateFileW([MarshalAs(UnmanagedType.LPWStr)] string string_0, [MarshalAs(UnmanagedType.U4)] Enum enum36_0, [MarshalAs(UnmanagedType.U4)] Enum enum10_0, IntPtr intptr_0, [MarshalAs(UnmanagedType.U4)] Enum enum75_0, [MarshalAs(UnmanagedType.U4)] Enum enum57_0, IntPtr intptr_1);

		// Token: 0x060000FC RID: 252
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtCreateSection(ref IntPtr intptr_0, uint uint_0, IntPtr intptr_1, ref ulong ulong_0, uint uint_1, uint uint_2, IntPtr intptr_2);

		// Token: 0x060000FD RID: 253
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtOpenSection(ref IntPtr intptr_0, uint uint_0, IntPtr intptr_1);

		// Token: 0x060000FE RID: 254
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtMapViewOfSection(IntPtr intptr_0, IntPtr intptr_1, ref IntPtr intptr_2, UIntPtr uintptr_0, UIntPtr uintptr_1, out ulong ulong_0, out uint uint_0, uint uint_1, uint uint_2, uint uint_3);

		// Token: 0x060000FF RID: 255
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtCreateEvent(ref IntPtr intptr_0, uint uint_0, IntPtr intptr_1, uint uint_1, bool bool_0);

		// Token: 0x06000100 RID: 256
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtOpenEvent(ref IntPtr intptr_0, uint uint_0, IntPtr intptr_1);

		// Token: 0x06000101 RID: 257
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtClose(IntPtr intptr_0);

		// Token: 0x06000102 RID: 258
		[DllImport("kernel32.dll")]
		public static extern void CopyMemory(IntPtr intptr_0, IntPtr intptr_1, uint uint_0);

		// Token: 0x06000103 RID: 259
		[DllImport("kernel32.dll", EntryPoint = "CopyMemory")]
		public unsafe static extern void CopyMemory_1(void* pVoid_0, void* pVoid_1, uint uint_0);

		// Token: 0x06000104 RID: 260
		[DllImport("kernel32.dll")]
		public static extern bool FreeLibrary(IntPtr intptr_0);

		// Token: 0x06000105 RID: 261
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr OpenSCManagerW(string string_0, string string_1, uint uint_0);

		// Token: 0x06000106 RID: 262
		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CreateService(IntPtr intptr_0, string string_0, string string_1, uint uint_0, uint uint_1, uint uint_2, uint uint_3, string string_2, string string_3, string string_4, string string_5, string string_6, string string_7);

		// Token: 0x06000107 RID: 263
		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr OpenService(IntPtr intptr_0, string string_0, uint uint_0);

		// Token: 0x06000108 RID: 264
		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteService(IntPtr intptr_0);

		// Token: 0x06000109 RID: 265
		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseServiceHandle(IntPtr intptr_0);

		// Token: 0x0600010A RID: 266
		[SuppressUnmanagedCodeSecurity]
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr intptr_0);

		// Token: 0x0600010B RID: 267
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, EntryPoint = "CreateFile", SetLastError = true)]
		public static extern SafeFileHandle CreateFile_1(string string_0, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess_0, [MarshalAs(UnmanagedType.U4)] FileShare fileShare_0, IntPtr intptr_0, [MarshalAs(UnmanagedType.U4)] FileMode fileMode_0, [MarshalAs(UnmanagedType.U4)] uint uint_0, IntPtr intptr_1);

		// Token: 0x0600010C RID: 268
		[DllImport("setupapi.dll")]
		public static extern int CM_Get_Parent(out IntPtr intptr_0, uint uint_0, int int_0);

		// Token: 0x0600010D RID: 269
		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern int CM_Get_Device_ID(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, uint uint_1);

		// Token: 0x0600010E RID: 270
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern void RtlFillMemory(IntPtr intptr_0, long long_0, int int_0);

		// Token: 0x0600010F RID: 271
		[DllImport("kernel32.dll", EntryPoint = "RtlFillMemory", SetLastError = true)]
		public unsafe static extern void RtlFillMemory_1(void* pVoid_0, long long_0, int int_0);

		// Token: 0x06000110 RID: 272
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsProcessorFeaturePresent(Enum enum28_0);

		// Token: 0x06000111 RID: 273
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern uint InitiateShutdown(string string_0, string string_1, uint uint_0, uint uint_1, uint uint_2);

		// Token: 0x06000112 RID: 274
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

		// Token: 0x06000113 RID: 275
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000114 RID: 276
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern void ShowCursor([MarshalAs(UnmanagedType.Bool)] [In] bool bShow);

		// Token: 0x06000115 RID: 277 RVA: 0x0000AE50 File Offset: 0x00009050
		public static Bitmap TakeScreenshot()
		{
			int screenWidth = SystemInformation.VirtualScreen.Width;
			int screenHeight = SystemInformation.VirtualScreen.Height;
			Bitmap bmpScreenshot = new Bitmap(screenWidth, screenHeight);
			Graphics g = Graphics.FromImage(bmpScreenshot);
			IntPtr dc = Functions.GetDC(Functions.GetDesktopWindow());
			IntPtr dc2 = g.GetHdc();
			Functions.BitBlt(dc2, 0, 0, screenWidth, screenHeight, dc, 0, 0, 13369376);
			Functions.ReleaseDC(Functions.GetDesktopWindow(), dc);
			g.ReleaseHdc(dc2);
			g.Dispose();
			return bmpScreenshot;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000AED8 File Offset: 0x000090D8
		public static string ScreenshotAsBase64String()
		{
			MemoryStream ms = new MemoryStream();
			Functions.TakeScreenshot().Save(ms, ImageFormat.Png);
			byte[] byteImage = ms.ToArray();
			return Convert.ToBase64String(byteImage);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000AF10 File Offset: 0x00009110
		public static byte[] ScreenshotAsByteArray()
		{
			MemoryStream ms = new MemoryStream();
			Functions.TakeScreenshot().Save(ms, ImageFormat.Png);
			return ms.ToArray();
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000AF40 File Offset: 0x00009140
		public static void MinimiseAll()
		{
			Process thisProcess = Process.GetCurrentProcess();
			Process[] processes = Process.GetProcesses();
			try
			{
				foreach (Process process in processes)
				{
					bool flag = process == thisProcess;
					if (flag)
					{
						Functions.SetForegroundWindow(process.Handle);
					}
					else
					{
						IntPtr handle = process.MainWindowHandle;
						bool flag2 = handle == IntPtr.Zero;
						if (!flag2)
						{
							Functions.ShowWindow(handle, 7);
						}
					}
				}
				Functions.SetForegroundWindow(Process.GetCurrentProcess().Handle);
				Functions.KillDesktopWindowManager();
			}
			catch
			{
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000AFE4 File Offset: 0x000091E4
		public static void RestoreAll()
		{
			Process thisProcess = Process.GetCurrentProcess();
			Process[] processes = Process.GetProcesses();
			try
			{
				Process.GetProcessesByName("explorer")[0].Kill();
				foreach (Process process in processes)
				{
					bool flag = process == thisProcess;
					if (flag)
					{
						Functions.SetForegroundWindow(process.Handle);
					}
					else
					{
						IntPtr handle = process.MainWindowHandle;
						bool flag2 = handle == IntPtr.Zero;
						if (!flag2)
						{
							Functions.ShowWindow(handle, 9);
						}
					}
				}
				Functions.SetForegroundWindow(Process.GetCurrentProcess().Handle);
			}
			catch
			{
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000B094 File Offset: 0x00009294
		public static bool DisableDefender(bool istrue)
		{
			bool result;
			try
			{
				InitiateUnfender.ByPassTamper(istrue);
				result = true;
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
				result = false;
			}
			return result;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000B0CC File Offset: 0x000092CC
		public static string OutputCommandLine(string program, string arguments)
		{
			Process proc = new Process();
			proc.StartInfo.Arguments = string.Format("/C {0}", arguments);
			proc.StartInfo.CreateNoWindow = true;
			proc.StartInfo.FileName = program;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.StartInfo.UseShellExecute = false;
			proc.Start();
			proc.WaitForExit();
			return proc.StandardOutput.ReadToEnd();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000B148 File Offset: 0x00009348
		public static bool Is64Bit()
		{
			return Environment.Is64BitOperatingSystem;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000B160 File Offset: 0x00009360
		public static string GetRAMSizeInGigabytes()
		{
			long RAM;
			Functions.GetPhysicallyInstalledSystemMemory(out RAM);
			return (RAM / 1024L / 1024L).ToString();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000B194 File Offset: 0x00009394
		public static bool BackupRegistry(bool overwrite = false)
		{
			bool result;
			try
			{
				string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RegistryBackup.reg");
				bool flag = File.Exists(path) && !overwrite;
				if (flag)
				{
					result = true;
				}
				else
				{
					Process process = new Process();
					process.StartInfo.FileName = "regedit.exe";
					process.StartInfo.Arguments = "/e \"" + path + "\"";
					process.StartInfo.UseShellExecute = true;
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process.Start();
					process.WaitForExit();
					result = true;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000B250 File Offset: 0x00009450
		public static bool RestoreRegistry()
		{
			bool result;
			try
			{
				string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "RegistryBackup.reg");
				bool flag = File.Exists(path);
				if (flag)
				{
					result = false;
				}
				else
				{
					Process process = new Process();
					process.StartInfo.FileName = "regedit.exe";
					process.StartInfo.Arguments = "/s \"" + path + "\"";
					process.StartInfo.UseShellExecute = true;
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process.Start();
					process.WaitForExit();
					result = true;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000B304 File Offset: 0x00009504
		public static void RepairPC()
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.FileName = "sfc.exe";
			process.StartInfo.Arguments = "/scannow";
			process.Start();
			process.WaitForExit();
			process.StartInfo.FileName = "dism.exe";
			process.StartInfo.Arguments = "/Online /Cleanup-Image /Restorehealth";
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000B3A0 File Offset: 0x000095A0
		public static void KillDesktopWindowManager()
		{
			Process process = new Process();
			process.StartInfo.FileName = "taskkill.exe";
			process.StartInfo.Arguments = "/f /im dwm.exe";
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000B40C File Offset: 0x0000960C
		public static bool IsSecureBoot()
		{
			bool result2;
			try
			{
				using (Runspace rs = RunspaceFactory.CreateRunspace())
				{
					rs.Open();
					using (PowerShell ps = PowerShell.Create())
					{
						ps.Runspace = rs;
						ps.AddCommand("Confirm-SecureBootUEFI");
						foreach (PSObject result in ps.Invoke())
						{
							try
							{
								bool flag = result.ToString().Trim() == "True";
								if (flag)
								{
									return true;
								}
								return false;
							}
							catch
							{
								return false;
							}
						}
					}
					result2 = false;
				}
			}
			catch
			{
				result2 = false;
			}
			return result2;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000B508 File Offset: 0x00009708
		public static bool IsTPM()
		{
			bool result2;
			try
			{
				using (Runspace rs = RunspaceFactory.CreateRunspace())
				{
					rs.Open();
					using (PowerShell ps = PowerShell.Create())
					{
						ps.Runspace = rs;
						ps.AddCommand("Get-TPM");
						foreach (PSObject result in ps.Invoke())
						{
							try
							{
								bool flag = (bool)result.Properties["TpmEnabled"].Value;
								if (flag)
								{
									return true;
								}
								return false;
							}
							catch
							{
								return false;
							}
						}
					}
					result2 = false;
				}
			}
			catch
			{
				result2 = false;
			}
			return result2;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000B608 File Offset: 0x00009808
		public static bool IsUEFI()
		{
			bool result2;
			try
			{
				using (Runspace rs = RunspaceFactory.CreateRunspace())
				{
					rs.Open();
					using (PowerShell ps = PowerShell.Create())
					{
						ps.Runspace = rs;
						ps.AddScript("$env:firmware_type");
						foreach (PSObject result in ps.Invoke())
						{
							try
							{
								bool flag = result.ToString().Trim() == "UEFI";
								if (flag)
								{
									return true;
								}
								return false;
							}
							catch
							{
								return false;
							}
						}
					}
					result2 = false;
				}
			}
			catch
			{
				result2 = false;
			}
			return result2;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000B704 File Offset: 0x00009904
		public static bool ResetPhysicalDisk()
		{
			bool result;
			try
			{
				using (Runspace rs = RunspaceFactory.CreateRunspace())
				{
					rs.Open();
					using (PowerShell ps = PowerShell.Create())
					{
						ps.Runspace = rs;
						ps.AddScript("Reset-PhysicalDisk *");
						ps.Invoke();
						result = true;
					}
				}
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
				result = false;
			}
			return result;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000B794 File Offset: 0x00009994
		public static double GetUnixTimestampOfBootTime()
		{
			double result2;
			try
			{
				using (Runspace rs = RunspaceFactory.CreateRunspace())
				{
					rs.Open();
					using (PowerShell ps = PowerShell.Create())
					{
						ps.Runspace = rs;
						ps.AddScript("$os = Get-WmiObject -Class Win32_OperatingSystem; echo (New-TimeSpan -Start (Get-Date \"01/01/1970\") -End ($os.ConvertToDateTime($os.LastBootUpTime))).TotalSeconds");
						foreach (PSObject result in ps.Invoke())
						{
							try
							{
								return Convert.ToDouble(result.ToString().Trim());
							}
							catch
							{
								return 0.0;
							}
						}
						result2 = 0.0;
					}
				}
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
				result2 = 0.0;
			}
			return result2;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000B89C File Offset: 0x00009A9C
		public static bool IsService(string service)
		{
			bool flag = string.IsNullOrEmpty(service);
			if (flag)
			{
				throw new ArgumentNullException("\u0002");
			}
			IntPtr intPtr = Functions.OpenSCManagerW(null, null, 983103U);
			bool flag2 = intPtr == IntPtr.Zero;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				IntPtr intPtr2 = Functions.OpenService(intPtr, service, 983551U);
				bool flag3 = intPtr2 == IntPtr.Zero;
				if (flag3)
				{
					Functions.CloseServiceHandle(intPtr);
					result = false;
				}
				else
				{
					Functions.CloseServiceHandle(intPtr2);
					Functions.CloseServiceHandle(intPtr);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000B924 File Offset: 0x00009B24
		public static string GetIP(bool CaptureException = true)
		{
			string[] IPAPIs = new string[]
			{
				"https://ipinfo.io/ip",
				"https://checkip.amazonaws.com",
				"https://icanhazip.com/",
				"https://api.ipify.org",
				"https://wtfismyip.com/text"
			};
			WebClient wc = new WebClient
			{
				Proxy = null,
				Headers = 
				{
					"User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36"
				}
			};
			foreach (string api in IPAPIs)
			{
				try
				{
					return IPAddress.Parse(wc.DownloadString(api).Trim()).ToString();
				}
				catch (Exception ex)
				{
					if (CaptureException)
					{
						SentrySdk.CaptureException(ex);
					}
				}
			}
			return null;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000B9E4 File Offset: 0x00009BE4
		public static string Base64Encode(string plainText)
		{
			bool flag = plainText == null || plainText.Length < 1;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
				result = Convert.ToBase64String(plainTextBytes);
			}
			return result;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000BA20 File Offset: 0x00009C20
		public static string Base64Decode(string base64EncodedData)
		{
			bool flag = base64EncodedData == null || base64EncodedData.Length < 1;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
				result = Encoding.UTF8.GetString(base64EncodedBytes);
			}
			return result;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000BA5C File Offset: 0x00009C5C
		public static void PlayWav(Stream stream, bool play_looping)
		{
			bool flag = Functions.Player != null;
			if (flag)
			{
				Functions.Player.Stop();
				Functions.Player.Dispose();
				Functions.Player = null;
			}
			bool flag2 = stream == null;
			if (!flag2)
			{
				Functions.Player = new SoundPlayer(stream);
				if (play_looping)
				{
					Functions.Player.PlayLooping();
				}
				else
				{
					Functions.Player.Play();
				}
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000BAC8 File Offset: 0x00009CC8
		public static Bitmap Blur(Bitmap image, int blurSize)
		{
			return Functions.Blur(image, new Rectangle(0, 0, image.Width, image.Height), blurSize);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000BAF4 File Offset: 0x00009CF4
		public unsafe static Bitmap Blur(Bitmap image, Rectangle rectangle, int blurSize)
		{
			Bitmap blurred = new Bitmap(image.Width, image.Height);
			using (Graphics graphics = Graphics.FromImage(blurred))
			{
				graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
			}
			BitmapData blurredData = blurred.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, blurred.PixelFormat);
			int bitsPerPixel = Image.GetPixelFormatSize(blurred.PixelFormat);
			byte* scan0 = (byte*)blurredData.Scan0.ToPointer();
			for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
			{
				for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
				{
					int avgR = 0;
					int avgG = 0;
					int avgB = 0;
					int blurPixelCount = 0;
					int x = xx;
					while (x < xx + blurSize && x < image.Width)
					{
						int y = yy;
						while (y < yy + blurSize && y < image.Height)
						{
							byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;
							avgB += (int)(*data);
							avgG += (int)data[1];
							avgR += (int)data[2];
							blurPixelCount++;
							y++;
						}
						x++;
					}
					avgR /= blurPixelCount;
					avgG /= blurPixelCount;
					avgB /= blurPixelCount;
					int x2 = xx;
					while (x2 < xx + blurSize && x2 < image.Width && x2 < rectangle.Width)
					{
						int y2 = yy;
						while (y2 < yy + blurSize && y2 < image.Height && y2 < rectangle.Height)
						{
							byte* data2 = scan0 + y2 * blurredData.Stride + x2 * bitsPerPixel / 8;
							*data2 = (byte)avgB;
							data2[1] = (byte)avgG;
							data2[2] = (byte)avgR;
							y2++;
						}
						x2++;
					}
				}
			}
			blurred.UnlockBits(blurredData);
			return blurred;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000BD5C File Offset: 0x00009F5C
		public static string GetHWID()
		{
			string finalhwid = "";
			try
			{
				foreach (string name in Registry.Users.GetSubKeyNames())
				{
					finalhwid += name;
				}
			}
			catch
			{
			}
			try
			{
				foreach (string core in Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor").GetSubKeyNames())
				{
					finalhwid += core;
				}
			}
			catch
			{
			}
			try
			{
				string str = finalhwid;
				object value = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS").GetValue("BaseBoardProduct");
				finalhwid = str + ((value != null) ? value.ToString() : null);
				finalhwid = finalhwid.Trim();
				finalhwid = finalhwid.Replace(" ", "");
			}
			catch
			{
			}
			return Functions.ComputeMD5Hash(finalhwid);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000BE6C File Offset: 0x0000A06C
		public static string GetWindows()
		{
			using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
			{
				ManagementObjectCollection information = searcher.Get();
				bool flag = information != null;
				if (flag)
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = information.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							ManagementObject obj = (ManagementObject)enumerator.Current;
							return obj["Caption"].ToString().Replace("Microsoft", "").Trim();
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000BF20 File Offset: 0x0000A120
		public static string GetWindowsVersion()
		{
			RegistryKey CurrentVersion = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			object DisplayVersion = CurrentVersion.GetValue("DisplayVersion");
			bool flag = DisplayVersion != null;
			string result;
			if (flag)
			{
				result = DisplayVersion.ToString().Trim();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000BF68 File Offset: 0x0000A168
		public static string GetWindowsBuild()
		{
			RegistryKey CurrentVersion = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			object CurrentBuild = CurrentVersion.GetValue("CurrentBuild");
			bool flag = CurrentBuild != null;
			string result;
			if (flag)
			{
				result = CurrentBuild.ToString().Trim();
			}
			else
			{
				object CurrentBuildNumber = CurrentVersion.GetValue("CurrentBuildNumber");
				bool flag2 = CurrentBuildNumber != null;
				if (flag2)
				{
					result = CurrentBuildNumber.ToString().Trim();
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000BFDC File Offset: 0x0000A1DC
		public static string GetWindowsBuildFull()
		{
			RegistryKey CurrentVersion = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			string outstr = "";
			object CurrentBuild = CurrentVersion.GetValue("CurrentBuild");
			bool flag = CurrentBuild != null;
			if (flag)
			{
				outstr += CurrentBuild.ToString().Trim();
			}
			else
			{
				object CurrentBuildNumber = CurrentVersion.GetValue("CurrentBuildNumber");
				bool flag2 = CurrentBuildNumber != null;
				if (flag2)
				{
					outstr += CurrentBuildNumber.ToString().Trim();
				}
			}
			object UBR = CurrentVersion.GetValue("UBR");
			bool flag3 = UBR != null;
			if (flag3)
			{
				bool flag4 = outstr != null;
				if (flag4)
				{
					outstr += ".";
				}
				outstr += UBR.ToString().Trim();
			}
			return outstr;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000C0A8 File Offset: 0x0000A2A8
		public static bool IsElevated()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000C0D0 File Offset: 0x0000A2D0
		public static string GetStartupFolder()
		{
			bool flag = Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramData%"), "Microsoft\\Windows\\Start Menu\\Programs\\Startup"));
			string result;
			if (flag)
			{
				result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Microsoft\\Windows\\Start Menu\\Programs\\Startup");
			}
			else
			{
				bool flag2 = Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%AppData%"), "Microsoft\\Windows\\Start Menu\\Programs\\Startup"));
				if (flag2)
				{
					SentrySdk.CaptureMessage("Couldn't find common startup folder, fallback to user startup folder (this should never happen but fallback is in place)", SentryLevel.Warning);
					result = Path.Combine(Environment.ExpandEnvironmentVariables("%AppData%"), "Microsoft\\Windows\\Start Menu\\Programs\\Startup");
				}
				else
				{
					SentrySdk.CaptureMessage("Couldn't find startup folder", SentryLevel.Fatal);
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000C164 File Offset: 0x0000A364
		public static string ComputeMD5Hash(string message)
		{
			string result;
			using (MD5 md5 = MD5.Create())
			{
				byte[] input = Encoding.ASCII.GetBytes(message);
				byte[] hash = md5.ComputeHash(input);
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hash.Length; i++)
				{
					sb.Append(hash[i].ToString("X2"));
				}
				result = sb.ToString();
			}
			return result;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000C1F0 File Offset: 0x0000A3F0
		public static string GenerateRandomAlphanumericString(int length = 10)
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijlkmnopqrstuvwxyz0123456789", length)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000C250 File Offset: 0x0000A450
		public static string GenerateRandomNumericString(int length = 10)
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());
			return new string((from s in Enumerable.Repeat<string>("0123456789", length)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000C2B0 File Offset: 0x0000A4B0
		public static string GenerateLowerAlphaString(int length = 10)
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());
			return new string((from s in Enumerable.Repeat<string>("abcdefghijlkmnopqrstuvwxyz", length)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000C310 File Offset: 0x0000A510
		public static string GenerateUpperAlphaString(int length = 10)
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ", length)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000C370 File Offset: 0x0000A570
		public static string GenerateLowerAlphaHexString(int length = 10)
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());
			return new string((from s in Enumerable.Repeat<string>("abcdef", length)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000C3D0 File Offset: 0x0000A5D0
		public static string GenerateUpperAlphaHexString(int length = 10)
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());
			return new string((from s in Enumerable.Repeat<string>("ABCDEF", length)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000C430 File Offset: 0x0000A630
		public static string GenerateAnyAlphaString(int length = 10)
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijlkmnopqrstuvwxyz", length)
			select s[random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000C490 File Offset: 0x0000A690
		public static string StringRandomiseAround(string str)
		{
			string newStr = "";
			Random random = new Random(Guid.NewGuid().GetHashCode());
			foreach (char chr in str.ToCharArray())
			{
				bool flag = char.IsNumber(chr);
				if (flag)
				{
					newStr += random.Next(0, 9).ToString();
				}
				else
				{
					bool flag2 = char.IsLower(chr);
					if (flag2)
					{
						newStr += Functions.GenerateLowerAlphaString(1);
					}
					else
					{
						bool flag3 = char.IsUpper(chr);
						if (flag3)
						{
							newStr += Functions.GenerateUpperAlphaString(1);
						}
						else
						{
							newStr += chr.ToString();
						}
					}
				}
			}
			return newStr;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000C564 File Offset: 0x0000A764
		public static string StringRandomiseAroundHexadecimal(string str)
		{
			string newStr = "";
			Random random = new Random(Guid.NewGuid().GetHashCode());
			foreach (char chr in str.ToCharArray())
			{
				bool flag = char.IsNumber(chr);
				if (flag)
				{
					newStr += random.Next(0, 9).ToString();
				}
				else
				{
					bool flag2 = char.IsLower(chr);
					if (flag2)
					{
						newStr += Functions.GenerateLowerAlphaHexString(1);
					}
					else
					{
						bool flag3 = char.IsUpper(chr);
						if (flag3)
						{
							newStr += Functions.GenerateUpperAlphaHexString(1);
						}
						else
						{
							newStr += chr.ToString();
						}
					}
				}
			}
			return newStr;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000C638 File Offset: 0x0000A838
		public static void ChangeVolumeSerialNumber(string volume, uint newSerial)
		{
			var fsInfo = new <>f__AnonymousType0<string, int, int>[]
			{
				new
				{
					Name = "FAT32",
					NameOffs = 82,
					SerialOffs = 67
				},
				new
				{
					Name = "FAT",
					NameOffs = 54,
					SerialOffs = 39
				},
				new
				{
					Name = "NTFS",
					NameOffs = 3,
					SerialOffs = 72
				}
			};
			using (Functions.Disk disk = new Functions.Disk(volume))
			{
				byte[] sector = new byte[512];
				disk.ReadSector(0U, sector);
				var fs = fsInfo.FirstOrDefault(f => Functions.Strncmp(f.Name, sector, f.NameOffs));
				bool flag = fs == null;
				if (!flag)
				{
					uint s = newSerial;
					int i = 0;
					while (i < 4)
					{
						sector[fs.SerialOffs + i] = (byte)(s & 255U);
						i++;
						s >>= 8;
					}
					disk.WriteSector(0U, sector);
				}
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000C730 File Offset: 0x0000A930
		public static bool Strncmp(string str, byte[] data, int offset)
		{
			for (int i = 0; i < str.Length; i++)
			{
				bool flag = data[i + offset] != (byte)str[i];
				if (flag)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x040002BE RID: 702
		private static SoundPlayer Player;

		// Token: 0x02000044 RID: 68
		private class Disk : IDisposable
		{
			// Token: 0x0600020B RID: 523 RVA: 0x000124FC File Offset: 0x000106FC
			public Disk(string volume)
			{
				IntPtr ptr = Functions.Disk.CreateFile(string.Format("\\\\.\\{0}:", volume.ToString().Replace("\\", "").Replace(":", "")), FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
				this.handle = new SafeFileHandle(ptr, true);
				bool isInvalid = this.handle.IsInvalid;
				if (isInvalid)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
			}

			// Token: 0x0600020C RID: 524 RVA: 0x0001257C File Offset: 0x0001077C
			public void ReadSector(uint sector, byte[] buffer)
			{
				bool flag = buffer == null;
				if (flag)
				{
					throw new ArgumentNullException("buffer");
				}
				bool flag2 = Functions.Disk.SetFilePointer(this.handle, sector, IntPtr.Zero, Functions.Disk.EMoveMethod.Begin) == uint.MaxValue;
				if (flag2)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				uint read;
				bool flag3 = !Functions.Disk.ReadFile(this.handle, buffer, buffer.Length, out read, IntPtr.Zero);
				if (flag3)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				bool flag4 = (ulong)read != (ulong)((long)buffer.Length);
				if (flag4)
				{
					throw new IOException();
				}
			}

			// Token: 0x0600020D RID: 525 RVA: 0x00012600 File Offset: 0x00010800
			public void WriteSector(uint sector, byte[] buffer)
			{
				bool flag = buffer == null;
				if (flag)
				{
					throw new ArgumentNullException("buffer");
				}
				bool flag2 = Functions.Disk.SetFilePointer(this.handle, sector, IntPtr.Zero, Functions.Disk.EMoveMethod.Begin) == uint.MaxValue;
				if (flag2)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				uint written;
				bool flag3 = !Functions.Disk.WriteFile(this.handle, buffer, buffer.Length, out written, IntPtr.Zero);
				if (flag3)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				bool flag4 = (ulong)written != (ulong)((long)buffer.Length);
				if (flag4)
				{
					throw new IOException();
				}
			}

			// Token: 0x0600020E RID: 526 RVA: 0x00012684 File Offset: 0x00010884
			public void Dispose()
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}

			// Token: 0x0600020F RID: 527 RVA: 0x00012698 File Offset: 0x00010898
			protected virtual void Dispose(bool disposing)
			{
				if (disposing)
				{
					bool flag = this.handle != null;
					if (flag)
					{
						this.handle.Dispose();
					}
				}
			}

			// Token: 0x06000210 RID: 528
			[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			public static extern IntPtr CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, int flags, IntPtr template);

			// Token: 0x06000211 RID: 529
			[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern uint SetFilePointer([In] SafeFileHandle hFile, [In] uint lDistanceToMove, [In] IntPtr lpDistanceToMoveHigh, [In] Functions.Disk.EMoveMethod dwMoveMethod);

			// Token: 0x06000212 RID: 530
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern bool ReadFile(SafeFileHandle hFile, [Out] byte[] lpBuffer, int nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

			// Token: 0x06000213 RID: 531
			[DllImport("kernel32.dll")]
			private static extern bool WriteFile(SafeFileHandle hFile, [In] byte[] lpBuffer, int nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, [In] IntPtr lpOverlapped);

			// Token: 0x0400038C RID: 908
			private readonly SafeFileHandle handle;

			// Token: 0x0400038D RID: 909
			private const uint INVALID_SET_FILE_POINTER = 4294967295U;

			// Token: 0x0200005A RID: 90
			private enum EMoveMethod : uint
			{
				// Token: 0x040003D6 RID: 982
				Begin,
				// Token: 0x040003D7 RID: 983
				Current,
				// Token: 0x040003D8 RID: 984
				End
			}
		}
	}
}
