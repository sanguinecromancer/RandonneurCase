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
public partial class ClubManagementPage : System.Web.UI.Page
{
    private ClubDAO clubDAO = new ClubDAO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(true); // true = login is required for accessing this page

        if (this.IsPostBack == false)
        {
            viewStateNew();
            createClubList(); // Populate Department List for the first time
        }

        addButtonScripts();
    }
    
    private void addButtonScripts()
    {
        btDelete.Attributes.Add("onclick",
          "return confirm('Are you sure you want to delete the data?');");
    }

    private void createClubList()
    {
        List<Club> clubList = clubDAO.GetAllClubsOrderedByName();

        listBoxClubs.Items.Clear();
        if (clubList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Club club in clubList)
            {
                String text = club.Clubname +", " +club.City;
                
                ListItem listItem = new ListItem(text, "" + club.Clubno);
                listBoxClubs.Items.Add(listItem);
            }
        }
    }

    protected void btAdd_Click(object sender, EventArgs e)
    {
        Club club = screenToModel();
        int insertOk = clubDAO.InsertClub(club);

        if (insertOk == 0) // Insert succeeded
        {
            createClubList();
            listBoxClubs.SelectedValue = club.Clubno.ToString();
            viewStateDetailsDisplayed();
            showNoMessage();
        }
        else if (insertOk == 1)
        {
            showErrorMessage("Club id " + club.Clubno +
              " is already in use. No record inserted into the database.");
            tbClubno.Focus();
        }
        else
        {
            showErrorMessage("No record inserted into the database. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    protected void btDelete_Click(object sender, EventArgs e)
    {
        int clubId = Convert.ToInt32(listBoxClubs.SelectedValue);
        int deleteOk = clubDAO.DeleteClub(clubId);

        if (deleteOk == 0) // Delete succeeded
        {
            createClubList();
            viewStateNew();
            showNoMessage();
        }
        else if (deleteOk == 1)
        {
            showErrorMessage("No record deleted. " +
              "Please delete the department's employees first.");
        }
        else
        {
            showErrorMessage("No record deleted. " +
             "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    protected void btNew_Click(object sender, EventArgs e)
    {
        viewStateNew();
    }

    protected void btUpdate_Click(object sender, EventArgs e)
    {
       Club club = screenToModel();
        int updateOk = clubDAO.UpdateClub(club);

        if (updateOk == 0) // Update succeeded
        {
            String selectedValue = listBoxClubs.SelectedValue;

            createClubList();
            listBoxClubs.SelectedValue = selectedValue;
            showNoMessage();
        }
        else
        {
            showErrorMessage("No record updated. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    protected void listBoxClubs_SelectedIndexChanged(object sender, EventArgs e)
    {
        int clubId = Convert.ToInt32(listBoxClubs.SelectedValue);
        Club club = clubDAO.GetClubByClubId(clubId);

        if (club != null)
        {
            modelToScreen(club);
            viewStateDetailsDisplayed();
            showNoMessage();
        }
    }

    private void modelToScreen(Club club)
    {
        tbClubno.Text = "" + club.Clubno;
        tbName.Text = club.Clubname;
        tbCity.Text = club.City;
        
        tbEmail.Text = club.Email;
    }

    private void resetForm()
    {
        tbClubno.Text = "";
        tbName.Text = "";
        tbCity.Text = "";
        
        tbEmail.Text = "";
    }

    private Club screenToModel()
    {
        Club club = new Club();

        club.Clubno = Convert.ToInt32(tbClubno.Text.Trim());
        club.Clubname = tbName.Text.Trim();
        club.City = tbCity.Text.Trim();
        club.Email = tbEmail.Text.Trim();
        return club;
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

    private void viewStateDetailsDisplayed()
    {
        tbClubno.Enabled = false;

        btAdd.Enabled = false;
        btDelete.Enabled = true;
        btNew.Enabled = true;
        btUpdate.Enabled = true;
    }

    private void viewStateNew()
    {
        tbClubno.Enabled = true;
        tbClubno.Focus();

        btAdd.Enabled = true;
        btDelete.Enabled = false;
        btNew.Enabled = true;
        btUpdate.Enabled = false;

        resetForm();
        listBoxClubs.SelectedIndex = -1;
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
        hyperLinkBrevetResults.Visible = true;
        hyperLinkClubManagement.Visible = false;
        hyperLinkRiderManagement.Visible = false;
 
        if (loginRequired == true && Session["username"] == null)
        {
            Page.Response.Redirect("HomePage.aspx");  // Jump to the login page.
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
            hyperLinkClubManagement.Visible = true;
        }
        
        if (Session["administrator"] != null)
        {
            // (3) In addition, show all hyperlinks that are available for administrators only
            hyperLinkClubManagement.Visible = true;
            hyperLinkRiderManagement.Visible = true;
            hyperLinkBrevetRegistration.Visible = true;
            hyperLinkBrevetManagement.Visible = true;
            hyperLinkUpdateResults.Visible = true;
            hyperLinkRiderLists.Visible = true;
            hyperLinkBrevetResults.Visible = true;
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
