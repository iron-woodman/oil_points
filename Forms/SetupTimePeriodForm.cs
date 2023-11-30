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
    /// класс формы выбора временного интервала
    /// </summary>
    public partial class SetupTimePeriodForm : Form
    {
        
        public SetupTimePeriodForm(string time_period)
        {
            InitializeComponent();
            string[] dates = time_period.Split('-');
            if(dates.Length == 2)
            {
                dtpStartDate.Value = DateTime.Parse(dates[0]);
                dtpEndDate.Value = DateTime.Parse(dates[1]);
            }
        }

        /// <summary>
        /// Начало временного интервала
        /// </summary>
        public DateTime StartTime
        {
            get 
            {
                return dtpStartDate.Value;
            }
        }


        /// <summary>
        /// Конец временного интервала
        /// </summary>
        public DateTime EndTime
        {
            get
            {
                return dtpEndDate.Value;
            }

        }
    }
}
