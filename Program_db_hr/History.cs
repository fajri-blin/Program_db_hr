using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Program_db_hr
{
    public class History
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public int? EndDate { get; set; }
        public int DepartmentId { get; set; }
        public string JobId { get; set; }

        public History() { }

        public static void GetAllHistories()
        {
            var histories = new List<History>();
            SqlConnection connect = ConnectionDB.GetConnection();
            connect.Open();

            try
            {
                // Create an instance of SqlCommand
                SqlCommand command = new SqlCommand();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM tb_tr_histories";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var history = new History();
                        history.StartDate = Convert.ToDateTime(reader["start_date"]);
                        history.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        history.EndDate = reader.IsDBNull(reader.GetOrdinal("end_date")) ? (int?)null : Convert.ToInt32(reader["end_date"]);
                        history.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        history.JobId = reader["job_id"].ToString();
                        histories.Add(history);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();

                //Display All Histories
                foreach(History history in histories)
                {
                    Console.WriteLine(history.StartDate + " " + history.EmployeeId + " " + history.EndDate + " " + history.DepartmentId + " " + history.JobId);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            connect.Close();
        }
    }
}
