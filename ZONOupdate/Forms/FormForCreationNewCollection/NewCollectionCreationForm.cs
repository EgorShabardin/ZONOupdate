using ZONOupdate.ProjectControls.ControlForCollectionName;
using ZONOupdate.EntityClasses;
using ZONOupdate.Database;
using System.Drawing.Text;
using Guna.UI2.WinForms;
using System.Resources;
using NLog;

namespace ZONOupdate.FormForCreationNewCollection
{
    /// <summary>
    /// Форма для создания новой подборки.
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

        #region События
        private void AddNewCollectionButtonMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Успешное подключение к базе данных при добавлении новой подборке");

            if (collectionNameTextBox.Text.Equals(String.Empty))
            {
                logger.Debug("Новая подборка не добавлена, т.к. поле с названием подборки пустое");

                var addingSelectionError = new Guna2MessageDialog();
                addingSelectionError.Buttons = MessageDialogButtons.OK;
                addingSelectionError.Icon = MessageDialogIcon.Warning;
                addingSelectionError.Style = MessageDialogStyle.Light;
                addingSelectionError.Parent = FindForm();
                addingSelectionError.Caption = languageResources.GetString("addingSelectionEmptyDataFieldTitle");
                addingSelectionError.Text = languageResources.GetString("addingSelectionEmptyDataFieldContent");
                addingSelectionError.Show();

                return;
            }
            if (collectionNameTextBox.Text.Length > 50)
            {
                logger.Debug("Новая подборка не добавлена, т.к. введено слишком длинное название подборки");

                var addingSelectionError = new Guna2MessageDialog();
                addingSelectionError.Buttons = MessageDialogButtons.OK;
                addingSelectionError.Icon = MessageDialogIcon.Warning;
                addingSelectionError.Style = MessageDialogStyle.Light;
                addingSelectionError.Parent = FindForm();
                addingSelectionError.Caption = languageResources.GetString("addingCollectionsLongNameTitle");
                addingSelectionError.Text = languageResources.GetString("addingCollectionsLongNameContent");
                addingSelectionError.Show();

                return;
            }

            var newCollection = DatabaseInteraction.AddNewCollection(curentUser.ID, collectionNameTextBox.Text);

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

            listflowlayoutpanel.Controls.Add(new CollectionNameControl(curentUser, newCollection, productsFlowLayoutPanel,
                languageResources, listflowlayoutpanel.Width));
            listflowlayoutpanel.Refresh();

            Close();
        }

        private void NewCollectionCreationFormLoad(object sender, EventArgs e)
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
        public NewCollectionCreationForm(User curentUser, FlowLayoutPanel productsFlowLayoutPanel,
            ResourceManager languageResources, FlowLayoutPanel listflowlayoutpanel)
        {
            this.curentUser = curentUser;
            this.listflowlayoutpanel = listflowlayoutpanel;
            this.productsFlowLayoutPanel = productsFlowLayoutPanel;
            this.languageResources = languageResources;
            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            InitializeComponent();

            informationLabel.Font = new Font(fontCollection.Families[0], 14);
            collectionNameTextBox.Font = new Font(fontCollection.Families[0], 14);
            saveNewCollectionButton.Font = new Font(fontCollection.Families[0], 14);

            informationLabel.Text = languageResources.GetString(informationLabel.Name);
            saveNewCollectionButton.Text = languageResources.GetString(saveNewCollectionButton.Name);
            Text = languageResources.GetString(Name);
        }
        #endregion
    }
}