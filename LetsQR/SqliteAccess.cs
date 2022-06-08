using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using System.Windows;

namespace LetsQR
{
    public class SqliteAccess
    {
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=log.db;Version=3; New = True; Compress = True");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sqlite_conn;
        }
        public static void CreateTable()
        {
            SQLiteCommand sqlite_cmd;
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();            
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Log (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date DATETIME, Type TEXT, Base64QR TEXT)";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void InsertLog(LogModel log)
        {
            
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            CreateTable();
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Log (date, type, base64qr) VALUES (@date, @type, @base64qr)";
            sqlite_cmd.Parameters.AddWithValue("@date", log.Date);
            sqlite_cmd.Parameters.AddWithValue("@type", log.Type);
            sqlite_cmd.Parameters.AddWithValue("@base64qr", log.Base64QR);
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }
        public static List<LogModel> GetAllLogs()
        {
            List<LogModel> logs = new List<LogModel>();
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            CreateTable();
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Log";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                LogModel log = new LogModel();
                log.Id = sqlite_datareader.GetInt32(0);
                log.Date = sqlite_datareader.GetDateTime(1);
                log.Type = sqlite_datareader.GetString(2);
                log.Base64QR = sqlite_datareader.GetString(3);
                logs.Add(log);
            }
            sqlite_conn.Close();
            return logs;
        }

    }
}
