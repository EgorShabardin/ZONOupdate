using ZONOupdate.FunctionalClasses;
using ZONOupdate.EntityClasses;
using ZONOupdate.Database;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Resources;
using NLog;

namespace ZONOupdate.Forms
{
    /// <summary>
    /// Форма добавления нового товара
    /// </summary>
    public partial class NewProductCreationForm : Form
    {
        #region Поля
        Guid currentUserID;
        Recommendation selectedProduct;
        ResourceManager languageResources;
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region Методы
        /// <summary>
        /// Метод для загрузки данных существующего товара.
        /// </summary>
        /// <param name="recommendation">Товар</param>
        public void LoadProductInfo(Recommendation recommendation)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при загрузке данных товара для редактирования");
                var colorName = database.Colors.Where(color => color.ColorID == recommendation.ColorID)
                    .Select(color => color.ColorName).FirstOrDefault();
                var productTypeName = database.ProductTypes.Where(productType => productType.ProductTypeID == recommendation
                .ProductTypeID).Select(productType => productType.ProductTypeName).FirstOrDefault();
                var manufactorName = database.Manufacturers.Where(manufacturer => manufacturer.ManufacturerID == recommendation
                .ManufacturerID).Select(manufacturer => manufacturer.ManufacturerName).FirstOrDefault();

                productNameTextBox.Text = recommendation.RecommendationName;
                productDescriptionTextBox.Text = recommendation.RecommendationDescription;
                productColorComboBox.SelectedItem = colorName;
                productTypeComboBox.SelectedItem = productTypeName;
                productManufacturerComboBox.SelectedItem = manufactorName;
                productYearOfProductionTextBox.Text = recommendation.YearOfProduction.ToString();
                productPriceTextBox.Text = recommendation.ProductPriceFrom.ToString();
                productPhotoPictureBox.Image = CustomImageConverter.ByteArrayToImage(recommendation.ProductPhoto);
            }

        }

        private void LoadComboBoxesData()
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при загрузке данных товраов");

                var manufacturerNames = database.Manufacturers.AsEnumerable().Select(manufacter => manufacter.ManufacturerName).ToList();
                var typeNames = database.ProductTypes.AsEnumerable().Select(productType => productType.ProductTypeName).ToList();
                var colorNames = database.Colors.AsEnumerable().Select(colors => colors.ColorName).ToList();

                productManufacturerComboBox.Items.AddRange(manufacturerNames.ToArray());
                productTypeComboBox.Items.AddRange(typeNames.ToArray());
                productColorComboBox.Items.AddRange(colorNames.ToArray());

                logger.Info("Данные товаров успешно загружены в ComboBox`ы");
            }
        }
        #endregion

        #region События
        private void BlockingIncorrectInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EditProductPhotoDialog(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите изображение товара";
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    productPhotoPictureBox.Image = new Bitmap(openFileDialog.FileName);

                    logger.Info("Изображение товара успешно загружено");
                }
            }
        }

        private void SaveNewProductInDatabase(object sender, EventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешноу подключение к базе данных при сохранении данных товара");

                var manufacturerIDs = database.Manufacturers.AsEnumerable().Select(x => x.ManufacturerID).ToList();
                var typeIDs = database.ProductTypes.AsEnumerable().Select(x => x.ProductTypeID).ToList();
                var colorIDs = database.Colors.AsEnumerable().Select(x => x.ColorID).ToList();

                var product = new Recommendation();
                product.ID = currentUserID;
                product.RecommendationName = productNameTextBox.Text;
                product.RecommendationDescription = productDescriptionTextBox.Text;
                product.RecommendationMark = 0;
                product.ProductPriceFrom = int.Parse(productPriceTextBox.Text);
                product.RecommendationId = Guid.NewGuid();

                using (var ms = new MemoryStream())
                {
                    productPhotoPictureBox.Image.Save(ms, ImageFormat.Jpeg);
                    product.ProductPhoto = ms.ToArray();
                }

                var colorselected = productColorComboBox.SelectedIndex;
                var manufacturerselected = productTypeComboBox.SelectedIndex;
                var producttypeselected = productTypeComboBox.SelectedIndex;


                product.ColorID = colorIDs[colorselected];
                product.ManufacturerID = manufacturerIDs[manufacturerselected];
                product.ProductTypeID = typeIDs[producttypeselected];
                
                if (int.TryParse(productYearOfProductionTextBox.Text, out int result))
                {
                    product.YearOfProduction = result;
                }

                database.Recommendations.Add(product);
                database.SaveChanges();

                MessageBox.Show(languageResources.GetString("addingProductContent"), languageResources
                    .GetString("addingProductTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                logger.Debug($"Товар с id {product.RecommendationId} успешно добавлен");

                Close();
            }
        }
        #endregion

        #region Конструкторы
        public NewProductCreationForm(Guid currentUserID, ResourceManager languageResources)
        {
            logger.Info("Открылась форма \"Создать/редактировать товар\"");

            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            this.languageResources = languageResources;
            this.currentUserID = currentUserID;
            InitializeComponent();

            productNameTextBox.Font = new Font(fontCollection.Families[0], 20);
            loadProductPhotoButton.Font = new Font(fontCollection.Families[0], 12);
            productDescriptionTextBox.Font = new Font(fontCollection.Families[0], 14);
            productColorLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productYearOfProductionLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productManufacturerLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productTypeLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productPriceLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            saveMarkButton.Font = new Font(fontCollection.Families[0], 16);
            productTypeComboBox.Font = new Font(fontCollection.Families[0], 14);
            productManufacturerComboBox.Font = new Font(fontCollection.Families[0], 14);
            productYearOfProductionTextBox.Font = new Font(fontCollection.Families[0], 14);
            productColorComboBox.Font = new Font(fontCollection.Families[0], 14);
            productPriceTextBox.Font = new Font(fontCollection.Families[0], 14);

            productNameTextBox.PlaceholderText = languageResources.GetString(productNameTextBox.Name);
            loadProductPhotoButton.Text = languageResources.GetString(loadProductPhotoButton.Name);
            productDescriptionTextBox.PlaceholderText = languageResources.GetString(productDescriptionTextBox.Name);
            productColorLabelTitle.Text = languageResources.GetString(productColorLabelTitle.Name);
            productYearOfProductionLabelTitle.Text = languageResources.GetString(productYearOfProductionLabelTitle.Name);
            productManufacturerLabelTitle.Text = languageResources.GetString(productManufacturerLabelTitle.Name);
            productTypeLabelTitle.Text = languageResources.GetString(productTypeLabelTitle.Name);
            productPriceLabelTitle.Text = languageResources.GetString(productPriceLabelTitle.Name);
            saveMarkButton.Text = languageResources.GetString(saveMarkButton.Name);
            Text = languageResources.GetString(Name);

            LoadComboBoxesData();
        }
        #endregion
    }
}