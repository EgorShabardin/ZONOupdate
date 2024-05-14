using NLog;

namespace ZONOupdate.FunctionalClasses
{
    /// <summary>
    /// Класс преобразования изображения из byte[] в Image.
    /// </summary>
    public static class CustomImageConverter
    {
        #region Поля
        static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Методы
        /// <summary>
        /// Метод для преобразования изображения из byte[] в Image.
        /// </summary>
        /// <param name="byteArray"> Массив пикселей, который хранится в базе данных (BLOB). </param>
        /// <returns> Объект Image. </returns>
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            logger.Debug("Изображение из базы данных конвертировано");

            using (var memoryStream = new MemoryStream(byteArray))
            {
                var image = new Bitmap(Image.FromStream(memoryStream));
                image.MakeTransparent(Color.White);

                return image != null ? image : null!;
            }
        }
        #endregion
    }
}