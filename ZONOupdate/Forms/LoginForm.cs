using System.Drawing.Text;
using System.Resources;
using NLog;

namespace ZONOupdate
{
    /// <summary>
    /// Класс формы авторизации пользователя в системе
    /// </summary>
    public partial class LoginForm : Form
    {
        #region Поля
        List<Control> onScreenControls = new List<Control>();
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        ResourceManager languageResources = new ResourceManager("ZONOupdate.Localization.LoginFormRU", typeof(LoginForm).Assembly);
        ResourceManager localizationResources = new ResourceManager("ZONOupdate.Localization.Languages", typeof(LoginForm).Assembly);
        #endregion

        #region Методы
        private Label CreatСontrolsForLoggingOrRegistration()
        {
            onScreenControls.Clear();

            loginFormTableLayoutPanel.Controls.Remove(loginWithAccountZONOLabel);
            loginFormTableLayoutPanel.Controls.Remove(loginWithAccountVKLabel);
            loginFormTableLayoutPanel.Controls.Remove(loginWithAccountYandexLabel);
            loginFormTableLayoutPanel.Controls.Remove(registrationLabel);

            var messageLabel = new Label();
            messageLabel.Font = new Font(fontCollection.Families[0], 16);
            messageLabel.Anchor = AnchorStyles.Top;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            messageLabel.AutoSize = true;
            loginFormTableLayoutPanel.Controls.Add(messageLabel, 1, 1);
            onScreenControls.Add(messageLabel);

            var loginFieldTextBox = new TextBox();
            loginFieldTextBox.Name = "loginFieldTextBox";
            loginFieldTextBox.Font = new Font(fontCollection.Families[0], 14);
            loginFieldTextBox.PlaceholderText = languageResources.GetString(loginFieldTextBox.Name);
            loginFieldTextBox.BackColor = Color.FromArgb(240, 240, 240);
            loginFieldTextBox.BorderStyle = BorderStyle.FixedSingle;
            loginFieldTextBox.Cursor = Cursors.IBeam;
            loginFieldTextBox.Anchor = AnchorStyles.Top;
            loginFieldTextBox.Margin = new Padding(10, 11, 10, 11);
            loginFieldTextBox.MaxLength = 30;
            loginFieldTextBox.Size = new Size(400, 60);
            loginFormTableLayoutPanel.Controls.Add(loginFieldTextBox, 1, 2);
            onScreenControls.Add(loginFieldTextBox);

            var passwordFieldTextBox = new TextBox();
            passwordFieldTextBox.Name = "passwordFieldTextBox";
            passwordFieldTextBox.Font = new Font(fontCollection.Families[0], 14);
            passwordFieldTextBox.PlaceholderText = languageResources.GetString(passwordFieldTextBox.Name);
            passwordFieldTextBox.BackColor = Color.FromArgb(240, 240, 240);
            passwordFieldTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordFieldTextBox.Cursor = Cursors.IBeam;
            passwordFieldTextBox.Anchor = AnchorStyles.Top;
            passwordFieldTextBox.Margin = new Padding(10, 11, 10, 11);
            passwordFieldTextBox.MaxLength = 30;
            passwordFieldTextBox.UseSystemPasswordChar = true;
            passwordFieldTextBox.Size = new Size(400, 60);
            loginFormTableLayoutPanel.Controls.Add(passwordFieldTextBox, 1, 3);
            onScreenControls.Add(passwordFieldTextBox);

            var showPasswordPictureBox = new PictureBox();
            showPasswordPictureBox.Name = "showPasswordPictureBox";
            showPasswordPictureBox.Image = Properties.Resources.eyeHidden;
            showPasswordPictureBox.Cursor = Cursors.Hand;
            showPasswordPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            showPasswordPictureBox.Margin = new Padding(0, 5, 5, 5);
            showPasswordPictureBox.Size = new Size(60, 60);
            showPasswordPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            showPasswordPictureBox.Click += ShowPasswordPictureBox;
            loginFormTableLayoutPanel.Controls.Add(showPasswordPictureBox, 2, 3);
            onScreenControls.Add(showPasswordPictureBox);

            var enterButton = new Button();
            enterButton.Name = "enterButton";
            enterButton.Font = new Font(fontCollection.Families[0], 16);
            enterButton.Text = languageResources.GetString(enterButton.Name);
            enterButton.BackColor = Color.FromArgb(0, 166, 253);
            enterButton.FlatAppearance.BorderSize = 0;
            enterButton.Cursor = Cursors.Hand;
            enterButton.Anchor = AnchorStyles.Top;
            enterButton.ForeColor = Color.FromArgb(255, 255, 255);
            enterButton.Margin = new Padding(80, 0, 80, 16);
            enterButton.Size = new Size(200, 65);
            loginFormTableLayoutPanel.Controls.Add(enterButton, 1, 5);
            onScreenControls.Add(enterButton);

            var goBackPictureBox = new PictureBox();
            goBackPictureBox.Name = "goBackPictureBox";
            goBackPictureBox.Image = Properties.Resources.left;
            goBackPictureBox.Cursor = Cursors.Hand;
            goBackPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            goBackPictureBox.Size = new Size(60, 60);
            goBackPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            goBackPictureBox.Click += GoBackPictureBoxClick;
            loginFormTableLayoutPanel.Controls.Add(goBackPictureBox, 0, 1);
            onScreenControls.Add(goBackPictureBox);

            return messageLabel;
        }
        #endregion

        #region События

        private void LoginWithAccountZONOLabelClick(object sender, EventArgs e)
        {
            var messageLabel = CreatСontrolsForLoggingOrRegistration();
            messageLabel.Text = languageResources.GetString("loginWithAccountZONOLabel");
            messageLabel.Name = "loginWithAccountZONOLabel";

        }
        private void LoginWithAccountVKClick(object sender, EventArgs e)
        {
            var messageLabel = CreatСontrolsForLoggingOrRegistration();
            messageLabel.Text = languageResources.GetString("loginWithAccountVKLabel");
            messageLabel.Name = "loginWithAccountVKLabel";
        }
        private void LoginWithAccountYandexClick(object sender, EventArgs e)
        {
            var messageLabel = CreatСontrolsForLoggingOrRegistration();
            messageLabel.Text = languageResources.GetString("loginWithAccountYandexLabel");
            messageLabel.Name = "loginWithAccountYandexLabel";
        }
        private void RegistrationLabelClick(object sender, EventArgs e)
        {
            var messageLabel = CreatСontrolsForLoggingOrRegistration();
            messageLabel.Text = languageResources.GetString("registrationLabel");
            messageLabel.Name = "registrationLabel";

            var passwordRepeatFieldTextBox = new TextBox();
            passwordRepeatFieldTextBox.Name = "passwordRepeatFieldTextBox";
            passwordRepeatFieldTextBox.Font = new Font(fontCollection.Families[0], 14);
            passwordRepeatFieldTextBox.PlaceholderText = languageResources.GetString(passwordRepeatFieldTextBox.Name);
            passwordRepeatFieldTextBox.BackColor = Color.FromArgb(240, 240, 240);
            passwordRepeatFieldTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordRepeatFieldTextBox.Cursor = Cursors.IBeam;
            passwordRepeatFieldTextBox.Anchor = AnchorStyles.Top;
            passwordRepeatFieldTextBox.Margin = new Padding(10, 11, 10, 11);
            passwordRepeatFieldTextBox.MaxLength = 30;
            passwordRepeatFieldTextBox.UseSystemPasswordChar = true;
            passwordRepeatFieldTextBox.Size = new Size(400, 60);
            loginFormTableLayoutPanel.Controls.Add(passwordRepeatFieldTextBox, 1, 4);
            onScreenControls.Add(passwordRepeatFieldTextBox);

            var showPasswordRepeatPictureBox = new PictureBox();
            showPasswordRepeatPictureBox.Name = "showPasswordRepeatPictureBox";
            showPasswordRepeatPictureBox.Image = Properties.Resources.eyeHidden;
            showPasswordRepeatPictureBox.Cursor = Cursors.Hand;
            showPasswordRepeatPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            showPasswordRepeatPictureBox.Margin = new Padding(0, 5, 5, 5);
            showPasswordRepeatPictureBox.Size = new Size(60, 60);
            showPasswordRepeatPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            showPasswordRepeatPictureBox.Click += ShowPasswordPictureBox;
            loginFormTableLayoutPanel.Controls.Add(showPasswordRepeatPictureBox, 2, 4);
            onScreenControls.Add(showPasswordRepeatPictureBox);
        }
        private void GoBackPictureBoxClick(object sender, EventArgs e)
        {
            foreach (var control in onScreenControls)
            {
                loginFormTableLayoutPanel.Controls.Remove(control);
            }

            loginFormTableLayoutPanel.Controls.Add(loginWithAccountZONOLabel, 1, 1);
            loginFormTableLayoutPanel.Controls.Add(loginWithAccountVKLabel, 1, 2);
            loginFormTableLayoutPanel.Controls.Add(loginWithAccountYandexLabel, 1, 3);
            loginFormTableLayoutPanel.Controls.Add(registrationLabel, 1, 4);
        }
        private void ShowPasswordPictureBox(object sender, EventArgs e)
        {
            var passwordFieldTextBox = onScreenControls.Find(control => control.Name == "passwordFieldTextBox") as TextBox;
            var passwordRepeatFieldTextBox = onScreenControls.Find(control => control.Name == "passwordRepeatFieldTextBox") as TextBox;
            var showPasswordPictureBox = sender as PictureBox;

            if ((passwordFieldTextBox != null) && (showPasswordPictureBox != null) && showPasswordPictureBox.Name.Equals("showPasswordPictureBox"))
            {
                if (!passwordFieldTextBox.UseSystemPasswordChar)
                {
                    logger.Info("Пользователь нажал на иконку для скрытия пароля");

                    passwordFieldTextBox.UseSystemPasswordChar = true;
                    showPasswordPictureBox.Image = Properties.Resources.eyeHidden;
                }
                else
                {
                    logger.Info("Пользователь нажал на иконку для просмотра пароля");

                    passwordFieldTextBox.UseSystemPasswordChar = false;
                    showPasswordPictureBox.Image = Properties.Resources.eyeVisible;
                }
            }

            if ((passwordRepeatFieldTextBox != null) && (showPasswordPictureBox != null) && showPasswordPictureBox.Name.Equals("showPasswordRepeatPictureBox"))
            {
                if (!passwordRepeatFieldTextBox.UseSystemPasswordChar)
                {
                    logger.Info("Пользователь нажал на иконку для скрытия пароля");

                    passwordRepeatFieldTextBox.UseSystemPasswordChar = true;
                    showPasswordPictureBox.Image = Properties.Resources.eyeHidden;
                }
                else
                {
                    logger.Info("Пользователь нажал на иконку для просмотра пароля");

                    passwordRepeatFieldTextBox.UseSystemPasswordChar = false;
                    showPasswordPictureBox.Image = Properties.Resources.eyeVisible;
                }
            }
        }
        private void SelectLanguageComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Пользователь сменил язык на {selectLanguageComboBox.SelectedText}");

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
            loginWithAccountYandexLabel.Text = languageResources.GetString(loginWithAccountYandexLabel.Name);
            registrationLabel.Text = languageResources.GetString(registrationLabel.Name);

            foreach (var control in onScreenControls)
            {
                if (control is TextBox)
                {
                    var dataTextBox = (TextBox)control;
                    dataTextBox.PlaceholderText = languageResources.GetString(dataTextBox.Name);
                    continue;
                }
                control.Text = languageResources.GetString(control.Name);
            }

            Text = languageResources.GetString(Name);
            flagPictureBox.Image = (System.Drawing.Image)languageResources.GetObject("flag");

            logger.Info("Все элементы управления поменяли язык");
        }

        //private void FormKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        EntryButtonClick(sender, e);
        //    }
        //}
        //private void EntryButtonClick(object sender, EventArgs e)
        //{
        //    if ((loginFieldTextBox.Text == String.Empty) || (passwordFieldTextBox.Text == String.Empty))
        //    {
        //        logger.Info("Пользователь нажал на кнопку входа/регистрации, не указав данные," +
        //            "необходимые для входа/регистрации");

        //        MessageBox.Show(languageResources.GetString("errorMessageContent"), languageResources
        //            .GetString("errorMessageTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //        return;
        //    }

        //    if (!isEntrance)
        //    {
        //        logger.Info("Пользователь нажал на кнопку регистрации");

        //        var repeatPasswordTextBox = loginFormTableLayoutPanel.Controls["repeatPasswordTextBox"];

        //        if (repeatPasswordTextBox == null)
        //        {
        //            logger.Error("При регистрации поле для повтора введенного пароля не появилось." +
        //                "Регистрация невозможна!");

        //            return;
        //        }

        //        if (repeatPasswordTextBox.Text != passwordFieldTextBox.Text)
        //        {
        //            logger.Info("Пользователь не зарегистрирован, т.к. было введено два разных пароля");

        //            MessageBox.Show(languageResources.GetString("passwordMismatchContent"), languageResources
        //            .GetString("passwordMismatchTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //            repeatPasswordTextBox.Text = String.Empty;
        //            passwordFieldTextBox.Text = String.Empty;

        //            return;
        //        }

        //        var registrationResult = DatabaseInteraction.RegisterNewUser(loginFieldTextBox.Text,
        //            passwordFieldTextBox.Text);

        //        if (!registrationResult)
        //        {
        //            logger.Warn($"Пользователь не зарегистрирован, т.к. логин {loginFieldTextBox.Text}" +
        //                $"уже существует в БД");

        //            MessageBox.Show(languageResources.GetString("errorRegistrationContent"), languageResources
        //            .GetString("errorRegistrationTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

        //            loginFieldTextBox.Text = String.Empty;
        //        }
        //        else
        //        {
        //            logger.Debug($"Пользователь зарегистрирован. В БД добавлен новый логин {loginFieldTextBox.Text}");

        //            MessageBox.Show(languageResources.GetString("successfulRegistrationContent"), languageResources
        //            .GetString("successfulRegistrationTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            enterButton.Text = languageResources.GetString($"{enterButton.Name}EnterValue");
        //            messageLabel.Text = languageResources.GetString($"{messageLabel.Name}EnterValue");
        //            registrationLabel.Text = languageResources.GetString($"{registrationLabel.Name}EnterValue");

        //            repeatPasswordTextBox.Dispose();
        //            loginFormTableLayoutPanel.Controls.Add(registrationLabel, 1, 4);

        //            loginFieldTextBox.Text = String.Empty;
        //            passwordFieldTextBox.Text = String.Empty;
        //            isEntrance = true;
        //        }
        //    }
        //    else if (isEntrance)
        //    {
        //        logger.Info("Пользователь нажал на кнопку входа в приложение");

        //        var loginResult = DatabaseInteraction.CheckLoginData(loginFieldTextBox.Text,
        //            passwordFieldTextBox.Text);

        //        if (loginResult)
        //        {
        //            logger.Info($"Пользователь с логином {loginFieldTextBox} успешно вошел в приложение");

        //            Program.SetLanguageInformation(selectLanguageComboBox.SelectedItem, languageResources);
        //            Close();
        //        }

        //        logger.Warn($"Пользователь не вошел в приложение, т.к. логина {loginFieldTextBox.Text}" +
        //            $"не существует в БД");

        //        MessageBox.Show(languageResources.GetString("loginFailedContent"), languageResources
        //        .GetString("loginFailedTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //private void ClickOnRegistrationLabel(object sender, EventArgs e)
        //{
        //    if (isEntrance)
        //    {
        //        logger.Info("Пользователь нажал на кнопку для начала регистрации");

        //        loginFormTableLayoutPanel.Controls.Add(registrationLabel, 0, 4);

        //        repeatPasswordTextBox.Dock = DockStyle.Fill;
        //        repeatPasswordTextBox.Font = new Font(fontCollection.Families[0], 14);
        //        repeatPasswordTextBox.BackColor = Color.FromArgb(240, 240, 240);
        //        repeatPasswordTextBox.BorderStyle = BorderStyle.FixedSingle;
        //        repeatPasswordTextBox.Cursor = Cursors.IBeam;
        //        repeatPasswordTextBox.Margin = new Padding(10, 4, 10, 11);
        //        repeatPasswordTextBox.MaxLength = 30;
        //        repeatPasswordTextBox.Name = "repeatPasswordTextBox";
        //        repeatPasswordTextBox.TabIndex = 0;
        //        repeatPasswordTextBox.UseSystemPasswordChar = true;
        //        repeatPasswordTextBox.Visible = true;
        //        repeatPasswordTextBox.PlaceholderText = languageResources.GetString(repeatPasswordTextBox.Name);
        //        loginFormTableLayoutPanel.Controls.Add(repeatPasswordTextBox, 1, 4);

        //        showPasswordPictureBox.Visible = true;
        //        passwordFieldTextBox.Margin = new Padding(10, 8, 10, 11);
        //        loginFieldTextBox.Text = string.Empty;
        //        passwordFieldTextBox.Text = string.Empty;
        //        repeatPasswordTextBox.Text = string.Empty;
        //        repeatPasswordTextBox.Visible = true;

        //        messageLabel.Text = languageResources.GetString($"{messageLabel.Name}RegistrationValue");
        //        enterButton.Text = languageResources.GetString($"{enterButton.Name}RegistrationValue");
        //        registrationLabel.Text = languageResources.GetString($"{registrationLabel.Name}RegistrationValue");
        //        isEntrance = false;
        //    }
        //    else
        //    {
        //        logger.Info("Пользователь нажал на кнопку для возвращения ко входу");

        //        var repeatPasswordTextBox = loginFormTableLayoutPanel.Controls["repeatPasswordTextBox"];

        //        if (repeatPasswordTextBox == null)
        //        {
        //            logger.Error("При регистрации поле для повтора введенного пароля не появилось");

        //            return;
        //        }

        //        repeatPasswordTextBox.Dispose();
        //        repeatPasswordTextBox.Visible = false;
        //        loginFormTableLayoutPanel.Controls.Add(registrationLabel, 1, 4);

        //        showPasswordPictureBox.Visible = true;
        //        passwordFieldTextBox.Margin = new Padding(10, 11, 10, 11);

        //        messageLabel.Text = languageResources.GetString($"{messageLabel.Name}EnterValue");
        //        enterButton.Text = languageResources.GetString($"{enterButton.Name}EnterValue");
        //        registrationLabel.Text = languageResources.GetString($"{registrationLabel.Name}EnterValue");

        //        loginFieldTextBox.Text = String.Empty;
        //        passwordFieldTextBox.Text = String.Empty;
        //        isEntrance = true;
        //    }
        //}
        //private void ClickOnEnterButtonViaVK(object sender, EventArgs e)
        //{
        //    VkApi api = new VkApi();

        //    api.Authorize(new ApiAuthParams()
        //    {
        //        Login = authorizationTexBoxes[1].Text,
        //        Password = authorizationTexBoxes[0].Text,
        //        ApplicationId = 51915316,
        //    });
        //}
        #endregion

        #region Конструкторы
        public LoginForm()
        {
            logger.Info("Запустилось приложение. Открылась форма входа в приложение");

            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            InitializeComponent();

            loginWithAccountZONOLabel.Font = new Font(fontCollection.Families[0], 14);
            loginWithAccountVKLabel.Font = new Font(fontCollection.Families[0], 14);
            loginWithAccountYandexLabel.Font = new Font(fontCollection.Families[0], 14);
            registrationLabel.Font = new Font(fontCollection.Families[0], 14);
            selectLanguageComboBox.Font = new Font(fontCollection.Families[0], 12);

            selectLanguageComboBox.Items.AddRange(new string[] { localizationResources.GetString("RU"),
                localizationResources.GetString("EN") });
            selectLanguageComboBox.SelectedItem = localizationResources.GetString("RU");

        }   
        #endregion
    }
}