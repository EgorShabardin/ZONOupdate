namespace ZONOupdate.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель цвета.
    /// </summary>
    public class Color
    {
        public Guid ColorID { get; set; }

        public string ColorName { get; set; } = null!;
    }
}