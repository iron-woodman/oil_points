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
    /// контрол отображения протоколов КМХ
    /// </summary>
    public partial class ProtocolKMXTableControl : UserControl
    {


        private Dictionary<string, string> items = new Dictionary<string, string>();
        private string word_template_path;

        public ProtocolKMXTableControl(DataTable dt, Dictionary<string, string> items, string word_template_path, string protocol_name, ProtocolType protocolType)
        {
            InitializeComponent();
            this.items = items;
            lbProtocolName.Text = protocol_name;
            lbProtocolNumber.Text += (" " + items["<ProtocolNumber>"]);
            lbCheckTime.Text += (" " + items["<kmx_date>"]);

            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
            this.word_template_path = word_template_path;

            // настройка состояний датчиков (годен/не годен)
            if (protocolType == ProtocolType.DENSITY)
            {
                lbALine1.Text = $"Плотномер: {items["<P_S>"]}";
                lbALine2.Text = "";
                lbALine3.Text = "";
                lbABIK.Text = "";
                lbBLine1.Text = "";
                lbBLine2.Text = "";
                lbBLine3.Text = "";
                lbBBIK.Text = "";
            }
            else
            {
                lbALine1.Text = $"Датчик А Линия 1: {items["<A1_S>"]}";
                lbALine2.Text = $"Датчик А Линия 2: {items["<A2_S>"]}";
                lbALine3.Text = $"Датчик А Линия 3: {items["<A3_S>"]}";
                lbABIK.Text = $"Датчик А в БИК: {items["<ABIK_S>"]}";
                lbBLine1.Text = $"Датчик Б Линия 1: {items["<B1_S>"]}";
                lbBLine2.Text = $"Датчик Б Линия 2: {items["<B2_S>"]}";
                lbBLine3.Text = $"Датчик Б Линия 3:{items["<B3_S>"]}"; ;
                lbBBIK.Text = $"Датчик Б в БИК: {items["<BBIK_S>"]}";
            }


            switch (protocolType)
            {
                case ProtocolType.TEMPERATURE:
                    lbValuesMeasurements.Text = "Значения температуры отображаются в градусах цельсия.";break;
                case ProtocolType.PRESSURE:
                    lbValuesMeasurements.Text = "Значения давления отображаются в мегапаскалях."; break;
                case ProtocolType.DENSITY:
                    lbValuesMeasurements.Text = "Значение плотности отображается в кг/м3."; break;
                default:
                    lbValuesMeasurements.Text = "";break;
            }

            if (CurrentUser.Role != UserRole.ADMIN)
            {
                dataGridView1.ContextMenuStrip = null;
            }



        }

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
    }


   public enum ProtocolType { TEMPERATURE, PRESSURE, DENSITY};


}
