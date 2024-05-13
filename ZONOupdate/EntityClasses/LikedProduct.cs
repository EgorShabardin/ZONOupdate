namespace ZONOupdate.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель товара, который понравился пользователю.
    /// </summary>
    public class LikedProduct
    {
        public Guid LikedProductID { get; set; }

        public Guid ID { get; set; }

        public Guid RecommendationID { get; set; }
    }
}
