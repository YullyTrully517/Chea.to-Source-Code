using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using Sentry;

namespace CheatoClient
{
	// Token: 0x02000023 RID: 35
	internal class Program
	{
		// Token: 0x06000152 RID: 338 RVA: 0x0000CDB8 File Offset: 0x0000AFB8
		[STAThread]
		private static void Main(string[] args)
		{
			Stopwatch watch = new Stopwatch();
			watch.Start();
			using (SentrySdk.Init(delegate(SentryOptions o)
			{
				o.Dsn = "https://39bb50ba3b7d4ffabde593ae44bac5db@o1142731.ingest.sentry.io/6201782";
				o.Debug = true;
				o.TracesSampleRate = 1.0;
				o.AutoSessionTracking = true;
				o.SendDefaultPii = true;
				o.ShutdownTimeout = TimeSpan.FromSeconds(10.0);
				o.DiagnosticLevel = SentryLevel.Info;
			}))
			{
				bool flag = !Functions.IsElevated();
				if (flag)
				{
					Process.GetCurrentProcess().Kill();
				}
				TokenManipulation.MySetPrivilege("SeRestorePrivilege", true);
				TokenManipulation.MySetPrivilege("SeBackupPrivilege", true);
				TokenManipulation.MySetPrivilege("SeTakeOwnershipPrivilege", true);
				AmsiBypass.Execute();
				AntiDebugger.KillOnDetection = true;
				AntiReverserTools.KillOnDetection = true;
				bool flag2 = File.Exists(Path.Combine(Functions.GetStartupFolder(), AppDomain.CurrentDomain.FriendlyName));
				if (flag2)
				{
					Console.WriteLine("STARTUP MODE");
				}
				Console.Title = "";
				RegistryKey spoofdatakey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Spoof", true);
				bool flag3 = spoofdatakey.GetValue("EULAAcknowledgement") == null;
				if (flag3)
				{
					new GigaChadMessageBox("1. Please ensure that all cracking, reversal, debugging, analysis, etc. tools and running anticheats have been closed and disabled.\r\n2. Please ensure that you are not running Cheato Spoofer in a virtual machine or other similar environment e.g. online file analysis tool.\r\n3. Do not download, run or share any so-called 'cracks', 'dumps', 'leaks', etc. of Cheato Spoofer, its assets or other intellectual property of Cheato.\r\n4. Failure to follow the above may result in an automatic or manual blacklist and other unexpected behaviour.\r\n5. Please follow steps properly for the best results. Do not complain that this spoofer is not working if you have not properly followed the steps.\r\nThis is your FIRST and ONLY warning! If you disagree, please close, delete and cease use of Cheato Spoofer immediately.", "Cheato Spoofer End-User License Agreement", "I have agreed and understood.", 566, 342, 12f, ScrollBars.None, true).ShowDialog();
					spoofdatakey.SetValue("EULAAcknowledgement", true);
				}
				bool flag4 = spoofdatakey.GetValue("UseDesktopBackground") == null;
				if (flag4)
				{
					DialogResult result = MessageBox.Show("Do you want background to be your desktop wallpaper?\r\nThis can be changed later.", "Cheato Spoofer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag5 = result == DialogResult.Yes;
					if (flag5)
					{
						spoofdatakey.SetValue("UseDesktopBackground", true);
					}
					else
					{
						spoofdatakey.SetValue("UseDesktopBackground", false);
					}
				}
				string[] motd = new string[]
				{
					"Cheato GigaChad Sex Spoofer",
					"Spoofer for Sick Kunts Only",
					"We're also cracking YOUR pasted spoofer too!",
					"Regularly updated, tested and maintained!",
					"\"Biggest Paste of the 21st Century!\" - actual paster",
					"This increases your chances of getting laid by 69%",
					"The best spoofer on the market since sliced bread!",
					"Vanity Spoofer is an absolute joke, no joke lmao.",
					"Clowning pasted HWID spoofer devs since 2020!",
					"\"I smoke weed bro!\" - Vanity, while smoking meth",
					"\"how much spoofer cost?\" - too low IQ to look it up",
					"\"I'll chargeback after using key!\" - Mensa Chairman",
					"Which nigger keeps getting my PayPals banned?",
					"\"I want refund!\" - idiot who didn't disable Secure Boot",
					"\"I'll card ur store!\" - who forgot 3D Secure is enforced",
					"\"C++ = uncrackable, C# = paste m8\" - clueless moron",
					"Plz fund my car build bro, shit is getting EXPENSIVE"
				};
				Console.WriteLine("Is Secure Boot? {0}", Functions.IsSecureBoot());
				Console.WriteLine("Is TPM? {0}", Functions.IsTPM());
				Console.WriteLine("Is UEFI? {0}", Functions.IsUEFI());
				bool flag6 = !Functions.GetWindows().Contains("10") && !Functions.GetWindows().Contains("11") && Convert.ToInt32(Functions.GetWindowsBuild()) <= 10240;
				if (flag6)
				{
					new GigaChadMessageBox("You are running an unsupported version of Windows.", "Cheato Spoofer", "OK", 466, 115, 14f, ScrollBars.None, true).ShowDialog();
					Process.GetCurrentProcess().Kill();
				}
				Functions.DisableDefender(true);
				Program.shitAuth = new ShitAuth("Spoofer", "JA2ooMqUtR", "3bd7d18fb2d6873a7c846d99cf092f1688683c995289465046308d1e584144e7", "4.26");
				Program.shitAuth.init();
				bool flag7 = !Program.shitAuth.response.success;
				if (flag7)
				{
					bool flag8 = Program.shitAuth.response.message == "invalidver";
					if (flag8)
					{
						Process.Start(Program.shitAuth.app_data.downloadLink);
						Process.GetCurrentProcess().Kill();
					}
					new GigaChadMessageBox(Program.shitAuth.response.message, "Cheato Spoofer", "OK", 466, 150, 14f, ScrollBars.None, true).ShowDialog();
					Process.GetCurrentProcess().Kill();
				}
				Program.shitAuth.check();
				new Auth(motd[new Random(Guid.NewGuid().GetHashCode()).Next(motd.Length)]).ShowDialog();
				watch.Stop();
				Console.WriteLine(string.Format("Execution Time: {0} ms", watch.ElapsedMilliseconds));
				Console.WriteLine("Done");
			}
		}

		// Token: 0x040002E1 RID: 737
		public static ShitAuth shitAuth;

		// Token: 0x040002E2 RID: 738
		public static SpoofWindow spoofwindow;

		// Token: 0x040002E3 RID: 739
		public static bool Done;
	}
}
