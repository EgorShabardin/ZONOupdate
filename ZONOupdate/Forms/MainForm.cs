using NLog;
using System.Drawing.Text;
using System.Resources;
using ZONOupdate.Database;
using ZONOupdate.EntityClasses;
using ZONOupdate.Forms;
using ZONOupdate.ProjectControls;
using ZONOupdate.ProjectControls.ControlForCollectionName;

namespace ZONOupdate
{
    /// <summary>
    /// Класс основной формы системы
    /// </summary>
    public partial class MainForm : Form
    {
        #region Поля
        User currentUser;
        bool isFiltersOn = false;
        ResourceManager languageResources;
        Logger logger = LogManager.GetCurrentClassLogger();
        List<Control> controlsForLocalization = new List<Control>();
        FlowLayoutPanel productsFlowLayoutPanel = new FlowLayoutPanel();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        ResourceManager localizationResources = new ResourceManager("ZONOupdate.Localization.Languages", typeof(MainForm).Assembly);
        #endregion

        #region Методы
        /// <summary>
        /// Метод заполнения таблицы flowLayoutPanel на главной странице с учетом предпочтений пользователя
        /// </summary>
        /// <param name="productsFlowLayoutPanel">Таблица с товарами</param>
        public void FillingMainPageLayoutPanelWithSetting(FlowLayoutPanel productsFlowLayoutPanel, RecommendationSetting setting)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    var selectedColorsArray = setting.SelectedColors.Split('/').ToList();

                    var selectedManufacturersArray = setting.SelectedManufacturers.Split('/').ToList();

                    var colorGuids = database.Colors.Where(color => selectedColorsArray.
                    Contains(color.ColorName)).Select(color => color.ColorID).ToList();

                    var manufacturerGuids = database.Manufacturers.Where(manufacturer => selectedManufacturersArray
                    .Contains(manufacturer.ManufacturerName)).Select(manufacturer => manufacturer.ManufacturerID).ToList();

                    var productTypeID = setting.SelectedTypeID;

                    var allrecommendations = database.Recommendations.Where(product => product.ProductPriceFrom >= setting.MinPrice)
                            .Where(product => product.ProductPriceFrom <= setting.MaxPrice)
                            .Where(product => product.ProductTypeID == productTypeID)
                            .Where(product => product.YearOfProduction >= setting.MinYear)
                            .Where(product => product.YearOfProduction <= setting.MaxYear)
                            .Where(product => colorGuids.Contains(product.ColorID)).ToList()
                            .Where(product => manufacturerGuids.Contains(product.ManufacturerID));
                            


                    if (allrecommendations != null)
                    {
                        foreach (var product in allrecommendations)
                        {
                            var control = new ProductControl(product, currentUser.ID, languageResources);
                            control.MakeProductControlForMainPageOrForFavorites(productsFlowLayoutPanel.Width);
                            productsFlowLayoutPanel.Controls.Add(control);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нам не удалось распознать ваши предпочтения. Пожалуйста выберите понравившиеся товары заново",
                            "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нам не удалось распознать ваши предпочтения. Пожалуйста выберите понравившиеся товары заново",
                            "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                logger.Error($"При работе приложение произошла ошибка: {ex}");
            }
        }

        /// <summary>
        /// Метод заполнения таблицы flowLayoutPanel на главной странице
        /// </summary>
        /// <param name="productsFlowLayoutPanel">Таблица с товарами</param>
        public void FillingMainPageLayoutPanel(FlowLayoutPanel productsFlowLayoutPanel)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при нажатии на раздел \"Главная страница\"");

                var recommendations = database.Recommendations.ToList();

                logger.Debug($"Из базы данных загружено {recommendations.Count} записей");

                foreach (var product in recommendations)
                {
                    var recomendation = new ProductControl(product, currentUser.ID, languageResources);
                    recomendation.MakeProductControlForMainPageOrForFavorites(productsFlowLayoutPanel.ClientSize.Width);
                    productsFlowLayoutPanel.Controls.Add(recomendation);
                }
            }
        }
        /// <summary>
        /// Метод заполнения таблицы flowLayoutPanel на странице Мои товары
        /// </summary>
        /// <param name="productsFlowLayoutPanel">Таблица с товарами</param>
        public void FillMyProductsLayoutPanel(FlowLayoutPanel productsFlowLayoutPanel)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при нажатии на раздел \"Мои товары\"");

                var myProducts = database.Recommendations.Where(product => product.ID == currentUser.ID).ToList();

                logger.Debug($"Из базы данных загружено {myProducts.Count} записей");

                foreach (var product in myProducts)
                {
                    var productControl = new ProductControl(product, currentUser.ID, languageResources);
                    productControl.MakeProductControlForMyProducts(productsFlowLayoutPanel.ClientRectangle.Width);
                    productsFlowLayoutPanel.Controls.Add(productControl);
                }
            }
        }

        /// <summary>
        /// Метод заполнения таблицы flowLayoutPanel на странице избранное
        /// </summary>
        /// <param name="productsFlowLayoutPanel">Таблица с товарами</param>
        private void FillFavoritesLayoutPanel(FlowLayoutPanel productsFlowLayoutPanel)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при нажатии на раздел \"Избранное\"");

                var favoritesID = database.Favorites.Where(favorite => favorite.ID == currentUser.ID)
                    .Select(favorite => favorite.RecommendationID).ToList();

                logger.Debug($"Из базы данных загружено {favoritesID.Count} записей");

                foreach (var favoriteID in favoritesID)
                {
                    var product = database.Recommendations.Where(recomendation => recomendation
                    .RecommendationId == favoriteID).First();
                    var favoriteControl = new ProductControl(product, currentUser.ID, languageResources);
                    favoriteControl.MakeProductControlForMainPageOrForFavorites(productsFlowLayoutPanel.ClientSize.Width);
                    productsFlowLayoutPanel.Controls.Add(favoriteControl);
                }
            }
        }
        /// <summary>
        /// Метод заполнения списка подборок пользователя
        /// </summary>
        /// <param name="productsFlowLayoutPanel">Таблица с товарами</param>
        public void FillingListFlowLayoutPanel(FlowLayoutPanel listFlowLayoutPanel, FlowLayoutPanel productsFlowLayoutPanel)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при нажатии на раздел \"Мои подборки\"");

                var collections = database.UserCollections.Where(collection => collection.ID == currentUser.ID).ToList();

                logger.Debug($"Из базы данных загружено {collections.Count} записей");

                foreach (var collection in collections)
                {
                    var collectionControl = new CollectionNameControl(currentUser, collection, productsFlowLayoutPanel,
                        languageResources, listFlowLayoutPanel.ClientRectangle.Width);
                    listFlowLayoutPanel.Controls.Add(collectionControl);
                }
            }
        }

        private void DeleteControlsFromMainTableLayoutPanel()
        {
            for (int i = mainTableLayoutPanel.Controls.Count - 1; i > 0; i--)
            {
                mainTableLayoutPanel.Controls[i].Dispose();
            }
        }
        #endregion

        #region События
        private void ChangedSearchTextBox(object sender, EventArgs e)
        {
            var searchTextBox = sender as TextBox;

            if (searchTextBox != null)
            {
                string searchText = searchTextBox.Text.Trim().ToUpper();

                foreach (ProductControl control in productsFlowLayoutPanel.Controls)
                {
                    if (control.currentProduct.RecommendationName.ToUpper().Contains(searchText))
                    {
                        control.Visible = true;
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
            }
        }

        private void ClickOnExitLabel(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку \"Выход\"");

            if (MessageBox.Show(languageResources.GetString("exitMessageContent"), 
                languageResources.GetString("exitMessageTitle"), MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                logger.Info($"Пользователь с id {currentUser.ID} вышел из своего аккаунта");

                Program.SetLoginInformation(true, currentUser.ID);
                Close();
            }
        }

        private void ClickOnMainPage(object? sender = null, MouseEventArgs? e = null)
        {
            if (mainPageLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Главная страница\"");

                controlsForLocalization.Clear();
                DeleteControlsFromMainTableLayoutPanel();
                secondaryTableLayoutPanel.Controls.Clear();

                mainPageLabel.ForeColor = System.Drawing.Color.FromArgb(0, 139, 253);
                myCollectionsLabel.ForeColor = SystemColors.WindowText;
                myProductsLabel.ForeColor = SystemColors.WindowText;
                favoriteLabel.ForeColor = SystemColors.WindowText;

                var mainPageTitleLabel = new Label();
                mainPageTitleLabel.Name = "mainPageTitleLabel";
                mainPageTitleLabel.Font = new Font(fontCollection.Families[0], 30);
                mainPageTitleLabel.Margin = new Padding(25, 11, 0, 0);
                mainPageTitleLabel.Dock = DockStyle.Fill;
                mainPageTitleLabel.Text = languageResources.GetString(mainPageTitleLabel.Name);
                mainTableLayoutPanel.Controls.Add(mainPageTitleLabel, 0, 0);
                controlsForLocalization.Add(mainPageTitleLabel);

                var filtersButton = new Button();
                filtersButton.Name = "filtersButton";
                filtersButton.Text = languageResources.GetString(filtersButton.Name);
                filtersButton.Font = new Font(fontCollection.Families[0], 14);
                filtersButton.BackColor = System.Drawing.Color.FromArgb(0, 166, 253);
                filtersButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                filtersButton.Dock = DockStyle.Fill;
                filtersButton.Margin = new Padding(40, 0, 220, 50);
                filtersButton.Cursor = Cursors.Hand;
                filtersButton.MouseDown += ClickOnFiltersButton;
                mainTableLayoutPanel.Controls.Add(filtersButton, 0, 1);
                controlsForLocalization.Add(filtersButton);

                var searchTableLayoutPanel = new TableLayoutPanel();
                searchTableLayoutPanel.Name = "searchTableLayoutPanel";
                searchTableLayoutPanel.ColumnCount = 2;
                searchTableLayoutPanel.RowCount = 1;
                searchTableLayoutPanel.Dock = DockStyle.Fill;
                searchTableLayoutPanel.Margin = new Padding(0);
                searchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));
                searchTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                mainTableLayoutPanel.Controls.Add(searchTableLayoutPanel, 1, 1);

                var searchLineTextBox = new TextBox();
                searchLineTextBox.Name = "searchLineTextBox";
                searchLineTextBox.PlaceholderText = languageResources.GetString(searchLineTextBox.Name);
                searchLineTextBox.Font = new Font(fontCollection.Families[0], 14);
                searchLineTextBox.BorderStyle = BorderStyle.FixedSingle;
                searchLineTextBox.Dock = DockStyle.Fill;
                searchLineTextBox.Margin = new Padding(5, 10, 0, 0);
                searchLineTextBox.TextChanged += ChangedSearchTextBox;
                searchTableLayoutPanel.Controls.Add(searchLineTextBox, 0, 0);

                var searchPictureBox = new PictureBox();
                searchPictureBox.Name = "searchPictureBox";
                searchPictureBox.Image = Properties.Resources.search;
                searchPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                searchPictureBox.Size = new Size(35, 35);
                searchPictureBox.Margin = new Padding(15, 10, 0, 0);
                searchPictureBox.Cursor = Cursors.Hand;
                searchTableLayoutPanel.Controls.Add(searchPictureBox, 1, 0);

                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowTable";
                productsFlowLayoutPanel.AutoScroll = true;
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                secondaryTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                productsFlowLayoutPanel.Controls.Clear();

                using (var database = new DatabaseContext())
                {
                    var existingSetting = database.RecommendationSettings.Where(setting => setting.ID == currentUser.ID).FirstOrDefault();

                    if (existingSetting != null)
                    {
                        FillingMainPageLayoutPanelWithSetting(productsFlowLayoutPanel, existingSetting);
                    }
                    else
                    {
                        FillingMainPageLayoutPanel(productsFlowLayoutPanel);
                    }
                }
            }
        }

        private void ClickOnMyCollectionsPage(object sender, MouseEventArgs e)
        {
            if (myCollectionsLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Мои подборки\"");

                controlsForLocalization.Clear();
                secondaryTableLayoutPanel.Controls.Clear();
                DeleteControlsFromMainTableLayoutPanel();

                myCollectionsLabel.ForeColor = System.Drawing.Color.FromArgb(0, 139, 253);
                favoriteLabel.ForeColor = SystemColors.WindowText;
                mainPageLabel.ForeColor = SystemColors.WindowText;
                myProductsLabel.ForeColor = SystemColors.WindowText;

                var myCollectionsTitleLabel = new Label();
                myCollectionsTitleLabel.Name = "myCollectionsTitleLabel";
                myCollectionsTitleLabel.Font = new Font(fontCollection.Families[0], 30);
                myCollectionsTitleLabel.Margin = new Padding(25, 11, 0, 0);
                myCollectionsTitleLabel.Dock = DockStyle.Fill;
                myCollectionsTitleLabel.Text = languageResources.GetString(myCollectionsTitleLabel.Name);
                mainTableLayoutPanel.Controls.Add(myCollectionsTitleLabel, 0, 0);
                controlsForLocalization.Add(myCollectionsTitleLabel);

                var addNewCollectionButton = new Button();
                addNewCollectionButton.Name = "addNewCollectionButton";
                addNewCollectionButton.Text = languageResources.GetString(addNewCollectionButton.Name);
                addNewCollectionButton.Font = new Font(fontCollection.Families[0], 14);
                addNewCollectionButton.BackColor = System.Drawing.Color.FromArgb(0, 166, 253);
                addNewCollectionButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                addNewCollectionButton.Dock = DockStyle.Fill;
                addNewCollectionButton.Margin = new Padding(40, 12, 220, 23);
                addNewCollectionButton.Cursor = Cursors.Hand;
                addNewCollectionButton.MouseDown += ClickOnAddNewCollectionButton;
                mainTableLayoutPanel.Controls.Add(addNewCollectionButton, 0, 1);
                controlsForLocalization.Add(addNewCollectionButton);

                var myCollectionTableLayoutPanel = new TableLayoutPanel();
                myCollectionTableLayoutPanel.Name = "myCollectionTableLayoutPanel";
                myCollectionTableLayoutPanel.RowCount = 1;
                myCollectionTableLayoutPanel.ColumnCount = 2;
                myCollectionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                myCollectionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
                myCollectionTableLayoutPanel.Margin = new Padding(0);
                myCollectionTableLayoutPanel.Dock = DockStyle.Fill;
                myCollectionTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                secondaryTableLayoutPanel.Controls.Add(myCollectionTableLayoutPanel);

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

                FillingListFlowLayoutPanel(listflowlayoutpanel, productsFlowLayoutPanel);
            }
        }

        private void ClickOnMyProductsPage(object sender, MouseEventArgs e)
        {
            if (myProductsLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Мои товары\"");

                controlsForLocalization.Clear();
                secondaryTableLayoutPanel.Controls.Clear();
                DeleteControlsFromMainTableLayoutPanel();

                myProductsLabel.ForeColor = System.Drawing.Color.FromArgb(0, 139, 253);
                myCollectionsLabel.ForeColor = SystemColors.WindowText;
                mainPageLabel.ForeColor = SystemColors.WindowText;
                favoriteLabel.ForeColor = SystemColors.WindowText;

                var myProductsTitleLabel = new Label();
                myProductsTitleLabel.Name = "myProductsTitleLabel";
                myProductsTitleLabel.Font = new Font(fontCollection.Families[0], 30);
                myProductsTitleLabel.Margin = new Padding(25, 11, 0, 0);
                myProductsTitleLabel.Dock = DockStyle.Fill;
                myProductsTitleLabel.Text = languageResources.GetString(myProductsTitleLabel.Name);
                mainTableLayoutPanel.Controls.Add(myProductsTitleLabel, 0, 0);
                controlsForLocalization.Add(myProductsTitleLabel);

                var addNewProductButton = new Button();
                addNewProductButton.Name = "addNewProductButton";
                addNewProductButton.Text = languageResources.GetString(addNewProductButton.Name);
                addNewProductButton.Font = new Font(fontCollection.Families[0], 14);
                addNewProductButton.BackColor = System.Drawing.Color.FromArgb(0, 166, 253);
                addNewProductButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                addNewProductButton.Dock = DockStyle.Fill;
                addNewProductButton.Margin = new Padding(40, 12, 220, 23);
                addNewProductButton.Cursor = Cursors.Hand;
                addNewProductButton.MouseDown += ClickOnAddNewProductButton;
                mainTableLayoutPanel.Controls.Add(addNewProductButton, 0, 1);
                controlsForLocalization.Add(addNewProductButton);

                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowTable";
                productsFlowLayoutPanel.AutoScroll = true;
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                secondaryTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                FillMyProductsLayoutPanel(productsFlowLayoutPanel);
            }
        }

        private void ClickOnFavoritePage(object sender, MouseEventArgs e)
        {
            if (favoriteLabel.ForeColor == SystemColors.WindowText)
            {
                logger.Info("Пользователь открыл раздел \"Избранное\"");

                DeleteControlsFromMainTableLayoutPanel();
                secondaryTableLayoutPanel.Controls.Clear();

                favoriteLabel.ForeColor = System.Drawing.Color.FromArgb(0, 139, 253);
                myCollectionsLabel.ForeColor = SystemColors.WindowText;
                mainPageLabel.ForeColor = SystemColors.WindowText;
                myProductsLabel.ForeColor = SystemColors.WindowText;

                var favoritesTitleLabel = new Label();
                favoritesTitleLabel.Name = "favoritesTitleLabel";
                favoritesTitleLabel.Font = new Font(fontCollection.Families[0], 30);
                favoritesTitleLabel.Margin = new Padding(25, 11, 0, 0);
                favoritesTitleLabel.Dock = DockStyle.Fill;
                favoritesTitleLabel.Text = languageResources.GetString(favoritesTitleLabel.Name);
                mainTableLayoutPanel.Controls.Add(favoritesTitleLabel, 0, 0);
                controlsForLocalization.Add(favoritesTitleLabel);

                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowTable";
                productsFlowLayoutPanel.AutoScroll = true;
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                secondaryTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

                FillFavoritesLayoutPanel(productsFlowLayoutPanel);
            }
        }

        private void SelectLanguageComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Пользователь сменил язык на {selectLanguageComboBox.SelectedText}");

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
                var searchTableLayoutPanel = mainTableLayoutPanel.Controls["searchTableLayoutPanel"]
                    as TableLayoutPanel;

                if (searchTableLayoutPanel != null)
                {
                    var searchLineTextBox = searchTableLayoutPanel.Controls["searchLineTextBox"] as TextBox;

                    if (searchLineTextBox != null)
                    {
                        searchLineTextBox.PlaceholderText = languageResources.GetString(searchLineTextBox.Name);
                    }
                }
            }

            var productsFlowLayoutPanel = secondaryTableLayoutPanel.Controls["productsFlowTable"] as FlowLayoutPanel;

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

        private void ClickOnAddNewProductButton(object sender, MouseEventArgs e)
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

        private void ClickOnAddNewCollectionButton(object sender, MouseEventArgs e)
        {
            var myCollectionTableLayoutPanel = secondaryTableLayoutPanel.Controls
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

        private void ClickOnFiltersButton(object sender, MouseEventArgs e)
        {
            if (!isFiltersOn)
            {
                mainTableLayoutPanel.Controls["searchTableLayoutPanel"].Dispose();
                secondaryTableLayoutPanel.Controls.Clear();

                var filtersMenuTableLayoutPanel = new TableLayoutPanel();
                filtersMenuTableLayoutPanel.Name = "filtersMenuTableLayoutPanel";
                filtersMenuTableLayoutPanel.Dock = DockStyle.Fill;
                filtersMenuTableLayoutPanel.ColumnCount = 3;
                filtersMenuTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
                filtersMenuTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                filtersMenuTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                mainTableLayoutPanel.Controls.Add(filtersMenuTableLayoutPanel, 1, 1);

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

                var chooseProductTypeComboBox = new ComboBox();
                chooseProductTypeComboBox.Name = "chooseProductTypeComboBox";
                chooseProductTypeComboBox.Dock = DockStyle.Fill;
                chooseProductTypeComboBox.Size = new Size(200, 28);
                chooseProductTypeComboBox.Font = new Font(fontCollection.Families[0], 14);
                chooseProductTypeComboBox.Items.Add("Тип товара");
                chooseProductTypeComboBox.Items.AddRange(DatabaseInteraction.LoadProductTypes());
                chooseProductTypeComboBox.TabIndex = 0;
                chooseProductTypeComboBox.SelectedIndex = 0;
                chooseProductTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                chooseProductTypeComboBox.TabIndex = 0;
                chooseProductTypeComboBox.SelectedIndexChanged += ChangingIndexInChooseProductTypeComboBox;
                filtersMenuTableLayoutPanel.Controls.Add(chooseProductTypeComboBox, 0, 0);
                
                isFiltersOn = true;
            }
            else
            {
                mainPageLabel.ForeColor = SystemColors.WindowText;
                ClickOnMainPage();
                isFiltersOn = false;
            }
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

                secondaryTableLayoutPanel.Controls.Clear();
                var productsFlowLayoutPanel = new FlowLayoutPanel();
                productsFlowLayoutPanel.Name = "productsFlowTable";
                productsFlowLayoutPanel.AutoScroll = true;
                productsFlowLayoutPanel.Dock = DockStyle.Fill;
                productsFlowLayoutPanel.Margin = new Padding(0);
                productsFlowLayoutPanel.Padding = new Padding(0);
                secondaryTableLayoutPanel.Controls.Add(productsFlowLayoutPanel);

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
            var filtersMenuTableLayoutPanel = mainTableLayoutPanel.Controls["filtersMenuTableLayoutPanel"] as TableLayoutPanel;

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
            this.languageResources = languageResources;
            InitializeComponent();
            currentUser = DatabaseInteraction.FindUser(userID);
            ClickOnMainPage(currentUser);

            selectLanguageComboBox.Items.AddRange(new string[] { localizationResources.GetString("RU"),
                localizationResources.GetString("EN") });
            selectLanguageComboBox.SelectedItem = languageName;

            mainPageLabel.Font = new Font(fontCollection.Families[0], 14);
            myCollectionsLabel.Font = new Font(fontCollection.Families[0], 14);
            myProductsLabel.Font = new Font(fontCollection.Families[0], 14);
            favoriteLabel.Font = new Font(fontCollection.Families[0], 14);
            exitButton.Font = new Font(fontCollection.Families[0], 12);
        }
        #endregion
    }
}
