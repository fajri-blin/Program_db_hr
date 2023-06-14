using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr
{
    public class ConnectionDB
    {
        static string connectionString = "Data Source=LAPTOP-SJCEEP0M;Database = db_hr; Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        static SqlConnection conn;

        public static SqlConnection GetConnection()
        {
            conn = new SqlConnection(connectionString);
            return conn;
        }

    }
}
