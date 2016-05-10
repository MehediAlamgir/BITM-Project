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
    public partial class CountryEntryUI : System.Web.UI.Page
    {
        CountryManager countryManager = new CountryManager(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LoadCountries();
            }
        }

        protected void countrySaveButton_Click(object sender, EventArgs e)
        {
           
            string countryName = Request.Form["countryNameTextBox"];
          //  string countryAbout = countryAboutTextAreaEditor.InnerText;
            //  string countryAbout = Request.Form["countryAboutTextAreaEditor"];
            string countryAbout = HttpUtility.UrlEncode("Request.Form['countryAboutTextAreaEditor']");
           // string countryAbout = HttpUtility.UrlEncode("countryAboutTextAreaEditor");
           // string countryAbout = "Democratic Country";
       
           Country aCountry = new Country(countryName,countryAbout);
           string message = countryManager.Save(aCountry);
            successMsg.Text = message;


            LoadCountries();
        }
        
             protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        public void LoadCountries()
        {
            List<Country> countriesList = countryManager.GetAllCountries();
            countryGridView.DataSource = countriesList;
            countryGridView.DataBind();
        }

        public void Clear()
        {
            //countryNameTextBox.Text = "";
            
        }
        protected void countryGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}