namespace ZONOupdate.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель товара, назначенного избранным у пользователя.
    /// </summary>
    public class Favorite
    {
        public Guid FavoriteID { get; set; }

        public Guid ID { get; set; }

        public Guid RecommendationID { get; set; }
    }
}