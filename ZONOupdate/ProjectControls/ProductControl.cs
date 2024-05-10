using ZONOupdate.EntityClasses;
using ZONOupdate.FunctionalClasses;
using ZONOupdate.Database;
using System.Drawing.Text;
using ZONOupdate.FormForProductCard;
using System.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace ZONOupdate.ProjectControls
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
        PrivateFontCollection fontCollection = new PrivateFontCollection();      
        #endregion

        #region Методы
        public void MakeProductControlForMainPageOrForFavorites(int width)
        {
            Width = width;

            addToCollectionComboBox = new ComboBox();
            addToCollectionComboBox.Dock = DockStyle.Fill;
            addToCollectionComboBox.Font = new Font(fontCollection.Families[0], 13);
            addToCollectionComboBox.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            addToCollectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            addToCollectionComboBox.Margin = new Padding(0, 50, 40, 0);
            addToCollectionComboBox.Items.Add("В подборку");
            addToCollectionComboBox.Items.AddRange(DatabaseInteraction.LoadUserCollections(userID));
            addToCollectionComboBox.Name = "addToCollectionComboBox";
            addToCollectionComboBox.SelectedIndex = 0;
            addToCollectionComboBox.SelectedIndexChanged += SelectedIndexChangedInAddingToCollectionComboBox;
            productControlTableLayoutPanel.Controls.Add(addToCollectionComboBox, 2, 0);

            var addToFavoritePictureBox = new PictureBox();
            var isProductInFavorite = DatabaseInteraction.IsProductInFavorites(currentProduct.RecommendationId, userID);
            addToFavoritePictureBox.Image = isProductInFavorite ? Properties.Resources.productInFavorites : Properties.Resources.favorites;
            addToFavoritePictureBox.Name = "addToFavoritePictureBox";
            addToCollectionComboBox.Dock = DockStyle.Fill;
            addToFavoritePictureBox.Size = new Size(60, 60);
            addToFavoritePictureBox.Margin = new Padding(105, 35, 0, 0);
            addToFavoritePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            addToFavoritePictureBox.Click += ClickOnAddToFavoritePictureBox;
            addToCollectionComboBox.Cursor = Cursors.Hand;
            productControlTableLayoutPanel.Controls.Add(addToFavoritePictureBox, 2, 1);
            productControlTableLayoutPanel.SetRowSpan(addToFavoritePictureBox, 2);
        }

        public void MakeProductControlForFilters(int width)
        {
            Width = width;

            var userLikedTitleLabel = new Label();
            userLikedTitleLabel.Dock = DockStyle.Fill;
            userLikedTitleLabel.Font = new Font(fontCollection.Families[0], 16);
            userLikedTitleLabel.Margin = new Padding(30, 40, 0, 0);
            userLikedTitleLabel.Name = "userLikedTitleLabel";
            userLikedTitleLabel.Text = "Понравилось";
            productControlTableLayoutPanel.Controls.Add(userLikedTitleLabel, 2, 0);

            var userLikedPictureBox = new PictureBox();
            userLikedPictureBox.Name = "userLikedPictureBox";
            userLikedPictureBox.Dock = DockStyle.Fill;
            userLikedPictureBox.Margin = new Padding(105, 35, 0, 0);
            userLikedPictureBox.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            userLikedPictureBox.BorderStyle = BorderStyle.FixedSingle;
            userLikedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            userLikedPictureBox.Click += ClickOnUserLikedPictureBox;
            userLikedPictureBox.Image = null;
            userLikedPictureBox.Cursor = Cursors.Hand;
            productControlTableLayoutPanel.Controls.Add(userLikedPictureBox, 2, 1);
            productControlTableLayoutPanel.SetRowSpan(userLikedPictureBox, 2);

        }

        public void MakeProductControlForMyProducts(int width)
        {
            Width = width;

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
            removeProductPictureBox.MouseDown += DeleteProduct;
            removeProductPictureBox.Cursor = Cursors.Hand;
            actionsWithProductTableLayoutPanel.Controls.Add(removeProductPictureBox);

            productControlTableLayoutPanel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productPhotoPictureBox.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productMarkLabel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productPriceLabel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
            productNameLabel.DoubleClick -= ProductControlTableLayoutPanelDoubleClick;
        }

        public void MakeProductControlForMyCollections(int width)
        {
            Width = width;

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
        private void DeleteProduct(object sender, EventArgs e)
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

            productMarkLabel.Font = new Font(fontCollection.Families[0], 14);
            productPriceLabel.Font = new Font(fontCollection.Families[0], 14);
            productNameLabel.Font = new Font(fontCollection.Families[0], 23);
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