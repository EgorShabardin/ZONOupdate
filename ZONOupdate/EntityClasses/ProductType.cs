namespace ZONOupdate.EntityClasses
{
    /// <summary>
    /// Класс, представляющий модель типа товара
    /// </summary>
    public class ProductType
    {
        public Guid ProductTypeID { get; set; }

        public string ProductTypeName { get; set; } = null!;
    }
}