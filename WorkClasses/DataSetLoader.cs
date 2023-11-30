using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Лог;

namespace oil_points.WorkClasses
{
    /// <summary>
    /// Класс загрузки стат данных конкретного узла
    /// </summary>
    public static class DataSetLoader
    {

        /// <summary>
        /// получить набор статистических данных узла
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string node)
        {
            DataSet ds = new DataSet(node);

            try
            {
                List<string> nodeTables = GetTablesList(node);
                using (SqlConnection cn = new SqlConnection(Config.connectionString))
                {
                    cn.Open();
                    foreach (string table in nodeTables)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM [{table}]", cn);
                        adapter.Fill(ds, table);
                    }
                    cn.Close();
                }
            }
            catch (SystemException ex)
            {
                logger.WriteToErrorLog($"Исключение при выгрузке набора данных по узлу {node}: {ex.Message}.");
                return null;
            }
            return ds;

        }

        /// <summary>
        /// получить список таблиц для конкретного узла 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="baseName"></param>
        /// <returns></returns>
        public static List<string> GetTablesList(string node)
        {

            using (SqlConnection cn = new SqlConnection(Config.connectionString))
            {
                try
                {
                    cn.Open();
                    DataTable dataTable = cn.GetSchema("Tables");
                    List<string> nodeTablesList = new List<string>();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        var tableName = dataTable.Rows[i][2].ToString();
                        if (tableName.Contains(node))
                        {
                            nodeTablesList.Add(tableName);
                        }
                    }
                    cn.Close();
                    return nodeTablesList;
                }
                catch (SystemException ex)
                {
                    logger.WriteToErrorLog($"Исключение при получении списка таблиц узла {node}: {ex.Message}.");
                    return null;
                }
            }
        }

    }
}
