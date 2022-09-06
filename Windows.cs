using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace CheatoClient
{
	// Token: 0x0200002A RID: 42
	internal class Windows
	{
		// Token: 0x06000179 RID: 377 RVA: 0x0000EEA4 File Offset: 0x0000D0A4
		public static void DeleteUSNJournal()
		{
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo drive in drives)
			{
				Process process = new Process();
				process.StartInfo.FileName = "fsutil.exe";
				process.StartInfo.Arguments = "usn deletejournal /d /n " + drive.Name.Replace("\\", "");
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.Start();
				process.WaitForExit();
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000EF54 File Offset: 0x0000D154
		public static void ResetPhysicalDisk()
		{
			Process process = new Process();
			process.StartInfo.FileName = "powershell.exe";
			process.StartInfo.Arguments = "Reset-PhysicalDisk *";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000EFC0 File Offset: 0x0000D1C0
		public static void RepairPhysicalDisk()
		{
			Process process = new Process();
			process.StartInfo.FileName = "powershell.exe";
			process.StartInfo.Arguments = "Repair-PhysicalDisk *";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000F02C File Offset: 0x0000D22C
		public static void DeleteVolumeShadowCopies()
		{
			Process process = new Process();
			process.StartInfo.FileName = "vssadmin.exe";
			process.StartInfo.Arguments = "delete shadows /All /Quiet";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
			process.StartInfo.FileName = "vssadmin.exe";
			process.StartInfo.Arguments = "shadowcopy delete";
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000F0C8 File Offset: 0x0000D2C8
		public static void DeleteBackupCatalog()
		{
			Process process = new Process();
			process.StartInfo.FileName = "wbadmin.exe";
			process.StartInfo.Arguments = "delete catalog -quiet";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000F134 File Offset: 0x0000D334
		public static void DeleteSystemBackups()
		{
			Process process = new Process();
			process.StartInfo.FileName = "wbadmin.exe";
			process.StartInfo.Arguments = "delete backup -keepversions:0 -quiet";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
			process.StartInfo.Arguments = "delete systemstatebackup -keepversions:0 -quiet";
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000F1C0 File Offset: 0x0000D3C0
		public static void KillWMI()
		{
			foreach (Process proc in Process.GetProcesses())
			{
				bool flag = proc.ProcessName == "WmiPrvSE";
				if (flag)
				{
					proc.Kill();
				}
			}
			Process process = new Process();
			process.StartInfo.FileName = "net.exe";
			process.StartInfo.Arguments = "stop winmgmt /Y";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000F268 File Offset: 0x0000D468
		public static void DisableSystemBackups(bool istrue = true)
		{
			Process process = new Process();
			process.StartInfo.FileName = "wbadmin.exe";
			if (istrue)
			{
				process.StartInfo.Arguments = "disable backup -quiet";
			}
			else
			{
				process.StartInfo.Arguments = "enable backup -quiet";
			}
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000F2F0 File Offset: 0x0000D4F0
		public static void ClearEventLogs()
		{
			foreach (EventLog eventLog in EventLog.GetEventLogs())
			{
				eventLog.Clear();
				eventLog.Dispose();
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000F328 File Offset: 0x0000D528
		public static void ChangeVolumeIDs()
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());
			byte[] buffer = new byte[4];
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo drive in drives)
			{
				random.NextBytes(buffer);
				string fourbytelongvolumeid = string.Concat((from x in buffer
				select string.Format("{0}", x.ToString("X2"))).ToArray<string>());
				Functions.ChangeVolumeSerialNumber(drive.Name.Replace("\\", ""), Convert.ToUInt32(fourbytelongvolumeid, 16));
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000F3DC File Offset: 0x0000D5DC
		public static void BladeGroupBypass()
		{
			string[] folders = new string[]
			{
				"C:\\Program Files\\Blade Group",
				"C:\\Program Files\\Blade Group\\Config",
				"C:\\Program Files\\Blade Group\\Shadow Control Panel",
				"C:\\Program Files\\Blade Group\\ShadowActivities",
				"C:\\Program Files\\Blade Group\\ShadowDumpWindowsDriver",
				"C:\\Program Files\\Blade Group\\ShadowInstaller",
				"C:\\Program Files\\Blade Group\\ShadowInstallerClone",
				"C:\\Program Files\\Blade Group\\ShadowManager",
				"C:\\Program Files\\Blade Group\\ShadowNvidiaDriver",
				"C:\\Program Files\\Blade Group\\ShadowOperator",
				"C:\\Program Files\\Blade Group\\ShadowProcessator",
				"C:\\Program Files\\Blade Group\\ShadowServicesWatcher",
				"C:\\Program Files\\Blade Group\\ShadowStreamer",
				"C:\\Program Files\\Blade Group\\ShadowSystemWatcher",
				"C:\\Program Files\\Blade Group\\ShadowUsbOverIp",
				"C:\\Program Files\\Blade Group\\ShadowVirtualAudio",
				"C:\\Program Files\\Blade Group\\ShadowVirtualGamepad",
				"C:\\Program Files\\Blade Group\\ShadowVirtualHid",
				"C:\\Program Files\\Blade Group\\ShadowVirtualStorage",
				"C:\\Program Files (x86)\\Blade Group",
				"C:\\Program Files (x86)\\Blade Group\\Config",
				"C:\\Program Files (x86)\\Blade Group\\Shadow Control Panel",
				"C:\\Program Files (x86)\\Blade Group\\ShadowActivities",
				"C:\\Program Files (x86)\\Blade Group\\ShadowDumpWindowsDriver",
				"C:\\Program Files (x86)\\Blade Group\\ShadowInstaller",
				"C:\\Program Files (x86)\\Blade Group\\ShadowInstallerClone",
				"C:\\Program Files (x86)\\Blade Group\\ShadowManager",
				"C:\\Program Files (x86)\\Blade Group\\ShadowNvidiaDriver",
				"C:\\Program Files (x86)\\Blade Group\\ShadowOperator",
				"C:\\Program Files (x86)\\Blade Group\\ShadowProcessator",
				"C:\\Program Files (x86)\\Blade Group\\ShadowServicesWatcher",
				"C:\\Program Files (x86)\\Blade Group\\ShadowStreamer",
				"C:\\Program Files (x86)\\Blade Group\\ShadowSystemWatcher",
				"C:\\Program Files (x86)\\Blade Group\\ShadowUsbOverIp",
				"C:\\Program Files (x86)\\Blade Group\\ShadowVirtualAudio",
				"C:\\Program Files (x86)\\Blade Group\\ShadowVirtualGamepad",
				"C:\\Program Files (x86)\\Blade Group\\ShadowVirtualHid",
				"C:\\Program Files (x86)\\Blade Group\\ShadowVirtualStorage"
			};
			foreach (string folder in folders)
			{
				bool flag = !Directory.Exists(folder);
				if (flag)
				{
					Directory.CreateDirectory(folder);
				}
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000F570 File Offset: 0x0000D770
		public static void ModifyRegistry()
		{
			Registry.LocalMachine.DeleteSubKeyTree("Software\\NVIDIA Corporation");
			Registry.CurrentUser.DeleteSubKeyTree("Software\\NVIDIA Corporation");
			Registry.LocalMachine.DeleteSubKeyTree("SYSTEM\\MountedDevices");
			Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Dfrg\\Statistics");
			RegistryKey scsiRegKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\Scsi", true);
			foreach (string keya in scsiRegKey.GetSubKeyNames())
			{
				foreach (string keyb in scsiRegKey.OpenSubKey(keya, true).GetSubKeyNames())
				{
					foreach (string keyc in scsiRegKey.OpenSubKey(keya, true).OpenSubKey(keyb, true).GetSubKeyNames())
					{
						foreach (string keyd in scsiRegKey.OpenSubKey(keya, true).OpenSubKey(keyb, true).OpenSubKey(keyc, true).GetSubKeyNames())
						{
							bool flag = keyd.ToLower().Contains("logical unit id");
							if (flag)
							{
								RegistryKey logicalunitRegKey = scsiRegKey.OpenSubKey(keya, true).OpenSubKey(keyb, true).OpenSubKey(keyc, true).OpenSubKey(keyd, true);
								object deviceidentifierpage = logicalunitRegKey.GetValue("DeviceIdentifierPage");
								bool flag2 = deviceidentifierpage != null;
								if (flag2)
								{
									string gotstr = Encoding.UTF8.GetString((byte[])deviceidentifierpage);
									byte[] towrite = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr));
									logicalunitRegKey.SetValue("DeviceIdentifierPage", towrite);
								}
								object identifier = logicalunitRegKey.GetValue("Identifier");
								bool flag3 = identifier != null;
								if (flag3)
								{
									logicalunitRegKey.SetValue("Identifier", Functions.StringRandomiseAround(identifier.ToString()));
								}
								object inquirydata = logicalunitRegKey.GetValue("InquiryData");
								bool flag4 = inquirydata != null;
								if (flag4)
								{
									string gotstr2 = Encoding.UTF8.GetString((byte[])inquirydata);
									byte[] towrite2 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr2));
									logicalunitRegKey.SetValue("InquiryData", towrite2);
								}
								object serialNumber = logicalunitRegKey.GetValue("SerialNumber");
								bool flag5 = serialNumber != null;
								if (flag5)
								{
									logicalunitRegKey.SetValue("SerialNumber", Functions.StringRandomiseAround(serialNumber.ToString()));
								}
							}
						}
					}
				}
			}
			RegistryKey diskcontrolRegKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\MultifunctionAdapter\\0\\DiskController", true);
			foreach (string keya2 in diskcontrolRegKey.GetSubKeyNames())
			{
				foreach (string keyb2 in diskcontrolRegKey.OpenSubKey(keya2, true).GetSubKeyNames())
				{
					foreach (string keyc2 in diskcontrolRegKey.OpenSubKey(keya2, true).OpenSubKey(keyb2, true).GetSubKeyNames())
					{
						RegistryKey zeroRegKey = diskcontrolRegKey.OpenSubKey(keya2, true).OpenSubKey(keyb2, true).OpenSubKey(keyc2, true);
						object identifier2 = zeroRegKey.GetValue("Identifier");
						bool flag6 = identifier2 != null;
						if (flag6)
						{
							zeroRegKey.SetValue("Identifier", Functions.StringRandomiseAround(identifier2.ToString()));
						}
					}
				}
			}
			RegistryKey centralprocessorRegKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor", true);
			foreach (string keya3 in centralprocessorRegKey.GetSubKeyNames())
			{
				RegistryKey zeroRegKey2 = centralprocessorRegKey.OpenSubKey(keya3, true);
				object identifier3 = zeroRegKey2.GetValue("Identifier");
				bool flag7 = identifier3 != null;
				if (flag7)
				{
					zeroRegKey2.SetValue("Identifier", Functions.StringRandomiseAround(identifier3.ToString()));
				}
				object componentinformation = zeroRegKey2.GetValue("Component Information");
				bool flag8 = componentinformation != null;
				if (flag8)
				{
					string gotstr3 = Encoding.UTF8.GetString((byte[])componentinformation);
					byte[] towrite3 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr3));
					zeroRegKey2.SetValue("Component Information", towrite3);
				}
			}
			RegistryKey ProcessorRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Provisioning\\CSPs\\.\\cimv2\\Win32_Processor", true);
			object Namespace = ProcessorRegKey.GetValue("Namespace");
			bool flag9 = Namespace != null;
			if (flag9)
			{
				ProcessorRegKey.SetValue("Namespace", Functions.GenerateRandomAlphanumericString(6));
			}
			object ExecutionMode = ProcessorRegKey.GetValue("ExecutionMode");
			bool flag10 = ExecutionMode != null;
			if (flag10)
			{
				ProcessorRegKey.SetValue("ExecutionMode", Functions.GenerateRandomAlphanumericString(2));
			}
			object ProviderType = ProcessorRegKey.GetValue("ProviderType");
			bool flag11 = ProviderType != null;
			if (flag11)
			{
				ProcessorRegKey.SetValue("ProviderType", Functions.GenerateRandomAlphanumericString(2));
			}
			RegistryKey OperatingSystemRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Provisioning\\CSPs\\.\\cimv2\\Win32_OperatingSystem", true);
			Namespace = OperatingSystemRegKey.GetValue("Namespace");
			bool flag12 = Namespace != null;
			if (flag12)
			{
				OperatingSystemRegKey.SetValue("Namespace", Functions.GenerateRandomAlphanumericString(6));
			}
			ExecutionMode = OperatingSystemRegKey.GetValue("ExecutionMode");
			bool flag13 = ExecutionMode != null;
			if (flag13)
			{
				OperatingSystemRegKey.SetValue("ExecutionMode", Functions.GenerateRandomAlphanumericString(2));
			}
			ProviderType = OperatingSystemRegKey.GetValue("ProviderType");
			bool flag14 = ProviderType != null;
			if (flag14)
			{
				OperatingSystemRegKey.SetValue("ProviderType", Functions.GenerateRandomAlphanumericString(2));
			}
			RegistryKey BaseBoardRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Provisioning\\CSPs\\.\\cimv2\\Win32_BaseBoard", true);
			Namespace = BaseBoardRegKey.GetValue("Namespace");
			bool flag15 = Namespace != null;
			if (flag15)
			{
				BaseBoardRegKey.SetValue("Namespace", Functions.GenerateRandomAlphanumericString(6));
			}
			ExecutionMode = BaseBoardRegKey.GetValue("ExecutionMode");
			bool flag16 = ExecutionMode != null;
			if (flag16)
			{
				BaseBoardRegKey.SetValue("ExecutionMode", Functions.GenerateRandomAlphanumericString(2));
			}
			ProviderType = BaseBoardRegKey.GetValue("ProviderType");
			bool flag17 = ProviderType != null;
			if (flag17)
			{
				BaseBoardRegKey.SetValue("ProviderType", Functions.GenerateRandomAlphanumericString(2));
			}
			RegistryKey BIOSRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Provisioning\\CSPs\\.\\cimv2\\Win32_BIOS", true);
			Namespace = BIOSRegKey.GetValue("Namespace");
			bool flag18 = Namespace != null;
			if (flag18)
			{
				BIOSRegKey.SetValue("Namespace", Functions.GenerateRandomAlphanumericString(6));
			}
			ExecutionMode = BIOSRegKey.GetValue("ExecutionMode");
			bool flag19 = ExecutionMode != null;
			if (flag19)
			{
				BIOSRegKey.SetValue("ExecutionMode", Functions.GenerateRandomAlphanumericString(2));
			}
			ProviderType = BIOSRegKey.GetValue("ProviderType");
			bool flag20 = ProviderType != null;
			if (flag20)
			{
				BIOSRegKey.SetValue("ProviderType", Functions.GenerateRandomAlphanumericString(2));
			}
			RegistryKey DiskDriveRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Provisioning\\CSPs\\.\\cimv2\\Win32_DiskDrive", true);
			Namespace = DiskDriveRegKey.GetValue("Namespace");
			bool flag21 = Namespace != null;
			if (flag21)
			{
				DiskDriveRegKey.SetValue("Namespace", Functions.GenerateRandomAlphanumericString(6));
			}
			ExecutionMode = DiskDriveRegKey.GetValue("ExecutionMode");
			bool flag22 = ExecutionMode != null;
			if (flag22)
			{
				DiskDriveRegKey.SetValue("ExecutionMode", Functions.GenerateRandomAlphanumericString(2));
			}
			ProviderType = DiskDriveRegKey.GetValue("ProviderType");
			bool flag23 = ProviderType != null;
			if (flag23)
			{
				DiskDriveRegKey.SetValue("ProviderType", Functions.GenerateRandomAlphanumericString(2));
			}
			RegistryKey VideoControllerRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Provisioning\\CSPs\\.\\cimv2\\Win32_VideoController", true);
			Namespace = VideoControllerRegKey.GetValue("Namespace");
			bool flag24 = Namespace != null;
			if (flag24)
			{
				VideoControllerRegKey.SetValue("Namespace", Functions.GenerateRandomAlphanumericString(6));
			}
			ExecutionMode = VideoControllerRegKey.GetValue("ExecutionMode");
			bool flag25 = ExecutionMode != null;
			if (flag25)
			{
				VideoControllerRegKey.SetValue("ExecutionMode", Functions.GenerateRandomAlphanumericString(2));
			}
			ProviderType = VideoControllerRegKey.GetValue("ProviderType");
			bool flag26 = ProviderType != null;
			if (flag26)
			{
				VideoControllerRegKey.SetValue("ProviderType", Functions.GenerateRandomAlphanumericString(2));
			}
			RegistryKey IDEControllerRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Provisioning\\CSPs\\.\\cimv2\\Win32_IDEController", true);
			Namespace = IDEControllerRegKey.GetValue("Namespace");
			bool flag27 = Namespace != null;
			if (flag27)
			{
				IDEControllerRegKey.SetValue("Namespace", Functions.StringRandomiseAround(Namespace.ToString()));
			}
			ExecutionMode = IDEControllerRegKey.GetValue("ExecutionMode");
			bool flag28 = ExecutionMode != null;
			if (flag28)
			{
				string gotstr4 = Encoding.UTF8.GetString((byte[])ExecutionMode);
				byte[] towrite4 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr4));
				IDEControllerRegKey.SetValue("ExecutionMode", towrite4);
			}
			ProviderType = IDEControllerRegKey.GetValue("ProviderType");
			bool flag29 = ProviderType != null;
			if (flag29)
			{
				string gotstr5 = Encoding.UTF8.GetString((byte[])ProviderType);
				byte[] towrite5 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr5));
				IDEControllerRegKey.SetValue("ProviderType", towrite5);
			}
			RegistryKey CurrentVersionRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			object BuildGUID = CurrentVersionRegKey.GetValue("BuildGUID");
			bool flag30 = BuildGUID != null;
			if (flag30)
			{
				CurrentVersionRegKey.SetValue("BuildGUID", Functions.StringRandomiseAroundHexadecimal(BuildGUID.ToString()));
			}
			object ProductId = CurrentVersionRegKey.GetValue("ProductId");
			bool flag31 = ProductId != null;
			if (flag31)
			{
				CurrentVersionRegKey.SetValue("ProductId", Functions.StringRandomiseAround(ProductId.ToString()));
			}
			object BuildGUIDEx = CurrentVersionRegKey.GetValue("BuildGUIDEx");
			bool flag32 = BuildGUIDEx != null;
			if (flag32)
			{
				string gotstr6 = Encoding.UTF8.GetString((byte[])BuildGUIDEx);
				byte[] towrite6 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr6));
				CurrentVersionRegKey.SetValue("BuildGUIDEx", towrite6);
			}
			object DigitalProductId = CurrentVersionRegKey.GetValue("DigitalProductId");
			bool flag33 = DigitalProductId != null;
			if (flag33)
			{
				string gotstr7 = Encoding.UTF8.GetString((byte[])DigitalProductId);
				byte[] towrite7 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr7));
				CurrentVersionRegKey.SetValue("DigitalProductId", towrite7);
			}
			object DigitalProductId2 = CurrentVersionRegKey.GetValue("DigitalProductId4");
			bool flag34 = DigitalProductId2 != null;
			if (flag34)
			{
				string gotstr8 = Encoding.UTF8.GetString((byte[])DigitalProductId2);
				byte[] towrite8 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr8));
				CurrentVersionRegKey.SetValue("DigitalProductId4", towrite8);
			}
			object InstallDate = CurrentVersionRegKey.GetValue("InstallDate");
			bool flag35 = InstallDate != null;
			if (flag35)
			{
				CurrentVersionRegKey.SetValue("InstallDate", Functions.StringRandomiseAround(InstallDate.ToString()));
			}
			object InstallTime = CurrentVersionRegKey.GetValue("InstallTime");
			bool flag36 = InstallTime != null;
			if (flag36)
			{
				CurrentVersionRegKey.SetValue("InstallTime", Functions.StringRandomiseAround(InstallTime.ToString()));
			}
			RegistryKey CryptographyRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
			object MachineGuid = CryptographyRegKey.GetValue("MachineGuid");
			bool flag37 = MachineGuid != null;
			if (flag37)
			{
				CryptographyRegKey.SetValue("MachineGuid", Functions.StringRandomiseAroundHexadecimal(MachineGuid.ToString()));
			}
			object GUID = CryptographyRegKey.GetValue("GUID");
			bool flag38 = GUID != null;
			if (flag38)
			{
				CryptographyRegKey.SetValue("GUID", Functions.StringRandomiseAroundHexadecimal(GUID.ToString()));
			}
			RegistryKey HardwareProfilesRegKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true);
			object HwProfileGuid = HardwareProfilesRegKey.GetValue("HwProfileGuid");
			bool flag39 = HwProfileGuid != null;
			if (flag39)
			{
				HardwareProfilesRegKey.SetValue("HwProfileGuid", Functions.StringRandomiseAroundHexadecimal(HwProfileGuid.ToString()));
			}
			RegistryKey WindowsUpdateRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate", true);
			object SusClientId = WindowsUpdateRegKey.GetValue("SusClientId");
			bool flag40 = SusClientId != null;
			if (flag40)
			{
				WindowsUpdateRegKey.SetValue("SusClientId", Functions.StringRandomiseAroundHexadecimal(SusClientId.ToString()));
			}
			object AccountDomainSid = WindowsUpdateRegKey.GetValue("AccountDomainSid");
			bool flag41 = AccountDomainSid != null;
			if (flag41)
			{
				WindowsUpdateRegKey.SetValue("AccountDomainSid", Functions.StringRandomiseAroundHexadecimal(AccountDomainSid.ToString()));
			}
			object PingID = WindowsUpdateRegKey.GetValue("PingID");
			bool flag42 = PingID != null;
			if (flag42)
			{
				WindowsUpdateRegKey.SetValue("PingID", Functions.StringRandomiseAroundHexadecimal(PingID.ToString()));
			}
			object SusClientIdValidation = WindowsUpdateRegKey.GetValue("SusClientIdValidation");
			bool flag43 = SusClientIdValidation != null;
			if (flag43)
			{
				string gotstr9 = Encoding.UTF8.GetString((byte[])SusClientIdValidation);
				byte[] towrite9 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr9));
				WindowsUpdateRegKey.SetValue("SusClientIdValidation", towrite9);
			}
			RegistryKey HardwareConfigRegKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\HardwareConfig", true);
			object LastConfig = HardwareConfigRegKey.GetValue("LastConfig");
			bool flag44 = LastConfig != null;
			if (flag44)
			{
				HardwareConfigRegKey.SetValue("LastConfig", Functions.StringRandomiseAroundHexadecimal(LastConfig.ToString()));
			}
			RegistryKey CS001SystemInformationRegKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\ControlSet001\\Control\\SystemInformation", true);
			object CS001ComputerHardwareId = CS001SystemInformationRegKey.GetValue("ComputerHardwareId");
			bool flag45 = CS001ComputerHardwareId != null;
			if (flag45)
			{
				CS001SystemInformationRegKey.SetValue("ComputerHardwareId", Functions.StringRandomiseAroundHexadecimal(CS001ComputerHardwareId.ToString()));
			}
			object CS001ComputerHardwareIds = CS001SystemInformationRegKey.GetValue("ComputerHardwareIds");
			bool flag46 = CS001ComputerHardwareIds != null;
			if (flag46)
			{
				CS001SystemInformationRegKey.SetValue("ComputerHardwareIds", Functions.StringRandomiseAroundHexadecimal(CS001ComputerHardwareIds.ToString()));
			}
			RegistryKey Tcpip6RegKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip6\\Parameters", true);
			object Dhcpv6DUID = Tcpip6RegKey.GetValue("Dhcpv6DUID");
			bool flag47 = Dhcpv6DUID != null;
			if (flag47)
			{
				string gotstr10 = Encoding.UTF8.GetString((byte[])Dhcpv6DUID);
				byte[] towrite10 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr10));
				Tcpip6RegKey.SetValue("Dhcpv6DUID", towrite10);
			}
			RegistryKey CCSSystemInformationRegKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", true);
			object CCSComputerHardwareId = CCSSystemInformationRegKey.GetValue("ComputerHardwareId");
			bool flag48 = CCSComputerHardwareId != null;
			if (flag48)
			{
				CCSSystemInformationRegKey.SetValue("ComputerHardwareId", Functions.StringRandomiseAroundHexadecimal(CCSComputerHardwareId.ToString()));
			}
			object CCSComputerHardwareIds = CCSSystemInformationRegKey.GetValue("ComputerHardwareIds");
			bool flag49 = CCSComputerHardwareIds != null;
			if (flag49)
			{
				CCSSystemInformationRegKey.SetValue("ComputerHardwareIds", Functions.StringRandomiseAroundHexadecimal(CCSComputerHardwareIds.ToString()));
			}
			RegistryKey MigrationRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Migration", true);
			object IEInstalledDate = MigrationRegKey.GetValue("IE Installed Date");
			bool flag50 = IEInstalledDate != null;
			if (flag50)
			{
				string gotstr11 = Encoding.UTF8.GetString((byte[])IEInstalledDate);
				byte[] towrite11 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr11));
				MigrationRegKey.SetValue("IE Installed Date", towrite11);
			}
			RegistryKey SQMClient = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\SQMClient", true);
			object MachineId = SQMClient.GetValue("MachineId");
			bool flag51 = MachineId != null;
			if (flag51)
			{
				SQMClient.SetValue("MachineId", Functions.StringRandomiseAroundHexadecimal(MachineId.ToString()));
			}
			object WinSqmFirstSessionStartTime = SQMClient.GetValue("WinSqmFirstSessionStartTime");
			bool flag52 = WinSqmFirstSessionStartTime != null;
			if (flag52)
			{
				Random random = new Random(Guid.NewGuid().GetHashCode());
				object gotstr12 = WinSqmFirstSessionStartTime;
				string newval = "";
				for (int x = 0; x < gotstr12.ToString().Length; x++)
				{
					byte[] buffer = new byte[5];
					random.NextBytes(buffer);
					newval += random.Next(0, 9).ToString();
				}
				SQMClient.SetValue("WinSqmFirstSessionStartTime", Convert.ToInt64(newval), RegistryValueKind.QWord);
			}
			RegistryKey GPU = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\GPU", true);
			object DeviceId = GPU.GetValue("DeviceId");
			bool flag53 = DeviceId != null;
			if (flag53)
			{
				string gotstr13 = Encoding.UTF8.GetString((byte[])DeviceId);
				byte[] towrite12 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr13));
				GPU.SetValue("DeviceId", towrite12);
			}
			object Revision = GPU.GetValue("Revision");
			bool flag54 = Revision != null;
			if (flag54)
			{
				string gotstr14 = Encoding.UTF8.GetString((byte[])Revision);
				byte[] towrite13 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr14));
				GPU.SetValue("Revision", towrite13);
			}
			object SubSysId = GPU.GetValue("SubSysId");
			bool flag55 = SubSysId != null;
			if (flag55)
			{
				string gotstr15 = Encoding.UTF8.GetString((byte[])SubSysId);
				byte[] towrite14 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr15));
				GPU.SetValue("SubSysId", towrite14);
			}
			object VendorId = GPU.GetValue("VendorId");
			bool flag56 = VendorId != null;
			if (flag56)
			{
				string gotstr16 = Encoding.UTF8.GetString((byte[])VendorId);
				byte[] towrite15 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr16));
				GPU.SetValue("VendorId", towrite15);
			}
			object Wow64DeviceId = GPU.GetValue("Wow64-DeviceId");
			bool flag57 = Wow64DeviceId != null;
			if (flag57)
			{
				string gotstr17 = Encoding.UTF8.GetString((byte[])Wow64DeviceId);
				byte[] towrite16 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr17));
				GPU.SetValue("Wow64-DeviceId", towrite16);
			}
			object Wow64Revision = GPU.GetValue("Wow64-Revision");
			bool flag58 = Wow64Revision != null;
			if (flag58)
			{
				string gotstr18 = Encoding.UTF8.GetString((byte[])Wow64Revision);
				byte[] towrite17 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr18));
				GPU.SetValue("Wow64-Revision", towrite17);
			}
			object Wow64SubSysId = GPU.GetValue("Wow64-SubSysId");
			bool flag59 = Wow64SubSysId != null;
			if (flag59)
			{
				string gotstr19 = Encoding.UTF8.GetString((byte[])Wow64SubSysId);
				byte[] towrite18 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr19));
				GPU.SetValue("Wow64-SubSysId", towrite18);
			}
			object Wow64VendorId = GPU.GetValue("Wow64-VendorId");
			bool flag60 = Wow64VendorId != null;
			if (flag60)
			{
				string gotstr20 = Encoding.UTF8.GetString((byte[])Wow64VendorId);
				byte[] towrite19 = Encoding.UTF8.GetBytes(Functions.StringRandomiseAroundHexadecimal(gotstr20));
				GPU.SetValue("Wow64-VendorId", towrite19);
			}
		}
	}
}
