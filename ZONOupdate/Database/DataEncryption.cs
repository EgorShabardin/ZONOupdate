using System.Security.Cryptography;
using System.Text;

namespace ZONOupdate.Database
{
    /// <summary>
    /// Класс шифрования данных.
    /// </summary>
    internal static class DataEncryption
    {
        /// <summary>
        /// Метод для шифрования данных, используемый для логина и пароля.
        /// </summary>
        /// <param name="dataString"> Логин/Пароль. </param>
        /// <returns> Зашифрованные данные. </returns>
        public static string HashingData(string dataString)
        {
            byte[] dataInBytesArray = Encoding.ASCII.GetBytes(dataString);
            byte[] hashedDataArray = MD5.HashData(dataInBytesArray);

            var hashedDataString = new StringBuilder();

            foreach (var element in hashedDataArray)
            {
                hashedDataString.Append(element.ToString("X2"));
            }

            return Convert.ToString(hashedDataString) ?? String.Empty;
        }
    }
}