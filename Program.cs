using oil_points.Forms;
using oil_points.WorkClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oil_points
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (LoginForm form = new LoginForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CurrentUser.Login = form.UserLogin;
                        Application.Run(new MainForm(form.UserLogin));
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show($"Исключенеи: {ex.Message}");
                    }
                }
                else
                {
                    return;
                }
              
               
            }
        }
    }
}
