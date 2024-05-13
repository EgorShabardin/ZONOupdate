namespace ZONOupdate.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель производителя.
    /// </summary>
    public class Manufacturer
    {
        public Guid ManufacturerID { get; set; }

        public string ManufacturerName { get; set; } = null!;
    }
}