<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RiderListsPage.aspx.cs" Inherits="RiderListsPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=iso-8859-1" http-equiv="content-type" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Rider Lists</title>
</head>

<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Rider Lists</h1>
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
                    Brevets</div>

                <div id="div_center_LISTBOX">
                    <asp:ListBox ID="listBoxBrevets" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listBoxBrevets_SelectedIndexChanged" CssClass="listbox_main"></asp:ListBox>
                </div>

                <div id="div_center_IMAGE">
                    <img id="main_image" src="images/brevet.png" alt="Department manegement image" />
                </div>
                <asp:Label ID="lbMessage" runat="server"></asp:Label>
            </div>



            <div id="div_RIGHT">
                <div id="div_right_HEADER">
                    Rider List</div>

                <div id="div_right_DETAILS">

                    <div class="div_right_details_ROW">


                        <asp:ListBox ID="ListBoxRider" runat="server" Height="337px" Width="321px"></asp:ListBox>


                    </div>


            

                    
                </div>
                <!-- End of div_right_DETAILS -->




                    <br />




                </div>
                <!-- End of div_right_VALIDATORS -->
            </div>
            <!-- End of div_RIGHT -->



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


        
        <!-- End of div_CONTAINER -->
    </form>
</body>
</html>
