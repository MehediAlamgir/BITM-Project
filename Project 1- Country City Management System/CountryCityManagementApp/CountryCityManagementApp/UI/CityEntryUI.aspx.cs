using CountryCityManagementApp.BLL;
using CountryCityManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CountryCityManagementApp.UI
{
    public partial class CityEntryUI : System.Web.UI.Page
    {
        CityManager cityManager = new CityManager();
        CountryManager countryManager = new CountryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCities();
                LoadCountriesToDropdown();
            }

        }
      
        protected void citySaveButton_Click(object sender, EventArgs e)
        {
            string cityName = Request.Form["cityName"]; 

            string cityAbout = HttpUtility.UrlEncode("Request.Form['cityAboutTextAreaEditor']");

            int noOfDeweller = Convert.ToInt32(Request.Form["noOfDeweller"]);
            string cityLocation = Request.Form["cityLocation"];
            string cityWeather = Request.Form["cityWeather"];
          //  int countryId = Convert.ToInt32(countryDropDownList.SelectedValue);
            int countryId = Convert.ToInt32(countryDropDownList.SelectedValue);
         //   int  countryId = Convert.ToInt32(countryDropDownList.Text);


            City city = new City(cityName, cityAbout, noOfDeweller, cityLocation, cityWeather, countryId);
           

            successMsg.Text = cityManager.Save(city);

            LoadCities();

        }

        private void LoadCities()
        {
            List<City> list = cityManager.LoadCities();

            cityGridView.DataSource = list;
            cityGridView.DataBind();
        }


        private void LoadCountriesToDropdown()
        {
            List<Country> list = countryManager.LoadCountriesToDropdown();

            countryDropDownList.DataSource = list;
            countryDropDownList.DataValueField = "Id";
            countryDropDownList.DataTextField = "Name";
            countryDropDownList.DataBind();
        }

        protected void cityCancelButton_Click(object sender, EventArgs e)
        {


        }

        protected void countryGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}