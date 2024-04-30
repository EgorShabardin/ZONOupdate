using System.Drawing.Text;
using System.Resources;
using NLog;
using Guna.UI2.WinForms;

namespace ZONOupdate.Forms
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
        LoginFormFunctional formFunctional = new LoginFormFunctional();
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
            messageLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
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
            loginFieldTextBox.Padding = new Padding(10, 3, 10, 3);
            loginFieldTextBox.PlaceholderForeColor = Color.FromArgb(151, 151, 151);
            loginFieldTextBox.ForeColor = Color.FromArgb(0, 0, 0);
            loginFieldTextBox.Cursor = Cursors.IBeam;
            loginFieldTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            loginFieldTextBox.Margin = new Padding(20, 11, 20, 11);
            loginFieldTextBox.MaxLength = 30;
            loginFieldTextBox.Size = new Size(400, 60);
            loginFieldTextBox.AutoScaleMode = AutoScaleMode.Inherit;
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
            passwordFieldTextBox.Padding = new Padding(10, 3, 10, 3);
            passwordFieldTextBox.PlaceholderForeColor = Color.FromArgb(151, 151, 151);
            passwordFieldTextBox.ForeColor = Color.FromArgb(0, 0, 0);
            passwordFieldTextBox.IconRight = Properties.Resources.eyeHidden;
            passwordFieldTextBox.IconRightCursor = Cursors.Hand;
            passwordFieldTextBox.IconRightSize = new Size(40, 40);
            passwordFieldTextBox.IconRightClick += ShowPasswordPictureBox;
            passwordFieldTextBox.Cursor = Cursors.IBeam;
            passwordFieldTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            passwordFieldTextBox.Margin = new Padding(20, 11, 20, 11);
            passwordFieldTextBox.MaxLength = 30;
            passwordFieldTextBox.UseSystemPasswordChar = true;
            passwordFieldTextBox.Size = new Size(400, 60);
            passwordFieldTextBox.AutoScaleMode = AutoScaleMode.Inherit;
            loginFormTableLayoutPanel.Controls.Add(passwordFieldTextBox, 1, 3);
            onScreenControls.Add(passwordFieldTextBox);

            var goBackPictureBox = new PictureBox();
            goBackPictureBox.Name = "goBackPictureBox";
            goBackPictureBox.Image = Properties.Resources.left;
            goBackPictureBox.Cursor = Cursors.Hand;
            goBackPictureBox.Anchor = AnchorStyles.Right;
            goBackPictureBox.Size = new Size(60, 60);
            goBackPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            goBackPictureBox.Margin = new Padding(0, 0, 10, 10);
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

            var enterButton = new Guna2Button();
            enterButton.Name = "enterButton";
            enterButton.Font = new Font(fontCollection.Families[0], 16);
            enterButton.Text = languageResources.GetString(enterButton.Name);
            enterButton.FillColor = Color.FromArgb(0, 166, 253);
            enterButton.BorderRadius = 8;
            enterButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            enterButton.BorderColor = Color.FromArgb(0, 0, 0);
            enterButton.BorderThickness = 1;
            enterButton.Padding = new Padding(10, 3, 10, 3);
            enterButton.Cursor = Cursors.Hand;
            enterButton.Anchor = AnchorStyles.Top;
            enterButton.ForeColor = Color.FromArgb(255, 255, 255);
            enterButton.Size = new Size(200, 65);
            enterButton.Margin = new Padding(0, 25, 0, 0);
            enterButton.Click += EnterZONOAccountButtonClick;
            loginFormTableLayoutPanel.Controls.Add(enterButton, 1, 4);
            loginFormTableLayoutPanel.SetRowSpan(enterButton, 2);
            onScreenControls.Add(enterButton);

        }
        private void LoginWithAccountVKClick(object sender, EventArgs e)
        {
            var messageLabel = CreatСontrolsForLoggingOrRegistration();
            messageLabel.Text = languageResources.GetString("loginWithAccountVKLabel");
            messageLabel.Name = "loginWithAccountVKLabel";

            var enterButton = new Guna2Button();
            enterButton.Name = "enterButton";
            enterButton.Font = new Font(fontCollection.Families[0], 16);
            enterButton.Text = languageResources.GetString(enterButton.Name);
            enterButton.FillColor = Color.FromArgb(0, 166, 253);
            enterButton.BorderRadius = 8;
            enterButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            enterButton.BorderColor = Color.FromArgb(0, 0, 0);
            enterButton.BorderThickness = 1;
            enterButton.Padding = new Padding(10, 3, 10, 3);
            enterButton.Cursor = Cursors.Hand;
            enterButton.Anchor = AnchorStyles.Top;
            enterButton.ForeColor = Color.FromArgb(255, 255, 255);
            enterButton.Size = new Size(200, 65);
            enterButton.Margin = new Padding(0, 25, 0, 0);
            enterButton.Click += EnterVKAccountButtonClick;
            loginFormTableLayoutPanel.Controls.Add(enterButton, 1, 4);
            loginFormTableLayoutPanel.SetRowSpan(enterButton, 2);
            onScreenControls.Add(enterButton);
        }
        private void LoginWithAccountYandexClick(object sender, EventArgs e)
        {
            var messageLabel = CreatСontrolsForLoggingOrRegistration();
            messageLabel.Text = languageResources.GetString("loginWithAccountYandexLabel");
            messageLabel.Name = "loginWithAccountYandexLabel";

            var enterButton = new Guna2Button();
            enterButton.Name = "enterButton";
            enterButton.Font = new Font(fontCollection.Families[0], 16);
            enterButton.Text = languageResources.GetString(enterButton.Name);
            enterButton.FillColor = Color.FromArgb(0, 166, 253);
            enterButton.BorderRadius = 8;
            enterButton.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            enterButton.BorderColor = Color.FromArgb(0, 0, 0);
            enterButton.BorderThickness = 1;
            enterButton.Padding = new Padding(10, 3, 10, 3);
            enterButton.Cursor = Cursors.Hand;
            enterButton.Anchor = AnchorStyles.Top;
            enterButton.ForeColor = Color.FromArgb(255, 255, 255);
            enterButton.Size = new Size(200, 65);
            enterButton.Margin = new Padding(0, 25, 0, 0);
            loginFormTableLayoutPanel.Controls.Add(enterButton, 1, 4);
            loginFormTableLayoutPanel.SetRowSpan(enterButton, 2);
            onScreenControls.Add(enterButton);
        }
        private void RegistrationLabelClick(object sender, EventArgs e)
        {
            var messageLabel = CreatСontrolsForLoggingOrRegistration();
            messageLabel.Text = languageResources.GetString("registrationLabel");
            messageLabel.Name = "registrationLabel";

            var passwordRepeatFieldTextBox = new Guna2TextBox();
            passwordRepeatFieldTextBox.Name = "passwordRepeatFieldTextBox";
            passwordRepeatFieldTextBox.Font = new Font(fontCollection.Families[0], 14);
            passwordRepeatFieldTextBox.PlaceholderText = languageResources.GetString(passwordRepeatFieldTextBox.Name);
            passwordRepeatFieldTextBox.FillColor = Color.FromArgb(240, 240, 240);
            passwordRepeatFieldTextBox.BorderRadius = 8;
            passwordRepeatFieldTextBox.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            passwordRepeatFieldTextBox.BorderColor = Color.FromArgb(0, 0, 0);
            passwordRepeatFieldTextBox.BorderThickness = 1;
            passwordRepeatFieldTextBox.Padding = new Padding(10, 3, 10, 3);
            passwordRepeatFieldTextBox.PlaceholderForeColor = Color.FromArgb(151, 151, 151);
            passwordRepeatFieldTextBox.ForeColor = Color.FromArgb(0, 0, 0);
            passwordRepeatFieldTextBox.IconRight = Properties.Resources.eyeHidden;
            passwordRepeatFieldTextBox.IconRightCursor = Cursors.Hand;
            passwordRepeatFieldTextBox.IconRightSize = new Size(40, 40);
            passwordRepeatFieldTextBox.IconRightClick += ShowPasswordPictureBox;
            passwordRepeatFieldTextBox.Cursor = Cursors.IBeam;
            passwordRepeatFieldTextBox.Anchor = AnchorStyles.Top;
            passwordRepeatFieldTextBox.Margin = new Padding(10, 11, 10, 11);
            passwordRepeatFieldTextBox.MaxLength = 30;
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
            registrationButton.Padding = new Padding(10, 3, 10, 3);
            registrationButton.Cursor = Cursors.Hand;
            registrationButton.Anchor = AnchorStyles.Top;
            registrationButton.ForeColor = Color.FromArgb(255, 255, 255);
            registrationButton.Size = new Size(200, 65);
            registrationButton.Margin = new Padding(0, 0, 0, 10);
            registrationButton.AutoSize = true;
            registrationButton.Click += RegistrationButtonClick;
            loginFormTableLayoutPanel.Controls.Add(registrationButton, 1, 5);
            onScreenControls.Add(registrationButton);
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
            var passwordFieldTextBox = sender as Guna2TextBox;

            if (passwordFieldTextBox != null)
            {
                if (!passwordFieldTextBox.UseSystemPasswordChar)
                {
                    logger.Info("Пользователь нажал на иконку для скрытия пароля");

                    passwordFieldTextBox.UseSystemPasswordChar = true;
                    passwordFieldTextBox.IconRight = Properties.Resources.eyeHidden;
                }
                else
                {
                    logger.Info("Пользователь нажал на иконку для просмотра пароля");

                    passwordFieldTextBox.UseSystemPasswordChar = false;
                    passwordFieldTextBox.IconRight = Properties.Resources.eyeVisible;
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
                if (control is Guna2TextBox)
                {
                    var dataTextBox = (TextBox)control;
                    dataTextBox.PlaceholderText = languageResources.GetString(dataTextBox.Name);
                    continue;
                }
                control.Text = languageResources.GetString(control.Name);
            }

            Text = languageResources.GetString(Name);
            flagPictureBox.Image = (Image)languageResources.GetObject("flag");

            logger.Info("Все элементы управления поменяли язык");
        }

        private void EnterZONOAccountButtonClick(object sender, EventArgs e)
        {
            var loginResult = formFunctional.LoginWithAccountZONO(onScreenControls);

            if (loginResult)
            {
                Close();
            }
            else
            {
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


        private void RegistrationButtonClick(object sender, EventArgs e)
        {
            var registrationResult = formFunctional.RegistrationOnZONO(onScreenControls);

            if (registrationResult)
            {
                GoBackPictureBoxClick(sender, e);
            }
            else
            {
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
        
        private void EnterVKAccountButtonClick(object sender, EventArgs e)
        {
            var loginResult = formFunctional.LoginWithAccountVK(onScreenControls);

            if (loginResult)
            {
                Close();
            }
            else
            {
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

        private void LoginForm_SizeChanged(object sender, EventArgs e)
        {
            foreach (var control in onScreenControls)
            {
            }
        }
    }
}