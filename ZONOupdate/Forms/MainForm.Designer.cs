using System.Windows.Forms;

namespace ZONOupdate
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            sidebarPanel = new Panel();
            exitButton = new Button();
            myFavoritesPictureBox = new PictureBox();
            myRecommendationsPictureBox = new PictureBox();
            myCollectionsPictureBox = new PictureBox();
            mainPagePictureBox = new PictureBox();
            logoPictureBox = new PictureBox();
            favoriteLabel = new Label();
            myProductsLabel = new Label();
            myCollectionsLabel = new Label();
            mainPageLabel = new Label();
            mainTableLayoutPanel = new TableLayoutPanel();
            selectLanguageTableLayoutPanel = new TableLayoutPanel();
            selectLanguageComboBox = new ComboBox();
            flagPictureBox = new PictureBox();
            secondaryTableLayoutPanel = new TableLayoutPanel();
            sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)myFavoritesPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myRecommendationsPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myCollectionsPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainPagePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            mainTableLayoutPanel.SuspendLayout();
            selectLanguageTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)flagPictureBox).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(178, 242, 196);
            sidebarPanel.BorderStyle = BorderStyle.FixedSingle;
            sidebarPanel.Controls.Add(exitButton);
            sidebarPanel.Controls.Add(myFavoritesPictureBox);
            sidebarPanel.Controls.Add(myRecommendationsPictureBox);
            sidebarPanel.Controls.Add(myCollectionsPictureBox);
            sidebarPanel.Controls.Add(mainPagePictureBox);
            sidebarPanel.Controls.Add(logoPictureBox);
            sidebarPanel.Controls.Add(favoriteLabel);
            sidebarPanel.Controls.Add(myProductsLabel);
            sidebarPanel.Controls.Add(myCollectionsLabel);
            sidebarPanel.Controls.Add(mainPageLabel);
            sidebarPanel.Dock = DockStyle.Right;
            sidebarPanel.ForeColor = SystemColors.WindowText;
            sidebarPanel.Location = new Point(829, 0);
            sidebarPanel.Margin = new Padding(0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(235, 681);
            sidebarPanel.TabIndex = 0;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(0, 166, 253);
            exitButton.Cursor = Cursors.Hand;
            exitButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitButton.ForeColor = SystemColors.ButtonHighlight;
            exitButton.Location = new Point(44, 631);
            exitButton.Margin = new Padding(0);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(151, 39);
            exitButton.TabIndex = 0;
            exitButton.TabStop = false;
            exitButton.UseVisualStyleBackColor = false;
            exitButton.MouseDown += ClickOnExitLabel;
            // 
            // myFavoritesPictureBox
            // 
            myFavoritesPictureBox.Image = Properties.Resources.favorites;
            myFavoritesPictureBox.Location = new Point(16, 321);
            myFavoritesPictureBox.Name = "myFavoritesPictureBox";
            myFavoritesPictureBox.Size = new Size(35, 34);
            myFavoritesPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            myFavoritesPictureBox.TabIndex = 10;
            myFavoritesPictureBox.TabStop = false;
            // 
            // myRecommendationsPictureBox
            // 
            myRecommendationsPictureBox.Image = Properties.Resources.myRecommendations;
            myRecommendationsPictureBox.Location = new Point(16, 268);
            myRecommendationsPictureBox.Name = "myRecommendationsPictureBox";
            myRecommendationsPictureBox.Size = new Size(35, 34);
            myRecommendationsPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            myRecommendationsPictureBox.TabIndex = 9;
            myRecommendationsPictureBox.TabStop = false;
            // 
            // myCollectionsPictureBox
            // 
            myCollectionsPictureBox.Image = Properties.Resources.сollections;
            myCollectionsPictureBox.Location = new Point(16, 214);
            myCollectionsPictureBox.Name = "myCollectionsPictureBox";
            myCollectionsPictureBox.Size = new Size(35, 34);
            myCollectionsPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            myCollectionsPictureBox.TabIndex = 8;
            myCollectionsPictureBox.TabStop = false;
            // 
            // mainPagePictureBox
            // 
            mainPagePictureBox.Image = Properties.Resources.homePage;
            mainPagePictureBox.Location = new Point(16, 161);
            mainPagePictureBox.Margin = new Padding(0);
            mainPagePictureBox.Name = "mainPagePictureBox";
            mainPagePictureBox.Size = new Size(35, 34);
            mainPagePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            mainPagePictureBox.TabIndex = 7;
            mainPagePictureBox.TabStop = false;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Image = Properties.Resources.logo;
            logoPictureBox.Location = new Point(51, 14);
            logoPictureBox.Margin = new Padding(0);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(134, 129);
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 5;
            logoPictureBox.TabStop = false;
            // 
            // favoriteLabel
            // 
            favoriteLabel.AutoSize = true;
            favoriteLabel.Cursor = Cursors.Hand;
            favoriteLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            favoriteLabel.ForeColor = SystemColors.WindowText;
            favoriteLabel.Location = new Point(55, 327);
            favoriteLabel.Name = "favoriteLabel";
            favoriteLabel.Size = new Size(0, 20);
            favoriteLabel.TabIndex = 0;
            favoriteLabel.MouseDown += ClickOnFavoritePage;
            // 
            // myProductsLabel
            // 
            myProductsLabel.AutoSize = true;
            myProductsLabel.Cursor = Cursors.Hand;
            myProductsLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            myProductsLabel.ForeColor = SystemColors.WindowText;
            myProductsLabel.Location = new Point(55, 274);
            myProductsLabel.Name = "myProductsLabel";
            myProductsLabel.Size = new Size(0, 20);
            myProductsLabel.TabIndex = 0;
            myProductsLabel.MouseDown += ClickOnMyProductsPage;
            // 
            // myCollectionsLabel
            // 
            myCollectionsLabel.AutoSize = true;
            myCollectionsLabel.Cursor = Cursors.Hand;
            myCollectionsLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            myCollectionsLabel.ForeColor = SystemColors.WindowText;
            myCollectionsLabel.Location = new Point(55, 220);
            myCollectionsLabel.Name = "myCollectionsLabel";
            myCollectionsLabel.Size = new Size(0, 20);
            myCollectionsLabel.TabIndex = 0;
            myCollectionsLabel.MouseDown += ClickOnMyCollectionsPage;
            // 
            // mainPageLabel
            // 
            mainPageLabel.AutoSize = true;
            mainPageLabel.Cursor = Cursors.Hand;
            mainPageLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainPageLabel.ForeColor = SystemColors.WindowText;
            mainPageLabel.Location = new Point(55, 168);
            mainPageLabel.Name = "mainPageLabel";
            mainPageLabel.Size = new Size(0, 20);
            mainPageLabel.TabIndex = 0;
            mainPageLabel.MouseDown += ClickOnMainPage;
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.AutoSize = true;
            mainTableLayoutPanel.BackColor = Color.FromArgb(178, 242, 196);
            mainTableLayoutPanel.ColumnCount = 2;
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.47648F));
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.52352F));
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.47648F));
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.52352F));
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 87F));
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 152F));
            mainTableLayoutPanel.Controls.Add(selectLanguageTableLayoutPanel, 1, 0);
            mainTableLayoutPanel.Location = new Point(0, 0);
            mainTableLayoutPanel.Margin = new Padding(0);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 2;
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 49.12281F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50.87719F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 49.1228065F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50.8771935F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 125F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 152F));
            mainTableLayoutPanel.Size = new Size(829, 137);
            mainTableLayoutPanel.TabIndex = 0;
            // 
            // selectLanguageTableLayoutPanel
            // 
            selectLanguageTableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectLanguageTableLayoutPanel.BackColor = Color.FromArgb(240, 240, 240);
            selectLanguageTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            selectLanguageTableLayoutPanel.ColumnCount = 2;
            selectLanguageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.2990646F));
            selectLanguageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.7009354F));
            selectLanguageTableLayoutPanel.Controls.Add(selectLanguageComboBox, 1, 0);
            selectLanguageTableLayoutPanel.Controls.Add(flagPictureBox, 0, 0);
            selectLanguageTableLayoutPanel.Location = new Point(579, 19);
            selectLanguageTableLayoutPanel.Margin = new Padding(0, 19, 56, 0);
            selectLanguageTableLayoutPanel.Name = "selectLanguageTableLayoutPanel";
            selectLanguageTableLayoutPanel.RowCount = 1;
            selectLanguageTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            selectLanguageTableLayoutPanel.Size = new Size(194, 34);
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
            selectLanguageComboBox.Location = new Point(52, 6);
            selectLanguageComboBox.Margin = new Padding(4, 5, 4, 0);
            selectLanguageComboBox.Name = "selectLanguageComboBox";
            selectLanguageComboBox.Size = new Size(137, 23);
            selectLanguageComboBox.TabIndex = 0;
            selectLanguageComboBox.TabStop = false;
            selectLanguageComboBox.SelectedIndexChanged += SelectLanguageComboBoxSelectedIndexChanged;
            // 
            // flagPictureBox
            // 
            flagPictureBox.Dock = DockStyle.Fill;
            flagPictureBox.Location = new Point(4, 4);
            flagPictureBox.Name = "flagPictureBox";
            flagPictureBox.Size = new Size(40, 26);
            flagPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            flagPictureBox.TabIndex = 0;
            flagPictureBox.TabStop = false;
            // 
            // secondaryTableLayoutPanel
            // 
            secondaryTableLayoutPanel.BackColor = Color.FromArgb(178, 242, 196);
            secondaryTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            secondaryTableLayoutPanel.ColumnCount = 1;
            secondaryTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            secondaryTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 606F));
            secondaryTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            secondaryTableLayoutPanel.Dock = DockStyle.Bottom;
            secondaryTableLayoutPanel.Location = new Point(0, 162);
            secondaryTableLayoutPanel.Margin = new Padding(0);
            secondaryTableLayoutPanel.Name = "secondaryTableLayoutPanel";
            secondaryTableLayoutPanel.RowCount = 1;
            secondaryTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            secondaryTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            secondaryTableLayoutPanel.Size = new Size(829, 519);
            secondaryTableLayoutPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 242, 196);
            ClientSize = new Size(1064, 681);
            Controls.Add(secondaryTableLayoutPanel);
            Controls.Add(mainTableLayoutPanel);
            Controls.Add(sidebarPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)myFavoritesPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)myRecommendationsPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)myCollectionsPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainPagePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            mainTableLayoutPanel.ResumeLayout(false);
            selectLanguageTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)flagPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel sidebarPanel;
        private Label favoriteLabel;
        private Label myProductsLabel;
        private Label myCollectionsLabel;
        private Label mainPageLabel;
        private PictureBox logoPictureBox;
        private PictureBox mainPagePictureBox;
        private PictureBox myCollectionsPictureBox;
        private PictureBox myFavoritesPictureBox;
        private PictureBox myRecommendationsPictureBox;
        private TableLayoutPanel mainTableLayoutPanel;
        private Button exitButton;
        private TableLayoutPanel secondaryTableLayoutPanel;
        private TableLayoutPanel selectLanguageTableLayoutPanel;
        private ComboBox selectLanguageComboBox;
        private PictureBox flagPictureBox;
    }
}