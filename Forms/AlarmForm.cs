using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oil_points.Forms
{
    /// <summary>
    /// Класс формы уведомления о наступлении критического события
    /// </summary>
    public partial class AlarmForm : Form
    {
        public AlarmForm(string message)
        {
            InitializeComponent();
            this.richTextBox1.Text = message;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Принять"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
