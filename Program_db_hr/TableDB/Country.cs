using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Program_db_hr.TableDB
{
    public class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public Country() { }

        public Country(string id, string name, int idRegions)
        {
            if (id.Length > 3)
            {
                throw new ArgumentException("The Length of ID must not exceed 2 characters");
            }
            Id = id;

            Name = name;
            RegionId = idRegions;
        }

        public List<Country> GetAllCountries()
        {
            var countries = new List<Country>();
            SqlConnection connection = ConnectionDB.GetConnection();
            connection.Open();
            try
            {
                // Create an instance of command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_countries";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Country();
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionId = reader.GetInt32(2);
                        countries.Add(country);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();

                // Display All Countries
                /*                foreach (Country country in countries)
                                {
                                    Console.WriteLine($"Country ID: {country.Id} | Country Name: {country.Name} | Region ID: {country.IdRegions}");
                                }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Error in GetAllCountries()");
            }
            connection.Close();
            return countries;
        }

        public Country GetCountryById(string id)
        {
            Country country = null;
            SqlConnection connection = ConnectionDB.GetConnection();
            connection.Open();
            try
            {
                // Create an instance of command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_countries WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        country = new Country();
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionId = reader.GetInt32(2);
                        /*                        Console.WriteLine($"Country ID: {country.Id} | Country Name: {country.Name} | Region ID: {country.IdRegions}");*/
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Error in GetCountryById()");
            }
            return country;
        }

        public void CreateCountry(string id, string name, int regionId)
        {
            int result = 0;
            SqlConnection connection = ConnectionDB.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Create an instance of command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_countries(id, nama, region_id) VALUES (@id, @name, @regionId)";
                command.Transaction = transaction;
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@regionId", regionId);

                result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    transaction.Commit();
                    Console.WriteLine("Insert Success");
                }
                else
                {
                    Console.WriteLine("Insert Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exRollback)
                {
                    Console.WriteLine(exRollback.Message);
                }
            }
            connection.Close();
        }

        public void UpdateCountry(string id, string name, int regionId)
        {
            int result = 0;
            SqlConnection connection = ConnectionDB.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Create an instance for command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE tb_m_countries SET id = @id, nama = @name, region_id = @regionId WHERE id = @id";
                cmd.Transaction = transaction;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@regionId", regionId);

                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    transaction.Commit();
                    Console.WriteLine("Update Success");
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exRollback)
                {
                    Console.WriteLine(exRollback.Message);
                }
            }
        }

        public void DeleteCountry(string id)
        {
            int result = 0;
            SqlConnection connection = ConnectionDB.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                //Create an instance for command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM tb_m_countries WHERE id = @id";
                cmd.Transaction = transaction;
                cmd.Parameters.AddWithValue("@id", id);

                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    transaction.Commit();
                    Console.WriteLine("Delete Success");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exRollback)
                {
                    Console.WriteLine(exRollback.Message);
                }
            }
        }

    }
}
