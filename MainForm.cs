using bd_worker;
using oil_points.Forms;
using oil_points.MyControls;
using oil_points.WorkClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Лог;


namespace oil_points
{
   



    public partial class MainForm : Form
    {

        //LastPanel lastPanel = new LastPanel();
        

        MyControls.NodesListControl nodesListControl = new MyControls.NodesListControl();


        private string user_Login = string.Empty;

        public MainForm(string login)
        {
            InitializeComponent();
            nodesListControl.Dock = DockStyle.Fill;
            nodesListControl.BorderStyle = BorderStyle.FixedSingle;
            nodesListControl.Node1Clicked += NodesListControl_NodeClick;
            tableLayoutPanelMain.Controls.Add(nodesListControl, 0, 1);
            user_Login = login;
            logger.WriteToStatLog($" Пользователь '{this.user_Login}' выполнил вход в ИС.");
            timer1.Enabled = true;
            this.Size = new Size(900, 400);
         


        }

        private void NodesListControl_NodeClick(object sender, EventArgs e)
        {
            ShowNodeStat(((MyControls.NodesListControl)sender).SelectedNode, ((MyControls.NodesListControl)sender).SelectedNodeCaption);
        }

        /// <summary>
        /// показать статистику узла 
        /// </summary>
        /// <param name="selectedNode"></param>
        /// <param name="selectedNodeCaption"></param>
        private void ShowNodeStat(string selectedNode, string selectedNodeCaption)
        {
            tableLayoutPanelMain.Controls.Remove(tableLayoutPanelMain.GetControlFromPosition(0, 1));
            MyControls.NodeStatControl nodeStatControl = new MyControls.NodeStatControl(selectedNode);
            tableLayoutPanelMain.Controls.Add(nodeStatControl, 0, 1);
            nodeStatControl.Dock = DockStyle.Fill;
            tableLayoutPanelMain.ColumnStyles[0].Width = 100;
            tableLayoutPanelMain.ColumnStyles[1].Width = 0;
            nodeStatControl.BorderStyle = BorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Maximized;


        }



        private void label_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.LightCoral;
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.White;
        }

        private void lbMenuExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        /// <summary>
        /// Выйти из приложения
        /// </summary>
        private void Exit()
        {
            logger.WriteToStatLog($" Пользователь '{this.user_Login}' вышел из ИС.");
            this.Close();
        }

        /// <summary>
        /// вернуться на предыдущую вкладку ПО
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMenuBack_Click(object sender, EventArgs e)
        {
            if (LastPanel.Stack.Count == 0)
            {
                ShowNodeList();
                return;
            }

            var prev_panel = LastPanel.Stack.Pop();

            switch (prev_panel)
            {
                case WorkClasses.Panel.NODE_LIST: ShowNodeList();break;
                case WorkClasses.Panel.NODE1_STAT: ShowNodeStat("node1", nodesListControl.Node1Caption); break;
                case WorkClasses.Panel.NODE2_STAT: ShowNodeStat("node2", nodesListControl.Node2Caption); break;
                case WorkClasses.Panel.NODE3_STAT: ShowNodeStat("node3", nodesListControl.Node3Caption); break;
                default: ShowNodeList(); break;

            }
        }

        private void ShowNodeList()
        {
            tableLayoutPanelMain.Controls.Remove(tableLayoutPanelMain.GetControlFromPosition(0, 1));
            tableLayoutPanelMain.Controls.Add(nodesListControl, 0, 1);
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(900, 300);
        }

        /// <summary>
        /// Вызов диалога настроек ПО
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMenuSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm form = new SettingsForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }

        /// <summary>
        /// Просмотр логов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMenuLogs_Click(object sender, EventArgs e)
        {
            ShowLogDatesList();
        }

        /// <summary>
        /// Показать список дат с логами
        /// </summary>
        private void ShowLogDatesList()
        {
            tableLayoutPanelMain.Controls.Remove(tableLayoutPanelMain.GetControlFromPosition(0, 1));
            List<MyControls.StringValue> dates = GetLogsDates();
            MyControls.ReportListControl logs_dates_control = new MyControls.ReportListControl(dates, "Журналы событий ИС");
            logs_dates_control.ListItemClicked += Logs_dates_control_ListItemClicked;
            logs_dates_control.ListItemDelete += Logs_dates_control_ListItemDelete;
            tableLayoutPanelMain.Controls.Add(logs_dates_control, 0, 1);
            logs_dates_control.Dock = DockStyle.Fill;
            tableLayoutPanelMain.ColumnStyles[0].Width = 100;
            tableLayoutPanelMain.ColumnStyles[1].Width = 0;
            this.WindowState = FormWindowState.Maximized;

        }


        /// <summary>
        /// выбран пункт меню удаления лога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logs_dates_control_ListItemDelete(object sender, EventArgs e)
        {
            var date = ((ReportItemClickEventArgs)e).ClickedItemCaption;
            DeleteLogData(date);
        }


        /// <summary>
        /// удалить лог за указанную дату
        /// </summary>
        /// <param name="date"></param>
        private void DeleteLogData(string date)
        {
            string log_file_path = Path.Combine("Logs", $"{date}.log");
            if (!File.Exists(log_file_path))
            {
                MessageBox.Show($"Лог-файл {log_file_path} не обнаружен");
                return;
            }

            try
            {
                File.Delete(log_file_path);
                ShowLogDatesList();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Выбран элемент списка логов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logs_dates_control_ListItemClicked(object sender, EventArgs e)
        {
            var date = ((ReportItemClickEventArgs)e).ClickedItemCaption;
            ShowLogData(date);
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Показать содержимое лога за конкретную дату
        /// </summary>
        /// <param name="date"></param>
        private void ShowLogData(string date)
        {
            string log_file_path = Path.Combine("Logs", $"{date}.log");
            if (!File.Exists(log_file_path))
            {
                MessageBox.Show($"Лог-файл {log_file_path} не обнаружен");
                return;
            }

            DataTable dt = new DataTable("day_report");
            dt.Columns.Add("Время", typeof(string));
            dt.Columns.Add("Событие", typeof(string));
            dt.Columns.Add("Сообщение", typeof(string));

            try
            {
                using (StreamReader sr = new StreamReader(log_file_path))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var items = line.Split('\t');
                        if (items.Length == 3)
                        {
                            DataRow row = dt.NewRow();
                            row[0] = items[0].ToString();
                            row[1] = items[1].ToString(); 
                            row[2] = items[2].ToString();
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Исключение: " + ex.Message);
                return;
            }

            //LastPanel.Value = WorkClasses.Panel.LOG_DATES_LIST;

            tableLayoutPanelMain.Controls.Remove(tableLayoutPanelMain.GetControlFromPosition(0, 1));
            // открываем microsoft word и показываем заполненный шаблон часового отчета
            ReportTableControl report_table_control = new ReportTableControl(dt, $"Журнал событий ({date})", $"");
            tableLayoutPanelMain.Controls.Add(report_table_control, 0, 1);
            report_table_control.Dock = DockStyle.Fill;
        }


        /// <summary>
        /// получить список дат всех отчетов ИС
        /// </summary>
        /// <returns></returns>
        private List<StringValue> GetLogsDates()
        {
            string[] logs_files = Directory.GetFiles("Logs", "*.log");

            List<StringValue> dates = new List<StringValue>();

            for (int i = 0; i < logs_files.Length; i++)
            {
                var date = new StringValue(Path.GetFileNameWithoutExtension(logs_files[i]));
                if (!dates.Contains(date))
                {
                    dates.Add(date);
                }
            }
            return dates;
        }


        // поиск новых xml-файлов и занесение их в БД (фоновый поток)
        private void bwDBFiller_DoWork(object sender, DoWorkEventArgs e)
        {
            DB_Filler db_filler = new DB_Filler();
            db_filler.CriticalEventNotify += Db_filler_CriticalEventNotify;
            Config.StoreFilesToArchive = true;
            db_filler.ProcessNewData();
        }

        /// <summary>
        /// Обработчик критического события
        /// </summary>
        /// <param name="message"></param>
        private void Db_filler_CriticalEventNotify(string message)
        {

            string[] items = message.Split(':');
            if (items.Length > 0)
            {
                var node = items[0];
                var node_caption = node;

                switch (node)
                {
                    case "node1": node_caption = "СИКН №1"; break;
                    case "node2": node_caption = "СИКН №2"; break;
                    case "node3": node_caption = "СИКН №3"; break;
                }

                message = message.Replace(node+":", node_caption + ":\n");

            }


            using (AlarmForm alarm_form = new AlarmForm(message))
            {
                alarm_form.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!bwDBFiller.IsBusy)
            {
                //зпускаем поток наполения БД стат данными из новых xml-файлов 
                bwDBFiller.RunWorkerAsync();
            }
        }
    }


    

}
