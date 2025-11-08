using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;

namespace Elevator
{
    public class Database
    {
        private readonly string conn;

        public Database()
        {
            string db = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "elevator_logs.sqlite");
            conn = $"Data Source={db};Version=3;";
            if (!File.Exists(db))
            {
                SQLiteConnection.CreateFile(db);
                using var c = new SQLiteConnection(conn);
                c.Open();
                using var cmd = c.CreateCommand();
                cmd.CommandText = "CREATE TABLE logs (id INTEGER PRIMARY KEY AUTOINCREMENT, timestamp TEXT, elevator INTEGER, floor INTEGER, message TEXT)";
                cmd.ExecuteNonQuery();
            }
        }

        public void LogAsync(int elevatorId, int floor, string message)
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (s, e) =>
            {
                using var c = new SQLiteConnection(conn);
                c.Open();
                using var cmd = c.CreateCommand();
                cmd.CommandText = "INSERT INTO logs (timestamp,elevator,floor,message) VALUES (@t,@e,@f,@m)";
                cmd.Parameters.AddWithValue("@t", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@e", elevatorId);
                cmd.Parameters.AddWithValue("@f", floor);
                cmd.Parameters.AddWithValue("@m", message);
                cmd.ExecuteNonQuery();
            };
            bw.RunWorkerAsync();
        }

        public System.Data.DataTable GetLogs()
        {
            using var c = new SQLiteConnection(conn);
            c.Open();
            using var da = new SQLiteDataAdapter("SELECT * FROM logs ORDER BY id DESC", c);
            var dt = new System.Data.DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}