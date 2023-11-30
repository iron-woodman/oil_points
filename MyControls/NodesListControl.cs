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
    public partial class NodesListControl : UserControl
    {

        private string _name;
        [Browsable(true)] [Category("Action")] 
        [Description("Событие выбора узла пользователем")]
        public event EventHandler Node1Clicked;

        public NodesListControl()
        {
            InitializeComponent();
            SelectedNode = "";
        }

        /// <summary>
        /// выбранный узел
        /// </summary>
        public string SelectedNode
        {
            get;
            private set;
        }

        /// <summary>
        /// название выбранного узла 
        /// </summary>
        public string SelectedNodeCaption
        {
            get;
            private set;
        }

        /// <summary>
        /// Название узла №1 
        /// </summary>
        public string Node1Caption
        {
            get { return btnNode1.Text; }
        }

        /// <summary>
        /// Название узла №2 
        /// </summary>
        public string Node2Caption
        {
            get { return btnNode2.Text; }
        }

        /// <summary>
        /// Название узла №3 
        /// </summary>
        public string Node3Caption
        {
            get { return btnNode3.Text; }
        }



        /// <summary>
        /// подсветка нужного узла при наведении курсора мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_MouseEnter(object sender, EventArgs e)
        {
            switch (((Button)sender).Tag.ToString())
            {
                case "node1": btnNode1.BackColor = Color.Green; btnNode1.Focus(); break;
                case "node2": btnNode2.BackColor = Color.Green; btnNode2.Focus(); break;
                case "node3": btnNode3.BackColor = Color.Green; btnNode3.Focus(); break;

            }
            //((Panel)sender).ForeColor = Color.IndianRed;
        }

        /// <summary>
        /// убираем подсветку при перемещении курсора мыши с данного элемнта управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lb_MouseLeave(object sender, EventArgs e)
        {
            switch (((Button)sender).Tag.ToString())
            {
                case "node1": btnNode1.BackColor = Color.Gray;  label1.Focus(); break ;
                case "node2": btnNode2.BackColor = Color.Gray; label1.Focus(); break;
                case "node3": btnNode3.BackColor = Color.Gray; label1.Focus(); break;

            }
        }

   


        /// <summary>
        /// выбор конкретного узла связи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void node_Click(object sender, EventArgs e)
        {
            SelectedNode = ((Button)sender).Tag.ToString();
            switch (SelectedNode)
            {
                case "node1": SelectedNodeCaption = btnNode1.Text; break;
                case "node2": SelectedNodeCaption = btnNode2.Text; break;
                case "node3": SelectedNodeCaption = btnNode3.Text; break;
            }
            Node1Clicked.Invoke(this, e);
        }
    }
}
