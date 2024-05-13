using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using NLog;

namespace ZONOupdate.FunctionalClasses
{
    /// <summary>
    /// Класс преобразования изображения из byte[] в Image
    /// </summary>
    public static class CustomImageConverter
    {
        #region Поля
        static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Методы
        /// <summary>
        /// Метод для преобразования изображения
        /// </summary>
        /// <param name="byteArray">Массив пикселей, который хранится в базе данных (BLOB)</param>
        /// <returns></returns>
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

        public static string GetImageHash(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                ms.Position = 0;

                using (SHA256Managed sha256 = new SHA256Managed())
                {
                    byte[] hash = sha256.ComputeHash(ms);
                    return BitConverter.ToString(hash).Replace("-", string.Empty);
                }
            }
        }
        #endregion
    }
}