using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using oil_points;
using Лог;

namespace bd_worker
{
    /// <summary>
    /// класс содержит методы наполнения БД данными из xml-файлов
    /// </summary>
    class DB_Filler
    {


        public delegate void CriticalEventHandler(string message);
        public event CriticalEventHandler CriticalEventNotify;        


        /// <summary>
        /// Добавить новые данные (xml) в базу данных
        /// </summary>
        public void ProcessNewData()
        {
            if (!Directory.Exists(Config.ReportsFolder) || !Directory.Exists(Config.EventsFolder) || !Directory.Exists(Config.ProtocolsFolder))
            {
                return;
            }

            if(!Directory.Exists(Config.ReportFolderArchive) || !Directory.Exists(Config.EventsFolderArchive) || !Directory.Exists(Config.ProtocolsFolderArchive))
            {
                return;
            }


            string[] hour_reports_xml = Directory.GetFiles(Config.ReportsFolder, "hr*.xml", SearchOption.TopDirectoryOnly); // отчеты за час
            string[] period_reports_xml = Directory.GetFiles(Config.ReportsFolder, "pr*.xml", SearchOption.TopDirectoryOnly); // отчеты за период
            string[] events_xml = Directory.GetFiles(Config.EventsFolder, "e_*.xml", SearchOption.TopDirectoryOnly); // логи событий
            string[] critical_events_xml = Directory.GetFiles(Config.EventsFolder, "critical_e_*.xml", SearchOption.TopDirectoryOnly); // логи критических событий
            string[] kmx_temperature_xml = Directory.GetFiles(Config.ProtocolsFolder, "kmx_temperature_*.xml", SearchOption.TopDirectoryOnly); 
            string[] kmx_pressure_xml = Directory.GetFiles(Config.ProtocolsFolder, "kmx_pressure_*.xml", SearchOption.TopDirectoryOnly);
            string[] kmx_density_xml = Directory.GetFiles(Config.ProtocolsFolder, "kmx_density_*.xml", SearchOption.TopDirectoryOnly);
            string[] oqp_xml = Directory.GetFiles(Config.ProtocolsFolder, "oqp_*.xml", SearchOption.TopDirectoryOnly); // Oil quality protocol

            for (int i = 0; i < kmx_density_xml.Length; i++)
            {
                InsertKmxDensityData(kmx_density_xml[i]);
                if (Config.StoreFilesToArchive)
                {
                    // перенос исходного файла в соответсвующий каталог архива
                    File.Copy(kmx_density_xml[i], Path.Combine(Config.ProtocolsFolderArchive, Path.GetFileName(kmx_density_xml[i])), true);
                }
                File.Delete(kmx_density_xml[i]);

            }


            for (int i = 0; i < kmx_temperature_xml.Length; i++)
            {
                InsertKmxTemperatureData(kmx_temperature_xml[i]);
                if (Config.StoreFilesToArchive)
                {
                    // перенос исходного файла в соответсвующий каталог архива
                    File.Copy(kmx_temperature_xml[i], Path.Combine(Config.ProtocolsFolderArchive, Path.GetFileName(kmx_temperature_xml[i])), true);
                }
                File.Delete(kmx_temperature_xml[i]);

            }

            for (int i = 0; i < kmx_pressure_xml.Length; i++)
            {
                InsertKmxPressureData(kmx_pressure_xml[i]);
                if (Config.StoreFilesToArchive)
                {
                    // перенос исходного файла в соответсвующий каталог архива
                    File.Copy(kmx_pressure_xml[i], Path.Combine(Config.ProtocolsFolderArchive, Path.GetFileName(kmx_pressure_xml[i])), true);
                }
                File.Delete(kmx_pressure_xml[i]);
            }




            for (int i = 0; i < oqp_xml.Length; i++)
            {
                InsertOilQualityProtocolData(oqp_xml[i]);
                if (Config.StoreFilesToArchive)
                {
                    // перенос исходного файла в соответсвующий каталог архива
                    File.Copy(oqp_xml[i], Path.Combine(Config.ProtocolsFolderArchive, Path.GetFileName(oqp_xml[i])), true);
                }
                File.Delete(oqp_xml[i]);

            }


            for (int i = 0; i < period_reports_xml.Length; i++)
            {
                InsertPeriodReportData(period_reports_xml[i]);
                if (Config.StoreFilesToArchive)
                {
                    // перенос исходного файла в соответсвующий каталог архива
                    File.Copy(period_reports_xml[i], Path.Combine(Config.ReportFolderArchive, Path.GetFileName(period_reports_xml[i])), true);
                }
                File.Delete(period_reports_xml[i]);

            }



            for (int i = 0; i < hour_reports_xml.Length; i++)
            {
                InsertHourReportData(hour_reports_xml[i]);
                if (Config.StoreFilesToArchive)
                {
                    // перенос исходного файла в соответсвующий каталог архива
                    File.Copy(hour_reports_xml[i], Path.Combine(Config.ReportFolderArchive, Path.GetFileName(hour_reports_xml[i])), true);
                }
                File.Delete(hour_reports_xml[i]);

            }



            for (int i = 0; i < events_xml.Length; i++)
            {
                InsertEventsData(events_xml[i]);
                if (Config.StoreFilesToArchive)
                {
                    // перенос исходного файла в соответсвующий каталог архива
                    File.Copy(events_xml[i], Path.Combine(Config.EventsFolderArchive, Path.GetFileName(events_xml[i])), true);
                }
                File.Delete(events_xml[i]);
            }

            for (int i = 0; i < critical_events_xml.Length; i++)
            {
                InsertCriticalEventsData(critical_events_xml[i]);
                if (Config.StoreFilesToArchive)
                {
                    // перенос исходного файла в соответсвующий каталог архива
                    File.Copy(critical_events_xml[i], Path.Combine(Config.EventsFolderArchive, Path.GetFileName(critical_events_xml[i])), true);
                }
                File.Delete(critical_events_xml[i]);
            }






        }

        /// <summary>
        /// Занести данные по внештатным ситуациям в БД
        /// </summary>
        /// <param name="xml_file"></param>
        private void InsertCriticalEventsData(string xml_file)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xml_file);

                var node = Path.GetFileNameWithoutExtension(xml_file).Split('_')[2];

                // Create a connection to the SQL database
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    connection.Open();

                    // Get the events node
                    XmlNode eventsNode = xmlDoc.SelectSingleNode("events");

                    // Iterate over the pipeline-line nodes
                    foreach (XmlNode eventNode in eventsNode.SelectNodes("event"))
                    {
                        // Get the id attribute value
                        string id = eventNode.Attributes["id"].Value;

                        // Get TIME value
                        string time = eventNode.SelectSingleNode("time").InnerText;

                        // Get MESSAGE value
                        string message = eventNode.SelectSingleNode("message").InnerText;

                        // Insert data into the SQL table
                        string insertDataQuery = $"INSERT INTO {node}_critical_events  ([Время], [Событие]) VALUES (@time, @message)";
                        using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                        {
                            insertDataCommand.Parameters.AddWithValue("@time", DateTime.Parse(time));
                            insertDataCommand.Parameters.AddWithValue("@message", message);
                            insertDataCommand.ExecuteNonQuery();
                        }
                        Console.WriteLine($"{time}: {message}");
                        CriticalEventNotify($"{node}:{time}:{message}.");
                    }

                    connection.Close();
                }

                logger.WriteToStatLog($"Журнал '{Path.GetFileName(xml_file)}' обработан.");
            }
            catch (SystemException ex)
            {
                logger.WriteToErrorLog($"Исключение при обработке файла '{Path.GetFileName(xml_file)}': {ex.Message}.");
            }
        }

        /// <summary>
        /// занести данные паспорта качества нефти в БД
        /// </summary>
        /// <param name="v"></param>
        private void InsertOilQualityProtocolData(string xml_file)
        {
            
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xml_file);
                // по имени xml-файла определяем узел, номер пасспорта и дату
                var node = Path.GetFileNameWithoutExtension(xml_file).Split('_')[1];
                var passport_number = Path.GetFileNameWithoutExtension(xml_file).Split('_')[2];
                var time = Path.GetFileNameWithoutExtension(xml_file).Split('_')[3];
                var passport_date = DateTime.ParseExact(time, "yyyyMMdd", null);

                XmlNode root = xmlDoc.SelectSingleNode("OIL_QUALITY_CERTIFICATE");

                var supplier= root.SelectSingleNode("enterprise_owner").InnerText;
                // Get enterprise owner

                XmlNodeList parameters = xmlDoc.GetElementsByTagName("parameter");

                var reportRow = new Dictionary<string, object>();

                reportRow["Поставщик"] = supplier;
                reportRow["Время"] = passport_date;
                reportRow["Номер паспорта"] = passport_number;



                foreach (XmlNode parameter in parameters)
                {
                    string name = parameter["name"].InnerText;
                    string value = parameter["value"].InnerText;
                    double dblValue;
                    if (double.TryParse(value.Replace(".", ","), out dblValue))
                    {
                        reportRow[name] = dblValue;
                    }
                    else
                    {
                        Console.WriteLine("Error parsing value for parameter: " + name);
                    }
                }

                try
                {
                    using (var sqlConnection = new SqlConnection(Config.connectionString))
                    {
                        var command = new SqlCommand()
                        {
                            Connection = sqlConnection,
                            CommandText = $"INSERT INTO {node}_oil_quality_passport" + 
                            @" ([Время], [Номер паспорта], [Поставщик], [Температура], [Давление], [Плотность], [Плотность при 20°C], [Массовая доля воды],
    [Массовая доля мех. примесей], [Массовая доля серы], [Массовая доля парафина], [Массовая доля сероводорода])
                                VALUES(@Date, @PassportNumber, @Supplier, @Temperature, @Pressure, @Density, @DensityAt20C, @MassFractWater, @MassFractMechImpurities, @MassFractSulphur,
                                @MassFractParaffin, @MassFractHydrogenSulfide)"
                        };

                        command.Parameters.AddWithValue("@Date", reportRow["Время"]);
                        command.Parameters.AddWithValue("@PassportNumber", reportRow["Номер паспорта"]);
                        command.Parameters.AddWithValue("@Supplier", reportRow["Поставщик"]);
                        command.Parameters.AddWithValue("@Temperature", reportRow["Температура"]);
                        command.Parameters.AddWithValue("@Pressure", reportRow["Давление"]);
                        command.Parameters.AddWithValue("@Density", reportRow["Плотность"]);
                        command.Parameters.AddWithValue("@DensityAt20C", reportRow["Плотность при 20°C"]);
                        command.Parameters.AddWithValue("@MassFractWater", reportRow["Массовая доля воды"]);
                        command.Parameters.AddWithValue("@MassFractMechImpurities", reportRow["Массовая доля мех. примесей"]);
                        command.Parameters.AddWithValue("@MassFractSulphur", reportRow["Массовая доля серы"]);
                        command.Parameters.AddWithValue("@MassFractParaffin", reportRow["Массовая доля парафина"]);
                        command.Parameters.AddWithValue("@MassFractHydrogenSulfide", reportRow["Массовая доля сероводорода"]);

                        try
                        {
                            sqlConnection.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.Write("SQL Error: " + ex.Message);
                        }
                        finally
                        {
                            sqlConnection.Close();
                        }



                    }
                logger.WriteToStatLog($"Протокол '{Path.GetFileName(xml_file)}' обработан.");

            }
            catch (Exception e)
                {
                    Console.WriteLine($"Error inserting in database: {e.Message}");
                }

            }

        /// <summary>
        /// Занести данные отчета за период
        /// </summary>
        /// <param name="v"></param>
            private void InsertPeriodReportData(string xml_file)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xml_file);

                var node = Path.GetFileNameWithoutExtension(xml_file).Split('_')[1];
                var time = Path.GetFileNameWithoutExtension(xml_file).Split('_')[2];
                var report_time = DateTime.ParseExact(time, "yyyyMMdd", null);


                // Get the report node
                XmlNode reportNode = xmlDoc.SelectSingleNode("report");

                // Get start time
                string start_time = reportNode.SelectSingleNode("start_time").InnerText; ;
                // Get end time
                string end_time = reportNode.SelectSingleNode("end_time").InnerText; 

                // Get enterprise owner
                string enterprise_owner = reportNode.SelectSingleNode("enterprise_owner").InnerText; ;
                // Get enterprise transporter
                string enterprise_transporter = reportNode.SelectSingleNode("enterprise_transporter").InnerText; ;

                // Get the instrument_readings node
                XmlNode instrumentReadingsNode = reportNode.SelectSingleNode("instrument_readings");

                // Get the quality_passport_number value
                string qualityPassportNumber = instrumentReadingsNode.SelectSingleNode("quality_passport_number").InnerText;

                // Get the oil_gross_mass value
                string oilGrossMass = instrumentReadingsNode.SelectSingleNode("oil_gross_mass").InnerText;

                // Get the average_temperature value
                string averageTemperature = instrumentReadingsNode.SelectSingleNode("average_temperature").InnerText;

                // Get the average_pressure value
                string averagePressure = instrumentReadingsNode.SelectSingleNode("average_pressure").InnerText;

                // Get the average_density_measurement_conditions value
                string averageDensityMeasurementConditions = instrumentReadingsNode.SelectSingleNode("average_density_measurement_conditions").InnerText;

                // Get the average_density_20_degrees value
                string averageDensity20Degrees = instrumentReadingsNode.SelectSingleNode("average_density_20_degrees").InnerText;

                // Get the water value from mass_fraction_ballast
                string water = instrumentReadingsNode.SelectSingleNode("mass_fraction_ballast/water").InnerText;

                // Get the mechanical_impurities value from mass_fraction_ballast
                string mechanicalImpurities = instrumentReadingsNode.SelectSingleNode("mass_fraction_ballast/mechanical_impurities").InnerText;

                // Get the sulfur value from mass_fraction_ballast
                string sulfur = instrumentReadingsNode.SelectSingleNode("mass_fraction_ballast/sulfur").InnerText;

                // Get the ballast_mass value
                string ballastMass = instrumentReadingsNode.SelectSingleNode("ballast_mass").InnerText;

                // Get the net_oil_mass value
                string netOilMass = instrumentReadingsNode.SelectSingleNode("net_oil_mass").InnerText;



                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    // Insert data into the SQL table
                    connection.Open();
                    string insertDataQuery = $"INSERT INTO {node}_reports_period " +
                    @"(
StartTime,
EndTime,
EnterpriseOwner,
EnterpriseTransporter,
QualityPassportNumber, 
OilGrossMass, 
AverageTemperature, 
AveragePressure, 
AverageDensityMeasurementConditions, 
AverageDensity20Degrees, 
Water, 
MechanicalImpurities, 
Sulfur, 
BallastMass, 
NetOilMass) 
VALUES 
(
@StartTime,
@EndTime,
@EnterpriseOwner,
@EnterpriseTransporter,
@QualityPassportNumber, 
@OilGrossMass, 
@AverageTemperature, 
@AveragePressure,
@AverageDensityMeasurementConditions, 
@AverageDensity20Degrees, 
@Water, 
@MechanicalImpurities, 
@Sulfur, 
@BallastMass, 
@NetOilMass
)";
                    using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                    {
                        insertDataCommand.Parameters.AddWithValue("@StartTime", DateTime.Parse(start_time));
                        insertDataCommand.Parameters.AddWithValue("@EndTime", DateTime.Parse(end_time));
                        insertDataCommand.Parameters.AddWithValue("@EnterpriseOwner", enterprise_owner);
                        insertDataCommand.Parameters.AddWithValue("@EnterpriseTransporter", enterprise_transporter);
                        insertDataCommand.Parameters.AddWithValue("@QualityPassportNumber", int.Parse(qualityPassportNumber));
                        insertDataCommand.Parameters.AddWithValue("@OilGrossMass", oilGrossMass);
                        insertDataCommand.Parameters.AddWithValue("@AverageTemperature", averageTemperature);
                        insertDataCommand.Parameters.AddWithValue("@AveragePressure", averagePressure);
                        insertDataCommand.Parameters.AddWithValue("@AverageDensityMeasurementConditions", averageDensityMeasurementConditions);
                        insertDataCommand.Parameters.AddWithValue("@AverageDensity20Degrees", averageDensity20Degrees);
                        insertDataCommand.Parameters.AddWithValue("@Water", water);
                        insertDataCommand.Parameters.AddWithValue("@MechanicalImpurities", mechanicalImpurities);
                        insertDataCommand.Parameters.AddWithValue("@Sulfur", sulfur);
                        insertDataCommand.Parameters.AddWithValue("@BallastMass", ballastMass);
                        insertDataCommand.Parameters.AddWithValue("@NetOilMass", netOilMass);
                        insertDataCommand.ExecuteNonQuery();

                    }
                    connection.Close();

                }
                logger.WriteToStatLog($"Отчет '{Path.GetFileName(xml_file)}' обработан.");
            }
            catch (SystemException ex)
            {
                logger.WriteToErrorLog($"Исключение при обработке файла '{Path.GetFileName(xml_file)}': {ex.Message}.");
            }
        }



        /// <summary>
        /// занести в БД данные по температуре 
        /// </summary>
        /// <param name="v"></param>
        private void InsertKmxTemperatureData(string xml_file)
        {
            try
            {
                var node = Path.GetFileNameWithoutExtension(xml_file).Split('_')[2];
                var protocol_number = Path.GetFileNameWithoutExtension(xml_file).Split('_')[3];
                var time = Path.GetFileNameWithoutExtension(xml_file).Split('_')[4];
                var report_time = DateTime.ParseExact(time, "yyyyMMdd", null);

                // Load the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xml_file);

                // Create a connection to the SQL database
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    connection.Open();


                    // Get the temperature node
                    XmlNode temperatureNode = xmlDoc.SelectSingleNode("temperature");

                    // Iterate over the pipeline-line nodes
                    foreach (XmlNode pipelineNode in temperatureNode.SelectNodes("pipeline-line"))
                    {
                        // Get the id attribute value
                        string LineId = pipelineNode.Attributes["id"].Value;

                        // Get the sensor-A value
                        string sensorA = pipelineNode.SelectSingleNode("sensor-A").InnerText;

                        // Get the sensor-B value
                        string sensorB = pipelineNode.SelectSingleNode("sensor-B").InnerText;

                        // Get the Contr-SI value
                        string contrSI = pipelineNode.SelectSingleNode("Contr-SI").InnerText;

                        // Get the difference value
                        string difference = pipelineNode.SelectSingleNode("difference").InnerText;

                        // Insert data into the SQL table
                        string insertDataQuery = $"INSERT INTO {node}_kmx_temperature (CheckTime, ProtocolNumber, LineId, SensorA, SensorB, ContrSI, Difference) VALUES (@CheckTime, @ProtocolNumber, @LineId, @SensorA, @SensorB, @ContrSI, @Difference)";
                        using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                        {
                            insertDataCommand.Parameters.AddWithValue("@CheckTime", report_time);
                            insertDataCommand.Parameters.AddWithValue("@ProtocolNumber", protocol_number);
                            insertDataCommand.Parameters.AddWithValue("@LineId", LineId);
                            insertDataCommand.Parameters.AddWithValue("@SensorA", decimal.Parse(sensorA));
                            insertDataCommand.Parameters.AddWithValue("@SensorB", decimal.Parse(sensorB));
                            insertDataCommand.Parameters.AddWithValue("@ContrSI", decimal.Parse(contrSI));
                            insertDataCommand.Parameters.AddWithValue("@Difference", decimal.Parse(difference));
                            insertDataCommand.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }

                logger.WriteToStatLog($"Протокол '{Path.GetFileName(xml_file)}' обработан.");

            }
            catch (SystemException ex)
            {
                logger.WriteToErrorLog($"Исключение при обработке файла '{Path.GetFileName(xml_file)}': {ex.Message}.");
            }
        }



        /// <summary>
        /// занести в БД данные по КМХ плотномеров
        /// </summary>
        /// <param name="xml_file"></param>
        private void InsertKmxDensityData(string xml_file)
        {
            try
            {

                var node = Path.GetFileNameWithoutExtension(xml_file).Split('_')[2];
                var protocol_number = Path.GetFileNameWithoutExtension(xml_file).Split('_')[3];
                var time = Path.GetFileNameWithoutExtension(xml_file).Split('_')[4];
                var report_time = DateTime.ParseExact(time, "yyyyMMdd", null);



                // Load the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xml_file);

                // Create a connection to the SQL database
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    connection.Open();

                    // Get the temperature node
                    XmlNode temperatureNode = xmlDoc.SelectSingleNode("areometer");

                    // Iterate over the pipeline-line nodes
                    foreach (XmlNode measurementNode in temperatureNode.SelectNodes("measurement"))
                    {
                        string mesuarementId = measurementNode.Attributes["id"].Value;
                        string temperature = measurementNode.SelectSingleNode("temperature").InnerText;
                        string pressure = measurementNode.SelectSingleNode("pressure").InnerText;
                        string density_at_conditions = measurementNode.SelectSingleNode("density_at_conditions").InnerText;
                        string density_at_20C = measurementNode.SelectSingleNode("density_at_20C").InnerText;
                        string density_at_conditions_lab = measurementNode.SelectSingleNode("density_at_conditions_lab").InnerText;
                        string density_at_20C_lab = measurementNode.SelectSingleNode("density_at_20C_lab").InnerText;
                        string difference_in_density_at_conditions = measurementNode.SelectSingleNode("difference_in_density_at_conditions").InnerText;
                        string density_difference_at_20C = measurementNode.SelectSingleNode("density_difference_at_20C").InnerText;


                        // Insert data into the SQL table
                        string insertDataQuery = $"INSERT INTO [{node}_kmx_density] ("+
           @"[CheckTime]
           ,[ProtocolNumber]
           ,[MeasurementNumber]
           ,[Temperature]
           ,[Pressure]
           ,[DensityAtConditions]
           ,[DensityAt20C]
           ,[DensityAtConditionsLab]
           ,[DensityAt20CLab]
           ,[DifferenceInDensityAtConditions]
           ,[DensityDifferenceAt20C])
     VALUES
           ( @CheckTime
           , @ProtocolNumber
           , @MeasurementNumber
           , @Temperature
           , @Pressure
           , @DensityAtConditions
           , @DensityAt20C
           , @DensityAtConditionsLab
           , @DensityAt20CLab
           , @DifferenceInDensityAtConditions
           , @DensityDifferenceAt20C
)";
                        using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                        {
                            insertDataCommand.Parameters.AddWithValue("@CheckTime", report_time);
                            insertDataCommand.Parameters.AddWithValue("@ProtocolNumber", protocol_number);
                            insertDataCommand.Parameters.AddWithValue("@MeasurementNumber", mesuarementId);
                            insertDataCommand.Parameters.AddWithValue("@Temperature", decimal.Parse(temperature));
                            insertDataCommand.Parameters.AddWithValue("@Pressure", decimal.Parse(pressure));
                            insertDataCommand.Parameters.AddWithValue("@DensityAtConditions", decimal.Parse(density_at_conditions));
                            insertDataCommand.Parameters.AddWithValue("@DensityAt20C", decimal.Parse(density_at_20C));
                            insertDataCommand.Parameters.AddWithValue("@DensityAtConditionsLab", decimal.Parse(density_at_conditions_lab));
                            insertDataCommand.Parameters.AddWithValue("@DensityAt20CLab", decimal.Parse(density_at_20C_lab));
                            insertDataCommand.Parameters.AddWithValue("@DifferenceInDensityAtConditions", decimal.Parse(difference_in_density_at_conditions));
                            insertDataCommand.Parameters.AddWithValue("@DensityDifferenceAt20C", decimal.Parse(density_difference_at_20C));
                            insertDataCommand.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }

                logger.WriteToStatLog($"Протокол '{Path.GetFileName(xml_file)}' обработан.");

            }
            catch (SystemException ex)
            {
                logger.WriteToErrorLog($"Исключение при обработке файла '{Path.GetFileName(xml_file)}': {ex.Message}.");
            }
        }


        /// <summary>
        /// занести в БД данные по КМХ давления
        /// </summary>
        /// <param name="v"></param>
        private void InsertKmxPressureData(string xml_file)
        {
            try
            {

                var node = Path.GetFileNameWithoutExtension(xml_file).Split('_')[2];
                var protocol_number = Path.GetFileNameWithoutExtension(xml_file).Split('_')[3];
                var time = Path.GetFileNameWithoutExtension(xml_file).Split('_')[4];
                var report_time = DateTime.ParseExact(time, "yyyyMMdd", null);




                // Load the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xml_file);

                // Create a connection to the SQL database
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    connection.Open();

                    // Get the temperature node
                    XmlNode temperatureNode = xmlDoc.SelectSingleNode("pressure");

                    // Iterate over the pipeline-line nodes
                    foreach (XmlNode pipelineNode in temperatureNode.SelectNodes("pipeline-line"))
                    {
                        // Get the id attribute value
                        string LineId = pipelineNode.Attributes["id"].Value;

                        // Get the sensor-A value
                        string sensorA = pipelineNode.SelectSingleNode("sensor-A").InnerText;

                        // Get the sensor-B value
                        string sensorB = pipelineNode.SelectSingleNode("sensor-B").InnerText;

                        // Get the Contr-SI value
                        string contrSI = pipelineNode.SelectSingleNode("Contr-SI").InnerText;

                        // Get the difference value
                        string difference = pipelineNode.SelectSingleNode("difference").InnerText;

                        // Insert data into the SQL table
                        string insertDataQuery = $"INSERT INTO {node}_kmx_pressure (CheckTime, ProtocolNumber, LineId, SensorA, SensorB, ContrSI,  Difference) VALUES (@CheckTime, @ProtocolNumber, @LineId, @SensorA, @SensorB, @ContrSI, @Difference)";
                        using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                        {
                            insertDataCommand.Parameters.AddWithValue("@CheckTime", report_time);
                            insertDataCommand.Parameters.AddWithValue("@ProtocolNumber", protocol_number);
                            insertDataCommand.Parameters.AddWithValue("@LineId", LineId);
                            insertDataCommand.Parameters.AddWithValue("@SensorA", decimal.Parse(sensorA));
                            insertDataCommand.Parameters.AddWithValue("@SensorB", decimal.Parse(sensorB));
                            insertDataCommand.Parameters.AddWithValue("@ContrSI", decimal.Parse(contrSI));
                            insertDataCommand.Parameters.AddWithValue("@Difference", decimal.Parse(difference));
                            insertDataCommand.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }

                logger.WriteToStatLog($"Протокол '{Path.GetFileName(xml_file)}' обработан.");

            }
            catch (SystemException ex)
            {
                logger.WriteToErrorLog($"Исключение при обработке файла '{Path.GetFileName(xml_file)}': {ex.Message}.");
            }
        }


        /// <summary>
        /// занести в БД данные по новому файлу штатных событий
        /// </summary>
        /// <param name="v"></param>
        private void InsertEventsData(string xml_file)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xml_file);


                var node = Path.GetFileNameWithoutExtension(xml_file).Split('_')[1];

                // Create a connection to the SQL database
                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    connection.Open();

                    // Get the events node
                    XmlNode eventsNode = xmlDoc.SelectSingleNode("events");

                    // Iterate over the pipeline-line nodes
                    foreach (XmlNode eventNode in eventsNode.SelectNodes("event"))
                    {
                        // Get the id attribute value
                        string id = eventNode.Attributes["id"].Value;

                        // Get TIME value
                        string time = eventNode.SelectSingleNode("time").InnerText;

                        // Get MESSAGE value
                        string message = eventNode.SelectSingleNode("message").InnerText;

                        // Insert data into the SQL table
                        string insertDataQuery = $"INSERT INTO {node}_events  ([Время], [Событие]) VALUES (@time, @message)";
                        using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                        {
                            insertDataCommand.Parameters.AddWithValue("@time", DateTime.Parse(time));
                            insertDataCommand.Parameters.AddWithValue("@message", message);
                            insertDataCommand.ExecuteNonQuery();
                        }
                        Console.WriteLine($"{time}: {message}");
                    }

                    connection.Close();
                }

                logger.WriteToStatLog($"Журнал '{Path.GetFileName(xml_file)}' обработан.");
            }
            catch (SystemException ex)
            {
                logger.WriteToErrorLog($"Исключение при обработке файла '{Path.GetFileName(xml_file)}': {ex.Message}.");
            }
        }

        /// <summary>
        /// Занести в БД данные по новому отчету
        /// </summary>
        /// <param name="xml_file"></param>
        private void InsertHourReportData(string xml_file)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xml_file);


                var node = Path.GetFileNameWithoutExtension(xml_file).Split('_')[1];
                var time = Path.GetFileNameWithoutExtension(xml_file).Split('_')[2];
                var report_time = DateTime.ParseExact(time, "yyyyMMddTHHmm", null);

                using (SqlConnection connection = new SqlConnection(Config.connectionString))
                {
                    connection.Open();

                    // Get the oil-pipeline-metering-report node
                    XmlNode reportNode = xmlDoc.SelectSingleNode("oil-pipeline-metering-report");

                    // Iterate over the pipeline-line nodes
                    foreach (XmlNode pipelineNode in reportNode.SelectNodes("pipeline-line"))
                    {
                        // Get the id attribute value
                        string line_id = pipelineNode.Attributes["id"].Value;

                        // Get the average-flow-rate value
                        string averageFlowRate = pipelineNode.SelectSingleNode("average-flow-rate").InnerText;

                        // Get the average-temperature value
                        string averageTemperature = pipelineNode.SelectSingleNode("average-temperature").InnerText;

                        // Get the average-pressure value
                        string averagePressure = pipelineNode.SelectSingleNode("average-pressure").InnerText;

                        // Get the average-density value
                        string averageDensity = pipelineNode.SelectSingleNode("average-density").InnerText;

                        // Get the average-density-at-20-degrees value
                        string averageDensityAt20Degrees = pipelineNode.SelectSingleNode("average-density-at-20-degrees").InnerText;

                        // Get the average-volumetric-water-content value
                        string averageVolumetricWaterContent = pipelineNode.SelectSingleNode("average-volumetric-water-content").InnerText;

                        // Get the average-mass-water-content value
                        string averageMassWaterContent = pipelineNode.SelectSingleNode("average-mass-water-content").InnerText;

                        // Get the volume-at-20-degrees value
                        string volumeAt20Degrees = pipelineNode.SelectSingleNode("volume-at-20-degrees").InnerText;

                        // Get the oil-weight-at-20-degrees value
                        string oilWeightAt20Degrees = pipelineNode.SelectSingleNode("oil-weight-at-20-degrees").InnerText;

                        // Insert data into the SQL table
                        string insertDataQuery = $"INSERT INTO {node}_reports ([Время], [Линия], [Средний расход], " + 
                            @" 
[Средняя температура], 
[Среднее давление],
[Средняя плотность],
[Средняя плотность при 20С],
[Среднее объёмное содержание воды],
[Среднее массовое содержание воды],
[Объём при 20С],
[Масса нефти при 20С]
) " +
@"VALUES (
@time, 
@line_id,
@AverageFlowRate, 
@AverageTemperature, 
@AveragePressure, 
@AverageDensity, 
@AverageDensityAt20Degrees, 
@AverageVolumetricWaterContent, 
@AverageMassWaterContent, 
@VolumeAt20Degrees, 
@OilWeightAt20Degrees)";
                        using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                        {
                            insertDataCommand.Parameters.AddWithValue("@time", report_time);
                            insertDataCommand.Parameters.AddWithValue("@line_id", line_id);
                            insertDataCommand.Parameters.AddWithValue("@AverageFlowRate", decimal.Parse(averageFlowRate));
                            insertDataCommand.Parameters.AddWithValue("@AverageTemperature", decimal.Parse(averageTemperature));
                            insertDataCommand.Parameters.AddWithValue("@AveragePressure", decimal.Parse(averagePressure));
                            insertDataCommand.Parameters.AddWithValue("@AverageDensity", decimal.Parse(averageDensity));
                            insertDataCommand.Parameters.AddWithValue("@AverageDensityAt20Degrees", decimal.Parse(averageDensityAt20Degrees));
                            insertDataCommand.Parameters.AddWithValue("@AverageVolumetricWaterContent", double.Parse(averageVolumetricWaterContent.Replace(".", ",")));
                            insertDataCommand.Parameters.AddWithValue("@AverageMassWaterContent", double.Parse(averageMassWaterContent.Replace(".", ",")));
                            insertDataCommand.Parameters.AddWithValue("@VolumeAt20Degrees", decimal.Parse(volumeAt20Degrees));
                            insertDataCommand.Parameters.AddWithValue("@OilWeightAt20Degrees", decimal.Parse(oilWeightAt20Degrees));

                            insertDataCommand.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }


                logger.WriteToStatLog($"Отчет '{Path.GetFileName(xml_file)}' обработан.");
            }
            catch (SystemException ex)
            {
                logger.WriteToErrorLog($"Исключение при обработке файла '{Path.GetFileName(xml_file)}': {ex.Message}.");
            }
        }
    }
}
