using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Sentry;

namespace CheatoClient
{
	// Token: 0x02000029 RID: 41
	internal class SMBIOS
	{
		// Token: 0x06000176 RID: 374 RVA: 0x0000E234 File Offset: 0x0000C434
		public static void SpoofAmericanMegatrendsMotherboard()
		{
			foreach (Process proc in Process.GetProcessesByName("amidewin"))
			{
				proc.Kill();
			}
			foreach (Process proc2 in Process.GetProcessesByName("amidewinx64"))
			{
				proc2.Kill();
			}
			bool flag = !Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12"));
			if (flag)
			{
				try
				{
					Directory.CreateDirectory(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12"));
				}
				catch
				{
				}
			}
			bool flag2 = !Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12"));
			if (flag2)
			{
				try
				{
					Directory.CreateDirectory(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12"));
				}
				catch
				{
				}
			}
			bool flag3 = !Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042"));
			if (flag3)
			{
				try
				{
					Directory.CreateDirectory(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042"));
				}
				catch
				{
				}
			}
			WebClient wc = new WebClient
			{
				Proxy = null
			};
			wc.Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.87 Safari/537.36");
			try
			{
				wc.DownloadFile("http://localhost/spoofer/api/download/AMI/32V2.12/amidewin.exe", Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12\\amidewin.exe"));
				wc.DownloadFile("http://localhost/spoofer/api/download/AMI/32V2.12/amifldrv32.sys", Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12\\amifldrv32.sys"));
				wc.DownloadFile("http://localhost/spoofer/api/download/AMI/64V2.12/amidewinx64.exe", Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12\\amidewinx64.exe"));
				wc.DownloadFile("http://localhost/spoofer/api/download/AMI/64V2.12/amifldrv64.sys", Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12\\amifldrv64.sys"));
				wc.DownloadFile("http://localhost/spoofer/api/download/AMI/64V5.20.0042/amidewinx64.exe", Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042\\amidewinx64.exe"));
				wc.DownloadFile("http://localhost/spoofer/api/download/AMI/64V5.20.0042/amifldrv64.sys", Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042\\amifldrv64.sys"));
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
			}
			string[] amiprograms212 = new string[]
			{
				Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12\\amidewin.exe"),
				Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12\\amidewinx64.exe")
			};
			string[] amiprograms213 = new string[]
			{
				Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042\\amidewinx64.exe")
			};
			string[] spoofing212 = new string[]
			{
				"/SM \"To Be Filled By O.E.M.\"",
				"/SP \"To Be Filled By O.E.M.\"",
				"/SS \"To Be Filled By O.E.M.\"",
				"/SU AUTO",
				"/SF \"To Be Filled By O.E.M.\"",
				"/BV \"To Be Filled By O.E.M.\"",
				"/BS \"To Be Filled By O.E.M.\"",
				"/BT \"To Be Filled By O.E.M.\"",
				"/CM \"To Be Filled By O.E.M.\"",
				"/CS \"To Be Filled By O.E.M.\"",
				"/CA \"To Be Filled By O.E.M.\"",
				"/PSN \"To Be Filled By O.E.M.\"",
				"/PPN \"To Be Filled By O.E.M.\"",
				"/PAT \"Unknown\"",
				"/OS 1 \"To Be Filled By O.E.M.\""
			};
			string[] spoofing213 = new string[]
			{
				"/IVN \"To Be Filled By O.E.M.\"",
				"/SM \"To Be Filled By O.E.M.\"",
				"/SP \"To Be Filled By O.E.M.\"",
				"/SS \"To Be Filled By O.E.M.\"",
				"/SU AUTO",
				"/SF \"To Be Filled By O.E.M.\"",
				"/BV \"To Be Filled By O.E.M.\"",
				"/BS \"To Be Filled By O.E.M.\"",
				"/BT \"To Be Filled By O.E.M.\"",
				"/CM \"To Be Filled By O.E.M.\"",
				"/CS \"To Be Filled By O.E.M.\"",
				"/CA \"To Be Filled By O.E.M.\"",
				"/PSN \"To Be Filled By O.E.M.\"",
				"/PPN \"To Be Filled By O.E.M.\"",
				"/PAT \"Unknown\"",
				"/OS 1 \"To Be Filled By O.E.M.\""
			};
			Process process = new Process();
			try
			{
				foreach (string program in amiprograms212)
				{
					foreach (string spoof in spoofing212)
					{
						process.StartInfo.FileName = program;
						process.StartInfo.WorkingDirectory = Path.GetDirectoryName(program);
						process.StartInfo.Arguments = spoof;
						process.StartInfo.UseShellExecute = true;
						process.StartInfo.CreateNoWindow = true;
						process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
						process.Start();
						process.WaitForExit();
					}
				}
				foreach (string program2 in amiprograms213)
				{
					foreach (string spoof2 in spoofing213)
					{
						process.StartInfo.FileName = program2;
						process.StartInfo.WorkingDirectory = Path.GetDirectoryName(program2);
						process.StartInfo.Arguments = spoof2;
						process.StartInfo.UseShellExecute = true;
						process.StartInfo.CreateNoWindow = true;
						process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
						process.Start();
						process.WaitForExit();
					}
				}
			}
			catch (Exception ex2)
			{
				SentrySdk.CaptureException(ex2);
			}
			bool flag4 = File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12\\amidewin.exe"));
			if (flag4)
			{
				try
				{
					File.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12\\amidewin.exe"));
				}
				catch
				{
				}
			}
			bool flag5 = File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12\\amifldrv32.sys"));
			if (flag5)
			{
				try
				{
					File.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12\\amifldrv32.sys"));
				}
				catch
				{
				}
			}
			bool flag6 = File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12\\amidewinx64.exe"));
			if (flag6)
			{
				try
				{
					File.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12\\amidewinx64.exe"));
				}
				catch
				{
				}
			}
			bool flag7 = File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12\\amifldrv64.sys"));
			if (flag7)
			{
				try
				{
					File.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12\\amifldrv64.sys"));
				}
				catch
				{
				}
			}
			bool flag8 = File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042\\amidewinx64.exe"));
			if (flag8)
			{
				try
				{
					File.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042\\amidewinx64.exe"));
				}
				catch
				{
				}
			}
			bool flag9 = File.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042\\amifldrv64.sys"));
			if (flag9)
			{
				try
				{
					File.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042\\amifldrv64.sys"));
				}
				catch
				{
				}
			}
			bool flag10 = Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12"));
			if (flag10)
			{
				try
				{
					Directory.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\32V2.12"));
				}
				catch
				{
				}
			}
			bool flag11 = Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12"));
			if (flag11)
			{
				try
				{
					Directory.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V2.12"));
				}
				catch
				{
				}
			}
			bool flag12 = Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042"));
			if (flag12)
			{
				try
				{
					Directory.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI\\64V5.20.0042"));
				}
				catch
				{
				}
			}
			bool flag13 = Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI"));
			if (flag13)
			{
				try
				{
					Directory.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\AMI"));
				}
				catch
				{
				}
			}
			bool flag14 = Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer"));
			if (flag14)
			{
				try
				{
					Directory.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer"));
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000EBCC File Offset: 0x0000CDCC
		public static void SpoofInsydeH2OMotherboard()
		{
			foreach (Process proc in Process.GetProcessesByName("H2OSDE-W"))
			{
				proc.Kill();
			}
			bool flag = !Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\InsydeH2O"));
			if (flag)
			{
				try
				{
					Directory.CreateDirectory(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\InsydeH2O"));
				}
				catch
				{
				}
			}
			string filepath = Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\InsydeH2O\\H2OSDE-W.exe");
			WebClient wc = new WebClient
			{
				Proxy = null
			};
			wc.Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.87 Safari/537.36");
			try
			{
				wc.DownloadFile("http://localhost/spoofer/api/download/InsydeH2O/H2OSDE-W.exe", filepath);
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
			}
			string[] spoofing = new string[]
			{
				"-OS 1 \"To Be Filled By O.E.M.\"",
				"-SM \"To Be Filled By O.E.M.\"",
				"-SP \"To Be Filled By O.E.M.\"",
				"-SS \"To Be Filled By O.E.M.\"",
				"-SU AUTO",
				"-SF \"To Be Filled By O.E.M.\"",
				"-BV \"To Be Filled By O.E.M.\"",
				"-BS \"To Be Filled By O.E.M.\"",
				"-CM \"To Be Filled By O.E.M.\"",
				"-CS \"To Be Filled By O.E.M.\"",
				"-CA \"To Be Filled By O.E.M.\""
			};
			Process process = new Process();
			try
			{
				foreach (string spoof in spoofing)
				{
					process.StartInfo.FileName = filepath;
					process.StartInfo.WorkingDirectory = Path.GetDirectoryName(filepath);
					process.StartInfo.Arguments = spoof;
					process.StartInfo.UseShellExecute = true;
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process.Start();
					process.WaitForExit();
				}
			}
			catch (Exception ex2)
			{
				SentrySdk.CaptureException(ex2);
			}
			bool flag2 = File.Exists(filepath);
			if (flag2)
			{
				try
				{
					File.Delete(filepath);
				}
				catch
				{
				}
			}
			bool flag3 = Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\InsydeH2O"));
			if (flag3)
			{
				try
				{
					Directory.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer\\InsydeH2O"));
				}
				catch
				{
				}
			}
			bool flag4 = Directory.Exists(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer"));
			if (flag4)
			{
				try
				{
					Directory.Delete(Path.Combine(Environment.ExpandEnvironmentVariables("%systemroot%"), "Spoofer"));
				}
				catch
				{
				}
			}
		}
	}
}
