using ZONOupdate.ProjectControls.ControlForCollectionName;
using ZONOupdate.ProjectControls;
using ZONOupdate.EntityClasses;
using System.Drawing.Text;
using ZONOupdate.Database;
using Guna.UI2.WinForms;
using System.Resources;
using NLog;

namespace ZONOupdate.Forms.FormForMainWindow
{
    /// <summary>
    /// Класc, содержащий внешний вид формы MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Поля
        User currentUser;
        ResourceManager languageResources;
        MainFormFunctional mainFormFunctional;
        Logger logger = LogManager.GetCurrentClassLogger();
        List<Control> controlsForLocalization = new List<Control>();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        ResourceManager localizationResources = new ResourceManager("ZONOupdate" +
            ".Localization.Languages", typeof(MainForm).Assembly);
        #endregion

        #region Методы
        private void DeleteControlsFromTableLayoutPanels()
        {
            for (int i = titleTableLayoutPanel.Controls.Count - 1; i > 0; i--)
            {
                titleTableLayoutPanel.Controls[i].Dispose();
            }

            recomendationsTableLayoutPanel.Controls.Clear();
            controlsForLocalization.Clear();
        }
        #endregion

        #region События
        private void MainPageMouseDown(object? sender = null, MouseEventArgs? e = null)
        {
            if (mainPageLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Главная страница\"");

                DeleteControlsFromTableLayoutPanels();

                mainPageLabel.ForeColor = System.Drawing.Color.FromArgb(0, 139, 253);
                myCollectionsLabel.ForeColor = SystemColors.WindowText;
                myProductsLabel.ForeColor = SystemColors.WindowText;
                favoriteLabel.ForeColor = SystemColors.WindowText;

                var mainPageTitleLabel = new Label();
                mainPageTitleLabel.Name = "mainPageTitleLabel";
                mainPageTitleLabel.Font = new Font(fontCollection.Families[0], 30);
                mainPageTitleLabel.Margin = new Padding(25, 15, 0, 0);
                mainPageTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                mainPageTitleLabel.Text = languageResources.GetString(mainPageTitleLabel.Name);
                mainPageTitleLabel.AutoEllipsis = true;
                mainPageTitleLabel.AutoSize = true;
                titleTableLayoutPanel.Controls.Add(mainPageTitleLabel, 0, 0);
                controlsForLocalization.Add(mainPageTitleLabel);

                var filtersButton = new Guna2Button();
                filtersButton.Name = "filtersButton";
                filtersButton.Text = languageResources.GetString(filtersButton.Name);
                filtersButton.Font = new Font(fontCollection.Families[0], 14);
                filtersButton.FillColor = System.Drawing.Color.FromArgb(0, 166, 253);
                filtersButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                filtersButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                filtersButton.BorderRadius = 15;
                filtersButton.BorderThickness = 0;
                filtersButton.Margin = new Padding(38, 5, 0, 0);
                filtersButton.Size = new Size(230, 50);
                filtersButton.Cursor = Cursors.Hand;
                filtersButton.MouseDown += FiltersButtonMouseDown;
                titleTableLayoutPanel.Controls.Add(filtersButton, 0, 1);
                controlsForLocalization.Add(filtersButton);

                var searchLineTextBox = new Guna2TextBox();
                searchLineTextBox.Name = "searchLineTextBox";
                searchLineTextBox.Font = new Font(fontCollection.Families[0], 14);
                searchLineTextBox.PlaceholderText = languageResources
                    .GetString(searchLineTextBox.Name);
                searchLineTextBox.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
                searchLineTextBox.BorderRadius = 8;
                searchLineTextBox.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                searchLineTextBox.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
                searchLineTextBox.BorderThickness = 1;
                searchLineTextBox.TextOffset = new Point(10, 0);
                searchLineTextBox.PlaceholderForeColor = System.Drawing
                    .Color.FromArgb(151, 151, 151);
                searchLineTextBox.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                searchLineTextBox.IconRight = Properties.Resources.search;
                searchLineTextBox.IconRightCursor = Cursors.Hand;
                searchLineTextBox.IconRightSize = new Size(32, 32);
                searchLineTextBox.IconRightClick += SearchPictureClick;
                searchLineTextBox.Anchor = AnchorStyles.Right | AnchorStyles.Left;
                searchLineTextBox.Cursor = Cursors.IBeam;
                searchLineTextBox.Size = new Size(400, 45);
                searchLineTextBox.Margin = new Padding(10, 0, 49, 19);
                titleTableLayoutPanel.Controls.Add(searchLineTextBox, 1, 1);

                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowLayoutPanel";
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                productsFlowLayoutPanel.HorizontalScroll.Maximum = 0;
                productsFlowLayoutPanel.HorizontalScroll.Visible = false;
                productsFlowLayoutPanel.AutoScroll = true;
                recomendationsTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                var existingSetting = DatabaseInteraction
                    .LoadingSearchSettings(currentUser.ID);

                if (existingSetting != null)
                {
                    var loadresult = mainFormFunctional.FillingMainPageLayoutPanelWithSetting(productsFlowLayoutPanel,
                        existingSetting, currentUser.ID, languageResources);

                    if (!loadresult)
                    {
                        var exitWarningMessageDialog = new Guna2MessageDialog();
                        exitWarningMessageDialog.Buttons = MessageDialogButtons.OK;
                        exitWarningMessageDialog.Icon = MessageDialogIcon.Warning;
                        exitWarningMessageDialog.Style = MessageDialogStyle.Light;
                        exitWarningMessageDialog.Parent = this;
                        exitWarningMessageDialog.Caption = languageResources.GetString("errorLoadingProductsTitle");
                        exitWarningMessageDialog.Text = languageResources.GetString("errorLoadingProductsContent");

                        logger.Error("Товары не загрузились в таблицу в разделе \"Главная страница\"");
                    }

                    return;
                }

                var loadResult = mainFormFunctional.FillingMainPageLayoutPanel(productsFlowLayoutPanel,
                    currentUser.ID, languageResources);

                if (!loadResult)
                {
                    var exitWarningMessageDialog = new Guna2MessageDialog();
                    exitWarningMessageDialog.Buttons = MessageDialogButtons.OK;
                    exitWarningMessageDialog.Icon = MessageDialogIcon.Warning;
                    exitWarningMessageDialog.Style = MessageDialogStyle.Light;
                    exitWarningMessageDialog.Parent = this;
                    exitWarningMessageDialog.Caption = languageResources.GetString("errorLoadingProductsTitle");
                    exitWarningMessageDialog.Text = languageResources.GetString("errorLoadingProductsContent");

                    logger.Error("Товары не загрузились в таблицу в разделе \"Главная страница\"");
                }
            }
        }

        private void MyCollectionsPageMouseDown(object sender, MouseEventArgs e)
        {
            if (myCollectionsLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Мои подборки\"");

                DeleteControlsFromTableLayoutPanels();

                myCollectionsLabel.ForeColor = System.Drawing.Color.FromArgb(0, 139, 253);
                favoriteLabel.ForeColor = SystemColors.WindowText;
                mainPageLabel.ForeColor = SystemColors.WindowText;
                myProductsLabel.ForeColor = SystemColors.WindowText;

                var myCollectionsTitleLabel = new Label();
                myCollectionsTitleLabel.Name = "myCollectionsTitleLabel";
                myCollectionsTitleLabel.Font = new Font(fontCollection.Families[0], 30);
                myCollectionsTitleLabel.Margin = new Padding(25, 15, 0, 0);
                myCollectionsTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                myCollectionsTitleLabel.Text = languageResources
                    .GetString(myCollectionsTitleLabel.Name);
                myCollectionsTitleLabel.AutoEllipsis = true;
                myCollectionsTitleLabel.AutoSize = true;
                titleTableLayoutPanel.Controls.Add(myCollectionsTitleLabel, 0, 0);
                controlsForLocalization.Add(myCollectionsTitleLabel);

                var addNewCollectionButton = new Guna2Button();
                addNewCollectionButton.Name = "addNewCollectionButton";
                addNewCollectionButton.Text = languageResources.GetString(addNewCollectionButton.Name);
                addNewCollectionButton.Font = new Font(fontCollection.Families[0], 14);
                addNewCollectionButton.FillColor = System.Drawing.Color.FromArgb(0, 166, 253);
                addNewCollectionButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                addNewCollectionButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                addNewCollectionButton.BorderRadius = 15;
                addNewCollectionButton.BorderThickness = 0;
                addNewCollectionButton.Margin = new Padding(38, 5, 0, 0);
                addNewCollectionButton.Size = new Size(230, 50);
                addNewCollectionButton.Cursor = Cursors.Hand;
                addNewCollectionButton.MouseDown += AddNewCollectionButtonMouseDown;
                titleTableLayoutPanel.Controls.Add(addNewCollectionButton, 0, 1);
                controlsForLocalization.Add(addNewCollectionButton);

                var myCollectionTableLayoutPanel = new TableLayoutPanel();
                myCollectionTableLayoutPanel.Name = "myCollectionTableLayoutPanel";
                myCollectionTableLayoutPanel.RowCount = 1;
                myCollectionTableLayoutPanel.ColumnCount = 2;
                myCollectionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29));
                myCollectionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71));
                myCollectionTableLayoutPanel.Margin = new Padding(0);
                myCollectionTableLayoutPanel.Padding = new Padding(0);
                myCollectionTableLayoutPanel.Dock = DockStyle.Fill;
                myCollectionTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                recomendationsTableLayoutPanel.Controls.Add(myCollectionTableLayoutPanel);

                var listFlowLayoutPanel = new FlowLayoutPanel();
                listFlowLayoutPanel.Name = "listFlowLayoutPanel";
                listFlowLayoutPanel.Dock = DockStyle.Fill;
                listFlowLayoutPanel.Margin = new Padding(0);
                listFlowLayoutPanel.Padding = new Padding(0);
                listFlowLayoutPanel.HorizontalScroll.Maximum = 0;
                listFlowLayoutPanel.HorizontalScroll.Visible = false;
                listFlowLayoutPanel.AutoScroll = true;
                myCollectionTableLayoutPanel.Controls.Add(listFlowLayoutPanel, 0, 0);

                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowLayoutPanel";
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                productsFlowLayoutPanel.HorizontalScroll.Maximum = 0;
                productsFlowLayoutPanel.HorizontalScroll.Visible = false;
                productsFlowLayoutPanel.AutoScroll = true;
                myCollectionTableLayoutPanel.Controls.Add(productsFlowLayoutPanel, 1, 0);

                var loadResult = mainFormFunctional.FillingListFlowLayoutPanel(listFlowLayoutPanel,
                    productsFlowLayoutPanel, currentUser, languageResources);

                if (!loadResult)
                {
                    var exitWarningMessageDialog = new Guna2MessageDialog();
                    exitWarningMessageDialog.Buttons = MessageDialogButtons.OK;
                    exitWarningMessageDialog.Icon = MessageDialogIcon.Warning;
                    exitWarningMessageDialog.Style = MessageDialogStyle.Light;
                    exitWarningMessageDialog.Parent = this;
                    exitWarningMessageDialog.Caption = languageResources.GetString("errorLoadingProductsTitle");
                    exitWarningMessageDialog.Text = languageResources.GetString("errorLoadingProductsContent");

                    logger.Error("Подборки не загрузились в таблицу в разделе \"Мои подборки\"");
                }
            }
        }

        private void MyProductsPageMouseDown(object sender, MouseEventArgs e)
        {
            if (myProductsLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Мои товары\"");

                DeleteControlsFromTableLayoutPanels();

                myProductsLabel.ForeColor = System.Drawing.Color.FromArgb(0, 139, 253);
                myCollectionsLabel.ForeColor = SystemColors.WindowText;
                mainPageLabel.ForeColor = SystemColors.WindowText;
                favoriteLabel.ForeColor = SystemColors.WindowText;

                var myProductsTitleLabel = new Label();
                myProductsTitleLabel.Name = "myProductsTitleLabel";
                myProductsTitleLabel.Font = new Font(fontCollection.Families[0], 30);
                myProductsTitleLabel.Margin = new Padding(25, 15, 0, 0);
                myProductsTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                myProductsTitleLabel.Text = languageResources
                    .GetString(myProductsTitleLabel.Name);
                myProductsTitleLabel.AutoSize = true;
                myProductsTitleLabel.AutoEllipsis = true;
                titleTableLayoutPanel.Controls.Add(myProductsTitleLabel, 0, 0);
                controlsForLocalization.Add(myProductsTitleLabel);

                var addNewProductButton = new Guna2Button();
                addNewProductButton.Name = "addNewProductButton";
                addNewProductButton.Text = languageResources.GetString(addNewProductButton.Name);
                addNewProductButton.Font = new Font(fontCollection.Families[0], 14);
                addNewProductButton.FillColor = System.Drawing.Color.FromArgb(0, 166, 253);
                addNewProductButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                addNewProductButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                addNewProductButton.BorderRadius = 15;
                addNewProductButton.BorderThickness = 0;
                addNewProductButton.Margin = new Padding(38, 5, 0, 0);
                addNewProductButton.Size = new Size(230, 50);
                addNewProductButton.Cursor = Cursors.Hand;
                addNewProductButton.MouseDown += AddNewProductButtonMouseDown;
                titleTableLayoutPanel.Controls.Add(addNewProductButton, 0, 1);
                controlsForLocalization.Add(addNewProductButton);

                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowLayoutPanel";
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                productsFlowLayoutPanel.HorizontalScroll.Maximum = 0;
                productsFlowLayoutPanel.HorizontalScroll.Visible = false;
                productsFlowLayoutPanel.AutoScroll = true;
                recomendationsTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                var loadResult = mainFormFunctional.FillMyProductsLayoutPanel(productsFlowLayoutPanel,
                    currentUser.ID, languageResources);

                if (!loadResult)
                {
                    var exitWarningMessageDialog = new Guna2MessageDialog();
                    exitWarningMessageDialog.Buttons = MessageDialogButtons.OK;
                    exitWarningMessageDialog.Icon = MessageDialogIcon.Warning;
                    exitWarningMessageDialog.Style = MessageDialogStyle.Light;
                    exitWarningMessageDialog.Parent = this;
                    exitWarningMessageDialog.Caption = languageResources.GetString("errorLoadingProductsTitle");
                    exitWarningMessageDialog.Text = languageResources.GetString("errorLoadingProductsContent");

                    logger.Error("Товары не загрузились в таблицу в разделе \"Мои товары\"");
                }
            }
        }
        
        private void FavoritePageMouseDown(object sender, MouseEventArgs e)
        {
            if (favoriteLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Избранное\"");

                DeleteControlsFromTableLayoutPanels();

                favoriteLabel.ForeColor = System.Drawing.Color.FromArgb(0, 139, 253);
                myCollectionsLabel.ForeColor = SystemColors.WindowText;
                mainPageLabel.ForeColor = SystemColors.WindowText;
                myProductsLabel.ForeColor = SystemColors.WindowText;

                var favoritesTitleLabel = new Label();
                favoritesTitleLabel.Name = "favoritesTitleLabel";
                favoritesTitleLabel.Font = new Font(fontCollection.Families[0], 30);
                favoritesTitleLabel.Margin = new Padding(25, 15, 0, 0);
                favoritesTitleLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                favoritesTitleLabel.Text = languageResources
                    .GetString(favoritesTitleLabel.Name);
                favoritesTitleLabel.AutoEllipsis = true;
                favoritesTitleLabel.AutoSize = true;
                titleTableLayoutPanel.Controls.Add(favoritesTitleLabel, 0, 0);
                controlsForLocalization.Add(favoritesTitleLabel);

                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowLayoutPanel";
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                productsFlowLayoutPanel.HorizontalScroll.Maximum = 0;
                productsFlowLayoutPanel.HorizontalScroll.Visible = false;
                productsFlowLayoutPanel.AutoScroll = true;
                recomendationsTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                var loadResult = mainFormFunctional.FillFavoritesLayoutPanel(productsFlowLayoutPanel,
                    currentUser.ID, languageResources);

                if (!loadResult)
                {
                    var exitWarningMessageDialog = new Guna2MessageDialog();
                    exitWarningMessageDialog.Buttons = MessageDialogButtons.OK;
                    exitWarningMessageDialog.Icon = MessageDialogIcon.Warning;
                    exitWarningMessageDialog.Style = MessageDialogStyle.Light;
                    exitWarningMessageDialog.Parent = this;
                    exitWarningMessageDialog.Caption = languageResources.GetString("errorLoadingProductsTitle");
                    exitWarningMessageDialog.Text = languageResources.GetString("errorLoadingProductsContent");

                    logger.Error("Товары не загрузились в таблицу в разделе \"Избранное\"");
                }
            }
        }

        private void ExitLabelMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку \"Выход\"");

            var exitWarningMessageDialog = new Guna2MessageDialog();
            exitWarningMessageDialog.Buttons = MessageDialogButtons.YesNo;
            exitWarningMessageDialog.Icon = MessageDialogIcon.Question;
            exitWarningMessageDialog.Style = MessageDialogStyle.Light;
            exitWarningMessageDialog.Parent = this;
            exitWarningMessageDialog.Caption = languageResources.GetString("exitMessageTitle");
            exitWarningMessageDialog.Text = languageResources.GetString("exitMessageContent");
            DialogResult dialogResult = exitWarningMessageDialog.Show();

            if (dialogResult == DialogResult.Yes)
            {
                logger.Info($"Пользователь с id {currentUser.ID} вышел из своего аккаунта");

                Program.SetLoginInformation(true, currentUser.ID);

                Close();
            }
        }

        private void SearchPictureClick(object sender, EventArgs e)
        {
            var productsFlowLayoutPanel = recomendationsTableLayoutPanel.Controls
                .Find("productsFlowLayoutPanel", false).FirstOrDefault();
            var searchTextBox = sender as Guna2TextBox;

            if ((searchTextBox != null) && (productsFlowLayoutPanel != null))
            {
                string searchText = searchTextBox.Text.Trim().ToUpper();

                foreach (ProductControl control in productsFlowLayoutPanel.Controls)
                {
                    if (control.currentProduct.RecommendationName.ToUpper()
                        .Contains(searchText))
                    {
                        control.Visible = true;
                        continue;
                    }

                    control.Visible = false;
                }
            }
        }

        private void FiltersButtonMouseDown(object sender, MouseEventArgs e)
        {
            var filtersButton = sender as Guna2Button;

            if (filtersButton != null)
            {
                logger.Info("Пользователь включил раздел \"Фильтры\"");

                if (filtersButton.FillColor == System.Drawing.Color.FromArgb(0, 166, 253))
                {
                    var searchLineTextBox = titleTableLayoutPanel.Controls.Find
                        ("searchLineTextBox", false).FirstOrDefault();

                    if (searchLineTextBox != null)
                    {
                        searchLineTextBox.Dispose();
                    }

                    recomendationsTableLayoutPanel.Controls.Clear();
                    filtersButton.FillColor = System.Drawing.Color.FromArgb(251, 95, 95);

                    var filtersMenuTableLayoutPanel = new TableLayoutPanel();
                    filtersMenuTableLayoutPanel.Name = "filtersMenuTableLayoutPanel";
                    filtersMenuTableLayoutPanel.Dock = DockStyle.Fill;
                    filtersMenuTableLayoutPanel.ColumnCount = 3;
                    filtersMenuTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    filtersMenuTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
                    filtersMenuTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
                    filtersMenuTableLayoutPanel.Margin = new Padding(0);
                    filtersMenuTableLayoutPanel.Padding = new Padding(0);
                    titleTableLayoutPanel.Controls.Add(filtersMenuTableLayoutPanel, 1, 1);

                    var chooseProductTypeComboBox = new Guna2ComboBox();
                    chooseProductTypeComboBox.Name = "chooseProductTypeComboBox";
                    chooseProductTypeComboBox.Font = new Font(fontCollection.Families[0], 12);
                    chooseProductTypeComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    chooseProductTypeComboBox.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
                    chooseProductTypeComboBox.BorderRadius = 8;
                    chooseProductTypeComboBox.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    chooseProductTypeComboBox.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    chooseProductTypeComboBox.BorderThickness = 1;
                    chooseProductTypeComboBox.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    chooseProductTypeComboBox.Size = new Size(220, 50);
                    chooseProductTypeComboBox.Items.Add(languageResources.GetString(chooseProductTypeComboBox.Name));
                    chooseProductTypeComboBox.Items.AddRange(DatabaseInteraction.LoadProductTypes());
                    chooseProductTypeComboBox.SelectedIndex = 0;
                    chooseProductTypeComboBox.Margin = new Padding(0, 0, 10, 16);
                    chooseProductTypeComboBox.SelectedIndexChanged += ChangingIndexInChooseProductTypeComboBox;
                    filtersMenuTableLayoutPanel.Controls.Add(chooseProductTypeComboBox, 0, 0);

                    var restartButton = new Guna2Button();
                    restartButton.Name = "restartButton";
                    restartButton.Text = languageResources.GetString(restartButton.Name);
                    restartButton.Font = new Font(fontCollection.Families[0], 10);
                    restartButton.FillColor = System.Drawing.Color.FromArgb(0, 166, 253);
                    restartButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                    restartButton.Anchor = AnchorStyles.Right | AnchorStyles.Left;
                    restartButton.BorderRadius = 15;
                    restartButton.BorderThickness = 0;
                    restartButton.Margin = new Padding(3, 0, 10, 16);
                    restartButton.Size = new Size(100, 45);
                    restartButton.Cursor = Cursors.Hand;
                    restartButton.MouseDown += RestartButtonMouseDown;
                    filtersMenuTableLayoutPanel.Controls.Add(restartButton, 2, 0);
                    controlsForLocalization.Add(restartButton);

                    var applyButton = new Guna2Button();
                    applyButton.Name = "applyButton";
                    applyButton.Text = languageResources.GetString(applyButton.Name);
                    applyButton.Font = new Font(fontCollection.Families[0], 10);
                    applyButton.FillColor = System.Drawing.Color.FromArgb(0, 166, 253);
                    applyButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                    applyButton.Anchor = AnchorStyles.Right | AnchorStyles.Left;
                    applyButton.BorderRadius = 15;
                    applyButton.BorderThickness = 0;
                    applyButton.Margin = new Padding(3, 0, 10, 16);
                    applyButton.Size = new Size(100, 45);
                    applyButton.Cursor = Cursors.Hand;
                    applyButton.MouseDown += ApplyButtonMouseDown;
                    filtersMenuTableLayoutPanel.Controls.Add(applyButton, 1, 0);
                    controlsForLocalization.Add(applyButton);
                }
                else
                {
                    logger.Info("Пользователь выключил раздел \"Фильтры\"");

                    mainPageLabel.ForeColor = SystemColors.WindowText;
                    MainPageMouseDown();
                }
            }
        }

        private void SelectLanguageComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Пользователь сменил язык на {selectLanguageComboBox.SelectedValue}");

            switch (selectLanguageComboBox.SelectedIndex)
            {
                case 0:
                    languageResources = new ResourceManager("ZONOupdate.Localization.MainFormRU",
                        typeof(MainForm).Assembly);
                    break;
                case 1:
                    languageResources = new ResourceManager("ZONOupdate.Localization.MainFormEN",
                        typeof(MainForm).Assembly);
                    break;
            }

            foreach (var control in controlsForLocalization)
            {
                control.Text = languageResources.GetString(control.Name);
            }

            if (mainPageLabel.ForeColor == System.Drawing.Color.FromArgb(0, 139, 253))
            {
                var searchLineTextBox = titleTableLayoutPanel.Controls.Find("searchLineTextBox", false)
                    .FirstOrDefault() as Guna2TextBox;

                if (searchLineTextBox != null)
                {
                    searchLineTextBox.PlaceholderText = languageResources.GetString(searchLineTextBox.Name);
                }
            }

            var productsFlowLayoutPanel = recomendationsTableLayoutPanel.Controls
                .Find("productsFlowLayoutPanel", false).FirstOrDefault() as TableLayoutPanel;

            if (productsFlowLayoutPanel != null)
            {
                foreach (var control in productsFlowLayoutPanel.Controls)
                {
                    var productControl = control as ProductControl;

                    if (productControl != null)
                    {
                        productControl.ChangeLanguage(languageResources);
                    }
                }
            }

            var filtersMenuTableLayoutPanel = titleTableLayoutPanel
                .Controls["filtersMenuTableLayoutPanel"] as TableLayoutPanel;

            if (filtersMenuTableLayoutPanel != null)
            {
                var chooseProductTypeComboBox = filtersMenuTableLayoutPanel
                    .Controls["chooseProductTypeComboBox"] as ComboBox;

                if (chooseProductTypeComboBox != null)
                {
                    chooseProductTypeComboBox.Items.RemoveAt(0);
                    chooseProductTypeComboBox.Items.Insert(0, languageResources
                        .GetString(chooseProductTypeComboBox.Name));
                    chooseProductTypeComboBox.SelectedIndex = 0;
                }
            }

            mainPageLabel.Text = languageResources.GetString(mainPageLabel.Name);
            myCollectionsLabel.Text = languageResources.GetString(myCollectionsLabel.Name);
            myProductsLabel.Text = languageResources.GetString(myProductsLabel.Name);
            favoriteLabel.Text = languageResources.GetString(favoriteLabel.Name);
            exitButton.Text = languageResources.GetString(exitButton.Name);
            Text = languageResources.GetString(Name);
            flagPictureBox.Image = (Image)languageResources.GetObject("flag");

            logger.Info("Все элементы управления поменяли язык");
        }

        private void ApplyButtonMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку принять в разделе \"Фильтры\"");

            var resultOfSelection = mainFormFunctional.SelectionOfRecommendations(currentUser.ID);

            if (!resultOfSelection)
            {
                var selectionWarningMessageDialog = new Guna2MessageDialog();
                selectionWarningMessageDialog.Buttons = MessageDialogButtons.OK;
                selectionWarningMessageDialog.Icon = MessageDialogIcon.Warning;
                selectionWarningMessageDialog.Style = MessageDialogStyle.Light;
                selectionWarningMessageDialog.Parent = this;
                selectionWarningMessageDialog.Caption = languageResources.GetString("selectionWarningTitle");
                selectionWarningMessageDialog.Text = languageResources.GetString("selectionWarningContent");
                selectionWarningMessageDialog.Show();

                return;
            }

            mainPageLabel.ForeColor = SystemColors.WindowText;
            MainPageMouseDown();
        }

        private void RestartButtonMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку \"Начать заново\"");

            var filtersMenuTableLayoutPanel = titleTableLayoutPanel
                .Controls["filtersMenuTableLayoutPanel"] as TableLayoutPanel;

            if (filtersMenuTableLayoutPanel != null)
            {
                var chooseProductTypeComboBox = filtersMenuTableLayoutPanel
                    .Controls["chooseProductTypeComboBox"] as ComboBox;

                if (chooseProductTypeComboBox != null)
                {
                    recomendationsTableLayoutPanel.Controls.Clear();
                    chooseProductTypeComboBox.SelectedIndex = 0;
                }
            }
        }

        private void AddNewCollectionButtonMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку \"Создать подборку\"");

            var myCollectionTableLayoutPanel = recomendationsTableLayoutPanel.Controls
                ["myCollectionFlowLayoutPanel"] as FlowLayoutPanel;

            if (myCollectionTableLayoutPanel != null)
            {
                var listflowlayoutpanel = myCollectionTableLayoutPanel.Controls
                    ["listFlowLayoutPanel"] as FlowLayoutPanel;

                if (listflowlayoutpanel != null)
                {
                    using (var newCollectionCreationForm = new NewCollectionCreationForm(currentUser,
                        languageResources, listflowlayoutpanel))
                    {
                        newCollectionCreationForm.ShowDialog();
                    }
                }
            }
        }

        private void AddNewProductButtonMouseDown(object sender, MouseEventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при добавлении товара");

                var userWhoOccupiedTable = database.Users.Where(user => (user.IsBusy == 1)).FirstOrDefault();

                if (userWhoOccupiedTable != null)
                {
                    logger.Warn("База данных, к которой пытается обращаться пользователь" +
                        "сейчас недоступна");

                    var databaseIsBusyMessageDialog = new Guna2MessageDialog();
                    databaseIsBusyMessageDialog.Buttons = MessageDialogButtons.OK;
                    databaseIsBusyMessageDialog.Icon = MessageDialogIcon.Warning;
                    databaseIsBusyMessageDialog.Style = MessageDialogStyle.Light;
                    databaseIsBusyMessageDialog.Parent = this;
                    databaseIsBusyMessageDialog.Caption = languageResources.GetString("databaseIsBusyTitle");
                    databaseIsBusyMessageDialog.Text = languageResources.GetString("databaseIsBusyContent");
                    databaseIsBusyMessageDialog.Show();

                    return;
                }

                logger.Info($"Пользователь с id {currentUser.ID} подключился к базе данных");

                var thisUser = database.Users.Where(user => user.ID == currentUser.ID).FirstOrDefault();

                if (thisUser != null)
                {
                    thisUser.IsBusy = Convert.ToInt32(true);
                    database.SaveChanges();

                    using (var newProductForm = new NewProductCreationForm(currentUser.ID, languageResources))
                    {
                        newProductForm.ShowDialog();
                    }

                    logger.Info($"Пользователь с id {currentUser.ID} отключился от базы данных");

                    thisUser.IsBusy = Convert.ToInt32(false);

                    database.SaveChanges();
                }
            }
        }

        private void ChangingIndexInChooseProductTypeComboBox(object sender, EventArgs e)
        {
            logger.Info("Пользователь выбрал тип товара в разделе \"Фильтры\"");

            var chooseProductTypeComboBox = sender as Guna2ComboBox;

            if (chooseProductTypeComboBox != null)
            {
                recomendationsTableLayoutPanel.Controls.Clear();

                if (chooseProductTypeComboBox.SelectedIndex <= 0)
                {
                    return;
                }

                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowLayoutPanel";
                productsFlowLayoutPanel.AutoScroll = true;
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                recomendationsTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                using (var database = new DatabaseContext())
                {
                    var productTypes = database.ProductTypes.OrderBy(product => product.ProductTypeName)
                        .Select(product => product.ProductTypeID).ToArray();
                    var selectedTypeIndex = chooseProductTypeComboBox.SelectedIndex;
                    var selectedType = productTypes[selectedTypeIndex - 1];

                    var products = database.Recommendations.Where(product => product
                    .ProductTypeID == selectedType).ToList();
                    var randomProducts = products.OrderBy(product => Guid.NewGuid()).Take(5).ToArray();
                    var controlsForFilters = new List<ProductControl>();

                    foreach (var product in randomProducts)
                    {
                        var control = new ProductControl(product, currentUser.ID, languageResources);
                        control.MakeProductControlForFilters(productsFlowLayoutPanel.Width);
                        controlsForFilters.Add(control);
                    }

                    productsFlowLayoutPanel.Controls.AddRange(controlsForFilters.ToArray());
                }
            }
        }

        private void MainFormResize(object sender, EventArgs e)
        {
            var productsFlowLayoutPanel = recomendationsTableLayoutPanel.Controls
                .Find("productsFlowLayoutPanel", true).FirstOrDefault();

            var listFlowLayoutPanel = recomendationsTableLayoutPanel.Controls
                .Find("listFlowLayoutPanel", true).FirstOrDefault();

            if (productsFlowLayoutPanel != null)
            {
                productsFlowLayoutPanel.Width = Width - menuBarTableLayoutPanel.Width;
                recomendationsTableLayoutPanel.Width = Width - menuBarTableLayoutPanel.Width;

                foreach (var product in productsFlowLayoutPanel.Controls)
                {
                    var productControl = product as ProductControl;

                    if (productControl != null)
                    {
                        productControl.Width = Width - menuBarTableLayoutPanel.Width;
                    }
                }
            }

            if ((listFlowLayoutPanel != null) && (productsFlowLayoutPanel != null))
            {
                listFlowLayoutPanel.Width = Width - menuBarTableLayoutPanel.Width
                    - productsFlowLayoutPanel.Width;
                recomendationsTableLayoutPanel.Width = Width - menuBarTableLayoutPanel.Width;

                foreach (var product in listFlowLayoutPanel.Controls)
                {
                    var productControl = product as CollectionNameControl;

                    if (productControl != null)
                    {
                        productControl.Width = Width - menuBarTableLayoutPanel.Width
                            - productsFlowLayoutPanel.Width;
                    }
                }
            }
        }
        #endregion

        #region Конструкторы
        public MainForm(Guid userID, object languageName, ResourceManager languageResources)
        {
            logger.Info("Открылась основная форма программы");

            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            currentUser = DatabaseInteraction.FindUser(userID);
            mainFormFunctional = new MainFormFunctional();
            this.languageResources = languageResources;
            InitializeComponent();

            MainPageMouseDown(currentUser);
            selectLanguageComboBox.Items.AddRange(new string[] { localizationResources.GetString("RU"),
                localizationResources.GetString("EN") });
            selectLanguageComboBox.SelectedItem = languageName;

            mainPageLabel.Font = new Font(fontCollection.Families[0], 14);
            myCollectionsLabel.Font = new Font(fontCollection.Families[0], 14);
            myProductsLabel.Font = new Font(fontCollection.Families[0], 14);
            favoriteLabel.Font = new Font(fontCollection.Families[0], 14);
            exitButton.Font = new Font(fontCollection.Families[0], 14);
            selectLanguageComboBox.Font = new Font(fontCollection.Families[0], 14);
        }
        #endregion
    }
}