using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using oil_points.Forms;
using oil_points.WorkClasses;
using Лог;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;

namespace oil_points.MyControls
{
    public partial class NodeStatControl : UserControl
    {
        /// <summary>
        /// узел контроля
        /// </summary>
        private string node;

        /// <summary>
        /// название узла контроля
        /// </summary>
        private string node_caption;

        DataSet nodeDataSet = new DataSet();

        /// <summary>
        ////текущий пункт меню
        /// </summary>
        CurrentMenuItem currentMenuItem = CurrentMenuItem.NONE;

        ToolTip tooltip = new ToolTip();

        public NodeStatControl(string node)
        {
            InitializeComponent();
            chart1.Legends.Clear();
            this.node = node;
            switch (this.node)
            {
                case "node1": this.node_caption = "СИКН №1"; break;
                case "node2": this.node_caption = "СИКН №2"; break;
                case "node3": this.node_caption = "СИКН №3"; break;
            }

            this.Dock = DockStyle.Fill;
            bwDataSetLoader.RunWorkerAsync();
            SetParametersButtonDefaultColors();
            SetSuppliersButtonDefaultColors();
            this.btnTemperature.BackColor = Color.Gray;
            LastPanel.Stack.Push(WorkClasses.Panel.NODE_LIST); // запоминаем предудущую панель (для возвращения по нажатию кнопки "Назад")

        }




        /// <summary>
        /// Поток загрузки набора данных узла из БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwDataSetLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            this.nodeDataSet.Tables.Clear();
            this.nodeDataSet = WorkClasses.DataSetLoader.GetDataSet(this.node);
        }

        /// <summary>
        /// Обработчик события завершения работы потока загрузки набора данных из БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwDataSetLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (nodeDataSet == null)
            {
                return;
            }
            // кол-во событий
            int events_count = 0;

            if (nodeDataSet.Tables.Contains($"{this.node}_events"))
            {
                events_count = nodeDataSet.Tables[$"{this.node}_events"].Rows.Count;
            }

            // кол-во критических событий
            int critical_events_count = 0;

            if (nodeDataSet.Tables.Contains($"{this.node}_critical_events"))
            {
                critical_events_count = nodeDataSet.Tables[$"{this.node}_critical_events"].Rows.Count;
            }

            lbEventsCount.Text = (events_count + critical_events_count).ToString();


            // рассчет кол-ва отчетов
            int hour_reports_count = 0; // часовые 
            int day_reports_count = 0; // суточные
            int period_reports_count = 0; // за период

            if (nodeDataSet.Tables.Contains($"{this.node}_reports"))
            {

                List<string> report_hour_list = new List<string>(); // кол-во уникальных записей по часам
                List<string> report_day_list = new List<string>(); // кол-во уникальных записей по суткам
                for (int i = 0; i < nodeDataSet.Tables[$"{this.node}_reports"].Rows.Count; i++)
                {
                    var report_time = nodeDataSet.Tables[$"{this.node}_reports"].Rows[i]["Время"].ToString();

                    var date = DateTime.Parse(report_time).ToShortDateString();

                    if (!report_hour_list.Contains(report_time))
                    {
                        report_hour_list.Add(report_time);
                    }

                    if (!report_day_list.Contains(date))
                    {
                        report_day_list.Add(date);
                    }

                }
                hour_reports_count = report_hour_list.Count;
                day_reports_count = report_day_list.Count;
            }

            if (nodeDataSet.Tables.Contains($"{this.node}_reports_period"))
            {
                period_reports_count = nodeDataSet.Tables[$"{this.node}_reports_period"].Rows.Count;
            }

            lbReportsCount.Text = (hour_reports_count + day_reports_count + period_reports_count).ToString();

            // расчет кол-ва паспортов/протоколов
            int kmx_temperature_count = 0;
            int kmx_pressure_count = 0;
            int kmx_density_count = 0;

            if (nodeDataSet.Tables.Contains($"{this.node}_kmx_temperature"))
            {
                // список уникальных значений номеров протоколов
                List<string> ProtocolNumberList = new List<string>();
                for (int i = 0; i < nodeDataSet.Tables[$"{this.node}_kmx_temperature"].Rows.Count; i++)
                {
                    var protocolNumber = nodeDataSet.Tables[$"{this.node}_kmx_temperature"].Rows[i]["ProtocolNumber"].ToString();
                    if (!ProtocolNumberList.Contains(protocolNumber))
                    {
                        ProtocolNumberList.Add(protocolNumber);
                    }
                }

                kmx_temperature_count = ProtocolNumberList.Count;
            }

            if (nodeDataSet.Tables.Contains($"{this.node}_kmx_pressure"))
            {
                List<string> ProtocolNumberList = new List<string>();
                for (int i = 0; i < nodeDataSet.Tables[$"{this.node}_kmx_pressure"].Rows.Count; i++)
                {
                    var protocolNumber = nodeDataSet.Tables[$"{this.node}_kmx_pressure"].Rows[i]["ProtocolNumber"].ToString();
                    if (!ProtocolNumberList.Contains(protocolNumber))
                    {
                        ProtocolNumberList.Add(protocolNumber);
                    }
                }

                kmx_pressure_count = ProtocolNumberList.Count;

            }

            if (nodeDataSet.Tables.Contains($"{this.node}_kmx_density"))
            {
                List<string> ProtocolNumberList = new List<string>();
                for (int i = 0; i < nodeDataSet.Tables[$"{this.node}_kmx_density"].Rows.Count; i++)
                {
                    var protocolNumber = nodeDataSet.Tables[$"{this.node}_kmx_density"].Rows[i]["ProtocolNumber"].ToString();
                    if (!ProtocolNumberList.Contains(protocolNumber))
                    {
                        ProtocolNumberList.Add(protocolNumber);
                    }
                }

                kmx_density_count = ProtocolNumberList.Count;
            }

            lbProtocolsCount.Text = (kmx_temperature_count + kmx_pressure_count + kmx_density_count).ToString();

            // рассчет объема прокачаннной нефти

            double total_oil_mass = 0;
            if (nodeDataSet.Tables.Contains($"{this.node}_reports_period"))
            {
                for (int i = 0; i < nodeDataSet.Tables[$"{this.node}_reports_period"].Rows.Count; i++)
                {
                    total_oil_mass += (double)(nodeDataSet.Tables[$"{this.node}_reports_period"].Rows[i]["NetOilMass"]);
                }
            }

            lbOilVolumeStat.Text = $"Прокачано {total_oil_mass} тонн.";

            ShowChartStat();
            ShowCurrentPanel();
        }

        /// <summary>
        /// Показать список дат с протоколами КМХ преобразователей давления
        /// </summary>
        private void ShowKmxPressureDatesList()
        {
            string table_name = $"{node}_kmx_pressure";
            if (!nodeDataSet.Tables.Contains(table_name))
            {
                MessageBox.Show($"Таблица статистики '{table_name}' не существует!");
                return;
            }

            lbCurrentOilParameter.Text = "Протоколы КМХ преобразователей давления по датам";

            //прячем панель с гграфиком и правую панель
            ShowPanels(false, true);

            List<StringValue> reports_date_list = new List<StringValue>();
            List<string> dates = new List<string>();
            for (int i = 0; i < nodeDataSet.Tables[table_name].Rows.Count; i++)
            {
                var date = ((DateTime)nodeDataSet.Tables[table_name].Rows[i]["CheckTime"]).ToShortDateString();
                if (dates.Contains(date))
                {
                    continue;
                }
                dates.Add(date);
                reports_date_list.Add(new StringValue(date));
            }

            ReportListControl report_list_control = new ReportListControl(reports_date_list, "Протоколы КМХ преобразователей давления");
            tlpMain.Controls.Add(report_list_control, 2, 1);
            report_list_control.Dock = DockStyle.Fill;
            report_list_control.ListItemClicked += Dates_list_control_ListItemClicked;
            report_list_control.ListItemDelete += Report_list_control_ListItemDelete;
        }


        /// <summary>
        /// клик на элементе управления протокола КМХ плотногсти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_kmx_density_protocol_Click(object sender, EventArgs e)
        {
            currentMenuItem = CurrentMenuItem.KMX_DENSITY;
            ShowCurrentPanel();
        }



        /// <summary>
        /// показать список дат штатных событий
        /// </summary>
        private void ShowEventDatesList()
        {
            if (nodeDataSet == null)
            {
                return;
            }

            if (!nodeDataSet.Tables.Contains($"{node}_events"))
            {
                MessageBox.Show($"Таблица статистики {node}_events не существует!");
                return;
            }

            lbCurrentOilParameter.Text = "Журнал событий";

            // формируем список событий форма  События-дата
            List<StringValue> events_date_list = new List<StringValue>();
            List<string> dates = new List<string>();
            for (int i = 0; i < nodeDataSet.Tables[$"{node}_events"].Rows.Count; i++)
            {
                var date = ((DateTime)nodeDataSet.Tables[$"{node}_events"].Rows[i]["Время"]).ToShortDateString();
                if (dates.Contains(date))
                {
                    continue;
                }
                dates.Add(date);
                events_date_list.Add(new StringValue(date));

            }

            ReportListControl report_list_control = new ReportListControl(events_date_list, "Штатные события");
            tlpMain.Controls.Add(report_list_control, 2, 1);
            report_list_control.Dock = DockStyle.Fill;
            report_list_control.ListItemClicked += Dates_list_control_ListItemClicked;
            report_list_control.ListItemDelete += Report_list_control_ListItemDelete;
        }


        /// <summary>
        /// показать список дат критических событий
        /// </summary>
        private void ShowCriticalEventDatesList()
        {
            if (nodeDataSet == null)
            {
                return;
            }

            if (!nodeDataSet.Tables.Contains($"{node}_critical_events"))
            {
                MessageBox.Show($"Таблица статистики {node}_critical_events не существует!");
                return;
            }


            // формируем список событий форма  События-дата
            List<StringValue> events_date_list = new List<StringValue>();
            List<string> dates = new List<string>();
            for (int i = 0; i < nodeDataSet.Tables[$"{node}_critical_events"].Rows.Count; i++)
            {
                var date = ((DateTime)nodeDataSet.Tables[$"{node}_critical_events"].Rows[i]["Время"]).ToShortDateString();
                if (dates.Contains(date))
                {
                    continue;
                }
                dates.Add(date);
                events_date_list.Add(new StringValue(date));

            }

            ReportListControl report_list_control = new ReportListControl(events_date_list, "Критические события");
            tlpMain.Controls.Add(report_list_control, 2, 1);
            report_list_control.Dock = DockStyle.Fill;
            report_list_control.ListItemClicked += Dates_list_control_ListItemClicked;
            report_list_control.ListItemDelete += Report_list_control_ListItemDelete;
        }



        /// <summary>
        /// показать список дат протоколов  КМХ плотномеров по ареометру
        /// </summary>
        private void ShowKmxDensityDatesList()
        {
            string table_name = $"{node}_kmx_density";
            if (!nodeDataSet.Tables.Contains(table_name))
            {
                MessageBox.Show($"Таблица статистики '{table_name}' не существует!");
                return;
            }


            List<StringValue> reports_date_list = new List<StringValue>();
            List<string> dates = new List<string>();
            for (int i = 0; i < nodeDataSet.Tables[table_name].Rows.Count; i++)
            {
                var date = ((DateTime)nodeDataSet.Tables[table_name].Rows[i]["CheckTime"]).ToShortDateString();
                if (dates.Contains(date))
                {
                    continue;
                }
                dates.Add(date);
                reports_date_list.Add(new StringValue(date));
            }

            ReportListControl report_list_control = new ReportListControl(reports_date_list, $"Протоколы КМХ плотномеров по ареометру {node_caption}");
            tlpMain.Controls.Add(report_list_control, 2, 1);
            report_list_control.Dock = DockStyle.Fill;
            report_list_control.ListItemClicked += Dates_list_control_ListItemClicked;
            report_list_control.ListItemDelete += Report_list_control_ListItemDelete;
        }



        /// <summary>
        /// показываем текущую панель данных (статистику) согласно выбранному пункту меню
        /// </summary>
        private void ShowCurrentPanel()
        {
            switch (currentMenuItem)
            {
                case CurrentMenuItem.EVENTS:
                    ShowPanels(false, true);
                    ShowEventDatesList();
                    break;


                case CurrentMenuItem.CRITICAL_EVENTS:
                    ShowPanels(false, true);
                    ShowCriticalEventDatesList();
                    break;

                case CurrentMenuItem.DAY_REPORT:
                    ShowPanels(false, true);
                    ShowReportDatesList();
                    break;

                case CurrentMenuItem.HOUR_REPORT:
                    ShowPanels(false, true);
                    ShowReportDatesList();
                    break;

                case CurrentMenuItem.PERIOD_REPORT:
                    ShowPanels(false, true);
                    ShowPeriodReports();
                    break;

                case CurrentMenuItem.KMX_TEMPERATURE:
                    ShowPanels(false, true);
                    ShowKmxTempDatesList();
                    break;

                case CurrentMenuItem.KMX_PRESSURE:
                    ShowPanels(false, true);
                    ShowKmxPressureDatesList();
                    break;

                case CurrentMenuItem.KMX_DENSITY:
                    ShowPanels(false, true);
                    ShowKmxDensityDatesList();
                    break;

                case CurrentMenuItem.SUPPLIER_1:
                    ShowPanels(false, true);
                    ShowSupplierPassportDateList("АО Нафтатранс");
                    break;

                case CurrentMenuItem.SUPPLIER_2:
                    ShowPanels(false, true);
                    ShowSupplierPassportDateList("ПАО Лукойл");
                    break;

                case CurrentMenuItem.SUPPLIER_3:
                    ShowPanels(false, true);
                    ShowSupplierPassportDateList("ПАО Татнефть");
                    break;

                default:
                    // показываем стартовую панель
                    chart1.Show();
                    ShowChartStat();
                    ShowPanels(true, false);
                    break;

            }
        }


        /// <summary>
        /// отобразить график выбранного параметра за выбранный временной интервал
        /// </summary>
        private void ShowChartStat()
        {
            if (!nodeDataSet.Tables.Contains($"{node}_reports"))
            {
                MessageBox.Show($"Таблица статистики {node}_reports не существует!");
                return;
            }

            string[] dates = linkLabelTimePeriod.Text.Replace("Диапазон дат: ", "").Split('-');
            string start_time = dates[0];
            string end_time = dates[1];

            DataRow[] rows = nodeDataSet.Tables[$"{node}_reports"].Select($"[Время] >= '{start_time}' and  [Время] < '{end_time}'");
            //DataRow[] rows = nodeDataSet.Tables[$"{node}_reports"].Select($"[Время] >= '2023-11-03 02:00:00' and  [Время] < '2023-11-03 09:00:00'");
            chart1.Series.Clear();
            if (rows.Length == 0)
            {
                return;
            }

            string columnName = string.Empty;
            Color chart_color = Color.Blue;
            int intervalX = 5;
            int yMaxValue = 900;
            string units_of_measurement = string.Empty;
            switch (lbCurrentOilParameter.Text)
            {
                case "Температура":
                    columnName = "Средняя температура";
                    chart_color = Color.Blue;
                    intervalX = 5;
                    yMaxValue = 70;
                    units_of_measurement = "C";
                    break;
                case "Давление":
                    columnName = "Среднее давление";
                    chart_color = Color.LawnGreen;
                    intervalX = 50;
                    yMaxValue = 700;
                    units_of_measurement = "кПА";
                    break;
                case "Плотность":
                    columnName = "Средняя плотность";
                    chart_color = Color.Orange;
                    intervalX = 50;
                    units_of_measurement = "кг/м3";
                    break;
                case "Плотность при 20С":
                    columnName = "Средняя плотность при 20С";
                    chart_color = Color.Yellow;
                    intervalX = 50;
                    units_of_measurement = "кг/м3";
                    break;
                default: return;
            }

            chart1.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series(lbCurrentOilParameter.Text));
            chart1.ChartAreas[0].AxisY.Title = columnName + $", {units_of_measurement}";
            chart1.ChartAreas[0].AxisX.Title = "Порядковый номер отчета";
            chart1.ChartAreas[0].AxisY.Interval = intervalX;
            chart1.ChartAreas[0].AxisY.Maximum = yMaxValue;
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("Times New Roman", 14, FontStyle.Bold);
            chart1.ChartAreas[0].AxisX.TitleFont = new Font("Times New Roman", 14, FontStyle.Bold);


            chart1.Series[0].Color = chart_color;



            Hashtable time_lines_data = new Hashtable(); //key=времяб value = значения параметра по 3-м линиям (далее будем считать среднее арифмитическое)


            for (int i = 0; i < rows.Length; i++)
            {
                var parametr_value = Convert.ToDouble(rows[i][columnName].ToString().Replace(".", ","));
                var time = rows[i]["Время"].ToString();
                if (time_lines_data.ContainsKey(time))
                {
                    ((List<double>)time_lines_data[time]).Add(parametr_value);
                }
                else
                {
                    // список значений выбранного параметра в один и тот же час по разным линиям
                    List<double> param_value_list = new List<double>();
                    param_value_list.Add(parametr_value);
                    time_lines_data.Add(time, param_value_list);
                }

            }

            // формируем список точек для отображения на графике
            int point_number = 0;
            foreach (string key in time_lines_data.Keys)
            {

                chart1.Series[lbCurrentOilParameter.Text].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(++point_number, GetMiddleValue((List<double>)time_lines_data[key])));
            }

            chart1.ChartAreas[0].AxisY.Maximum = yMaxValue;

        }

        /// <summary>
        /// получить среднее значение элементов списка
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        private double GetMiddleValue(List<double> values_list)
        {
            double result = 0;
            for (int i = 0; i < values_list.Count; i++)
            {
                result += values_list[i];
            }

            if (values_list.Count > 0)
            {
                result = Math.Round(result / values_list.Count, 2);
            }
            return result;
        }


        /// <summary>
        /// показать отчет за период
        /// </summary>
        /// <param name="period"></param>
        private void ShowPeriodReport(string period)
        {
            string[] period_items = period.Split('-');
            string start_date = period_items[0];
            string end_date = period_items[1];

            DataRow[] period_reports_rows = nodeDataSet.Tables[$"{node}_reports_period"].Select($"[StartTime] = '{start_date}' and  [EndTime] = '{end_date}'");
            //прячем другие панели статистики показываем только 5-ю панель
            ShowPanels(false, true);

            var items = new Dictionary<string, string>();
            items.Add("<NodeName>", this.node_caption);
            for (int i = 0; i < nodeDataSet.Tables[$"{node}_reports_period"].Columns.Count; i++)
            {
                string column_name = nodeDataSet.Tables[$"{node}_reports_period"].Columns[i].ColumnName;
                items.Add($"<{column_name}>", $"{period_reports_rows[0][column_name].ToString()}");
            }


            PeriodReportTableControl perid_report_control = new PeriodReportTableControl(items, @"templates\period_report.doc");
            tlpMain.Controls.Add(perid_report_control, 2, 1);
            perid_report_control.Dock = DockStyle.Fill;

        }

        /// <summary>
        /// показать список часовых отчетов за выбранную дату
        /// </summary>
        /// <param name="date"></param>
        private void ShowHourReportsListPerDate(string report_date)
        {
            string[] date_items = report_date.Split('.');

            string corrected_date = $"{date_items[2]}-{date_items[1]}-{date_items[0]}";
            report_date = corrected_date;


            DataRow[] hour_reports_rows = nodeDataSet.Tables[$"{node}_reports"].Select($"[Время] >= '{report_date} 00:00:00' and  [Время] < '{report_date} 23:59:59'");

            // формируем список событий форма  События-дата
            List<StringValue> reports_per_date_list = new List<StringValue>();
            List<string> hours = new List<string>();
            for (int i = 0; i < hour_reports_rows.Length; i++)
            {
                string start_hour = ((DateTime)hour_reports_rows[i]["Время"]).Hour.ToString();
                string end_hour = (Convert.ToInt32(start_hour) + 1).ToString();
                if (start_hour.Length == 1)
                {
                    start_hour = "0" + start_hour;
                }

                if (end_hour.Length == 1)
                {
                    end_hour = "0" + end_hour;
                }

                string hour = $"{start_hour}:00-{end_hour}:00";

                if (hours.Contains(hour))
                {
                    continue;
                }
                hours.Add(hour);
                reports_per_date_list.Add(new StringValue(hour));

            }

            ReportListControl report_list_control = new ReportListControl(reports_per_date_list, $"{report_date}");
            tlpMain.Controls.Add(report_list_control, 2, 1);
            report_list_control.Dock = DockStyle.Fill;
            report_list_control.ListItemClicked += hour_report_ItemClicked;
        }


        /// <summary>
        /// обработчик события выбора конкретного часового отчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hour_report_ItemClicked(object sender, EventArgs e)
        {
            //часовой интервал
            var interval = ((ReportItemClickEventArgs)e).ClickedItemCaption;


            string[] items = interval.Split('-');
            if (items.Length != 2)
            {
                MessageBox.Show("Некорректный формат врменного интервала");
                return;
            }

            string start_hour = items[0].Split(':')[0];
            string end_hour = items[1].Split(':')[0];


            //дата
            string report_date = ((ReportItemClickEventArgs)e).Header;

            //выборка данных конкретногго-часового отчета
            DataRow[] hour_reports_rows = nodeDataSet.Tables[$"{node}_reports"].Select($"[Время] >= '{report_date} {start_hour}:00:00' and  [Время] < '{report_date} {start_hour}:59:59'");

            if (hour_reports_rows.Length < 3)
            {
                return;
            }

            //прячем другие панели статистики показываем только 5-ю панель
            ShowPanels(false, true);
            //формируем таблицу часового отчета
            DataTable dt = new DataTable("hour_report");
            dt.Columns.Add("Показатели", Type.GetType("System.String"));
            dt.Columns.Add("Един. Измер.", Type.GetType("System.String"));
            dt.Columns.Add("Линия1", Type.GetType("System.Double"));
            dt.Columns.Add("Линия2", Type.GetType("System.Double"));
            dt.Columns.Add("Линия3", Type.GetType("System.Double"));
            dt.Columns.Add("БИЛ", Type.GetType("System.Double"));


            // заполняем таблицу данными
            for (int i = 3; i < nodeDataSet.Tables[$"{node}_reports"].Columns.Count; i++)
            {
                DataRow dr = dt.NewRow();
                var column = nodeDataSet.Tables[$"{node}_reports"].Columns[i].ColumnName;
                dr[0] = column;
                dr[1] = GetUnitOfMeasurementsByPrameterName(column);
                dr[2] = hour_reports_rows[0][column];
                dr[3] = hour_reports_rows[1][column];
                dr[4] = hour_reports_rows[2][column];
                dr[5] = Math.Round((Convert.ToDouble(dr[2]) + Convert.ToDouble(dr[3]) + Convert.ToDouble(dr[4])) / GetDelitelByParameterName(column), 2); // округляем до 2 знаков после запятой
                dt.Rows.Add(dr);
            }

            // открываем microsoft word и показываем заполненный шаблон часового отчета
            ReportTableControl report_table_control = new ReportTableControl(dt, $"Часовой отчет ({report_date})", $"{start_hour}:00-{end_hour}:00");
            tlpMain.Controls.Add(report_table_control, 2, 1);
            report_table_control.Dock = DockStyle.Fill;

        }





        /// <summary>
        /// показать события за указанную дату
        /// </summary>
        /// <param name="date"></param>
        private void ShowEventsPerDate(string event_date)
        {
            string[] date_items = event_date.Split('.');

            string corrected_date = $"{date_items[2]}-{date_items[1]}-{date_items[0]}";
            event_date = corrected_date;


            DataRow[] events_rows = nodeDataSet.Tables[$"{node}_events"].Select($"[Время] >= '{event_date} 00:00:00' and  [Время] < '{event_date} 23:59:59'");

            //формируем таблицу часового отчета
            DataTable dt = new DataTable("hour_report");
            dt.Columns.Add("Время", Type.GetType("System.String"));
            dt.Columns.Add("Событие", Type.GetType("System.String"));



            // формируем список событий форма  События-дата
            for (int i = 0; i < events_rows.Length; i++)
            {
                DataRow row = dt.NewRow();
                var time = $"{((DateTime)events_rows[i]["Время"]).ToShortDateString()} {((DateTime)events_rows[i]["Время"]).ToShortTimeString()}";
                var cur_event = events_rows[i]["Событие"];
                row[0] = time;
                row[1] = cur_event;
                dt.Rows.Add(row);
            }

            ReportTableControl report_table_control = new ReportTableControl(dt, $"Штатные события", event_date);
            tlpMain.Controls.Add(report_table_control, 2, 1);
            report_table_control.Dock = DockStyle.Fill;

        }

        /// <summary>
        /// показать критические события за указанную дату
        /// </summary>
        /// <param name="date"></param>
        private void ShowCriticalEventsPerDate(string event_date)
        {
            string[] date_items = event_date.Split('.');

            string corrected_date = $"{date_items[2]}-{date_items[1]}-{date_items[0]}";
            event_date = corrected_date;


            DataRow[] events_rows = nodeDataSet.Tables[$"{node}_critical_events"].Select($"[Время] >= '{event_date} 00:00:00' and  [Время] < '{event_date} 23:59:59'");


            //формируем таблицу часового отчета
            DataTable dt = new DataTable("hour_report");
            dt.Columns.Add("Время", Type.GetType("System.String"));
            dt.Columns.Add("Событие", Type.GetType("System.String"));



            // формируем список событий форма  События-дата
            for (int i = 0; i < events_rows.Length; i++)
            {
                DataRow row = dt.NewRow();
                var time = $"{((DateTime)events_rows[i]["Время"]).ToShortDateString()} {((DateTime)events_rows[i]["Время"]).ToShortTimeString()}";
                var cur_event = events_rows[i]["Событие"];
                row[0] = time;
                row[1] = cur_event;
                dt.Rows.Add(row);
            }

            ReportTableControl report_table_control = new ReportTableControl(dt, $"Критические события", event_date);
            tlpMain.Controls.Add(report_table_control, 2, 1);
            report_table_control.Dock = DockStyle.Fill;

        }



        /// <summary>
        /// Обработчик события клика по элементу списка перечня отчетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Period_list_control_ListItemClicked(object sender, EventArgs e)
        {
            var period = ((ReportItemClickEventArgs)e).ClickedItemCaption;
            ShowPeriodReport(period);
        }


        /// <summary>
        /// получить делитель подсчета среднего значения по имени параметра
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private int GetDelitelByParameterName(string param_name)
        {
            int delitel = 3;
            switch (param_name)
            {
                case "Средний расход": delitel = 1; break;
                case "Средняя температура": delitel = 3; break;
                case "Среднее давление": delitel = 3; break;
                case "Средняя плотность": delitel = 3; break;
                case "Средняя плотность при 20С": delitel = 3; break;
                case "Среднее объёмное содержание воды": delitel = 3; break;
                case "Среднее массовое содержание воды": delitel = 3; break;
                case "Объём при 20С": delitel = 1; break;
                case "Масса нефти при 20С": delitel = 1; break;
                default: delitel = 3; break;

            }
            return delitel;
        }


        /// <summary>
        /// Получить единицы измерения по названию параметра
        /// </summary>
        /// <param name="param_name"></param>
        /// <returns></returns>
        private string GetUnitOfMeasurementsByPrameterName(string param_name)
        {
            string ret_val = string.Empty;
            switch (param_name)
            {
                case "Средний расход": ret_val = "м3/ч"; break;
                case "Средняя температура": ret_val = "С"; break;
                case "Среднее давление": ret_val = "кПа"; break;
                case "Средняя плотность": ret_val = "кг/м3"; break;
                case "Средняя плотность при 20С": ret_val = "кг/м3"; break;
                case "Среднее объёмное содержание воды": ret_val = "%"; break;
                case "Среднее массовое содержание воды": ret_val = "%"; break;
                case "Объём при 20С": ret_val = "м3"; break;
                case "Масса нефти при 20С": ret_val = "т"; break;

                case "Температура": ret_val = "С"; break;
                case "Давление": ret_val = "кПа"; break;
                case "Плотность": ret_val = "кг/м3"; break;
                case "Плотность при 20С": ret_val = "кг/м3"; break;
                case "Массовая доля воды": ret_val = "%"; break;
                case "Массовая доля мех. примесей": ret_val = "%"; break;
                case "Массовая доля серы": ret_val = "%"; break;
                case "Массовая доля парафина": ret_val = "%"; break;
                case "Массовая доля сероводорода": ret_val = "ppm"; break;

                default: break;



            }
            return ret_val;
        }


        /// <summary>
        /// настройка отображения панелей с элементами управления/просмотра  статисткой
        /// </summary>
        /// <param name="chartPanel"></param>
        /// <param name="statPanel"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        private void ShowPanels(bool chartPanel, bool statPanel)
        {

            if (chartPanel)
            {
                // показываем панель графика
                // прячем панель графика
                var control = tlpMain.GetControlFromPosition(2, 1);
                if (control != null)
                {
                    tlpMain.Controls.Remove(control);
                }
                tlpMain.Controls.Add(tlpChart, 2, 1);
            }
            else
            {
                // прячем панель графика
                var control = tlpMain.GetControlFromPosition(2, 1);
                if (control != null)
                {
                    tlpMain.Controls.Remove(control);
                }

            }
        }

       
        /// <summary>
        /// Показать список дат с отчетами
        /// </summary>
        private void ShowReportDatesList()
        {
            if (!nodeDataSet.Tables.Contains($"{node}_reports"))
            {
                MessageBox.Show($"Таблица статистики {node}_reports не существует!");
                return;
            }

            // формируем список событий форма  События-дата
            List<StringValue> reports_date_list = new List<StringValue>();
            List<string> dates = new List<string>();
            for (int i = 0; i < nodeDataSet.Tables[$"{node}_reports"].Rows.Count; i++)
            {
                var date = ((DateTime)nodeDataSet.Tables[$"{node}_reports"].Rows[i]["Время"]).ToShortDateString();
                if (dates.Contains(date))
                {
                    continue;
                }
                dates.Add(date);
                reports_date_list.Add(new StringValue(date));
            }

            ReportListControl report_list_control = new ReportListControl(reports_date_list, "Отчеты");
            tlpMain.Controls.Add(report_list_control, 2, 1);
            report_list_control.Dock = DockStyle.Fill;
            report_list_control.BorderStyle = BorderStyle.FixedSingle;
            report_list_control.ListItemClicked += Dates_list_control_ListItemClicked;
            report_list_control.ListItemDelete += Report_list_control_ListItemDelete;
        }


        /// <summary>
        /// обработчик события клика по конкретной дате в списке отчетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dates_list_control_ListItemClicked(object sender, EventArgs e)
        {
            var date = ((ReportItemClickEventArgs)e).ClickedItemCaption;
            if (currentMenuItem == CurrentMenuItem.EVENTS)
            {
                ShowPanels(false, true);
                ShowEventsPerDate(date);
            }
            else if (currentMenuItem == CurrentMenuItem.CRITICAL_EVENTS)
            {
                ShowPanels(false, true);
                ShowCriticalEventsPerDate(date);
            }
            else if (currentMenuItem == CurrentMenuItem.HOUR_REPORT)
            {
                ShowPanels(false, true);
                //показываем часовые отчеты за сутки (список часов)
                ShowHourReportsListPerDate(date);
            }
            else if (currentMenuItem == CurrentMenuItem.DAY_REPORT)
            {
                ShowPanels(false, true);
                // показываем суточный отчет
                ShowDayReport(date);
            }
            else if (currentMenuItem == CurrentMenuItem.PERIOD_REPORT)
            {
                ShowPeriodReport(date);
            }
            else if (currentMenuItem == CurrentMenuItem.KMX_TEMPERATURE)
            {
                //показываем протокол КМХ датчиков температуры за указанную дату
                ShowKMXTemperatureProtocol(date);
            }
            else if (currentMenuItem == CurrentMenuItem.KMX_PRESSURE)
            {
                //показываем протокол КМХ преобразователей давления за указанную дату
                ShowKMXPressureProtocol(date);
            }
            else if (currentMenuItem == CurrentMenuItem.KMX_DENSITY)
            {
                //показываем протокол КМХ плотномеров по ареометру 
                ShowKMXDensityProtocol(date);
            }
            else if (currentMenuItem == CurrentMenuItem.SUPPLIER_1)
            {
                ShowPanels(false, true);
                //показываем протокол КМХ плотномеров по ареометру 
                ShowOilQuailtyPassport(date, btnSupplier1.Text);
            }
            else if (currentMenuItem == CurrentMenuItem.SUPPLIER_2)
            {
                ShowPanels(false, true);
                //показываем протокол КМХ плотномеров по ареометру 
                ShowOilQuailtyPassport(date, btnSupplier2.Text);
            }
            else if (currentMenuItem == CurrentMenuItem.SUPPLIER_3)
            {
                ShowPanels(false, true);
                //показываем протокол КМХ плотномеров по ареометру 
                ShowOilQuailtyPassport(date, btnSupplier3.Text);
            }

        }

        /// <summary>
        /// показать данные паспорта качества нефти выбранного поставщика за указанную дату
        /// </summary>
        /// <param name="date"></param>
        /// <param name="v"></param>
        private void ShowOilQuailtyPassport(string date, string supplier_name)
        {
            string table_name = $"{node}_oil_quality_passport";
            DataRow[] supplier_passport_rows = nodeDataSet.Tables[table_name].Select($"[Время] = '{date}' and [Поставщик] = '{supplier_name}'");

            var passport_number = supplier_passport_rows[0]["Номер паспорта"].ToString();

            //формируем таблицу часового отчета
            DataTable dt = new DataTable("oil_quality_passport");
            dt.Columns.Add("№", Type.GetType("System.Int32"));
            dt.Columns.Add("Наименование показателя", Type.GetType("System.String"));
            dt.Columns.Add("Един. Измерения", Type.GetType("System.String"));
            dt.Columns.Add("Результат", Type.GetType("System.Double"));

            // заполняем таблицу данными
            for (int i = 4; i < nodeDataSet.Tables[table_name].Columns.Count; i++)
            {
                DataRow dr = dt.NewRow();
                var column = nodeDataSet.Tables[table_name].Columns[i].ColumnName;
                dr[0] = i - 3;
                dr[1] = column;
                dr[2] = GetUnitOfMeasurementsByPrameterName(column);
                dr[3] = supplier_passport_rows[0][column];
                dt.Rows.Add(dr);
            }

            //прячем другие панели статистики показываем только 5-ю панель
            ShowPanels(false, true);
            // открываем microsoft word и показываем заполненный шаблон часового отчета
            ReportTableControl report_table_control = new ReportTableControl(dt, $"Паспорт качества нефти [{supplier_name}] №{passport_number} ", $"от {date}");
            tlpMain.Controls.Add(report_table_control, 2, 1);
            report_table_control.Dock = DockStyle.Fill;
        }


        /// <summary>
        /// показываем протокол КМХ плотномеров по ареометру за указанную дату
        /// </summary>
        /// <param name="date"></param>
        private void ShowKMXDensityProtocol(string date)
        {
            string table_name = $"{node}_kmx_density";
            double density_sensor_limit = 0.3; // лимит годности плотномера по ареометру
            DataRow[] kmx_density_rows = nodeDataSet.Tables[table_name].Select($"[CheckTime] = '{date}'");

            //отображаемая таблица протокола
            DataTable dt = new DataTable("kmx_temparature");
            dt.Columns.Add("№ измерения", typeof(string));
            dt.Columns.Add("Температура", typeof(string));
            dt.Columns.Add("Давление", typeof(string));
            dt.Columns.Add("Плотность при условиях", typeof(string));
            dt.Columns.Add("Плотность при 20С", typeof(string));
            dt.Columns.Add("Плотность при условиях (лаб.)", typeof(string));
            dt.Columns.Add("Плотность при 20С (лаб.)", typeof(string));
            dt.Columns.Add("Разность давления при условиях", typeof(string));
            dt.Columns.Add("Разность давления при 20С", typeof(string));

            var items = new Dictionary<string, string>();
            items.Add("<NodeName>", this.node_caption);
            items.Add("<kmx_date>", date);


            var plotnomer_state = "годен";

            for (int i = 0; i < kmx_density_rows.Length; i++)
            {

                var mesuarementID = kmx_density_rows[i]["MeasurementNumber"].ToString();
                var temperature = kmx_density_rows[i]["Temperature"].ToString();
                var pressure = kmx_density_rows[i]["Pressure"].ToString();
                double densityAtConditions = Convert.ToDouble(kmx_density_rows[i]["DensityAtConditions"]);
                double densityAt20C = Convert.ToDouble(kmx_density_rows[i]["DensityAt20C"]);
                double densityAtConditionsLab = Convert.ToDouble(kmx_density_rows[i]["DensityAtConditionsLab"]);
                double densityAt20CLab = Convert.ToDouble(kmx_density_rows[i]["DensityAt20CLab"]);
                double differenceInDensityAtConditions = Convert.ToDouble(kmx_density_rows[i]["DifferenceInDensityAtConditions"]);
                double densityDifferenceAt20C = Convert.ToDouble(kmx_density_rows[i]["DensityDifferenceAt20C"]);

                string protocolNumber = kmx_density_rows[i]["ProtocolNumber"].ToString();
                DictionaryAdd(ref items, $"<ProtocolNumber>", protocolNumber);

                DictionaryAdd(ref items, $"<M{mesuarementID}T20>", densityAt20C.ToString());
                DictionaryAdd(ref items, $"<T{mesuarementID}>", temperature);
                DictionaryAdd(ref items, $"<P{mesuarementID}>", temperature);
                DictionaryAdd(ref items, $"<M{mesuarementID}C>", densityAtConditions.ToString());
                DictionaryAdd(ref items, $"<M{mesuarementID}CL>", densityAtConditionsLab.ToString());
                DictionaryAdd(ref items, $"<M{mesuarementID}T20L>", densityAt20CLab.ToString());
                DictionaryAdd(ref items, $"<D{mesuarementID}>", differenceInDensityAtConditions.ToString());
                DictionaryAdd(ref items, $"<D{mesuarementID}T20>", densityDifferenceAt20C.ToString());



                if (Math.Abs(differenceInDensityAtConditions) > density_sensor_limit || Math.Abs(densityDifferenceAt20C) > density_sensor_limit)
                {
                    plotnomer_state = "не годен";
                }

                DataRow row = dt.NewRow();
                row["№ измерения"] = mesuarementID;
                row["Температура"] = temperature;
                row["Давление"] = pressure;
                row["Плотность при условиях"] = densityAtConditions;
                row["Плотность при 20С"] = densityAt20C;
                row["Плотность при условиях (лаб.)"] = densityAtConditionsLab;
                row["Плотность при 20С (лаб.)"] = densityAt20CLab;
                row["Разность давления при условиях"] = differenceInDensityAtConditions;
                row["Разность давления при 20С"] = densityDifferenceAt20C;

                dt.Rows.Add(row);

            }

            DictionaryAdd(ref items, $"<P_S>", plotnomer_state);


            // тут показываем контрол протокола

            ShowPanels(false, true);
            // открываем microsoft word и показываем заполненный шаблон часового отчета
            ProtocolKMXTableControl protocol_table_control = new ProtocolKMXTableControl(dt, items, @"templates\kmx_density_protocol.docx", $"КМХ плотномеров по ареометру {items["<NodeName>"]}", ProtocolType.DENSITY);
            tlpMain.Controls.Add(protocol_table_control, 2, 1);
            protocol_table_control.Dock = DockStyle.Fill;





        }


        /// <summary>
        /// показать протокол КМХ преобразователей давления за указанную дату
        /// </summary>
        /// <param name="date"></param>
        private void ShowKMXPressureProtocol(string date)
        {
            string table_name = $"{node}_kmx_pressure";
            double pressure_sensor_limit = 0.075; // лимит годности плотномера по ареометру
            DataRow[] kmx_pressure_rows = nodeDataSet.Tables[table_name].Select($"[CheckTime] = '{date}'");

            //отображаемая таблица протокола
            DataTable dt = new DataTable("kmx_temparature");
            dt.Columns.Add("Линия", typeof(string));
            dt.Columns.Add("Датчик А", typeof(string));
            dt.Columns.Add("Датчик Б", typeof(string));
            dt.Columns.Add("Контр. СИ", typeof(string));
            dt.Columns.Add("Разность", typeof(string));



            var items = new Dictionary<string, string>();
            DictionaryAdd(ref items, "<NodeName>", this.node_caption);
            DictionaryAdd(ref items, "<kmx_date>", date);

            for (int i = 0; i < kmx_pressure_rows.Length; i++)
            {
                var lineID = kmx_pressure_rows[i]["LineID"].ToString();

                double sensorA = Convert.ToDouble(kmx_pressure_rows[i]["SensorA"]);
                double sensorB = Convert.ToDouble(kmx_pressure_rows[i]["SensorB"]);
                double contr_SI = Convert.ToDouble(kmx_pressure_rows[i]["ContrSI"]);
                double diff_A = sensorA - contr_SI;
                double diff_B = sensorB - contr_SI;
                string protocolNumber = kmx_pressure_rows[i]["ProtocolNumber"].ToString();
                DictionaryAdd(ref items, $"<ProtocolNumber>", protocolNumber);

                DictionaryAdd(ref items, $"<A{lineID}>", sensorA.ToString());
                DictionaryAdd(ref items, $"<B{lineID}>", sensorB.ToString());
                DictionaryAdd(ref items, $"<SI{lineID}>", contr_SI.ToString());
                DictionaryAdd(ref items, $"<D{lineID}>", kmx_pressure_rows[i]["Difference"].ToString());

                if (Math.Abs(diff_A) > pressure_sensor_limit)
                {
                    DictionaryAdd(ref items, $"<A{lineID}_S>", "не годен");
                }
                else
                {
                    DictionaryAdd(ref items, $"<A{lineID}_S>", "годен");
                }

                if (Math.Abs(diff_B) > pressure_sensor_limit)
                {
                    DictionaryAdd(ref items, $"<B{lineID}_S>", "не годен");
                }
                else
                {
                    DictionaryAdd(ref items, $"<B{lineID}_S>", "годен");
                }
                DataRow row = dt.NewRow();
                row["Линия"] = lineID;
                row["Датчик А"] = sensorA.ToString();
                row["Датчик Б"] = sensorB.ToString();
                row["Контр. СИ"] = contr_SI.ToString();
                row["Разность"] = kmx_pressure_rows[i]["Difference"].ToString();
                dt.Rows.Add(row);

            }

            // тут показываем контрол протокола

            ShowPanels(false, true);
            // открываем microsoft word и показываем заполненный шаблон часового отчета
            ProtocolKMXTableControl protocol_table_control = new ProtocolKMXTableControl(dt, items, @"templates\kmx_pressure_protocol.docx", $"КМХ преобразователей давления {items["<NodeName>"]}", ProtocolType.PRESSURE);
            tlpMain.Controls.Add(protocol_table_control, 2, 1);
            protocol_table_control.Dock = DockStyle.Fill;
        }



        /// <summary>
        /// показать протокол КМХ датчиков температуры за указанную дату
        /// </summary>
        /// <param name="date"></param>
        private void ShowKMXTemperatureProtocol(string date)
        {
            string table_name = $"{node}_kmx_temperature";
            double temperature_sensor_limit = 0.16; // лимит годности датчика
            DataRow[] kmx_temperature_rows = nodeDataSet.Tables[table_name].Select($"[CheckTime] = '{date}'");
            //отображаемая таблица протокола
            DataTable dt = new DataTable("kmx_temparature");
            dt.Columns.Add("Линия", typeof(string));
            dt.Columns.Add("Датчик А", typeof(string));
            dt.Columns.Add("Датчик Б", typeof(string));
            dt.Columns.Add("Контр. СИ", typeof(string));
            dt.Columns.Add("Разность", typeof(string));

            var items = new Dictionary<string, string>();
            DictionaryAdd(ref items, "<NodeName>", this.node_caption);
            DictionaryAdd(ref items, "<kmx_date>", date);

            for (int i = 0; i < kmx_temperature_rows.Length; i++)
            {

                var lineID = kmx_temperature_rows[i]["LineID"].ToString();

                string protocolNumber = kmx_temperature_rows[i]["ProtocolNumber"].ToString();
                DictionaryAdd(ref items, $"<ProtocolNumber>", protocolNumber);

                double sensorA = Convert.ToDouble(kmx_temperature_rows[i]["SensorA"]);
                double sensorB = Convert.ToDouble(kmx_temperature_rows[i]["SensorB"]);
                double contr_SI = Convert.ToDouble(kmx_temperature_rows[i]["ContrSI"]);
                double diff_A = sensorA - contr_SI;
                double diff_B = sensorB - contr_SI;


                DictionaryAdd(ref items, $"<A{lineID}>", sensorA.ToString());
                DictionaryAdd(ref items, $"<B{lineID}>", sensorB.ToString());
                DictionaryAdd(ref items, $"<SI{lineID}>", contr_SI.ToString());
                DictionaryAdd(ref items, $"<D{lineID}>", kmx_temperature_rows[i]["Difference"].ToString());

                if (Math.Abs(diff_A) > temperature_sensor_limit)
                {
                    DictionaryAdd(ref items, $"<A{lineID}_S>", "не годен");
                }
                else
                {
                    DictionaryAdd(ref items, $"<A{lineID}_S>", "годен");
                }

                if (Math.Abs(diff_B) > temperature_sensor_limit)
                {
                    DictionaryAdd(ref items, $"<B{lineID}_S>", "не годен");
                }
                else
                {
                    DictionaryAdd(ref items, $"<B{lineID}_S>", "годен");
                }


                DataRow row = dt.NewRow();
                row["Линия"] = lineID;
                row["Датчик А"] = sensorA.ToString();
                row["Датчик Б"] = sensorB.ToString();
                row["Контр. СИ"] = contr_SI.ToString();
                row["Разность"] = kmx_temperature_rows[i]["Difference"].ToString();
                dt.Rows.Add(row);

            }

            // тут показываем контрол протокола

            ShowPanels(false, true);
            // открываем microsoft word и показываем заполненный шаблон часового отчета
            ProtocolKMXTableControl protocol_table_control = new ProtocolKMXTableControl(dt, items, @"templates\kmx_temperature_protocol.docx", $"КМХ датчиков температуры {items["<NodeName>"]}", ProtocolType.TEMPERATURE);
            tlpMain.Controls.Add(protocol_table_control, 2, 1);
            protocol_table_control.Dock = DockStyle.Fill;


        }


        /// <summary>
        /// добавить в словарь ключ, значние
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        private void DictionaryAdd(ref Dictionary<string, string> dict, string key, string val)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, val);
            }
        }


        /// <summary>
        /// показать суточный отчет
        /// </summary>
        /// <param name="date"></param>
        private void ShowDayReport(string report_date)
        {

            //выборка данных конкретногго-часового отчета
            DataRow[] line1_hour_reports_rows = nodeDataSet.Tables[$"{node}_reports"].Select($"[Время] >= '{report_date} 00:00:00' and  [Время] < '{report_date} 23:59:59' and [Линия]=1");
            DataRow[] line2_hour_reports_rows = nodeDataSet.Tables[$"{node}_reports"].Select($"[Время] >= '{report_date} 00:00:00' and  [Время] < '{report_date} 23:59:59' and [Линия]=2");
            DataRow[] line3_hour_reports_rows = nodeDataSet.Tables[$"{node}_reports"].Select($"[Время] >= '{report_date} 00:00:00' and  [Время] < '{report_date} 23:59:59' and [Линия]=3");

            //прячем другие панели статистики показываем только 2-ю панель
            ShowPanels(false, true);
            //формируем таблицу часового отчета
            DataTable dt = new DataTable("day_report");
            dt.Columns.Add("Показатели", Type.GetType("System.String"));
            dt.Columns.Add("Един. Измер.", Type.GetType("System.String"));
            dt.Columns.Add("Линия1", Type.GetType("System.Double"));
            dt.Columns.Add("Линия2", Type.GetType("System.Double"));
            dt.Columns.Add("Линия3", Type.GetType("System.Double"));
            dt.Columns.Add("БИЛ", Type.GetType("System.Double"));


            // суммируем данные всех часовых отчетов за выбранные сутки
            double[] line1_params = new double[9];
            double[] line2_params = new double[9];
            double[] line3_params = new double[9];

            SumLineParams(ref line1_hour_reports_rows, ref line1_params);
            SumLineParams(ref line2_hour_reports_rows, ref line2_params);
            SumLineParams(ref line3_hour_reports_rows, ref line3_params);

            // заполняем таблицу данными
            for (int i = 3; i < nodeDataSet.Tables[$"{node}_reports"].Columns.Count; i++)
            {
                DataRow dr = dt.NewRow();
                var column = nodeDataSet.Tables[$"{node}_reports"].Columns[i].ColumnName;
                dr[0] = column;
                dr[1] = GetUnitOfMeasurementsByPrameterName(column);
                dr[2] = line1_params[i - 3];
                dr[3] = line2_params[i - 3];
                dr[4] = line3_params[i - 3];
                dr[5] = Math.Round((Convert.ToDouble(dr[2]) + Convert.ToDouble(dr[3]) + Convert.ToDouble(dr[4])) / GetDelitelByParameterName(column), 2); // округляем до 2 знаков после запятой
                dt.Rows.Add(dr);
            }

            // открываем microsoft word и показываем заполненный шаблон часового отчета
            ReportTableControl report_table_control = new ReportTableControl(dt, $"Суточный отчет ({report_date})", $"00:00-23:59");
            tlpMain.Controls.Add(report_table_control, 2, 1);
            report_table_control.Dock = DockStyle.Fill;

        }


        /// <summary>
        /// суммировать параметры линии
        /// </summary>
        /// <param name="line_hour_reports_rows"></param>
        /// <param name="line_params"></param>
        private void SumLineParams(ref DataRow[] line_hour_reports_rows, ref double[] line_params)
        {
            for (int i = 0; i < line_hour_reports_rows.Length; i++)
            {
                for (int p = 0; p < line_params.Length; p++)
                {
                    line_params[p] += Convert.ToDouble(line_hour_reports_rows[i][3 + p]);
                }
            }

            for (int i = 0; i < line_params.Length; i++)
            {
                if (i == 0 || i == line_params.Length - 1 || i == line_params.Length - 2)// эти параметры просто суммируем
                {
                    continue;
                }

                line_params[i] = Math.Round(line_params[i] / line_hour_reports_rows.Length, 2); // находим среднее значение и округляем
            }

        }

        /// <summary>
        /// обработчик события клика по элементу управления отчета за период
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeriodReport_Click(object sender, EventArgs e)
        {
            currentMenuItem = CurrentMenuItem.PERIOD_REPORT;
            ShowCurrentPanel();

        }

        /// <summary>
        /// показать отчеты за период
        /// </summary>
        private void ShowPeriodReports()
        {
            if (!nodeDataSet.Tables.Contains($"{node}_reports_period"))
            {
                MessageBox.Show($"Таблица статистики {node}_reports_period не существует!");
                return;
            }

            lbCurrentOilParameter.Text = "Отчеты по партиям";

            // формируем список событий форма  События-дата
            List<StringValue> reports_periods_list = new List<StringValue>();
            List<string> periods = new List<string>();
            for (int i = 0; i < nodeDataSet.Tables[$"{node}_reports_period"].Rows.Count; i++)
            {
                var start_date = ((DateTime)nodeDataSet.Tables[$"{node}_reports_period"].Rows[i]["StartTime"]).ToShortDateString();
                var end_date = ((DateTime)nodeDataSet.Tables[$"{node}_reports_period"].Rows[i]["EndTime"]).ToShortDateString();
                var period = $"{start_date}-{end_date}";

                if (periods.Contains(period))
                {
                    continue;
                }
                periods.Add(period);
                reports_periods_list.Add(new StringValue(period));
            }


            ReportListControl report_list_control = new ReportListControl(reports_periods_list, "Отчеты за период");
            tlpMain.Controls.Add(report_list_control, 2, 1);
            report_list_control.Dock = DockStyle.Fill;
            report_list_control.ListItemClicked += Dates_list_control_ListItemClicked;
            report_list_control.ListItemDelete += Report_list_control_ListItemDelete;
        }

        /// <summary>
        /// удалить отчет/протокол/паспорт за указанную дату
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Report_list_control_ListItemDelete(object sender, EventArgs e)
        {
            var date = ((ReportItemClickEventArgs)e).ClickedItemCaption;


            date = CorrectDateToSQLDBFormat(date); // корректируем дату 'dd.MM.yyyy' ->  'yyy-MM-dd'

            bool delete_result = false;

            string report_type = "Отчет";

            if (currentMenuItem == CurrentMenuItem.EVENTS)
            {
                delete_result = DB.ExecuteSQLCommand($"DELETE FROM [{node}_events] WHERE [Время] >= '{date} 00:00:00' and [Время] <='{date} 23:59:59'");
                report_type = "Журнал";
            }
            else if (currentMenuItem == CurrentMenuItem.CRITICAL_EVENTS)
            {
                delete_result = DB.ExecuteSQLCommand($"DELETE FROM [{node}_critical_events] WHERE [Время] >= '{date} 00:00:00' and [Время] <='{date} 23:59:59'");
                report_type = "Журнал";
            }
            else if (currentMenuItem == CurrentMenuItem.HOUR_REPORT || currentMenuItem == CurrentMenuItem.DAY_REPORT)
            {
                delete_result = DB.ExecuteSQLCommand($"DELETE FROM [{node}_reports] WHERE [Время] >= '{date} 00:00:00' and [Время] <='{date} 23:59:59'");
            }
            else if (currentMenuItem == CurrentMenuItem.PERIOD_REPORT)
            {
                var start_date = CorrectDateToSQLDBFormat(date.Split('-')[0]);
                var end_date = CorrectDateToSQLDBFormat(date.Split('-')[1]);
                delete_result = DB.ExecuteSQLCommand($"DELETE FROM [{node}_reports_period] WHERE [StartTime] = '{start_date}' and [EndTime] ='{end_date}'");
            }
            else if (currentMenuItem == CurrentMenuItem.KMX_TEMPERATURE)
            {
                delete_result = DB.ExecuteSQLCommand($"DELETE FROM [{node}_kmx_temperature] WHERE [CheckTime] = '{date}'");
                report_type = "Протокол";
            }
            else if (currentMenuItem == CurrentMenuItem.KMX_PRESSURE)
            {
                delete_result = DB.ExecuteSQLCommand($"DELETE FROM [{node}_kmx_pressure] WHERE [CheckTime] = '{date}'");
                report_type = "Протокол";

            }
            else if (currentMenuItem == CurrentMenuItem.KMX_DENSITY)
            {
                delete_result = DB.ExecuteSQLCommand($"DELETE FROM [{node}_kmx_density] WHERE [CheckTime] = '{date}'");
                report_type = "Протокол";

            }
            else if (currentMenuItem == CurrentMenuItem.SUPPLIER_1)
            {
                delete_result = DB.ExecuteSQLCommand($"DELETE FROM [{node}_oil_quality_passport] WHERE [Время] = '{date}' and [Поставщик] = '«Поставщик №1»'");
                report_type = "Паспорт качества нефти";

            }
            else if (currentMenuItem == CurrentMenuItem.SUPPLIER_2)
            {
                delete_result = DB.ExecuteSQLCommand($"DELETE FROM [{node}_oil_quality_passport] WHERE [Время] = '{date}' and [Поставщик] = '«Поставщик №2»'");
                report_type = "Паспорт качества нефти";

            }
            else if (currentMenuItem == CurrentMenuItem.SUPPLIER_3)
            {
                delete_result = DB.ExecuteSQLCommand($"DELETE FROM [{node}_oil_quality_passport] WHERE [Время] = '{date}' and [Поставщик] = '«Поставщик №3»'");
                report_type = "Паспорт качества нефти";

            }


            if (delete_result)
            {
                MessageBox.Show($"{report_type} за '{date}' удален.");
                logger.WriteToStatLog($"{report_type} за '{date}' удален.");

                if (!bwDataSetLoader.IsBusy)
                {
                    bwDataSetLoader.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show($"При удалении отчета возникла ошибка. Смотри лог ошибок.");
            }

        }

        /// <summary>
        /// изменить формат даты 'yyyy-MM-dd'
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private string CorrectDateToSQLDBFormat(string date)
        {

            if (date.Contains("."))
            {
                string[] items = date.Split('.');
                if (items.Length == 3)
                {
                    date = $"{items[2]}-{items[1]}-{items[0]}";
                }
            }

            return date;
        }



        /// <summary>
        /// показать список дат пасспортов качества конкретного поставщика
        /// </summary>
        /// <param name="supplier"></param>
        private void ShowSupplierPassportDateList(string supplier)
        {
            string table_name = $"{node}_oil_quality_passport";
            if (!nodeDataSet.Tables.Contains(table_name))
            {
                MessageBox.Show($"Таблица статистики '{table_name}' не существует!");
                return;
            }

            List<StringValue> reports_date_list = new List<StringValue>();
            List<string> dates = new List<string>();
            for (int i = 0; i < nodeDataSet.Tables[table_name].Rows.Count; i++)
            {
                var date = ((DateTime)nodeDataSet.Tables[table_name].Rows[i]["Время"]).ToShortDateString();
                var cur_supplier = nodeDataSet.Tables[table_name].Rows[i]["Поставщик"].ToString();

                if (dates.Contains(date) || !cur_supplier.Contains(supplier))
                {
                    continue;
                }
                dates.Add(date);
                reports_date_list.Add(new StringValue(date));
            }

            ReportListControl report_list_control = new ReportListControl(reports_date_list, $"Паспорта качества [{supplier}]");
            tlpMain.Controls.Add(report_list_control, 2, 1);
            report_list_control.Dock = DockStyle.Fill;
            report_list_control.ListItemClicked += Dates_list_control_ListItemClicked;
            report_list_control.ListItemDelete += Report_list_control_ListItemDelete;
        }


        Point? prevPosition = null;



        /// <summary>
        /// обработчик события движения мыши над графиком выбранного параметра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {

            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around)
                        if (Math.Abs(pos.X - pointXPixel) < 10 && Math.Abs(pos.Y - pointYPixel) < 50)
                        {
                            tooltip.Show($"{lbCurrentOilParameter.Text} :" + prop.YValues[0], this.chart1,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }


            /// <summary>
            /// Показать список дат с протоколами КМХ датчиков температуры
            /// </summary>
            private void ShowKmxTempDatesList()
            {

                string table_name = $"{node}_kmx_temperature";
                if (!nodeDataSet.Tables.Contains(table_name))
                {
                    MessageBox.Show($"Таблица статистики '{table_name}' не существует!");
                    return;
                }

                lbCurrentOilParameter.Text = "Протоколы КМХ датчиков температуры по датам";

                // формируем список событий форма  События-дата
                List<StringValue> reports_date_list = new List<StringValue>();
                List<string> dates = new List<string>();
                for (int i = 0; i < nodeDataSet.Tables[table_name].Rows.Count; i++)
                {
                    var date = ((DateTime)nodeDataSet.Tables[table_name].Rows[i]["CheckTime"]).ToShortDateString();
                    if (dates.Contains(date))
                    {
                        continue;
                    }
                    dates.Add(date);
                    reports_date_list.Add(new StringValue(date));
                }


                ReportListControl report_list_control = new ReportListControl(reports_date_list, "Протоколы КМХ датчиков температуры");
                tlpMain.Controls.Add(report_list_control, 2, 1);
                report_list_control.Dock = DockStyle.Fill;
                report_list_control.ListItemClicked += Dates_list_control_ListItemClicked;
                report_list_control.ListItemDelete += Report_list_control_ListItemDelete;
            }


        /// <summary>
        /// установить цвет кнопок параметров в значения по умолчанию
        /// </summary>
        private void SetParametersButtonDefaultColors()
        {
            this.btnPressure.BackColor = Color.Gray;
            this.btnTemperature.BackColor = Color.Gray;
            this.btnDensity.BackColor = Color.Gray;
            this.btnDensity20C.BackColor = Color.Gray;
        }
        /// <summary>
        /// установить цвет кнопок поставщиков в значения по умолчанию
        /// </summary>
        private void SetSuppliersButtonDefaultColors()
        {
            this.btnSupplier1.BackColor = Color.DarkGray;
            this.btnSupplier2.BackColor = Color.DarkGray;
            this.btnSupplier3.BackColor = Color.DarkGray;
        }

        /// <summary>
        /// обработчик события выбора конкретного параметра контроля нефти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParameter_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            lbCurrentOilParameter.Text = btn.Text;
            SetParametersButtonDefaultColors();
            SetSuppliersButtonDefaultColors();
            btn.BackColor = Color .DimGray;
            chart1.Show();
            ShowChartStat();
            ShowPanels(true, false);
        }

        /// <summary>
        /// обработчик события выбора конкретного поставщика нефти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            SetSuppliersButtonDefaultColors();
            SetParametersButtonDefaultColors();
            btn.BackColor = Color.Gray;

            string supplier = ((Button)sender).Tag.ToString();

            switch (supplier)
            {
                case "supplier1": currentMenuItem = CurrentMenuItem.SUPPLIER_1; break;
                case "supplier2": currentMenuItem = CurrentMenuItem.SUPPLIER_2; break;
                case "supplier3": currentMenuItem = CurrentMenuItem.SUPPLIER_3; break;
                default: MessageBox.Show("Поставщик не определен."); break;
            }
            ShowCurrentPanel();
        }

        /// <summary>
        /// обработчик клика по элементу выбора верменного периода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetupTimePeriod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SetupTimePeriodForm setup_form = new SetupTimePeriodForm(linkLabelTimePeriod.Text.Replace("Диапазон дат: ", "")))
            {
                if (setup_form.ShowDialog() == DialogResult.OK)
                {
                    linkLabelTimePeriod.Text = $"Диапазон дат: {setup_form.StartTime}-{setup_form.EndTime}";
                    ShowChartStat();
                }
            }
        }

        /// <summary>
        /// обработчик события клика по кнопке часовых отчетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHourReport_Click(object sender, EventArgs e)
        {
            currentMenuItem = CurrentMenuItem.HOUR_REPORT;
            ShowCurrentPanel();
        }

        /// <summary>
        /// обработчик события клика по кнопке суточных отчетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDayReport_Click(object sender, EventArgs e)
        {
            currentMenuItem = CurrentMenuItem.DAY_REPORT;
            ShowCurrentPanel();
        }

        /// <summary>
        /// обработчик события клика по кнопке отчетов за период
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPeriodReport_Click(object sender, EventArgs e)
        {
            currentMenuItem = CurrentMenuItem.PERIOD_REPORT;
            ShowCurrentPanel();
        }

        /// <summary>
        /// обработчик события клика по кнопке протокола КМХ по температуре
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKMXTemperature_Click(object sender, EventArgs e)
        {
            currentMenuItem = CurrentMenuItem.KMX_TEMPERATURE;
            ShowCurrentPanel();
        }
        /// <summary>
        /// обработчик события клика по кнопке протокола КМХ по давлению
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKMXPressure_Click(object sender, EventArgs e)
        {
            currentMenuItem = CurrentMenuItem.KMX_PRESSURE;
            ShowCurrentPanel();
        }

        /// <summary>
        /// обработчик события клика по кнопке протокола КМХ по плотности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKMXDensity_Click(object sender, EventArgs e)
        {
            currentMenuItem = CurrentMenuItem.KMX_DENSITY;
            ShowCurrentPanel();
        }


        /// <summary>
        /// обработчик события клика по кнопке штатных событий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEvents_Click(object sender, EventArgs e)
        {
            currentMenuItem = CurrentMenuItem.EVENTS;
            ShowCurrentPanel();
        }

        /// <summary>
        /// обработчик события клика по кнопке критических событий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCriticalEvents_Click(object sender, EventArgs e)
        {
            currentMenuItem = CurrentMenuItem.CRITICAL_EVENTS;
            ShowCurrentPanel();
        }


     
    }


    /// <summary>
    /// ТЕКУЩИЙ ПУНКТ МЕНЮ
    /// </summary>
    enum CurrentMenuItem { NONE = 1, HOUR_REPORT, DAY_REPORT, PERIOD_REPORT, EVENTS, CRITICAL_EVENTS, KMX_TEMPERATURE, KMX_PRESSURE, KMX_DENSITY, SUPPLIER_1, SUPPLIER_2, SUPPLIER_3 };


}



