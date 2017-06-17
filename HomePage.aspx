<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=iso-8859-1" http-equiv="content-type" />
    <link href="CSS/ModelCaseStyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Home Page - DWA Model Case</title>
</head>

<body>
    <form id="form1" runat="server">
        <div id="div_CONTAINER">


            <div id="div_HEADER">
                <div id="div_header_TEXT">
                    <h1>Model Case Home Page</h1>
                </div>

                <div id="div_header_LOGIN_STATUS">
                    <asp:Label ID="lbLoginInfo" runat="server"></asp:Label>.<br />
                    <asp:LinkButton ID="btLogout" runat="server" CssClass="logout_link" OnClick="btLogout_Click">LOGOUT</asp:LinkButton>
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
                <br />
                <br />
                Welcome to HH Randennours Home Page!<br />
                <br />
                <br />
                <img src="images/brevet_rider.png" alt="Team image" /><br />
                <br />
                <br />
                <br />
                <br />
                <br />
                HH Randonneurs organize annuel Super Randonneur series of 200, 300, 400 and<br />
                600 km Brevets. In addition, we organize
                <br />
                1000 and 1200 km Brevets when possible.
                <br />
                <br />
                Whichever Brevet you choose, we&#39;ll make it<br />
                an unforgettable ride!<br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>



            <div id="div_RIGHT">
                You can view rider lists and brevet results without logging in.<br />
                <br />
                Login is required for brevet registrations.
                <br />
                Pre-registration for brevets is accepted up to one week<br />
                before the event. <br />
                <br />

                <asp:Panel ID="panelLogin" runat="server" GroupingText="Login" CssClass="loginPanel">
                    <asp:Label ID="lbUsername" runat="server" EnableViewState="False" Text="Username:"></asp:Label><br />
                    <asp:TextBox ID="tbUsername" runat="server" CssClass="loginTextBox"></asp:TextBox><br />
                    <asp:Label ID="lbPassword" runat="server" Text="Password:"></asp:Label><br />
                    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="loginTextBox"></asp:TextBox><br />
                    <asp:Button ID="btLogin" runat="server" EnableTheming="False" Text="Login" OnClick="btLogin_Click" CssClass="loginButton" />
                </asp:Panel>

                <asp:Label ID="lbMessage" runat="server" CssClass="validatorMessage"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
                Links<br />
                <asp:HyperLink ID="hyperLink1" runat="server" CssClass="other_page_link" NavigateUrl="https://en.wikipedia.org/wiki/Brevet_(cycling)">https://en.wikipedia.org/wiki/Brevet_(cycling)</asp:HyperLink>
                <br />
                <asp:HyperLink ID="hyperLink2" runat="server" CssClass="other_page_link" NavigateUrl="https://en.wikipedia.org/wiki/Paris_Brest_Paris">https://en.wikipedia.org/wiki/Paris_Brest_Paris</asp:HyperLink>
                <br />
                <asp:HyperLink ID="hyperLink3" runat="server" CssClass="other_page_link" NavigateUrl="http://www.randonneurs.fi">http://www.randonneurs.fi</asp:HyperLink>
                <br />
                <asp:HyperLink ID="hyperLink4" runat="server" CssClass="other_page_link" NavigateUrl="http://www.rusa.org">http://www.rusa.org</asp:HyperLink>
                <br />
            </div>



            <div id="div_FOOTER">
                <div id="div_footer_W3C_ICONS">
                    <a href="http://validator.w3.org/check?uri=referer">
                        <img class="w3c_icon" src="images/valid-xhtml10.png" alt="Valid XHTML 1.0 Transitional" /></a>
                    <a href="http://jigsaw.w3.org/css-validator/">
                        <img class="w3c_icon" src="images/vcss.png" alt="Valid CSS!" /></a>
                </div>

                <div id="div_footer_AUTHOR">
                    Zeynep Aykal 2015 v1.0
                </div>
            </div>


        </div>
        <!-- End of div_CONTAINER -->
    </form>
</body>
</html>
