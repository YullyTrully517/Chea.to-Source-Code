using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CheatoClient
{
	// Token: 0x0200000D RID: 13
	public static class ProcessUtilities
	{
		// Token: 0x06000065 RID: 101 RVA: 0x00006A00 File Offset: 0x00004C00
		public static string GetCurrentDirectory(int processId)
		{
			return ProcessUtilities.GetProcessParametersString(processId, PEB_OFFSET.CurrentDirectory);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00006A1C File Offset: 0x00004C1C
		public static string GetCurrentDirectory(this Process process)
		{
			bool flag = process == null;
			if (flag)
			{
				throw new ArgumentNullException("process");
			}
			return ProcessUtilities.GetCurrentDirectory(process.Id);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00006A4C File Offset: 0x00004C4C
		private static string GetProcessParametersString(int processId, PEB_OFFSET Offset)
		{
			IntPtr handle = ProcessUtilities.OpenProcess(1040, false, processId);
			bool flag = handle == IntPtr.Zero;
			if (flag)
			{
				throw new Win32Exception(Marshal.GetLastWin32Error());
			}
			bool IsWow64Process = Is64BitChecker.InternalCheckIsWow64();
			bool IsTargetWow64Process = Is64BitChecker.GetProcessIsWow64(handle);
			bool IsTarget64BitProcess = ProcessUtilities.Is64BitOperatingSystem && !IsTargetWow64Process;
			long processParametersOffset = IsTarget64BitProcess ? 32L : 16L;
			string result;
			if (Offset != PEB_OFFSET.CurrentDirectory)
			{
				if (Offset != PEB_OFFSET.CommandLine)
				{
				}
				result = null;
			}
			else
			{
				long offset = IsTarget64BitProcess ? 56L : 36L;
				try
				{
					bool flag2 = IsTargetWow64Process;
					if (flag2)
					{
						IntPtr peb32 = 0;
						int hr = ProcessUtilities.NtQueryInformationProcess(handle, 26, ref peb32, IntPtr.Size, IntPtr.Zero);
						bool flag3 = hr != 0;
						if (flag3)
						{
							throw new Win32Exception(hr);
						}
						long pebAddress = peb32.ToInt64();
						IntPtr pp = 0;
						bool flag4 = !ProcessUtilities.ReadProcessMemory(handle, new IntPtr(pebAddress + processParametersOffset), ref pp, new IntPtr(Marshal.SizeOf<IntPtr>(pp)), IntPtr.Zero);
						if (flag4)
						{
						}
						ProcessUtilities.UNICODE_STRING_32 us = default(ProcessUtilities.UNICODE_STRING_32);
						bool flag5 = !ProcessUtilities.ReadProcessMemory(handle, new IntPtr(pp.ToInt64() + offset), ref us, new IntPtr(Marshal.SizeOf<ProcessUtilities.UNICODE_STRING_32>(us)), IntPtr.Zero);
						if (flag5)
						{
						}
						bool flag6 = us.Buffer == 0 || us.Length == 0;
						if (flag6)
						{
							result = null;
						}
						else
						{
							string s = new string('\0', (int)(us.Length / 2));
							bool flag7 = !ProcessUtilities.ReadProcessMemory(handle, new IntPtr(us.Buffer), s, new IntPtr((int)us.Length), IntPtr.Zero);
							if (flag7)
							{
							}
							result = s;
						}
					}
					else
					{
						bool flag8 = IsWow64Process;
						if (flag8)
						{
							ProcessUtilities.PROCESS_BASIC_INFORMATION_WOW64 pbi = default(ProcessUtilities.PROCESS_BASIC_INFORMATION_WOW64);
							int hr2 = ProcessUtilities.NtWow64QueryInformationProcess64(handle, 0, ref pbi, Marshal.SizeOf<ProcessUtilities.PROCESS_BASIC_INFORMATION_WOW64>(pbi), IntPtr.Zero);
							bool flag9 = hr2 != 0;
							if (flag9)
							{
								throw new Win32Exception(hr2);
							}
							long pebAddress = pbi.PebBaseAddress;
							long pp2 = 0L;
							hr2 = ProcessUtilities.NtWow64ReadVirtualMemory64(handle, pebAddress + processParametersOffset, ref pp2, (long)Marshal.SizeOf<long>(pp2), IntPtr.Zero);
							bool flag10 = hr2 != 0;
							if (flag10)
							{
								throw new Win32Exception(hr2);
							}
							ProcessUtilities.UNICODE_STRING_WOW64 us2 = default(ProcessUtilities.UNICODE_STRING_WOW64);
							hr2 = ProcessUtilities.NtWow64ReadVirtualMemory64(handle, pp2 + offset, ref us2, (long)Marshal.SizeOf<ProcessUtilities.UNICODE_STRING_WOW64>(us2), IntPtr.Zero);
							bool flag11 = hr2 != 0;
							if (flag11)
							{
								throw new Win32Exception(hr2);
							}
							bool flag12 = us2.Buffer == 0L || us2.Length == 0;
							if (flag12)
							{
								result = null;
							}
							else
							{
								string s2 = new string('\0', (int)(us2.Length / 2));
								hr2 = ProcessUtilities.NtWow64ReadVirtualMemory64(handle, us2.Buffer, s2, (long)us2.Length, IntPtr.Zero);
								bool flag13 = hr2 != 0;
								if (flag13)
								{
									throw new Win32Exception(hr2);
								}
								result = s2;
							}
						}
						else
						{
							ProcessUtilities.PROCESS_BASIC_INFORMATION pbi2 = default(ProcessUtilities.PROCESS_BASIC_INFORMATION);
							int hr3 = ProcessUtilities.NtQueryInformationProcess(handle, 0, ref pbi2, Marshal.SizeOf<ProcessUtilities.PROCESS_BASIC_INFORMATION>(pbi2), IntPtr.Zero);
							bool flag14 = hr3 != 0;
							if (flag14)
							{
								throw new Win32Exception(hr3);
							}
							long pebAddress = pbi2.PebBaseAddress.ToInt64();
							IntPtr pp3 = 0;
							bool flag15 = !ProcessUtilities.ReadProcessMemory(handle, new IntPtr(pebAddress + processParametersOffset), ref pp3, new IntPtr(Marshal.SizeOf<IntPtr>(pp3)), IntPtr.Zero);
							if (flag15)
							{
							}
							ProcessUtilities.UNICODE_STRING us3 = default(ProcessUtilities.UNICODE_STRING);
							bool flag16 = !ProcessUtilities.ReadProcessMemory(handle, new IntPtr((long)pp3 + offset), ref us3, new IntPtr(Marshal.SizeOf<ProcessUtilities.UNICODE_STRING>(us3)), IntPtr.Zero);
							if (flag16)
							{
							}
							bool flag17 = us3.Buffer == IntPtr.Zero || us3.Length == 0;
							if (flag17)
							{
								result = null;
							}
							else
							{
								string s3 = new string('\0', (int)(us3.Length / 2));
								bool flag18 = !ProcessUtilities.ReadProcessMemory(handle, us3.Buffer, s3, new IntPtr((int)us3.Length), IntPtr.Zero);
								if (flag18)
								{
								}
								result = s3;
							}
						}
					}
				}
				finally
				{
					ProcessUtilities.CloseHandle(handle);
				}
			}
			return result;
		}

		// Token: 0x06000068 RID: 104
		[DllImport("ntdll.dll")]
		private static extern int NtQueryInformationProcess(IntPtr ProcessHandle, int ProcessInformationClass, ref ProcessUtilities.PROCESS_BASIC_INFORMATION ProcessInformation, int ProcessInformationLength, IntPtr ReturnLength);

		// Token: 0x06000069 RID: 105
		[DllImport("ntdll.dll")]
		private static extern int NtQueryInformationProcess(IntPtr ProcessHandle, int ProcessInformationClass, ref IntPtr ProcessInformation, int ProcessInformationLength, IntPtr ReturnLength);

		// Token: 0x0600006A RID: 106
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref IntPtr lpBuffer, IntPtr dwSize, IntPtr lpNumberOfBytesRead);

		// Token: 0x0600006B RID: 107
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref ProcessUtilities.UNICODE_STRING lpBuffer, IntPtr dwSize, IntPtr lpNumberOfBytesRead);

		// Token: 0x0600006C RID: 108
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref ProcessUtilities.UNICODE_STRING_32 lpBuffer, IntPtr dwSize, IntPtr lpNumberOfBytesRead);

		// Token: 0x0600006D RID: 109
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [MarshalAs(UnmanagedType.LPWStr)] string lpBuffer, IntPtr dwSize, IntPtr lpNumberOfBytesRead);

		// Token: 0x0600006E RID: 110
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		// Token: 0x0600006F RID: 111
		[DllImport("kernel32.dll")]
		private static extern bool CloseHandle(IntPtr hObject);

		// Token: 0x06000070 RID: 112
		[DllImport("ntdll.dll")]
		private static extern int NtWow64QueryInformationProcess64(IntPtr ProcessHandle, int ProcessInformationClass, ref ProcessUtilities.PROCESS_BASIC_INFORMATION_WOW64 ProcessInformation, int ProcessInformationLength, IntPtr ReturnLength);

		// Token: 0x06000071 RID: 113
		[DllImport("ntdll.dll")]
		private static extern int NtWow64ReadVirtualMemory64(IntPtr hProcess, long lpBaseAddress, ref long lpBuffer, long dwSize, IntPtr lpNumberOfBytesRead);

		// Token: 0x06000072 RID: 114
		[DllImport("ntdll.dll")]
		private static extern int NtWow64ReadVirtualMemory64(IntPtr hProcess, long lpBaseAddress, ref ProcessUtilities.UNICODE_STRING_WOW64 lpBuffer, long dwSize, IntPtr lpNumberOfBytesRead);

		// Token: 0x06000073 RID: 115
		[DllImport("ntdll.dll")]
		private static extern int NtWow64ReadVirtualMemory64(IntPtr hProcess, long lpBaseAddress, [MarshalAs(UnmanagedType.LPWStr)] string lpBuffer, long dwSize, IntPtr lpNumberOfBytesRead);

		// Token: 0x0400002F RID: 47
		public static readonly bool Is64BitProcess = IntPtr.Size > 4;

		// Token: 0x04000030 RID: 48
		public static readonly bool Is64BitOperatingSystem = ProcessUtilities.Is64BitProcess || Is64BitChecker.InternalCheckIsWow64();

		// Token: 0x04000031 RID: 49
		private const int PROCESS_QUERY_INFORMATION = 1024;

		// Token: 0x04000032 RID: 50
		private const int PROCESS_VM_READ = 16;

		// Token: 0x02000038 RID: 56
		private struct PROCESS_BASIC_INFORMATION
		{
			// Token: 0x04000341 RID: 833
			public IntPtr Reserved1;

			// Token: 0x04000342 RID: 834
			public IntPtr PebBaseAddress;

			// Token: 0x04000343 RID: 835
			public IntPtr Reserved2_0;

			// Token: 0x04000344 RID: 836
			public IntPtr Reserved2_1;

			// Token: 0x04000345 RID: 837
			public IntPtr UniqueProcessId;

			// Token: 0x04000346 RID: 838
			public IntPtr Reserved3;
		}

		// Token: 0x02000039 RID: 57
		private struct UNICODE_STRING
		{
			// Token: 0x04000347 RID: 839
			public short Length;

			// Token: 0x04000348 RID: 840
			public short MaximumLength;

			// Token: 0x04000349 RID: 841
			public IntPtr Buffer;
		}

		// Token: 0x0200003A RID: 58
		private struct PROCESS_BASIC_INFORMATION_WOW64
		{
			// Token: 0x0400034A RID: 842
			public long Reserved1;

			// Token: 0x0400034B RID: 843
			public long PebBaseAddress;

			// Token: 0x0400034C RID: 844
			public long Reserved2_0;

			// Token: 0x0400034D RID: 845
			public long Reserved2_1;

			// Token: 0x0400034E RID: 846
			public long UniqueProcessId;

			// Token: 0x0400034F RID: 847
			public long Reserved3;
		}

		// Token: 0x0200003B RID: 59
		private struct UNICODE_STRING_WOW64
		{
			// Token: 0x04000350 RID: 848
			public short Length;

			// Token: 0x04000351 RID: 849
			public short MaximumLength;

			// Token: 0x04000352 RID: 850
			public long Buffer;
		}

		// Token: 0x0200003C RID: 60
		private struct UNICODE_STRING_32
		{
			// Token: 0x04000353 RID: 851
			public short Length;

			// Token: 0x04000354 RID: 852
			public short MaximumLength;

			// Token: 0x04000355 RID: 853
			public int Buffer;
		}
	}
}
