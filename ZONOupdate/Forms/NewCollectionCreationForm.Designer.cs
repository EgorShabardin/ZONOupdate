namespace ZONOupdate.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCollectionCreationForm));
            collectionNameTextBox = new TextBox();
            saveNewCollectionButton = new Button();
            informationLabel = new Label();
            addNewCollectionTableLayoutPanel = new TableLayoutPanel();
            addNewCollectionTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // collectionNameTextBox
            // 
            collectionNameTextBox.BackColor = SystemColors.ButtonFace;
            collectionNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            collectionNameTextBox.Dock = DockStyle.Fill;
            collectionNameTextBox.Location = new Point(70, 74);
            collectionNameTextBox.Margin = new Padding(70, 15, 70, 0);
            collectionNameTextBox.Name = "collectionNameTextBox";
            collectionNameTextBox.Size = new Size(219, 23);
            collectionNameTextBox.TabIndex = 0;
            // 
            // saveNewCollectionButton
            // 
            saveNewCollectionButton.BackColor = Color.FromArgb(0, 166, 253);
            saveNewCollectionButton.Cursor = Cursors.Hand;
            saveNewCollectionButton.Dock = DockStyle.Fill;
            saveNewCollectionButton.ForeColor = SystemColors.Window;
            saveNewCollectionButton.Location = new Point(93, 126);
            saveNewCollectionButton.Margin = new Padding(93, 8, 93, 11);
            saveNewCollectionButton.Name = "saveNewCollectionButton";
            saveNewCollectionButton.Size = new Size(173, 40);
            saveNewCollectionButton.TabIndex = 0;
            saveNewCollectionButton.UseVisualStyleBackColor = false;
            saveNewCollectionButton.MouseDown += ClickOnAddNewCollectionButton;
            // 
            // informationLabel
            // 
            informationLabel.AutoSize = true;
            informationLabel.Dock = DockStyle.Fill;
            informationLabel.Location = new Point(0, 19);
            informationLabel.Margin = new Padding(0, 19, 0, 0);
            informationLabel.Name = "informationLabel";
            informationLabel.Size = new Size(359, 40);
            informationLabel.TabIndex = 0;
            informationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addNewCollectionTableLayoutPanel
            // 
            addNewCollectionTableLayoutPanel.ColumnCount = 1;
            addNewCollectionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            addNewCollectionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 16F));
            addNewCollectionTableLayoutPanel.Controls.Add(saveNewCollectionButton, 0, 2);
            addNewCollectionTableLayoutPanel.Controls.Add(collectionNameTextBox, 0, 1);
            addNewCollectionTableLayoutPanel.Controls.Add(informationLabel, 0, 0);
            addNewCollectionTableLayoutPanel.Dock = DockStyle.Fill;
            addNewCollectionTableLayoutPanel.Location = new Point(0, 0);
            addNewCollectionTableLayoutPanel.Margin = new Padding(2);
            addNewCollectionTableLayoutPanel.Name = "addNewCollectionTableLayoutPanel";
            addNewCollectionTableLayoutPanel.RowCount = 3;
            addNewCollectionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            addNewCollectionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            addNewCollectionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            addNewCollectionTableLayoutPanel.Size = new Size(359, 177);
            addNewCollectionTableLayoutPanel.TabIndex = 1;
            // 
            // NewCollectionCreationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(359, 177);
            Controls.Add(addNewCollectionTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "NewCollectionCreationForm";
            StartPosition = FormStartPosition.CenterScreen;
            addNewCollectionTableLayoutPanel.ResumeLayout(false);
            addNewCollectionTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private TextBox collectionNameTextBox;
        private Button saveNewCollectionButton;
        private Label informationLabel;
        private TableLayoutPanel addNewCollectionTableLayoutPanel;
    }
}