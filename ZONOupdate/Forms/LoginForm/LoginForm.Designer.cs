namespace ZONOupdate.Forms
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
            logoPictureBox = new PictureBox();
            loginFormTableLayoutPanel = new TableLayoutPanel();
            selectLanguageTableLayoutPanel = new TableLayoutPanel();
            selectLanguageComboBox = new ComboBox();
            flagPictureBox = new PictureBox();
            loginWithAccountZONOLabel = new Label();
            loginWithAccountVKLabel = new Label();
            loginWithAccountYandexLabel = new Label();
            registrationLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            loginFormTableLayoutPanel.SuspendLayout();
            selectLanguageTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)flagPictureBox).BeginInit();
            SuspendLayout();
            // 
            // logoPictureBox
            // 
            logoPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logoPictureBox.Image = Properties.Resources.logo;
            logoPictureBox.Location = new Point(260, 0);
            logoPictureBox.Margin = new Padding(0);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(411, 364);
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
            loginFormTableLayoutPanel.Controls.Add(loginWithAccountZONOLabel, 1, 1);
            loginFormTableLayoutPanel.Controls.Add(loginWithAccountVKLabel, 1, 2);
            loginFormTableLayoutPanel.Controls.Add(loginWithAccountYandexLabel, 1, 3);
            loginFormTableLayoutPanel.Controls.Add(registrationLabel, 1, 4);
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
            loginFormTableLayoutPanel.Size = new Size(932, 687);
            loginFormTableLayoutPanel.TabIndex = 0;
            // 
            // selectLanguageTableLayoutPanel
            // 
            selectLanguageTableLayoutPanel.Anchor = AnchorStyles.Top;
            selectLanguageTableLayoutPanel.BackColor = Color.FromArgb(240, 240, 240);
            selectLanguageTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            selectLanguageTableLayoutPanel.ColumnCount = 2;
            selectLanguageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.2990646F));
            selectLanguageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.7009354F));
            selectLanguageTableLayoutPanel.Controls.Add(selectLanguageComboBox, 1, 0);
            selectLanguageTableLayoutPanel.Controls.Add(flagPictureBox, 0, 0);
            selectLanguageTableLayoutPanel.Location = new Point(15, 27);
            selectLanguageTableLayoutPanel.Margin = new Padding(15, 27, 24, 0);
            selectLanguageTableLayoutPanel.Name = "selectLanguageTableLayoutPanel";
            selectLanguageTableLayoutPanel.RowCount = 1;
            selectLanguageTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            selectLanguageTableLayoutPanel.Size = new Size(221, 39);
            selectLanguageTableLayoutPanel.TabIndex = 0;
            // 
            // selectLanguageComboBox
            // 
            selectLanguageComboBox.BackColor = Color.FromArgb(240, 240, 240);
            selectLanguageComboBox.Cursor = Cursors.Hand;
            selectLanguageComboBox.Dock = DockStyle.Fill;
            selectLanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectLanguageComboBox.FlatStyle = FlatStyle.Popup;
            selectLanguageComboBox.FormattingEnabled = true;
            selectLanguageComboBox.Location = new Point(58, 5);
            selectLanguageComboBox.Margin = new Padding(4, 4, 4, 0);
            selectLanguageComboBox.Name = "selectLanguageComboBox";
            selectLanguageComboBox.Size = new Size(158, 28);
            selectLanguageComboBox.TabIndex = 0;
            selectLanguageComboBox.TabStop = false;
            selectLanguageComboBox.SelectedIndexChanged += SelectLanguageComboBoxSelectedIndexChanged;
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
            // loginWithAccountZONOLabel
            // 
            loginWithAccountZONOLabel.Anchor = AnchorStyles.Bottom;
            loginWithAccountZONOLabel.AutoSize = true;
            loginWithAccountZONOLabel.Cursor = Cursors.Hand;
            loginWithAccountZONOLabel.ForeColor = Color.FromArgb(0, 166, 253);
            loginWithAccountZONOLabel.Location = new Point(465, 392);
            loginWithAccountZONOLabel.Margin = new Padding(0);
            loginWithAccountZONOLabel.Name = "loginWithAccountZONOLabel";
            loginWithAccountZONOLabel.Size = new Size(0, 20);
            loginWithAccountZONOLabel.TabIndex = 0;
            loginWithAccountZONOLabel.TextAlign = ContentAlignment.MiddleCenter;
            loginWithAccountZONOLabel.Click += LoginWithAccountZONOLabelClick;
            // 
            // loginWithAccountVKLabel
            // 
            loginWithAccountVKLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            loginWithAccountVKLabel.AutoSize = true;
            loginWithAccountVKLabel.Cursor = Cursors.Hand;
            loginWithAccountVKLabel.ForeColor = Color.FromArgb(0, 166, 253);
            loginWithAccountVKLabel.Location = new Point(263, 436);
            loginWithAccountVKLabel.Name = "loginWithAccountVKLabel";
            loginWithAccountVKLabel.Size = new Size(405, 20);
            loginWithAccountVKLabel.TabIndex = 2;
            loginWithAccountVKLabel.TextAlign = ContentAlignment.MiddleCenter;
            loginWithAccountVKLabel.Click += LoginWithAccountVKClick;
            // 
            // loginWithAccountYandexLabel
            // 
            loginWithAccountYandexLabel.Anchor = AnchorStyles.Bottom;
            loginWithAccountYandexLabel.AutoSize = true;
            loginWithAccountYandexLabel.Cursor = Cursors.Hand;
            loginWithAccountYandexLabel.ForeColor = Color.FromArgb(0, 166, 253);
            loginWithAccountYandexLabel.Location = new Point(465, 528);
            loginWithAccountYandexLabel.Name = "loginWithAccountYandexLabel";
            loginWithAccountYandexLabel.Size = new Size(0, 20);
            loginWithAccountYandexLabel.TabIndex = 3;
            loginWithAccountYandexLabel.TextAlign = ContentAlignment.MiddleCenter;
            loginWithAccountYandexLabel.Click += LoginWithAccountYandexClick;
            // 
            // registrationLabel
            // 
            registrationLabel.Anchor = AnchorStyles.Bottom;
            registrationLabel.AutoSize = true;
            registrationLabel.Cursor = Cursors.Hand;
            registrationLabel.ForeColor = Color.FromArgb(0, 166, 253);
            registrationLabel.Location = new Point(465, 596);
            registrationLabel.Name = "registrationLabel";
            registrationLabel.Size = new Size(0, 20);
            registrationLabel.TabIndex = 4;
            registrationLabel.TextAlign = ContentAlignment.MiddleCenter;
            registrationLabel.Click += RegistrationLabelClick;
            // 
            // LoginForm
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.FromArgb(178, 242, 196);
            ClientSize = new Size(932, 687);
            Controls.Add(loginFormTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            Icon = Properties.Resources.logoIcon;
            KeyPreview = true;
            MinimumSize = new Size(950, 734);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            SizeChanged += LoginForm_SizeChanged;
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
        private ComboBox selectLanguageComboBox;
        private TableLayoutPanel selectLanguageTableLayoutPanel;
        private PictureBox flagPictureBox;
        private Label loginWithAccountZONOLabel;
        private Label loginWithAccountVKLabel;
        private Label loginWithAccountYandexLabel;
        private Label registrationLabel;
    }
}