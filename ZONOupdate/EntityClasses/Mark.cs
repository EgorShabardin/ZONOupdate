namespace ZONOupdate.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель оценки.
    /// </summary>
    public class Mark
    {
        public Guid MarkID { get; set; }

        public int MarkValue { get; set; }

        public Guid ID { get; set; }

        public Guid RecommendationID { get; set; }
    }
}