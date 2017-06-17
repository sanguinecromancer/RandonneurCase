/* **************************************************************************
 * DepartmentManagementPage.cs  Original version: Kari Silpiö 18.3.2014 v1.0
 *                              Modified by     : - 
 * -------------------------------------------------------------------------
 *  Application: DWA Model Case
 *  Class:       Code-behind class for DepartmentManagementPage.aspx
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************** */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// DepartmentManagementPage - Code behind part for the ASPX Page 
/// <remarks>Kari Silpiö 2014 
///          Modified by: -</remarks>
/// </summary>
public partial class RiderListsPage : System.Web.UI.Page
{
    private BrevetDAO brevetDAO = new BrevetDAO();
    private RiderDAO riderDAO = new RiderDAO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
      checkLogin(true); // true = login is required for accessing this page

        if (this.IsPostBack == false)
        {
            viewStateNew();
            createBrevetList(); // Populate Brevet List for the first time
        }

      
    }
    
  

    private void createBrevetList()
    {
        
        List<Brevet> brevetList = brevetDAO.GetAllBrevetsOrderedByName();

        
        if (brevetList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Brevet brevet in brevetList)
            {
                String text = brevet.Distance+" km, Date:"+ brevet.BrevetDate.ToString("dd-MM-yyyy")+ ", "+brevet.Location;
                
                ListItem listItem = new ListItem(text, "" + brevet.BrevetID);
                listBoxBrevets.Items.Add(listItem);
            }
        }
    }

    protected void listBoxBrevets_SelectedIndexChanged(object sender, EventArgs e)
    {
        int brevetId = Convert.ToInt32(listBoxBrevets.SelectedValue);

        List<Rider> brevetRiderList = riderDAO.GetRiderByBrevetId(brevetId);

        ListBoxRider.Items.Clear();
        if (brevetRiderList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Rider rider in brevetRiderList)
            {
                String text = rider.Surname + ", " + rider.Firstname + ", " + rider.Clubname;
                ListItem listItem = new ListItem(text, "" + rider.Surname);
                ListBoxRider.Items.Add(listItem);
            }
        }

    }

    

  

    private void resetForm()
    {
    
    }

  

    private void showErrorMessage(String message)
    {
        lbMessage.Text = message;
        lbMessage.ForeColor = System.Drawing.Color.Red;
    }

    private void showNoMessage()
    {
        lbMessage.Text = "";
        lbMessage.ForeColor = System.Drawing.Color.Black;
    }


    private void viewStateNew()
    {
        

        resetForm();
       listBoxBrevets.SelectedIndex = -1;
        showNoMessage();
    }


    /* **********************************************************************
    * LOGIN MANAGEMENT CODE 
    * - This is the special code to be used on your ASPX pages.
    * - DO NOT change anything else but the HyperLink controls here!
    *   HyperLink controls are managed under comments (1), (2), and (3)
    *********************************************************************** */
    private void checkLogin(bool loginRequired)
    {
        Response.Cache.SetNoStore();    // Should disable browser's Back Button
                
        // (1) Hide all hyperlinks that are available for autenthicated users only
        hyperLinkRiderLists.Visible = true;

        hyperLinkClubManagement.Visible = false;
        hyperLinkRiderManagement.Visible = false;
        hyperLinkUpdateResults.Visible = false;
        hyperLinkBrevetRegistration.Visible = false;
        hyperLinkBrevetManagement.Visible = false;
 
        if (loginRequired == true)
        {
          //  Page.Response.Redirect("HomePage.aspx");  // Jump to the login page.
            
            hyperLinkRiderLists.Visible = true;
           
        }

        if (Session["username"] == null)
        {
            lbLoginInfo.Text = "You are not logged in";
            btLogout.Visible = false;
        }

        if (Session["username"] != null)
        {

            lbLoginInfo.Text = "You are logged in as " + Session["username"];
            btLogout.Visible = true;

            // (2) Show all hyperlinks that are available for autenthicated users only
            
            hyperLinkBrevetRegistration.Visible = true;
          
        }
        
        if (Session["administrator"] != null)
        {
            // (3) In addition, show all hyperlinks that are available for administrators only
            hyperLinkRiderManagement.Visible = true;

            hyperLinkClubManagement.Visible = true;
            hyperLinkUpdateResults.Visible = true;
            hyperLinkRiderLists.Visible = true;
            hyperLinkBrevetRegistration.Visible = true;
            hyperLinkBrevetManagement.Visible = true;



        }
    }

    protected void btLogout_Click(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["administrator"] = null;
        Page.Response.Redirect("HomePage.aspx");
    }
    /* LOGIN MANAGEMENT code ends here  */
}
// End
