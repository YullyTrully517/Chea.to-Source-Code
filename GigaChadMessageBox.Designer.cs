namespace CheatoClient
{
	// Token: 0x02000010 RID: 16
	public partial class GigaChadMessageBox : global::System.Windows.Forms.Form
	{
		// Token: 0x06000096 RID: 150 RVA: 0x00008008 File Offset: 0x00006208
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00008040 File Offset: 0x00006240
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::CheatoClient.GigaChadMessageBox));
			this.button = new global::System.Windows.Forms.Button();
			this.textBox = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.button.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.button.BackColor = global::System.Drawing.Color.WhiteSmoke;
			this.button.FlatAppearance.BorderSize = 0;
			this.button.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.button.Location = new global::System.Drawing.Point(8, 160);
			this.button.Name = "button";
			this.button.Size = new global::System.Drawing.Size(435, 30);
			this.button.TabIndex = 1;
			this.button.Text = "OK";
			this.button.UseVisualStyleBackColor = false;
			this.button.Click += new global::System.EventHandler(this.button_Click);
			this.textBox.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox.BackColor = global::System.Drawing.Color.White;
			this.textBox.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.textBox.Font = new global::System.Drawing.Font("Segoe UI", 12f);
			this.textBox.Location = new global::System.Drawing.Point(0, 0);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.ReadOnly = true;
			this.textBox.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.textBox.Size = new global::System.Drawing.Size(450, 150);
			this.textBox.TabIndex = 2;
			this.textBox.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox.Click += new global::System.EventHandler(this.textBox_Click);
			this.textBox.TextChanged += new global::System.EventHandler(this.textBox_TextChanged);
			this.textBox.Enter += new global::System.EventHandler(this.textBox_Enter);
			this.textBox.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
			this.textBox.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.textBox_MouseMove);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(450, 200);
			base.Controls.Add(this.textBox);
			base.Controls.Add(this.button);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "GigaChadMessageBox";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			base.TopMost = true;
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.GigaChadMessageBox_MouseDown);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000041 RID: 65
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.Button button;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.TextBox textBox;
	}
}
