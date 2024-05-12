using System.Drawing.Text;
using System.Resources;

namespace ZONOupdate.Forms.FormForWelcomingUser
{
    /// <summary>
    /// Форма, предназанченная для приветсявия пользователя после входа в приложение.
    /// </summary>
    public partial class UserWelcomeForm : Form
    {
        #region События
        private void UserWelcomeFormLoad(object sender, EventArgs e)
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
                    userWelcomeTimer.Start();
                }
            }
        }

        private void UserWelcomeTimerTick(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Конструкторы
        public UserWelcomeForm(ResourceManager languageResources)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            InitializeComponent();

            userWelcomeLabel.Font = new Font(fontCollection.Families[0], 25);
            userWelcomeLabel.Text = languageResources.GetString(userWelcomeLabel.Name);
        }
        #endregion
    }
}