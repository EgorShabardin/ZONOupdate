namespace ZONOupdate.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель коллекций пользователя.
    /// </summary>
    public class UserCollection
    {
        public Guid CollectionID { get; set; }

        public Guid ID { get; set; }

        public string CollectionName { get; set; } = null!;
    }
}