namespace ZONOupdate.ProjectControls.ControlForCollectionName;

partial class CollectionNameControl
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
        collectionNameTableLayoutPanel = new TableLayoutPanel();
        collectionNameLabel = new Label();
        collectionSendToEmailPictureBox = new PictureBox();
        collectionNameTableLayoutPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)collectionSendToEmailPictureBox).BeginInit();
        SuspendLayout();
        // 
        // collectionNameTableLayoutPanel
        // 
        collectionNameTableLayoutPanel.ColumnCount = 2;
        collectionNameTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
        collectionNameTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        collectionNameTableLayoutPanel.Controls.Add(collectionNameLabel, 0, 0);
        collectionNameTableLayoutPanel.Controls.Add(collectionSendToEmailPictureBox, 1, 0);
        collectionNameTableLayoutPanel.Dock = DockStyle.Fill;
        collectionNameTableLayoutPanel.Location = new Point(0, 0);
        collectionNameTableLayoutPanel.Margin = new Padding(0);
        collectionNameTableLayoutPanel.Name = "collectionNameTableLayoutPanel";
        collectionNameTableLayoutPanel.RowCount = 1;
        collectionNameTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        collectionNameTableLayoutPanel.Size = new Size(200, 60);
        collectionNameTableLayoutPanel.TabIndex = 0;
        collectionNameTableLayoutPanel.TabStop = true;
        // 
        // collectionNameLabel
        // 
        collectionNameLabel.AutoSize = true;
        collectionNameLabel.Cursor = Cursors.Hand;
        collectionNameLabel.Dock = DockStyle.Fill;
        collectionNameLabel.Location = new Point(15, 0);
        collectionNameLabel.Margin = new Padding(15, 0, 0, 0);
        collectionNameLabel.Name = "collectionNameLabel";
        collectionNameLabel.Size = new Size(145, 60);
        collectionNameLabel.TabIndex = 0;
        collectionNameLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // collectionSendToEmailPictureBox
        // 
        collectionSendToEmailPictureBox.Anchor = AnchorStyles.Left;
        collectionSendToEmailPictureBox.Cursor = Cursors.Hand;
        collectionSendToEmailPictureBox.Image = Properties.Resources.sendByEmail;
        collectionSendToEmailPictureBox.Location = new Point(160, 10);
        collectionSendToEmailPictureBox.Margin = new Padding(0);
        collectionSendToEmailPictureBox.Name = "collectionSendToEmailPictureBox";
        collectionSendToEmailPictureBox.Size = new Size(30, 40);
        collectionSendToEmailPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        collectionSendToEmailPictureBox.TabIndex = 1;
        collectionSendToEmailPictureBox.TabStop = false;
        collectionSendToEmailPictureBox.MouseDown += CollectionSendToEmailPictureBoxMouseDown;
        // 
        // CollectionNameControl
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(178, 242, 196);
        Controls.Add(collectionNameTableLayoutPanel);
        ForeColor = SystemColors.WindowText;
        Margin = new Padding(0);
        Name = "CollectionNameControl";
        Size = new Size(200, 60);
        collectionNameTableLayoutPanel.ResumeLayout(false);
        collectionNameTableLayoutPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)collectionSendToEmailPictureBox).EndInit();
        ResumeLayout(false);
    }
    #endregion

    private TableLayoutPanel collectionNameTableLayoutPanel;
    private Label collectionNameLabel;
    private PictureBox collectionSendToEmailPictureBox;
}