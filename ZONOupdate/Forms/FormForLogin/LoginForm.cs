using Microsoft.VisualBasic;
using System.Drawing.Text;
using Guna.UI2.WinForms;
using System.Resources;
using MimeKit;
using NLog;

namespace ZONOupdate.Forms.FormForLogin
{
    /// <summary>
    /// Класс, содержащий внешний вид формы LoginForm.
    /// </summary>
    public partial class LoginForm : Form
    {
        #region Поля
        LoginFormFunctional formFunctional;
        ResourceManager languageResources = null!;
        Logger logger = LogManager.GetCurrentClassLogger();
        List<Control> onScreenControls = new List<Control>();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        ResourceManager localizationResources = new ResourceManager("ZONOupdate.Localization.Languages",
            typeof(LoginForm).Assembly);
        #endregion

        #region Методы
        /// <summary>
        /// Метод, отображающий окно для ввода кода.
        /// </summary>
        /// <param name="inputBoxName"> Название окна ввода. </param>
        /// <returns> Строка с введенным кодом. </returns>
        internal string DisplayingCodeInputBox(string inputBoxName)
        {
            return Interaction.InputBox(languageResources.GetString($"{inputBoxName}Content"),
                languageResources.GetString($"{inputBoxName}Title"));
        }

        /// <summary>
        /// Метод, создающий сообщение с кодом для регистрации.
        /// </summary>
        /// <param name="userEmail"> Почта пользователя. </param>
        /// <param name="randomNumber"> Случайное число. </param>
        /// <returns> Объект-сообщение. </returns>
        internal MimeMessage CreatingEmailMessage(string userEmail, int randomNumber)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(Properties.EmailResources.applicationEmailName,
                Properties.EmailResources.applicationEmail));
            emailMessage.To.Add(new MailboxAddress(String.Empty, userEmail));
            emailMessage.Subject = languageResources.GetString("emailMessageSubject");
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"{languageResources.GetString("emailMessageContent")}{randomNumber}"
            };

            return emailMessage;
        }

        private Label CreatСontrolsForLoggingOrRegistration()
        {
            logger.Info("Создаются элементы управления для входа/регистрации");

            onScreenControls.Clear();
            loginFormTableLayoutPanel.Controls.Remove(loginWithAccountZONOLabel);
            loginFormTableLayoutPanel.Controls.Remove(loginWithAccountVKLabel);
            loginFormTableLayoutPanel.Controls.Remove(registrationLabel);

            var messageLabel = new Label();
            messageLabel.Font = new Font(fontCollection.Families[0], 16);
            messageLabel.Anchor = AnchorStyles.Top;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            messageLabel.AutoSize = true;
            loginFormTableLayoutPanel.Controls.Add(messageLabel, 1, 1);
            onScreenControls.Add(messageLabel);

            var loginFieldTextBox = new Guna2TextBox();
            loginFieldTextBox.Name = "loginFieldTextBox";
            loginFieldTextBox.Font = new Font(fontCollection.Families[0], 14);
            loginFieldTextBox.PlaceholderText = languageResources.GetString(loginFieldTextBox.Name);
            loginFieldTextBox.FillColor = Color.FromArgb(240, 240, 240);
            loginFieldTextBox.BorderRadius = 8;
            loginFieldTextBox.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            loginFieldTextBox.BorderColor = Color.FromArgb(0, 0, 0);
            loginFieldTextBox.BorderThickness = 1;
            loginFieldTextBox.TextOffset = new Point(10, 0);
            loginFieldTextBox.PlaceholderForeColor = Color.FromArgb(151, 151, 151);
            loginFieldTextBox.ForeColor = Color.FromArgb(0, 0, 0);
            loginFieldTextBox.Cursor = Cursors.IBeam;
            loginFieldTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            loginFieldTextBox.Margin = new Padding(10);
            loginFieldTextBox.MaxLength = 40;
            loginFieldTextBox.Size = new Size(400, 60);
            loginFormTableLayoutPanel.Controls.Add(loginFieldTextBox, 1, 2);
            onScreenControls.Add(loginFieldTextBox);

            var passwordFieldTextBox = new Guna2TextBox();
            passwordFieldTextBox.Name = "passwordFieldTextBox";
            passwordFieldTextBox.Font = new Font(fontCollection.Families[0], 14);
            passwordFieldTextBox.PlaceholderText = languageResources.GetString(passwordFieldTextBox.Name);
            passwordFieldTextBox.FillColor = Color.FromArgb(240, 240, 240);
            passwordFieldTextBox.BorderRadius = 8;
            passwordFieldTextBox.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            passwordFieldTextBox.BorderColor = Color.FromArgb(0, 0, 0);
            passwordFieldTextBox.BorderThickness = 1;
            passwordFieldTextBox.TextOffset = new Point(10, 0);
            passwordFieldTextBox.PlaceholderForeColor = Color.FromArgb(151, 151, 151);
            passwordFieldTextBox.ForeColor = Color.FromArgb(0, 0, 0);
            passwordFieldTextBox.IconRight = Properties.Resources.eyeVisible;
            passwordFieldTextBox.IconRightCursor = Cursors.Hand;
            passwordFieldTextBox.IconRightSize = new Size(43, 43);
            passwordFieldTextBox.IconRightClick += ShowPasswordPictureBox;
            passwordFieldTextBox.Cursor = Cursors.IBeam;
            passwordFieldTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            passwordFieldTextBox.Margin = new Padding(10);
            passwordFieldTextBox.MaxLength = 40;
            passwordFieldTextBox.UseSystemPasswordChar = true;
            passwordFieldTextBox.Size = new Size(400, 60);
            loginFormTableLayoutPanel.Controls.Add(passwordFieldTextBox, 1, 3);
            onScreenControls.Add(passwordFieldTextBox);

            var goBackPictureBox = new PictureBox();
            goBackPictureBox.Name = "goBackPictureBox";
            goBackPictureBox.Image = Properties.Resources.goBack;
            goBackPictureBox.Cursor = Cursors.Hand;
            goBackPictureBox.Anchor = AnchorStyles.Right;
            goBackPictureBox.Size = new Size(60, 60);
            goBackPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            goBackPictureBox.Margin = new Padding(0, 0, 10, 10);
            goBackPictureBox.MouseDown += GoBackPictureBoxMouseDown;
            loginFormTableLayoutPanel.Controls.Add(goBackPictureBox, 0, 1);
            onScreenControls.Add(goBackPictureBox);

            return messageLabel;
        }
        #endregion

        #region События
        private void LoginWithAccountZONOLabelMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку \"Войти в аккаунт ZONO\"");

            var messageLabel = CreatСontrolsForLoggingOrRegistration();
            messageLabel.Name = "loginWithAccountZONOLabel";
            messageLabel.Text = languageResources.GetString(messageLabel.Name);

            var enterButton = new Guna2Button();
            enterButton.Name = "enterButton";
            enterButton.Font = new Font(fontCollection.Families[0], 16);
            enterButton.Text = languageResources.GetString(enterButton.Name);
            enterButton.FillColor = Color.FromArgb(0, 166, 253);
            enterButton.BorderRadius = 8;
            enterButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            enterButton.BorderColor = Color.FromArgb(0, 0, 0);
            enterButton.BorderThickness = 1;
            enterButton.Cursor = Cursors.Hand;
            enterButton.Anchor = AnchorStyles.Top;
            enterButton.ForeColor = Color.FromArgb(255, 255, 255);
            enterButton.Size = new Size(220, 60);
            enterButton.Margin = new Padding(0, 25, 0, 0);
            enterButton.MouseDown += EnterZONOAccountButtonMouseDown;
            loginFormTableLayoutPanel.Controls.Add(enterButton, 1, 4);
            loginFormTableLayoutPanel.SetRowSpan(enterButton, 2);
            onScreenControls.Add(enterButton);
        }

        private void LoginWithAccountVKMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку \"Войти через ВКонтакте\"");

            var messageLabel = CreatСontrolsForLoggingOrRegistration();
            messageLabel.Name = "loginWithAccountVKLabel";
            messageLabel.Text = languageResources.GetString(messageLabel.Name);

            var enterButton = new Guna2Button();
            enterButton.Name = "enterButton";
            enterButton.Font = new Font(fontCollection.Families[0], 16);
            enterButton.Text = languageResources.GetString(enterButton.Name);
            enterButton.FillColor = Color.FromArgb(0, 166, 253);
            enterButton.BorderRadius = 8;
            enterButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            enterButton.BorderColor = Color.FromArgb(0, 0, 0);
            enterButton.BorderThickness = 1;
            enterButton.Cursor = Cursors.Hand;
            enterButton.Anchor = AnchorStyles.Top;
            enterButton.ForeColor = Color.FromArgb(255, 255, 255);
            enterButton.Size = new Size(220, 60);
            enterButton.Margin = new Padding(0, 25, 0, 0);
            enterButton.MouseDown += EnterVKAccountButtonMouseDown;
            loginFormTableLayoutPanel.Controls.Add(enterButton, 1, 4);
            loginFormTableLayoutPanel.SetRowSpan(enterButton, 2);
            onScreenControls.Add(enterButton);
        }

        private void RegistrationLabelMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку \"Регистрация на ZONO\"");

            var messageLabel = CreatСontrolsForLoggingOrRegistration();
            messageLabel.Name = "registrationLabel";
            messageLabel.Text = languageResources.GetString(messageLabel.Name);

            var passwordRepeatFieldTextBox = new Guna2TextBox();
            passwordRepeatFieldTextBox.Name = "passwordRepeatFieldTextBox";
            passwordRepeatFieldTextBox.Font = new Font(fontCollection.Families[0], 14);
            passwordRepeatFieldTextBox.PlaceholderText = languageResources.GetString(passwordRepeatFieldTextBox.Name);
            passwordRepeatFieldTextBox.FillColor = Color.FromArgb(240, 240, 240);
            passwordRepeatFieldTextBox.BorderRadius = 8;
            passwordRepeatFieldTextBox.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            passwordRepeatFieldTextBox.BorderColor = Color.FromArgb(0, 0, 0);
            passwordRepeatFieldTextBox.BorderThickness = 1;
            passwordRepeatFieldTextBox.TextOffset = new Point(10, 0);
            passwordRepeatFieldTextBox.PlaceholderForeColor = Color.FromArgb(151, 151, 151);
            passwordRepeatFieldTextBox.ForeColor = Color.FromArgb(0, 0, 0);
            passwordRepeatFieldTextBox.IconRight = Properties.Resources.eyeVisible;
            passwordRepeatFieldTextBox.IconRightCursor = Cursors.Hand;
            passwordRepeatFieldTextBox.IconRightSize = new Size(43, 43);
            passwordRepeatFieldTextBox.IconRightClick += ShowPasswordPictureBox;
            passwordRepeatFieldTextBox.Cursor = Cursors.IBeam;
            passwordRepeatFieldTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            passwordRepeatFieldTextBox.Margin = new Padding(10);
            passwordRepeatFieldTextBox.MaxLength = 40;
            passwordRepeatFieldTextBox.UseSystemPasswordChar = true;
            passwordRepeatFieldTextBox.Size = new Size(400, 60);
            loginFormTableLayoutPanel.Controls.Add(passwordRepeatFieldTextBox, 1, 4);
            onScreenControls.Add(passwordRepeatFieldTextBox);

            var registrationButton = new Guna2Button();
            registrationButton.Name = "registrationButton";
            registrationButton.Font = new Font(fontCollection.Families[0], 16);
            registrationButton.Text = languageResources.GetString(registrationButton.Name);
            registrationButton.FillColor = Color.FromArgb(0, 166, 253);
            registrationButton.BorderRadius = 8;
            registrationButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            registrationButton.BorderColor = Color.FromArgb(0, 0, 0);
            registrationButton.BorderThickness = 1;
            registrationButton.Cursor = Cursors.Hand;
            registrationButton.Anchor = AnchorStyles.Top;
            registrationButton.ForeColor = Color.FromArgb(255, 255, 255);
            registrationButton.Size = new Size(220, 60);
            registrationButton.Margin = new Padding(0, 0, 0, 10);
            registrationButton.MouseDown += RegistrationButtonMouseDown;
            loginFormTableLayoutPanel.Controls.Add(registrationButton, 1, 5);
            onScreenControls.Add(registrationButton);
        }

        private void GoBackPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь вернулся к выбору входа");

            foreach (var control in onScreenControls)
            {
                loginFormTableLayoutPanel.Controls.Remove(control);
            }

            loginFormTableLayoutPanel.Controls.Add(loginWithAccountZONOLabel, 1, 2);
            loginFormTableLayoutPanel.Controls.Add(loginWithAccountVKLabel, 1, 3);
            loginFormTableLayoutPanel.Controls.Add(registrationLabel, 1, 4);
        }

        private void ShowPasswordPictureBox(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку для скрытия/просмотра пароля");

            var passwordFieldTextBox = sender as Guna2TextBox;

            if (passwordFieldTextBox != null)
            {
                if (!passwordFieldTextBox.UseSystemPasswordChar)
                {
                    logger.Info("Пользователь нажал на иконку для скрытия пароля");

                    passwordFieldTextBox.UseSystemPasswordChar = true;
                    passwordFieldTextBox.IconRight = Properties.Resources.eyeVisible;
                }
                else
                {
                    logger.Info("Пользователь нажал на иконку для просмотра пароля");

                    passwordFieldTextBox.UseSystemPasswordChar = false;
                    passwordFieldTextBox.IconRight = Properties.Resources.eyeHidden;
                }
            }
        }

        private void SelectLanguageComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Пользователь сменил язык");

            switch (selectLanguageComboBox.SelectedIndex)
            {
                case 0:
                    languageResources = new ResourceManager("ZONOupdate.Localization.LoginFormRU",
                        typeof(LoginForm).Assembly);
                    break;

                case 1:
                    languageResources = new ResourceManager("ZONOupdate.Localization.LoginFormEN",
                        typeof(LoginForm).Assembly);
                    break;
            }

            loginWithAccountZONOLabel.Text = languageResources.GetString(loginWithAccountZONOLabel.Name);
            loginWithAccountVKLabel.Text = languageResources.GetString(loginWithAccountVKLabel.Name);
            registrationLabel.Text = languageResources.GetString(registrationLabel.Name);

            foreach (var control in onScreenControls)
            {
                if (control is Guna2TextBox)
                {
                    var dataTextBox = (Guna2TextBox)control;
                    dataTextBox.PlaceholderText = languageResources.GetString(dataTextBox.Name);

                    continue;
                }

                control.Text = languageResources.GetString(control.Name);
            }

            Text = languageResources.GetString(Name);
            flagPictureBox.Image = (Image)languageResources.GetObject("flag");

            logger.Info("Все элементы управления поменяли язык");
        }

        private void EnterZONOAccountButtonMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку входа для авторизации через аккаунт ZONO");

            var loginResult = formFunctional.LoginWithAccountZONO(onScreenControls);

            if (loginResult)
            {
                logger.Debug("Пользователь вошел в приложение");

                if (selectLanguageComboBox.SelectedItem != null)
                {
                    Program.SetLanguageInformation(selectLanguageComboBox.SelectedItem, languageResources);
                }

                Close();
            }
            else
            {
                logger.Warn("Попытка входа в аккаунт закончилась неудачей");

                var loginErrorMessageDialog = new Guna2MessageDialog();
                loginErrorMessageDialog.Buttons = MessageDialogButtons.OK;
                loginErrorMessageDialog.Icon = MessageDialogIcon.Error;
                loginErrorMessageDialog.Style = MessageDialogStyle.Light;
                loginErrorMessageDialog.Parent = this;
                loginErrorMessageDialog.Caption = languageResources.GetString("loginErrorTitle");
                loginErrorMessageDialog.Text = languageResources.GetString("loginErrorContent");
                loginErrorMessageDialog.Show();
            }
        }

        private void EnterVKAccountButtonMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку входа для авторизации через аккаунт ВКонтакте");

            var loginResult = formFunctional.LoginWithAccountVK(onScreenControls);

            if (loginResult)
            {
                logger.Debug("Пользователь вошел в приложение");

                if (selectLanguageComboBox.SelectedItem != null)
                {
                    Program.SetLanguageInformation(selectLanguageComboBox.SelectedItem, languageResources);
                }

                Close();
            }
            else
            {
                logger.Warn("Попытка входа в аккаунт закончилась неудачей");

                var loginErrorMessageDialog = new Guna2MessageDialog();
                loginErrorMessageDialog.Buttons = MessageDialogButtons.OK;
                loginErrorMessageDialog.Icon = MessageDialogIcon.Error;
                loginErrorMessageDialog.Style = MessageDialogStyle.Light;
                loginErrorMessageDialog.Parent = this;
                loginErrorMessageDialog.Caption = languageResources.GetString("loginErrorTitle");
                loginErrorMessageDialog.Text = languageResources.GetString("loginErrorContent");
                loginErrorMessageDialog.Show();
            }
        }

        private void RegistrationButtonMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку для регистрации в приложении");

            var registrationResult = formFunctional.RegistrationOnZONO(onScreenControls);

            if (registrationResult)
            {
                logger.Debug("Пользователь успешно зарегистрирован");

                var registrationSuccsessMessageDialog = new Guna2MessageDialog();
                registrationSuccsessMessageDialog.Buttons = MessageDialogButtons.OK;
                registrationSuccsessMessageDialog.Icon = MessageDialogIcon.Information;
                registrationSuccsessMessageDialog.Style = MessageDialogStyle.Light;
                registrationSuccsessMessageDialog.Parent = this;
                registrationSuccsessMessageDialog.Caption = languageResources.GetString("registrationSuccessTitle");
                registrationSuccsessMessageDialog.Text = languageResources.GetString("registrationSuccessContent");
                registrationSuccsessMessageDialog.Show();

                GoBackPictureBoxMouseDown(sender, e);
            }
            else
            {
                logger.Warn("Попытка регистрации провалилась");

                var registrationErrorMessageDialog = new Guna2MessageDialog();
                registrationErrorMessageDialog.Buttons = MessageDialogButtons.OK;
                registrationErrorMessageDialog.Icon = MessageDialogIcon.Error;
                registrationErrorMessageDialog.Style = MessageDialogStyle.Light;
                registrationErrorMessageDialog.Parent = this;
                registrationErrorMessageDialog.Caption = languageResources.GetString("registrationErrorTitle");
                registrationErrorMessageDialog.Text = languageResources.GetString("registrationErrorContent");
                registrationErrorMessageDialog.Show();
            }
        }

        private void LoginOrRegistrationLabelsMouseMove(object sender, MouseEventArgs e)
        {
            var loginOrRegistrationLabel = sender as Label;

            if (loginOrRegistrationLabel != null)
            {
                loginOrRegistrationLabel.ForeColor = Color.FromArgb(0, 71, 255);
            }
        }

        private void LoginOrRegistrationLabelsMouseLeave(object sender, EventArgs e)
        {
            var loginOrRegistrationLabel = sender as Label;

            if (loginOrRegistrationLabel != null)
            {
                loginOrRegistrationLabel.ForeColor = Color.FromArgb(0, 167, 255);
            }
        }

        private void LoginFormLoad(object sender, EventArgs e)
        {
            var formAppearanceTimer = new System.Windows.Forms.Timer();
            formAppearanceTimer.Interval = 60;
            formAppearanceTimer.Tick += FormAppearanceTimerTick;
            formAppearanceTimer.Start();
        }

        private void FormAppearanceTimerTick(object sender, EventArgs e)
        {
            Opacity += 0.1;

            if (Opacity == 1)
            {
                var formAppearanceTimer = sender as System.Windows.Forms.Timer;

                if (formAppearanceTimer != null)
                {
                    formAppearanceTimer.Stop();
                }
            }
        }
        #endregion

        #region Конструкторы
        public LoginForm()
        {
            logger.Info("Запустилось приложение. Открылась форма входа в приложение");

            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            formFunctional = new LoginFormFunctional(this);
            InitializeComponent();

            loginWithAccountZONOLabel.Font = new Font(fontCollection.Families[0], 16);
            loginWithAccountVKLabel.Font = new Font(fontCollection.Families[0], 16);
            registrationLabel.Font = new Font(fontCollection.Families[0], 16);
            selectLanguageComboBox.Font = new Font(fontCollection.Families[0], 13);

            selectLanguageComboBox.Items.AddRange(new string[] { localizationResources.GetString("RU"),
                localizationResources.GetString("EN") });
            selectLanguageComboBox.SelectedItem = localizationResources.GetString("RU");
        }
        #endregion
    }
}