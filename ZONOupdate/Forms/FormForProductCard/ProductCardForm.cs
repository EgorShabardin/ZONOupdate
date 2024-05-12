using ZONOupdate.ProjectControls.ControlForDisplayingProduct;
using ZONOupdate.FunctionalClasses;
using ZONOupdate.EntityClasses;
using ZONOupdate.Database;
using System.Drawing.Text;
using System.Resources;
using NLog;

namespace ZONOupdate.FormForProductCard
{
    /// <summary>
    /// Форма для отображения карточки товара с возможностью проставления оценки.
    /// </summary>
    public partial class ProductCardForm : Form
    {
        #region Поля
        Guid userID;
        ProductControl productControl;
        Recommendation selectedProduct;
        ResourceManager languageResources;
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region События
        private void SaveMarkButtonMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку \"Сохранить\" в карточке товара");

            if (!markComboBox.SelectedIndex.Equals(-1))
            {
                using (var database = new DatabaseContext())
                {
                    var selectedMark = markComboBox.SelectedItem;

                    if (selectedMark != null)
                    {
                        if (int.TryParse(selectedMark.ToString(), out int mark))
                        {
                            logger.Trace($"Пользователь с id {userID} поставил товару с id {selectedProduct.ID} оценку {mark}");

                            DatabaseInteraction.AddNewMark(userID, selectedProduct.RecommendationId, mark);

                            var productMarkLabel = productControl.Controls.Find("productMarkLabel", true)
                                .FirstOrDefault() as Label;

                            if (productMarkLabel != null)
                            {
                                productMarkLabel.Text = $"{languageResources.GetString(productMarkLabel.Name)}: " +
                                $"{DatabaseInteraction.CountProductRating(selectedProduct.RecommendationId)} / 5";
                            }

                            Close();
                        }
                    }
                }
            }
        }

        private void ProductCardFormLoad(object sender, EventArgs e)
        {
            var formAppearanceTimer = new System.Windows.Forms.Timer();
            formAppearanceTimer.Interval = 60;
            formAppearanceTimer.Tick += FormAppearanceTimerTick;
            formAppearanceTimer.Start();
        }

        private void FormAppearanceTimerTick(object sender, EventArgs e)
        {
            Opacity += 0.1;

            if (Opacity == 1)
            {
                var formAppearanceTimer = sender as System.Windows.Forms.Timer;

                if (formAppearanceTimer != null)
                {
                    formAppearanceTimer.Stop();
                }
            }
        }
        #endregion

        #region Конструкторы
        public ProductCardForm(Recommendation selectedProduct,
            Guid userID, ResourceManager languageResources, ProductControl productControl)
        {
            logger.Info("Открылась форма \"Карточка товара\"");

            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            this.languageResources = languageResources;
            this.productControl = productControl;
            this.selectedProduct = selectedProduct;
            this.userID = userID;
            InitializeComponent();

            productNameLabel.Font = new Font(fontCollection.Families[0], 20);
            productDescriptionLabel.Font = new Font(fontCollection.Families[0], 14);
            productColorLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productColorLabelInfo.Font = new Font(fontCollection.Families[0], 14);
            productYearOfProductionLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productYearOfProductionLabelInfo.Font = new Font(fontCollection.Families[0], 14);
            productManufacturerLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productManufacturerLabelInfo.Font = new Font(fontCollection.Families[0], 14);
            productTypeLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productTypeLabelInfo.Font = new Font(fontCollection.Families[0], 14);
            productPriceLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productPriceLabelInfo.Font = new Font(fontCollection.Families[0], 14);
            markTitle.Font = new Font(fontCollection.Families[0], 16);
            markComboBox.Font = new Font(fontCollection.Families[0], 16);
            saveMarkButton.Font = new Font(fontCollection.Families[0], 16);

            productColorLabelTitle.Text = languageResources.GetString(productColorLabelTitle.Name);
            productYearOfProductionLabelTitle.Text = languageResources.GetString(productYearOfProductionLabelTitle.Name);
            productManufacturerLabelTitle.Text = languageResources.GetString(productManufacturerLabelTitle.Name);
            productTypeLabelTitle.Text = languageResources.GetString(productTypeLabelTitle.Name);
            productPriceLabelTitle.Text = languageResources.GetString(productPriceLabelTitle.Name);
            markTitle.Text = languageResources.GetString(markTitle.Name);
            saveMarkButton.Text = languageResources.GetString(saveMarkButton.Name);
            Text = languageResources.GetString(Name);

            using (var database = new DatabaseContext())
            {
                var productType = database.ProductTypes.Where(product => product.ProductTypeID ==
                selectedProduct.ProductTypeID).FirstOrDefault();
                var productColor = database.Colors.Where(product => product.ColorID == selectedProduct.ColorID)
                    .FirstOrDefault();
                var productManufacturer = database.Manufacturers.Where(product => product.ManufacturerID
                == selectedProduct.ManufacturerID).FirstOrDefault();

                if (productColor != null && productType != null && productManufacturer != null)
                {
                    productPhotoPictureBox.Image = CustomImageConverter.ByteArrayToImage(selectedProduct.ProductPhoto);
                    productNameLabel.Text = selectedProduct.RecommendationName;
                    productDescriptionLabel.Text = selectedProduct.RecommendationDescription;
                    productColorLabelInfo.Text = productColor.ColorName;
                    productYearOfProductionLabelInfo.Text = selectedProduct.YearOfProduction.ToString();
                    productManufacturerLabelInfo.Text = productManufacturer.ManufacturerName;
                    productTypeLabelInfo.Text = productType.ProductTypeName;
                    productPriceLabelInfo.Text = $"{selectedProduct.ProductPriceFrom}₽";
                }
            }
        }
        #endregion
    }
}