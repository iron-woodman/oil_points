using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Лог;
using oil_points;

namespace bd_worker
{
    /// <summary>
    /// класс работы с учетными записями пользователя
    /// </summary>
    class DB_User
    {

        /// <summary>
        /// проверить учетную запись пользователя
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Config.connectionString))
            {
                SqlCommand command = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "SELECT PasswordHash FROM Users WHERE Username = @Username"
                };
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    sqlConnection.Open();
                    string storedPasswordHash = command.ExecuteScalar() as string;

                    if (storedPasswordHash != null)
                    {
                        string submittedPasswordHash = Convert.ToBase64String(
                            SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password))
                        );

                        if (storedPasswordHash == submittedPasswordHash)
                        {
                            return true;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    logger.WriteToErrorLog($"Исключение аутентификации пользователя '{username}': {ex.Message}.");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
                

            return false; // User not authenticated
        }

        /// <summary>
        /// создать учетную запись пользователя
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void CreateUser(string username, string password)
        {

            using (SqlConnection sqlConnection = new SqlConnection(Config.connectionString))
            {
                // Compute the hash of the password
                string passwordHash = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));

                SqlCommand command = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash)"
                };
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                try
                {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    logger.WriteToErrorLog($"Исключение при добавлении учетной записи пользователя '{username}': {ex.Message}.");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

               
        }

        /// <summary>
        /// удалить учетную запись пользователя
        /// </summary>
        /// <param name="username"></param>
        public void DeleteUser(string username)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Config.connectionString))
            {
                SqlCommand command = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "DELETE FROM Users WHERE Username = @Username"
                };
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    logger.WriteToErrorLog($"Исключение при удалении учетной записи пользователя '{username}': {ex.Message}.");
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// изменить пароль учетной записи пользователя
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newPassword"></param>
        public void UpdatePassword(string username, string newPassword)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Config.connectionString))
            {
                string newPasswordHash = Convert.ToBase64String(
                SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(newPassword))
            );

                SqlCommand command = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Username = @Username"
                };
                command.Parameters.AddWithValue("@PasswordHash", newPasswordHash);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    logger.WriteToErrorLog($"Исключение при изменении пароля  пользователя '{username}': {ex.Message}.");
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }



    }
}
