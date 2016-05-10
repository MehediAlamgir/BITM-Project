<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCitiesUI.aspx.cs" Inherits="CountryCityManagementApp.UI.ViewCitiesUI" %>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Title of the document</title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        .innerFieldset {
          font-size:15px;
          padding:10px;
          width:550px;
          line-height:1.8;
         
        }
    </style>
</head>
<body>

    <div class="container">
         <nav class="navbar navbar-nav  naavbar-inverse">
          <div class="container">
            <div class="navbar-header">
              <a class="navbar-brand" href="#">BitmProject</a>
            </div>
            <ul class="nav navbar-nav navbar-right">
              <li class="active"><a href="index.aspx">Home</a></li>
                <li class="">
                    <a href="CountryEntryUI.aspx">Country Entry</a>
                 </li>
                <li class="">
                    <a href="CityEntryUI.aspx">City Entry</a>

                </li>
                <li class="">
                    <a href="#">View Cities</a>

                </li>
                <li class="">
                    <a href="ViewCountriesUI.aspx">View Countries</a>

                </li>
                 
            </ul>
    
          </div>
        </nav>

    </div>
 <div class="container" style="background-color:#F4F3EE;">
           
              
           <div class="page-header">
                <h1>View Cities</h1>   
            </div>
            <div class="col-sm-offset-3 col-sm-9">
                    <asp:Label ID="successMsg" runat="server" Font-Italic="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
                    
                </div>
  
            <form class="form-horizontal" id="cityForm" runat="server">
                <div class="col-sm-offset-3 col-sm-9">
                    <fieldset>
                    <legend>Search Criteria</legend>
                    <div class="form-group ">
                             <asp:RadioButton Class="col-sm-2" ID="cityNameRadioButton" runat="server" Checked="True" GroupName="selectSearchOption" Text="City Name" />
                            <div class="col-sm-5">
                             <asp:TextBox ID="cityNameTextBox"  runat="server" style="margin-bottom: 0px"></asp:TextBox>
                       <!--     <input type="text" class="form-control"  id="cityName" name="cityName" placeholder="Enter City Name ">  -->
                           </div>   
                    
                    </div>
                         <div class="form-group ">
                             <asp:RadioButton Class="col-sm-2" ID="countryNameRadioButton" runat="server" Checked="True" GroupName="selectSearchOption" Text="Country Name" />
                            <div class="col-sm-5">
                    
                            <asp:DropDownList ID="countryListDropDownList" class="form-control" runat="server" Height="35px" style="margin-left: 31px" Width="198px"></asp:DropDownList>
                           </div> 
                             <div class=" col-sm-5">
                                 <asp:Button ID="searchButton"  class="btn btn-info" runat="server" Text="Search" Width="122px" OnClick="searchButton_Click" />
                                 
                            
                           </div>   
                    
                    </div>
                          
                  
            

                </fieldset>
                

                </div>
               
        
    <div class="container">
        <div class="row">
            <div class="col-sm-offset-1 col-sm-10">
               <asp:GridView ID="viewCitiesGridView" runat="server" AutoGenerateColumns="False" Height="175px" style="margin-left: 16px" Width="830px" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="5" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                     <asp:TemplateField HeaderText="SL#">
                        <ItemTemplate>
                             <span><%#Container.DataItemIndex + 1%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="City Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="About">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("About") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="No.of dwellers">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("NoOfDwellers") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Location">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Location") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Weather">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Weather") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Country">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("CountryName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="About Country">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("CountryAbout") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="Blue" />
                <HeaderStyle BackColor="Blue" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                
        </asp:GridView>
            </div>
            <div class="col-sm-1"></div>
        </div>
        <br /><br />
    </div>

                </form>

        </div>

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
<!-- Latest compiled JavaScript -->
<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</body>
</html>







