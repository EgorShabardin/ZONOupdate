using Guna.UI2.WinForms;
using System.Net.Mail;
using System.Net.NetworkInformation;
using VkNet.Model;
using ZONOupdate.Database;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using System.Security.Policy;
using VkNet;
using VkNet.Enums.Filters;
using Microsoft.VisualBasic;
using DevExpress.XtraEditors;

namespace ZONOupdate.Forms
{
    internal class LoginFormFunctional
    {
        public bool LoginWithAccountZONO(List<Control> onScreenControls)
        {
            var loginFieldTextBox = onScreenControls.Find(control => control.Name == "loginFieldTextBox") as Guna2TextBox;
            var passwordFieldTextBox = onScreenControls.Find(control => control.Name == "passwordFieldTextBox") as Guna2TextBox;

            if ((loginFieldTextBox == null) || (passwordFieldTextBox == null)) 
            {
                return false;
            }

            if ((loginFieldTextBox.Text == String.Empty) || (passwordFieldTextBox.Text == String.Empty))
            {
                return false;
            }

            return DatabaseInteraction.CheckLoginData(loginFieldTextBox.Text, passwordFieldTextBox.Text);
        }
        public bool LoginWithAccountVK(List<Control> onScreenControls)
        {
            try
            {
                var loginFieldTextBox = onScreenControls.Find(control => control.Name == "loginFieldTextBox") as Guna2TextBox;
                var passwordFieldTextBox = onScreenControls.Find(control => control.Name == "passwordFieldTextBox") as Guna2TextBox;

                if ((loginFieldTextBox == null) || (passwordFieldTextBox == null))
                {
                    return false;
                }

                VkApi api = new VkApi();

                api.Authorize(new ApiAuthParams()
                {
                    Login = loginFieldTextBox.Text,
                    Password = passwordFieldTextBox.Text,
                    ApplicationId = 51915316,
                    TwoFactorAuthorization = () =>
                    {
                        return Interaction.InputBox("fff", "dff");
                    }
                });

                return api.IsAuthorized;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
        public bool RegistrationOnZONO(List<Control> onScreenControls) 
        {
            try
            {
                var loginFieldTextBox = onScreenControls.Find(control => control.Name == "loginFieldTextBox") as Guna2TextBox;
                var passwordFieldTextBox = onScreenControls.Find(control => control.Name == "passwordFieldTextBox") as Guna2TextBox;
                var passwordRepeatFieldTextBox = onScreenControls.Find(control => control.Name == "passwordRepeatFieldTextBox") as Guna2TextBox;

                if ((loginFieldTextBox == null) || (passwordFieldTextBox == null) || (passwordRepeatFieldTextBox == null))
                {
                    return false;
                }

                if ((loginFieldTextBox.Text == String.Empty) || (passwordFieldTextBox.Text == String.Empty) || (passwordRepeatFieldTextBox.Text == String.Empty))
                {
                    return false;
                }

                if (passwordFieldTextBox.Text != passwordRepeatFieldTextBox.Text)
                {
                    return false;
                }

                var isEmailDoesNotExist = DatabaseInteraction.CheckingMail(loginFieldTextBox.Text);

                if (isEmailDoesNotExist)
                {
                    var randomNumberGenerator = new Random();
                    var randomNumber = randomNumberGenerator.Next(1000, 10000);
                    var emailMessage = new MimeMessage();

                    emailMessage.From.Add(new MailboxAddress("Маркетплейс ZONO", "zono.marketplace@mail.ru"));
                    emailMessage.To.Add(new MailboxAddress(String.Empty, loginFieldTextBox.Text));
                    emailMessage.Subject = "Решистрация в приложении ZONO";
                    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = $"Код: {randomNumber}\nЧтобы продолжить регистрацию введите полученный код в открывшееся окно приложения ZONO"
                    };

                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Timeout = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
                        client.Connect("smtp.mail.ru", 25, false);
                        client.Authenticate("zono.marketplace@mail.ru", "G9HzJ7J0W8tehCJrnXsu");
                        client.Send(emailMessage);

                        client.Disconnect(true);
                    }

                    var inputValue = Interaction.InputBox("fff", "dff");

                    if (inputValue == randomNumber.ToString())
                    {
                        DatabaseInteraction.RegisterNewUser(loginFieldTextBox.Text, passwordFieldTextBox.Text);
                        return true;
                    }

                }

                return false;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
