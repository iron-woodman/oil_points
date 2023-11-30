namespace oil_points.MyControls
{
    partial class NodeStatControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 250D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 75D);
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.btnKMXDensity = new System.Windows.Forms.Button();
            this.btnKMXPressure = new System.Windows.Forms.Button();
            this.btnKMXTemperature = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.linklbProtocols = new System.Windows.Forms.LinkLabel();
            this.lbProtocolsCount = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.linklbReports = new System.Windows.Forms.LinkLabel();
            this.lbReportsCount = new System.Windows.Forms.Label();
            this.btnHourReport = new System.Windows.Forms.Button();
            this.btnDayReport = new System.Windows.Forms.Button();
            this.btnPeriodReport = new System.Windows.Forms.Button();
            this.lbOilVolumeStat = new System.Windows.Forms.Label();
            this.tlpChart = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.linkLabelTimePeriod = new System.Windows.Forms.LinkLabel();
            this.lbCurrentOilParameter = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTemperature = new System.Windows.Forms.Button();
            this.btnPressure = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnDensity = new System.Windows.Forms.Button();
            this.btnDensity20C = new System.Windows.Forms.Button();
            this.tplSuppliers = new System.Windows.Forms.TableLayoutPanel();
            this.btnSupplier3 = new System.Windows.Forms.Button();
            this.btnSupplier2 = new System.Windows.Forms.Button();
            this.linkLabelSuppliers = new System.Windows.Forms.LinkLabel();
            this.btnSupplier1 = new System.Windows.Forms.Button();
            this.tplProtocols = new System.Windows.Forms.TableLayoutPanel();
            this.btnCommonEvents = new System.Windows.Forms.Button();
            this.panelEvents = new System.Windows.Forms.Panel();
            this.linkEvents = new System.Windows.Forms.LinkLabel();
            this.lbEventsCount = new System.Windows.Forms.Label();
            this.btnCriticalEvents = new System.Windows.Forms.Button();
            this.bwDataSetLoader = new System.ComponentModel.BackgroundWorker();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tlpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tplSuppliers.SuspendLayout();
            this.tplProtocols.SuspendLayout();
            this.panelEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 5;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.Controls.Add(this.tableLayoutPanelLeft, 1, 1);
            this.tlpMain.Controls.Add(this.lbOilVolumeStat, 2, 2);
            this.tlpMain.Controls.Add(this.tlpChart, 2, 1);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 3, 1);
            this.tlpMain.Controls.Add(this.tplSuppliers, 3, 2);
            this.tlpMain.Controls.Add(this.tplProtocols, 1, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.Size = new System.Drawing.Size(1129, 754);
            this.tlpMain.TabIndex = 0;
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.btnKMXDensity, 0, 8);
            this.tableLayoutPanelLeft.Controls.Add(this.btnKMXPressure, 0, 7);
            this.tableLayoutPanelLeft.Controls.Add(this.btnKMXTemperature, 0, 6);
            this.tableLayoutPanelLeft.Controls.Add(this.panel10, 0, 5);
            this.tableLayoutPanelLeft.Controls.Add(this.panel9, 0, 1);
            this.tableLayoutPanelLeft.Controls.Add(this.btnHourReport, 0, 2);
            this.tableLayoutPanelLeft.Controls.Add(this.btnDayReport, 0, 3);
            this.tableLayoutPanelLeft.Controls.Add(this.btnPeriodReport, 0, 4);
            this.tableLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(43, 23);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 10;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(234, 528);
            this.tableLayoutPanelLeft.TabIndex = 0;
            // 
            // btnKMXDensity
            // 
            this.btnKMXDensity.BackColor = System.Drawing.Color.Peru;
            this.btnKMXDensity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKMXDensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKMXDensity.Location = new System.Drawing.Point(0, 465);
            this.btnKMXDensity.Margin = new System.Windows.Forms.Padding(0);
            this.btnKMXDensity.Name = "btnKMXDensity";
            this.btnKMXDensity.Size = new System.Drawing.Size(234, 41);
            this.btnKMXDensity.TabIndex = 7;
            this.btnKMXDensity.Text = "КМХ плотномеров";
            this.btnKMXDensity.UseVisualStyleBackColor = false;
            this.btnKMXDensity.Click += new System.EventHandler(this.btnKMXDensity_Click);
            // 
            // btnKMXPressure
            // 
            this.btnKMXPressure.BackColor = System.Drawing.Color.Peru;
            this.btnKMXPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKMXPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKMXPressure.Location = new System.Drawing.Point(0, 424);
            this.btnKMXPressure.Margin = new System.Windows.Forms.Padding(0);
            this.btnKMXPressure.Name = "btnKMXPressure";
            this.btnKMXPressure.Size = new System.Drawing.Size(234, 41);
            this.btnKMXPressure.TabIndex = 7;
            this.btnKMXPressure.Text = "КМХ давления";
            this.btnKMXPressure.UseVisualStyleBackColor = false;
            this.btnKMXPressure.Click += new System.EventHandler(this.btnKMXPressure_Click);
            // 
            // btnKMXTemperature
            // 
            this.btnKMXTemperature.BackColor = System.Drawing.Color.Peru;
            this.btnKMXTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKMXTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKMXTemperature.Location = new System.Drawing.Point(0, 383);
            this.btnKMXTemperature.Margin = new System.Windows.Forms.Padding(0);
            this.btnKMXTemperature.Name = "btnKMXTemperature";
            this.btnKMXTemperature.Size = new System.Drawing.Size(234, 41);
            this.btnKMXTemperature.TabIndex = 7;
            this.btnKMXTemperature.Text = "КМХ температуры";
            this.btnKMXTemperature.UseVisualStyleBackColor = false;
            this.btnKMXTemperature.Click += new System.EventHandler(this.btnKMXTemperature_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Peru;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel10.Controls.Add(this.linklbProtocols);
            this.panel10.Controls.Add(this.lbProtocolsCount);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(3, 296);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(228, 84);
            this.panel10.TabIndex = 0;
            // 
            // linklbProtocols
            // 
            this.linklbProtocols.AutoSize = true;
            this.linklbProtocols.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linklbProtocols.ForeColor = System.Drawing.SystemColors.WindowText;
            this.linklbProtocols.LinkColor = System.Drawing.Color.Black;
            this.linklbProtocols.Location = new System.Drawing.Point(17, 44);
            this.linklbProtocols.Name = "linklbProtocols";
            this.linklbProtocols.Size = new System.Drawing.Size(128, 24);
            this.linklbProtocols.TabIndex = 6;
            this.linklbProtocols.TabStop = true;
            this.linklbProtocols.Text = "Протоколов";
            // 
            // lbProtocolsCount
            // 
            this.lbProtocolsCount.AutoSize = true;
            this.lbProtocolsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbProtocolsCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbProtocolsCount.Location = new System.Drawing.Point(23, 2);
            this.lbProtocolsCount.Name = "lbProtocolsCount";
            this.lbProtocolsCount.Size = new System.Drawing.Size(47, 37);
            this.lbProtocolsCount.TabIndex = 0;
            this.lbProtocolsCount.Text = "---";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Peru;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.linklbReports);
            this.panel9.Controls.Add(this.lbReportsCount);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 83);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(228, 84);
            this.panel9.TabIndex = 0;
            // 
            // linklbReports
            // 
            this.linklbReports.AutoSize = true;
            this.linklbReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linklbReports.ForeColor = System.Drawing.SystemColors.WindowText;
            this.linklbReports.LinkColor = System.Drawing.Color.Black;
            this.linklbReports.Location = new System.Drawing.Point(31, 44);
            this.linklbReports.Name = "linklbReports";
            this.linklbReports.Size = new System.Drawing.Size(95, 24);
            this.linklbReports.TabIndex = 6;
            this.linklbReports.TabStop = true;
            this.linklbReports.Text = "Отчетов";
            // 
            // lbReportsCount
            // 
            this.lbReportsCount.AutoSize = true;
            this.lbReportsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbReportsCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbReportsCount.Location = new System.Drawing.Point(24, 4);
            this.lbReportsCount.Name = "lbReportsCount";
            this.lbReportsCount.Size = new System.Drawing.Size(47, 37);
            this.lbReportsCount.TabIndex = 0;
            this.lbReportsCount.Text = "---";
            // 
            // btnHourReport
            // 
            this.btnHourReport.BackColor = System.Drawing.Color.Peru;
            this.btnHourReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHourReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHourReport.Location = new System.Drawing.Point(0, 170);
            this.btnHourReport.Margin = new System.Windows.Forms.Padding(0);
            this.btnHourReport.Name = "btnHourReport";
            this.btnHourReport.Size = new System.Drawing.Size(234, 41);
            this.btnHourReport.TabIndex = 7;
            this.btnHourReport.Text = "Отчет за час";
            this.btnHourReport.UseVisualStyleBackColor = false;
            this.btnHourReport.Click += new System.EventHandler(this.btnHourReport_Click);
            // 
            // btnDayReport
            // 
            this.btnDayReport.BackColor = System.Drawing.Color.Peru;
            this.btnDayReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDayReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDayReport.Location = new System.Drawing.Point(0, 211);
            this.btnDayReport.Margin = new System.Windows.Forms.Padding(0);
            this.btnDayReport.Name = "btnDayReport";
            this.btnDayReport.Size = new System.Drawing.Size(234, 41);
            this.btnDayReport.TabIndex = 7;
            this.btnDayReport.Text = "Отчет за сутки";
            this.btnDayReport.UseVisualStyleBackColor = false;
            this.btnDayReport.Click += new System.EventHandler(this.btnDayReport_Click);
            // 
            // btnPeriodReport
            // 
            this.btnPeriodReport.BackColor = System.Drawing.Color.Peru;
            this.btnPeriodReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPeriodReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPeriodReport.Location = new System.Drawing.Point(0, 252);
            this.btnPeriodReport.Margin = new System.Windows.Forms.Padding(0);
            this.btnPeriodReport.Name = "btnPeriodReport";
            this.btnPeriodReport.Size = new System.Drawing.Size(234, 41);
            this.btnPeriodReport.TabIndex = 7;
            this.btnPeriodReport.Text = "Отчет за период";
            this.btnPeriodReport.UseVisualStyleBackColor = false;
            this.btnPeriodReport.Click += new System.EventHandler(this.btnPeriodReport_Click);
            // 
            // lbOilVolumeStat
            // 
            this.lbOilVolumeStat.AutoSize = true;
            this.lbOilVolumeStat.BackColor = System.Drawing.Color.DarkGray;
            this.lbOilVolumeStat.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbOilVolumeStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbOilVolumeStat.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbOilVolumeStat.Location = new System.Drawing.Point(283, 554);
            this.lbOilVolumeStat.Name = "lbOilVolumeStat";
            this.lbOilVolumeStat.Padding = new System.Windows.Forms.Padding(100, 15, 15, 15);
            this.lbOilVolumeStat.Size = new System.Drawing.Size(544, 55);
            this.lbOilVolumeStat.TabIndex = 2;
            this.lbOilVolumeStat.Text = "Прокачано";
            // 
            // tlpChart
            // 
            this.tlpChart.ColumnCount = 1;
            this.tlpChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChart.Controls.Add(this.chart1, 0, 2);
            this.tlpChart.Controls.Add(this.linkLabelTimePeriod, 0, 1);
            this.tlpChart.Controls.Add(this.lbCurrentOilParameter, 0, 0);
            this.tlpChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChart.Location = new System.Drawing.Point(283, 23);
            this.tlpChart.Name = "tlpChart";
            this.tlpChart.RowCount = 3;
            this.tlpChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChart.Size = new System.Drawing.Size(544, 528);
            this.tlpChart.TabIndex = 1;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.DarkGray;
            this.chart1.BorderlineColor = System.Drawing.Color.DimGray;
            chartArea1.BackColor = System.Drawing.Color.DimGray;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 83);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "StatData";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(538, 442);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // linkLabelTimePeriod
            // 
            this.linkLabelTimePeriod.AutoSize = true;
            this.linkLabelTimePeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabelTimePeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelTimePeriod.ForeColor = System.Drawing.SystemColors.WindowText;
            this.linkLabelTimePeriod.LinkColor = System.Drawing.Color.Black;
            this.linkLabelTimePeriod.Location = new System.Drawing.Point(3, 50);
            this.linkLabelTimePeriod.Name = "linkLabelTimePeriod";
            this.linkLabelTimePeriod.Padding = new System.Windows.Forms.Padding(90, 0, 0, 0);
            this.linkLabelTimePeriod.Size = new System.Drawing.Size(538, 30);
            this.linkLabelTimePeriod.TabIndex = 6;
            this.linkLabelTimePeriod.TabStop = true;
            this.linkLabelTimePeriod.Text = "Диапазон дат: 01.11.2023 09:00-03.11.2023 09:00";
            this.linkLabelTimePeriod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SetupTimePeriod_LinkClicked);
            // 
            // lbCurrentOilParameter
            // 
            this.lbCurrentOilParameter.AutoSize = true;
            this.lbCurrentOilParameter.BackColor = System.Drawing.Color.DarkGray;
            this.lbCurrentOilParameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCurrentOilParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCurrentOilParameter.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbCurrentOilParameter.Location = new System.Drawing.Point(3, 0);
            this.lbCurrentOilParameter.Name = "lbCurrentOilParameter";
            this.lbCurrentOilParameter.Padding = new System.Windows.Forms.Padding(90, 5, 5, 5);
            this.lbCurrentOilParameter.Size = new System.Drawing.Size(538, 34);
            this.lbCurrentOilParameter.TabIndex = 0;
            this.lbCurrentOilParameter.Text = "Температура";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnTemperature, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPressure, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDensity, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnDensity20C, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(833, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(253, 528);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnTemperature
            // 
            this.btnTemperature.BackColor = System.Drawing.Color.Gray;
            this.btnTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTemperature.ForeColor = System.Drawing.Color.Blue;
            this.btnTemperature.Location = new System.Drawing.Point(3, 113);
            this.btnTemperature.Name = "btnTemperature";
            this.btnTemperature.Size = new System.Drawing.Size(247, 83);
            this.btnTemperature.TabIndex = 0;
            this.btnTemperature.Text = "Температура";
            this.btnTemperature.UseVisualStyleBackColor = false;
            this.btnTemperature.Click += new System.EventHandler(this.btnParameter_Click);
            // 
            // btnPressure
            // 
            this.btnPressure.BackColor = System.Drawing.Color.Gray;
            this.btnPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPressure.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnPressure.Location = new System.Drawing.Point(3, 202);
            this.btnPressure.Name = "btnPressure";
            this.btnPressure.Size = new System.Drawing.Size(247, 83);
            this.btnPressure.TabIndex = 0;
            this.btnPressure.Text = "Давление";
            this.btnPressure.UseVisualStyleBackColor = false;
            this.btnPressure.Click += new System.EventHandler(this.btnParameter_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(3, 76);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Padding = new System.Windows.Forms.Padding(45, 0, 0, 10);
            this.linkLabel1.Size = new System.Drawing.Size(247, 34);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Параметры";
            // 
            // btnDensity
            // 
            this.btnDensity.BackColor = System.Drawing.Color.Gray;
            this.btnDensity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDensity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDensity.ForeColor = System.Drawing.Color.Orange;
            this.btnDensity.Location = new System.Drawing.Point(3, 291);
            this.btnDensity.Name = "btnDensity";
            this.btnDensity.Size = new System.Drawing.Size(247, 83);
            this.btnDensity.TabIndex = 0;
            this.btnDensity.Text = "Плотность";
            this.btnDensity.UseVisualStyleBackColor = false;
            this.btnDensity.Click += new System.EventHandler(this.btnParameter_Click);
            // 
            // btnDensity20C
            // 
            this.btnDensity20C.BackColor = System.Drawing.Color.Gray;
            this.btnDensity20C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDensity20C.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDensity20C.ForeColor = System.Drawing.Color.Yellow;
            this.btnDensity20C.Location = new System.Drawing.Point(3, 380);
            this.btnDensity20C.Name = "btnDensity20C";
            this.btnDensity20C.Size = new System.Drawing.Size(247, 83);
            this.btnDensity20C.TabIndex = 0;
            this.btnDensity20C.Text = "Плотность при 20С";
            this.btnDensity20C.UseVisualStyleBackColor = false;
            this.btnDensity20C.Click += new System.EventHandler(this.btnParameter_Click);
            // 
            // tplSuppliers
            // 
            this.tplSuppliers.ColumnCount = 1;
            this.tplSuppliers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplSuppliers.Controls.Add(this.btnSupplier3, 0, 3);
            this.tplSuppliers.Controls.Add(this.btnSupplier2, 0, 2);
            this.tplSuppliers.Controls.Add(this.linkLabelSuppliers, 0, 0);
            this.tplSuppliers.Controls.Add(this.btnSupplier1, 0, 1);
            this.tplSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplSuppliers.Location = new System.Drawing.Point(833, 557);
            this.tplSuppliers.Name = "tplSuppliers";
            this.tplSuppliers.RowCount = 4;
            this.tplSuppliers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tplSuppliers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tplSuppliers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tplSuppliers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tplSuppliers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tplSuppliers.Size = new System.Drawing.Size(253, 194);
            this.tplSuppliers.TabIndex = 3;
            // 
            // btnSupplier3
            // 
            this.btnSupplier3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSupplier3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSupplier3.Location = new System.Drawing.Point(0, 142);
            this.btnSupplier3.Margin = new System.Windows.Forms.Padding(0);
            this.btnSupplier3.Name = "btnSupplier3";
            this.btnSupplier3.Size = new System.Drawing.Size(253, 52);
            this.btnSupplier3.TabIndex = 9;
            this.btnSupplier3.Tag = "supplier3";
            this.btnSupplier3.Text = "«ПАО Татнефть»";
            this.btnSupplier3.UseVisualStyleBackColor = true;
            this.btnSupplier3.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnSupplier2
            // 
            this.btnSupplier2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSupplier2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSupplier2.Location = new System.Drawing.Point(0, 91);
            this.btnSupplier2.Margin = new System.Windows.Forms.Padding(0);
            this.btnSupplier2.Name = "btnSupplier2";
            this.btnSupplier2.Size = new System.Drawing.Size(253, 51);
            this.btnSupplier2.TabIndex = 8;
            this.btnSupplier2.Tag = "supplier2";
            this.btnSupplier2.Text = "«ПАО Лукойл»";
            this.btnSupplier2.UseVisualStyleBackColor = true;
            this.btnSupplier2.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // linkLabelSuppliers
            // 
            this.linkLabelSuppliers.AutoSize = true;
            this.linkLabelSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelSuppliers.LinkColor = System.Drawing.Color.Black;
            this.linkLabelSuppliers.Location = new System.Drawing.Point(3, 0);
            this.linkLabelSuppliers.Name = "linkLabelSuppliers";
            this.linkLabelSuppliers.Padding = new System.Windows.Forms.Padding(45, 0, 0, 0);
            this.linkLabelSuppliers.Size = new System.Drawing.Size(174, 24);
            this.linkLabelSuppliers.TabIndex = 6;
            this.linkLabelSuppliers.TabStop = true;
            this.linkLabelSuppliers.Text = "Поставщики";
            // 
            // btnSupplier1
            // 
            this.btnSupplier1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSupplier1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSupplier1.Location = new System.Drawing.Point(0, 40);
            this.btnSupplier1.Margin = new System.Windows.Forms.Padding(0);
            this.btnSupplier1.Name = "btnSupplier1";
            this.btnSupplier1.Size = new System.Drawing.Size(253, 51);
            this.btnSupplier1.TabIndex = 7;
            this.btnSupplier1.Tag = "supplier1";
            this.btnSupplier1.Text = "«АО Нафтатранс»";
            this.btnSupplier1.UseVisualStyleBackColor = true;
            this.btnSupplier1.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // tplProtocols
            // 
            this.tplProtocols.ColumnCount = 1;
            this.tplProtocols.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tplProtocols.Controls.Add(this.btnCommonEvents, 0, 2);
            this.tplProtocols.Controls.Add(this.panelEvents, 0, 1);
            this.tplProtocols.Controls.Add(this.btnCriticalEvents, 0, 3);
            this.tplProtocols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tplProtocols.Location = new System.Drawing.Point(43, 557);
            this.tplProtocols.Name = "tplProtocols";
            this.tplProtocols.RowCount = 4;
            this.tplProtocols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tplProtocols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tplProtocols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplProtocols.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tplProtocols.Size = new System.Drawing.Size(234, 194);
            this.tplProtocols.TabIndex = 4;
            // 
            // btnCommonEvents
            // 
            this.btnCommonEvents.BackColor = System.Drawing.Color.Peru;
            this.btnCommonEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCommonEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCommonEvents.Location = new System.Drawing.Point(0, 120);
            this.btnCommonEvents.Margin = new System.Windows.Forms.Padding(0);
            this.btnCommonEvents.Name = "btnCommonEvents";
            this.btnCommonEvents.Size = new System.Drawing.Size(234, 37);
            this.btnCommonEvents.TabIndex = 7;
            this.btnCommonEvents.Text = "Штатные";
            this.btnCommonEvents.UseVisualStyleBackColor = false;
            this.btnCommonEvents.Click += new System.EventHandler(this.btnEvents_Click);
            // 
            // panelEvents
            // 
            this.panelEvents.BackColor = System.Drawing.Color.Peru;
            this.panelEvents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEvents.Controls.Add(this.linkEvents);
            this.panelEvents.Controls.Add(this.lbEventsCount);
            this.panelEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEvents.Location = new System.Drawing.Point(3, 23);
            this.panelEvents.Name = "panelEvents";
            this.panelEvents.Size = new System.Drawing.Size(228, 94);
            this.panelEvents.TabIndex = 0;
            // 
            // linkEvents
            // 
            this.linkEvents.AutoSize = true;
            this.linkEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkEvents.ForeColor = System.Drawing.SystemColors.WindowText;
            this.linkEvents.LinkColor = System.Drawing.Color.Black;
            this.linkEvents.Location = new System.Drawing.Point(31, 45);
            this.linkEvents.Name = "linkEvents";
            this.linkEvents.Size = new System.Drawing.Size(97, 24);
            this.linkEvents.TabIndex = 6;
            this.linkEvents.TabStop = true;
            this.linkEvents.Text = "Событий";
            // 
            // lbEventsCount
            // 
            this.lbEventsCount.AutoSize = true;
            this.lbEventsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEventsCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbEventsCount.Location = new System.Drawing.Point(24, 4);
            this.lbEventsCount.Name = "lbEventsCount";
            this.lbEventsCount.Size = new System.Drawing.Size(47, 37);
            this.lbEventsCount.TabIndex = 0;
            this.lbEventsCount.Text = "---";
            // 
            // btnCriticalEvents
            // 
            this.btnCriticalEvents.BackColor = System.Drawing.Color.Peru;
            this.btnCriticalEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCriticalEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCriticalEvents.Location = new System.Drawing.Point(0, 157);
            this.btnCriticalEvents.Margin = new System.Windows.Forms.Padding(0);
            this.btnCriticalEvents.Name = "btnCriticalEvents";
            this.btnCriticalEvents.Size = new System.Drawing.Size(234, 37);
            this.btnCriticalEvents.TabIndex = 7;
            this.btnCriticalEvents.Text = "Критические";
            this.btnCriticalEvents.UseVisualStyleBackColor = false;
            this.btnCriticalEvents.Click += new System.EventHandler(this.btnCriticalEvents_Click);
            // 
            // bwDataSetLoader
            // 
            this.bwDataSetLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDataSetLoader_DoWork);
            this.bwDataSetLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDataSetLoader_RunWorkerCompleted);
            // 
            // NodeStatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.tlpMain);
            this.Name = "NodeStatControl";
            this.Size = new System.Drawing.Size(1129, 754);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tlpChart.ResumeLayout(false);
            this.tlpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tplSuppliers.ResumeLayout(false);
            this.tplSuppliers.PerformLayout();
            this.tplProtocols.ResumeLayout(false);
            this.panelEvents.ResumeLayout(false);
            this.panelEvents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.Panel panelEvents;
        private System.Windows.Forms.LinkLabel linkEvents;
        private System.Windows.Forms.Label lbEventsCount;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.LinkLabel linklbReports;
        private System.Windows.Forms.Label lbReportsCount;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.LinkLabel linklbProtocols;
        private System.Windows.Forms.Label lbProtocolsCount;
        private System.Windows.Forms.TableLayoutPanel tlpChart;
        private System.Windows.Forms.Label lbCurrentOilParameter;
        private System.Windows.Forms.LinkLabel linkLabelTimePeriod;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tplSuppliers;
        private System.Windows.Forms.LinkLabel linkLabelSuppliers;
        private System.Windows.Forms.Button btnSupplier3;
        private System.Windows.Forms.Button btnSupplier2;
        private System.Windows.Forms.Button btnSupplier1;
        private System.Windows.Forms.TableLayoutPanel tplProtocols;
        private System.Windows.Forms.Button btnHourReport;
        private System.Windows.Forms.Button btnDayReport;
        private System.Windows.Forms.Button btnPeriodReport;
        private System.Windows.Forms.Button btnKMXTemperature;
        private System.Windows.Forms.Button btnKMXPressure;
        private System.Windows.Forms.Button btnKMXDensity;
        private System.Windows.Forms.Label lbOilVolumeStat;
        private System.ComponentModel.BackgroundWorker bwDataSetLoader;
        private System.Windows.Forms.Button btnTemperature;
        private System.Windows.Forms.Button btnPressure;
        private System.Windows.Forms.Button btnDensity;
        private System.Windows.Forms.Button btnDensity20C;
        private System.Windows.Forms.Button btnCommonEvents;
        private System.Windows.Forms.Button btnCriticalEvents;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
