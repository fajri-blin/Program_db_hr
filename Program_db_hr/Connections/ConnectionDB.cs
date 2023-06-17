using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_db_hr.Connections;

public class ConnectionDB
{
    private static string connectionString = "Data Source=LAPTOP-SJCEEP0M;Database = db_hr; Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public static SqlConnection Get()
    {
    return new SqlConnection(connectionString);
    }

}

