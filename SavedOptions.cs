using System;
using Microsoft.Win32;

namespace CheatoClient
{
	// Token: 0x0200000F RID: 15
	internal class SavedOptions
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00007AD0 File Offset: 0x00005CD0
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00007B54 File Offset: 0x00005D54
		public static string Key
		{
			get
			{
				bool flag = SavedOptions.regkey.GetValue("Key") == null || SavedOptions.regkey.GetValue("Key").ToString().Length < 1;
				string result;
				if (flag)
				{
					SavedOptions.regkey.SetValue("Key", "");
					result = null;
				}
				else
				{
					result = StringCipher.Decrypt(Functions.Base64Decode(SavedOptions.regkey.GetValue("Key").ToString()), "AusblokeIsAChad");
				}
				return result;
			}
			set
			{
				bool flag = value == null || value.Length < 1;
				if (flag)
				{
					SavedOptions.regkey.DeleteValue("Key");
				}
				else
				{
					SavedOptions.regkey.SetValue("Key", Functions.Base64Encode(StringCipher.Encrypt(value.ToString(), "AusblokeIsAChad")));
				}
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00007BB0 File Offset: 0x00005DB0
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00007BF1 File Offset: 0x00005DF1
		public static bool UseDesktopBackground
		{
			get
			{
				bool flag = SavedOptions.regkey.GetValue("UseDesktopBackground") == null;
				return !flag && Convert.ToBoolean(SavedOptions.regkey.GetValue("UseDesktopBackground"));
			}
			set
			{
				SavedOptions.regkey.SetValue("UseDesktopBackground", value);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00007C0C File Offset: 0x00005E0C
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00007C90 File Offset: 0x00005E90
		public static string SpoofingType
		{
			get
			{
				bool flag = SavedOptions.regkey.GetValue("SpoofingType") == null || SavedOptions.regkey.GetValue("SpoofingType").ToString().Length < 1;
				string result;
				if (flag)
				{
					SavedOptions.regkey.SetValue("SpoofingType", "");
					result = null;
				}
				else
				{
					result = StringCipher.Decrypt(Functions.Base64Decode(SavedOptions.regkey.GetValue("SpoofingType").ToString()), "AusblokeIsAChad");
				}
				return result;
			}
			set
			{
				bool flag = value == null || value.Length < 1;
				if (flag)
				{
					SavedOptions.regkey.DeleteValue("SpoofingType");
				}
				else
				{
					SavedOptions.regkey.SetValue("SpoofingType", Functions.Base64Encode(StringCipher.Encrypt(value.ToString(), "AusblokeIsAChad")));
				}
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00007CEC File Offset: 0x00005EEC
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00007D70 File Offset: 0x00005F70
		public static string CleaningType
		{
			get
			{
				bool flag = SavedOptions.regkey.GetValue("CleaningType") == null || SavedOptions.regkey.GetValue("CleaningType").ToString().Length < 1;
				string result;
				if (flag)
				{
					SavedOptions.regkey.SetValue("CleaningType", "");
					result = null;
				}
				else
				{
					result = StringCipher.Decrypt(Functions.Base64Decode(SavedOptions.regkey.GetValue("CleaningType").ToString()), "AusblokeIsAChad");
				}
				return result;
			}
			set
			{
				bool flag = value == null || value.Length < 1;
				if (flag)
				{
					SavedOptions.regkey.DeleteValue("CleaningType");
				}
				else
				{
					SavedOptions.regkey.SetValue("CleaningType", Functions.Base64Encode(StringCipher.Encrypt(value.ToString(), "AusblokeIsAChad")));
				}
			}
		}

		// Token: 0x0400003D RID: 61
		public static RegistryKey regkey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Spoof", true);
	}
}
