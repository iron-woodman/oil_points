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
    /// элемент управления представляющий список отчетов/протоколов 
    /// </summary>
    public partial class ReportListControl : UserControl
    {

        [Browsable(true)]
        [Category("Action")]
        [Description("Событие выбора элемента списка")]
        public event EventHandler ListItemClicked;

        [Browsable(true)]
        [Category("Action")]
        [Description("Событие удаление элемента списка")]
        public event EventHandler ListItemDelete;

        bool desable_mouse_events = false;

        ReportItemClickEventArgs clicked_item;

        public ReportListControl(List<StringValue> reportList, string report_name, bool disableMouseEvents=false)
        {
            InitializeComponent();
            lbReportName.Text = report_name;
            var source = new BindingSource();
            source.DataSource = reportList;
            dataGridView1.DataSource = source;
            dataGridView1.ClearSelection();
            if (disableMouseEvents)
            {
                dataGridView1.Columns[0].Width = 600;
            }
            else
            {
                dataGridView1.Columns[0].Width = 200;
            }
            this.desable_mouse_events = disableMouseEvents;

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.desable_mouse_events)
            {
                return;
            }

            // снимаем выделение текущей ячейки datagridView
            DataGridViewCell curentCell = dataGridView1.CurrentCell;
            curentCell.Selected = false;

            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Green;
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (this.desable_mouse_events)
            {
                return;
            }
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Gray;
            }
        }

        /// <summary>
        /// обработчик события нажатия мыши на конкретном отчете
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            clicked_item = new ReportItemClickEventArgs();
            clicked_item.ClickedItemCaption = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            clicked_item.Header = lbReportName.Text;

            if (e.Button == MouseButtons.Left)
            {
                if (this.desable_mouse_events)
                {
                    return;
                }

                ListItemClicked.Invoke(this, clicked_item);
            }
            else if (e.Button == MouseButtons.Right && !this.desable_mouse_events && CurrentUser.Role == UserRole.ADMIN)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
            else
            {
                clicked_item = null;
            }
           
        }

        /// <summary>
        /// удаление отчета/протокола за выбранную дату
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ListItemDelete.Invoke(this, clicked_item);
            }
            catch { }
        }
    }


    //---------------------------------------------- вспомогательные классы -------------------------------------------------------------------

    /// <summary>
    /// наш класс аргументов события клика по элементу списка
    /// </summary>
    public class ReportItemClickEventArgs : EventArgs
    {
        /// <summary>
        /// выбранный элемент списка
        /// </summary>
        public string ClickedItemCaption;

        /// <summary>
        /// Название отчета
        /// </summary>
        public string Header;
    }

    /// <summary>
    /// класс обертка для элемента списка событий (список строк является источником данных datagridview)
    /// </summary>
    public class StringValue
    {
        public string Name { get; set; }


        public StringValue(string name)
        {
            Name = name;
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------------------------

}
