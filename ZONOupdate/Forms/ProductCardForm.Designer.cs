namespace ZONOupdate.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCardForm));
            productInformationTableLayoutPanel = new TableLayoutPanel();
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
            markComboBox = new ComboBox();
            saveMarkButton = new Button();
            productInformationTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productPhotoPictureBox).BeginInit();
            productInfoTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // productInformationTableLayoutPanel
            // 
            productInformationTableLayoutPanel.ColumnCount = 1;
            productInformationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            productInformationTableLayoutPanel.Controls.Add(productNameLabel, 0, 0);
            productInformationTableLayoutPanel.Controls.Add(productPhotoPictureBox, 0, 1);
            productInformationTableLayoutPanel.Controls.Add(productInfoTableLayoutPanel, 0, 2);
            productInformationTableLayoutPanel.Controls.Add(saveMarkButton, 0, 3);
            productInformationTableLayoutPanel.Dock = DockStyle.Fill;
            productInformationTableLayoutPanel.Location = new Point(0, 0);
            productInformationTableLayoutPanel.Margin = new Padding(0);
            productInformationTableLayoutPanel.Name = "productInformationTableLayoutPanel";
            productInformationTableLayoutPanel.RowCount = 4;
            productInformationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            productInformationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            productInformationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            productInformationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            productInformationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            productInformationTableLayoutPanel.Size = new Size(431, 587);
            productInformationTableLayoutPanel.TabIndex = 0;
            // 
            // productNameLabel
            // 
            productNameLabel.AutoSize = true;
            productNameLabel.Dock = DockStyle.Fill;
            productNameLabel.Location = new Point(0, 0);
            productNameLabel.Margin = new Padding(0, 0, 0, 11);
            productNameLabel.Name = "productNameLabel";
            productNameLabel.Size = new Size(431, 47);
            productNameLabel.TabIndex = 0;
            productNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // productPhotoPictureBox
            // 
            productPhotoPictureBox.Dock = DockStyle.Fill;
            productPhotoPictureBox.Location = new Point(35, 58);
            productPhotoPictureBox.Margin = new Padding(35, 0, 35, 11);
            productPhotoPictureBox.Name = "productPhotoPictureBox";
            productPhotoPictureBox.Size = new Size(361, 194);
            productPhotoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            productPhotoPictureBox.TabIndex = 1;
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
            productInfoTableLayoutPanel.Location = new Point(0, 263);
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
            productInfoTableLayoutPanel.Size = new Size(431, 264);
            productInfoTableLayoutPanel.TabIndex = 0;
            // 
            // productDescriptionLabel
            // 
            productDescriptionLabel.AutoSize = true;
            productInfoTableLayoutPanel.SetColumnSpan(productDescriptionLabel, 2);
            productDescriptionLabel.Dock = DockStyle.Fill;
            productDescriptionLabel.Location = new Point(12, 0);
            productDescriptionLabel.Margin = new Padding(12, 0, 12, 8);
            productDescriptionLabel.Name = "productDescriptionLabel";
            productDescriptionLabel.Size = new Size(407, 44);
            productDescriptionLabel.TabIndex = 0;
            // 
            // productTypeLabelTitle
            // 
            productTypeLabelTitle.AutoSize = true;
            productTypeLabelTitle.Dock = DockStyle.Fill;
            productTypeLabelTitle.Location = new Point(27, 52);
            productTypeLabelTitle.Margin = new Padding(27, 0, 0, 0);
            productTypeLabelTitle.Name = "productTypeLabelTitle";
            productTypeLabelTitle.Size = new Size(188, 35);
            productTypeLabelTitle.TabIndex = 0;
            productTypeLabelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productManufacturerLabelTitle
            // 
            productManufacturerLabelTitle.AutoSize = true;
            productManufacturerLabelTitle.Dock = DockStyle.Fill;
            productManufacturerLabelTitle.Location = new Point(27, 87);
            productManufacturerLabelTitle.Margin = new Padding(27, 0, 0, 0);
            productManufacturerLabelTitle.Name = "productManufacturerLabelTitle";
            productManufacturerLabelTitle.Size = new Size(188, 35);
            productManufacturerLabelTitle.TabIndex = 0;
            productManufacturerLabelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productYearOfProductionLabelTitle
            // 
            productYearOfProductionLabelTitle.AutoSize = true;
            productYearOfProductionLabelTitle.Dock = DockStyle.Fill;
            productYearOfProductionLabelTitle.Location = new Point(27, 122);
            productYearOfProductionLabelTitle.Margin = new Padding(27, 0, 0, 0);
            productYearOfProductionLabelTitle.Name = "productYearOfProductionLabelTitle";
            productYearOfProductionLabelTitle.Size = new Size(188, 35);
            productYearOfProductionLabelTitle.TabIndex = 0;
            productYearOfProductionLabelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productColorLabelTitle
            // 
            productColorLabelTitle.AutoSize = true;
            productColorLabelTitle.Dock = DockStyle.Fill;
            productColorLabelTitle.Location = new Point(27, 157);
            productColorLabelTitle.Margin = new Padding(27, 0, 0, 0);
            productColorLabelTitle.Name = "productColorLabelTitle";
            productColorLabelTitle.Size = new Size(188, 35);
            productColorLabelTitle.TabIndex = 0;
            productColorLabelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productPriceLabelTitle
            // 
            productPriceLabelTitle.AutoSize = true;
            productPriceLabelTitle.Dock = DockStyle.Fill;
            productPriceLabelTitle.Location = new Point(27, 192);
            productPriceLabelTitle.Margin = new Padding(27, 0, 0, 0);
            productPriceLabelTitle.Name = "productPriceLabelTitle";
            productPriceLabelTitle.Size = new Size(188, 35);
            productPriceLabelTitle.TabIndex = 0;
            // 
            // productTypeLabelInfo
            // 
            productTypeLabelInfo.AutoSize = true;
            productTypeLabelInfo.Dock = DockStyle.Fill;
            productTypeLabelInfo.Location = new Point(231, 52);
            productTypeLabelInfo.Margin = new Padding(16, 0, 0, 0);
            productTypeLabelInfo.Name = "productTypeLabelInfo";
            productTypeLabelInfo.Size = new Size(200, 35);
            productTypeLabelInfo.TabIndex = 0;
            productTypeLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productManufacturerLabelInfo
            // 
            productManufacturerLabelInfo.AutoSize = true;
            productManufacturerLabelInfo.Dock = DockStyle.Fill;
            productManufacturerLabelInfo.Location = new Point(231, 87);
            productManufacturerLabelInfo.Margin = new Padding(16, 0, 0, 0);
            productManufacturerLabelInfo.Name = "productManufacturerLabelInfo";
            productManufacturerLabelInfo.Size = new Size(200, 35);
            productManufacturerLabelInfo.TabIndex = 0;
            productManufacturerLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productYearOfProductionLabelInfo
            // 
            productYearOfProductionLabelInfo.AutoSize = true;
            productYearOfProductionLabelInfo.Dock = DockStyle.Fill;
            productYearOfProductionLabelInfo.Location = new Point(231, 122);
            productYearOfProductionLabelInfo.Margin = new Padding(16, 0, 0, 0);
            productYearOfProductionLabelInfo.Name = "productYearOfProductionLabelInfo";
            productYearOfProductionLabelInfo.Size = new Size(200, 35);
            productYearOfProductionLabelInfo.TabIndex = 0;
            productYearOfProductionLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productColorLabelInfo
            // 
            productColorLabelInfo.AutoSize = true;
            productColorLabelInfo.Dock = DockStyle.Fill;
            productColorLabelInfo.Location = new Point(231, 157);
            productColorLabelInfo.Margin = new Padding(16, 0, 0, 0);
            productColorLabelInfo.Name = "productColorLabelInfo";
            productColorLabelInfo.Size = new Size(200, 35);
            productColorLabelInfo.TabIndex = 0;
            productColorLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productPriceLabelInfo
            // 
            productPriceLabelInfo.AutoSize = true;
            productPriceLabelInfo.Dock = DockStyle.Fill;
            productPriceLabelInfo.Location = new Point(231, 192);
            productPriceLabelInfo.Margin = new Padding(16, 0, 0, 0);
            productPriceLabelInfo.Name = "productPriceLabelInfo";
            productPriceLabelInfo.Size = new Size(200, 35);
            productPriceLabelInfo.TabIndex = 0;
            productPriceLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // markTitle
            // 
            markTitle.AutoSize = true;
            markTitle.Dock = DockStyle.Fill;
            markTitle.Location = new Point(0, 227);
            markTitle.Margin = new Padding(0, 0, 16, 0);
            markTitle.Name = "markTitle";
            markTitle.Size = new Size(199, 37);
            markTitle.TabIndex = 0;
            markTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // markComboBox
            // 
            markComboBox.BackColor = SystemColors.ButtonFace;
            markComboBox.Cursor = Cursors.Hand;
            markComboBox.Dock = DockStyle.Top;
            markComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            markComboBox.FlatStyle = FlatStyle.Popup;
            markComboBox.FormattingEnabled = true;
            markComboBox.Items.AddRange(new object[] { "5", "4", "3", "2", "1" });
            markComboBox.Location = new Point(223, 235);
            markComboBox.Margin = new Padding(8, 8, 86, 0);
            markComboBox.Name = "markComboBox";
            markComboBox.Size = new Size(122, 23);
            markComboBox.TabIndex = 0;
            markComboBox.TabStop = false;
            // 
            // saveMarkButton
            // 
            saveMarkButton.BackColor = Color.FromArgb(0, 166, 253);
            saveMarkButton.Cursor = Cursors.Hand;
            saveMarkButton.Dock = DockStyle.Fill;
            saveMarkButton.Location = new Point(132, 538);
            saveMarkButton.Margin = new Padding(132, 11, 132, 8);
            saveMarkButton.Name = "saveMarkButton";
            saveMarkButton.Size = new Size(167, 41);
            saveMarkButton.TabIndex = 0;
            saveMarkButton.UseVisualStyleBackColor = false;
            saveMarkButton.Click += ClickOnSaveMarkButton;
            // 
            // ProductCardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(431, 587);
            Controls.Add(productInformationTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ProductCardForm";
            StartPosition = FormStartPosition.CenterScreen;
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
        private ComboBox markComboBox;
        private Button saveMarkButton;
    }
}