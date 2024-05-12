using ZONOupdate.FunctionalClasses;
using ZONOupdate.EntityClasses;
using ZONOupdate.Database;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Resources;
using NLog;

namespace ZONOupdate.FormForCreationNewProduct
{
    /// <summary>
    /// Форма для добавления/редактирования нового товара.
    /// </summary>
    public partial class NewProductCreationForm : Form
    {
        #region Поля
        Guid currentUserID;
        Recommendation? selectedProduct;
        ResourceManager languageResources;
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region Методы
        private void LoadProductInfo()
        {
            using (var database = new DatabaseContext())
            {
                if (selectedProduct != null)
                {
                    logger.Info("Успешное подключение к базе данных при загрузке данных товара для редактирования");
                    var colorName = database.Colors.Where(color => color.ColorID == selectedProduct.ColorID)
                        .Select(color => color.ColorName).FirstOrDefault();
                    var productTypeName = database.ProductTypes.Where(productType => productType.ProductTypeID == selectedProduct
                    .ProductTypeID).Select(productType => productType.ProductTypeName).FirstOrDefault();
                    var manufactorName = database.Manufacturers.Where(manufacturer => manufacturer.ManufacturerID == selectedProduct
                    .ManufacturerID).Select(manufacturer => manufacturer.ManufacturerName).FirstOrDefault();

                    productNameTextBox.Text = selectedProduct.RecommendationName;
                    productDescriptionTextBox.Text = selectedProduct.RecommendationDescription;
                    productColorComboBox.SelectedItem = colorName;
                    productTypeComboBox.SelectedItem = productTypeName;
                    productManufacturerComboBox.SelectedItem = manufactorName;
                    productYearOfProductionTextBox.Text = selectedProduct.YearOfProduction.ToString();
                    productPriceTextBox.Text = selectedProduct.ProductPriceFrom.ToString();
                    productPhotoPictureBox.Image = CustomImageConverter.ByteArrayToImage(selectedProduct.ProductPhoto);
                }
            }
        }

        private void LoadComboBoxesData()
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при загрузке данных товраов");

                var manufacturerNames = database.Manufacturers.Select(manufacter => manufacter.ManufacturerName).ToArray();
                var typeNames = database.ProductTypes.Select(productType => productType.ProductTypeName).ToArray();
                var colorNames = database.Colors.Select(colors => colors.ColorName).ToArray();

                productManufacturerComboBox.Items.AddRange(manufacturerNames);
                productTypeComboBox.Items.AddRange(typeNames);
                productColorComboBox.Items.AddRange(colorNames);

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

        private void EditProductPhotoDialogMouseDown(object sender, MouseEventArgs e)
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

        private void SaveNewProductInDatabase(object sender, MouseEventArgs e)
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
        private void SaveProductEditInDatabase(object sender, MouseEventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешноу подключение к базе данных при сохранении данных товара");

                var manufacturerIDs = database.Manufacturers.Select(manufacturer => manufacturer.ManufacturerID).ToList();
                var productTypeIDs = database.ProductTypes.Select(productType => productType.ProductTypeID).ToList();
                var colorIDs = database.Colors.Select(color => color.ColorID).ToList();

                selectedProduct.RecommendationName = productNameTextBox.Text;
                selectedProduct.RecommendationDescription = productDescriptionTextBox.Text;
                selectedProduct.ProductPriceFrom = int.Parse(productPriceTextBox.Text);

                using (var ms = new MemoryStream())
                {
                    productPhotoPictureBox.Image.Save(ms, ImageFormat.Jpeg);
                    selectedProduct.ProductPhoto = ms.ToArray();
                }

                var colorselected = productColorComboBox.SelectedIndex;
                var manufacturerselected = productTypeComboBox.SelectedIndex;
                var producttypeselected = productTypeComboBox.SelectedIndex;


                selectedProduct.ColorID = colorIDs[colorselected];
                selectedProduct.ManufacturerID = manufacturerIDs[manufacturerselected];
                selectedProduct.ProductTypeID = productTypeIDs[producttypeselected];

                if (int.TryParse(productYearOfProductionTextBox.Text, out int result))
                {
                    selectedProduct.YearOfProduction = result;
                }

                database.SaveChanges();

                logger.Debug($"Товар с id {selectedProduct.RecommendationId} успешно добавлен");

                Close();
            }
        }


        private void NewProductCreationFormLoad(object sender, EventArgs e)
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
        public NewProductCreationForm(Guid currentUserID,
            ResourceManager languageResources, Recommendation? selectedProduct = null)
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

            if (selectedProduct != null)
            {
                this.selectedProduct = selectedProduct;
                saveMarkButton.MouseDown -= SaveNewProductInDatabase;
                saveMarkButton.MouseDown += SaveProductEditInDatabase;
                LoadProductInfo();
            }
        }
        #endregion
    }
}