namespace ZONOupdate.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель рекомендаций пользователя.
    /// </summary>
    public class RecommendationSetting
    {
        public Guid RecommendationSettingID { get; set; }

        public Guid ID { get; set; }

        public Guid SelectedTypeID { get; set; }

        public int MinPrice {  get; set; }

        public int MaxPrice { get; set; }

        public int MinYear {  get; set; }

        public int MaxYear { get; set; }

        public string SelectedColors { get; set; } = null!;

        public string SelectedManufacturers { get; set; } = null!;
    }
}