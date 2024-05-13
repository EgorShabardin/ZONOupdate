namespace ZONOupdate.Forms.FormForWelcomingUser
{
    partial class UserWelcomeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            userWelcomeTableLayoutPanel = new TableLayoutPanel();
            userWelcomePictureBox = new PictureBox();
            userWelcomeLabel = new Label();
            userWelcomeTimer = new System.Windows.Forms.Timer(components);
            userWelcomeTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userWelcomePictureBox).BeginInit();
            SuspendLayout();
            // 
            // userWelcomeTableLayoutPanel
            // 
            userWelcomeTableLayoutPanel.ColumnCount = 3;
            userWelcomeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            userWelcomeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            userWelcomeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            userWelcomeTableLayoutPanel.Controls.Add(userWelcomePictureBox, 1, 0);
            userWelcomeTableLayoutPanel.Controls.Add(userWelcomeLabel, 0, 1);
            userWelcomeTableLayoutPanel.Dock = DockStyle.Fill;
            userWelcomeTableLayoutPanel.Location = new Point(0, 0);
            userWelcomeTableLayoutPanel.Margin = new Padding(0);
            userWelcomeTableLayoutPanel.Name = "userWelcomeTableLayoutPanel";
            userWelcomeTableLayoutPanel.RowCount = 2;
            userWelcomeTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            userWelcomeTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            userWelcomeTableLayoutPanel.Size = new Size(800, 500);
            userWelcomeTableLayoutPanel.TabIndex = 0;
            userWelcomeTableLayoutPanel.TabStop = true;
            // 
            // userWelcomePictureBox
            // 
            userWelcomePictureBox.Dock = DockStyle.Fill;
            userWelcomePictureBox.Image = Properties.Resources.logo;
            userWelcomePictureBox.Location = new Point(123, 35);
            userWelcomePictureBox.Margin = new Padding(3, 35, 3, 3);
            userWelcomePictureBox.Name = "userWelcomePictureBox";
            userWelcomePictureBox.Size = new Size(554, 337);
            userWelcomePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            userWelcomePictureBox.TabIndex = 0;
            // 
            // userWelcomeLabel
            // 
            userWelcomeLabel.AutoEllipsis = true;
            userWelcomeLabel.AutoSize = true;
            userWelcomeTableLayoutPanel.SetColumnSpan(userWelcomeLabel, 3);
            userWelcomeLabel.Dock = DockStyle.Fill;
            userWelcomeLabel.Location = new Point(0, 375);
            userWelcomeLabel.Margin = new Padding(0);
            userWelcomeLabel.Name = "userWelcomeLabel";
            userWelcomeLabel.Size = new Size(800, 125);
            userWelcomeLabel.TabIndex = 0;
            userWelcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userWelcomeTimer
            // 
            userWelcomeTimer.Interval = 2000;
            userWelcomeTimer.Tick += UserWelcomeTimerTick;
            // 
            // UserWelcomeForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 242, 196);
            ClientSize = new Size(800, 500);
            Controls.Add(userWelcomeTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = Properties.Resources.logoIcon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserWelcomeForm";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Load += UserWelcomeFormLoad;
            userWelcomeTableLayoutPanel.ResumeLayout(false);
            userWelcomeTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)userWelcomePictureBox).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private TableLayoutPanel userWelcomeTableLayoutPanel;
        private PictureBox userWelcomePictureBox;
        private Label userWelcomeLabel;
        private System.Windows.Forms.Timer userWelcomeTimer;
    }
}