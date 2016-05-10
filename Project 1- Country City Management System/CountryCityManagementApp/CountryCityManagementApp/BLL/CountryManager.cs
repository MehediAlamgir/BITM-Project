using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CountryCityManagementApp.DAL;
using CountryCityManagementApp.Models;

namespace CountryCityManagementApp.BLL
{
    public class CountryManager
    {
        CountryGateway countryGateway = new CountryGateway();

        public string Save(Country country)
        {

            string message = "";

                bool isCountryExists = countryGateway.IsCountryExists(country);

                if (isCountryExists)
                    message = "Country Already Exists";

                else
                {
                    int rowsAffected = countryGateway.Save(country);

                    if (rowsAffected > 0)
                        message = "Country Saved Successfully";
                    else
                    {
                        message = "Sorry!! Country Didn't Save";
                    }
                }

            

            return message;
        }

        public List<Country> GetAllCountries()
        {
            List<Country> countriesList = countryGateway.GetAllCountries();
            return countriesList;
        }

        public List<Country> LoadCountriesToDropdown()
        {
            return countryGateway.GetAllForDropDown();
        }

        public List<Country> GetCountOfAllCityDwellers()
        {
            return countryGateway.GetCountOfAllCityDwellers();
        }

        public List<Country> GetCountriesByCountryName(string name)
        {
            return countryGateway.GetCountriesByCountryName(name);
        }
    }
}