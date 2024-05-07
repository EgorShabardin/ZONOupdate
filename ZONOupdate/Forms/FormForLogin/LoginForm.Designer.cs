namespace ZONOupdate.Forms.FormForLogin
{
    partial class LoginForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            logoPictureBox = new PictureBox();
            loginFormTableLayoutPanel = new TableLayoutPanel();
            selectLanguageTableLayoutPanel = new TableLayoutPanel();
            flagPictureBox = new PictureBox();
            selectLanguageComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            registrationLabel = new Label();
            loginWithAccountVKLabel = new Label();
            loginWithAccountZONOLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            loginFormTableLayoutPanel.SuspendLayout();
            selectLanguageTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)flagPictureBox).BeginInit();
            SuspendLayout();
            // 
            // logoPictureBox
            // 
            logoPictureBox.Dock = DockStyle.Fill;
            logoPictureBox.Image = Properties.Resources.logo;
            logoPictureBox.Location = new Point(269, 3);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(414, 383);
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // loginFormTableLayoutPanel
            // 
            loginFormTableLayoutPanel.ColumnCount = 3;
            loginFormTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.94118F));
            loginFormTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.1176453F));
            loginFormTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.9411774F));
            loginFormTableLayoutPanel.Controls.Add(logoPictureBox, 1, 0);
            loginFormTableLayoutPanel.Controls.Add(selectLanguageTableLayoutPanel, 0, 0);
            loginFormTableLayoutPanel.Controls.Add(registrationLabel, 1, 4);
            loginFormTableLayoutPanel.Controls.Add(loginWithAccountVKLabel, 1, 3);
            loginFormTableLayoutPanel.Controls.Add(loginWithAccountZONOLabel, 1, 2);
            loginFormTableLayoutPanel.Dock = DockStyle.Fill;
            loginFormTableLayoutPanel.Location = new Point(0, 0);
            loginFormTableLayoutPanel.Margin = new Padding(0);
            loginFormTableLayoutPanel.Name = "loginFormTableLayoutPanel";
            loginFormTableLayoutPanel.RowCount = 6;
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 53F));
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            loginFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            loginFormTableLayoutPanel.Size = new Size(952, 734);
            loginFormTableLayoutPanel.TabIndex = 0;
            // 
            // selectLanguageTableLayoutPanel
            // 
            selectLanguageTableLayoutPanel.BackColor = Color.FromArgb(240, 240, 240);
            selectLanguageTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            selectLanguageTableLayoutPanel.ColumnCount = 2;
            selectLanguageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.2990646F));
            selectLanguageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.7009354F));
            selectLanguageTableLayoutPanel.Controls.Add(flagPictureBox, 0, 0);
            selectLanguageTableLayoutPanel.Controls.Add(selectLanguageComboBox, 1, 0);
            selectLanguageTableLayoutPanel.Location = new Point(15, 27);
            selectLanguageTableLayoutPanel.Margin = new Padding(15, 27, 24, 0);
            selectLanguageTableLayoutPanel.Name = "selectLanguageTableLayoutPanel";
            selectLanguageTableLayoutPanel.RowCount = 1;
            selectLanguageTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            selectLanguageTableLayoutPanel.Size = new Size(221, 39);
            selectLanguageTableLayoutPanel.TabIndex = 0;
            // 
            // flagPictureBox
            // 
            flagPictureBox.Dock = DockStyle.Fill;
            flagPictureBox.Location = new Point(4, 4);
            flagPictureBox.Name = "flagPictureBox";
            flagPictureBox.Size = new Size(46, 31);
            flagPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            flagPictureBox.TabIndex = 0;
            flagPictureBox.TabStop = false;
            // 
            // selectLanguageComboBox
            // 
            selectLanguageComboBox.BackColor = Color.Transparent;
            selectLanguageComboBox.BorderThickness = 0;
            selectLanguageComboBox.Cursor = Cursors.Hand;
            selectLanguageComboBox.CustomizableEdges = customizableEdges1;
            selectLanguageComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            selectLanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectLanguageComboBox.FillColor = SystemColors.ButtonFace;
            selectLanguageComboBox.FocusedColor = Color.FromArgb(94, 148, 255);
            selectLanguageComboBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            selectLanguageComboBox.Font = new Font("Segoe UI", 10F);
            selectLanguageComboBox.ForeColor = SystemColors.WindowText;
            selectLanguageComboBox.ItemHeight = 30;
            selectLanguageComboBox.Location = new Point(54, 1);
            selectLanguageComboBox.Margin = new Padding(0);
            selectLanguageComboBox.Name = "selectLanguageComboBox";
            selectLanguageComboBox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            selectLanguageComboBox.Size = new Size(166, 36);
            selectLanguageComboBox.TabIndex = 0;
            selectLanguageComboBox.TabStop = false;
            selectLanguageComboBox.TextAlign = HorizontalAlignment.Center;
            selectLanguageComboBox.SelectedIndexChanged += SelectLanguageComboBoxSelectedIndexChanged;
            // 
            // registrationLabel
            // 
            registrationLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            registrationLabel.AutoSize = true;
            registrationLabel.Cursor = Cursors.Hand;
            registrationLabel.ForeColor = Color.FromArgb(0, 166, 253);
            registrationLabel.Location = new Point(269, 612);
            registrationLabel.Margin = new Padding(3);
            registrationLabel.Name = "registrationLabel";
            registrationLabel.Size = new Size(414, 20);
            registrationLabel.TabIndex = 0;
            registrationLabel.TextAlign = ContentAlignment.MiddleCenter;
            registrationLabel.MouseDown += RegistrationLabelMouseDown;
            registrationLabel.MouseLeave += LoginOrRegistrationLabelsMouseLeave;
            registrationLabel.MouseMove += LoginOrRegistrationLabelsMouseMove;
            // 
            // loginWithAccountVKLabel
            // 
            loginWithAccountVKLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            loginWithAccountVKLabel.AutoSize = true;
            loginWithAccountVKLabel.Cursor = Cursors.Hand;
            loginWithAccountVKLabel.ForeColor = Color.FromArgb(0, 166, 253);
            loginWithAccountVKLabel.Location = new Point(269, 539);
            loginWithAccountVKLabel.Margin = new Padding(3);
            loginWithAccountVKLabel.Name = "loginWithAccountVKLabel";
            loginWithAccountVKLabel.Size = new Size(414, 20);
            loginWithAccountVKLabel.TabIndex = 0;
            loginWithAccountVKLabel.TextAlign = ContentAlignment.MiddleCenter;
            loginWithAccountVKLabel.MouseDown += LoginWithAccountVKMouseDown;
            loginWithAccountVKLabel.MouseLeave += LoginOrRegistrationLabelsMouseLeave;
            loginWithAccountVKLabel.MouseMove += LoginOrRegistrationLabelsMouseMove;
            // 
            // loginWithAccountZONOLabel
            // 
            loginWithAccountZONOLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            loginWithAccountZONOLabel.AutoSize = true;
            loginWithAccountZONOLabel.Cursor = Cursors.Hand;
            loginWithAccountZONOLabel.ForeColor = Color.FromArgb(0, 166, 253);
            loginWithAccountZONOLabel.Location = new Point(269, 466);
            loginWithAccountZONOLabel.Margin = new Padding(3);
            loginWithAccountZONOLabel.Name = "loginWithAccountZONOLabel";
            loginWithAccountZONOLabel.Size = new Size(414, 20);
            loginWithAccountZONOLabel.TabIndex = 0;
            loginWithAccountZONOLabel.TextAlign = ContentAlignment.MiddleCenter;
            loginWithAccountZONOLabel.MouseDown += LoginWithAccountZONOLabelMouseDown;
            loginWithAccountZONOLabel.MouseLeave += LoginOrRegistrationLabelsMouseLeave;
            loginWithAccountZONOLabel.MouseMove += LoginOrRegistrationLabelsMouseMove;
            // 
            // LoginForm
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.FromArgb(178, 242, 196);
            ClientSize = new Size(952, 734);
            Controls.Add(loginFormTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            Icon = Properties.Resources.logoIcon;
            KeyPreview = true;
            MinimumSize = new Size(970, 780);
            Name = "LoginForm";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Load += LoginFormLoad;
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            loginFormTableLayoutPanel.ResumeLayout(false);
            loginFormTableLayoutPanel.PerformLayout();
            selectLanguageTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)flagPictureBox).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private PictureBox logoPictureBox;
        private TableLayoutPanel loginFormTableLayoutPanel;
        private TableLayoutPanel selectLanguageTableLayoutPanel;
        private PictureBox flagPictureBox;
        private Label loginWithAccountZONOLabel;
        private Label loginWithAccountVKLabel;
        private Label registrationLabel;
        private Guna.UI2.WinForms.Guna2ComboBox selectLanguageComboBox;
    }
}