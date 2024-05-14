using ZONOupdate.Forms.FormForWelcomingUser;
using ZONOupdate.Forms.FormForMainWindow;
using ZONOupdate.Forms.FormForLogin;
using System.Resources;

namespace ZONOupdate
{
    internal static class Program
    {
        #region Поля
        static Guid userID;
        static bool isEntryAllowed;
        static object languageName = null!;
        static ResourceManager languageResources = null!;
        #endregion

        #region Методы
        /// <summary>
        /// Метод, предназначенный для загрузки данных пользователя.
        /// </summary>
        /// <param name="isEntryAllowed"> Разрешение входа. </param>
        /// <param name="userID"> ID пользователя. </param>
        public static void SetLoginInformation(bool isEntryAllowed, Guid userID)
        {
            Program.isEntryAllowed = isEntryAllowed;
            Program.userID = userID;
        }

        /// <summary>
        /// Метод, предназначенный для загрузки данных локализации.
        /// </summary>
        /// <param name="languageName"> Название языка. </param>
        /// <param name="languageResources"> Файл локализации. </param>
        public static void SetLanguageInformation(object languageName, ResourceManager languageResources)
        {
            Program.languageName = languageName;
            Program.languageResources = new ResourceManager($"ZONOupdate.Localization.MainForm{languageResources
                .BaseName.Remove(0, languageResources.BaseName.Length - 2)}",
                typeof(MainForm).Assembly);
        }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            do
            {
                isEntryAllowed = false;
                Application.Run(new LoginForm());

                if (isEntryAllowed)
                {
                    Application.Run(new UserWelcomeForm(languageResources));
                    isEntryAllowed = false;
                    Application.Run(new MainForm(userID, languageName, languageResources));
                }
            }
            while (isEntryAllowed);
        }
        #endregion
    }
}