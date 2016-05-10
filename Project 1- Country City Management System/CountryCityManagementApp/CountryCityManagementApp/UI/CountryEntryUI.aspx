<%@ Page validateRequest="false" Language="C#" AutoEventWireup="true" CodeBehind="CountryEntryUI.aspx.cs" Inherits="CountryCityManagementApp.UI.CountryEntryUI"  %>

<!DOCTYPE html>
<html>
<head runat="server">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <meta charset="utf-8">
    <title>Country Entry</title>

     <!-- Include Font Awesome. -->
    <link href="//cdnjs.cloudflare.com/ajax/libs/font-awesome/4.4.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
   
    <!-- Include Editor style. -->
    <link href="../Editor/froala_editor_2.2.3/css/froala_editor.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/froala_style.min.css" rel="stylesheet" />
    
    <!-- Include Code Mirror style -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.3.0/codemirror.min.css">
    
    <!-- Include Editor Plugins style. -->
    <link href="../Editor/froala_editor_2.2.3/css/plugins/char_counter.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/code_view.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/colors.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/emoticons.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/file.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/fullscreen.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/image.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/image_manager.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/line_breaker.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/quick_insert.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/table.min.css" rel="stylesheet" />
    <link href="../Editor/froala_editor_2.2.3/css/plugins/video.min.css" rel="stylesheet" />


    <style type="text/css">
        #countryAboutTextAreaEditor {
            width: 235px;
            height: 138px;
        }
        .auto-style1 {
            width: 100px;
        }

         label.error {
            color: red;
            font-style: italic;
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
                <li class="active"><a href="#">Add Country</a></li>
                <li class="active"><a href="CityEntryUI.aspx">Add City</a></li>
                 <li class="">
                    <a href="ViewCitiesUI.aspx">View Cities</a>

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
                <h1>Country Entry</h1>   
            </div>
          <div class="col-sm-offset-3 col-sm-9">
                    <asp:Label ID="successMsg" runat="server" Font-Italic="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
                    
                </div>
  
            <form class="form-horizontal" id="countryForm" runat="server">
                
            <div class="form-group">
                <label for="name" class="col-sm-3 control-label">Name</label>
                <div class="col-sm-5">
                    <input type="text" class="form-control"  id="countryNameTextBox" name="countryNameTextBox" placeholder="Enter Country Name">
                </div>
            </div>
            <div class="form-group">
                <label for="countryAboutTextAreaEditor" class="col-sm-3 control-label">About</label>
                <div class="col-sm-7">
                    
                  <textarea id="countryAboutTextAreaEditor" name="countryAboutTextAreaEditor"  cols="20"></textarea>  
                    
                </div>
                  <div class="col-sm-2"></div>
            </div>
           
            
            <div class="form-group">
                <div class="col-sm-offset-3 col-sm-9">
                    <asp:Button ID="countrySaveButton" type="submit" class="btn btn-success" runat="server" Text="Save" OnClick="countrySaveButton_Click" />
                    
                    <asp:Button ID="cancelButton"  class="btn btn-danger" runat="server" Text="Cancel" OnClick="cancelButton_Click" />
                </div>
            </div>
        
    <div class="container">
        <div class="row">
            <div class="col-sm-offset-1 col-sm-10">
                 <asp:GridView ID="countryGridView" runat="server" AutoGenerateColumns="False" Height="123px" Width="900px" OnSelectedIndexChanged="countryGridView_SelectedIndexChanged">
                    
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                 <asp:TemplateField HeaderText="SL#">
                                        <ItemTemplate>
                                            <span><%#Container.DataItemIndex + 1%></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                              <asp:Label runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="About">
                                        <ItemTemplate>
                                          <asp:Label runat="server" Text='<%#Eval("About") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                        </Columns>
                    
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

                        </asp:GridView>
            </div>
            <div class="col-sm-1"></div>
        </div>
        <br /><br />
    </div>

                </form>

        </div>
   
     
    
   
    <!-- <script src="../Scripts/jquery-2.2.2.min.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    
    <!--<script src="Scripts/bootstrap.js"></script>-->
    <!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
<!-- Latest compiled JavaScript -->
<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
     <!-- Include jQuery. -->
 <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
     
    <!-- Include JS files. -->
    <script src="../Editor/froala_editor_2.2.3/js/froala_editor.min.js"></script>
    
     <!-- Include Code Mirror. -->
     <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.3.0/codemirror.min.js"></script>
     <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.3.0/mode/xml/xml.min.js"></script>
         <!-- Include Plugins. -->
    <script src="../Editor/froala_editor_2.2.3/js/plugins/align.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/char_counter.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/code_beautifier.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/code_view.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/colors.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/emoticons.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/entities.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/file.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/font_family.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/font_size.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/fullscreen.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/image.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/image_manager.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/inline_style.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/line_breaker.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/link.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/lists.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/paragraph_format.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/paragraph_style.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/quick_insert.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/quote.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/save.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/table.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/url.min.js"></script>
    <script src="../Editor/froala_editor_2.2.3/js/plugins/video.min.js"></script>

     <!-- Include Language file if we want to use it. -->
    <script src="../Editor/froala_editor_2.2.3/js/languages/ro.js"></script>

        <script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.13.0/jquery.validate.js"></script>
    
    
     <!-- Initialize the editor. -->
     <script>
         
         $(function() {
             $('#countryAboutTextAreaEditor').froalaEditor()
             heightMax: 500
             width:800
         });

     </script>


 
    <script>
        $(document).ready(function () {
            $("#countryForm").validate({
                ignore: [],
                rules: {
                    countryNameTextBox: "required",
                    countryAboutTextAreaEditor: {
                        required: true
                    }
                   
                },
                messages: {
                    countryNameTextBox: "Please provide your name.",
                    countryAboutTextAreaEditor: {
                        required: "Please provide description for  country."
                        
                    }
                   ,
                   
                }
            });
        });
    </script>
</body>

</html>
