namespace ZONOupdate.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель данных пользователя.
    /// </summary>
    public class User
    {
        public Guid ID { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int IsBusy { get; set; }

        public int InternalAccount { get; set; }
    }
}