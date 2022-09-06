using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CheatoClient
{
	// Token: 0x02000010 RID: 16
	public partial class GigaChadMessageBox : Form
	{
		// Token: 0x0600008C RID: 140
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x0600008D RID: 141
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x0600008E RID: 142 RVA: 0x00007DEC File Offset: 0x00005FEC
		public GigaChadMessageBox(string message = "", string title = "Cheato Spoofer", string buttontext = "OK", int setwidth = 466, int setheight = 239, float fontsize = 14f, ScrollBars scrollbars = ScrollBars.Vertical, bool isreadonly = false)
		{
			this.InitializeComponent();
			this.Text = title;
			this.textBox.Text = message;
			this.button.Text = buttontext;
			base.Width = setwidth;
			base.Height = setheight;
			this.textBox.Font = new Font("Segoe UI", fontsize);
			this.textBox.ScrollBars = scrollbars;
			GigaChadMessageBox.isreadonly = isreadonly;
			base.UseWaitCursor = false;
			if (isreadonly)
			{
				this.textBox.ShortcutsEnabled = false;
				this.textBox.Cursor = Cursors.Arrow;
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00007E9E File Offset: 0x0000609E
		private void button_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00007EA8 File Offset: 0x000060A8
		private void GigaChadMessageBox_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				GigaChadMessageBox.ReleaseCapture();
				GigaChadMessageBox.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00007EE2 File Offset: 0x000060E2
		private void textBox_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00007EE8 File Offset: 0x000060E8
		private void textBox_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = GigaChadMessageBox.isreadonly;
			if (flag)
			{
				this.textBox.SelectionLength = 0;
				this.textBox.DeselectAll();
				this.button.Focus();
				this.Cursor = Cursors.Arrow;
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00007F34 File Offset: 0x00006134
		private void textBox_Click(object sender, EventArgs e)
		{
			bool flag = GigaChadMessageBox.isreadonly;
			if (flag)
			{
				this.textBox.SelectionLength = 0;
				this.textBox.DeselectAll();
				this.button.Focus();
				this.Cursor = Cursors.Arrow;
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00007F80 File Offset: 0x00006180
		private void textBox_Enter(object sender, EventArgs e)
		{
			bool flag = GigaChadMessageBox.isreadonly;
			if (flag)
			{
				this.textBox.SelectionLength = 0;
				this.textBox.DeselectAll();
				this.button.Focus();
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00007FC0 File Offset: 0x000061C0
		private void textBox_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = GigaChadMessageBox.isreadonly;
			if (flag)
			{
				bool flag2 = e.Button == MouseButtons.Left;
				if (flag2)
				{
					GigaChadMessageBox.ReleaseCapture();
					GigaChadMessageBox.SendMessage(base.Handle, 161, 2, 0);
				}
			}
		}

		// Token: 0x0400003E RID: 62
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x0400003F RID: 63
		public const int HT_CAPTION = 2;

		// Token: 0x04000040 RID: 64
		private static bool isreadonly;
	}
}
