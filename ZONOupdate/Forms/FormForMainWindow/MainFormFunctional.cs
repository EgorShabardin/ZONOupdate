using ZONOupdate.ProjectControls.ControlForCollectionName;
using ZONOupdate.ProjectControls;
using ZONOupdate.EntityClasses;
using ZONOupdate.Database;
using System.Resources;
using NLog;

namespace ZONOupdate.Forms.FormForMainWindow
{
    /// <summary>
    /// Класс, содержащий функционал формы MainForm.
    /// </summary>
    internal class MainFormFunctional
    {
        #region Поля
        Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Методы
        /// <summary>
        /// Метод, заполняющий таблицу товаров в разделе "Главная страница".
        /// </summary>
        /// <param name="productsFlowLayoutPanel"> Таблица товаров. </param>
        /// <param name="UserID"> ID пользователя. </param>
        /// <param name="languageResources"> Файл локализации. </param>
        /// <returns> true - товары добавлены; false - ошибка в добавлении товаров. </returns>
        internal bool FillingMainPageLayoutPanel(FlowLayoutPanel productsFlowLayoutPanel,
            Guid UserID, ResourceManager languageResources)
        {
            try 
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при загрузке товаров " +
                        "в разделе \"Главная страница\"");

                    var recommendations = database.Recommendations.ToList();
                    var productControls = new List<ProductControl>();

                    foreach (var product in recommendations)
                    {
                        var recomendation = new ProductControl(product, UserID, languageResources);
                        recomendation.MakeProductControlForMainPageOrForFavorites
                            (productsFlowLayoutPanel.Width);

                        productControls.Add(recomendation);
                    }

                    productsFlowLayoutPanel.Controls.AddRange(productControls.ToArray());

                    return true;
                }
            }
            catch (Exception ex) 
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }

        /// <summary>
        /// Метод, заполняющий таблицу товаров в разделе "Мои товары".
        /// </summary>
        /// <param name="productsFlowLayoutPanel"> Таблица товаров. </param>
        /// <param name="UserID"> ID пользователя. </param>
        /// <param name="languageResources"> Файл локализации. </param>
        /// <returns> true - товары добавлены; false - ошибка в добавлении товаров. </returns>
        internal bool FillMyProductsLayoutPanel(FlowLayoutPanel productsFlowLayoutPanel,
            Guid UserID, ResourceManager languageResources)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при загрузке товаров " +
                        "в разделе \"Мои товары\"");

                    var myProducts = database.Recommendations.Where(product => product.ID == UserID)
                        .ToList();
                    var productControls = new List<ProductControl>();

                    foreach (var product in myProducts)
                    {
                        var productControl = new ProductControl(product, UserID, languageResources);
                        productControl.MakeProductControlForMyProducts(productsFlowLayoutPanel.Width);

                        productControls.Add(productControl);
                    }

                    productsFlowLayoutPanel.Controls.AddRange(productControls.ToArray());

                    return true;
                }
            }
            catch(Exception ex) 
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }

        /// <summary>
        /// Метод, заполняющий таблицу товаров в разделе "Избранное".
        /// </summary>
        /// <param name="productsFlowLayoutPanel"> Таблица товаров. </param>
        /// <param name="UserID"> ID пользователя. </param>
        /// <param name="languageResources"> Файл локализации. </param>
        /// <returns> true - товары добавлены; false - ошибка в добавлении товаров. </returns>
        internal bool FillFavoritesLayoutPanel(FlowLayoutPanel productsFlowLayoutPanel,
            Guid UserID, ResourceManager languageResources)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при загрузке товаров " +
                        "в разделе \"Избранное\"");

                    var favoritesID = database.Favorites.Where(favorite => favorite
                    .ID == UserID).Select(favorite => favorite.RecommendationID).ToList();
                    var productControls = new List<ProductControl>();

                    foreach (var favoriteID in favoritesID)
                    {
                        var productInFavorite = database.Recommendations.Where(recomendation
                            => recomendation.RecommendationId == favoriteID).FirstOrDefault();

                        if (productInFavorite != null)
                        {
                            var favoriteControl = new ProductControl(productInFavorite,
                                UserID, languageResources);
                            favoriteControl.MakeProductControlForMainPageOrForFavorites(productsFlowLayoutPanel.Width);

                            productControls.Add(favoriteControl);
                        }
                    }

                    productsFlowLayoutPanel.Controls.AddRange(productControls.ToArray());

                    return true;
                }
            }
            catch(Exception ex) 
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }

        /// <summary>
        /// Метод, заполняющий таблицу с подборками в разделе "Мои подборки".
        /// </summary>
        /// <param name="listFlowLayoutPanel"> Таблица подборок. </param>
        /// <param name="productsFlowLayoutPanel"> Таблица товаров. </param>
        /// <param name="currentUser"> Текущий пользователь. </param>
        /// <param name="languageResources"> Файл локализации. </param>
        /// <returns> true - товары добавлены; false - ошибка в добавлении товаров. </returns>
        internal bool FillingListFlowLayoutPanel(FlowLayoutPanel listFlowLayoutPanel,
            FlowLayoutPanel productsFlowLayoutPanel, User currentUser, ResourceManager languageResources)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при загрузке подборок " +
                        "в разделе \"Мои подборки\"");

                    var collections = database.UserCollections.Where(collection =>
                    collection.ID == currentUser.ID).ToList();
                    var productControls = new List<CollectionNameControl>();

                    foreach (var collection in collections)
                    {
                        var collectionControl = new CollectionNameControl(currentUser, collection,
                            productsFlowLayoutPanel, languageResources, listFlowLayoutPanel.Width);

                        productControls.Add(collectionControl);
                    }

                    listFlowLayoutPanel.Controls.Add(CreatingCollectionWithMatches(listFlowLayoutPanel,
                        productsFlowLayoutPanel, currentUser,languageResources));

                    listFlowLayoutPanel.Controls.AddRange(productControls.ToArray());

                    return true;
                }
            }
            catch (Exception ex) 
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }

        /// <summary>
        /// Метод, заполняющий таблицу товаров с учетом предпочтений пользователя в разделе "Главная страница".
        /// </summary>
        /// <param name="productsFlowLayoutPanel"> Таблица товаров. </param>
        /// <param name="setting"> Настройки отбора рекомендаций. </param>
        /// <param name="UserID"> ID пользователя. </param>
        /// <param name="languageResources"> Файл локализации. </param>
        /// <returns> true - товары добавлены; false - ошибка в добавлении товаров. </returns>
        internal bool FillingMainPageLayoutPanelWithSetting(FlowLayoutPanel productsFlowLayoutPanel,
            RecommendationSetting setting, Guid UserID, ResourceManager languageResources)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при загрузке товаров " +
                        "с учетом предпочтений пользователя в разделе \"Главная страница\"");

                    var selectedColorsArray = setting.SelectedColors.Split('/').ToList();

                    var selectedManufacturersArray = setting.SelectedManufacturers.Split('/').ToList();

                    var colorGuids = database.Colors.Where(color => selectedColorsArray.
                    Contains(color.ColorName)).Select(color => color.ColorID).ToList();

                    var manufacturerGuids = database.Manufacturers.Where(manufacturer =>
                    selectedManufacturersArray.Contains(manufacturer.ManufacturerName))
                        .Select(manufacturer => manufacturer.ManufacturerID).ToList();

                    var productTypeID = setting.SelectedTypeID;

                    var allrecommendations = database.Recommendations.Where(product => product
                            .ProductPriceFrom >= setting.MinPrice)
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

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }

        /// <summary>
        /// Метод, составляющий настройки для отбора рекомендаций.
        /// </summary>
        /// <param name="userID"> ID пользователя.</param>
        /// <returns> true - настройки составлены; false - ошибка в составлении настроек. </returns>
        internal bool SelectionOfRecommendations(Guid userID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при составлении настроек " +
                        "для отбора рекомендаций");

                    if (database.LikedProducts.Where(product => product.ID == userID).Count() <= 0)
                    {
                        return false;
                    }

                    var existingSetting = database.RecommendationSettings.Where(setting => setting
                    .ID == userID).FirstOrDefault();

                    if (existingSetting != null)
                    {
                        database.RecommendationSettings.Remove(existingSetting);
                        database.SaveChanges();
                    }

                    var likedProducts = database.LikedProducts.Where(product => product.ID == userID)
                        .Select(product => product.RecommendationID).ToList();
                    var years = new List<int>();
                    var prices = new List<int>();
                    var colors = new List<string>();
                    var manufacturers = new List<string>();

                    foreach (var likedproduct in likedProducts)
                    {
                        var product = database.Recommendations.Where(product => product
                        .RecommendationId == likedproduct).FirstOrDefault();

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

                    string colorTemp = String.Empty;
                    string manufacturerTemp = String.Empty;

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

                    var selectedTypeID = database.Recommendations.Where(product => product
                    .RecommendationId == likedProducts.First()).Select(product => product.ProductTypeID)
                    .FirstOrDefault();

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
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }

        /// <summary>
        /// Метод, составляющий подборку с популярными товарами.
        /// </summary>
        /// <param name="currentUser"> Текущий пользователь. </param>
        /// <param name="productsFlowLayoutPanel"> Таблица товаров. </param>
        /// <param name="languageResources"> Файл локализации. </param>
        /// <returns> Элемент управления для отображения подборки. </returns>
        private CollectionNameControl? CreatingCollectionWithMatches(FlowLayoutPanel listFlowLayoutPanel,
            FlowLayoutPanel productsFlowLayoutPanel, User currentUser, ResourceManager languageResources)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при составлении подборки " +
                        "с популярными товарами");

                    var userCollections = database.RecommendationInCollections
                        .Where(collection => collection.UserID != currentUser.ID).ToArray();

                    var recomendationCounts = userCollections.GroupBy(recomendation => recomendation)
                        .ToDictionary(recomendation => recomendation.Key, recomendationCount => recomendationCount.Count());

                    var sortedRecomendations = recomendationCounts.OrderByDescending(recomendation => recomendation.Value)
                        .SelectMany(recomendation => Enumerable.Repeat(recomendation.Key, recomendation.Value)).ToList();

                    var recomendations = new List<Recommendation>();

                    foreach (var item in sortedRecomendations)
                    {
                        recomendations.Add(database.Recommendations.Where(rec => rec
                        .RecommendationId == item.RecommendationID).First());
                    }

                    return new CollectionNameControl(currentUser, productsFlowLayoutPanel,
                        languageResources, recomendations, listFlowLayoutPanel.Width);
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return null;
            }
        }
        #endregion
    }
}