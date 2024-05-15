﻿namespace ZONOupdate.Forms.FormForMainWindow
{
    partial class MainForm
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
            mainFormTableLayoutPanel = new TableLayoutPanel();
            menuBarTableLayoutPanel = new TableLayoutPanel();
            logoPictureBox = new PictureBox();
            applicationSectionsTableLayoutPanel = new TableLayoutPanel();
            mainPageLabel = new Label();
            myCollectionsLabel = new Label();
            myProductsLabel = new Label();
            favoriteLabel = new Label();
            mainPagePictureBox = new PictureBox();
            myProductsPictureBox = new PictureBox();
            favoritePictureBox = new PictureBox();
            myCollectionsPictureBox = new PictureBox();
            accountStatusLabel = new Label();
            exitButton = new Guna.UI2.WinForms.Guna2Button();
            mainFormContentTableLayoutPanel = new TableLayoutPanel();
            titleTableLayoutPanel = new TableLayoutPanel();
            selectLanguageTableLayoutPanel = new TableLayoutPanel();
            flagPictureBox = new PictureBox();
            selectLanguageComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            recomendationsTableLayoutPanel = new TableLayoutPanel();
            mainFormTableLayoutPanel.SuspendLayout();
            menuBarTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            applicationSectionsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainPagePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myProductsPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)favoritePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myCollectionsPictureBox).BeginInit();
            mainFormContentTableLayoutPanel.SuspendLayout();
            titleTableLayoutPanel.SuspendLayout();
            selectLanguageTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)flagPictureBox).BeginInit();
            SuspendLayout();
            // 
            // mainFormTableLayoutPanel
            // 
            mainFormTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            mainFormTableLayoutPanel.ColumnCount = 2;
            mainFormTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79F));
            mainFormTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21F));
            mainFormTableLayoutPanel.Controls.Add(menuBarTableLayoutPanel, 1, 0);
            mainFormTableLayoutPanel.Controls.Add(mainFormContentTableLayoutPanel, 0, 0);
            mainFormTableLayoutPanel.Dock = DockStyle.Fill;
            mainFormTableLayoutPanel.Location = new Point(0, 0);
            mainFormTableLayoutPanel.Margin = new Padding(0);
            mainFormTableLayoutPanel.Name = "mainFormTableLayoutPanel";
            mainFormTableLayoutPanel.RowCount = 1;
            mainFormTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainFormTableLayoutPanel.Size = new Size(1075, 715);
            mainFormTableLayoutPanel.TabIndex = 0;
            mainFormTableLayoutPanel.TabStop = true;
            // 
            // menuBarTableLayoutPanel
            // 
            menuBarTableLayoutPanel.ColumnCount = 1;
            menuBarTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            menuBarTableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
            menuBarTableLayoutPanel.Controls.Add(applicationSectionsTableLayoutPanel, 0, 1);
            menuBarTableLayoutPanel.Controls.Add(exitButton, 0, 2);
            menuBarTableLayoutPanel.Dock = DockStyle.Fill;
            menuBarTableLayoutPanel.Location = new Point(848, 1);
            menuBarTableLayoutPanel.Margin = new Padding(0);
            menuBarTableLayoutPanel.Name = "menuBarTableLayoutPanel";
            menuBarTableLayoutPanel.RowCount = 3;
            menuBarTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            menuBarTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            menuBarTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            menuBarTableLayoutPanel.Size = new Size(226, 713);
            menuBarTableLayoutPanel.TabIndex = 0;
            menuBarTableLayoutPanel.TabStop = true;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Dock = DockStyle.Fill;
            logoPictureBox.Image = Properties.Resources.logo;
            logoPictureBox.Location = new Point(12, 11);
            logoPictureBox.Margin = new Padding(12, 11, 12, 11);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(202, 156);
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // applicationSectionsTableLayoutPanel
            // 
            applicationSectionsTableLayoutPanel.ColumnCount = 2;
            applicationSectionsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            applicationSectionsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            applicationSectionsTableLayoutPanel.Controls.Add(mainPageLabel, 1, 0);
            applicationSectionsTableLayoutPanel.Controls.Add(myCollectionsLabel, 1, 1);
            applicationSectionsTableLayoutPanel.Controls.Add(myProductsLabel, 1, 2);
            applicationSectionsTableLayoutPanel.Controls.Add(favoriteLabel, 1, 3);
            applicationSectionsTableLayoutPanel.Controls.Add(mainPagePictureBox, 0, 0);
            applicationSectionsTableLayoutPanel.Controls.Add(myProductsPictureBox, 0, 2);
            applicationSectionsTableLayoutPanel.Controls.Add(favoritePictureBox, 0, 3);
            applicationSectionsTableLayoutPanel.Controls.Add(myCollectionsPictureBox, 0, 1);
            applicationSectionsTableLayoutPanel.Controls.Add(accountStatusLabel, 0, 4);
            applicationSectionsTableLayoutPanel.Dock = DockStyle.Fill;
            applicationSectionsTableLayoutPanel.Location = new Point(0, 178);
            applicationSectionsTableLayoutPanel.Margin = new Padding(0);
            applicationSectionsTableLayoutPanel.Name = "applicationSectionsTableLayoutPanel";
            applicationSectionsTableLayoutPanel.RowCount = 6;
            applicationSectionsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            applicationSectionsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            applicationSectionsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            applicationSectionsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            applicationSectionsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            applicationSectionsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            applicationSectionsTableLayoutPanel.Size = new Size(226, 463);
            applicationSectionsTableLayoutPanel.TabIndex = 0;
            applicationSectionsTableLayoutPanel.TabStop = true;
            // 
            // mainPageLabel
            // 
            mainPageLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            mainPageLabel.AutoEllipsis = true;
            mainPageLabel.AutoSize = true;
            mainPageLabel.Cursor = Cursors.Hand;
            mainPageLabel.Location = new Point(64, 15);
            mainPageLabel.Margin = new Padding(8, 0, 8, 0);
            mainPageLabel.Name = "mainPageLabel";
            mainPageLabel.Size = new Size(154, 15);
            mainPageLabel.TabIndex = 0;
            mainPageLabel.TextAlign = ContentAlignment.MiddleLeft;
            mainPageLabel.MouseDown += MainPageMouseDown;
            // 
            // myCollectionsLabel
            // 
            myCollectionsLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            myCollectionsLabel.AutoEllipsis = true;
            myCollectionsLabel.AutoSize = true;
            myCollectionsLabel.Cursor = Cursors.Hand;
            myCollectionsLabel.Location = new Point(64, 61);
            myCollectionsLabel.Margin = new Padding(8, 0, 8, 0);
            myCollectionsLabel.Name = "myCollectionsLabel";
            myCollectionsLabel.Size = new Size(154, 15);
            myCollectionsLabel.TabIndex = 0;
            myCollectionsLabel.TextAlign = ContentAlignment.MiddleLeft;
            myCollectionsLabel.MouseDown += MyCollectionsPageMouseDown;
            // 
            // myProductsLabel
            // 
            myProductsLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            myProductsLabel.AutoEllipsis = true;
            myProductsLabel.AutoSize = true;
            myProductsLabel.Cursor = Cursors.Hand;
            myProductsLabel.Location = new Point(64, 107);
            myProductsLabel.Margin = new Padding(8, 0, 8, 0);
            myProductsLabel.Name = "myProductsLabel";
            myProductsLabel.Size = new Size(154, 15);
            myProductsLabel.TabIndex = 0;
            myProductsLabel.TextAlign = ContentAlignment.MiddleLeft;
            myProductsLabel.MouseDown += MyProductsPageMouseDown;
            // 
            // favoriteLabel
            // 
            favoriteLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            favoriteLabel.AutoEllipsis = true;
            favoriteLabel.AutoSize = true;
            favoriteLabel.Cursor = Cursors.Hand;
            favoriteLabel.Location = new Point(64, 153);
            favoriteLabel.Margin = new Padding(8, 0, 8, 0);
            favoriteLabel.Name = "favoriteLabel";
            favoriteLabel.Size = new Size(154, 15);
            favoriteLabel.TabIndex = 0;
            favoriteLabel.TextAlign = ContentAlignment.MiddleLeft;
            favoriteLabel.MouseDown += FavoritePageMouseDown;
            // 
            // mainPagePictureBox
            // 
            mainPagePictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            mainPagePictureBox.Image = Properties.Resources.homePage;
            mainPagePictureBox.Location = new Point(12, 8);
            mainPagePictureBox.Margin = new Padding(12, 8, 0, 8);
            mainPagePictureBox.Name = "mainPagePictureBox";
            mainPagePictureBox.Size = new Size(44, 30);
            mainPagePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            mainPagePictureBox.TabIndex = 0;
            mainPagePictureBox.TabStop = false;
            // 
            // myProductsPictureBox
            // 
            myProductsPictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            myProductsPictureBox.Image = Properties.Resources.myRecommendations;
            myProductsPictureBox.Location = new Point(12, 100);
            myProductsPictureBox.Margin = new Padding(12, 8, 0, 8);
            myProductsPictureBox.Name = "myProductsPictureBox";
            myProductsPictureBox.Size = new Size(44, 30);
            myProductsPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            myProductsPictureBox.TabIndex = 0;
            myProductsPictureBox.TabStop = false;
            // 
            // favoritePictureBox
            // 
            favoritePictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            favoritePictureBox.Image = Properties.Resources.favorites;
            favoritePictureBox.Location = new Point(12, 146);
            favoritePictureBox.Margin = new Padding(12, 8, 0, 8);
            favoritePictureBox.Name = "favoritePictureBox";
            favoritePictureBox.Size = new Size(44, 30);
            favoritePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            favoritePictureBox.TabIndex = 0;
            favoritePictureBox.TabStop = false;
            // 
            // myCollectionsPictureBox
            // 
            myCollectionsPictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            myCollectionsPictureBox.Image = Properties.Resources.сollections;
            myCollectionsPictureBox.Location = new Point(12, 54);
            myCollectionsPictureBox.Margin = new Padding(12, 8, 0, 8);
            myCollectionsPictureBox.Name = "myCollectionsPictureBox";
            myCollectionsPictureBox.Size = new Size(44, 30);
            myCollectionsPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            myCollectionsPictureBox.TabIndex = 0;
            myCollectionsPictureBox.TabStop = false;
            // 
            // accountStatusLabel
            // 
            accountStatusLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            accountStatusLabel.AutoEllipsis = true;
            accountStatusLabel.AutoSize = true;
            applicationSectionsTableLayoutPanel.SetColumnSpan(accountStatusLabel, 2);
            accountStatusLabel.Location = new Point(14, 222);
            accountStatusLabel.Margin = new Padding(14, 0, 14, 0);
            accountStatusLabel.Name = "accountStatusLabel";
            accountStatusLabel.Size = new Size(198, 15);
            accountStatusLabel.TabIndex = 0;
            accountStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            exitButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            exitButton.BorderRadius = 15;
            exitButton.Cursor = Cursors.Hand;
            exitButton.CustomizableEdges = customizableEdges1;
            exitButton.DisabledState.BorderColor = Color.DarkGray;
            exitButton.DisabledState.CustomBorderColor = Color.DarkGray;
            exitButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            exitButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            exitButton.FillColor = Color.FromArgb(0, 166, 253);
            exitButton.Font = new Font("Segoe UI", 9F);
            exitButton.ForeColor = SystemColors.Window;
            exitButton.Location = new Point(39, 656);
            exitButton.Margin = new Padding(39, 0, 39, 0);
            exitButton.Name = "exitButton";
            exitButton.ShadowDecoration.CustomizableEdges = customizableEdges2;
            exitButton.Size = new Size(148, 42);
            exitButton.TabIndex = 0;
            exitButton.MouseDown += ExitLabelMouseDown;
            // 
            // mainFormContentTableLayoutPanel
            // 
            mainFormContentTableLayoutPanel.ColumnCount = 1;
            mainFormContentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainFormContentTableLayoutPanel.Controls.Add(titleTableLayoutPanel, 0, 0);
            mainFormContentTableLayoutPanel.Controls.Add(recomendationsTableLayoutPanel, 0, 1);
            mainFormContentTableLayoutPanel.Dock = DockStyle.Fill;
            mainFormContentTableLayoutPanel.Location = new Point(1, 1);
            mainFormContentTableLayoutPanel.Margin = new Padding(0);
            mainFormContentTableLayoutPanel.Name = "mainFormContentTableLayoutPanel";
            mainFormContentTableLayoutPanel.RowCount = 2;
            mainFormContentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            mainFormContentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 82F));
            mainFormContentTableLayoutPanel.Size = new Size(846, 713);
            mainFormContentTableLayoutPanel.TabIndex = 0;
            mainFormContentTableLayoutPanel.TabStop = true;
            // 
            // titleTableLayoutPanel
            // 
            titleTableLayoutPanel.ColumnCount = 2;
            titleTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.0973358F));
            titleTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.9026642F));
            titleTableLayoutPanel.Controls.Add(selectLanguageTableLayoutPanel, 1, 0);
            titleTableLayoutPanel.Dock = DockStyle.Fill;
            titleTableLayoutPanel.Location = new Point(0, 0);
            titleTableLayoutPanel.Margin = new Padding(0);
            titleTableLayoutPanel.Name = "titleTableLayoutPanel";
            titleTableLayoutPanel.RowCount = 2;
            titleTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            titleTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            titleTableLayoutPanel.Size = new Size(846, 128);
            titleTableLayoutPanel.TabIndex = 0;
            titleTableLayoutPanel.TabStop = true;
            // 
            // selectLanguageTableLayoutPanel
            // 
            selectLanguageTableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectLanguageTableLayoutPanel.BackColor = Color.FromArgb(240, 240, 240);
            selectLanguageTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            selectLanguageTableLayoutPanel.ColumnCount = 2;
            selectLanguageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.2990646F));
            selectLanguageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.7009354F));
            selectLanguageTableLayoutPanel.Controls.Add(flagPictureBox, 0, 0);
            selectLanguageTableLayoutPanel.Controls.Add(selectLanguageComboBox, 1, 0);
            selectLanguageTableLayoutPanel.Location = new Point(602, 21);
            selectLanguageTableLayoutPanel.Margin = new Padding(0, 21, 39, 0);
            selectLanguageTableLayoutPanel.Name = "selectLanguageTableLayoutPanel";
            selectLanguageTableLayoutPanel.RowCount = 1;
            selectLanguageTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            selectLanguageTableLayoutPanel.Size = new Size(205, 34);
            selectLanguageTableLayoutPanel.TabIndex = 0;
            // 
            // flagPictureBox
            // 
            flagPictureBox.Dock = DockStyle.Fill;
            flagPictureBox.Location = new Point(5, 5);
            flagPictureBox.Margin = new Padding(4);
            flagPictureBox.Name = "flagPictureBox";
            flagPictureBox.Size = new Size(41, 24);
            flagPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            flagPictureBox.TabIndex = 0;
            flagPictureBox.TabStop = false;
            // 
            // selectLanguageComboBox
            // 
            selectLanguageComboBox.BackColor = Color.Transparent;
            selectLanguageComboBox.BorderThickness = 0;
            selectLanguageComboBox.Cursor = Cursors.Hand;
            selectLanguageComboBox.CustomizableEdges = customizableEdges3;
            selectLanguageComboBox.Dock = DockStyle.Fill;
            selectLanguageComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            selectLanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectLanguageComboBox.FillColor = SystemColors.ButtonFace;
            selectLanguageComboBox.FocusedColor = Color.FromArgb(94, 148, 255);
            selectLanguageComboBox.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            selectLanguageComboBox.Font = new Font("Segoe UI", 10F);
            selectLanguageComboBox.ForeColor = SystemColors.WindowText;
            selectLanguageComboBox.ItemHeight = 30;
            selectLanguageComboBox.Location = new Point(51, 5);
            selectLanguageComboBox.Margin = new Padding(0, 4, 0, 0);
            selectLanguageComboBox.Name = "selectLanguageComboBox";
            selectLanguageComboBox.ShadowDecoration.CustomizableEdges = customizableEdges4;
            selectLanguageComboBox.Size = new Size(153, 36);
            selectLanguageComboBox.TabIndex = 0;
            selectLanguageComboBox.TextAlign = HorizontalAlignment.Center;
            selectLanguageComboBox.SelectedIndexChanged += SelectLanguageComboBoxSelectedIndexChanged;
            // 
            // recomendationsTableLayoutPanel
            // 
            recomendationsTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            recomendationsTableLayoutPanel.ColumnCount = 1;
            recomendationsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            recomendationsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 16F));
            recomendationsTableLayoutPanel.Dock = DockStyle.Fill;
            recomendationsTableLayoutPanel.Location = new Point(0, 128);
            recomendationsTableLayoutPanel.Margin = new Padding(0);
            recomendationsTableLayoutPanel.Name = "recomendationsTableLayoutPanel";
            recomendationsTableLayoutPanel.RowCount = 1;
            recomendationsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            recomendationsTableLayoutPanel.Size = new Size(846, 585);
            recomendationsTableLayoutPanel.TabIndex = 0;
            recomendationsTableLayoutPanel.TabStop = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 242, 196);
            ClientSize = new Size(1075, 715);
            Controls.Add(mainFormTableLayoutPanel);
            ForeColor = SystemColors.WindowText;
            Icon = Properties.Resources.logoIcon;
            MinimumSize = new Size(937, 685);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Resize += MainFormResize;
            mainFormTableLayoutPanel.ResumeLayout(false);
            menuBarTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            applicationSectionsTableLayoutPanel.ResumeLayout(false);
            applicationSectionsTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainPagePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)myProductsPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)favoritePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)myCollectionsPictureBox).EndInit();
            mainFormContentTableLayoutPanel.ResumeLayout(false);
            titleTableLayoutPanel.ResumeLayout(false);
            selectLanguageTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)flagPictureBox).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private TableLayoutPanel mainFormTableLayoutPanel;
        private TableLayoutPanel menuBarTableLayoutPanel;
        private PictureBox logoPictureBox;
        private TableLayoutPanel applicationSectionsTableLayoutPanel;
        private Label mainPageLabel;
        private Label myCollectionsLabel;
        private Label myProductsLabel;
        private Label favoriteLabel;
        private PictureBox mainPagePictureBox;
        private PictureBox myCollectionsPictureBox;
        private PictureBox myProductsPictureBox;
        private PictureBox favoritePictureBox;
        private TableLayoutPanel mainFormContentTableLayoutPanel;
        private TableLayoutPanel titleTableLayoutPanel;
        private TableLayoutPanel recomendationsTableLayoutPanel;
        private TableLayoutPanel selectLanguageTableLayoutPanel;
        private PictureBox flagPictureBox;
        private Guna.UI2.WinForms.Guna2ComboBox selectLanguageComboBox;
        private Guna.UI2.WinForms.Guna2Button exitButton;
        private Label accountStatusLabel;
    }
}