namespace oil_points
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelbtnSettings = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbMenuSettings = new System.Windows.Forms.Label();
            this.panelbtnStat = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbMenuLogs = new System.Windows.Forms.Label();
            this.panelbtnBack = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbMenuBack = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lbMenuExit = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelNodesList = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bwDBFiller = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelbtnSettings.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panelbtnStat.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelbtnBack.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelbtnSettings
            // 
            this.panelbtnSettings.Controls.Add(this.tableLayoutPanel4);
            this.panelbtnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbtnSettings.Location = new System.Drawing.Point(545, 3);
            this.panelbtnSettings.Name = "panelbtnSettings";
            this.panelbtnSettings.Size = new System.Drawing.Size(265, 63);
            this.panelbtnSettings.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lbMenuSettings, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(265, 63);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lbMenuSettings
            // 
            this.lbMenuSettings.AutoSize = true;
            this.lbMenuSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMenuSettings.ForeColor = System.Drawing.SystemColors.Window;
            this.lbMenuSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbMenuSettings.Location = new System.Drawing.Point(87, 0);
            this.lbMenuSettings.Name = "lbMenuSettings";
            this.lbMenuSettings.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lbMenuSettings.Size = new System.Drawing.Size(91, 40);
            this.lbMenuSettings.TabIndex = 2;
            this.lbMenuSettings.Text = "Настройки";
            this.lbMenuSettings.Click += new System.EventHandler(this.lbMenuSettings_Click);
            this.lbMenuSettings.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lbMenuSettings.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // panelbtnStat
            // 
            this.panelbtnStat.Controls.Add(this.tableLayoutPanel3);
            this.panelbtnStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbtnStat.Location = new System.Drawing.Point(274, 3);
            this.panelbtnStat.Name = "panelbtnStat";
            this.panelbtnStat.Size = new System.Drawing.Size(265, 63);
            this.panelbtnStat.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lbMenuLogs, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(265, 63);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lbMenuLogs
            // 
            this.lbMenuLogs.AutoSize = true;
            this.lbMenuLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMenuLogs.ForeColor = System.Drawing.SystemColors.Window;
            this.lbMenuLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbMenuLogs.Location = new System.Drawing.Point(65, 0);
            this.lbMenuLogs.Name = "lbMenuLogs";
            this.lbMenuLogs.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lbMenuLogs.Size = new System.Drawing.Size(134, 40);
            this.lbMenuLogs.TabIndex = 2;
            this.lbMenuLogs.Text = "Журнал событий";
            this.lbMenuLogs.Click += new System.EventHandler(this.lbMenuLogs_Click);
            this.lbMenuLogs.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lbMenuLogs.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // panelbtnBack
            // 
            this.panelbtnBack.Controls.Add(this.tableLayoutPanel2);
            this.panelbtnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbtnBack.Location = new System.Drawing.Point(3, 3);
            this.panelbtnBack.Name = "panelbtnBack";
            this.panelbtnBack.Size = new System.Drawing.Size(265, 63);
            this.panelbtnBack.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lbMenuBack, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(265, 63);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbMenuBack
            // 
            this.lbMenuBack.AutoSize = true;
            this.lbMenuBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMenuBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMenuBack.ForeColor = System.Drawing.SystemColors.Window;
            this.lbMenuBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbMenuBack.Location = new System.Drawing.Point(103, 0);
            this.lbMenuBack.Name = "lbMenuBack";
            this.lbMenuBack.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lbMenuBack.Size = new System.Drawing.Size(58, 63);
            this.lbMenuBack.TabIndex = 2;
            this.lbMenuBack.Text = "Назад";
            this.lbMenuBack.Click += new System.EventHandler(this.lbMenuBack_Click);
            this.lbMenuBack.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lbMenuBack.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(816, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 63);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.lbMenuExit, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(267, 63);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // lbMenuExit
            // 
            this.lbMenuExit.AutoSize = true;
            this.lbMenuExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMenuExit.ForeColor = System.Drawing.SystemColors.Window;
            this.lbMenuExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbMenuExit.Location = new System.Drawing.Point(104, 0);
            this.lbMenuExit.Name = "lbMenuExit";
            this.lbMenuExit.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lbMenuExit.Size = new System.Drawing.Size(58, 40);
            this.lbMenuExit.TabIndex = 1;
            this.lbMenuExit.Text = "Выход";
            this.lbMenuExit.Click += new System.EventHandler(this.lbMenuExit_Click);
            this.lbMenuExit.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lbMenuExit.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.BackColor = System.Drawing.Color.DarkGray;
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanelMain.Controls.Add(this.panelNodesList, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1092, 752);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // panelNodesList
            // 
            this.panelNodesList.BackColor = System.Drawing.Color.DarkGray;
            this.panelNodesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNodesList.Location = new System.Drawing.Point(3, 78);
            this.panelNodesList.Name = "panelNodesList";
            this.panelNodesList.Size = new System.Drawing.Size(1086, 671);
            this.panelNodesList.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelbtnSettings, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelbtnBack, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelbtnStat, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1086, 69);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // bwDBFiller
            // 
            this.bwDBFiller.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDBFiller_DoWork);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1092, 752);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelbtnSettings.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panelbtnStat.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panelbtnBack.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelbtnSettings;
        private System.Windows.Forms.Panel panelbtnStat;
        private System.Windows.Forms.Panel panelbtnBack;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelNodesList;
        private System.Windows.Forms.Label lbMenuSettings;
        private System.Windows.Forms.Label lbMenuLogs;
        private System.Windows.Forms.Label lbMenuBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbMenuExit;
        private System.ComponentModel.BackgroundWorker bwDBFiller;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}

