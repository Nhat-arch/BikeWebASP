using MySql.Data.MySqlClient;
namespace App.Models
{
    public static class DataProvider
    {
        // connect voi db
        static string connStr = "Server=127.0.0.1;Database=doan_bike1;User Id=root;Password=''";
        // tao ket noi
        public static MySqlConnection Connect()
        {
            var conn = new MySqlConnection(connStr);
            conn.Open();
            return conn;
        }
        // doc du lieu
        public static MySqlDataReader Read(string comm, MySqlConnection conn, params MySqlParameter[] par)
        {
            var com = new MySqlCommand(comm, conn);
            com.Parameters.AddRange(par);
            return com.ExecuteReader();
        }
        // thuc thi lenh
        public static int Execute(string comm, MySqlConnection conn, params MySqlParameter[] par)
        {
            var com = new MySqlCommand(comm, conn);
            com.Parameters.AddRange(par);
            return com.ExecuteNonQuery();
        }
    }
}