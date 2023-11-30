namespace oil_points.MyControls
{
    partial class NodesListControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNode1 = new System.Windows.Forms.Button();
            this.btnNode2 = new System.Windows.Forms.Button();
            this.btnNode3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 732F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1058, 350);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(166, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 207);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnNode1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnNode2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnNode3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(726, 207);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(166, 38);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(50, 0, 0, 10);
            this.label1.Size = new System.Drawing.Size(726, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберете систему измерений количества и показателей качества нефти:";
            // 
            // btnNode1
            // 
            this.btnNode1.BackColor = System.Drawing.Color.Gray;
            this.btnNode1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNode1.Location = new System.Drawing.Point(3, 3);
            this.btnNode1.Name = "btnNode1";
            this.btnNode1.Size = new System.Drawing.Size(720, 63);
            this.btnNode1.TabIndex = 3;
            this.btnNode1.Tag = "node1";
            this.btnNode1.Text = "СИКН №1";
            this.btnNode1.UseVisualStyleBackColor = false;
            this.btnNode1.Click += new System.EventHandler(this.node_Click);
            this.btnNode1.MouseEnter += new System.EventHandler(this.lb_MouseEnter);
            this.btnNode1.MouseLeave += new System.EventHandler(this.lb_MouseLeave);
            // 
            // btnNode2
            // 
            this.btnNode2.BackColor = System.Drawing.Color.Gray;
            this.btnNode2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNode2.Location = new System.Drawing.Point(3, 72);
            this.btnNode2.Name = "btnNode2";
            this.btnNode2.Size = new System.Drawing.Size(720, 63);
            this.btnNode2.TabIndex = 3;
            this.btnNode2.Tag = "node2";
            this.btnNode2.Text = "СИКН №2";
            this.btnNode2.UseVisualStyleBackColor = false;
            this.btnNode2.Click += new System.EventHandler(this.node_Click);
            this.btnNode2.MouseEnter += new System.EventHandler(this.lb_MouseEnter);
            this.btnNode2.MouseLeave += new System.EventHandler(this.lb_MouseLeave);
            // 
            // btnNode3
            // 
            this.btnNode3.BackColor = System.Drawing.Color.Gray;
            this.btnNode3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNode3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNode3.Location = new System.Drawing.Point(3, 141);
            this.btnNode3.Name = "btnNode3";
            this.btnNode3.Size = new System.Drawing.Size(720, 63);
            this.btnNode3.TabIndex = 3;
            this.btnNode3.Tag = "node3";
            this.btnNode3.Text = "СИКН №3";
            this.btnNode3.UseVisualStyleBackColor = false;
            this.btnNode3.Click += new System.EventHandler(this.node_Click);
            this.btnNode3.MouseEnter += new System.EventHandler(this.lb_MouseEnter);
            this.btnNode3.MouseLeave += new System.EventHandler(this.lb_MouseLeave);
            // 
            // NodesListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NodesListControl";
            this.Size = new System.Drawing.Size(1058, 350);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNode1;
        private System.Windows.Forms.Button btnNode2;
        private System.Windows.Forms.Button btnNode3;
    }
}
