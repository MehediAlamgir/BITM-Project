using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CountryCityManagementApp.BLL;
using CountryCityManagementApp.Models;

namespace CountryCityManagementApp.UI
{
    public partial class ViewCitiesUI : System.Web.UI.Page
    {
        CityManager cityManager = new CityManager();
        CountryManager countryManager = new CountryManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<City> cityList = cityManager.LoadCityDetailsFromView();

            viewCitiesGridView.DataSource = cityList;
            viewCitiesGridView.DataBind();

          //  if (IsPostBack == false)
          //  {
                List<Country> countryList = countryManager.LoadCountriesToDropdown();

                countryListDropDownList.DataSource = countryList;
                countryListDropDownList.DataValueField = "Id";
                countryListDropDownList.DataTextField = "Name";
                countryListDropDownList.DataBind();
          //  }

        }
     

        protected void searchButton_Click(object sender, EventArgs e)
        {
            List<City> list = null;


            if (cityNameRadioButton.Checked)
            {
                string cityName = cityNameTextBox.Text;

                list = cityManager.SearchCitiesByCityname(cityName);

            }
            else if (countryNameRadioButton.Checked)
            {
                int countryId = Convert.ToInt32(countryListDropDownList.Text);

                list = cityManager.SearchCitiesByCountryName(countryId);
            }

            if (list.Count == 0)
            {
                successMsg.Text = "Sorry!!  Not Found.";

                viewCitiesGridView.DataSource = null;
                viewCitiesGridView.DataBind();
            }
            else
            {
                successMsg.Text = "";
                viewCitiesGridView.DataSource = list;
                viewCitiesGridView.DataBind();
            }

         
        }
    }
}