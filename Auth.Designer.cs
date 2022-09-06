namespace CheatoClient
{
	// Token: 0x0200000E RID: 14
	public partial class Auth : global::System.Windows.Forms.Form
	{
		// Token: 0x06000080 RID: 128 RVA: 0x0000748C File Offset: 0x0000568C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000074C4 File Offset: 0x000056C4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::CheatoClient.Auth));
			this.titleLabel = new global::System.Windows.Forms.Label();
			this.keyBox = new global::System.Windows.Forms.TextBox();
			this.button = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.loginLabel = new global::System.Windows.Forms.Label();
			this.fadeInTimer = new global::System.Windows.Forms.Timer(this.components);
			this.fadeOutTimer = new global::System.Windows.Forms.Timer(this.components);
			base.SuspendLayout();
			this.titleLabel.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.titleLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.titleLabel.Font = new global::System.Drawing.Font("Segoe UI", 18f);
			this.titleLabel.ForeColor = global::System.Drawing.Color.White;
			this.titleLabel.Location = new global::System.Drawing.Point(0, 8);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new global::System.Drawing.Size(600, 35);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "MOTD here cunts";
			this.titleLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.titleLabel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseDown);
			this.keyBox.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.keyBox.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.keyBox.Font = new global::System.Drawing.Font("Segoe UI Light", 14f);
			this.keyBox.ForeColor = global::System.Drawing.Color.White;
			this.keyBox.Location = new global::System.Drawing.Point(70, 160);
			this.keyBox.MaxLength = 64;
			this.keyBox.Name = "keyBox";
			this.keyBox.Size = new global::System.Drawing.Size(460, 25);
			this.keyBox.TabIndex = 2;
			this.keyBox.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.button.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.button.FlatAppearance.BorderSize = 0;
			this.button.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.button.ForeColor = global::System.Drawing.Color.White;
			this.button.Location = new global::System.Drawing.Point(260, 191);
			this.button.Name = "button";
			this.button.Size = new global::System.Drawing.Size(80, 26);
			this.button.TabIndex = 1;
			this.button.Text = "Login";
			this.button.UseVisualStyleBackColor = false;
			this.button.Click += new global::System.EventHandler(this.button_Click);
			this.label1.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 14f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(0, 274);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(600, 55);
			this.label1.TabIndex = 3;
			this.label1.Text = "Store, support and chat over at our official and only website chea.to\r\nAny other sites claiming to be us are FAKE and likely to be MALWARE!";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
			this.loginLabel.AutoSize = true;
			this.loginLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.loginLabel.Font = new global::System.Drawing.Font("Segoe UI", 21f);
			this.loginLabel.ForeColor = global::System.Drawing.Color.White;
			this.loginLabel.Location = new global::System.Drawing.Point(152, 116);
			this.loginLabel.Name = "loginLabel";
			this.loginLabel.Size = new global::System.Drawing.Size(297, 38);
			this.loginLabel.TabIndex = 4;
			this.loginLabel.Text = "Login with License Key";
			this.loginLabel.Visible = false;
			this.loginLabel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.loginLabel_MouseDown);
			this.fadeInTimer.Interval = 10;
			this.fadeInTimer.Tick += new global::System.EventHandler(this.fadeInTimer_Tick);
			this.fadeOutTimer.Interval = 10;
			this.fadeOutTimer.Tick += new global::System.EventHandler(this.fadeOutTimer_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			this.BackgroundImage = global::CheatoClient.Properties.Resources.chadspoofer2;
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new global::System.Drawing.Size(600, 338);
			base.Controls.Add(this.loginLabel);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button);
			base.Controls.Add(this.keyBox);
			base.Controls.Add(this.titleLabel);
			this.DoubleBuffered = true;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Auth";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cheato Spoofer";
			base.TopMost = true;
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.Auth_MouseDown);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000035 RID: 53
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Label titleLabel;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.TextBox keyBox;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.Button button;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.Label loginLabel;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.Timer fadeInTimer;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.Timer fadeOutTimer;
	}
}
