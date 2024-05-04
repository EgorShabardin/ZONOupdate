using System.Resources;
using ZONOupdate.Forms.FormForWelcomingUser;
using ZONOupdate.Forms;
using ZONOupdate.Forms.FormForLogin;

namespace ZONOupdate
{
    internal static class Program
    {
        static bool isEntryAllowed;
        static Guid userID;
        static object languageName;
        static ResourceManager languageResources;

        public static void SetLoginInformation(bool isEntryAllowed, Guid userID)
        {
            Program.isEntryAllowed = isEntryAllowed;
            Program.userID = userID;
        }

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
            //Application.Run(new MainForm(new Guid("7569C43C-7D55-4406-97AB-5BFE49DC4658"), (object)"Русский", new ResourceManager($"ZONOupdate.Localization.MainFormRU", typeof(MainForm).Assembly)));

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
    }
}