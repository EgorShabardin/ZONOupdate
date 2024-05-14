using ZONOupdate.EntityClasses;
using System.Resources;
using NLog;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ZONOupdate.Database
{
    /// <summary>
    /// Класс взаимодействия с базой данных
    /// </summary>
    public static class DatabaseInteraction
    {
        #region Поля
        static ResourceManager languageResources = null!;
        static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Методы для входа/регистрации в приложении
        /// <summary>
        /// Метод, проверяющий вход в приложение через внутренний аккаунт ZONO.
        /// </summary>
        /// <param name="login"> Логин. </param>
        /// <param name="password"> Пароль. </param>
        /// <returns> true - вход разрешен; false - вход запрещен. </returns>
        public static bool CheckingLoginViaZONOAccount(string login, string password)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке входа через" +
                        "внутренний аккаунт ZONO");

                    var User = database.Users.Where(user => user.Login == login)
                        .Where(user => (user.InternalAccount == 1)).FirstOrDefault();

                    if (User != null)
                    {
                        if (User.Password == DataEncryption.HashingData(password))
                        {
                            logger.Debug($"Пользователь с id {User.ID} вошел в аккаунт");

                            Program.SetLoginInformation(true, User.ID);
                            return true;
                        }
                    }

                    logger.Debug("Пользователь не вошел в аккаунт, т.к." +
                        "введен неверный логин или пароль");

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
        /// Метод, проверяющий существует ли введенный email в базе данных.
        /// </summary>
        /// <param name="login"> Email почта. </param>
        /// <returns> true - почты нет в базе данных; false - почта есть в базе данных. </returns>
        public static bool CheckingLoginExistence(string login)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при проверке существования" +
                        "email почты");

                    var User = database.Users.Where(user => user.Login == login).
                        Where(user => (user.InternalAccount == 1)).FirstOrDefault();

                    return User != null ? false : true;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }

        /// <summary>
        /// Метод, регистрирующий нового пользователя в приложении.
        /// </summary>
        /// <param name="login"> Логин. </param>
        /// <param name="password"> Пароль. </param>
        /// <returns> true - пользователь зарегистрирован; false - пользователь не зарегистрирован. </returns>
        public static bool RegistrationNewUser(string login, string password)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке регистрации");

                    var user = database.Users.Where(user => user.Login == login).FirstOrDefault();

                    if (user == null)
                    {
                        var newUser = new User
                        {
                            Login = login,
                            Password = DataEncryption.HashingData(password),
                            IsBusy = Convert.ToInt32(false),
                            InternalAccount = Convert.ToInt32(true)
                        };

                        database.Users.Add(newUser);
                        database.SaveChanges();

                        logger.Info($"Пользователь с id {newUser.ID} успешно зарегистрирован");

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
        /// Метод, регистрирующий пользователя, зашедшего со стороннего сервиса, в приложении.
        /// </summary>
        /// <param name="login"> Логин. </param>
        public static bool RegistrationWithLoginFromThirdPartyApplication(string login)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке регистрации " +
                        "пользователя зашедшего со стороннего приложения");

                    var user = database.Users.Where(user => user.Login == login)
                        .Where(user => user.InternalAccount == Convert.ToInt32(false)).FirstOrDefault();

                    if (user != null) 
                    {
                        Program.SetLoginInformation(true, user.ID);

                        return true;
                    }

                    var newUser = new User
                    {
                        Login = login,
                        Password = String.Empty,
                        IsBusy = Convert.ToInt32(false),
                        InternalAccount = Convert.ToInt32(false)
                    };


                    database.Users.Add(newUser);
                    database.SaveChanges();

                    Program.SetLoginInformation(true, newUser.ID);

                    logger.Info($"Пользователь с id {newUser.ID} успешно зарегистрирован");

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }
        #endregion

        #region Остальные Методы

        public static Recommendation[] LoadRecomendationsFromCollection(Guid collectionID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    var recomendationsInCollection = database.RecommendationInCollections.Where(collection => collection
                    .CollectionID == collectionID).ToArray();

                    var recomendations = new Recommendation[recomendationsInCollection.Length];

                    for (int i = 0; i < recomendations.Length; i++)
                    {
                        var currentRecomendation = database.Recommendations.Where(recomendation => recomendation
                        .RecommendationId == recomendationsInCollection[i].RecommendationID).FirstOrDefault();

                        if (currentRecomendation != null)
                        {
                            recomendations[i] = currentRecomendation;
                        }
                    }

                    return recomendations;
                }
            }
            catch (Exception ex)
            {

                return Array.Empty<Recommendation>();
            }
        }

        public static UserCollection? AddNewCollection(Guid userID, string collectionName)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    var newCollection = new UserCollection()
                    {
                        CollectionID = Guid.NewGuid(),
                        ID = userID,
                        CollectionName = collectionName
                    };

                    logger.Info($"Добавлена новая подборка \"{collectionName}\"");

                    database.UserCollections.Add(newCollection);
                    database.SaveChanges();

                    return newCollection;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static string LoadUserEmail(Guid UserID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    var userEmail = database.Users.Where(user => user.ID == UserID).Select(user => user.Login).FirstOrDefault();

                    if (userEmail != null)
                    {
                        return userEmail;
                    }

                    return String.Empty;
                }
            }
            catch (Exception ex)
            {

                return String.Empty;
            }
        }

        public static RecommendationSetting? LoadingSearchSettings(Guid UserID)
        {
            using (var database = new DatabaseContext())
            {
                return database.RecommendationSettings.Where(setting => setting.ID == UserID).FirstOrDefault();
            }
        }

        public static object[] LoadingDataFromTables(string fieldName)
        {
            using (var database = new DatabaseContext())
            {
                var tableWithData = database.GetType().GetProperty(fieldName);

                if (tableWithData != null)
                {
                    return (tableWithData.GetValue(database) as DbSet<object>).ToArray();
                }

                return Array.Empty<object>();
            }
        }

        public static void CleanLikedProducts(Guid userID)
        {
            using (var database = new DatabaseContext())
            {
                var likedProducts = database.LikedProducts.Where(product => product.ID == userID).ToList();

                foreach (var product in likedProducts)
                {
                    database.LikedProducts.Remove(product);

                }
                database.SaveChanges();
            }
        }

        /// <summary>
        /// Метод поиска пользователя по ID
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        public static User FindUser(Guid userID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при поиске пользователя по id");

                    var user = database.Users.Where(userR => userR.ID == userID).FirstOrDefault();

                    return user != null ? user : null!;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return null!;
            }
        }

        /// <summary>
        /// Метод проверки является ли товар избранным пользователя
        /// </summary>
        /// <param name="RecommendationID">ID товара</param>
        /// <param name="ID">ID пользователя</param>
        public static bool IsProductInFavorites(Guid RecommendationID, Guid ID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при поиске избранных товаров");

                    bool isInFavorites = database.Favorites.Any(favorite =>
                    favorite.RecommendationID == RecommendationID && favorite.ID == ID);

                    return isInFavorites;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        public static string IsProductInCollection(Guid RecommendationID, Guid ID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при поиске избранных товаров");

                    var collection = database.RecommendationInCollections.Where(recomendation =>
                    recomendation.RecommendationID == RecommendationID && recomendation.UserID == ID).FirstOrDefault();

                    if (collection != null)
                    {
                        return database.UserCollections.Where(collection => collection.CollectionID == collection.CollectionID).Select(collection => collection.CollectionName).First();
                    }

                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return String.Empty;
            }
        }

        /// <summary>
        /// Метод загрузки подборок пользователя
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        public static string[] LoadUserCollections(Guid userID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при поиске подборок пользователя");

                    string[] userCollections = database.UserCollections.Where(collection => collection.ID == userID)
                        .Select(collection => collection.CollectionName).ToArray();

                    return userCollections;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return Array.Empty<string>();
            }
        }

        /// <summary>
        /// Метод загрузки типов товаров
        /// </summary>
        public static string[] LoadProductTypes()
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при загрузке всех типов товаров");

                    string[] productTypes = database.ProductTypes.OrderBy(product => product.ProductTypeName)
                        .Select(product => product.ProductTypeName).ToArray();

                    return productTypes;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return Array.Empty<string>();
            }
        }

        /// <summary>
        /// Метод добавления товара в избранное
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        /// <param name="recommendationId">ID товара</param>
        public static void AddToFavorites(Guid userID, Guid recommendationId)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке добавить товар в избранное");

                    var userFavorite = new Favorite
                    {
                        FavoriteID = Guid.NewGuid(),
                        ID = userID,
                        RecommendationID = recommendationId
                    };

                    logger.Debug($"Товар с id {recommendationId} добавлен в избранное " +
                        $"пользователю с id {userID}");

                    database.Favorites.Add(userFavorite);
                    database.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод удаления товара из избранного
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        /// <param name="recommendationId">ID товара</param>
        public static void RemoveFromFavorites(Guid userID, Guid recommendationId)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке удаления товара из избранного");

                    var userFavorite = database.Favorites.Where(favorite => favorite.ID == userID)
                        .Where(favorite => favorite.RecommendationID == recommendationId).FirstOrDefault();

                    if (userFavorite != null) 
                    {
                        logger.Debug($"Товар с id {recommendationId} удален из избранного " +
                        $"пользовател с id {userID}");

                        database.Favorites.Remove(userFavorite);
                        database.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод добавления товара в коллекцию
        /// </summary>
        /// <param name="recommendationID">ID товара</param>
        /// <param name="collectionID">ID коллекции</param>
        public static void AddProductToCollection(Guid recommendationID, Guid collectionID, Guid userID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке добавить товар в подборку");

                    var existingRelation = database.RecommendationInCollections.FirstOrDefault(product => product.RecommendationID
                    == recommendationID && product.CollectionID == collectionID);

                    if (existingRelation != null)
                    {
                        return;
                    }

                    var otherRelations = database.RecommendationInCollections.Where(product => product.RecommendationID
                    == recommendationID && product.CollectionID != collectionID).ToList();

                    if (otherRelations.Any())
                    {
                        foreach (var relation in otherRelations)
                        {
                            database.RecommendationInCollections.Remove(relation);
                        }
                    }

                    var newRelation = new RecommendationInCollection()
                    {
                        RecommendationInCollectionsID = Guid.NewGuid(),
                        RecommendationID = recommendationID,
                        CollectionID = collectionID,    
                        UserID = userID
                    };

                    logger.Debug($"Товар с id {recommendationID} успешно добавлен в подборку с id {collectionID}");

                    database.RecommendationInCollections.Add(newRelation);
                    database.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод добавления новой оценки
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        /// <param name="recommendationID">ID товара</param>
        /// <param name="markValue">Оценка</param>
        public static void AddNewMark(Guid userID, Guid recommendationID, int markValue)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при попытке поставить оценку товару");

                    var relatedMarks = database.Marks.Where(mark => mark.ID == userID).Where(mark => mark.RecommendationID
                    == recommendationID).ToList();
                    if (relatedMarks.Any())
                    {
                        foreach (var mark in relatedMarks)
                        {
                            database.Marks.Remove(mark);
                        }
                    }
                    var newMark = new Mark()
                    {
                        ID = userID,
                        MarkValue = markValue,
                        RecommendationID = recommendationID,
                        MarkID = Guid.NewGuid()
                    };

                    logger.Debug($"Оценка с id {newMark.ID} успешно добавлен товару с id {recommendationID}");

                    database.Marks.Add(newMark);
                    database.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод рассчёта рейтинга товара
        /// </summary>
        /// <param name="recommendationID">ID товара</param>
        public static float CountProductRating(Guid recommendationID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при загрузке рейтинга товара");

                    var listOfMarks = database.Marks.Where(mark => mark.RecommendationID == recommendationID).ToList();
                    var numberOfMarks = listOfMarks.Count();
                    var sumOfMarks = 0;

                    foreach (var mark in listOfMarks)
                    {
                        sumOfMarks += mark.MarkValue;
                    }

                    double rating = (double)sumOfMarks / numberOfMarks;

                    logger.Debug($"Оценка товара с id {recommendationID} успешно загружена");

                    return (float)Math.Round(rating, 2);
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return 0;
            }
        }

        /// <summary>
        /// Метод проверки понравился ли товар пользователю
        /// </summary>
        /// <param name="RecommendationID">ID товара</param>
        /// <param name="ID">ID пользователя</param>
        public static bool IsProductLiked(Guid RecommendationID, Guid ID)
        {
            try
            {
                using (var database = new DatabaseContext())
                {
                    logger.Info("Успешное подключение к базе данных при проверке понравившихся " +
                        "пользователю товаров");

                    bool isInLiked = database.LikedProducts.Any(product =>
                    product.RecommendationID == RecommendationID && product.ID == ID);

                    return isInLiked;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                MessageBox.Show(languageResources.GetString("errorWhenWorkingWithDatabaseContent") + ex,
                    languageResources.GetString("errorWhenWorkingWithDatabaseTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
        #endregion
    }
}