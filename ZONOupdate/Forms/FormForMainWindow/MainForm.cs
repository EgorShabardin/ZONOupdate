using Guna.UI2.WinForms;
using NLog;
using System.Drawing.Text;
using System.Resources;
using ZONOupdate.Database;
using ZONOupdate.EntityClasses;
using ZONOupdate.ProjectControls;

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
        FlowLayoutPanel productsFlowLayoutPanel = new FlowLayoutPanel();
        ResourceManager localizationResources = new ResourceManager("ZONOupdate.Localization.Languages", typeof(MainForm).Assembly);
        #endregion

        #region Методы
        private void DeleteControlsFromTitleTableLayoutPanel()
        {
            for (int i = titleTableLayoutPanel.Controls.Count - 1; i > 0; i--)
            {
                titleTableLayoutPanel.Controls[i].Dispose();
            }
        }
        #endregion

        #region События
        private void MainPageMouseDown(object? sender = null, MouseEventArgs? e = null)
        {
            if (mainPageLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Главная страница\"");

                controlsForLocalization.Clear();
                DeleteControlsFromTitleTableLayoutPanel();
                recomendationsTableLayoutPanel.Controls.Clear();

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
                productsFlowLayoutPanel.Name = "productsFlowTable";
                productsFlowLayoutPanel.AutoScroll = true;
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                recomendationsTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                var existingSetting = DatabaseInteraction
                    .LoadingSearchSettings(currentUser.ID);

                if (existingSetting != null)
                {
                    mainFormFunctional.FillingMainPageLayoutPanelWithSetting(productsFlowLayoutPanel,
                        existingSetting, currentUser.ID, languageResources);

                    return;
                }

                mainFormFunctional.FillingMainPageLayoutPanel(productsFlowLayoutPanel,
                    currentUser.ID, languageResources);
            }
        }

        private void MyCollectionsPageMouseDown(object sender, MouseEventArgs e)
        {
            if (myCollectionsLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Мои подборки\"");

                controlsForLocalization.Clear();
                DeleteControlsFromTitleTableLayoutPanel();
                recomendationsTableLayoutPanel.Controls.Clear();

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

                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowTable";
                productsFlowLayoutPanel.AutoScroll = true;
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                myCollectionTableLayoutPanel.Controls.Add(productsFlowLayoutPanel, 1, 0);

                var listflowlayoutpanel = new FlowLayoutPanel();
                listflowlayoutpanel.Name = "listflowlayoutpanel";
                listflowlayoutpanel.AutoScroll = true;
                listflowlayoutpanel.Dock = DockStyle.Fill;
                listflowlayoutpanel.Margin = new Padding(0);
                listflowlayoutpanel.Padding = new Padding(0);
                myCollectionTableLayoutPanel.Controls.Add(listflowlayoutpanel, 0, 0);

                mainFormFunctional.FillingListFlowLayoutPanel(listflowlayoutpanel,
                    productsFlowLayoutPanel, currentUser, languageResources);
            }
        }

        private void MyProductsPageMouseDown(object sender, MouseEventArgs e)
        {
            if (myProductsLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Мои товары\"");

                controlsForLocalization.Clear();
                DeleteControlsFromTitleTableLayoutPanel();
                recomendationsTableLayoutPanel.Controls.Clear();

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
                productsFlowLayoutPanel.Name = "productsFlowTable";
                productsFlowLayoutPanel.AutoScroll = true;
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                recomendationsTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                mainFormFunctional.FillMyProductsLayoutPanel(productsFlowLayoutPanel,
                    currentUser.ID, languageResources);
            }
        }

        private void FavoritePageMouseDown(object sender, MouseEventArgs e)
        {
            if (favoriteLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Избранное\"");

                controlsForLocalization.Clear();
                DeleteControlsFromTitleTableLayoutPanel();
                recomendationsTableLayoutPanel.Controls.Clear();

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
                productsFlowLayoutPanel.Name = "productsFlowTable";
                productsFlowLayoutPanel.AutoScroll = true;
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                recomendationsTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                mainFormFunctional.FillFavoritesLayoutPanel(productsFlowLayoutPanel,
                    currentUser.ID, languageResources);
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
                .Find("productsFlowTable", false).FirstOrDefault();
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
                    filtersMenuTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
                    filtersMenuTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                    filtersMenuTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
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

                    chooseProductTypeComboBox.Items.Add(languageResources.GetString("chooseProductTypeComboBox"));
                    chooseProductTypeComboBox.Items.AddRange(DatabaseInteraction.LoadProductTypes());
                    chooseProductTypeComboBox.SelectedIndex = 0;
                    chooseProductTypeComboBox.SelectedIndexChanged += ChangingIndexInChooseProductTypeComboBox;
                    filtersMenuTableLayoutPanel.Controls.Add(chooseProductTypeComboBox, 0, 0);

                    var restartButton = new Button();
                    restartButton.BackColor = System.Drawing.Color.DeepSkyBlue;
                    restartButton.ForeColor = SystemColors.ButtonHighlight;
                    restartButton.Location = new Point(442, 208);
                    restartButton.Margin = new Padding(4);
                    restartButton.Name = "restartButton";
                    restartButton.Size = new Size(161, 44);
                    restartButton.TabIndex = 7;
                    restartButton.Text = "Начать заново";
                    restartButton.UseVisualStyleBackColor = false;
                    restartButton.Click += ClickOnRestartButton;
                    filtersMenuTableLayoutPanel.Controls.Add(restartButton, 2, 0);

                    var applyButton = new Button();
                    applyButton.BackColor = System.Drawing.Color.DeepSkyBlue;
                    applyButton.ForeColor = SystemColors.ButtonHighlight;
                    applyButton.Location = new Point(788, 208);
                    applyButton.Margin = new Padding(4);
                    applyButton.Name = "applyButton";
                    applyButton.Size = new Size(161, 44);
                    applyButton.TabIndex = 8;
                    applyButton.Text = "Применить";
                    applyButton.UseVisualStyleBackColor = false;
                    applyButton.Click += ClickOnApplyButton;
                    filtersMenuTableLayoutPanel.Controls.Add(applyButton, 1, 0);
                }
                else
                {
                    mainPageLabel.ForeColor = SystemColors.WindowText;
                    MainPageMouseDown();
                }
            }
        }

        private void AddNewProductButtonMouseDown(object sender, MouseEventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при добавлении товара");

                var users = database.Users.Where(x => x.IsBusy == 1 && x.ID != currentUser.ID).FirstOrDefault();

                if (users != null)
                {
                    logger.Warn("База данных, к которой пытается обращаться пользователь сейчас недоступна");

                    MessageBox.Show(languageResources.GetString("databaseIsBusyContent"),
                        languageResources.GetString("databaseIsBusyTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var thisUser = database.Users.Where(user => user.ID == currentUser.ID).FirstOrDefault();

                if (thisUser != null)
                {
                    logger.Info($"Пользователь с id {currentUser.ID} подключился к базе данных");

                    thisUser.IsBusy = Convert.ToInt32(true);
                    database.SaveChanges();
                }

                using (var newProductForm = new NewProductCreationForm(currentUser.ID, languageResources))
                {
                    newProductForm.ShowDialog();
                }

                if (thisUser != null)
                {
                    logger.Info($"Пользователь с id {currentUser.ID} отключился к базе данных");

                    thisUser.IsBusy = Convert.ToInt32(false);
                }

                database.SaveChanges();
            }
        }

        private void AddNewCollectionButtonMouseDown(object sender, MouseEventArgs e)
        {
            var myCollectionTableLayoutPanel = recomendationsTableLayoutPanel.Controls
                ["myCollectionTableLayoutPanel"] as TableLayoutPanel;
            if (myCollectionTableLayoutPanel != null)
            {
                var listflowlayoutpanel = myCollectionTableLayoutPanel.Controls
                    ["listflowlayoutpanel"] as FlowLayoutPanel;

                if (listflowlayoutpanel != null)
                {
                    using (var newCollectionCreationForm = new NewCollectionCreationForm(currentUser,
                        languageResources, listflowlayoutpanel))
                    {
                        logger.Info("Успешное подключение к базе данных при добавлении новой подборки");

                        newCollectionCreationForm.ShowDialog();
                    }
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
                .Find("productsFlowTable", false).FirstOrDefault() as FlowLayoutPanel;

            if (productsFlowLayoutPanel != null)
            {
                foreach(var control in productsFlowLayoutPanel.Controls)
                {
                    var productControl = control as ProductControl;

                    if (productControl != null) 
                    {
                        productControl.ChangeLanguage(languageResources);
                    }
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

        

        

        private void ClickOnApplyButton(object sender, EventArgs e)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    if (database.LikedProducts.Where(product => product.ID == currentUser.ID).Count() <= 0)
                    {
                        MessageBox.Show("Пожалуйста, выберите больше товаров или загрузите новые нажав на кнопку \"Начать заново\"",
                            "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var existingSetting = database.RecommendationSettings.Where(setting => setting.ID == currentUser.ID).FirstOrDefault();

                    if (existingSetting != null)
                    {
                        database.RecommendationSettings.Remove(existingSetting);
                        database.SaveChanges();
                    }
                    var likedProducts = database.LikedProducts.Where(product => product.ID == currentUser.ID).
                        Select(product => product.RecommendationID).ToList();

                    var years = new List<int>();
                    var prices = new List<int>();
                    var colors = new List<string>();
                    var manufacturers = new List<string>();

                    foreach (var likedproduct in likedProducts)
                    {
                        var product = database.Recommendations.Where(product => product.RecommendationId == likedproduct).FirstOrDefault();

                        if (product != null)
                        {
                            years.Add(product.YearOfProduction);
                            prices.Add(product.ProductPriceFrom);

                            var color = database.Colors.Where(color => color.ColorID == product.ColorID)
                                .Select(color => color.ColorName).FirstOrDefault();
                            var manufacturer = database.Manufacturers.Where(manufacturer => manufacturer.ManufacturerID
                            == product.ManufacturerID).Select(manufacturer => manufacturer.ManufacturerName).FirstOrDefault();

                            if (color != null && manufacturer != null)
                            {
                                colors.Add(color);
                                manufacturers.Add(manufacturer);
                            }
                        }
                    }
                    years.Sort();
                    prices.Sort();

                    string colorTemp = string.Empty;
                    string manufacturerTemp = string.Empty;

                    for (int i = 0; i < colors.Count; i++)
                    {
                        colorTemp += colors[i];
                        manufacturerTemp += manufacturers[i];
                        if (i != colors.Count - 1)
                        {
                            colorTemp += "/";
                            manufacturerTemp += "/";
                        }
                    }

                    var selectedTypeID = database.Recommendations.Where(product => product.RecommendationId == likedProducts.First())
                        .Select(product => product.ProductTypeID).FirstOrDefault();

                    var recommendationSetting = new RecommendationSetting()
                    {
                        RecommendationSettingID = Guid.NewGuid(),
                        ID = currentUser.ID,
                        MinPrice = prices.Min(),
                        MaxPrice = prices.Max(),
                        MinYear = years.Min(),
                        MaxYear = years.Max(),
                        SelectedColors = colorTemp,
                        SelectedManufacturers = manufacturerTemp,
                        SelectedTypeID = selectedTypeID
                    };

                    database.Add(recommendationSetting);
                    database.SaveChanges();

                    CleanLikedProducts();

                    MessageBox.Show("Спасибо за выбор понравившихся товаров, мы учтем ваши предпочтения!", "Внимание!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка. Код ошибки: {ex}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CleanLikedProducts()
        {
            using (var database = new DatabaseContext())
            {
                var likedProducts = database.LikedProducts.Where(product => product.ID == currentUser.ID).ToList();

                foreach (var product in likedProducts)
                {
                    database.LikedProducts.Remove(product);

                }
                database.SaveChanges();
            }
        }

        private void ChangingIndexInChooseProductTypeComboBox(object sender, EventArgs e)
        {
            var chooseProductTypeComboBox = sender as ComboBox;

            if (chooseProductTypeComboBox != null)
            {

                if (chooseProductTypeComboBox.SelectedIndex <= 0)
                {
                    return;
                }

                recomendationsTableLayoutPanel.Controls.Clear();
                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowTable";
                productsFlowLayoutPanel.AutoScroll = true;
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                recomendationsTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                using (var database = new DatabaseContext())
                {
                    var productTypes = database.ProductTypes.AsEnumerable().Select(x => x.ProductTypeID).ToList();
                    var selectedTypeIndex = chooseProductTypeComboBox.SelectedIndex;
                    var selectedType = productTypes[selectedTypeIndex - 1];

                    var products = database.Recommendations.Where(x => x.ProductTypeID == selectedType).ToList();
                    var randomProducts = products.OrderBy(x => Guid.NewGuid()).Take(5).ToList();

                    foreach (var product in randomProducts)
                    {
                        var control = new ProductControl(product, currentUser.ID, languageResources);
                        control.MakeProductControlForFilters(productsFlowLayoutPanel.Width);
                        productsFlowLayoutPanel.Controls.Add(control);
                    }
                }
            }
        }

        private void ClickOnRestartButton(object sender, EventArgs e)
        {
            var filtersMenuTableLayoutPanel = titleTableLayoutPanel.Controls["filtersMenuTableLayoutPanel"] as TableLayoutPanel;

            if (filtersMenuTableLayoutPanel != null)
            {
                var chooseProductTypeComboBox = filtersMenuTableLayoutPanel.Controls["chooseProductTypeComboBox"] as ComboBox;

                if (chooseProductTypeComboBox != null)
                {
                    try
                    {
                        if (chooseProductTypeComboBox.SelectedIndex != 0)
                        {
                            productsFlowLayoutPanel.Controls.Clear();

                            using (var database = new DatabaseContext())
                            {
                                var productTypes = database.ProductTypes.AsEnumerable().Select(x => x.ProductTypeID).ToList();
                                var selectedTypeIndex = chooseProductTypeComboBox.SelectedIndex;
                                var selectedType = productTypes[selectedTypeIndex - 1];

                                var products = database.Recommendations.Where(x => x.ProductTypeID == selectedType).ToList();
                                var randomProducts = products.OrderBy(x => Guid.NewGuid()).Take(5).ToList();

                                foreach (var product in randomProducts)
                                {
                                    var control = new ProductControl(product, currentUser.ID, languageResources);
                                    control.MakeProductControlForFilters(productsFlowLayoutPanel.Width);
                                    productsFlowLayoutPanel.Controls.Add(control);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Для того чтобы начать заново, нужно выбрать тип товара!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Возникла ошибка. Код ошибки: {ex}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        logger.Error($"При работе приложение произошла ошибка: {ex}");
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