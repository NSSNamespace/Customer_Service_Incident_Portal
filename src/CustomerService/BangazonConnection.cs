using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace CustomerService
{
    public class BangazonConnection
    {
        private string _connectionString1 = "Data Source=" + System.Environment.GetEnvironmentVariable("Bangazon_Db_Path1");
        private string _connectionString2 = "Data Source=" + System.Environment.GetEnvironmentVariable("Bangqzon_Db_Path2");

        public void insert(string query)
        {
            SqliteConnection dbcon2 = new SqliteConnection(_connectionString2);

            dbcon2.Open();
            SqliteCommand dbcmd = dbcon2.CreateCommand();

            dbcmd.CommandText = query;
            dbcmd.ExecuteNonQuery();

            // clean up
            dbcmd.Dispose();
            dbcon2.Close();
        }

        public void execute(string query, Action<SqliteDataReader> handler)
        {

            SqliteConnection dbcon1 = new SqliteConnection(_connectionString1);

            dbcon1.Open();
            SqliteCommand dbcmd = dbcon1.CreateCommand();
            dbcmd.CommandText = query;

            using (var reader = dbcmd.ExecuteReader())
            {
                handler(reader);
            }

            // clean up
            dbcmd.Dispose();
            dbcon1.Close();
        }

        public void executeNewDb(string query, Action<SqliteDataReader> handler)
        {

            SqliteConnection dbcon2 = new SqliteConnection(_connectionString2);

            dbcon2.Open();
            SqliteCommand dbcmd = dbcon2.CreateCommand();
            dbcmd.CommandText = query;

            using (var reader = dbcmd.ExecuteReader())
            {
                handler(reader);
            }

            // clean up
            dbcmd.Dispose();
            dbcon2.Close();
        }
    }
}
