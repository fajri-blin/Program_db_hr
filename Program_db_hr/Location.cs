using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Program_db_hr
{
    public class Location
    {
        public int Id { get; set; }
        public string StreetAdress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }
    
        public Location(){}

        public Location(int id, string streetAdress, string postalCode, string city, string stateProvince, string countryId)
        {
            Id = id;
            StreetAdress = streetAdress;
            PostalCode = postalCode;
            City = city;
            StateProvince = stateProvince;
            CountryId = countryId;
        }

        public static void GetAllLocations()
        {
            var Base = new List<Location>();
            SqlConnection connection = ConnectionDB.GetConnection();
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
                        data.StreetAdress = reader.GetString(1);
                        data.PostalCode = reader.GetString(2);
                        data.City = reader.GetString(3);
                        data.StateProvince = reader.GetString(4);
                        Base.Add(data);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found");
                }
                reader.Close();

                // Display All Regions
                foreach (Location location in Base)
                {
                    Console.WriteLine(location.Id + " " + location.StreetAdress + " " + location.PostalCode + " " + location.City + " " + location.StateProvince + " " + location.CountryId);
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

    }
}


