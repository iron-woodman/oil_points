using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using oil_points.WorkClasses;

namespace oil_points.MyControls
{
    /// <summary>
    /// контрол отображения отчета за период
    /// </summary>
    public partial class PeriodReportTableControl : UserControl
    {
        private Dictionary<string, string> items = new Dictionary<string, string>();
        private string word_template_path;

        public PeriodReportTableControl(Dictionary<string, string> items, string word_template_path)
        {
            InitializeComponent();
            this.word_template_path = word_template_path;
            this.items = items;

            DataTable report_dt = new DataTable();
            report_dt.Columns.Add("Параметр", typeof(string));
            report_dt.Columns.Add("Значение", typeof(string));

            DataRow row = report_dt.NewRow();
            row[0] = "Пункт приема нефти:";
            row[1] = items["<NodeName>"];
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Предприятие (владелец):";
            row[1] = items["<EnterpriseOwner>"];
            report_dt.Rows.Add(row);
            
            row = report_dt.NewRow();
            row[0] = "Предприятие (транспортировщик):";
            row[1] = items["<EnterpriseTransporter>"];
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Начало формирования партии:";
            row[1] = items["<StartTime>"];
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Окончание формирования партии:";
            row[1] = items["<EndTime>"];
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "";
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Показания приборов СИКН:";
            report_dt.Rows.Add(row);


            row = report_dt.NewRow();
            row[0] = "№ паспорта качества нефти";
            row[1] = items["<QualityPassportNumber>"];
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Масса нефти брутто";
            row[1] = items["<OilGrossMass>"] + " т";
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Средняя температура";
            row[1] = items["<AverageTemperature>"] + " °С";
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Среднее давление";
            row[1] = items["<AveragePressure>"] + " МПа";
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Средняя плотность нефти при условиях измерений";
            row[1] = items["<AverageDensityMeasurementConditions>"] + " кг/м3";
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Средняя плотность нефти при 20°С";
            row[1] = items["<AverageDensity20Degrees>"] + " кг/м3";
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Массовая доля балласта:";
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Воды";
            row[1] = items["<Water>"] + " %";
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Мех. Примесей";
            row[1] = items["<MechanicalImpurities>"] + " %";
            report_dt.Rows.Add(row);


            row = report_dt.NewRow();
            row[0] = "Серы";
            row[1] = items["<Sulfur>"] + " %";
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Масса балласта";
            row[1] = items["<BallastMass>"] + " т";
            report_dt.Rows.Add(row);

            row = report_dt.NewRow();
            row[0] = "Масса нейти нетто";
            row[1] = items["<NetOilMass>"] + " т";
            report_dt.Rows.Add(row);


            dataGridView1.DataSource = report_dt;
            dataGridView1.ClearSelection();

            if (CurrentUser.Role != UserRole.ADMIN)
            {
                dataGridView1.ContextMenuStrip = null;
            }
        }
        /// <summary>
        /// выбор пункта контекстного меню сохранить о в Word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьВWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // экспорт протокола в Word
            var helper = new WordHelper(word_template_path, Application.StartupPath);
            string result_order_filename = string.Empty;
            if (helper.Process(items, ref result_order_filename))
            {
                // заносим новый приказ в БД
                helper.OpenReport(result_order_filename);
            }
        }


        /// <summary>
        /// выбор пункта контекстного меню сохранить о в Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
            }

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet sheet;
            object misValue = System.Reflection.Missing.Value;
            excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            workbook = excel.Workbooks.Add(misValue);
            sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Item[1];

            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[3, 1];
            CR.Select();
            sheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            CR = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[1, 1];
            CR.Value2 = lbReportName.Text;
            sheet.Columns.AutoFit();

        }

        
    }
}
