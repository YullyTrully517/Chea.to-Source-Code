using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheatoClient.Properties;

namespace CheatoClient
{
	// Token: 0x0200002B RID: 43
	public partial class SpoofWindow : Form
	{
		// Token: 0x06000186 RID: 390 RVA: 0x00010758 File Offset: 0x0000E958
		public SpoofWindow(string SpoofType, string CleanType)
		{
			this.InitializeComponent();
			base.Opacity = 0.0;
			base.CenterToScreen();
			base.WindowState = FormWindowState.Maximized;
			this.spoofingTextTimer.Start();
			base.UseWaitCursor = false;
			this.textBox1.Cursor = Cursors.Arrow;
			this.textBox1.ShortcutsEnabled = false;
			Functions.PlayWav(Resources._10x, false);
			this.fadeOutTimer.Enabled = false;
			this.fadeInTimer.Enabled = true;
			this.fadeInTimer.Start();
			SpoofWindow.SpoofingType = SpoofType;
			SpoofWindow.CleaningType = CleanType;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0001080C File Offset: 0x0000EA0C
		public void AppendTextBox(string value)
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.Invoke(new Action<string>(this.AppendTextBox), new object[]
				{
					value
				});
			}
			else
			{
				TextBox textBox = this.textBox1;
				textBox.Text = textBox.Text + value + Environment.NewLine;
				base.Invoke(new MethodInvoker(delegate()
				{
					this.textBox1.SelectionStart = this.textBox1.Text.Length;
					this.textBox1.ScrollToCaret();
				}));
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00010874 File Offset: 0x0000EA74
		public void Done()
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.Invoke(new Action(this.Done));
			}
			else
			{
				Program.Done = true;
				this.fadeInTimer.Enabled = false;
				this.fadeOutTimer.Enabled = true;
				this.fadeOutTimer.Start();
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000108D0 File Offset: 0x0000EAD0
		private void spoofingTextTimer_Tick(object sender, EventArgs e)
		{
			bool flag = SpoofWindow.SpoofingLabelDots == "";
			if (flag)
			{
				SpoofWindow.SpoofingLabelDots = ".";
			}
			else
			{
				bool flag2 = SpoofWindow.SpoofingLabelDots == ".";
				if (flag2)
				{
					SpoofWindow.SpoofingLabelDots = "..";
				}
				else
				{
					bool flag3 = SpoofWindow.SpoofingLabelDots == "..";
					if (flag3)
					{
						SpoofWindow.SpoofingLabelDots = "...";
					}
					else
					{
						bool flag4 = SpoofWindow.SpoofingLabelDots == "...";
						if (flag4)
						{
							SpoofWindow.SpoofingLabelDots = "";
						}
					}
				}
			}
			this.spoofingText.Text = SpoofWindow.SpoofingLabelText + SpoofWindow.SpoofingLabelDots;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0001097B File Offset: 0x0000EB7B
		private void textBox1_MouseMove(object sender, MouseEventArgs e)
		{
			this.textBox1.SelectionLength = 0;
			this.textBox1.DeselectAll();
			this.logoBox.Focus();
			this.Cursor = Cursors.Arrow;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000109AF File Offset: 0x0000EBAF
		private void textBox1_Enter(object sender, EventArgs e)
		{
			this.textBox1.SelectionLength = 0;
			this.textBox1.DeselectAll();
			this.logoBox.Focus();
			this.Cursor = Cursors.Arrow;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000109E3 File Offset: 0x0000EBE3
		private void textBox1_Click(object sender, EventArgs e)
		{
			this.textBox1.SelectionLength = 0;
			this.textBox1.DeselectAll();
			this.logoBox.Focus();
			this.Cursor = Cursors.Arrow;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00010A18 File Offset: 0x0000EC18
		private void fadeInTimer_Tick(object sender, EventArgs e)
		{
			base.Opacity += 0.01;
			bool flag = base.Opacity >= 1.0;
			if (flag)
			{
				this.fadeInTimer.Stop();
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00010A64 File Offset: 0x0000EC64
		private void fadeOutTimer_Tick(object sender, EventArgs e)
		{
			base.Opacity -= 0.01;
			bool flag = base.Opacity <= 0.0;
			if (flag)
			{
				base.Close();
				this.fadeOutTimer.Stop();
			}
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00010AB6 File Offset: 0x0000ECB6
		private void SpoofWindow_Load(object sender, EventArgs e)
		{
			Task.Run(delegate()
			{
				this.Spoof();
			});
		}

		// Token: 0x06000190 RID: 400
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern void BlockInput([MarshalAs(UnmanagedType.Bool)] [In] bool fBlockIt);

		// Token: 0x06000191 RID: 401
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern void ShowCursor([MarshalAs(UnmanagedType.Bool)] [In] bool bShow);

		// Token: 0x06000192 RID: 402 RVA: 0x00010ACC File Offset: 0x0000ECCC
		private void Spoof()
		{
			Stopwatch watch = new Stopwatch();
			watch.Start();
			Screen currentScreen = Screen.FromHandle(Process.GetCurrentProcess().MainWindowHandle);
			bool flag = SpoofWindow.SpoofingType == "Revert";
			if (flag)
			{
				SpoofWindow.SpoofingLabelText = "Please wait while we revert your PC";
			}
			else
			{
				SpoofWindow.SpoofingLabelText = "Please wait while we spoof your PC";
			}
			Thread.Sleep(5000);
			SpoofWindow.BlockInput(false);
			SpoofWindow.ShowCursor(true);
			Cursor.Position = new Point(currentScreen.Bounds.Width / 2, currentScreen.Bounds.Height / 2);
			Functions.PlayWav(Resources._11, false);
			this.Done();
		}

		// Token: 0x040002EC RID: 748
		private static string SpoofingType;

		// Token: 0x040002ED RID: 749
		private static string CleaningType;

		// Token: 0x040002EE RID: 750
		public static string SpoofingLabelText = "Please wait while we start messing around with your PC";

		// Token: 0x040002EF RID: 751
		private static string SpoofingLabelDots = "";
	}
}
