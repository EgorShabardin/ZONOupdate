namespace ZONOupdate.Forms.FormForInputBox
{
    partial class InputBoxForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBoxForm));
            inputBoxTableLayoutPanel = new TableLayoutPanel();
            inputBoxTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            inputBoxSaveButton = new Guna.UI2.WinForms.Guna2Button();
            inputBoxTitleLabel = new Label();
            inputBoxTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // inputBoxTableLayoutPanel
            // 
            inputBoxTableLayoutPanel.ColumnCount = 1;
            inputBoxTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            inputBoxTableLayoutPanel.Controls.Add(inputBoxTextBox, 0, 1);
            inputBoxTableLayoutPanel.Controls.Add(inputBoxSaveButton, 0, 2);
            inputBoxTableLayoutPanel.Controls.Add(inputBoxTitleLabel, 0, 0);
            inputBoxTableLayoutPanel.Dock = DockStyle.Fill;
            inputBoxTableLayoutPanel.Location = new Point(0, 0);
            inputBoxTableLayoutPanel.Margin = new Padding(0);
            inputBoxTableLayoutPanel.Name = "inputBoxTableLayoutPanel";
            inputBoxTableLayoutPanel.RowCount = 3;
            inputBoxTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            inputBoxTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            inputBoxTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            inputBoxTableLayoutPanel.Size = new Size(506, 216);
            inputBoxTableLayoutPanel.TabIndex = 0;
            inputBoxTableLayoutPanel.TabStop = true;
            // 
            // inputBoxTextBox
            // 
            inputBoxTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inputBoxTextBox.BorderColor = Color.Black;
            inputBoxTextBox.BorderRadius = 8;
            inputBoxTextBox.Cursor = Cursors.IBeam;
            inputBoxTextBox.CustomizableEdges = customizableEdges1;
            inputBoxTextBox.DefaultText = "";
            inputBoxTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            inputBoxTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            inputBoxTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            inputBoxTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            inputBoxTextBox.FillColor = SystemColors.ButtonFace;
            inputBoxTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            inputBoxTextBox.Font = new Font("Segoe UI", 9F);
            inputBoxTextBox.ForeColor = SystemColors.WindowText;
            inputBoxTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            inputBoxTextBox.Location = new Point(65, 85);
            inputBoxTextBox.Margin = new Padding(65, 0, 65, 0);
            inputBoxTextBox.MaxLength = 100;
            inputBoxTextBox.Name = "inputBoxTextBox";
            inputBoxTextBox.PasswordChar = '\0';
            inputBoxTextBox.PlaceholderText = "";
            inputBoxTextBox.SelectedText = "";
            inputBoxTextBox.ShadowDecoration.CustomizableEdges = customizableEdges2;
            inputBoxTextBox.Size = new Size(376, 43);
            inputBoxTextBox.TabIndex = 0;
            inputBoxTextBox.TabStop = true;
            inputBoxTextBox.TextOffset = new Point(5, 0);
            // 
            // inputBoxSaveButton
            // 
            inputBoxSaveButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inputBoxSaveButton.BorderRadius = 15;
            inputBoxSaveButton.Cursor = Cursors.Hand;
            inputBoxSaveButton.CustomizableEdges = customizableEdges3;
            inputBoxSaveButton.DisabledState.BorderColor = Color.DarkGray;
            inputBoxSaveButton.DisabledState.CustomBorderColor = Color.DarkGray;
            inputBoxSaveButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            inputBoxSaveButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            inputBoxSaveButton.FillColor = Color.FromArgb(0, 166, 253);
            inputBoxSaveButton.Font = new Font("Segoe UI", 9F);
            inputBoxSaveButton.ForeColor = SystemColors.Window;
            inputBoxSaveButton.Location = new Point(140, 153);
            inputBoxSaveButton.Margin = new Padding(140, 0, 140, 0);
            inputBoxSaveButton.Name = "inputBoxSaveButton";
            inputBoxSaveButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            inputBoxSaveButton.Size = new Size(226, 51);
            inputBoxSaveButton.TabIndex = 0;
            inputBoxSaveButton.TabStop = true;
            inputBoxSaveButton.MouseDown += InputBoxButtonMouseDown;
            // 
            // inputBoxTitleLabel
            // 
            inputBoxTitleLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            inputBoxTitleLabel.AutoEllipsis = true;
            inputBoxTitleLabel.AutoSize = true;
            inputBoxTitleLabel.Location = new Point(18, 25);
            inputBoxTitleLabel.Margin = new Padding(18, 0, 18, 0);
            inputBoxTitleLabel.Name = "inputBoxTitleLabel";
            inputBoxTitleLabel.Size = new Size(470, 20);
            inputBoxTitleLabel.TabIndex = 0;
            inputBoxTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InputBoxForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(506, 216);
            Controls.Add(inputBoxTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = Properties.Resources.logoIcon;
            MaximizeBox = false;
            Name = "InputBoxForm";
            StartPosition = FormStartPosition.CenterScreen;
            inputBoxTableLayoutPanel.ResumeLayout(false);
            inputBoxTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private TableLayoutPanel inputBoxTableLayoutPanel;
        private Label inputBoxTitleLabel;
        private Guna.UI2.WinForms.Guna2Button inputBoxSaveButton;
        private Guna.UI2.WinForms.Guna2TextBox inputBoxTextBox;
    }
}