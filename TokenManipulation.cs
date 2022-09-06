using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CheatoClient
{
	// Token: 0x02000020 RID: 32
	public class TokenManipulation
	{
		// Token: 0x06000142 RID: 322
		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool AdjustTokenPrivileges([In] IntPtr accessTokenHandle, [MarshalAs(UnmanagedType.Bool)] [In] bool disableAllPrivileges, [In] ref TokenManipulation.TOKEN_PRIVILEGES newState, [In] int bufferLength, [In] [Out] ref TokenManipulation.TOKEN_PRIVILEGES previousState, [In] [Out] ref int returnLength);

		// Token: 0x06000143 RID: 323
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool CloseHandle([In] IntPtr handle);

		// Token: 0x06000144 RID: 324
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetCurrentProcess();

		// Token: 0x06000145 RID: 325
		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);

		// Token: 0x06000146 RID: 326
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool LookupPrivilegeName([In] string systemName, [In] ref TokenManipulation.LUID luid, [In] [Out] StringBuilder name, [In] [Out] ref int nameLength);

		// Token: 0x06000147 RID: 327
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool LookupPrivilegeValue([In] string systemName, [In] string name, [In] [Out] ref TokenManipulation.LUID luid);

		// Token: 0x06000148 RID: 328
		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool OpenProcessToken([In] IntPtr processHandle, [In] TokenManipulation.TokenAccessRights desiredAccess, [In] [Out] ref IntPtr tokenHandle);

		// Token: 0x06000149 RID: 329
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern int GetLastError();

		// Token: 0x0600014A RID: 330 RVA: 0x0000C780 File Offset: 0x0000A980
		public static bool MySetPrivilege(string sPrivilege, bool enablePrivilege)
		{
			TokenManipulation.TOKEN_PRIVILEGES newTP = default(TokenManipulation.TOKEN_PRIVILEGES);
			TokenManipulation.TOKEN_PRIVILEGES oldTP = default(TokenManipulation.TOKEN_PRIVILEGES);
			TokenManipulation.LUID luid = default(TokenManipulation.LUID);
			int retrunLength = 0;
			IntPtr processToken = IntPtr.Zero;
			bool blRc = TokenManipulation.OpenProcessToken(TokenManipulation.GetCurrentProcess(), TokenManipulation.TokenAccessRights.AllAccess, ref processToken);
			bool flag = !blRc;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				blRc = TokenManipulation.LookupPrivilegeValue(null, sPrivilege, ref luid);
				bool flag2 = !blRc;
				if (flag2)
				{
					result = false;
				}
				else
				{
					newTP.PrivilegeCount = 1;
					newTP.Privileges = new TokenManipulation.LUID_AND_ATTRIBUTES[64];
					newTP.Privileges[0].Luid = luid;
					if (enablePrivilege)
					{
						newTP.Privileges[0].Attributes = 2;
					}
					else
					{
						newTP.Privileges[0].Attributes = 0;
					}
					oldTP.PrivilegeCount = 64;
					oldTP.Privileges = new TokenManipulation.LUID_AND_ATTRIBUTES[64];
					blRc = TokenManipulation.AdjustTokenPrivileges(processToken, false, ref newTP, 16, ref oldTP, ref retrunLength);
					bool flag3 = !blRc;
					result = !flag3;
				}
			}
			return result;
		}

		// Token: 0x040002BF RID: 703
		public const string CreateToken = "SeCreateTokenPrivilege";

		// Token: 0x040002C0 RID: 704
		public const string AssignPrimaryToken = "SeAssignPrimaryTokenPrivilege";

		// Token: 0x040002C1 RID: 705
		public const string LockMemory = "SeLockMemoryPrivilege";

		// Token: 0x040002C2 RID: 706
		public const string IncreaseQuota = "SeIncreaseQuotaPrivilege";

		// Token: 0x040002C3 RID: 707
		public const string UnsolicitedInput = "SeUnsolicitedInputPrivilege";

		// Token: 0x040002C4 RID: 708
		public const string MachineAccount = "SeMachineAccountPrivilege";

		// Token: 0x040002C5 RID: 709
		public const string TrustedComputingBase = "SeTcbPrivilege";

		// Token: 0x040002C6 RID: 710
		public const string Security = "SeSecurityPrivilege";

		// Token: 0x040002C7 RID: 711
		public const string TakeOwnership = "SeTakeOwnershipPrivilege";

		// Token: 0x040002C8 RID: 712
		public const string LoadDriver = "SeLoadDriverPrivilege";

		// Token: 0x040002C9 RID: 713
		public const string SystemProfile = "SeSystemProfilePrivilege";

		// Token: 0x040002CA RID: 714
		public const string SystemTime = "SeSystemtimePrivilege";

		// Token: 0x040002CB RID: 715
		public const string ProfileSingleProcess = "SeProfileSingleProcessPrivilege";

		// Token: 0x040002CC RID: 716
		public const string IncreaseBasePriority = "SeIncreaseBasePriorityPrivilege";

		// Token: 0x040002CD RID: 717
		public const string CreatePageFile = "SeCreatePagefilePrivilege";

		// Token: 0x040002CE RID: 718
		public const string CreatePermanent = "SeCreatePermanentPrivilege";

		// Token: 0x040002CF RID: 719
		public const string Backup = "SeBackupPrivilege";

		// Token: 0x040002D0 RID: 720
		public const string Restore = "SeRestorePrivilege";

		// Token: 0x040002D1 RID: 721
		public const string Shutdown = "SeShutdownPrivilege";

		// Token: 0x040002D2 RID: 722
		public const string Debug = "SeDebugPrivilege";

		// Token: 0x040002D3 RID: 723
		public const string Audit = "SeAuditPrivilege";

		// Token: 0x040002D4 RID: 724
		public const string SystemEnvironment = "SeSystemEnvironmentPrivilege";

		// Token: 0x040002D5 RID: 725
		public const string ChangeNotify = "SeChangeNotifyPrivilege";

		// Token: 0x040002D6 RID: 726
		public const string RemoteShutdown = "SeRemoteShutdownPrivilege";

		// Token: 0x040002D7 RID: 727
		public const string Undock = "SeUndockPrivilege";

		// Token: 0x040002D8 RID: 728
		public const string SyncAgent = "SeSyncAgentPrivilege";

		// Token: 0x040002D9 RID: 729
		public const string EnableDelegation = "SeEnableDelegationPrivilege";

		// Token: 0x040002DA RID: 730
		public const string ManageVolume = "SeManageVolumePrivilege";

		// Token: 0x040002DB RID: 731
		public const string Impersonate = "SeImpersonatePrivilege";

		// Token: 0x040002DC RID: 732
		public const string CreateGlobal = "SeCreateGlobalPrivilege";

		// Token: 0x040002DD RID: 733
		public const string TrustedCredentialManagerAccess = "SeTrustedCredManAccessPrivilege";

		// Token: 0x040002DE RID: 734
		public const string ReserveProcessor = "SeReserveProcessorPrivilege";

		// Token: 0x0200004D RID: 77
		public struct LUID
		{
			// Token: 0x04000396 RID: 918
			public int lowPart;

			// Token: 0x04000397 RID: 919
			public int highPart;
		}

		// Token: 0x0200004E RID: 78
		public struct LUID_AND_ATTRIBUTES
		{
			// Token: 0x04000398 RID: 920
			public TokenManipulation.LUID Luid;

			// Token: 0x04000399 RID: 921
			public int Attributes;
		}

		// Token: 0x0200004F RID: 79
		public struct TOKEN_PRIVILEGES
		{
			// Token: 0x0400039A RID: 922
			public int PrivilegeCount;

			// Token: 0x0400039B RID: 923
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
			public TokenManipulation.LUID_AND_ATTRIBUTES[] Privileges;
		}

		// Token: 0x02000050 RID: 80
		[Flags]
		public enum PrivilegeAttributes
		{
			// Token: 0x0400039D RID: 925
			Disabled = 0,
			// Token: 0x0400039E RID: 926
			EnabledByDefault = 1,
			// Token: 0x0400039F RID: 927
			Enabled = 2,
			// Token: 0x040003A0 RID: 928
			Removed = 4,
			// Token: 0x040003A1 RID: 929
			UsedForAccess = -2147483648
		}

		// Token: 0x02000051 RID: 81
		[Flags]
		public enum TokenAccessRights
		{
			// Token: 0x040003A3 RID: 931
			AssignPrimary = 0,
			// Token: 0x040003A4 RID: 932
			Duplicate = 1,
			// Token: 0x040003A5 RID: 933
			Impersonate = 4,
			// Token: 0x040003A6 RID: 934
			Query = 8,
			// Token: 0x040003A7 RID: 935
			QuerySource = 16,
			// Token: 0x040003A8 RID: 936
			AdjustPrivileges = 32,
			// Token: 0x040003A9 RID: 937
			AdjustGroups = 64,
			// Token: 0x040003AA RID: 938
			AdjustDefault = 128,
			// Token: 0x040003AB RID: 939
			AdjustSessionId = 256,
			// Token: 0x040003AC RID: 940
			AllAccess = 983549,
			// Token: 0x040003AD RID: 941
			Read = 131080,
			// Token: 0x040003AE RID: 942
			Write = 131296,
			// Token: 0x040003AF RID: 943
			Execute = 131076
		}

		// Token: 0x02000052 RID: 82
		[Flags]
		internal enum AccessTypeMasks
		{
			// Token: 0x040003B1 RID: 945
			Delete = 65536,
			// Token: 0x040003B2 RID: 946
			ReadControl = 131072,
			// Token: 0x040003B3 RID: 947
			WriteDAC = 262144,
			// Token: 0x040003B4 RID: 948
			WriteOwner = 524288,
			// Token: 0x040003B5 RID: 949
			Synchronize = 1048576,
			// Token: 0x040003B6 RID: 950
			StandardRightsRequired = 983040,
			// Token: 0x040003B7 RID: 951
			StandardRightsRead = 131072,
			// Token: 0x040003B8 RID: 952
			StandardRightsWrite = 131072,
			// Token: 0x040003B9 RID: 953
			StandardRightsExecute = 131072,
			// Token: 0x040003BA RID: 954
			StandardRightsAll = 2031616,
			// Token: 0x040003BB RID: 955
			SpecificRightsAll = 65535
		}
	}
}
