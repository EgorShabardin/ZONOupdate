namespace ZONOupdate.ProjectControls.ControlForDisplayingProduct
{
    partial class ProductControl
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

        #region Код, автоматически созданный конструктором компонентов
        private void InitializeComponent()
        {
            productPhotoPictureBox = new PictureBox();
            productNameLabel = new Label();
            productPriceLabel = new Label();
            productMarkLabel = new Label();
            productControlTableLayoutPanel = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)productPhotoPictureBox).BeginInit();
            productControlTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // productPhotoPictureBox
            // 
            productPhotoPictureBox.Location = new Point(65, 20);
            productPhotoPictureBox.Margin = new Padding(65, 20, 20, 20);
            productPhotoPictureBox.Name = "productPhotoPictureBox";
            productControlTableLayoutPanel.SetRowSpan(productPhotoPictureBox, 3);
            productPhotoPictureBox.Size = new Size(181, 153);
            productPhotoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            productPhotoPictureBox.TabIndex = 0;
            productPhotoPictureBox.TabStop = true;
            productPhotoPictureBox.DoubleClick += ProductControlTableLayoutPanelDoubleClick;
            // 
            // productNameLabel
            // 
            productNameLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productNameLabel.AutoEllipsis = true;
            productNameLabel.AutoSize = true;
            productNameLabel.ForeColor = SystemColors.WindowText;
            productNameLabel.ImageAlign = ContentAlignment.MiddleLeft;
            productNameLabel.Location = new Point(301, 28);
            productNameLabel.Margin = new Padding(35, 10, 10, 10);
            productNameLabel.Name = "productNameLabel";
            productNameLabel.Size = new Size(365, 20);
            productNameLabel.TabIndex = 0;
            productNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            productNameLabel.DoubleClick += ProductControlTableLayoutPanelDoubleClick;
            // 
            // productPriceLabel
            // 
            productPriceLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productPriceLabel.AutoEllipsis = true;
            productPriceLabel.AutoSize = true;
            productPriceLabel.ForeColor = SystemColors.WindowText;
            productPriceLabel.Location = new Point(306, 95);
            productPriceLabel.Margin = new Padding(40, 10, 10, 10);
            productPriceLabel.Name = "productPriceLabel";
            productPriceLabel.Size = new Size(360, 20);
            productPriceLabel.TabIndex = 0;
            productPriceLabel.TextAlign = ContentAlignment.MiddleLeft;
            productPriceLabel.DoubleClick += ProductControlTableLayoutPanelDoubleClick;
            // 
            // productMarkLabel
            // 
            productMarkLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            productMarkLabel.AutoEllipsis = true;
            productMarkLabel.AutoSize = true;
            productMarkLabel.ForeColor = SystemColors.WindowText;
            productMarkLabel.Location = new Point(306, 153);
            productMarkLabel.Margin = new Padding(40, 10, 10, 10);
            productMarkLabel.Name = "productMarkLabel";
            productMarkLabel.Size = new Size(360, 20);
            productMarkLabel.TabIndex = 0;
            productMarkLabel.TextAlign = ContentAlignment.MiddleLeft;
            productMarkLabel.DoubleClick += ProductControlTableLayoutPanelDoubleClick;
            // 
            // productControlTableLayoutPanel
            // 
            productControlTableLayoutPanel.BackColor = Color.FromArgb(178, 242, 196);
            productControlTableLayoutPanel.ColumnCount = 3;
            productControlTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.0784321F));
            productControlTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.19608F));
            productControlTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.72549F));
            productControlTableLayoutPanel.Controls.Add(productPhotoPictureBox, 0, 0);
            productControlTableLayoutPanel.Controls.Add(productMarkLabel, 1, 2);
            productControlTableLayoutPanel.Controls.Add(productNameLabel, 1, 0);
            productControlTableLayoutPanel.Controls.Add(productPriceLabel, 1, 1);
            productControlTableLayoutPanel.Dock = DockStyle.Fill;
            productControlTableLayoutPanel.Location = new Point(0, 0);
            productControlTableLayoutPanel.Margin = new Padding(0);
            productControlTableLayoutPanel.Name = "productControlTableLayoutPanel";
            productControlTableLayoutPanel.RowCount = 3;
            productControlTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            productControlTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            productControlTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            productControlTableLayoutPanel.Size = new Size(1020, 193);
            productControlTableLayoutPanel.TabIndex = 0;
            productControlTableLayoutPanel.TabStop = true;
            productControlTableLayoutPanel.DoubleClick += ProductControlTableLayoutPanelDoubleClick;
            // 
            // ProductControl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(178, 242, 196);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(productControlTableLayoutPanel);
            Margin = new Padding(0);
            Name = "ProductControl";
            Size = new Size(1020, 193);
            ((System.ComponentModel.ISupportInitialize)productPhotoPictureBox).EndInit();
            productControlTableLayoutPanel.ResumeLayout(false);
            productControlTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private PictureBox productPhotoPictureBox;
        private Label productNameLabel;
        private Label productPriceLabel;
        private Label productMarkLabel;
        private PictureBox addToFavoritePictureBox;
        private TableLayoutPanel productControlTableLayoutPanel;
    }
}