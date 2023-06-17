using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Program_db_hr.Connections;

namespace Program_db_hr.Models
{
    public class History
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public int? EndDate { get; set; }
        public int DepartmentId { get; set; }
        public string JobId { get; set; }

        public History() { }

        public List<History> GetAll()
        {
            var histories = new List<History>();
            SqlConnection connect = ConnectionDB.Get();
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
                        history.EndDate = reader.IsDBNull(reader.GetOrdinal("end_date")) ? null : Convert.ToInt32(reader["end_date"]);
                        history.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        history.JobId = reader["job_id"].ToString();
                        histories.Add(history);
                    }
                }
                else
                {
                    histories = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            connect.Close();
            return histories;
        }
    }
}
