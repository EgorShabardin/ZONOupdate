using ZONOupdate.EntityClasses;
using ZONOupdate.FunctionalClasses;
using ZONOupdate.Database;
using System.Drawing.Text;
using ZONOupdate.Forms.FormForProductCard;
using System.Resources;
using Guna.UI2.WinForms;
using NLog;
using ZONOupdate.Forms.FormForCreationNewProduct;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;


namespace ZONOupdate.ProjectControls.ControlForDisplayingProduct
{
    /// <summary>
    /// Кастомный control для отображения единицы товара на главной странице
    /// </summary>
    public partial class ProductControl : UserControl
    {
        #region Поля
        Guid userID;
        ComboBox addToCollectionComboBox;
        ResourceManager languageResources;
        public Recommendation currentProduct {  get; set; }
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region Методы
        public void MakingChangesToProduct(Recommendation changedProduct)
        {
            currentProduct = changedProduct;

            productNameLabel.Text = changedProduct.RecommendationName;
            productPriceLabel.Text = changedProduct.ProductPriceFrom.ToString();

            var productPhoto = CustomImageConverter.ByteArrayToImage(changedProduct.ProductPhoto);

            //if (CustomImageConverter.GetImageHash(productPhotoPictureBox.Image) != CustomImageConverter.GetImageHash(productPhoto))
            //{
                productPhotoPictureBox.Image = productPhoto;
            //}
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
            addToCollectionComboBox.Items.Add("В подборку");
            addToCollectionComboBox.Items.AddRange(DatabaseInteraction
                .LoadUserCollections(userID));
            addToCollectionComboBox.SelectedIndexChanged +=
                SelectedIndexChangedInAddingToCollectionComboBox;
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
            addToFavoritePictureBox.Click += ClickOnAddToFavoritePictureBox;
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
            userLikedPictureBox.Margin = new Padding(110, 30, 0, 0);
            userLikedPictureBox.BorderStyle = BorderStyle.FixedSingle;
            userLikedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            userLikedPictureBox.Image = null;
            userLikedPictureBox.Cursor = Cursors.Hand;
            userLikedPictureBox.Size = new Size(140, 130);
            userLikedPictureBox.Click += ClickOnUserLikedPictureBox;
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
            actionsWithProductTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            actionsWithProductTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            actionsWithProductTableLayoutPanel.Margin = new Padding(30, 0, 0, 0);
            productControlTableLayoutPanel.Controls.Add(actionsWithProductTableLayoutPanel, 2, 1);

            var removeProductPictureBox = new PictureBox();
            removeProductPictureBox.Image = Properties.Resources.removeProduct;
            removeProductPictureBox.Name = "removeProductPictureBox";
            removeProductPictureBox.Dock = DockStyle.Fill;
            removeProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            removeProductPictureBox.MouseDown += DeleteProductPictureBoxMouseDown;
            removeProductPictureBox.Cursor = Cursors.Hand;
            actionsWithProductTableLayoutPanel.Controls.Add(removeProductPictureBox, 0, 1);

            var editProductPictureBox = new PictureBox();
            editProductPictureBox.Image = Properties.Resources.editProduct;
            editProductPictureBox.Name = "editProductPictureBox";
            editProductPictureBox.Dock = DockStyle.Fill;
            editProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            editProductPictureBox.MouseDown += EditProductPicturBocMouseDown;
            editProductPictureBox.Cursor = Cursors.Hand;
            actionsWithProductTableLayoutPanel.Controls.Add(editProductPictureBox, 1, 1);

            productControlTableLayoutPanel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productPhotoPictureBox.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productMarkLabel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productPriceLabel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productNameLabel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
        }

        public void MakeProductControlForMyCollections(int tableWidth)
        {
            Width = tableWidth;

            var removeProductPictureBox = new PictureBox();
            removeProductPictureBox.Image = Properties.Resources.removeProduct;
            removeProductPictureBox.Name = "removeProductPictureBox";
            removeProductPictureBox.Dock = DockStyle.Fill;
            removeProductPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            removeProductPictureBox.Margin = new Padding(60);
            removeProductPictureBox.MouseDown += RemoveProductFromCollection;
            removeProductPictureBox.Cursor = Cursors.Hand;
            productControlTableLayoutPanel.Controls.Add(removeProductPictureBox, 2, 0);
            productControlTableLayoutPanel.SetRowSpan(removeProductPictureBox, 3);
        }

        public void MakeProductControlForMatches(int tableWidth) { Width = tableWidth; }

        public void ChangeLanguage(ResourceManager languageResources)
        {
            this.languageResources = languageResources;

            productPriceLabel.Text = $"{languageResources.GetString(productPriceLabel.Name)}: " +
                $"{currentProduct.ProductPriceFrom}₽";
            productMarkLabel.Text = $"{languageResources.GetString(productMarkLabel.Name)}: " +
                $"{DatabaseInteraction.CountProductRating(currentProduct.RecommendationId)} / 5";
        }
        #endregion

        #region События
        private void RemoveProductFromCollection(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить этот товар из подборки?", "Внимание!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                using (var database = new DatabaseContext())
                {
                    var userCollections = database.UserCollections
                        .Where(c => c.ID == userID)
                        .ToList();

                    foreach (var collection in userCollections)
                    {
                        var relationToDelete = database.RecommendationInCollections
                            .FirstOrDefault(r => r.RecommendationID == currentProduct.RecommendationId && r.CollectionID == collection.CollectionID);

                        if (relationToDelete != null)
                        {
                            database.RecommendationInCollections.Remove(relationToDelete);
                        }
                    }

                    database.SaveChanges();

                }
            }
        }
        private void DeleteProductPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить этот товар?", "Внимание!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes)) {
                using (var database = new DatabaseContext())
                {
                    var product = database.Recommendations.Where(product => product.ID == userID)
                        .Where(product => product.RecommendationId == currentProduct.RecommendationId).FirstOrDefault();

                    if (product != null)
                    {
                        database.Recommendations.Remove(product);
                        database.SaveChanges();
                        MessageBox.Show("Товар успешно удалён!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void EditProductPicturBocMouseDown(object sender, MouseEventArgs e)
        {
            var edit = new NewProductCreationForm(userID, languageResources, Parent as FlowLayoutPanel, currentProduct);
            edit.Show();
        }
        private void ClickOnUserLikedPictureBox(object sender, EventArgs e)
        {
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
                        var product = database.LikedProducts.Where(product => product.ID == userID)
                            .Where(product => product.RecommendationID == currentProduct.RecommendationId).FirstOrDefault();

                        if (product != null)
                        {
                            database.LikedProducts.Remove(product);
                            database.SaveChanges();
                            userLikedPictureBox.Image = Properties.Resources.favorites;
                        }
                    }
                }
            }
        }

        private void ClickOnAddToFavoritePictureBox(object sender, EventArgs e)
        {
            var addToFavoritePictureBox = sender as PictureBox;

            if (!DatabaseInteraction.IsProductInFavorites(currentProduct.RecommendationId, userID))
            {
                if (addToFavoritePictureBox != null)
                {
                    addToFavoritePictureBox.Image = Properties.Resources.productInFavorites;
                    DatabaseInteraction.AddToFavorites(userID, currentProduct.RecommendationId);
                }
            }
            else
            {
                if (addToFavoritePictureBox != null)
                {
                    addToFavoritePictureBox.Image = Properties.Resources.favorites;
                    DatabaseInteraction.RemoveFromFavorites(userID, currentProduct.RecommendationId);
                }
            }
        }
        private void SelectedIndexChangedInAddingToCollectionComboBox(object sender, EventArgs e)
        {
            var addToCollectionComboBox = sender as Guna2ComboBox;

            if (!addToCollectionComboBox.SelectedIndex.Equals(0))
            {
                using (var database = new DatabaseContext())
                {
                    ComboBox comboBox = (ComboBox)sender;

                    string selectedCollection = comboBox.SelectedItem.ToString();

                    if (selectedCollection != null)
                    {
                        var collectionID = database.UserCollections.Where(x => x.CollectionName == selectedCollection).FirstOrDefault();

                        if (collectionID != null)
                        {
                            DatabaseInteraction.AddProductToCollection(currentProduct.RecommendationId, collectionID.CollectionID, userID);
                        }
                    }

                }
            }
        }

        private void ProductControlTableLayoutPanelDoubleClick(object sender, EventArgs e)
        {
            var productCardForm = new ProductCardForm(currentProduct, userID, languageResources, this);
            productCardForm.Show();
        }
        #endregion

        #region Конструкторы
        public ProductControl(Recommendation currentProduct, Guid userID, ResourceManager languageResources)
        {
            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            this.languageResources = languageResources;
            this.currentProduct = currentProduct;
            this.userID = userID;
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