using System;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

namespace CheatoClient
{
	// Token: 0x0200001E RID: 30
	public class AntiVirtualMachine
	{
		// Token: 0x060000D2 RID: 210
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandleW(string lib);

		// Token: 0x060000D3 RID: 211
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr ModuleHandle, string Function);

		// Token: 0x060000D4 RID: 212
		[DllImport("kernel32.dll", EntryPoint = "GetModuleHandle")]
		private static extern IntPtr GenericAcl(string lpModuleName);

		// Token: 0x060000D5 RID: 213
		[DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
		private static extern IntPtr TryCode(IntPtr hModule, string procName);

		// Token: 0x060000D6 RID: 214
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, EntryPoint = "GetFileAttributes", SetLastError = true)]
		private static extern uint ISymbolReader(string lpFileName);

		// Token: 0x060000D7 RID: 215 RVA: 0x0000A310 File Offset: 0x00008510
		public static bool Check()
		{
			bool result;
			try
			{
				bool flag = AntiVirtualMachine.DetectVirtualMachine() || AntiVirtualMachine.IsWinePresent() || AntiVirtualMachine.IsSandboxiePresent() || AntiVirtualMachine.IsQihoo360SandboxPresent() || AntiVirtualMachine.IsEmulationPresent() || AntiVirtualMachine.IsCuckooSandboxPresent() || AntiVirtualMachine.IsComodoSandboxPresent();
				if (flag)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000A378 File Offset: 0x00008578
		private static bool DetectVirtualMachine()
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject item in managementObjectCollection)
					{
						bool flag = (item["Manufacturer"].ToString().ToLower() == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) || item["Manufacturer"].ToString().ToLower().Contains("vmware") || item["Model"].ToString() == "VirtualBox";
						if (flag)
						{
							return true;
						}
					}
				}
			}
			foreach (ManagementBaseObject item2 in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
			{
				bool flag2 = item2.GetPropertyValue("Name").ToString().Contains("VMware") && item2.GetPropertyValue("Name").ToString().Contains("VBox");
				if (flag2)
				{
					return true;
				}
			}
			string[] regkeys = new string[]
			{
				"HARDWARE\\ACPI\\DSDT\\VBOX__",
				"HARDWARE\\ACPI\\FADT\\VBOX__",
				"HARDWARE\\ACPI\\RSDT\\VBOX__",
				"SOFTWARE\\Oracle\\VirtualBox Guest Additions",
				"SYSTEM\\ControlSet001\\Services\\VBoxGuest",
				"SYSTEM\\ControlSet001\\Services\\VBoxMouse",
				"SYSTEM\\ControlSet001\\Services\\VBoxService",
				"SYSTEM\\ControlSet001\\Services\\VBoxSF",
				"SYSTEM\\ControlSet001\\Services\\VBoxVideo",
				"SOFTWARE\\VMware, Inc.\\VMware Tools",
				"SOFTWARE\\Wine",
				"SOFTWARE\\Microsoft\\Virtual Machine\\Guest\\Parameters"
			};
			string[] files = new string[]
			{
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\VBoxMouse.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\VBoxGuest.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\VBoxSF.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\VBoxVideo.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxdisp.dll"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxhook.dll"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxmrxnp.dll"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxogl.dll"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxoglarrayspu.dll"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxoglcrutil.dll"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxoglerrorspu.dll"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxoglfeedbackspu.dll"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxoglpackspu.dll"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxoglpassthroughspu.dll"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxservice.exe"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vboxtray.exe"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "VBoxControl.exe"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\vmmouse.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\vmhgfs.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\vm3dmp.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\vmhgfs.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\vmmemctl.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\vmmouse.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\vmrawdsk.sys"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\vmusbmouse.sys")
			};
			string[] directories = new string[]
			{
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "oracle\\virtualbox guest additions\\")
			};
			foreach (string reg in regkeys)
			{
				bool flag3 = Registry.LocalMachine.OpenSubKey(reg) != null;
				if (flag3)
				{
					return true;
				}
				bool flag4 = Registry.CurrentUser.OpenSubKey(reg) != null;
				if (flag4)
				{
					return true;
				}
			}
			foreach (string file in files)
			{
				bool flag5 = File.Exists(file);
				if (flag5)
				{
					return true;
				}
			}
			foreach (string dir in directories)
			{
				bool flag6 = Directory.Exists(dir);
				if (flag6)
				{
					return true;
				}
			}
			return AntiVirtualMachine.MessageDictionary();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000A8AC File Offset: 0x00008AAC
		public static bool IsSandboxiePresent()
		{
			return AntiVirtualMachine.GetModuleHandleW("SbieDll.dll").ToInt32() != 0;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000A8DC File Offset: 0x00008ADC
		public static bool IsComodoSandboxPresent()
		{
			return AntiVirtualMachine.GetModuleHandleW("cmdvrt32.dll").ToInt32() != 0;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000A90C File Offset: 0x00008B0C
		public static bool IsQihoo360SandboxPresent()
		{
			return AntiVirtualMachine.GetModuleHandleW("SxIn.dll").ToInt32() != 0;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000A93C File Offset: 0x00008B3C
		public static bool IsCuckooSandboxPresent()
		{
			return AntiVirtualMachine.GetModuleHandleW("cuckoomon.dll").ToInt32() != 0;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000A96C File Offset: 0x00008B6C
		public static bool IsEmulationPresent()
		{
			long Tick = (long)Environment.TickCount;
			Thread.Sleep(500);
			long Tick2 = (long)Environment.TickCount;
			return Tick2 - Tick < 500L;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000A9AC File Offset: 0x00008BAC
		public static bool IsWinePresent()
		{
			IntPtr ModuleHandle = AntiVirtualMachine.GetModuleHandleW("kernel32.dll");
			return AntiVirtualMachine.GetProcAddress(ModuleHandle, "wine_get_unix_file_name").ToInt32() != 0;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000A9E8 File Offset: 0x00008BE8
		public static bool MessageDictionary()
		{
			bool flag = AntiVirtualMachine.SoapNcName("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VBOX") || AntiVirtualMachine.SoapNcName("HARDWARE\\Description\\System", "SystemBiosVersion").ToUpper().Contains("VBOX") || AntiVirtualMachine.SoapNcName("HARDWARE\\Description\\System", "VideoBiosVersion").ToUpper().Contains("VIRTUALBOX") || AntiVirtualMachine.SoapNcName("SOFTWARE\\Oracle\\VirtualBox Guest Additions", "") == "noValueButYesKey" || AntiVirtualMachine.ISymbolReader("C:\\WINDOWS\\system32\\drivers\\VBoxMouse.sys") != uint.MaxValue || AntiVirtualMachine.SoapNcName("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE") || AntiVirtualMachine.SoapNcName("SOFTWARE\\VMware, Inc.\\VMware Tools", "") == "noValueButYesKey" || AntiVirtualMachine.SoapNcName("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 1\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE") || AntiVirtualMachine.SoapNcName("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 2\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE") || AntiVirtualMachine.SoapNcName("SYSTEM\\ControlSet001\\Services\\Disk\\Enum", "0").ToUpper().Contains("vmware".ToUpper()) || AntiVirtualMachine.SoapNcName("SYSTEM\\ControlSet001\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", "DriverDesc").ToUpper().Contains("VMWARE") || AntiVirtualMachine.SoapNcName("SYSTEM\\ControlSet001\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000\\Settings", "Device Description").ToUpper().Contains("VMWARE") || AntiVirtualMachine.SoapNcName("SOFTWARE\\VMware, Inc.\\VMware Tools", "InstallPath").ToUpper().Contains("C:\\PROGRAM FILES\\VMWARE\\VMWARE TOOLS\\") || AntiVirtualMachine.ISymbolReader("C:\\WINDOWS\\system32\\drivers\\vmmouse.sys") != uint.MaxValue || AntiVirtualMachine.ISymbolReader("C:\\WINDOWS\\system32\\drivers\\vmhgfs.sys") != uint.MaxValue || AntiVirtualMachine.TryCode(AntiVirtualMachine.GenericAcl("kernel32.dll"), "wine_get_unix_file_name") != (IntPtr)0 || AntiVirtualMachine.SoapNcName("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("QEMU") || AntiVirtualMachine.SoapNcName("HARDWARE\\Description\\System", "SystemBiosVersion").ToUpper().Contains("QEMU");
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				foreach (ManagementBaseObject o in new ManagementObjectSearcher(new ManagementScope("\\\\.\\ROOT\\cimv2"), new ObjectQuery("SELECT * FROM Win32_VideoController")).Get())
				{
					ManagementObject managementObject = (ManagementObject)o;
					bool flag2 = managementObject["Description"].ToString() == "VM Additions S3 Trio32/64" || managementObject["Description"].ToString() == "S3 Trio32/64" || managementObject["Description"].ToString() == "VirtualBox Graphics Adapter" || managementObject["Description"].ToString() == "VMware SVGA II" || managementObject["Description"].ToString().ToUpper().Contains("VMWARE") || managementObject["Description"].ToString() == "";
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000AD54 File Offset: 0x00008F54
		private static string SoapNcName(string obj0, string obj1)
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(obj0, false);
			bool flag = registryKey == null;
			string result;
			if (flag)
			{
				result = "noKey";
			}
			else
			{
				object obj2 = registryKey.GetValue(obj1, "noValueButYesKey");
				bool flag2 = obj2 is string || registryKey.GetValueKind(obj1) == RegistryValueKind.String || registryKey.GetValueKind(obj1) == RegistryValueKind.ExpandString;
				if (flag2)
				{
					result = obj2.ToString();
				}
				else
				{
					bool flag3 = registryKey.GetValueKind(obj1) == RegistryValueKind.DWord;
					if (flag3)
					{
						result = Convert.ToString((int)obj2);
					}
					else
					{
						bool flag4 = registryKey.GetValueKind(obj1) == RegistryValueKind.QWord;
						if (flag4)
						{
							result = Convert.ToString((long)obj2);
						}
						else
						{
							bool flag5 = registryKey.GetValueKind(obj1) == RegistryValueKind.Binary;
							if (flag5)
							{
								result = Convert.ToString((byte[])obj2);
							}
							else
							{
								bool flag6 = registryKey.GetValueKind(obj1) == RegistryValueKind.MultiString;
								if (flag6)
								{
									result = string.Join("", (string[])obj2);
								}
								else
								{
									result = "noValueButYesKey";
								}
							}
						}
					}
				}
			}
			return result;
		}
	}
}
