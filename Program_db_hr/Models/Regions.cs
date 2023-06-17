using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Program_db_hr.Connections;

namespace Program_db_hr.Models
{
    public class Region
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public Region(int id, string name_region)
        {
            Id = id;
            Name = name_region;
        }

        public Region() { }

        public List<Region> GetAll()
        {
            var regions = new List<Region>();
            SqlConnection connection = ConnectionDB.Get();
            connection.Open();
            try
            {
                // Create an instance of SqlCommand
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM tb_m_regions";


                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var region = new Region(
                            reader.GetInt32(0),
                            reader.GetString(1)
                        );
                        regions.Add(region);
                    }
                }
                else
                {
                    regions = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Connection Failed");
            }
            connection.Close();
            return regions;

        }

        public Region GetById(int id)
        {
            var region = new Region();
            SqlConnection conn = ConnectionDB.Get();
            conn.Open();
            try
            {
                // Create an instance of SqlCommand
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM tb_m_regions WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);


                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);
                }
                else
                {
                    region = null;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Connection Failed");
            }
            conn.Close();
            return region;
        }

        public int Create(string name)
        {
            int result = 0;
            SqlConnection conn = ConnectionDB.Get();
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                // Create an instance for command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO tb_m_regions(nama) VALUES (@name)";
                cmd.Transaction = transaction;

                // Create Parameter
                SqlParameter param_name = new SqlParameter("@name", name);

                // Add Parameter
                cmd.Parameters.Add(param_name);

                // Execute Command
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            conn.Close();
            return result;
        }

        public int Update(int id, string name)
        {
            int result = 0;
            SqlConnection conn = ConnectionDB.Get();
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                // Create an instance for command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE tb_m_regions SET nama = @name WHERE id = @id";
                cmd.Transaction = transaction;

                // Create Parameter
                SqlParameter param_id = new SqlParameter("@id", id);
                SqlParameter param_name = new SqlParameter("@name", name);

                // Add Parameter
                cmd.Parameters.Add(param_id);
                cmd.Parameters.Add(param_name);

                // Execute Command
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            return result;
        }

        public int Delete(int id)
        {
            int result = 0;
            SqlConnection conn = ConnectionDB.Get();
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                // Create an instance for command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM tb_m_regions WHERE id = @id";
                cmd.Transaction = transaction;

                // Create Parameter
                SqlParameter param_id = new SqlParameter("@id", id);

                // Add Parameter
                cmd.Parameters.Add(param_id);

                // Execute Command
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            return result;
        }
    }
}
