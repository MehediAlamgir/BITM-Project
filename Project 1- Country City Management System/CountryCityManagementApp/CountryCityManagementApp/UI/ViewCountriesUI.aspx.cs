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
    public partial class ViewCountriesUI : System.Web.UI.Page
    {
        CountryManager countryManager = new CountryManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            viewCountriesGridView.DataSource = countryManager.GetCountOfAllCityDwellers();
            viewCountriesGridView.DataBind();
        }


        protected void searchButton_Click(object sender, EventArgs e)
        {
            List<Country> countriesList = null;

            if (countryNameTextBox.Text == "")
            {
                viewCountriesGridView.DataSource = countryManager.GetCountOfAllCityDwellers();
                viewCountriesGridView.DataBind();
            }
            else
            {
                string name = countryNameTextBox.Text;
                countriesList = countryManager.GetCountriesByCountryName(name);

                if (countriesList.Count == 0)
                {
                    successMsg.Text = "Sorry!! No Data Found.";
                    viewCountriesGridView.DataSource = null;
                    viewCountriesGridView.DataBind();
                }

                else
                {
                    successMsg.Text = "";
                    viewCountriesGridView.DataSource = countriesList;
                    viewCountriesGridView.DataBind();
                }


            }
        }
    }
}