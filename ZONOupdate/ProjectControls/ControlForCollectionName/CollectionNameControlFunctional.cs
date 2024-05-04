using ZONOupdate.Database;
using MailKit.Net.Smtp;
using MimeKit;
using NLog;

namespace ZONOupdate.ProjectControls.ControlForCollectionName
{
    /// <summary>
    /// Класс, содержащий функционал элемента управления CollectionNameControl.
    /// </summary>
    internal class CollectionNameControlFunctional
    {
        #region Поля
        CollectionNameControl collectionNameControl;
        Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Методы
        /// <summary>
        /// Метод, отправляющий пользователю подборку с товарами на почту.
        /// <param name="userID"> ID пользователя. </param>
        /// <returns> true - сообщение отправлено; false - сообщение не отправлено. </returns>
        public bool SendMessageWithCollection(Guid userID)
        {
            try
            {
                logger.Info("Попытка отправки писма с содержимым выбранной подборки");

                var messageWithCollection = collectionNameControl.CreatingEmailMessage();
                messageWithCollection.From.Add(new MailboxAddress(Properties.EmailResources
                .applicationEmailName, Properties.EmailResources.applicationEmail));
                messageWithCollection.To.Add(new MailboxAddress(String.Empty, DatabaseInteraction
                    .LoadUserEmail(userID)));

                using (var client = new SmtpClient())
                {
                    client.Connect(Properties.EmailResources.applicationEmailHost, 587, false);
                    client.Authenticate(Properties.EmailResources.applicationEmail,
                        Properties.EmailResources.applicationEmailPassword);
                    client.Send(messageWithCollection);
                    client.Disconnect(true);
                }

                logger.Info("Сообщение успешно отправлено");

                return true;
            }
            catch(Exception ex) 
            {
                logger.Error($"При работе приложение произошла ошибка: {ex}");

                return false;
            }
        }
        #endregion

        #region Конструкторы
        public CollectionNameControlFunctional(CollectionNameControl collectionNameControl)
        {
            this.collectionNameControl = collectionNameControl;
        }
        #endregion
    }
}