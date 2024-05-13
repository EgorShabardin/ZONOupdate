using ZONOupdate.ProjectControls.ControlForCollectionName;
using ZONOupdate.EntityClasses;
using ZONOupdate.Database;
using System.Drawing.Text;
using Guna.UI2.WinForms;
using System.Resources;
using NLog;

namespace ZONOupdate.Forms.FormForCreationNewCollection
{
    /// <summary>
    /// Форма, предназначенная для создания новой подборки товаров.
    /// </summary>
    public partial class NewCollectionCreationForm : Form
    {
        #region Поля
        User curentUser;
        ResourceManager languageResources;
        FlowLayoutPanel listflowlayoutpanel;
        FlowLayoutPanel productsFlowLayoutPanel;
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region Методы
        private void StartReturnNormalTimer()
        {
            var returnToNormalTimer = new System.Windows.Forms.Timer();
            returnToNormalTimer.Interval = 5000;
            returnToNormalTimer.Tick += ReturnToNormalTimerTick;
            returnToNormalTimer.Start();
        }
        #endregion

        #region События
        private void AddNewCollectionButtonMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Успешное подключение к базе данных при " +
                "добавлении новой подборке");

            if (collectionNameTextBox.Text.Equals(String.Empty))
            {
                logger.Debug("Новая подборка не добавлена, т.к. поле с " +
                    "названием подборки пустое");

                informationLabel.Text = languageResources
                    .GetString("addingSelectionEmptyDataField");
                collectionNameTextBox.FillColor = System.Drawing
                    .Color.FromArgb(251, 95, 95);
                StartReturnNormalTimer();

                return;
            }
            if (collectionNameTextBox.Text.Length > 50)
            {
                logger.Debug("Новая подборка не добавлена, т.к. введено слишком" +
                    " длинное название подборки");

                informationLabel.Text = languageResources
                    .GetString("addingCollectionsLongName");
                collectionNameTextBox.FillColor = System.Drawing
                    .Color.FromArgb(251, 95, 95);
                StartReturnNormalTimer();

                return;
            }

            var newCollection = DatabaseInteraction
                .AddNewCollection(curentUser.ID, collectionNameTextBox.Text);

            if (newCollection == null)
            {
                logger.Error("Новая подборка не добавлена");

                var addingSelectionError = new Guna2MessageDialog();
                addingSelectionError.Buttons = MessageDialogButtons.OK;
                addingSelectionError.Icon = MessageDialogIcon.Warning;
                addingSelectionError.Style = MessageDialogStyle.Light;
                addingSelectionError.Parent = FindForm();
                addingSelectionError.Caption = languageResources.GetString("collectionNotCreatedTitle");
                addingSelectionError.Text = languageResources.GetString("collectionNotCreatedContent");
                addingSelectionError.Show();

                return;
            }

            logger.Info("Подборка успешно добавлена");

            listflowlayoutpanel.Controls.Add(new CollectionNameControl(curentUser,
                newCollection, productsFlowLayoutPanel, languageResources, listflowlayoutpanel.Width));
            listflowlayoutpanel.Refresh();

            Close();
        }

        private void NewCollectionCreationFormLoad(object sender, EventArgs e)
        {
            var formAppearanceTimer = new System.Windows.Forms.Timer();
            formAppearanceTimer.Interval = 50;
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

        private void ReturnToNormalTimerTick(object sender, EventArgs e)
        {
            informationLabel.Text = languageResources.GetString(informationLabel.Name);
            collectionNameTextBox.FillColor = SystemColors.ButtonFace;
        }
        #endregion

        #region Конструкторы
        public NewCollectionCreationForm(User curentUser, FlowLayoutPanel productsFlowLayoutPanel,
            ResourceManager languageResources, FlowLayoutPanel listflowlayoutpanel)
        {
            logger.Info("Открылась форма для создания новой подборки");

            this.curentUser = curentUser;
            this.languageResources = languageResources;
            this.listflowlayoutpanel = listflowlayoutpanel;
            this.productsFlowLayoutPanel = productsFlowLayoutPanel;
            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            InitializeComponent();

            informationLabel.Font = new Font(fontCollection.Families[0], 13);
            collectionNameTextBox.Font = new Font(fontCollection.Families[0], 13);
            addNewCollectionButton.Font = new Font(fontCollection.Families[0], 13);

            informationLabel.Text = languageResources.GetString(informationLabel.Name);
            addNewCollectionButton.Text = languageResources.GetString(addNewCollectionButton.Name);
            Text = languageResources.GetString(Name);
        }
        #endregion
    }
}