using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace CountryCityManagementApp.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int NoOfDwellers { get; set; }
        public string Weather { get; set; }
        public string Location { get; set; }
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string CountryAbout { get; set; }

        public City()
        {
            
        }
        public City(string name, string about, int noOfDwellers, string location, string weather, int countryId)
        {
            this.Name = name;
            this.About = about;
            this.NoOfDwellers = noOfDwellers;
            this.Location = location;
            this.Weather = weather;
            this.CountryId = countryId;

        }
    }
}