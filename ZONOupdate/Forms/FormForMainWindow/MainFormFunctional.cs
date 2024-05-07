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
                    recomendation.Dock = DockStyle.Fill;
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

        public bool SelectionOfRecommendations(Guid userID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    if (database.LikedProducts.Where(product => product.ID == userID).Count() <= 0)
                    {
                        return false;
                    }

                    var existingSetting = database.RecommendationSettings.Where(setting => setting.ID == userID).FirstOrDefault();

                    if (existingSetting != null)
                    {
                        database.RecommendationSettings.Remove(existingSetting);
                        database.SaveChanges();
                    }
                    var likedProducts = database.LikedProducts.Where(product => product.ID == userID).
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
                        ID = userID,
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

                    DatabaseInteraction.CleanLikedProducts(userID);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка. Код ошибки: {ex}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }


        #endregion
    }
}
