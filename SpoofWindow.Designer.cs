namespace CheatoClient
{
	// Token: 0x0200002B RID: 43
	public partial class SpoofWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06000193 RID: 403 RVA: 0x00010B80 File Offset: 0x0000ED80
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00010BB8 File Offset: 0x0000EDB8
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::CheatoClient.SpoofWindow));
			this.spoofingText = new global::System.Windows.Forms.Label();
			this.spoofingTextTimer = new global::System.Windows.Forms.Timer(this.components);
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.loadingBox = new global::System.Windows.Forms.PictureBox();
			this.logoBox = new global::System.Windows.Forms.PictureBox();
			this.fadeInTimer = new global::System.Windows.Forms.Timer(this.components);
			this.fadeOutTimer = new global::System.Windows.Forms.Timer(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.loadingBox).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.logoBox).BeginInit();
			base.SuspendLayout();
			this.spoofingText.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.spoofingText.ForeColor = global::System.Drawing.Color.White;
			this.spoofingText.Location = new global::System.Drawing.Point(545, 492);
			this.spoofingText.Name = "spoofingText";
			this.spoofingText.Size = new global::System.Drawing.Size(830, 62);
			this.spoofingText.TabIndex = 0;
			this.spoofingText.Text = "Please wait while we spoof your PC";
			this.spoofingText.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.spoofingTextTimer.Enabled = true;
			this.spoofingTextTimer.Interval = 500;
			this.spoofingTextTimer.Tick += new global::System.EventHandler(this.spoofingTextTimer_Tick);
			this.textBox1.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.textBox1.BackColor = global::System.Drawing.Color.Black;
			this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new global::System.Drawing.Font("Segoe UI Light", 14f);
			this.textBox1.ForeColor = global::System.Drawing.Color.LightGray;
			this.textBox1.Location = new global::System.Drawing.Point(60, 698);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ShortcutsEnabled = false;
			this.textBox1.Size = new global::System.Drawing.Size(1800, 380);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox1.Click += new global::System.EventHandler(this.textBox1_Click);
			this.textBox1.Enter += new global::System.EventHandler(this.textBox1_Enter);
			this.textBox1.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.textBox1_MouseMove);
			this.label1.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Light", 18f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(545, 554);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(830, 35);
			this.label1.TabIndex = 3;
			this.label1.Text = "Do not turn off your computer.";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.loadingBox.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.loadingBox.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.loadingBox.Image = global::CheatoClient.Properties.Resources.windows_loading;
			this.loadingBox.Location = new global::System.Drawing.Point(935, 621);
			this.loadingBox.Name = "loadingBox";
			this.loadingBox.Size = new global::System.Drawing.Size(50, 50);
			this.loadingBox.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.loadingBox.TabIndex = 2;
			this.loadingBox.TabStop = false;
			this.logoBox.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.logoBox.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.logoBox.Image = global::CheatoClient.Properties.Resources.direct_hit_emoji_by_twitter;
			this.logoBox.Location = new global::System.Drawing.Point(900, 356);
			this.logoBox.Name = "logoBox";
			this.logoBox.Size = new global::System.Drawing.Size(120, 120);
			this.logoBox.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.logoBox.TabIndex = 1;
			this.logoBox.TabStop = false;
			this.fadeInTimer.Interval = 10;
			this.fadeInTimer.Tick += new global::System.EventHandler(this.fadeInTimer_Tick);
			this.fadeOutTimer.Interval = 10;
			this.fadeOutTimer.Tick += new global::System.EventHandler(this.fadeOutTimer_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(25f, 62f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.Black;
			base.ClientSize = new global::System.Drawing.Size(1920, 1080);
			base.ControlBox = false;
			base.Controls.Add(this.label1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.loadingBox);
			base.Controls.Add(this.logoBox);
			base.Controls.Add(this.spoofingText);
			this.Font = new global::System.Drawing.Font("Segoe UI Light", 35f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ForeColor = global::System.Drawing.Color.LightGray;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new global::System.Windows.Forms.Padding(12, 14, 12, 14);
			base.Name = "SpoofWindow";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.SpoofWindow_Load);
			((global::System.ComponentModel.ISupportInitialize)this.loadingBox).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.logoBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002F0 RID: 752
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002F1 RID: 753
		private global::System.Windows.Forms.Label spoofingText;

		// Token: 0x040002F2 RID: 754
		private global::System.Windows.Forms.Timer spoofingTextTimer;

		// Token: 0x040002F3 RID: 755
		private global::System.Windows.Forms.PictureBox logoBox;

		// Token: 0x040002F4 RID: 756
		private global::System.Windows.Forms.PictureBox loadingBox;

		// Token: 0x040002F5 RID: 757
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002F7 RID: 759
		private global::System.Windows.Forms.Timer fadeInTimer;

		// Token: 0x040002F8 RID: 760
		private global::System.Windows.Forms.Timer fadeOutTimer;
	}
}
