namespace ZONOupdate.Forms.FormForCreationNewCollection
{
    partial class NewCollectionCreationForm
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
            informationLabel = new Label();
            addNewCollectionTableLayoutPanel = new TableLayoutPanel();
            addNewCollectionButton = new Guna.UI2.WinForms.Guna2Button();
            collectionNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            addNewCollectionTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // informationLabel
            // 
            informationLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            informationLabel.AutoEllipsis = true;
            informationLabel.AutoSize = true;
            informationLabel.Location = new Point(25, 28);
            informationLabel.Margin = new Padding(25, 28, 25, 0);
            informationLabel.Name = "informationLabel";
            informationLabel.Size = new Size(414, 20);
            informationLabel.TabIndex = 0;
            informationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addNewCollectionTableLayoutPanel
            // 
            addNewCollectionTableLayoutPanel.ColumnCount = 1;
            addNewCollectionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            addNewCollectionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 21F));
            addNewCollectionTableLayoutPanel.Controls.Add(addNewCollectionButton, 0, 2);
            addNewCollectionTableLayoutPanel.Controls.Add(informationLabel, 0, 0);
            addNewCollectionTableLayoutPanel.Controls.Add(collectionNameTextBox, 0, 1);
            addNewCollectionTableLayoutPanel.Dock = DockStyle.Fill;
            addNewCollectionTableLayoutPanel.Location = new Point(0, 0);
            addNewCollectionTableLayoutPanel.Margin = new Padding(0);
            addNewCollectionTableLayoutPanel.Name = "addNewCollectionTableLayoutPanel";
            addNewCollectionTableLayoutPanel.RowCount = 3;
            addNewCollectionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            addNewCollectionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            addNewCollectionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            addNewCollectionTableLayoutPanel.Size = new Size(464, 245);
            addNewCollectionTableLayoutPanel.TabIndex = 0;
            addNewCollectionTableLayoutPanel.TabStop = true;
            // 
            // addNewCollectionButton
            // 
            addNewCollectionButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            addNewCollectionButton.BorderColor = SystemColors.WindowText;
            addNewCollectionButton.BorderRadius = 15;
            addNewCollectionButton.Cursor = Cursors.Hand;
            addNewCollectionButton.CustomizableEdges = customizableEdges1;
            addNewCollectionButton.DisabledState.BorderColor = Color.DarkGray;
            addNewCollectionButton.DisabledState.CustomBorderColor = Color.DarkGray;
            addNewCollectionButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            addNewCollectionButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            addNewCollectionButton.FillColor = Color.FromArgb(0, 166, 253);
            addNewCollectionButton.ForeColor = SystemColors.Window;
            addNewCollectionButton.Location = new Point(115, 172);
            addNewCollectionButton.Margin = new Padding(115, 0, 115, 10);
            addNewCollectionButton.Name = "addNewCollectionButton";
            addNewCollectionButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            addNewCollectionButton.Size = new Size(234, 52);
            addNewCollectionButton.TabIndex = 0;
            addNewCollectionButton.MouseDown += AddNewCollectionButtonMouseDown;
            // 
            // collectionNameTextBox
            // 
            collectionNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            collectionNameTextBox.BorderColor = SystemColors.WindowText;
            collectionNameTextBox.BorderRadius = 8;
            collectionNameTextBox.Cursor = Cursors.IBeam;
            collectionNameTextBox.CustomizableEdges = customizableEdges3;
            collectionNameTextBox.DefaultText = "";
            collectionNameTextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            collectionNameTextBox.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            collectionNameTextBox.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            collectionNameTextBox.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            collectionNameTextBox.FillColor = SystemColors.ButtonFace;
            collectionNameTextBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            collectionNameTextBox.Font = new Font("Segoe UI", 9F);
            collectionNameTextBox.ForeColor = SystemColors.WindowText;
            collectionNameTextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            collectionNameTextBox.Location = new Point(58, 97);
            collectionNameTextBox.Margin = new Padding(58, 0, 58, 0);
            collectionNameTextBox.MaxLength = 100;
            collectionNameTextBox.Name = "collectionNameTextBox";
            collectionNameTextBox.PasswordChar = '\0';
            collectionNameTextBox.PlaceholderText = "";
            collectionNameTextBox.SelectedText = "";
            collectionNameTextBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            collectionNameTextBox.Size = new Size(348, 49);
            collectionNameTextBox.TabIndex = 0;
            collectionNameTextBox.TextOffset = new Point(5, 0);
            // 
            // NewCollectionCreationForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(464, 245);
            Controls.Add(addNewCollectionTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = Properties.Resources.logoIcon;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "NewCollectionCreationForm";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Load += NewCollectionCreationFormLoad;
            addNewCollectionTableLayoutPanel.ResumeLayout(false);
            addNewCollectionTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private Label informationLabel;
        private TableLayoutPanel addNewCollectionTableLayoutPanel;
        private Guna.UI2.WinForms.Guna2TextBox collectionNameTextBox;
        private Guna.UI2.WinForms.Guna2Button addNewCollectionButton;
    }
}