using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using Sentry;

namespace CheatoClient
{
	// Token: 0x02000006 RID: 6
	internal class Cleaner
	{
		// Token: 0x06000030 RID: 48 RVA: 0x0000467C File Offset: 0x0000287C
		public static void Clean(bool aggressive = false)
		{
			WebClient wc = new WebClient
			{
				Proxy = null,
				Headers = 
				{
					"User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36"
				}
			};
			string cleaner = wc.DownloadString("http://localhost/spoofer/cleaner.php");
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000046B8 File Offset: 0x000028B8
		public static void TakeOwnership(string path)
		{
			Process process = new Process();
			process.StartInfo.FileName = "takeown.exe";
			process.StartInfo.Arguments = "takeown /f \"" + path + "\" /r /d /y";
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
			process.StartInfo.FileName = "icacls.exe";
			process.StartInfo.Arguments = "\"" + path + "\" /grant administrators:F /t";
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000476C File Offset: 0x0000296C
		public static void DeleteFile(string file, bool insubdirs = false, bool waitforexit = true)
		{
			string s = null;
			if (insubdirs)
			{
				s = " /s";
			}
			Process proc = new Process();
			proc.StartInfo.FileName = "cmd.exe";
			proc.StartInfo.Arguments = string.Concat(new string[]
			{
				"/C \"del /f",
				s,
				" /q \"",
				file,
				"\"\""
			});
			proc.StartInfo.UseShellExecute = true;
			proc.StartInfo.CreateNoWindow = true;
			proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			proc.Start();
			if (waitforexit)
			{
				proc.WaitForExit();
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004814 File Offset: 0x00002A14
		public static void DeleteDirectory(string dir, bool subdirs = false, bool waitforexit = true)
		{
			string s = null;
			if (subdirs)
			{
				s = " /s";
			}
			Process proc = new Process();
			proc.StartInfo.FileName = "cmd.exe";
			proc.StartInfo.Arguments = string.Concat(new string[]
			{
				"/C \"rmdir",
				s,
				" /q \"",
				dir,
				"\"\""
			});
			proc.StartInfo.UseShellExecute = true;
			proc.StartInfo.CreateNoWindow = true;
			proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			proc.Start();
			if (waitforexit)
			{
				proc.WaitForExit();
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000048BC File Offset: 0x00002ABC
		public static void DeleteRegistry(string key, string valuename = null, bool recursive = true, bool searchintopkeyonly = true)
		{
			try
			{
				WindowsIdentity id = WindowsIdentity.GetCurrent();
				bool blRc = TokenManipulation.MySetPrivilege("SeTakeOwnershipPrivilege", true);
				bool flag = !blRc;
				if (flag)
				{
					throw new PrivilegeNotHeldException("SeTakeOwnershipPrivilege");
				}
				blRc = TokenManipulation.MySetPrivilege("SeRestorePrivilege", true);
				bool flag2 = !blRc;
				if (flag2)
				{
					throw new PrivilegeNotHeldException("SeRestorePrivilege");
				}
				RegistryKey OwnerShipByPass = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows Defender\\Features", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.TakeOwnership);
				RegistrySecurity regSecTempo = OwnerShipByPass.GetAccessControl(AccessControlSections.All);
				IdentityReference oldId = regSecTempo.GetOwner(typeof(SecurityIdentifier));
				SecurityIdentifier siTrustedInstaller = new SecurityIdentifier(oldId.ToString());
				regSecTempo.SetOwner(id.User);
				OwnerShipByPass.SetAccessControl(regSecTempo);
				RegistryAccessRule regARFullAccess = new RegistryAccessRule(id.User, RegistryRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow);
				regSecTempo.AddAccessRule(regARFullAccess);
				OwnerShipByPass.SetAccessControl(regSecTempo);
				regSecTempo.SetOwner(siTrustedInstaller);
				OwnerShipByPass.SetAccessControl(regSecTempo);
				regSecTempo.RemoveAccessRule(regARFullAccess);
				OwnerShipByPass.SetAccessControl(regSecTempo);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000049CC File Offset: 0x00002BCC
		public static void CreateFile(string parentpath, string file, byte[] data, bool overwrite = false)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000049CF File Offset: 0x00002BCF
		public static void CreateDirectory(string path)
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000049D2 File Offset: 0x00002BD2
		public static void CreateRegistry(string key, string valuename = null, string valuedata = null, string valuetype = null, bool intopkeyonly = true)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000049D5 File Offset: 0x00002BD5
		public static void ModifyFile(string parentpath, string file, byte[] data, bool createifnotexist = true)
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000049D8 File Offset: 0x00002BD8
		public static void ModifyDirectory(string path, string newname)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000049DB File Offset: 0x00002BDB
		public static void ModifyRegistry(string key, string valuename = null, string newvaluename = null, string valuedata = null, string newvaluedata = null, string valuetype = null, string newvaluetype = null, bool intopkeyonly = true)
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000049E0 File Offset: 0x00002BE0
		public static void CleanSteam()
		{
			try
			{
				foreach (Process proc in Process.GetProcesses())
				{
					bool flag = proc.ProcessName.ToLower().Contains("rust") || proc.ProcessName.ToLower().Contains("steam");
					if (flag)
					{
						proc.Kill();
					}
				}
				RegistryKey steamReg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Valve\\Steam", true);
				bool flag2 = steamReg == null;
				if (!flag2)
				{
					string steamPath = steamReg.GetValue("InstallPath").ToString();
					Cleaner.DeleteDirectory(Path.Combine(steamPath, "appcache"), true, true);
					Directory.CreateDirectory(Path.Combine(steamPath, "appcache"));
					Cleaner.DeleteDirectory(Path.Combine(steamPath, "userdata"), true, true);
					Directory.CreateDirectory(Path.Combine(steamPath, "userdata"));
					Cleaner.DeleteFile(Path.Combine(steamPath, "depotcache", "*.*"), true, true);
					Cleaner.DeleteFile(Path.Combine(steamPath, "config", "*.*"), true, true);
					Cleaner.DeleteFile(Path.Combine(steamPath, "dumps", "*.*"), true, true);
					Cleaner.DeleteFile(Path.Combine(steamPath, "logs", "*.*"), true, true);
					Cleaner.DeleteFile(Path.Combine(steamPath, ".crash"), true, true);
					Cleaner.DeleteFile(Path.Combine(steamPath, "ssfn*"), true, true);
					RegistryKey steamCurrentUser = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam", true);
					bool flag3 = steamCurrentUser != null;
					if (flag3)
					{
						steamCurrentUser.SetValue("AutoLoginUser", "");
						steamCurrentUser.SetValue("LastGameNameUsed", "");
						steamCurrentUser.SetValue("PseudoUUID", "");
					}
					List<string> steamGameDirs = new List<string>();
					List<string> rustDirs = new List<string>();
					RegistryKey valveRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Valve\\");
					foreach (string valveSubKey in valveRegKey.GetSubKeyNames())
					{
						using (RegistryKey subKey = valveRegKey.OpenSubKey(valveSubKey))
						{
							string steamInstallPath = subKey.GetValue("InstallPath").ToString();
							string configPath = steamInstallPath + "/steamapps/libraryfolders.vdf";
							string driveRegex = "[A-Z]:\\\\";
							bool flag4 = File.Exists(configPath);
							if (flag4)
							{
								string[] configLines = File.ReadAllLines(configPath);
								foreach (string item in configLines)
								{
									Match match = Regex.Match(item, driveRegex);
									bool flag5 = item != string.Empty && match.Success;
									if (flag5)
									{
										string matched = match.ToString();
										string item2 = item.Substring(item.IndexOf(matched));
										item2 = item2.Replace("\\\\", "\\");
										item2 = item2.Replace("\"", "\\steamapps\\common\\");
										steamGameDirs.Add(item2);
									}
								}
								steamGameDirs.Add(steamInstallPath + "\\steamapps\\common\\");
							}
						}
					}
					foreach (string gameDir in steamGameDirs)
					{
						foreach (string gameSubDir in Directory.GetDirectories(gameDir))
						{
							string searchRustDir = Path.Combine(gameDir, "Rust");
							bool flag6 = gameSubDir == searchRustDir;
							if (flag6)
							{
								rustDirs.Add(searchRustDir);
							}
						}
					}
					bool flag7 = rustDirs.Count != 0;
					if (flag7)
					{
						foreach (string rustDir in rustDirs)
						{
							Cleaner.DeleteFile(Path.Combine(rustDir, "output_log*"), true, true);
						}
						RegistryKey fpKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Facepunch Studios LTD", true);
						bool flag8 = fpKey.OpenSubKey("Rust") != null;
						if (flag8)
						{
							fpKey.DeleteSubKey("Rust");
						}
					}
				}
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00004E78 File Offset: 0x00003078
		public static void CleanFiveM()
		{
			try
			{
				string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				Cleaner.DeleteFile(Path.Combine(localAppDataPath, "DigitalEntitlements", "*.*"), true, true);
				Cleaner.DeleteFile(Path.Combine(appDataPath, "CitizenFX", "*.*"), true, true);
				Cleaner.DeleteDirectory(Path.Combine(appDataPath, "CitizenFX"), true, true);
				Directory.CreateDirectory(Path.Combine(appDataPath, "CitizenFX"));
				RegistryKey fiveMReg = Registry.CurrentUser.OpenSubKey("Software\\CitizenFX\\FiveM", true);
				bool isNotReg = false;
				bool flag = fiveMReg != null;
				if (flag)
				{
					bool flag2 = fiveMReg.GetValue("Last Run Location") != null;
					if (flag2)
					{
						string fiveMAppDataPath = fiveMReg.GetValue("Last Run Location").ToString();
						Cleaner.DeleteFile(Path.Combine(fiveMAppDataPath, "\\crashes", "*.*"), true, true);
						Cleaner.DeleteFile(Path.Combine(fiveMAppDataPath, "\\logs", "*.*"), true, true);
						Cleaner.DeleteFile(Path.Combine(fiveMAppDataPath, "\\data\\cache", "crashometry"), true, true);
						Cleaner.DeleteFile(Path.Combine(fiveMAppDataPath, "\\data\\cache\\NV_", "*.*"), true, true);
						Cleaner.DeleteFile(Path.Combine(fiveMAppDataPath, "\\data\\cache\\servers", "*.*"), true, true);
						Cleaner.DeleteFile(Path.Combine(fiveMAppDataPath, "\\data\\cache\\subprocess", "*.log"), true, true);
						Cleaner.DeleteFile(Path.Combine(fiveMAppDataPath, "\\data\\cache", "executable_snapshot*"), true, true);
						Cleaner.DeleteFile(Path.Combine(fiveMAppDataPath, "\\data\\cache\\authbrowser", "*.*"), true, true);
						Cleaner.DeleteFile(Path.Combine(fiveMAppDataPath, "*.log"), true, true);
					}
					else
					{
						isNotReg = true;
					}
				}
				else
				{
					isNotReg = true;
				}
				bool flag3 = isNotReg;
				if (flag3)
				{
					Cleaner.DeleteFile(Path.Combine(localAppDataPath, "FiveM\\FiveM.app\\crashes", "*.*"), true, true);
					Cleaner.DeleteFile(Path.Combine(localAppDataPath, "FiveM\\FiveM.app\\logs", "*.*"), true, true);
					Cleaner.DeleteFile(Path.Combine(localAppDataPath, "FiveM\\FiveM.app\\data\\cache", "crashometry"), true, true);
					Cleaner.DeleteFile(Path.Combine(localAppDataPath, "FiveM\\FiveM.app\\data\\cache\\NV_", "*.*"), true, true);
					Cleaner.DeleteFile(Path.Combine(localAppDataPath, "FiveM\\FiveM.app\\data\\cache\\servers", "*.*"), true, true);
					Cleaner.DeleteFile(Path.Combine(localAppDataPath, "FiveM\\FiveM.app\\data\\cache\\subprocess", "*.log"), true, true);
					Cleaner.DeleteFile(Path.Combine(localAppDataPath, "FiveM\\FiveM.app\\data\\cache", "executable_snapshot*"), true, true);
					Cleaner.DeleteFile(Path.Combine(localAppDataPath, "FiveM\\FiveM.app\\data\\cache\\authbrowser", "*.*"), true, true);
					Cleaner.DeleteFile(Path.Combine(localAppDataPath, "FiveM\\FiveM.app", "*.log"), true, true);
				}
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
			}
		}
	}
}
