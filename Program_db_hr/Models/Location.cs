using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Program_db_hr.Connections;

namespace Program_db_hr.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string StreetAdress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }

        public Location() { }

        public Location(int id, string streetAdress, string postalCode, string city, string stateProvince, string countryId)
        {
            Id = id;
            StreetAdress = streetAdress;
            PostalCode = postalCode;
            City = city;
            StateProvince = stateProvince;
            CountryId = countryId;
        }

        public List<Location> GetAll()
        {
            var locations = new List<Location>();
            SqlConnection connection = ConnectionDB.Get();
            connection.Open();
            try
            {
                // Create an instance of SqlCommand
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM tb_m_locations";


                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var data = new Location();
                        data.Id = reader.GetInt32(0);
                        data.StreetAdress = reader.GetString(1);
                        data.PostalCode = reader.GetString(2);
                        data.City = reader.GetString(3);
                        data.StateProvince = reader.GetString(4);
                        data.CountryId = reader.GetString(5);
                        locations.Add(data);
                    }
                }
                else
                {
                    locations = null;
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
            return locations;
        }

    }
}


