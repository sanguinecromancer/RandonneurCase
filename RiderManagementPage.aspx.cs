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
public partial class RiderManagementPage : System.Web.UI.Page
{
    private RiderDAO riderDAO = new RiderDAO();
    private ClubDAO clubDAO = new ClubDAO();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        checkLogin(true); // true = login is required for accessing this page

       
        if (this.IsPostBack == false)
        {
            viewStateNew();
            createRiderList(); // Populate Department List for the first time
        }

        addButtonScripts();
    }
    
    private void addButtonScripts()
    {
        btDelete.Attributes.Add("onclick",
          "return confirm('Are you sure you want to delete the data?');");
    }

    private void createRiderList()
    {
        List<Rider> riderList = riderDAO.GetAllRidersOrderedByName();

        listBoxRiders.Items.Clear();
        if (riderList == null)
        {
            showErrorMessage("DATABASE TEMPORARILY OUT OF USE (see Database.log)");
        }
        else
        {
            foreach (Rider rider in riderList)
            {
                String text = rider.RiderID + ", " + rider.Firstname +", "+ rider.Surname ;
                ListItem listItem = new ListItem(text, "" + rider.RiderID);
                listBoxRiders.Items.Add(listItem);
            }
        }
    }

   protected void btAdd_Click(object sender, EventArgs e)
    {
        Rider rider = screenToModel();
        int insertOk = riderDAO.InsertRider(rider);
        
        

        if (insertOk == 0) // Insert succeeded
        {
            createRiderList();
            listBoxRiders.SelectedValue = rider.RiderID.ToString();
            if (rbFemale.Checked)
            {
                rider.Gender = "F";
                rbMale.Checked = false;
            }
            else
            {
                rider.Gender = "M";
                rbFemale.Checked = false;
            }
            if (rbUser.Checked)
            {
                rider.Role = "user";
                rbAdmin.Checked = false;
            }
            else
            {
                rider.Role = "admin";
                rbUser.Checked = false;
            }


            viewStateDetailsDisplayed();
            showNoMessage();
        }
        else if (insertOk == 1)
        {
            showErrorMessage("Rider id " + rider.RiderID +
              " is already in use. No record inserted into the database.");
            tbRiderID.Focus();
        }
        else
        {
            showErrorMessage("No record inserted into the database. PASSWORD MIGHT BE WRONG OR " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    protected void btDelete_Click(object sender, EventArgs e)
    {
        int riderId = Convert.ToInt32(listBoxRiders.SelectedValue);
        int deleteOk = riderDAO.DeleteRider(riderId);

        if (deleteOk == 0) // Delete succeeded
        {
            createRiderList();
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
        Rider rider = screenToModel();
        int updateOk = riderDAO.UpdateRider(rider);

        if (updateOk == 0) // Update succeeded
        {
            String selectedValue = listBoxRiders.SelectedValue;

            createRiderList();
            listBoxRiders.SelectedValue = selectedValue;
            showNoMessage();
        }
        else
        {
            showErrorMessage("No record updated. " +
              "THE DATABASE IS TEMPORARILY OUT OF USE.");
        }
    }

    protected void listBoxRiders_SelectedIndexChanged(object sender, EventArgs e)
    {
        int riderId = Convert.ToInt32(listBoxRiders.SelectedValue);
        Rider rider = riderDAO.GetRiderByRiderId(riderId);

        if (rider != null)
        {
            modelToScreen(rider);
            viewStateDetailsDisplayed();
            showNoMessage();
        }
    }
    
    private void modelToScreen(Rider rider)
    {
        tbRiderID.Text = "" + rider.RiderID;
        tbSurname.Text = rider.Surname;
        tbFirstName.Text = rider.Firstname;
        if (rider.Gender == "F")
        {
            rbFemale.Checked = true;
            rbMale.Checked = false;
        }
        else
        {
            rbMale.Checked = true;
            rbFemale.Checked = false;
        }
        DropDownListClubs.Items.Insert(0, rider.Clubname);
        DropDownListClubs.SelectedIndex = 0;
        tbEmail.Text = rider.Email;
        tbPhone.Text = rider.Phone;
        tbUsername.Text = rider.Username;
        tbPassword.Text = rider.Password;
        if (rider.Role == "user")
           {
              rbUser.Checked = true;
              rbAdmin.Checked = false;
           }
        else
           {
              rbUser.Checked = false;
              rbAdmin.Checked = true;
           }
    }

    private void resetForm()
    {
        tbRiderID.Text = "";
        tbSurname.Text = "";
        tbFirstName.Text = "";
        tbUsername.Text = "";
        tbPhone.Text = "";
        tbEmail.Text = "";
        rbUser.Checked = false;
        rbAdmin.Checked = false;
        rbMale.Checked = false;
        rbFemale.Checked = false;
    }

    private Rider screenToModel()
    {
      

            

        Rider rider = new Rider();
        rider.Clubname = DropDownListClubs.SelectedValue.Trim();
        rider.RiderID = Convert.ToInt32(tbRiderID.Text.Trim());
        rider.Surname = tbSurname.Text.Trim();
        rider.Firstname = tbFirstName.Text.Trim();
        rider.Phone = tbPhone.Text.Trim();
        rider.Email = tbEmail.Text.Trim();
        rider.Username = tbUsername.Text.Trim();
        
        if (tbReEnterPassword.Text == tbPassword.Text)
        {
            rider.Password = tbPassword.Text.Trim();
           
        }
        else
        {
            showErrorMessage("Second password is not the same as the first one, try again.");
            return null;
        }
        if (rbFemale.Checked == true)
        {
            rider.Gender = "F";
            rbMale.Checked = false;
        }
        else
        {
            rider.Gender = "M";
            rbFemale.Checked = false;
        }
        if (rbAdmin.Checked == true)
        {
            rider.Role = "admin";
            rbUser.Checked = false;
        }
        else
        {
            rider.Role = "user";
            rbAdmin.Checked = false;
        }
      
        return rider;
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
        tbRiderID.Enabled = false;

        btAdd.Enabled = true;
        btDelete.Enabled = true;
        btNew.Enabled = true;
        btUpdate.Enabled = true;
    }

    private void viewStateNew()
    {
        DropDownListClubs.Items.Clear();
        List<Club> c1 = clubDAO.GetAllClubNames();
        for (int i = 0; i < c1.Count; i++)
        {
            DropDownListClubs.Items.Add(c1[i].Clubname);
        }
        tbRiderID.Enabled = true;
        tbRiderID.Focus();

        btAdd.Enabled = true;
        btDelete.Enabled = false;
        btNew.Enabled = true;
        btUpdate.Enabled = false;

        resetForm();
        listBoxRiders.SelectedIndex = -1;
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
