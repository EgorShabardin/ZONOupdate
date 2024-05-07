using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZONOupdate.Database;
using ZONOupdate.ProjectControls.ControlForCollectionName;
using ZONOupdate.ProjectControls;
using NLog;
using ZONOupdate.EntityClasses;
using System.Resources;

namespace ZONOupdate.Forms.FormForMainWindow
{
    internal class MainFormFunctional
    {
        #region Поля
        Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Методы
        /// <summary>
        /// Метод заполнения таблицы flowLayoutPanel на главной странице
        /// </summary>
        /// <param name="productsFlowLayoutPanel">Таблица с товарами</param>
        public void FillingMainPageLayoutPanel(FlowLayoutPanel productsFlowLayoutPanel, Guid UserID,
            ResourceManager languageResources)
        {
            using (var database = new DatabaseContext())
            {
                var recommendations = database.Recommendations.ToList();
                var productControls = new List<ProductControl>();

                foreach (var product in recommendations)
                {
                    var recomendation = new ProductControl(product, UserID, languageResources);
                    recomendation.MakeProductControlForMainPageOrForFavorites(productsFlowLayoutPanel.ClientSize.Width);
                    productControls.Add(recomendation);
                }

                productsFlowLayoutPanel.Controls.AddRange(productControls.ToArray());
            }
        }

        /// <summary>
        /// Метод заполнения таблицы flowLayoutPanel на странице Мои товары
        /// </summary>
        /// <param name="productsFlowLayoutPanel">Таблица с товарами</param>
        public void FillMyProductsLayoutPanel(FlowLayoutPanel productsFlowLayoutPanel, Guid UserID,
            ResourceManager languageResources)
        {
            using (var database = new DatabaseContext())
            {
                var myProducts = database.Recommendations.Where(product => product.ID == UserID).ToList();
                var productControls = new List<ProductControl>();

                foreach (var product in myProducts)
                {
                    var productControl = new ProductControl(product, UserID, languageResources);
                    productControl.MakeProductControlForMyProducts(productsFlowLayoutPanel.ClientRectangle.Width);
                    productControls.Add(productControl);
                }

                productsFlowLayoutPanel.Controls.AddRange(productControls.ToArray());
            }
        }

        /// <summary>
        /// Метод заполнения таблицы flowLayoutPanel на странице избранное
        /// </summary>
        /// <param name="productsFlowLayoutPanel">Таблица с товарами</param>
        public void FillFavoritesLayoutPanel(FlowLayoutPanel productsFlowLayoutPanel, Guid UserID,
            ResourceManager languageResources)
        {
            using (var database = new DatabaseContext())
            {
                var favoritesID = database.Favorites.Where(favorite => favorite.ID == UserID)
                    .Select(favorite => favorite.RecommendationID).ToList();
                var productControls = new List<ProductControl>();

                foreach (var favoriteID in favoritesID)
                {
                    var product = database.Recommendations.Where(recomendation => recomendation
                    .RecommendationId == favoriteID).First();
                    var favoriteControl = new ProductControl(product, UserID, languageResources);
                    favoriteControl.MakeProductControlForMainPageOrForFavorites(productsFlowLayoutPanel.ClientSize.Width);
                    productControls.Add(favoriteControl);
                }

                productsFlowLayoutPanel.Controls.AddRange(productControls.ToArray());
            }
        }
        /// <summary>
        /// Метод заполнения списка подборок пользователя
        /// </summary>
        /// <param name="productsFlowLayoutPanel">Таблица с товарами</param>
        public void FillingListFlowLayoutPanel(FlowLayoutPanel listFlowLayoutPanel, FlowLayoutPanel productsFlowLayoutPanel, User currentUser,
            ResourceManager languageResources)
        {
            using (var database = new DatabaseContext())
            {
                var collections = database.UserCollections.Where(collection => collection.ID == currentUser.ID).ToList();
                var productControls = new List<CollectionNameControl>();

                foreach (var collection in collections)
                {
                    var collectionControl = new CollectionNameControl(currentUser, collection, productsFlowLayoutPanel,
                        languageResources, listFlowLayoutPanel.ClientRectangle.Width);
                    productControls.Add(collectionControl);
                }

                listFlowLayoutPanel.Controls.AddRange(productControls.ToArray());
            }
        }

        /// <summary>
        /// Метод заполнения таблицы flowLayoutPanel на главной странице с учетом предпочтений пользователя
        /// </summary>
        /// <param name="productsFlowLayoutPanel">Таблица с товарами</param>
        public void FillingMainPageLayoutPanelWithSetting(FlowLayoutPanel productsFlowLayoutPanel, RecommendationSetting setting, Guid UserID, ResourceManager languageResources)
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
                            var control = new ProductControl(product, UserID, languageResources);
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

        #endregion
    }
}
