namespace ZONOupdate.Forms.FormForProductCard
{
    partial class ProductCardForm
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
            productInformationTableLayoutPanel = new TableLayoutPanel();
            saveMarkButton = new Guna.UI2.WinForms.Guna2Button();
            productNameLabel = new Label();
            productPhotoPictureBox = new PictureBox();
            productInfoTableLayoutPanel = new TableLayoutPanel();
            productDescriptionLabel = new Label();
            productTypeLabelTitle = new Label();
            productManufacturerLabelTitle = new Label();
            productYearOfProductionLabelTitle = new Label();
            productColorLabelTitle = new Label();
            productPriceLabelTitle = new Label();
            productTypeLabelInfo = new Label();
            productManufacturerLabelInfo = new Label();
            productYearOfProductionLabelInfo = new Label();
            productColorLabelInfo = new Label();
            productPriceLabelInfo = new Label();
            markTitle = new Label();
            markComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            productInformationTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productPhotoPictureBox).BeginInit();
            productInfoTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // productInformationTableLayoutPanel
            // 
            productInformationTableLayoutPanel.ColumnCount = 1;
            productInformationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            productInformationTableLayoutPanel.Controls.Add(saveMarkButton, 0, 3);
            productInformationTableLayoutPanel.Controls.Add(productNameLabel, 0, 0);
            productInformationTableLayoutPanel.Controls.Add(productPhotoPictureBox, 0, 1);
            productInformationTableLayoutPanel.Controls.Add(productInfoTableLayoutPanel, 0, 2);
            productInformationTableLayoutPanel.Dock = DockStyle.Fill;
            productInformationTableLayoutPanel.Location = new Point(0, 0);
            productInformationTableLayoutPanel.Margin = new Padding(0);
            productInformationTableLayoutPanel.Name = "productInformationTableLayoutPanel";
            productInformationTableLayoutPanel.RowCount = 4;
            productInformationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9.523809F));
            productInformationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            productInformationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 47.61905F));
            productInformationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9.523809F));
            productInformationTableLayoutPanel.Size = new Size(554, 783);
            productInformationTableLayoutPanel.TabIndex = 0;
            productInformationTableLayoutPanel.TabStop = true;
            // 
            // saveMarkButton
            // 
            saveMarkButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            saveMarkButton.BorderRadius = 15;
            saveMarkButton.Cursor = Cursors.Hand;
            saveMarkButton.CustomizableEdges = customizableEdges1;
            saveMarkButton.DisabledState.BorderColor = Color.DarkGray;
            saveMarkButton.DisabledState.CustomBorderColor = Color.DarkGray;
            saveMarkButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            saveMarkButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            saveMarkButton.FillColor = Color.FromArgb(0, 166, 253);
            saveMarkButton.Font = new Font("Segoe UI", 9F);
            saveMarkButton.ForeColor = SystemColors.Window;
            saveMarkButton.Location = new Point(150, 713);
            saveMarkButton.Margin = new Padding(150, 0, 150, 10);
            saveMarkButton.Name = "saveMarkButton";
            saveMarkButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            saveMarkButton.Size = new Size(254, 52);
            saveMarkButton.TabIndex = 0;
            saveMarkButton.MouseDown += SaveMarkButtonMouseDown;
            // 
            // productNameLabel
            // 
            productNameLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productNameLabel.AutoEllipsis = true;
            productNameLabel.AutoSize = true;
            productNameLabel.Location = new Point(30, 27);
            productNameLabel.Margin = new Padding(30, 0, 30, 0);
            productNameLabel.Name = "productNameLabel";
            productNameLabel.Size = new Size(494, 20);
            productNameLabel.TabIndex = 0;
            productNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // productPhotoPictureBox
            // 
            productPhotoPictureBox.Dock = DockStyle.Fill;
            productPhotoPictureBox.Location = new Point(45, 74);
            productPhotoPictureBox.Margin = new Padding(45, 0, 45, 15);
            productPhotoPictureBox.Name = "productPhotoPictureBox";
            productPhotoPictureBox.Size = new Size(464, 245);
            productPhotoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            productPhotoPictureBox.TabIndex = 0;
            productPhotoPictureBox.TabStop = false;
            // 
            // productInfoTableLayoutPanel
            // 
            productInfoTableLayoutPanel.ColumnCount = 2;
            productInfoTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            productInfoTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            productInfoTableLayoutPanel.Controls.Add(productDescriptionLabel, 0, 0);
            productInfoTableLayoutPanel.Controls.Add(productTypeLabelTitle, 0, 1);
            productInfoTableLayoutPanel.Controls.Add(productManufacturerLabelTitle, 0, 2);
            productInfoTableLayoutPanel.Controls.Add(productYearOfProductionLabelTitle, 0, 3);
            productInfoTableLayoutPanel.Controls.Add(productColorLabelTitle, 0, 4);
            productInfoTableLayoutPanel.Controls.Add(productPriceLabelTitle, 0, 5);
            productInfoTableLayoutPanel.Controls.Add(productTypeLabelInfo, 1, 1);
            productInfoTableLayoutPanel.Controls.Add(productManufacturerLabelInfo, 1, 2);
            productInfoTableLayoutPanel.Controls.Add(productYearOfProductionLabelInfo, 1, 3);
            productInfoTableLayoutPanel.Controls.Add(productColorLabelInfo, 1, 4);
            productInfoTableLayoutPanel.Controls.Add(productPriceLabelInfo, 1, 5);
            productInfoTableLayoutPanel.Controls.Add(markTitle, 0, 6);
            productInfoTableLayoutPanel.Controls.Add(markComboBox, 1, 6);
            productInfoTableLayoutPanel.Dock = DockStyle.Fill;
            productInfoTableLayoutPanel.Location = new Point(0, 334);
            productInfoTableLayoutPanel.Margin = new Padding(0);
            productInfoTableLayoutPanel.Name = "productInfoTableLayoutPanel";
            productInfoTableLayoutPanel.RowCount = 7;
            productInfoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0039978F));
            productInfoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3326654F));
            productInfoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3326654F));
            productInfoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3326654F));
            productInfoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3326654F));
            productInfoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3326654F));
            productInfoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3326654F));
            productInfoTableLayoutPanel.Size = new Size(554, 372);
            productInfoTableLayoutPanel.TabIndex = 0;
            // 
            // productDescriptionLabel
            // 
            productDescriptionLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productDescriptionLabel.AutoEllipsis = true;
            productDescriptionLabel.AutoSize = true;
            productInfoTableLayoutPanel.SetColumnSpan(productDescriptionLabel, 2);
            productDescriptionLabel.Location = new Point(35, 27);
            productDescriptionLabel.Margin = new Padding(35, 0, 35, 0);
            productDescriptionLabel.Name = "productDescriptionLabel";
            productDescriptionLabel.Size = new Size(484, 20);
            productDescriptionLabel.TabIndex = 0;
            // 
            // productTypeLabelTitle
            // 
            productTypeLabelTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productTypeLabelTitle.AutoEllipsis = true;
            productTypeLabelTitle.AutoSize = true;
            productTypeLabelTitle.Location = new Point(35, 88);
            productTypeLabelTitle.Margin = new Padding(35, 0, 0, 0);
            productTypeLabelTitle.Name = "productTypeLabelTitle";
            productTypeLabelTitle.Size = new Size(242, 20);
            productTypeLabelTitle.TabIndex = 0;
            productTypeLabelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productManufacturerLabelTitle
            // 
            productManufacturerLabelTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productManufacturerLabelTitle.AutoEllipsis = true;
            productManufacturerLabelTitle.AutoSize = true;
            productManufacturerLabelTitle.Location = new Point(35, 137);
            productManufacturerLabelTitle.Margin = new Padding(35, 0, 0, 0);
            productManufacturerLabelTitle.Name = "productManufacturerLabelTitle";
            productManufacturerLabelTitle.Size = new Size(242, 20);
            productManufacturerLabelTitle.TabIndex = 0;
            productManufacturerLabelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productYearOfProductionLabelTitle
            // 
            productYearOfProductionLabelTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productYearOfProductionLabelTitle.AutoEllipsis = true;
            productYearOfProductionLabelTitle.AutoSize = true;
            productYearOfProductionLabelTitle.Location = new Point(35, 186);
            productYearOfProductionLabelTitle.Margin = new Padding(35, 0, 0, 0);
            productYearOfProductionLabelTitle.Name = "productYearOfProductionLabelTitle";
            productYearOfProductionLabelTitle.Size = new Size(242, 20);
            productYearOfProductionLabelTitle.TabIndex = 0;
            productYearOfProductionLabelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productColorLabelTitle
            // 
            productColorLabelTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productColorLabelTitle.AutoEllipsis = true;
            productColorLabelTitle.AutoSize = true;
            productColorLabelTitle.Location = new Point(35, 235);
            productColorLabelTitle.Margin = new Padding(35, 0, 0, 0);
            productColorLabelTitle.Name = "productColorLabelTitle";
            productColorLabelTitle.Size = new Size(242, 20);
            productColorLabelTitle.TabIndex = 0;
            productColorLabelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productPriceLabelTitle
            // 
            productPriceLabelTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productPriceLabelTitle.AutoEllipsis = true;
            productPriceLabelTitle.AutoSize = true;
            productPriceLabelTitle.Location = new Point(35, 284);
            productPriceLabelTitle.Margin = new Padding(35, 0, 0, 0);
            productPriceLabelTitle.Name = "productPriceLabelTitle";
            productPriceLabelTitle.Size = new Size(242, 20);
            productPriceLabelTitle.TabIndex = 0;
            productPriceLabelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productTypeLabelInfo
            // 
            productTypeLabelInfo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productTypeLabelInfo.AutoEllipsis = true;
            productTypeLabelInfo.AutoSize = true;
            productTypeLabelInfo.Location = new Point(298, 88);
            productTypeLabelInfo.Margin = new Padding(21, 0, 0, 0);
            productTypeLabelInfo.Name = "productTypeLabelInfo";
            productTypeLabelInfo.Size = new Size(256, 20);
            productTypeLabelInfo.TabIndex = 0;
            productTypeLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productManufacturerLabelInfo
            // 
            productManufacturerLabelInfo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productManufacturerLabelInfo.AutoEllipsis = true;
            productManufacturerLabelInfo.AutoSize = true;
            productManufacturerLabelInfo.Location = new Point(298, 137);
            productManufacturerLabelInfo.Margin = new Padding(21, 0, 0, 0);
            productManufacturerLabelInfo.Name = "productManufacturerLabelInfo";
            productManufacturerLabelInfo.Size = new Size(256, 20);
            productManufacturerLabelInfo.TabIndex = 0;
            productManufacturerLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productYearOfProductionLabelInfo
            // 
            productYearOfProductionLabelInfo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productYearOfProductionLabelInfo.AutoEllipsis = true;
            productYearOfProductionLabelInfo.AutoSize = true;
            productYearOfProductionLabelInfo.Location = new Point(298, 186);
            productYearOfProductionLabelInfo.Margin = new Padding(21, 0, 0, 0);
            productYearOfProductionLabelInfo.Name = "productYearOfProductionLabelInfo";
            productYearOfProductionLabelInfo.Size = new Size(256, 20);
            productYearOfProductionLabelInfo.TabIndex = 0;
            productYearOfProductionLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productColorLabelInfo
            // 
            productColorLabelInfo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productColorLabelInfo.AutoEllipsis = true;
            productColorLabelInfo.AutoSize = true;
            productColorLabelInfo.Location = new Point(298, 235);
            productColorLabelInfo.Margin = new Padding(21, 0, 0, 0);
            productColorLabelInfo.Name = "productColorLabelInfo";
            productColorLabelInfo.Size = new Size(256, 20);
            productColorLabelInfo.TabIndex = 0;
            productColorLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productPriceLabelInfo
            // 
            productPriceLabelInfo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productPriceLabelInfo.AutoEllipsis = true;
            productPriceLabelInfo.AutoSize = true;
            productPriceLabelInfo.Location = new Point(298, 284);
            productPriceLabelInfo.Margin = new Padding(21, 0, 0, 0);
            productPriceLabelInfo.Name = "productPriceLabelInfo";
            productPriceLabelInfo.Size = new Size(256, 20);
            productPriceLabelInfo.TabIndex = 0;
            productPriceLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // markTitle
            // 
            markTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            markTitle.AutoEllipsis = true;
            markTitle.AutoSize = true;
            markTitle.Location = new Point(0, 335);
            markTitle.Margin = new Padding(0, 0, 21, 0);
            markTitle.Name = "markTitle";
            markTitle.Size = new Size(256, 20);
            markTitle.TabIndex = 0;
            markTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // markComboBox
            // 
            markComboBox.BackColor = Color.Transparent;
            markComboBox.BorderRadius = 8;
            markComboBox.Cursor = Cursors.Hand;
            markComboBox.CustomizableEdges = customizableEdges3;
            markComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            markComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            markComboBox.FillColor = SystemColors.MenuBar;
            markComboBox.FocusedColor = Color.FromArgb(94, 148, 255);
            markComboBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            markComboBox.Font = new Font("Segoe UI", 10F);
            markComboBox.ForeColor = SystemColors.WindowText;
            markComboBox.ItemHeight = 30;
            markComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            markComboBox.Location = new Point(292, 326);
            markComboBox.Margin = new Padding(15, 7, 0, 0);
            markComboBox.Name = "markComboBox";
            markComboBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            markComboBox.Size = new Size(170, 36);
            markComboBox.TabIndex = 0;
            // 
            // ProductCardForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(554, 783);
            Controls.Add(productInformationTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = Properties.Resources.logoIcon;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "ProductCardForm";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Load += ProductCardFormLoad;
            productInformationTableLayoutPanel.ResumeLayout(false);
            productInformationTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)productPhotoPictureBox).EndInit();
            productInfoTableLayoutPanel.ResumeLayout(false);
            productInfoTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private TableLayoutPanel productInformationTableLayoutPanel;
        private Label productNameLabel;
        private PictureBox productPhotoPictureBox;
        private TableLayoutPanel productInfoTableLayoutPanel;
        private Label productDescriptionLabel;
        private Label productTypeLabelTitle;
        private Label productManufacturerLabelTitle;
        private Label productYearOfProductionLabelTitle;
        private Label productColorLabelTitle;
        private Label productPriceLabelTitle;
        private Label productTypeLabelInfo;
        private Label productManufacturerLabelInfo;
        private Label productYearOfProductionLabelInfo;
        private Label productColorLabelInfo;
        private Label productPriceLabelInfo;
        private Label markTitle;
        private Guna.UI2.WinForms.Guna2ComboBox markComboBox;
        private Guna.UI2.WinForms.Guna2Button saveMarkButton;
    }
}