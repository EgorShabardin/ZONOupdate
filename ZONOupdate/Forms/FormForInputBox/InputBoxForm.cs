using System.Drawing.Text;
using NLog;

namespace ZONOupdate.Forms.FormForInputBox
{
    /// <summary>
    /// Форма для отображение диалогового окна с возможностью ввода данных.
    /// </summary>
    public partial class InputBoxForm : Form
    {
        #region Поля
        string inputCode = null!;
        Logger logger = LogManager.GetCurrentClassLogger();
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство для получения введенного кода.
        /// </summary>
        public string InputCode
        {
            get
            {
                logger.Info("Попытка получения введенного кода");

                return inputCode;
            }
        }
        #endregion

        #region События
        private void InputBoxButtonMouseDown(object sender, MouseEventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку в InputBoxForm");

            inputCode = inputBoxTextBox.Text;
            Close();
        }
        #endregion

        #region Конструкторы
        public InputBoxForm(string inputBoxName, string inputBoxTitle, string? inputBoxButtonName)
        {
            logger.Info("Открылась форма для ввода кода");

            fontCollection.AddFontFile("../../../Font/GTEestiProDisplayRegular.ttf");
            InitializeComponent();

            inputBoxTitleLabel.Font = new Font(fontCollection.Families[0], 13);
            inputBoxTextBox.Font = new Font(fontCollection.Families[0], 13);
            inputBoxSaveButton.Font = new Font(fontCollection.Families[0], 12);

            Text = inputBoxName;
            inputBoxTitleLabel.Text = inputBoxTitle;
            inputBoxSaveButton.Text = inputBoxButtonName;
        }
        #endregion
    }
}
