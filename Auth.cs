using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using CheatoClient.Properties;
using Microsoft.Win32;

namespace CheatoClient
{
	// Token: 0x0200000E RID: 14
	public partial class Auth : Form
	{
		// Token: 0x06000075 RID: 117
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000076 RID: 118
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000077 RID: 119 RVA: 0x00006E8C File Offset: 0x0000508C
		public Auth(string motd = "")
		{
			this.InitializeComponent();
			this.titleLabel.Text = motd;
			bool flag = SavedOptions.Key != null;
			if (flag)
			{
				bool flag2 = SavedOptions.Key.Length > 0;
				if (flag2)
				{
					this.keyBox.Text = SavedOptions.Key;
				}
			}
			RegistryKey spoofdatakey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Spoof", true);
			bool flag3 = Convert.ToBoolean(spoofdatakey.GetValue("UseDesktopBackground"));
			if (flag3)
			{
				RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop");
				bool flag4 = regkey != null;
				if (flag4)
				{
					object wallpaperlocation = regkey.GetValue("WallPaper");
					bool flag5 = wallpaperlocation != null;
					if (flag5)
					{
						Bitmap gotimg = new Bitmap(wallpaperlocation.ToString());
						int targetWidth = base.ClientSize.Width;
						int targetHeight = base.ClientSize.Height;
						int x = gotimg.Width / 2 - targetWidth / 2;
						int y = gotimg.Height / 2 - targetHeight / 2;
						Rectangle cropArea = new Rectangle(x, y, targetWidth, targetHeight);
						Bitmap bgimage = gotimg.Clone(cropArea, gotimg.PixelFormat);
						this.BackgroundImage = Functions.Blur(bgimage, 4);
						this.BackgroundImageLayout = ImageLayout.None;
						this.loginLabel.Show();
					}
				}
			}
			base.Opacity = 0.0;
			this.fadeInTimer.Enabled = true;
			this.fadeInTimer.Start();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00007014 File Offset: 0x00005214
		private void button_Click(object sender, EventArgs e)
		{
			Program.shitAuth.license(this.keyBox.Text.Trim());
			bool success = Program.shitAuth.response.success;
			if (success)
			{
				DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
				dtDateTime = dtDateTime.AddSeconds((double)long.Parse(Program.shitAuth.user_data.subscriptions[0].expiry)).ToLocalTime();
				bool flag = (dtDateTime - DateTime.Now).TotalSeconds <= 0.0;
				if (flag)
				{
					bool flag2 = SavedOptions.Key != null;
					if (flag2)
					{
						SavedOptions.Key = null;
					}
					new GigaChadMessageBox("Your key has expired. Please buy a new key @ chea.to.", "Cheato Spoofer", "OK", 466, 145, 14f, ScrollBars.None, true).ShowDialog();
				}
				else
				{
					Program.shitAuth.setvar("BypassCheck", "1337");
					bool flag3 = Program.shitAuth.getvar("BypassCheck") != "1337";
					if (flag3)
					{
						new GigaChadMessageBox("Detected bypass attempt, stop being retarded \ud83d\udc80", "Cheato Spoofer", "OK", 466, 115, 14f, ScrollBars.None, true).ShowDialog();
						Process.GetCurrentProcess().Kill();
					}
					Program.shitAuth.setvar("BypassCheck", "Good");
					SavedOptions.Key = this.keyBox.Text.Trim();
					new GigaChadMessageBox("Login successful!\r\nThere are " + Program.shitAuth.expirydaysleft() + " left on your key.", "Cheato Spoofer", "OK", 466, 145, 14f, ScrollBars.None, true).ShowDialog();
					this.fadeInTimer.Enabled = false;
					this.fadeOutTimer.Enabled = true;
					this.fadeOutTimer.Start();
					new Main(this.titleLabel.Text).ShowDialog();
					while (!Program.Done)
					{
						Thread.Sleep(50);
					}
					base.Close();
				}
			}
			else
			{
				bool flag4 = SavedOptions.Key != null;
				if (flag4)
				{
					SavedOptions.Key = null;
				}
				new GigaChadMessageBox("Failed to login: " + Program.shitAuth.response.message, "Cheato Spoofer", "OK", 466, 230, 14f, ScrollBars.Vertical, true).ShowDialog();
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00007294 File Offset: 0x00005494
		private void textLabelBox_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Auth.ReleaseCapture();
				Auth.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000072D0 File Offset: 0x000054D0
		private void Auth_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Auth.ReleaseCapture();
				Auth.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000730C File Offset: 0x0000550C
		private void titleLabel_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Auth.ReleaseCapture();
				Auth.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00007348 File Offset: 0x00005548
		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Auth.ReleaseCapture();
				Auth.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00007384 File Offset: 0x00005584
		private void loginLabel_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Auth.ReleaseCapture();
				Auth.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000073C0 File Offset: 0x000055C0
		private void fadeInTimer_Tick(object sender, EventArgs e)
		{
			base.Opacity += 0.025;
			bool flag = base.Opacity >= 1.0;
			if (flag)
			{
				this.fadeInTimer.Stop();
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000740C File Offset: 0x0000560C
		private void fadeOutTimer_Tick(object sender, EventArgs e)
		{
			while (this.fadeInTimer.Enabled)
			{
				Thread.Sleep(50);
			}
			base.Opacity -= 0.025;
			bool flag = base.Opacity <= 0.025;
			if (flag)
			{
				base.Opacity = 0.0;
				base.Hide();
				this.fadeOutTimer.Stop();
			}
		}

		// Token: 0x04000033 RID: 51
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000034 RID: 52
		public const int HT_CAPTION = 2;
	}
}
