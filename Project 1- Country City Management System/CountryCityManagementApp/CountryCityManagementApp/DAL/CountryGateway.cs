using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CountryCityManagementApp.Models;

namespace CountryCityManagementApp.DAL
{

    public class CountryGateway
    {
        string connectionString = @"Server=(localdb)\v11.0;Database=CountryCityMS;Integrated Security=true;";

        public bool IsCountryExists(Country country)
        {
            bool isCountryExists = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT name FROM Countries WHERE name= @name ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = country.Name;


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isCountryExists = true;
            }
            connection.Close();
            
            return isCountryExists;
        }

        public int Save(Country country)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Countries (name,about) VALUES(@name, @about)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();
            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = country.Name;
            command.Parameters.Add("about", SqlDbType.VarChar);
            command.Parameters["about"].Value = country.About;

            
            connection.Open();
            int rowsEffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsEffected;
        }

        public List<Country> GetAllCountries()
        {
            int count = 1;
            List<Country> countryList = new List<Country>();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Countries ORDER BY name";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
               
                string name = reader["name"].ToString();
                string about = reader["about"].ToString();

                Country aCountry = new Country(name,about);
                aCountry.Id = count++;

                countryList.Add(aCountry);

            }

            connection.Close();


            return countryList;
        }

        public List<Country> GetAllForDropDown()
        {
            List<Country> countriesList = new List<Country>();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Countries ORDER BY name";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
               
                string name = reader["name"].ToString();
                string about = reader["about"].ToString();

                Country aCountry = new Country(name,about);
                aCountry.Id = Convert.ToInt32(reader["id"].ToString());

                countriesList.Add(aCountry);

            }

            connection.Close();
            reader.Close();

            return countriesList;
        }

        public List<Country> GetCountOfAllCityDwellers() 
        {
            int count = 1;
            List<Country> countriesList = new List<Country>();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM CountCityDwellersView ORDER BY name";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                Country country = new Country();

                country.Id = count++;
                country.Name = reader["name"].ToString();
                country.About = reader["about"].ToString();
                country.NoOfCities = Convert.ToInt32(reader["TotalCity"].ToString());
                country.NoOfDwellers = Convert.ToInt32(reader["TotalDwellers"].ToString());

                countriesList.Add(country);

            }

            connection.Close();
            reader.Close();

            return countriesList;
        }

        public List<Country> GetCountriesByCountryName(string name)
        {
            int count = 1;
            List<Country> countriesList = new List<Country>();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM CountCityDwellersView where name like @name ORDER BY name";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = "%" + name + "%";


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                Country country = new Country();

                country.Id = count++;
                country.Name = reader["name"].ToString();
                country.About = reader["about"].ToString();
                country.NoOfCities = Convert.ToInt32(reader["TotalCity"].ToString());
                country.NoOfDwellers = Convert.ToInt32(reader["TotalDwellers"].ToString());

                countriesList.Add(country);

            }

            connection.Close();
            reader.Close();

            return countriesList;
        }

    }
}