
using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace NHibernateTest
{
    class MySqlHelper
    {
        private static readonly string ConStr = ConfigurationManager.ConnectionStrings["mysql"].ToString();

        public static DataTable GetAll(string tableName)
        {
            var table = new DataTable();

            using (var connection = new MySqlConnection(ConStr))
            {
                try
                {
                    connection.Open();
                    var selectAllSql = string.Format("select * from {0};", tableName);
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = selectAllSql;

                        var adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(table);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            return table;
        }
    }
}
