using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using Microsoft.Win32;
using Sentry;

namespace CheatoClient
{
	// Token: 0x02000028 RID: 40
	internal class Network
	{
		// Token: 0x06000173 RID: 371 RVA: 0x0000DBB4 File Offset: 0x0000BDB4
		public static void SpoofMAC()
		{
			try
			{
				Process process = new Process();
				Random random = new Random(Guid.NewGuid().GetHashCode());
				ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapter");
				foreach (ManagementBaseObject managementBaseObject in searcher.Get())
				{
					ManagementObject queryObj = (ManagementObject)managementBaseObject;
					bool flag = Convert.ToBoolean(queryObj["PhysicalAdapter"]);
					if (flag)
					{
						string prefix = "02";
						bool flag2 = queryObj["NetConnectionID"].ToString().Contains("Bluetooth") || queryObj["Caption"].ToString().Contains("Bluetooth") || queryObj["Name"].ToString().Contains("Bluetooth");
						if (!flag2)
						{
							string deviceID = queryObj["DeviceID"].ToString().PadLeft(4, '0');
							RegistryKey regkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e972-e325-11ce-bfc1-08002be10318}\\" + deviceID, true);
							byte[] buffer = new byte[5];
							random.NextBytes(buffer);
							string generatedMAC = prefix + string.Concat((from x in buffer
							select string.Format("{0}", x.ToString("X2"))).ToArray<string>()).TrimEnd(new char[]
							{
								':'
							});
							regkey.SetValue("OriginalNetworkAddress", generatedMAC);
							regkey.SetValue("NetworkAddress", generatedMAC);
							regkey.SetValue("PnPCapabilities", "24");
							process.StartInfo.FileName = "netsh.exe";
							ProcessStartInfo startInfo = process.StartInfo;
							string str = "int set int name=\"";
							object obj = queryObj["NetConnectionID"];
							startInfo.Arguments = str + ((obj != null) ? obj.ToString() : null) + "\" disable";
							process.StartInfo.UseShellExecute = false;
							process.StartInfo.CreateNoWindow = true;
							process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
							process.Start();
							process.WaitForExit();
							ProcessStartInfo startInfo2 = process.StartInfo;
							string str2 = "int set int name=\"";
							object obj2 = queryObj["NetConnectionID"];
							startInfo2.Arguments = str2 + ((obj2 != null) ? obj2.ToString() : null) + "\" enable";
							process.Start();
							process.WaitForExit();
						}
					}
				}
				process.StartInfo.Arguments = "winsock reset";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "int ip reset";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "int ipv4 reset";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "int ipv6 reset";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "int tcp reset";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "int reset all";
				process.Start();
				process.WaitForExit();
				process.StartInfo.FileName = "ipconfig.exe";
				process.StartInfo.Arguments = "/release";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "/renew";
				process.Start();
				process.StartInfo.Arguments = "/flushdns";
				process.Start();
				process.WaitForExit();
				process.StartInfo.FileName = "nbtstat.exe";
				process.StartInfo.Arguments = "-R";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "-RR";
				process.Start();
				process.WaitForExit();
				process.StartInfo.FileName = "wmic.exe";
				process.StartInfo.Arguments = "PATH WIN32_NETWORKADAPTER WHERE PHYSICALADAPTER=TRUE CALL DISABLE";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "PATH WIN32_NETWORKADAPTER WHERE PHYSICALADAPTER=TRUE CALL ENABLE";
				process.Start();
				process.WaitForExit();
				process.StartInfo.FileName = "netsh.exe";
				process.StartInfo.Arguments = "advfirewall reset";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "int ipv6 reset";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "winsock reset";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "int ip reset";
				process.Start();
				process.WaitForExit();
				process.StartInfo.FileName = "ipconfig.exe";
				process.StartInfo.Arguments = "/release";
				process.Start();
				process.WaitForExit();
				process.StartInfo.Arguments = "/renew";
				process.Start();
				process.StartInfo.Arguments = "/flushdns";
				process.Start();
				process.WaitForExit();
				while (!Network.CheckInternet())
				{
					Program.spoofwindow.AppendTextBox("");
					Program.spoofwindow.AppendTextBox("Your internet connection still seems to be down after network spoofing.");
					Program.spoofwindow.AppendTextBox("Please sort out your connection.");
					Program.spoofwindow.AppendTextBox("");
					Program.spoofwindow.AppendTextBox("Common fixes:");
					Program.spoofwindow.AppendTextBox("1. Log back in to your Wi-Fi network.");
					Program.spoofwindow.AppendTextBox("2. Open Device Manager (CTRL + X -> Device Manager) -> Action in top bar -> Scan for hardware changes. Then test internet connection.");
					Program.spoofwindow.AppendTextBox("3. If still not working, go back to Device Manager -> Open your PC name -> Open Network adapters -> Right click your Wi-Fi or Ethernet adapter -> Update driver -> Browse my computer for drivers -> Let me pick from a list of available drivers on my computer -> Choose the driver -> Press Next, log back into Wi-Fi and then test your connection.");
					Program.spoofwindow.AppendTextBox("");
				}
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000E1D0 File Offset: 0x0000C3D0
		public static bool CheckInternet()
		{
			Stopwatch watch = new Stopwatch();
			watch.Start();
			while (watch.ElapsedMilliseconds / 1000L < 15L)
			{
				string IP = Functions.GetIP(false);
				bool flag = IP != null && IP.Length > 0;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}
	}
}
