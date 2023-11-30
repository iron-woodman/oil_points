using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oil_points.Forms
{
    /// <summary>
    /// класс формы настройки рабочих параметров приложения
    /// </summary>
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadParams();
        }
        /// <summary>
        /// Загрузить параметры из файла
        /// </summary>
        private void LoadParams()
        {
            tbEnterFolder.Text = Config.root_in_folder;
            tbArhivFolder.Text = Config.root_arhive_folder;

        }

        /// <summary>
        /// Отменить внесение изменений в настройку рабочих параметров приложения и закрыть форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        ///  Внести изменения в настройку рабочих параметров приложения и закрыть форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveParams();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Сохранить параметры в файл App.config
        /// </summary>
        private void SaveParams()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["IN_root_folder"].Value = tbEnterFolder.Text;
            config.AppSettings.Settings["Arhiv_root_folder"].Value = tbArhivFolder.Text;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");

        }

        /// <summary>
        /// Задать каталог входящих отчетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetupInFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    tbEnterFolder.Text = dialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Задать каталог архива входящих отчетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetupArhivFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    tbArhivFolder.Text = dialog.SelectedPath;
                }
            }
        }
    }
}
