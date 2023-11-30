using bd_worker;
using System;
using System.Windows.Forms;
using Лог;

namespace oil_points.Forms
{
    /// <summary>
    /// класс формы авторизации пользователя
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Логин текущего полльзвателя
        /// </summary>
        public string UserLogin
        {
            get { return tbLogin.Text; }
        }


        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// авторизация пользователя по нажатию кнопки "ОК"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            lbError.Visible = false;
            DB_User user = new DB_User();
            if (user.AuthenticateUser(tbLogin.Text, tbPassword.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lbError.Visible = true;
                tbPassword.Text = "";
                return;
            }
        }

        /// <summary>
        /// отмена входа в ИС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
