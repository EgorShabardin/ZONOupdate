﻿using System.Resources;
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
                typeof(UserWelcomeForm).Assembly);
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
    }
}