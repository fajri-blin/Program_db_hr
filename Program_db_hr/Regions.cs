using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Program_db_hr
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Region(int id, string name_region)
        {
            Id = id;
            Name = name_region;
        }

        public static void GetAllRegions()
        {
            var regions = new List<Region>();
            SqlConnection connection = ConnectionDB.GetConnection();
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
                    Console.WriteLine("Data Not Found");
                }
                reader.Close();

                // Display All Regions
                foreach (Region region in regions)
                {
                    Console.WriteLine($"Id: {region.Id} - Name: {region.Name}");
                }
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Connection Failed");
            }
            connection.Close();
        }

        public static void GetRegionById(int id)
        {
            var regions = new List<Region>();
            SqlConnection conn = ConnectionDB.GetConnection();
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
                    Console.WriteLine("Data Not Found");
                }
                reader.Close();

                // Display All Regions
                foreach (Region region in regions)
                {
                    Console.WriteLine($"Id: {region.Id} - Name: {region.Name}");
                
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Connection Failed");
            }
            conn.Close();
        }

        public static void CreateRegion(string name)
        {
            int result = 0;
            SqlConnection conn = ConnectionDB.GetConnection();
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
                if(result > 0)
                {
                    Console.WriteLine($"Region by name = {name}, has been created");
                }
                else{
                    Console.WriteLine("Create Failed");
                }

                transaction.Commit();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }catch(Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            conn.Close();
        }

        public static void UpdateRegion(int id, string name)
        {    
            int result = 0;
            SqlConnection conn = ConnectionDB.GetConnection();
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
                if(result > 0)
                {
                    Console.WriteLine($"Region by ID={id} has been updated");
                }
                else{
                    Console.WriteLine("Update Failed");
                }

                // Commit Transaction
                transaction.Commit();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }catch(Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
        }
        
        public static void DeleteRegion(int id)
        {
            SqlConnection conn = ConnectionDB.GetConnection();
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
                int rowAffected = cmd.ExecuteNonQuery();
                if(rowAffected > 0)
                {
                    Console.WriteLine($"Region by ID={id} has been deleted");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }

                // Commit Transaction
                transaction.Commit();
            
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }catch(Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
        }
    }
}
