namespace ZONOupdate
{
    partial class UserWelcomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserWelcomeForm));
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
            userWelcomeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            userWelcomeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            userWelcomeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            userWelcomeTableLayoutPanel.Controls.Add(userWelcomePictureBox, 1, 0);
            userWelcomeTableLayoutPanel.Controls.Add(userWelcomeLabel, 0, 1);
            userWelcomeTableLayoutPanel.Dock = DockStyle.Fill;
            userWelcomeTableLayoutPanel.Location = new Point(0, 0);
            userWelcomeTableLayoutPanel.Margin = new Padding(0);
            userWelcomeTableLayoutPanel.Name = "userWelcomeTableLayoutPanel";
            userWelcomeTableLayoutPanel.RowCount = 2;
            userWelcomeTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 72.6F));
            userWelcomeTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 27.4F));
            userWelcomeTableLayoutPanel.Size = new Size(800, 500);
            userWelcomeTableLayoutPanel.TabIndex = 0;
            // 
            // userWelcomePictureBox
            // 
            userWelcomePictureBox.Dock = DockStyle.Fill;
            userWelcomePictureBox.Image = Properties.Resources.logo;
            userWelcomePictureBox.Location = new Point(163, 3);
            userWelcomePictureBox.Name = "userWelcomePictureBox";
            userWelcomePictureBox.Size = new Size(474, 357);
            userWelcomePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            userWelcomePictureBox.TabIndex = 0;
            userWelcomePictureBox.TabStop = false;
            // 
            // userWelcomeLabel
            // 
            userWelcomeLabel.AutoSize = true;
            userWelcomeTableLayoutPanel.SetColumnSpan(userWelcomeLabel, 3);
            userWelcomeLabel.Dock = DockStyle.Fill;
            userWelcomeLabel.Location = new Point(0, 363);
            userWelcomeLabel.Margin = new Padding(0);
            userWelcomeLabel.Name = "userWelcomeLabel";
            userWelcomeLabel.Size = new Size(800, 137);
            userWelcomeLabel.TabIndex = 0;
            userWelcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userWelcomeTimer
            // 
            userWelcomeTimer.Enabled = true;
            userWelcomeTimer.Interval = 3000;
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserWelcomeForm";
            StartPosition = FormStartPosition.CenterScreen;
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