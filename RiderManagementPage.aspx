<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RiderManagementPage.aspx.cs" Inherits="RiderManagementPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=iso-8859-1" http-equiv="content-type" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Rider Management - DWA Model Case</title>
    <style type="text/css">
        #form1 {
            height: 1095px;
        }
        .div_right_details_ROW {
            height: 77px;
            width: 456px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Rider Management</h1>
                </div>

                <div id="div_header_LOGIN_STATUS">
                    <asp:Label ID="lbLoginInfo" runat="server"></asp:Label>.<br />
                    <asp:LinkButton ID="btLogout" runat="server" CssClass="logout_link" OnClick="btLogout_Click" CausesValidation="False">LOGOUT</asp:LinkButton>
                </div>
            </div>



            <div id="div_LEFT">
                <div id="div_NAV">
                    
                    <asp:HyperLink ID="hyperLinkHomePage" runat="server" CssClass="current_page_link" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink><br />
                    <asp:HyperLink ID="hyperLinkRiderLists" runat="server" CssClass="other_page_link" NavigateUrl="~/RiderListsPage.aspx">Rider Lists</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="hyperLinkBrevetResults" runat="server" CssClass="other_page_link" NavigateUrl="~/BrevetResults.aspx">Brevet Results</asp:HyperLink>
                    <br />
                    <br />
                    <br />
                    <asp:HyperLink ID="hyperLinkBrevetRegistration" runat="server" CssClass="other_page_link" NavigateUrl="~/BrevetRegistration.aspx">Brevet Registration</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hyperLinkBrevetManagement" runat="server" CssClass="other_page_link" NavigateUrl="~/BrevetManagement.aspx">Brevet Management</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="hyperLinkRiderManagement" runat="server" CssClass="other_page_link" NavigateUrl="~/RiderManagementPage.aspx">Rider Management</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="hyperLinkClubManagement" runat="server" CssClass="other_page_link" NavigateUrl="~/ClubManagementPage.aspx">Club Management</asp:HyperLink>
                    <br />
                    <br />
                    <br />
                    <asp:HyperLink ID="hyperLinkUpdateResults" runat="server" CssClass="other_page_link" NavigateUrl="~/UpdateResults.aspx">Update Results</asp:HyperLink>
                    <br />
                </div>
            </div>



            <div id="div_CENTER">
                <div class="div_center_HEADER">
                   Riders
                </div>

                <div id="div_center_LISTBOX">
                    <asp:ListBox ID="listBoxRiders" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listBoxRiders_SelectedIndexChanged" CssClass="listbox_main"></asp:ListBox>
                </div>

                <div id="div_center_IMAGE">
                    <img id="main_image" src="images/rider.png" alt="Department manegement image" />
                </div>
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Rider Details
                </div>

                <div id="div_right_DETAILS">

                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbRiderID" runat="server" Text="Rider ID:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbRiderID" runat="server" CssClass="detail_textbox" MaxLength="4"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRiderId"
                            runat="server" ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbRiderID" CssClass="validatorMessage">
                        </asp:RequiredFieldValidator>
                    </div>


                                <div class="div_right_details_ROW">
                        <asp:Label ID="lbSurname" runat="server" Text="Surname:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbSurname" runat="server" CssClass="detail_textbox" MaxLength="50"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbSurname" CssClass="validatorMessage">
                        </asp:RequiredFieldValidator>
                        
                       
                    </div>


                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbGivenName" runat="server" Text="Given name:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbFirstName" runat="server" CssClass="detail_textbox" MaxLength="50"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbFirstName" CssClass="validatorMessage">
                        </asp:RequiredFieldValidator>
                      
                       
                    </div>
                                <div class="div_right_details_ROW">
                        <asp:Label ID="lbGender" runat="server" Text="Gender:" CssClass="detail_label"></asp:Label>
                                    <asp:RadioButton ID="rbFemale" runat="server" Text="Female" AutoPostBack="True" GroupName="Gender" />
                                    <asp:RadioButton ID="rbMale" runat="server" Text="Male" GroupName="Gender" />

                       
                    </div>




                                <div class="div_right_details_ROW">
                        <asp:Label ID="lbPhone" runat="server" Text="Phone:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbPhone" runat="server" CssClass="detail_textbox" MaxLength="50"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbPhone" CssClass="validatorMessage">
                        </asp:RequiredFieldValidator>
                        
                       
                    </div>
                                <div class="div_right_details_ROW">
                        <asp:Label ID="lb" runat="server" Text="Name:" CssClass="detail_label"></asp:Label>
                                    <asp:DropDownList ID="DropDownListClubs" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                      
                       
                    </div>
                   
                    <div class="div_right_details_ROW">
                        <asp:Label ID="lbUsername" runat="server" Text="Username:" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbUsername" runat="server" CssClass="detail_textbox" MaxLength="10"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbUsername" CssClass="validatorMessage">
                        </asp:RequiredFieldValidator>
                    </div>
                     <div class="div_right_details_ROW">
                        <asp:Label ID="lbPassword" runat="server" Text="Password" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbPassword" runat="server" CssClass="detail_textbox" MaxLength="10" TextMode="Password"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbPassword" CssClass="validatorMessage">
                        </asp:RequiredFieldValidator>
                    </div>
                     <div class="div_right_details_ROW">
                        <asp:Label ID="lbEmail" runat="server" Text="Email" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbEmail" runat="server" CssClass="detail_textbox" MaxLength="20"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbEmail" CssClass="validatorMessage">
                        </asp:RequiredFieldValidator>
                    </div>
                     <div class="div_right_details_ROW">
                        <asp:Label ID="lbReEnter" runat="server" Text="ReEnter Pwd" CssClass="detail_label"></asp:Label>
                        <asp:TextBox ID="tbReEnterPassword" runat="server" CssClass="detail_textbox" MaxLength="10" TextMode="Password"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ControlToValidate="tbReEnterPassword" CssClass="validatorMessage">
                        </asp:RequiredFieldValidator>
                    </div>
             <div class="div_right_details_ROW">
                        <asp:Label ID="lbRole" runat="server" Text="Role:" CssClass="detail_label"></asp:Label>
                                    <asp:RadioButton ID="rbUser" runat="server" Text="User" GroupName="Role" />
                                    <asp:RadioButton ID="rbAdmin" runat="server" Text="Admin" GroupName="Role" />

                        
                      
                       
                    </div>

                    </div>
&nbsp;<div id="div_right_BUTTONS">
                    <asp:Button ID="btNew" runat="server" Text="New" OnClick="btNew_Click" CausesValidation="False" CssClass="div_right_buttons_button" />
                    <asp:Button ID="btAdd" runat="server" Text="Add" OnClick="btAdd_Click" CausesValidation="True" CssClass="div_right_buttons_button" />
                    <asp:Button ID="btUpdate" runat="server" Text="Update" OnClick="btUpdate_Click" CausesValidation="True" CssClass="div_right_buttons_button" />
                    <asp:Button ID="btDelete" runat="server" Text="Delete" OnClick="btDelete_Click" CausesValidation="False" CssClass="div_right_buttons_button" />
                </div>


                    </div>
                <!-- End of div_right_DETAILS -->
                <br />
                <br />


                <div id="div_right_VALIDATORS">
                    <div>
                        <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
                    </div>

                   
                    <br />



                 

                </div>
                <!-- End of div_right_VALIDATORS -->
            </div>
            <!-- End of div_RIGHT -->
            <br />
                                <div class="div_right_details_ROW">
               

                    </div>
            <br />
            <br />
            <br />
            <br />
            <br />



        <!-- End of div_CONTAINER -->

            

    </form>



            <div id="div_FOOTER">
                <div id="div_footer_W3C_ICONS">
                    <a href="http://validator.w3.org/check?uri=referer">
                        <img class="w3c_icon" src="images/valid-xhtml10.png" alt="Valid XHTML 1.0 Transitional" /></a>
                    <a href="http://jigsaw.w3.org/css-validator/">
                        <img class="w3c_icon" src="images/vcss.png" alt="Valid CSS!" /></a>
                </div>

                <div id="div_footer_AUTHOR">
                    Zeynep Aykal 2014 v1.0
                </div>
            </div>


        
        </body>
</html>
