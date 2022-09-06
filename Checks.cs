using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using Microsoft.Win32;

namespace CheatoClient
{
	// Token: 0x02000024 RID: 36
	internal class Checks
	{
		// Token: 0x06000154 RID: 340 RVA: 0x0000D200 File Offset: 0x0000B400
		public static bool CheckRunningAntiCheats()
		{
			bool IsAntiCheat = false;
			try
			{
				bool flag = Functions.IsService("FACEIT") && new ServiceController("FACEIT").Status != ServiceControllerStatus.Stopped;
				if (flag)
				{
					IsAntiCheat = true;
				}
			}
			catch (Exception)
			{
			}
			try
			{
				bool flag2 = Functions.IsService("vgk") && new ServiceController("vgk").Status != ServiceControllerStatus.Stopped;
				if (flag2)
				{
					IsAntiCheat = true;
				}
			}
			catch (Exception)
			{
			}
			try
			{
				bool flag3 = Functions.IsService("EasyAntiCheatSys") && new ServiceController("EasyAntiCheatSys").Status != ServiceControllerStatus.Stopped;
				if (flag3)
				{
					IsAntiCheat = true;
				}
			}
			catch (Exception)
			{
			}
			try
			{
				bool flag4 = (Functions.IsService("BEDaisy") && new ServiceController("BEDaisy").Status != ServiceControllerStatus.Stopped) || (Functions.IsService("BEService") && new ServiceController("BEService").Status != ServiceControllerStatus.Stopped);
				if (flag4)
				{
					IsAntiCheat = true;
				}
			}
			catch (Exception)
			{
			}
			return IsAntiCheat;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000D348 File Offset: 0x0000B548
		public static bool IsAnyRun()
		{
			int anyrunflag = 0;
			RegistryKey CurrentVersionRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			object CurVer = CurrentVersionRegKey.GetValue("CurrentVersion");
			bool flag = CurVer != null;
			if (flag)
			{
				bool flag2 = CurVer.ToString() == "6.1";
				if (flag2)
				{
					anyrunflag++;
				}
			}
			object CurBuild = CurrentVersionRegKey.GetValue("CurrentBuild");
			bool flag3 = CurBuild != null;
			if (flag3)
			{
				bool flag4 = CurBuild.ToString() == "7601";
				if (flag4)
				{
					anyrunflag++;
				}
			}
			object ProductName = CurrentVersionRegKey.GetValue("ProductName");
			bool flag5 = ProductName != null;
			if (flag5)
			{
				bool flag6 = ProductName.ToString().Contains("Windows 7");
				if (flag6)
				{
					anyrunflag++;
				}
			}
			bool flag7 = Environment.MachineName == "USER-PC";
			if (flag7)
			{
				anyrunflag++;
			}
			ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapter");
			foreach (ManagementBaseObject managementBaseObject in searcher.Get())
			{
				ManagementObject queryObj = (ManagementObject)managementBaseObject;
				bool flag8 = Convert.ToBoolean(queryObj["PhysicalAdapter"]);
				if (flag8)
				{
					string deviceID = queryObj["DeviceID"].ToString().PadLeft(4, '0');
					RegistryKey regkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}\\" + deviceID, true);
					bool flag9 = regkey.GetValue("DriverDesc").ToString() == "Intel(R) PRO/1000 MT Network Connection";
					if (flag9)
					{
						anyrunflag++;
					}
				}
			}
			bool flag10 = (from g in (from n in NetworkInterface.GetAllNetworkInterfaces()
			where n.OperationalStatus == OperationalStatus.Up
			where n.NetworkInterfaceType != NetworkInterfaceType.Loopback
			select n).SelectMany(delegate(NetworkInterface n)
			{
				IPInterfaceProperties ipproperties = n.GetIPProperties();
				return (ipproperties != null) ? ipproperties.GatewayAddresses : null;
			})
			select (g != null) ? g.Address : null into a
			where a != null
			select a).FirstOrDefault<IPAddress>().ToString() == "192.168.100.2";
			if (flag10)
			{
				anyrunflag++;
			}
			bool flag11 = (from a in (from n in NetworkInterface.GetAllNetworkInterfaces()
			where n.OperationalStatus == OperationalStatus.Up
			where n.NetworkInterfaceType != NetworkInterfaceType.Loopback
			select n).SelectMany(delegate(NetworkInterface n)
			{
				IPInterfaceProperties ipproperties = n.GetIPProperties();
				return (ipproperties != null) ? ipproperties.DnsAddresses : null;
			})
			where a != null
			select a).FirstOrDefault<IPAddress>().ToString() == "192.168.100.2";
			if (flag11)
			{
				anyrunflag++;
			}
			int shortcutflag = 0;
			try
			{
				string[] shortcuts = new string[]
				{
					"Acrobat Reader DC",
					"CCleaner",
					"FileZilla Client",
					"Firefox",
					"Google Chrome",
					"Opera",
					"Skype",
					"VLC media player"
				};
				foreach (string file in Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)))
				{
					bool flag12 = shortcuts.Contains(file.ToString().Replace(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory), "").Replace("\\", "").Replace(".lnk", ""));
					if (flag12)
					{
						shortcutflag++;
					}
				}
			}
			catch
			{
			}
			return anyrunflag > 4 && shortcutflag > 4;
		}
	}
}
