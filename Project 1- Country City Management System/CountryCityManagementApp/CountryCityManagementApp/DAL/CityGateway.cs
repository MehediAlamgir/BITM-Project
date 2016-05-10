using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CountryCityManagementApp.Models;
using System.Data.SqlClient;
using System.Data;

namespace CountryCityManagementApp.DAL
{
    public class CityGateway
    {
        private string connectionString = @"Server=(localdb)\v11.0;Database=CountryCityMS;Integrated Security=true;";

        public bool IsCityExists(City city)
        {
            bool isCityExists = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Cities WHERE name = @name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = city.Name;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isCityExists = true;

            }
            connection.Close();

            return isCityExists;

        }


        public int Save(City city)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query =
                "INSERT INTO Cities(name,about,no_of_dwellers,location,weather,country_id) VALUES(@name,@about,@no_of_dwellers,@location,@weather,@country_id)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = city.Name;
            command.Parameters.Add("about", SqlDbType.VarChar);
            command.Parameters["about"].Value = city.About;
            command.Parameters.Add("no_of_dwellers", SqlDbType.Int);
            command.Parameters["no_of_dwellers"].Value = city.NoOfDwellers;
            command.Parameters.Add("location", SqlDbType.VarChar);
            command.Parameters["location"].Value = city.Location;
            command.Parameters.Add("weather", SqlDbType.VarChar);
            command.Parameters["weather"].Value = city.Weather;
            command.Parameters.Add("country_id", SqlDbType.Int);
            command.Parameters["country_id"].Value = city.CountryId;

            connection.Open();
            int NumOfRowAffected = command.ExecuteNonQuery();
            connection.Close();

            return NumOfRowAffected;
        }

        public List<City> GetCitiesByCountryName(int country_id)
        {
            List<City> cityList = new List<City>();
            int count = 1;
            SqlConnection connection = new SqlConnection(connectionString);
            string query =
                "SELECT cityName,cityAbout,no_of_dwellers,location,weather,countryName, countryAbout FROM CountryCityView WHERE country_id = @country_id ORDER BY cityName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("country_id", SqlDbType.Int);
            command.Parameters["country_id"].Value = country_id;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

           
            while (reader.Read())
            {

                City city = new City();

                city.Id = count++;
                city.Name = reader["cityName"].ToString();
                city.About = reader["cityAbout"].ToString();
                city.NoOfDwellers = Convert.ToInt32(reader["no_of_dwellers"]);
                city.Location = reader["location"].ToString();
                city.Weather = reader["weather"].ToString();
                city.CountryName = reader["countryName"].ToString();
                city.CountryAbout = reader["countryAbout"].ToString();

                cityList.Add(city);


            }
            reader.Close();
            connection.Close();
            return cityList;
        }

        public List<City> GetAll()
        {
            List<City> cityList = new List<City>();
            int count = 1;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT cityName,no_of_dwellers,countryName FROM CountryCityView ORDER BY cityName";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

           
            while (reader.Read())
            {

                City city = new City();
                city.Id = count++;
                city.Name = reader["cityName"].ToString();
                city.NoOfDwellers = Convert.ToInt32(reader["no_of_dwellers"]);
                city.CountryName = reader["countryName"].ToString();

                cityList.Add(city);

            }

            connection.Close();

            return cityList;
        }

        public List<City> GetAllFromCountryCityView()
        {
            int count = 1;
            List<City> cityList = new List<City>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query =
                "SELECT cityName,cityAbout,no_of_dwellers,location,weather,countryName, countryAbout FROM CountryCityView ORDER BY cityName";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {

                City city = new City();
                city.Id = count++;
                city.Name = reader["cityName"].ToString();
                city.About = reader["cityAbout"].ToString();
                city.NoOfDwellers = Convert.ToInt32(reader["no_of_dwellers"]);
                city.Location = reader["location"].ToString();
                city.Weather = reader["weather"].ToString();
                city.CountryName = reader["countryName"].ToString();
                city.CountryAbout = reader["countryAbout"].ToString();

                cityList.Add(city);

            }

            connection.Close();

            return cityList;
        }

        public List<City> GetCitiesByCityName(string cityName)
        {
            List<City> cityList = new List<City>();
            int count = 1;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT cityName,cityAbout,no_of_dwellers,location,weather,countryName, countryAbout FROM CountryCityView WHERE cityName like @cityName ORDER BY cityName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("cityName", SqlDbType.VarChar);
            command.Parameters["cityName"].Value = "%" + cityName + "%";

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

           
            while (reader.Read())
            {

                City city = new City();

                city.Id = count++;
                city.Name = reader["cityName"].ToString();
                city.About = reader["cityAbout"].ToString();
                city.NoOfDwellers = Convert.ToInt32(reader["no_of_dwellers"]);
                city.Location = reader["location"].ToString();
                city.Weather = reader["weather"].ToString();
                city.CountryName = reader["countryName"].ToString();
                city.CountryAbout = reader["countryAbout"].ToString();

                cityList.Add(city);


            }
         
            connection.Close();
            return cityList;
        }

    }
}