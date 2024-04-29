namespace ZONOupdate.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель рекомендаций пользователя
    /// </summary>
    public class Recommendation
    {
        public Guid RecommendationId { get; set; }

        public Guid ID { get; set; }

        public string RecommendationName { get; set; } = null!;

        public string RecommendationDescription { get; set; } = null!;

        public float RecommendationMark { get; set; }

        public Guid ProductTypeID {  get; set; }

        public int YearOfProduction { get; set; }

        public Guid ManufacturerID { get; set; }

        public Guid ColorID { get; set; }

        public int  ProductPriceFrom { get; set; }

        public byte[] ProductPhoto { get; set; } = null!;
    }
}