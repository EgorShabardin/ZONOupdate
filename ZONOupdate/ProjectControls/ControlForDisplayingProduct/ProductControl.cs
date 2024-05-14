using ZONOupdate.Forms.FormForCreationNewProduct;
using ZONOupdate.Forms.FormForProductCard;
using ZONOupdate.FunctionalClasses;
using ZONOupdate.EntityClasses;
using System.Drawing.Text;
using ZONOupdate.Database;
using Guna.UI2.WinForms;
using System.Resources;
using NLog;


namespace ZONOupdate.ProjectControls.ControlForDisplayingProduct
{
    /// <summary>
    /// Пользовательский элемент управления для отображения товаров.
    /// </summary>
    public partial class ProductControl : UserControl
    {
        #region Поля
        Guid userID;
        ResourceManager languageResources;    
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region Свойства
        public Recommendation currentProduct { get; set; }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, меняющий данные товара.
        /// </summary>
        /// <param name="changedProduct"> Измененный товар. </param>
        public void MakingChangesToProduct(Recommendation changedProduct)
        {
            currentProduct = changedProduct;

            productNameLabel.Text = changedProduct.RecommendationName;
            productPriceLabel.Text = changedProduct.ProductPriceFrom.ToString();

            productPhotoPictureBox.Image = CustomImageConverter
                .ByteArrayToImage(changedProduct.ProductPhoto);
        }

        /// <summary>
        /// Метод, создающий элемент управления для отображения товара в разделе "Главная страница" или "Избранное".
        /// </summary>
        /// <param name="tableWidth"> Ширина таблицы. </param>
        public void MakeProductControlForMainPageOrForFavorites(int tableWidth)
        {
            logger.Info("Создан элемент управления для отображения товара в разделе" +
                " \"Главная страница\" или \"Избранное\"");

            Width = tableWidth;

            var addToCollectionComboBox = new Guna2ComboBox();
            addToCollectionComboBox.Name = "addToCollectionComboBox";
            addToCollectionComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            addToCollectionComboBox.Font = new Font(fontCollection.Families[0], 13);
            addToCollectionComboBox.FillColor = SystemColors.ButtonFace;
            addToCollectionComboBox.ForeColor = SystemColors.WindowText;
            addToCollectionComboBox.BorderColor = SystemColors.WindowText;
            addToCollectionComboBox.BorderRadius = 8;
            addToCollectionComboBox.BorderThickness = 1;
            addToCollectionComboBox.Cursor = Cursors.Hand;
            addToCollectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            addToCollectionComboBox.Size = new Size(197, 45);
            addToCollectionComboBox.TextAlign = HorizontalAlignment.Left;
            addToCollectionComboBox.Margin = new Padding(10, 50, 80, 0);
            addToCollectionComboBox.Items.Add(languageResources
                    .GetString(addToCollectionComboBox.Name));
            addToCollectionComboBox.Items.AddRange(DatabaseInteraction
                .LoadUserCollections(userID));
            addToCollectionComboBox.SelectedIndexChanged +=
                SelectedIndexChangedInAddingToCollection;
            productControlTableLayoutPanel.Controls.Add(addToCollectionComboBox, 2, 0);

            var isProductInCollection = DatabaseInteraction
                .IsProductInCollection(currentProduct.RecommendationId, userID);

            if (!isProductInCollection.Equals(String.Empty))
            {
                addToCollectionComboBox.SelectedItem = isProductInCollection;
            }
            else
            {
                addToCollectionComboBox.SelectedIndex = 0;
            }

            var addToFavoritePictureBox = new PictureBox();
            var isProductInFavorite = DatabaseInteraction
                .IsProductInFavorites(currentProduct.RecommendationId, userID);
            addToFavoritePictureBox.Image = isProductInFavorite ? Properties.Resources
                .productInFavorites : Properties.Resources.favorites;
            addToFavoritePictureBox.Name = "addToFavoritePictureBox";
            addToFavoritePictureBox.Dock = DockStyle.Fill;
            addToFavoritePictureBox.Margin = new Padding(0, 25, 55, 20);
            addToFavoritePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            addToFavoritePictureBox.Cursor = Cursors.Hand;
            addToFavoritePictureBox.Click += AddToFavorite;
            productControlTableLayoutPanel.Controls.Add(addToFavoritePictureBox, 2, 1);
            productControlTableLayoutPanel.SetRowSpan(addToFavoritePictureBox, 2);
        }

        /// <summary>
        /// Метод, создающий элемент управления для отображения товара в разделе "Фильтры".
        /// </summary>
        /// <param name="tableWidth"> Ширина таблицы. </param>
        public void MakeProductControlForFilters(int tableWidth)
        {
            logger.Info("Создан элемент управления для отображения товара в разделе" +
                " \"Фильтры\"");

            Width = tableWidth;

            var userLikedPictureBox = new PictureBox();
            userLikedPictureBox.Name = "userLikedPictureBox";
            userLikedPictureBox.BackColor = System.Drawing.Color
                .FromArgb(240, 240, 240);
            userLikedPictureBox.Margin = new Padding(130, 63, 0, 0);
            userLikedPictureBox.BorderStyle = BorderStyle.FixedSingle;
            userLikedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            userLikedPictureBox.Image = null;
            userLikedPictureBox.Cursor = Cursors.Hand;
            userLikedPictureBox.Size = new Size(75, 70);
            userLikedPictureBox.Click += AddToLicked;
            productControlTableLayoutPanel.Controls.Add(userLikedPictureBox, 2, 0);
            productControlTableLayoutPanel.SetRowSpan(userLikedPictureBox, 3);
        }

        /// <summary>
        /// Метод, создающий элемент управления для отображения товара в разделе "Мои товары".
        /// </summary>
        /// <param name="tableWidth"> Ширина таблицы. </param>
        public void MakeProductControlForMyProducts(int tableWidth)
        {
            logger.Info("Создан элемент управления для отображения товара в разделе" +
                " \"Мои товары\"");

            Width = tableWidth;

            var actionsWithProductTableLayoutPanel = new TableLayoutPanel();
            actionsWithProductTableLayoutPanel.RowCount = 1;
            actionsWithProductTableLayoutPanel.ColumnCount = 2;
            actionsWithProductTableLayoutPanel.Dock = DockStyle.Fill;
            actionsWithProductTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            actionsWithProductTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            actionsWithProductTableLayoutPanel.Margin = new Padding(30, 0, 0, 0);
            productControlTableLayoutPanel.Controls.Add(actionsWithProductTableLayoutPanel, 2, 0);
            productControlTableLayoutPanel.SetRowSpan(actionsWithProductTableLayoutPanel, 3);

            var removeProductPictureBox = new PictureBox();
            removeProductPictureBox.Image = Properties.Resources.removeProduct;
            removeProductPictureBox.Name = "removeProductPictureBox";
            removeProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            removeProductPictureBox.Size = new Size(70, 70);
            removeProductPictureBox.Margin = new Padding(20, 63, 0, 0);
            removeProductPictureBox.Cursor = Cursors.Hand;
            removeProductPictureBox.MouseDown += DeleteProductFromMyProducts;
            actionsWithProductTableLayoutPanel.Controls.Add(removeProductPictureBox, 0, 1);

            var editProductPictureBox = new PictureBox();
            editProductPictureBox.Image = Properties.Resources.editProduct;
            editProductPictureBox.Name = "editProductPictureBox";
            editProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            editProductPictureBox.Size = new Size(70, 70);
            editProductPictureBox.Margin = new Padding(0, 63, 0, 0);
            editProductPictureBox.Cursor = Cursors.Hand;
            editProductPictureBox.MouseDown += EditProduct;
            actionsWithProductTableLayoutPanel.Controls.Add(editProductPictureBox, 1, 1);

            productControlTableLayoutPanel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productPhotoPictureBox.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productMarkLabel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productPriceLabel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productNameLabel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
        }

        /// <summary>
        /// Метод, создающий элемент управления для отображения товара в разделе "Мои подборки".
        /// </summary>
        /// <param name="tableWidth"> Ширина таблицы. </param>
        public void MakeProductControlForMyCollections(int tableWidth)
        {
            logger.Info("Создан элемент управления для отображения товара в разделе" +
                " \"Мои подборки\"");

            Width = tableWidth;

            var removeProductPictureBox = new PictureBox();
            removeProductPictureBox.Name = "removeProductPictureBox";
            removeProductPictureBox.Image = Properties.Resources.removeProduct;
            removeProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            removeProductPictureBox.Size = new Size(70, 70);
            removeProductPictureBox.Margin = new Padding(80, 63, 0, 0);
            removeProductPictureBox.Cursor = Cursors.Hand;
            removeProductPictureBox.MouseDown += RemoveProductFromCollection;
            productControlTableLayoutPanel.Controls.Add(removeProductPictureBox, 2, 0);
            productControlTableLayoutPanel.SetRowSpan(removeProductPictureBox, 3);
        }

        /// <summary>
        /// Метод, создающий элемент управления для отображения товара в разделе "Мои подборки" в подборке "Популярное".
        /// </summary>
        /// <param name="tableWidth"> Ширина таблицы. </param>
        public void MakeProductControlForMatches(int tableWidth)
        {
            Width = tableWidth;
        }

        /// <summary>
        /// Метод, меняющий локализацию пользовательского элемента управления.
        /// </summary>
        /// <param name="languageResources"> Файл локализации. </param>
        public void ChangeLanguage(ResourceManager languageResources)
        {
            this.languageResources = languageResources;

            productPriceLabel.Text = $"{languageResources.GetString(productPriceLabel.Name)}: " +
                $"{currentProduct.ProductPriceFrom}₽";
            productMarkLabel.Text = $"{languageResources.GetString(productMarkLabel.Name)}: " +
                $"{DatabaseInteraction.CountProductRating(currentProduct.RecommendationId)} / 5";

            var addToCollectionComboBox = productControlTableLayoutPanel
                .Controls["addToCollectionComboBox"] as Guna2ComboBox;

            if (addToCollectionComboBox != null)
            {
                if (addToCollectionComboBox.SelectedIndex.Equals(0))
                {
                    addToCollectionComboBox.Items.RemoveAt(0);
                    addToCollectionComboBox.Items.Insert(0, languageResources
                        .GetString(addToCollectionComboBox.Name));
                    addToCollectionComboBox.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region События
        private void RemoveProductFromCollection(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку удаления товара из подборки");

            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при удалении " +
                    "товара из подборки");

                var userCollections = database.UserCollections
                    .Where(collection => collection.ID == userID).ToList();

                foreach (var collection in userCollections)
                {
                    var relationToDelete = database.RecommendationInCollections
                        .Where(recomendation => recomendation.RecommendationID == currentProduct.RecommendationId)
                        .Where(recomendation => recomendation.CollectionID == collection.CollectionID).FirstOrDefault();

                    if (relationToDelete != null)
                    {
                        database.RecommendationInCollections.Remove(relationToDelete);
                    }
                }

                database.SaveChanges();

                var productsFlowLayoutPanel = Parent as FlowLayoutPanel;

                if (productsFlowLayoutPanel != null)
                {
                    var productControl = productsFlowLayoutPanel.Controls[currentProduct.RecommendationId.ToString()];

                    if (productControl != null)
                    {
                        productControl.Dispose();
                    }
                }
            }
        }

        private void DeleteProductFromMyProducts(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку удаления товара");

            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при удалении товара");

                var product = database.Recommendations.Where(product => product.ID == userID)
                .Where(product => product.RecommendationId == currentProduct.RecommendationId).FirstOrDefault();

                if (product != null)
                {
                    database.Recommendations.Remove(product);
                    database.SaveChanges();
                }

                var productsFlowLayoutPanel = Parent as FlowLayoutPanel;

                if (productsFlowLayoutPanel != null)
                {
                    var productControl = productsFlowLayoutPanel.Controls[currentProduct.RecommendationId.ToString()];

                    if (productControl != null)
                    {
                        productControl.Dispose();
                    }
                }
            }
        }

        private void EditProduct(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку для редактирования товара");

            var productsFlowLayoutPanel = Parent as FlowLayoutPanel;

            if (productsFlowLayoutPanel != null)
            {
                var formForEditProduct = new NewProductCreationForm(userID,
                    languageResources, productsFlowLayoutPanel, currentProduct);
                formForEditProduct.Show();
            }
        }

        private void AddToLicked(object sender, EventArgs e)
        {
            logger.Info("Пользователь добавил товар в понравившееся в разделе \"Фильтры\"");

            var userLikedPictureBox = sender as PictureBox;

            if (userLikedPictureBox != null)
            {
                using (var database = new DatabaseContext())
                {
                    if (!DatabaseInteraction.IsProductLiked(currentProduct.RecommendationId, userID))
                    {
                        if (userLikedPictureBox != null)
                        {
                            var product = new LikedProduct
                            {
                                ID = userID,
                                RecommendationID = currentProduct.RecommendationId,
                                LikedProductID = Guid.NewGuid()
                            };

                            database.LikedProducts.Add(product);
                            database.SaveChanges();

                            userLikedPictureBox.Image = Properties.Resources.checkMark;
                        }
                    }
                    else
                    {
                        var product = database.LikedProducts.Where(product => product
                        .ID == userID).Where(product => product.RecommendationID == currentProduct
                        .RecommendationId).FirstOrDefault();

                        if (product != null)
                        {
                            database.LikedProducts.Remove(product);
                            database.SaveChanges();
                            userLikedPictureBox.Image = null;
                        }
                    }
                }
            }
        }

        private void AddToFavorite(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку для добавления/удаления" +
                " товара из избранного");

            var addToFavoritePictureBox = sender as PictureBox;

            if (!DatabaseInteraction.IsProductInFavorites(currentProduct
                .RecommendationId, userID))
            {
                if (addToFavoritePictureBox != null)
                {
                    addToFavoritePictureBox.Image = Properties
                        .Resources.productInFavorites;
                    DatabaseInteraction.AddToFavorites(userID,
                        currentProduct.RecommendationId);
                }
            }
            else
            {
                if (addToFavoritePictureBox != null)
                {
                    addToFavoritePictureBox.Image = Properties
                        .Resources.favorites;
                    DatabaseInteraction.RemoveFromFavorites(userID,
                        currentProduct.RecommendationId);
                }
            }
        }

        private void SelectedIndexChangedInAddingToCollection(object sender, EventArgs e)
        {
            var addToCollectionComboBox = sender as Guna2ComboBox;

            if (addToCollectionComboBox != null)
            {
                if (!addToCollectionComboBox.SelectedIndex.Equals(0))
                {
                    using (var database = new DatabaseContext())
                    {
                        string selectedCollection = addToCollectionComboBox
                            .SelectedItem.ToString();

                        if (selectedCollection != null)
                        {
                            var collectionID = database.UserCollections
                                .Where(collection => collection.CollectionName == selectedCollection)
                                .FirstOrDefault();

                            if (collectionID != null)
                            {
                                DatabaseInteraction.AddProductToCollection(currentProduct
                                    .RecommendationId, collectionID.CollectionID, userID);
                            }
                        }
                    }
                }
            }
        }

        private void ProductControlTableLayoutPanelDoubleClick(object sender, EventArgs e)
        {
            logger.Info("Пользователь открыл карточку товара");

            var productCardForm = new ProductCardForm(currentProduct, userID, languageResources, this);
            productCardForm.Show();
        }
        #endregion

        #region Конструкторы
        public ProductControl(Recommendation currentProduct, Guid userID, ResourceManager languageResources)
        {
            this.userID = userID;
            this.currentProduct = currentProduct;
            this.languageResources = languageResources;
            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            InitializeComponent();

            productMarkLabel.Font = new Font(fontCollection.Families[0], 15);
            productPriceLabel.Font = new Font(fontCollection.Families[0], 15);
            productNameLabel.Font = new Font(fontCollection.Families[0], 25);
            productPhotoPictureBox.Image = CustomImageConverter.ByteArrayToImage(currentProduct.ProductPhoto);

            productNameLabel.Text = currentProduct.RecommendationName;
            productPriceLabel.Text = $"{languageResources.GetString(productPriceLabel.Name)}: " +
                $"{currentProduct.ProductPriceFrom}₽";
            productMarkLabel.Text = $"{languageResources.GetString(productMarkLabel.Name)}: " +
                $"{DatabaseInteraction.CountProductRating(currentProduct.RecommendationId)} / 5";          
        }
        #endregion 
    }
}