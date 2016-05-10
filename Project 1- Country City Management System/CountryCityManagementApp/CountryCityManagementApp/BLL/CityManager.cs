using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CountryCityManagementApp.Models;
using CountryCityManagementApp.DAL;

namespace CountryCityManagementApp.BLL
{
    public class CityManager
    {
        CityGateway cityGateway = new CityGateway();
        public string Save(City city)
        {
            string message = "";
            
            bool isCityExist = cityGateway.IsCityExists(city);

            if (isCityExist)
            {
                message = "City Already Exist";

            }
            else {
                int rowsAffected = cityGateway.Save(city);

                if (rowsAffected > 0)
                    message = "City Saved Successfully";
                else
                {
                    message = "Sorry!! City Didn't Save";
                }
            }


            return message;
        }

        public List<City> LoadCities()
        {
            List<City> cities = cityGateway.GetAll();
            return cities;
        }

      
        public List<City> LoadCityDetailsFromView()
        {
            List<City> cityDetailsList = cityGateway.GetAllFromCountryCityView();
            return cityDetailsList;
        }

        public List<City> SearchCitiesByCityname(string name)
        {
            List<City> cities = cityGateway.GetCitiesByCityName(name);
            return cities;
        }

        public List<City> SearchCitiesByCountryName(int id)
        {
            List<City> cities = cityGateway.GetCitiesByCountryName(id);
            return cities;
        }

    }
}