using ZONOupdate.EntityClasses;
using ZONOupdate.Database;
using System.Drawing.Text;
using Guna.UI2.WinForms;
using System.Resources;
using MimeKit;
using NLog;

namespace ZONOupdate.ProjectControls.ControlForCollectionName
{
    /// <summary>
    /// Пользовательский элемент управления для отображения названия подборки в разделе "Мои подборки".
    /// </summary>
    public partial class CollectionNameControl : UserControl
    {
        #region Поля
        User currentUser;
        UserCollection? currentCollection;
        ResourceManager languageResources;
        List<Recommendation>? recommendations; 
        FlowLayoutPanel productsFlowLayoutPanel;
        Logger logger = LogManager.GetCurrentClassLogger();
        CollectionNameControlFunctional collectionNameControlFunctional;
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region Методы
        /// <summary>
        /// Метод, который формирует содержание email сообщения с рекомендациями из подборки.
        /// </summary>
        /// <returns> Сформированное email сообщение. </returns>
        internal MimeMessage CreatingEmailMessage()
        {
            logger.Info($"Формируется сообщение для отправки подборки на почту");

            var messageWithCollection = new MimeMessage();
            messageWithCollection.Subject = languageResources.GetString("messageSubject");

            var htmlFileForSendingCollection = Properties.Resources.htmlFileForSendingCollection;
            var htmlFileWithAppearanceOfRecomendation = Properties.Resources.htmlFileWithAppearanceOfRecomendation;
            var messageBody = new Multipart("alternative");
            var messagePart = new TextPart("html");

            var recomendationsInCollection = new List<Recommendation>();

            if (currentCollection != null)
            {
                recomendationsInCollection = DatabaseInteraction.LoadRecomendationsFromCollection
                    (currentCollection.CollectionID).ToList();

                messagePart.Text = htmlFileForSendingCollection.Replace("{collectionNameTitle}",
                    languageResources.GetString("collectionNameTitle")).Replace("{collectionName}",
                    currentCollection.CollectionName);
            }
            else
            {
                recomendationsInCollection = recommendations;

                messagePart.Text = htmlFileForSendingCollection.Replace("{collectionNameTitle}",
                    languageResources.GetString("collectionNameTitle")).Replace("{collectionName}",
                    languageResources.GetString("selectionWithMatches"));
            }

            if (recomendationsInCollection != null)
            {
                foreach (var recomendation in recomendationsInCollection)
                {
                    messagePart.Text += htmlFileWithAppearanceOfRecomendation.Replace("{recomendationName}",
                        recomendation.RecommendationName).Replace("{recomendationMark}", recomendation.RecommendationMark
                        .ToString()).Replace("{recomendationDescription}", recomendation.RecommendationDescription)
                        .Replace("{recomendationPrice}", recomendation.ProductPriceFrom.ToString()).Replace("{recomendationPriceTitle}",
                        languageResources.GetString("productPriceLabel")).Replace("{recomedationMarkTitle}", languageResources
                        .GetString("productMarkLabel"));
                }
            }

            messagePart.Text += "</div></body></html>";
            messageBody.Add(messagePart);
            messageWithCollection.Body = messagePart;

            return messageWithCollection;
        }
        #endregion

        #region События
        private void ClickOnCollectionControl(object sender, MouseEventArgs e)
        {
            if (currentCollection != null)
            {
                logger.Debug($"Пользователь нажал на подборку с id {currentCollection.CollectionID}");

                productsFlowLayoutPanel.Controls.Clear();

                var recomendationsInCollection = DatabaseInteraction.LoadRecomendationsFromCollection
                    (currentCollection.CollectionID);
                var productControls = new List<ProductControl>();

                foreach (var recommendation in recomendationsInCollection)
                {
                    var productControl = new ProductControl(recommendation, currentUser.ID,
                        languageResources);

                    productControl.MakeProductControlForMyCollections(productsFlowLayoutPanel.Width);
                    productControls.Add(productControl);
                }

                productsFlowLayoutPanel.Controls.AddRange(productControls.ToArray());
            }
        }

        private void ClickOnSelectionWithMatches(object sender, MouseEventArgs e)
        {
            logger.Debug($"Пользователь нажал на подборку с популярными товарами");

            productsFlowLayoutPanel.Controls.Clear();

            if (recommendations != null)
            {
                var productControls = new List<ProductControl>();

                foreach (var recommendation in recommendations)
                {
                    var productControl = new ProductControl(recommendation, currentUser.ID,
                        languageResources);

                    productControls.Add(productControl);
                }

                productsFlowLayoutPanel.Controls.AddRange(productControls.ToArray());
            }
        }

        private void CollectionSendToEmailPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            var resultOfSendingMessage = collectionNameControlFunctional.SendMessageWithCollection(currentUser.ID);

            if (resultOfSendingMessage)
            {
                logger.Warn("Письмо с подборкой успешно отправлено на email почту");

                var successfulMessageSending = new Guna2MessageDialog();
                successfulMessageSending.Buttons = MessageDialogButtons.OK;
                successfulMessageSending.Icon = MessageDialogIcon.Information;
                successfulMessageSending.Style = MessageDialogStyle.Light;
                successfulMessageSending.Parent = FindForm();
                successfulMessageSending.Caption = languageResources.GetString("messageSendingTitle");
                successfulMessageSending.Text = languageResources.GetString("successfulMessageSendingContent");
                successfulMessageSending.Show();
            }
            else
            {
                logger.Warn("Попытка отправки письма с подборкой провалилась");

                var errorMessageSending = new Guna2MessageDialog();
                errorMessageSending.Buttons = MessageDialogButtons.OK;
                errorMessageSending.Icon = MessageDialogIcon.Error;
                errorMessageSending.Style = MessageDialogStyle.Light;
                errorMessageSending.Parent = FindForm();
                errorMessageSending.Caption = languageResources.GetString("messageSendingTitle");
                errorMessageSending.Text = languageResources.GetString("errorMessageSendingContent");
                errorMessageSending.Show();
            }
        }
        #endregion

        #region Конструкторы
        public CollectionNameControl(User currentUser, UserCollection currentCollection,
            FlowLayoutPanel productsFlowLayoutPanel, ResourceManager languageResources, int controlWidth)
        {
            logger.Info($"Создан элемент управления для отображения подборки" +
                $"с id {currentCollection.ID}");

            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            this.productsFlowLayoutPanel = productsFlowLayoutPanel;
            this.languageResources = languageResources;
            this.currentCollection = currentCollection;
            this.currentUser = currentUser;
            collectionNameControlFunctional = new CollectionNameControlFunctional(this);
            InitializeComponent();

            Width = controlWidth;
            collectionNameLabel.Text = currentCollection.CollectionName;
            collectionNameLabel.Font = new Font(fontCollection.Families[0], 14);
            collectionNameTableLayoutPanel.MouseDown += ClickOnCollectionControl;
            collectionNameLabel.MouseDown += ClickOnCollectionControl;
        }

        public CollectionNameControl(User currentUser, FlowLayoutPanel productsFlowLayoutPanel, 
            ResourceManager languageResources, List<Recommendation> recommendations, int controlWidth)
        {
            logger.Info($"Создан элемент управления для отображения подборки с " +
                $"популярными товарами");

            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            this.productsFlowLayoutPanel = productsFlowLayoutPanel;
            this.languageResources = languageResources;
            this.currentUser = currentUser;
            this.recommendations = recommendations;
            collectionNameControlFunctional = new CollectionNameControlFunctional(this);
            InitializeComponent();

            Width = controlWidth;
            collectionNameLabel.Text = languageResources.GetString("selectionWithMatches");
            collectionNameLabel.Font = new Font(fontCollection.Families[0], 14);
            collectionNameTableLayoutPanel.MouseDown += ClickOnSelectionWithMatches;
            collectionNameLabel.MouseDown += ClickOnSelectionWithMatches;
        }
        #endregion
    }
}