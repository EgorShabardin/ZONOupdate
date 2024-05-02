using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Resources;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZONOupdate
{
    public partial class UserWelcomeForm : Form
    {



        private void UserWelcomeTimerTick(object sender, EventArgs e)
        {
            Close();
        }

        public UserWelcomeForm(ResourceManager languageResources)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            InitializeComponent();

            userWelcomeLabel.Font = new Font(fontCollection.Families[0], 25);
            userWelcomeLabel.Text = languageResources.GetString(userWelcomeLabel.Name);
        }
    }
}
