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
	// Token: 0x02000005 RID: 5
	public partial class Main : Form
	{
		// Token: 0x06000013 RID: 19
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000014 RID: 20
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000015 RID: 21 RVA: 0x00002C9C File Offset: 0x00000E9C
		public Main(string motd = "")
		{
			this.InitializeComponent();
			this.titleLabel.Text = motd;
			bool flag = Convert.ToBoolean(Main.spoofdatakey.GetValue("UseDesktopBackground"));
			if (flag)
			{
				RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop");
				bool flag2 = regkey != null;
				if (flag2)
				{
					object wallpaperlocation = regkey.GetValue("WallPaper");
					bool flag3 = wallpaperlocation != null;
					if (flag3)
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
					}
				}
				this.bgButton.Text = "Use Sex Background";
			}
			else
			{
				this.bgButton.Text = "Use Desktop Background";
			}
			bool flag4 = Main.spoofdatakey.GetValue("SpoofingType") == null;
			if (flag4)
			{
				Main.SpoofingType = "Not Selected";
			}
			else
			{
				Main.SpoofingType = SavedOptions.SpoofingType;
			}
			this.spoofingTypeLabel.Text = "Spoofing Type (" + Main.SpoofingType + ")";
			bool flag5 = Main.spoofdatakey.GetValue("CleaningType") == null;
			if (flag5)
			{
				Main.CleaningType = "Not Selected";
			}
			else
			{
				Main.CleaningType = SavedOptions.CleaningType;
			}
			this.cleaningTypeLabel.Text = "Cleaning Type (" + Main.CleaningType + ")";
			foreach (ShitAuth.Data sub in Program.shitAuth.user_data.subscriptions)
			{
				bool flag6 = sub.subscription != "perma";
				if (flag6)
				{
					this.spoofPermanentButton.Enabled = false;
					this.spoofPermanentButton.Visible = false;
					this.spoofTempButton.Size = new Size(246, 26);
					bool flag7 = sub.subscription != "trial";
					if (flag7)
					{
						this.spoofingTypeLabel.Text = "Temporary Spoof Only - Please Consider A Better Plan :)";
					}
					else
					{
						this.spoofingTypeLabel.Text = "Temporary Spoof Only - Enjoy The Trial :)";
					}
					Main.SpoofingType = "Temporary";
					SavedOptions.SpoofingType = "Temporary";
				}
			}
			base.Opacity = 0.0;
			this.fadeInTimer.Enabled = true;
			this.fadeInTimer.Start();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002F94 File Offset: 0x00001194
		private void button_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002FA0 File Offset: 0x000011A0
		private void textLabelBox_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002FDC File Offset: 0x000011DC
		private void Main_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003018 File Offset: 0x00001218
		private void titleLabel_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003054 File Offset: 0x00001254
		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003090 File Offset: 0x00001290
		private void loginLabel_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000030CC File Offset: 0x000012CC
		private void fadeInTimer_Tick(object sender, EventArgs e)
		{
			base.Opacity += 0.025;
			bool flag = base.Opacity >= 1.0;
			if (flag)
			{
				this.fadeInTimer.Stop();
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003118 File Offset: 0x00001318
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
				this.fadeOutTimer.Stop();
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000318E File Offset: 0x0000138E
		private void button_Click_1(object sender, EventArgs e)
		{
			this.fadeOutTimer.Enabled = true;
			this.fadeOutTimer.Start();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000031AC File Offset: 0x000013AC
		private void spoofingTypeLabel_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000031E8 File Offset: 0x000013E8
		private void cleaningTypeLabel_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003224 File Offset: 0x00001424
		private void cleanSpoofLabel_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Main.ReleaseCapture();
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000325E File Offset: 0x0000145E
		private void spoofTempButton_Click(object sender, EventArgs e)
		{
			Main.SpoofingType = "Temporary";
			this.spoofingTypeLabel.Text = "Spoofing Type (" + Main.SpoofingType + ")";
			SavedOptions.SpoofingType = Main.SpoofingType;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003296 File Offset: 0x00001496
		private void spoofPermanentButton_Click(object sender, EventArgs e)
		{
			Main.SpoofingType = "Permanent";
			this.spoofingTypeLabel.Text = "Spoofing Type (" + Main.SpoofingType + ")";
			SavedOptions.SpoofingType = Main.SpoofingType;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000032CE File Offset: 0x000014CE
		private void cleanNoneButton_Click(object sender, EventArgs e)
		{
			Main.CleaningType = "None";
			this.cleaningTypeLabel.Text = "Cleaning Type (" + Main.CleaningType + ")";
			SavedOptions.CleaningType = Main.CleaningType;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003306 File Offset: 0x00001506
		private void cleanNormalButton_Click(object sender, EventArgs e)
		{
			Main.CleaningType = "Normal";
			this.cleaningTypeLabel.Text = "Cleaning Type (" + Main.CleaningType + ")";
			SavedOptions.CleaningType = Main.CleaningType;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000333E File Offset: 0x0000153E
		private void cleanAggressiveButton_Click(object sender, EventArgs e)
		{
			Main.CleaningType = "Aggressive";
			this.cleaningTypeLabel.Text = "Cleaning Type (" + Main.CleaningType + ")";
			SavedOptions.CleaningType = Main.CleaningType;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003376 File Offset: 0x00001576
		private void supportButton_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.chea.to");
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003384 File Offset: 0x00001584
		private void storeButton_Click(object sender, EventArgs e)
		{
			Process.Start("https://chea.to");
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003394 File Offset: 0x00001594
		private void bgButton_Click(object sender, EventArgs e)
		{
			bool flag = Convert.ToBoolean(Main.spoofdatakey.GetValue("UseDesktopBackground"));
			if (flag)
			{
				SavedOptions.UseDesktopBackground = false;
				this.bgButton.Text = "Use Desktop Background";
				this.BackgroundImage = Resources.chadspoofer1;
			}
			else
			{
				SavedOptions.UseDesktopBackground = true;
				this.bgButton.Text = "Use Sex Background";
				RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop");
				bool flag2 = regkey != null;
				if (flag2)
				{
					object wallpaperlocation = regkey.GetValue("WallPaper");
					bool flag3 = wallpaperlocation != null;
					if (flag3)
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
					}
				}
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000034C0 File Offset: 0x000016C0
		private void beginButton_Click(object sender, EventArgs e)
		{
			bool flag = Main.SpoofingType == "Not Selected";
			if (flag)
			{
				new GigaChadMessageBox("Please select a spoofing type!", "Cheato Spoofer", "OK", 366, 118, 14f, ScrollBars.None, true).ShowDialog();
			}
			else
			{
				bool flag2 = Main.CleaningType == "Not Selected";
				if (flag2)
				{
					new GigaChadMessageBox("Please select a cleaning type!", "Cheato Spoofer", "OK", 366, 118, 14f, ScrollBars.None, true).ShowDialog();
				}
				else
				{
					Cursor.Hide();
					this.fadeInTimer.Enabled = false;
					this.fadeOutTimer.Enabled = true;
					this.fadeOutTimer.Start();
					Program.spoofwindow = new SpoofWindow(Main.SpoofingType, Main.CleaningType);
					Program.spoofwindow.ShowDialog();
					base.Close();
				}
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000035A0 File Offset: 0x000017A0
		private void revertButton_Click(object sender, EventArgs e)
		{
			Cursor.Hide();
			this.fadeInTimer.Enabled = false;
			this.fadeOutTimer.Enabled = true;
			this.fadeOutTimer.Start();
			Program.spoofwindow = new SpoofWindow("Revert", null);
			Program.spoofwindow.ShowDialog();
			base.Close();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000035FC File Offset: 0x000017FC
		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			Program.Done = true;
		}

		// Token: 0x04000005 RID: 5
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000006 RID: 6
		public const int HT_CAPTION = 2;

		// Token: 0x04000007 RID: 7
		public static string SpoofingType;

		// Token: 0x04000008 RID: 8
		public static string CleaningType;

		// Token: 0x04000009 RID: 9
		public static RegistryKey spoofdatakey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Spoof", true);
	}
}
