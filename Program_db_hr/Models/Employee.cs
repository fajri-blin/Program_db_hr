using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Program_db_hr.Connections;

namespace Program_db_hr.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public decimal CommissionPCT { get; set; }
        public int ManagerId { get; set; }
        public string JobId { get; set; }
        public int DepartmentId { get; set; }

        public Employee() { }

        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();
            SqlConnection connection = ConnectionDB.Get();
            connection.Open();
            try
            {
                // Create an instance of SqlCommand
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM tb_m_employees";

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var employee = new Employee();
                        employee.Id = reader.GetInt32(0);
                        employee.FirstName = reader.GetString(1);
                        employee.LastName = reader.GetString(2);
                        employee.Email = reader.GetString(3);
                        employee.PhoneNumber = reader.GetString(4);
                        employee.HireDate = reader.GetDateTime(5);
                        employee.Salary = reader.GetInt32(6);
                        employee.CommissionPCT = reader.GetDecimal(7);
                        employee.ManagerId = reader.GetInt32(8);
                        employee.JobId = reader.GetString(9);
                        employee.DepartmentId = reader.GetInt32(10);

                        employees.Add(employee);
                    }
                }
                else
                {
                    employees = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!!!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return employees;
        }
    }
}
