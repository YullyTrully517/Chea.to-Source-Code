namespace CheatoClient
{
	// Token: 0x02000005 RID: 5
	public partial class Main : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00003608 File Offset: 0x00001808
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003640 File Offset: 0x00001840
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::CheatoClient.Main));
			this.titleLabel = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.fadeInTimer = new global::System.Windows.Forms.Timer(this.components);
			this.fadeOutTimer = new global::System.Windows.Forms.Timer(this.components);
			this.spoofingTypeLabel = new global::System.Windows.Forms.Label();
			this.cleaningTypeLabel = new global::System.Windows.Forms.Label();
			this.beginButton = new global::System.Windows.Forms.Button();
			this.cleanNoneButton = new global::System.Windows.Forms.Button();
			this.cleanSpoofLabel = new global::System.Windows.Forms.Label();
			this.cleanAggressiveButton = new global::System.Windows.Forms.Button();
			this.spoofTempButton = new global::System.Windows.Forms.Button();
			this.spoofPermanentButton = new global::System.Windows.Forms.Button();
			this.cleanNormalButton = new global::System.Windows.Forms.Button();
			this.supportButton = new global::System.Windows.Forms.Button();
			this.bgButton = new global::System.Windows.Forms.Button();
			this.storeButton = new global::System.Windows.Forms.Button();
			this.revertButton = new global::System.Windows.Forms.Button();
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
			this.fadeInTimer.Interval = 10;
			this.fadeInTimer.Tick += new global::System.EventHandler(this.fadeInTimer_Tick);
			this.fadeOutTimer.Interval = 10;
			this.fadeOutTimer.Tick += new global::System.EventHandler(this.fadeOutTimer_Tick);
			this.spoofingTypeLabel.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.spoofingTypeLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.spoofingTypeLabel.Font = new global::System.Drawing.Font("Segoe UI Light", 16f);
			this.spoofingTypeLabel.ForeColor = global::System.Drawing.Color.White;
			this.spoofingTypeLabel.Location = new global::System.Drawing.Point(0, 45);
			this.spoofingTypeLabel.Name = "spoofingTypeLabel";
			this.spoofingTypeLabel.Size = new global::System.Drawing.Size(600, 32);
			this.spoofingTypeLabel.TabIndex = 4;
			this.spoofingTypeLabel.Text = "Spoofing Type (N/A)";
			this.spoofingTypeLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.spoofingTypeLabel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.spoofingTypeLabel_MouseDown);
			this.cleaningTypeLabel.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.cleaningTypeLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.cleaningTypeLabel.Font = new global::System.Drawing.Font("Segoe UI Light", 16f);
			this.cleaningTypeLabel.ForeColor = global::System.Drawing.Color.White;
			this.cleaningTypeLabel.Location = new global::System.Drawing.Point(0, 111);
			this.cleaningTypeLabel.Name = "cleaningTypeLabel";
			this.cleaningTypeLabel.Size = new global::System.Drawing.Size(600, 32);
			this.cleaningTypeLabel.TabIndex = 5;
			this.cleaningTypeLabel.Text = "Cleaning Type (N/A)";
			this.cleaningTypeLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.cleaningTypeLabel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cleaningTypeLabel_MouseDown);
			this.beginButton.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.beginButton.FlatAppearance.BorderSize = 0;
			this.beginButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.beginButton.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.beginButton.ForeColor = global::System.Drawing.Color.White;
			this.beginButton.Location = new global::System.Drawing.Point(71, 213);
			this.beginButton.Name = "beginButton";
			this.beginButton.Size = new global::System.Drawing.Size(332, 26);
			this.beginButton.TabIndex = 6;
			this.beginButton.Text = "Begin";
			this.beginButton.UseVisualStyleBackColor = false;
			this.beginButton.Click += new global::System.EventHandler(this.beginButton_Click);
			this.cleanNoneButton.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.cleanNoneButton.FlatAppearance.BorderSize = 0;
			this.cleanNoneButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cleanNoneButton.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.cleanNoneButton.ForeColor = global::System.Drawing.Color.White;
			this.cleanNoneButton.Location = new global::System.Drawing.Point(113, 146);
			this.cleanNoneButton.Name = "cleanNoneButton";
			this.cleanNoneButton.Size = new global::System.Drawing.Size(120, 26);
			this.cleanNoneButton.TabIndex = 3;
			this.cleanNoneButton.Text = "None";
			this.cleanNoneButton.UseVisualStyleBackColor = false;
			this.cleanNoneButton.Click += new global::System.EventHandler(this.cleanNoneButton_Click);
			this.cleanSpoofLabel.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.cleanSpoofLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.cleanSpoofLabel.Font = new global::System.Drawing.Font("Segoe UI Light", 16f);
			this.cleanSpoofLabel.ForeColor = global::System.Drawing.Color.White;
			this.cleanSpoofLabel.Location = new global::System.Drawing.Point(0, 175);
			this.cleanSpoofLabel.Name = "cleanSpoofLabel";
			this.cleanSpoofLabel.Size = new global::System.Drawing.Size(600, 32);
			this.cleanSpoofLabel.TabIndex = 8;
			this.cleanSpoofLabel.Text = "Clean + Spoof";
			this.cleanSpoofLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.cleanSpoofLabel.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.cleanSpoofLabel_MouseDown);
			this.cleanAggressiveButton.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.cleanAggressiveButton.FlatAppearance.BorderSize = 0;
			this.cleanAggressiveButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cleanAggressiveButton.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.cleanAggressiveButton.ForeColor = global::System.Drawing.Color.White;
			this.cleanAggressiveButton.Location = new global::System.Drawing.Point(365, 146);
			this.cleanAggressiveButton.Name = "cleanAggressiveButton";
			this.cleanAggressiveButton.Size = new global::System.Drawing.Size(120, 26);
			this.cleanAggressiveButton.TabIndex = 5;
			this.cleanAggressiveButton.Text = "Aggressive";
			this.cleanAggressiveButton.UseVisualStyleBackColor = false;
			this.cleanAggressiveButton.Click += new global::System.EventHandler(this.cleanAggressiveButton_Click);
			this.spoofTempButton.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.spoofTempButton.FlatAppearance.BorderSize = 0;
			this.spoofTempButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.spoofTempButton.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.spoofTempButton.ForeColor = global::System.Drawing.Color.White;
			this.spoofTempButton.Location = new global::System.Drawing.Point(177, 80);
			this.spoofTempButton.Name = "spoofTempButton";
			this.spoofTempButton.Size = new global::System.Drawing.Size(120, 26);
			this.spoofTempButton.TabIndex = 1;
			this.spoofTempButton.Text = "Until Restart";
			this.spoofTempButton.UseVisualStyleBackColor = false;
			this.spoofTempButton.Click += new global::System.EventHandler(this.spoofTempButton_Click);
			this.spoofPermanentButton.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.spoofPermanentButton.FlatAppearance.BorderSize = 0;
			this.spoofPermanentButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.spoofPermanentButton.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.spoofPermanentButton.ForeColor = global::System.Drawing.Color.White;
			this.spoofPermanentButton.Location = new global::System.Drawing.Point(303, 80);
			this.spoofPermanentButton.Name = "spoofPermanentButton";
			this.spoofPermanentButton.Size = new global::System.Drawing.Size(120, 26);
			this.spoofPermanentButton.TabIndex = 2;
			this.spoofPermanentButton.Text = "Permanent";
			this.spoofPermanentButton.UseVisualStyleBackColor = false;
			this.spoofPermanentButton.Click += new global::System.EventHandler(this.spoofPermanentButton_Click);
			this.cleanNormalButton.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.cleanNormalButton.FlatAppearance.BorderSize = 0;
			this.cleanNormalButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.cleanNormalButton.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.cleanNormalButton.ForeColor = global::System.Drawing.Color.White;
			this.cleanNormalButton.Location = new global::System.Drawing.Point(239, 146);
			this.cleanNormalButton.Name = "cleanNormalButton";
			this.cleanNormalButton.Size = new global::System.Drawing.Size(120, 26);
			this.cleanNormalButton.TabIndex = 4;
			this.cleanNormalButton.Text = "Normal";
			this.cleanNormalButton.UseVisualStyleBackColor = false;
			this.cleanNormalButton.Click += new global::System.EventHandler(this.cleanNormalButton_Click);
			this.supportButton.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.supportButton.FlatAppearance.BorderSize = 0;
			this.supportButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.supportButton.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.supportButton.ForeColor = global::System.Drawing.Color.White;
			this.supportButton.Location = new global::System.Drawing.Point(409, 245);
			this.supportButton.Name = "supportButton";
			this.supportButton.Size = new global::System.Drawing.Size(120, 26);
			this.supportButton.TabIndex = 8;
			this.supportButton.Text = "Discord";
			this.supportButton.UseVisualStyleBackColor = false;
			this.supportButton.Click += new global::System.EventHandler(this.supportButton_Click);
			this.bgButton.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.bgButton.FlatAppearance.BorderSize = 0;
			this.bgButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.bgButton.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.bgButton.ForeColor = global::System.Drawing.Color.White;
			this.bgButton.Location = new global::System.Drawing.Point(197, 245);
			this.bgButton.Name = "bgButton";
			this.bgButton.Size = new global::System.Drawing.Size(206, 26);
			this.bgButton.TabIndex = 7;
			this.bgButton.Text = "Use Windows Background";
			this.bgButton.UseVisualStyleBackColor = false;
			this.bgButton.Click += new global::System.EventHandler(this.bgButton_Click);
			this.storeButton.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.storeButton.FlatAppearance.BorderSize = 0;
			this.storeButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.storeButton.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.storeButton.ForeColor = global::System.Drawing.Color.White;
			this.storeButton.Location = new global::System.Drawing.Point(71, 245);
			this.storeButton.Name = "storeButton";
			this.storeButton.Size = new global::System.Drawing.Size(120, 26);
			this.storeButton.TabIndex = 9;
			this.storeButton.Text = "Store";
			this.storeButton.UseVisualStyleBackColor = false;
			this.storeButton.Click += new global::System.EventHandler(this.storeButton_Click);
			this.revertButton.BackColor = global::System.Drawing.Color.FromArgb(10, 10, 10);
			this.revertButton.FlatAppearance.BorderSize = 0;
			this.revertButton.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.revertButton.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.revertButton.ForeColor = global::System.Drawing.Color.White;
			this.revertButton.Location = new global::System.Drawing.Point(409, 213);
			this.revertButton.Name = "revertButton";
			this.revertButton.Size = new global::System.Drawing.Size(120, 26);
			this.revertButton.TabIndex = 10;
			this.revertButton.Text = "Revert";
			this.revertButton.UseVisualStyleBackColor = false;
			this.revertButton.Click += new global::System.EventHandler(this.revertButton_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			this.BackgroundImage = global::CheatoClient.Properties.Resources.chadspoofer1;
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new global::System.Drawing.Size(600, 338);
			base.Controls.Add(this.revertButton);
			base.Controls.Add(this.storeButton);
			base.Controls.Add(this.bgButton);
			base.Controls.Add(this.supportButton);
			base.Controls.Add(this.spoofPermanentButton);
			base.Controls.Add(this.spoofTempButton);
			base.Controls.Add(this.cleanAggressiveButton);
			base.Controls.Add(this.cleanSpoofLabel);
			base.Controls.Add(this.cleanNormalButton);
			base.Controls.Add(this.cleanNoneButton);
			base.Controls.Add(this.beginButton);
			base.Controls.Add(this.cleaningTypeLabel);
			base.Controls.Add(this.spoofingTypeLabel);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.titleLabel);
			this.DoubleBuffered = true;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Main";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cheato Spoofer";
			base.TopMost = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
			base.ResumeLayout(false);
		}

		// Token: 0x0400000A RID: 10
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Label titleLabel;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Timer fadeInTimer;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Timer fadeOutTimer;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label spoofingTypeLabel;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Label cleaningTypeLabel;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Button beginButton;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Button cleanNoneButton;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Label cleanSpoofLabel;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Button cleanAggressiveButton;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Button spoofTempButton;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Button spoofPermanentButton;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Button cleanNormalButton;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Button supportButton;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Button bgButton;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Button storeButton;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Button revertButton;
	}
}
