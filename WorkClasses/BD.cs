using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лог;

namespace oil_points.MyControls
{
    public static class DB
    {

        /// <summary>
        /// выполнить sql-command
        /// </summary>
        /// <param name="sqlcommand"></param>
        /// <returns></returns>
        public static bool ExecuteSQLCommand(string sqlcommand)
        {
            using (SqlConnection cn = new SqlConnection(Config.connectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sqlcommand, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;

                }
                catch (SystemException ex)
                {
                    logger.WriteToErrorLog($"Исключение при выполнени запроса '{sqlcommand}': {ex.Message}.");
                    return false;
                }
            }
        }

    }


    }
