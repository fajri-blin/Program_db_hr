using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Program_db_hr.Connections;

namespace Program_db_hr.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }

        public Department() { }

        public List<Department> GetAll()
        {
            var departments = new List<Department>();
            SqlConnection connection = ConnectionDB.Get();
            connection.Open();

            try
            {
                // Create an instance of SqlCommand
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_departments";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var department = new Department();
                        department.Id = reader.GetInt32(0);
                        department.Name = reader.GetString(1);

                        if (!reader.IsDBNull(2))
                        {
                            department.LocationId = reader.GetInt32(2);
                        }
                        else
                        {
                            department.LocationId = 0; // Assign a default value or handle it accordingly
                        }

                        if (!reader.IsDBNull(3))
                        {
                            department.ManagerId = reader.GetInt32(3);
                        }
                        else
                        {
                            department.ManagerId = 0; // Assign a default value or handle it accordingly
                        }

                        departments.Add(department);
                    }
                }
                else
                {
                    departments = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
            return departments;
        }


    }
}
