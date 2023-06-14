﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Program_db_hr
{
    public class Job
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        public Job(){}

        public static void GetAllJobs()
        {
            var jobs = new List<Job>();
            SqlConnection connection = ConnectionDB.GetConnection();
            connection.Open();

            try
            {
                // Create an instance of SqlCommand
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM tb_m_jobs";

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new Job();
                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.MinSalary = reader.GetInt32(2);
                        job.MaxSalary = reader.GetInt32(3);
                        jobs.Add(job);
                    }
                }else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                // Display All Jobs
                foreach (var job in jobs)
                {
                    Console.WriteLine(job.Id + " " + job.Title + " " + job.MinSalary + " " + job.MaxSalary);
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }


    }
}
