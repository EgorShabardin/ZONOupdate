using ZONOupdate.ProjectControls.ControlForDisplayingProduct;
using ZONOupdate.FunctionalClasses;
using ZONOupdate.EntityClasses;
using ZONOupdate.Database;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Resources;
using NLog;

namespace ZONOupdate.Forms.FormForCreationNewProduct
{
    /// <summary>
    /// Форма, предназначенная для добавления/редактирования товара.
    /// </summary>
    public partial class NewProductCreationForm : Form
    {
        #region Поля
        Guid currentUserID;
        Recommendation? selectedProduct;
        ResourceManager languageResources;
        FlowLayoutPanel productFlowLayoutPanel;
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region Методы
        private void LoadProductInformation()
        {
            using (var database = new DatabaseContext())
            {
                if (selectedProduct != null)
                {
                    logger.Info("Успешное подключение к базе данных при загрузке данных товара для редактирования");

                    var colorName = database.Colors.Where(color => color
                    .ColorID == selectedProduct.ColorID).Select(color => color.ColorName)
                    .FirstOrDefault();
                    var productTypeName = database.ProductTypes.Where(productType => 
                    productType.ProductTypeID == selectedProduct.ProductTypeID)
                        .Select(productType => productType.ProductTypeName).FirstOrDefault();
                    var manufactorName = database.Manufacturers.Where(manufacturer
                        => manufacturer.ManufacturerID == selectedProduct.ManufacturerID)
                        .Select(manufacturer => manufacturer.ManufacturerName).FirstOrDefault();

                    productNameTextBox.Text = selectedProduct.RecommendationName;
                    productDescriptionTextBox.Text = selectedProduct
                        .RecommendationDescription;
                    productColorComboBox.SelectedItem = colorName;
                    productTypeComboBox.SelectedItem = productTypeName;
                    productManufacturerComboBox.SelectedItem = manufactorName;
                    productYearOfProductionTextBox.Text = selectedProduct
                        .YearOfProduction.ToString();
                    productPriceTextBox.Text = selectedProduct
                        .ProductPriceFrom.ToString();
                    productPhotoPictureBox.Image = CustomImageConverter.ByteArrayToImage(selectedProduct.ProductPhoto);

                    productPhotoPictureBox.BorderStyle = BorderStyle.None;
                }
            }
        }

        private void LoadComboBoxesData()
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при загрузке данных товраов");

                var manufacturerNames = database.Manufacturers.AsEnumerable()
                    .Select(manufacter => manufacter.ManufacturerName).ToArray();
                var typeNames = database.ProductTypes.AsEnumerable()
                    .Select(productType => productType.ProductTypeName).ToArray();
                var colorNames = database.Colors.AsEnumerable()
                    .Select(colors => colors.ColorName).ToArray();

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
                openFileDialog.Title = languageResources.GetString("loadProductPhoto");
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    productPhotoPictureBox.Image = new Bitmap(openFileDialog.FileName);
                    productPhotoPictureBox.BorderStyle = BorderStyle.None;

                    logger.Info("Изображение товара успешно загружено");
                }
            }
        }

        private void SaveNewProductButtonMouseDown(object sender, MouseEventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешноу подключение к базе данных при создании нового товара");

                var manufacturersID = database.Manufacturers.AsEnumerable()
                    .Select(manufacturer => manufacturer.ManufacturerID).ToArray();
                var productTypesID = database.ProductTypes.AsEnumerable()
                    .Select(productType => productType.ProductTypeID).ToArray();
                var colorsID = database.Colors.AsEnumerable().Select(color => color.ColorID)
                    .ToArray();

                var newProduct = new Recommendation()
                {
                    ID = currentUserID,
                    RecommendationId = Guid.NewGuid(),
                    RecommendationMark = 0,
                    RecommendationName = productNameTextBox.Text,
                    RecommendationDescription = productDescriptionTextBox.Text,
                    ProductPriceFrom = int.Parse(productPriceTextBox.Text),
                    YearOfProduction = int.Parse(productYearOfProductionTextBox.Text)
                };

                using (var memoryStream = new MemoryStream())
                {
                    productPhotoPictureBox.Image.Save(memoryStream, ImageFormat.Jpeg);
                    newProduct.ProductPhoto = memoryStream.ToArray();
                }

                newProduct.ColorID = colorsID[productColorComboBox.SelectedIndex];
                newProduct.ManufacturerID = manufacturersID[productManufacturerComboBox
                    .SelectedIndex]; 
                newProduct.ProductTypeID = productTypesID[productTypeComboBox
                    .SelectedIndex];

                database.Recommendations.Add(newProduct);
                database.SaveChanges();

                logger.Debug($"Товар с id {newProduct.RecommendationId} успешно добавлен");

                var productControl = new ProductControl(newProduct, currentUserID,
                    languageResources);
                productControl.MakeProductControlForMyProducts(productFlowLayoutPanel.Width);
                productControl.Name = newProduct.RecommendationName;

                productFlowLayoutPanel.Controls.Add(productControl);
                productFlowLayoutPanel.Refresh();

                Close();
            }
        }

        private void SaveProductСhangesButtonMouseDown(object sender, MouseEventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешноу подключение к базе данных при сохранении данных товара");

                var currentProduct = database.Recommendations.Where(product => product
                .RecommendationId == selectedProduct.RecommendationId).FirstOrDefault();

                if (currentProduct != null)
                {
                    var manufacturersID = database.Manufacturers.AsEnumerable()
                    .Select(manufacturer => manufacturer.ManufacturerID).ToArray();
                    var productTypesID = database.ProductTypes.AsEnumerable()
                        .Select(productType => productType.ProductTypeID).ToArray();
                    var colorsID = database.Colors.AsEnumerable().Select(color => color.ColorID)
                        .ToArray();

                    currentProduct.RecommendationName = productNameTextBox.Text;
                    currentProduct.RecommendationDescription = productDescriptionTextBox.Text;
                    currentProduct.ProductPriceFrom = int.Parse(productPriceTextBox.Text);
                    currentProduct.YearOfProduction = int.Parse(productYearOfProductionTextBox.Text);

                    using (var memoryStream = new MemoryStream())
                    {
                        productPhotoPictureBox.Image.Save(memoryStream, ImageFormat.Jpeg);
                        currentProduct.ProductPhoto = memoryStream.ToArray();
                    }

                    currentProduct.ColorID = colorsID[productColorComboBox.SelectedIndex];
                    currentProduct.ManufacturerID = manufacturersID[productManufacturerComboBox
                        .SelectedIndex];
                    currentProduct.ProductTypeID = productTypesID[productTypeComboBox
                        .SelectedIndex];

                    logger.Debug($"Товар с id {currentProduct.RecommendationId} успешно " +
                        $"отредактирован");

                    var productControl = productFlowLayoutPanel.Controls[currentProduct
                        .RecommendationId.ToString()] as ProductControl;

                    if (productControl != null)
                    {
                        productControl.MakingChangesToProduct(currentProduct);
                    }

                    database.SaveChanges();

                    Close();
                }
            }
        }

        private void NewProductCreationOrEditFormLoad(object sender, EventArgs e)
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
        public NewProductCreationForm(Guid currentUserID, ResourceManager languageResources,
            FlowLayoutPanel productFlowLayoutPanel, Recommendation? selectedProduct = null)
        {
            logger.Info("Открылась форма \"Создать/редактировать товар\"");

            this.currentUserID = currentUserID;
            this.languageResources = languageResources;
            this.productFlowLayoutPanel = productFlowLayoutPanel;
            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            InitializeComponent();

            productNameTextBox.Font = new Font(fontCollection.Families[0], 16);
            loadProductPhotoButton.Font = new Font(fontCollection.Families[0], 12);
            productDescriptionTextBox.Font = new Font(fontCollection.Families[0], 12);
            productColorLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productYearOfProductionLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productManufacturerLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productTypeLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            productPriceLabelTitle.Font = new Font(fontCollection.Families[0], 14);
            saveProductButton.Font = new Font(fontCollection.Families[0], 14);
            productTypeComboBox.Font = new Font(fontCollection.Families[0], 12);
            productManufacturerComboBox.Font = new Font(fontCollection.Families[0], 12);
            productYearOfProductionTextBox.Font = new Font(fontCollection.Families[0], 12);
            productColorComboBox.Font = new Font(fontCollection.Families[0], 12);
            productPriceTextBox.Font = new Font(fontCollection.Families[0], 12);

            productNameTextBox.PlaceholderText = languageResources.GetString(productNameTextBox.Name);
            loadProductPhotoButton.Text = languageResources.GetString(loadProductPhotoButton.Name);
            productDescriptionTextBox.PlaceholderText = languageResources.GetString(productDescriptionTextBox.Name);
            productColorLabelTitle.Text = languageResources.GetString(productColorLabelTitle.Name);
            productYearOfProductionLabelTitle.Text = languageResources.GetString(productYearOfProductionLabelTitle.Name);
            productManufacturerLabelTitle.Text = languageResources.GetString(productManufacturerLabelTitle.Name);
            productTypeLabelTitle.Text = languageResources.GetString(productTypeLabelTitle.Name);
            productPriceLabelTitle.Text = languageResources.GetString(productPriceLabelTitle.Name);
            saveProductButton.Text = languageResources.GetString(saveProductButton.Name);
            Text = languageResources.GetString(Name);

            LoadComboBoxesData();

            if (selectedProduct != null)
            {
                this.selectedProduct = selectedProduct;
                saveProductButton.MouseDown -= SaveNewProductButtonMouseDown;
                saveProductButton.MouseDown += SaveProductСhangesButtonMouseDown;
                LoadProductInformation();
            }
        }
        #endregion
    }
}