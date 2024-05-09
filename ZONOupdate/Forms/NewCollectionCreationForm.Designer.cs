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
            collectionNameTextBox.Location = new Point(90, 98);
            collectionNameTextBox.Margin = new Padding(90, 20, 90, 0);
            collectionNameTextBox.Name = "collectionNameTextBox";
            collectionNameTextBox.Size = new Size(282, 27);
            collectionNameTextBox.TabIndex = 0;
            // 
            // saveNewCollectionButton
            // 
            saveNewCollectionButton.BackColor = Color.FromArgb(0, 166, 253);
            saveNewCollectionButton.Cursor = Cursors.Hand;
            saveNewCollectionButton.Dock = DockStyle.Fill;
            saveNewCollectionButton.ForeColor = SystemColors.Window;
            saveNewCollectionButton.Location = new Point(120, 167);
            saveNewCollectionButton.Margin = new Padding(120, 11, 120, 15);
            saveNewCollectionButton.Name = "saveNewCollectionButton";
            saveNewCollectionButton.Size = new Size(222, 54);
            saveNewCollectionButton.TabIndex = 0;
            saveNewCollectionButton.UseVisualStyleBackColor = false;
            saveNewCollectionButton.MouseDown += ClickOnAddNewCollectionButton;
            // 
            // informationLabel
            // 
            informationLabel.AutoSize = true;
            informationLabel.Dock = DockStyle.Fill;
            informationLabel.Location = new Point(0, 25);
            informationLabel.Margin = new Padding(0, 25, 0, 0);
            informationLabel.Name = "informationLabel";
            informationLabel.Size = new Size(462, 53);
            informationLabel.TabIndex = 0;
            informationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addNewCollectionTableLayoutPanel
            // 
            addNewCollectionTableLayoutPanel.ColumnCount = 1;
            addNewCollectionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            addNewCollectionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 21F));
            addNewCollectionTableLayoutPanel.Controls.Add(saveNewCollectionButton, 0, 2);
            addNewCollectionTableLayoutPanel.Controls.Add(collectionNameTextBox, 0, 1);
            addNewCollectionTableLayoutPanel.Controls.Add(informationLabel, 0, 0);
            addNewCollectionTableLayoutPanel.Dock = DockStyle.Fill;
            addNewCollectionTableLayoutPanel.Location = new Point(0, 0);
            addNewCollectionTableLayoutPanel.Name = "addNewCollectionTableLayoutPanel";
            addNewCollectionTableLayoutPanel.RowCount = 3;
            addNewCollectionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            addNewCollectionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            addNewCollectionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            addNewCollectionTableLayoutPanel.Size = new Size(462, 236);
            addNewCollectionTableLayoutPanel.TabIndex = 1;
            // 
            // NewCollectionCreationForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(462, 236);
            Controls.Add(addNewCollectionTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
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