using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Program_db_hr.Connections;
using Program_db_hr.Views;

namespace Program_db_hr.Models;

public class Country
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int IdRegions { get; set; }

    public Country() { }

    public Country(string id, string name, int idRegions)
    {
        if (id.Length > 3)
        {
            throw new ArgumentException("The Length of ID must not exceed 2 characters");
        }
        Id = id;

        Name = name;
        IdRegions = idRegions;
    }

    public List<Country> GetAll()
    {
        var countries = new List<Country>();
        SqlConnection connection = ConnectionDB.Get();
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
                    country.IdRegions = reader.GetInt32(2);
                    countries.Add(country);
                }
            }
            else
            {
                countries = null;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            ErrorViews.ErrorHandlings(ex);
        }
        connection.Close();
        return countries;
    }

    public Country GetById(string id)
    {
        var country = new Country();
        SqlConnection connection = ConnectionDB.Get();
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
                reader.Read();
                country.Id = reader.GetString(0);
                country.Name = reader.GetString(1);
                country.IdRegions = reader.GetInt32(2);
            }
            else
            {
                country = null;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            ErrorViews.ErrorHandlings(ex);
        }
        return country;
    }

    public int Create(string id, string name, int regionId)
    {
        int result = 0;
        SqlConnection connection = ConnectionDB.Get();
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
            }
        }
        catch (Exception ex)
        {
            try
            {
                transaction.Rollback();
            }
            catch (Exception exRollback)
            {
                ErrorViews.ErrorHandlings(exRollback);
            }
        }
        connection.Close();
        return result;
    }

    public int Update(string search,string id, string name, int regionId)
    {
        int result = 0;
        SqlConnection connection = ConnectionDB.Get();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            //Create an instance for command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "UPDATE tb_m_countries SET id = @id, nama = @name, region_id = @regionId WHERE id = @search";
            cmd.Transaction = transaction;
            cmd.Parameters.AddWithValue("@search", search);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@regionId", regionId);

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
            ErrorViews.ErrorHandlings(ex);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exRollback)
            {
                ErrorViews.ErrorHandlings(exRollback);
            }
        }
        return result;
    }

    public int Delete(string id)
    {
        int result = 0;
        SqlConnection connection = ConnectionDB.Get();
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
            }
            else 
            { 
                transaction.Rollback(); 
            }    
        }
        catch (Exception ex)
        {
            ErrorViews.ErrorHandlings(ex);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exRollback)
            {
                ErrorViews.ErrorHandlings(exRollback);
            }
        }
        return result;
    }

}

