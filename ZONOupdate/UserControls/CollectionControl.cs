using ZONOupdate.EntityClasses;
using ZONOupdate.Database;
using System.Drawing.Text;
using System.Resources;
using NLog;

namespace ZONOupdate.UserControls
{
    /// <summary>
    /// Кастомный control для отображение подборки в разделе "Мои подборки".
    /// </summary>
    public partial class CollectionControl : UserControl
    {
        #region Поля
        User currentUser;
        UserCollection currentCollection;
        ResourceManager languageResources;
        FlowLayoutPanel flowLayoutPanel = null!;
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region События
        private void ClickOnCollectionControl(object sender, MouseEventArgs e)
        {
            logger.Debug($"Пользователь нажал на подборку с id {currentCollection}");

            flowLayoutPanel.Controls.Clear();
            using (var database = new DatabaseContext())
            {
                var products = database.RecommendationInCollections.Where(collection => collection.CollectionID
                == currentCollection.CollectionID).ToList();

                foreach (var product in products)
                {
                    var currentProduct = database.Recommendations.Where(item => item.RecommendationId
                    == product.RecommendationID).FirstOrDefault();

                    if (currentProduct != null)
                    {
                        var control = new ProductControl(currentProduct, currentUser.ID, languageResources);
                        control.MakeProductControlForMyCollections(flowLayoutPanel.Width);
                        flowLayoutPanel.Controls.Add(control);
                    }
                }
            }
        }
        #endregion

        #region Конструкторы
        public CollectionControl(UserCollection thisCollection, FlowLayoutPanel productsFlowLayoutPanel,
            User currentUser, ResourceManager languageResources, int width)
        {
            logger.Info($"Создан элемент управления для коллекции с id {thisCollection.ID}");

            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            this.languageResources = languageResources;
            flowLayoutPanel = productsFlowLayoutPanel;
            this.currentUser = currentUser;
            InitializeComponent();

            Width = width - 23;

            using (var database = new DatabaseContext())
            {
                var currentCollection = database.UserCollections.Where(collection => collection.ID == currentUser.ID
                && collection.CollectionName == thisCollection.CollectionName).FirstOrDefault();

                if (currentCollection != null)
                {
                    collectionNameLabel.Text = currentCollection.CollectionName;
                    this.currentCollection = currentCollection;
                }
            }

            collectionNameLabel.Font = new Font(fontCollection.Families[0], 14);
        }
        #endregion
    }
}