using System.Text.RegularExpressions;
using ZONOupdate.Database;
using Guna.UI2.WinForms;
using VkNet.Model;
using VkNet;
using NLog;

namespace ZONOupdate.Forms.FormForLogin
{
    /// <summary>
    /// Класс, содержащий функционал формы LoginForm.
    /// </summary>
    internal class LoginFormFunctional
    {
        #region Поля
        LoginForm loginForm;
        Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Методы
        /// <summary>
        /// Метод, выполняющий вход в приложение через внутренний аккаунт ZONO.
        /// </summary>
        /// <param name="onScreenControls"> Элементы управления, расположенные на экране. </param>
        /// <returns> true - вход разрешен; false - вход запрещен. </returns>
        internal bool LoginWithAccountZONO(List<Control> onScreenControls)
        {
            try
            {
                logger.Debug("Выполняется вход в приложение через внутренний аккаунт ZONO");

                var loginFieldTextBox = onScreenControls.Find(control => control
                .Name == "loginFieldTextBox") as Guna2TextBox;
                var passwordFieldTextBox = onScreenControls.Find(control => control
                .Name == "passwordFieldTextBox") as Guna2TextBox;

                if ((loginFieldTextBox == null) || (passwordFieldTextBox == null))
                {
                    logger.Debug("Вход запрещен, т.к. поля с логином и/или паролем не появились");

                    return false;
                }

                if ((loginFieldTextBox.Text == String.Empty) ||
                    (passwordFieldTextBox.Text == String.Empty))
                {
                    logger.Debug("Вход запрещен, т.к. пользователь оставил поля с " +
                        "логином и/или паролем пустыми");

                    return false;
                }

                return DatabaseInteraction.CheckingLoginViaZONOAccount(loginFieldTextBox.Text,
                    passwordFieldTextBox.Text);
            }
            catch(Exception ex) 
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }

        /// <summary>
        /// Метод, выполняющий вход в приложение через аккаунт ВКонтакте.
        /// </summary>
        /// <param name="onScreenControls"> Элементы управления, расположенные на экране. </param>
        /// <returns> true - вход разрешен; false - вход запрещен. </returns>
        internal bool LoginWithAccountVK(List<Control> onScreenControls)
        {
            try
            {
                logger.Debug("Выполняется вход в приложение через аккаунт ВКонтакте");

                var loginFieldTextBox = onScreenControls.Find(control => control
                .Name == "loginFieldTextBox") as Guna2TextBox;
                var passwordFieldTextBox = onScreenControls.Find(control => control
                .Name == "passwordFieldTextBox") as Guna2TextBox;

                if ((loginFieldTextBox == null) || (passwordFieldTextBox == null))
                {
                    logger.Debug("Вход запрещен, т.к. поля с логином и/или паролем не появились");

                    return false;
                }

                if ((loginFieldTextBox.Text == String.Empty) ||
                    (passwordFieldTextBox.Text == String.Empty))
                {
                    logger.Debug("Вход запрещен, т.к. пользователь оставил поля с " +
                        "логином и/или паролем пустыми");

                    return false;
                }

                if (!Regex.IsMatch(loginFieldTextBox.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                {
                    logger.Debug("Вход запрещен, т.к. пользователь неверно ввел email почту");

                    return false;
                }

                VkApi vkApi = new VkApi();

                vkApi.Authorize(new ApiAuthParams()
                {
                    Login = loginFieldTextBox.Text,
                    Password = passwordFieldTextBox.Text,
                    ApplicationId = Convert.ToUInt64(Properties.VkAuthorizationResources.applicationId),
                    TwoFactorAuthorization = () =>
                    {
                        return loginForm.DisplayingCodeInputBox("loginWithAccountVKInputBox");
                    }
                });

                if (vkApi.IsAuthorized)
                {
                    DatabaseInteraction.RegistrationWithLoginFromThirdPartyApplication(loginFieldTextBox.Text);
                }

                return vkApi.IsAuthorized;
            }
            catch (Exception ex) 
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }

        /// <summary>
        /// Метод, выполняющий регистрацию пользователя в приложении.
        /// </summary>
        /// <param name="onScreenControls"> Элементы управления, расположенные на экране. </param>
        /// <returns> true - вход разрешен; false - вход запрещен. </returns>
        internal bool RegistrationOnZONO(List<Control> onScreenControls) 
        {
            try
            {
                logger.Debug("Выполняется регистрация в приложении");

                var loginFieldTextBox = onScreenControls.Find(control => control
                .Name == "loginFieldTextBox") as Guna2TextBox;
                var passwordFieldTextBox = onScreenControls.Find(control => control
                .Name == "passwordFieldTextBox") as Guna2TextBox;
                var passwordRepeatFieldTextBox = onScreenControls.Find(control => control
                .Name == "passwordRepeatFieldTextBox") as Guna2TextBox;

                if ((loginFieldTextBox == null) || (passwordFieldTextBox == null)
                    || (passwordRepeatFieldTextBox == null))
                {
                    logger.Debug("Регистрация запрещена, т.к. поля с логином и/или паролем не появились");

                    return false;
                }

                if ((loginFieldTextBox.Text == String.Empty) || (passwordFieldTextBox.Text == String.Empty)
                    || (passwordRepeatFieldTextBox.Text == String.Empty))
                {
                    logger.Debug("Решистрация запрещена, т.к. пользователь оставил поля с " +
                        "логином и/или паролем пустыми");

                    return false;
                }

                if (passwordFieldTextBox.Text != passwordRepeatFieldTextBox.Text)
                {
                    logger.Debug("Регистрация запрещена, т.к. введенные пароли не совпадают");

                    return false;
                }

                if (!Regex.IsMatch(loginFieldTextBox.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                {
                    logger.Debug("Вход запрещен, т.к. пользователь неверно ввел email почту");

                    return false;
                }

                var isEmailDoesNotExist = DatabaseInteraction.CheckingLoginExistence(loginFieldTextBox.Text);

                if (isEmailDoesNotExist)
                {
                    logger.Debug("Регистрация в приложении разрешена");

                    var randomNumberGenerator = new Random();
                    var randomNumber = randomNumberGenerator.Next(1000, 10000);
                    var emailMessage = loginForm.CreatingEmailMessage(loginFieldTextBox.Text, randomNumber);

                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Timeout = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
                        client.Connect(Properties.EmailResources.applicationEmailHost, 25, false);
                        client.Authenticate(Properties.EmailResources.applicationEmail,
                            Properties.EmailResources.applicationEmailPassword);
                        client.Send(emailMessage);
                        client.Disconnect(true);
                    }

                    var inputValue = loginForm.DisplayingCodeInputBox("registrationInputBox");

                    if (inputValue == randomNumber.ToString())
                    {
                        logger.Debug("Пользователь зарегистрован в приложении");

                        DatabaseInteraction.RegistrationNewUser(loginFieldTextBox.Text,
                            passwordFieldTextBox.Text);

                        return true;
                    }
                }

                logger.Debug("Регистрация в приложении запрещена");

                return false;
            }
            catch (Exception ex) 
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }
        #endregion

        #region Конструкторы
        public LoginFormFunctional(LoginForm loginForm)
        {
            this.loginForm = loginForm;
        }
        #endregion
    }
}