using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oil_points.MyControls
{
    public partial class ReportTableControl : UserControl
    {

        private string excel_reports_folder = string.Empty;
        public ReportTableControl(DataTable dt, string report_name, string time_period)
        {
            InitializeComponent();
            lbReportName.Text = report_name;
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
            lbTimeInterval.Text = time_period;

            if (WorkClasses.CurrentUser.Role != WorkClasses.UserRole.ADMIN)
            {
                dataGridView1.ContextMenuStrip = null;
            }

        }

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


            int column_number = 1;
            if (lbReportName.Text.ToLower().Contains("паспорт"))
            {
                column_number = 2;
            }

            CR = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[1, column_number];
            CR.Value2 = lbReportName.Text;

            CR = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[2, column_number];
            CR.Value2 = lbTimeInterval.Text;
            sheet.Columns.AutoFit();
        }
    }
}
