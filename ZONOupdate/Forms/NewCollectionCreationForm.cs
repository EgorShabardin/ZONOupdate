using ZONOupdate.EntityClasses;
using ZONOupdate.ProjectControls.ControlForCollectionName;
using ZONOupdate.Database;
using System.Drawing.Text;
using System.Resources;
using NLog;

namespace ZONOupdate.Forms
{
    /// <summary>
    /// Форма создания новой коллекции
    /// </summary>
    public partial class NewCollectionCreationForm : Form
    {
        #region Поля
        User curentUser;
        FlowLayoutPanel listflowlayoutpanel;
        ResourceManager languageResources;
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region События
        private void ClickOnAddNewCollectionButton(object sender, MouseEventArgs e)
        {
            using (var database = new DatabaseContext())
            {
                logger.Info("Успешное подключение к базе данных при добавлении новой подборке");

                if (collectionNameTextBox.Text.Equals(string.Empty))
                {
                    logger.Debug("Новая подборка не добавлена, т.к. поле с названием подборки пустое");

                    MessageBox.Show(languageResources.GetString("addingSelectionEmptyDataFieldContent"), languageResources
                        .GetString("addingSelectionEmptyDataFieldTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (collectionNameTextBox.Text.Length > 16)
                {
                    logger.Debug("Новая подборка не добавлена, т.к. введено слишком длинное название подборки");

                    MessageBox.Show(languageResources.GetString("addingCollectionsLongNameContent"), languageResources
                        .GetString("addingCollectionsLongNameTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newCollection = new UserCollection()
                {
                    CollectionID = Guid.NewGuid(),
                    ID = curentUser.ID,
                    CollectionName = collectionNameTextBox.Text
                };

                logger.Info($"Добавлена новая подборка \"{collectionNameTextBox.Text}\"");

                database.UserCollections.Add(newCollection);
                database.SaveChanges();

                listflowlayoutpanel.Controls.Add(new CollectionNameControl(curentUser, newCollection, listflowlayoutpanel,
                    languageResources, listflowlayoutpanel.Width));
                listflowlayoutpanel.Refresh();

                MessageBox.Show(languageResources.GetString("successfulCollectionCreationContent"), languageResources
                    .GetString("successfulCollectionCreationTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        #endregion

        #region Конструкторы
        public NewCollectionCreationForm(User curentUser, ResourceManager languageResources, FlowLayoutPanel listflowlayoutpanel)
        {
            this.curentUser = curentUser;
            this.listflowlayoutpanel = listflowlayoutpanel;
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