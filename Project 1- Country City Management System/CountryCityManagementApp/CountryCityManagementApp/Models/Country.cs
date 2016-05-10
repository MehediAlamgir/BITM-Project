using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryCityManagementApp.Models
{
    public class Country
    {
        private string noOfDeweller;
        private string cityLocation;
        private string cityWeather;
        private int countryId;

        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int NoOfCities { get; set; }
        public int NoOfDwellers { get; set; }

        public Country()
        {
            
        }
        public Country(string name, string about)
        {
            this.Name = name;
            this.About = about;
        }

        public Country(string name, string about, string noOfDeweller, string cityLocation, string cityWeather, int countryId) : this(name, about)
        {
            this.noOfDeweller = noOfDeweller;
            this.cityLocation = cityLocation;
            this.cityWeather = cityWeather;
            this.countryId = countryId;
        }
    }
}