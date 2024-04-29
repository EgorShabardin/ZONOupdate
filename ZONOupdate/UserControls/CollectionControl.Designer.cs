namespace ZONOupdate.UserControls
{
    partial class CollectionControl
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
            collectionInfoTableLayoutPanel = new TableLayoutPanel();
            collectionNameLabel = new Label();
            collectionInfoTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // collectionInfoTableLayoutPanel
            // 
            collectionInfoTableLayoutPanel.ColumnCount = 1;
            collectionInfoTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            collectionInfoTableLayoutPanel.Controls.Add(collectionNameLabel, 0, 0);
            collectionInfoTableLayoutPanel.Dock = DockStyle.Fill;
            collectionInfoTableLayoutPanel.Location = new Point(0, 0);
            collectionInfoTableLayoutPanel.Margin = new Padding(2, 2, 2, 2);
            collectionInfoTableLayoutPanel.Name = "collectionInfoTableLayoutPanel";
            collectionInfoTableLayoutPanel.RowCount = 1;
            collectionInfoTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            collectionInfoTableLayoutPanel.Size = new Size(154, 41);
            collectionInfoTableLayoutPanel.TabIndex = 0;
            collectionInfoTableLayoutPanel.MouseDown += ClickOnCollectionControl;
            // 
            // collectionNameLabel
            // 
            collectionNameLabel.AutoSize = true;
            collectionNameLabel.Dock = DockStyle.Fill;
            collectionNameLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            collectionNameLabel.Location = new Point(8, 0);
            collectionNameLabel.Margin = new Padding(8, 0, 0, 0);
            collectionNameLabel.Name = "collectionNameLabel";
            collectionNameLabel.Size = new Size(146, 41);
            collectionNameLabel.TabIndex = 0;
            collectionNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            collectionNameLabel.MouseDown += ClickOnCollectionControl;
            // 
            // CollectionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 242, 196);
            Controls.Add(collectionInfoTableLayoutPanel);
            Cursor = Cursors.Hand;
            Margin = new Padding(0);
            Name = "CollectionControl";
            Size = new Size(154, 41);
            MouseDown += ClickOnCollectionControl;
            collectionInfoTableLayoutPanel.ResumeLayout(false);
            collectionInfoTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private TableLayoutPanel collectionInfoTableLayoutPanel;
        private Label collectionNameLabel;
    }
}