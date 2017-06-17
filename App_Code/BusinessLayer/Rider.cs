/* *************************************************************************
 * Department.cs    Original version: Kari Silpiö 20.3.2014 v1.0
 *                  Modified by     : - 
 * -----------------------------------------------------------------------
 *  Application: Model Case
 *  Layer:       Business Logic Layer
 *  Class:       Business object class describing a single Department
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
using System;

/// <summary>
/// Department - Business object class
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: </remarks>
/// </summary>
public class Rider
{
    private int riderID;
    private String surname;
    private String email;
        private String firstname;
        private String gender;
        private String phone;
        private String username;
        private String password;
        private String clubname;
        private String repassword;
        private String role;

        public Rider()
        {
           

        }
    public int RiderID
    {
        get { return riderID; }
        set { riderID = value; }
    }
    

     public String Surname
    {
        get { return surname; }
        set { surname = value; }
    }
    

    public String Firstname
    {
        get { return firstname; }
        set { firstname = value; }
    }
    

    public String Email
    {
        get { return email; }
        set { email = value; }
    }
    

    public String Gender
    {
        get { return gender; }
        set { gender = value; }
    }
    

    public String Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    

    public String Username
    {
        get { return username; }
        set { username = value; }
    }
    

    public String Clubname
    {
        get { return clubname; }
        set { clubname = value; }
    }
    

    public String Password
    {
        get { return password; }
        set { password = value; }
    }
    

    public String Repassword
    {
        get { return repassword; }
        set { repassword = value; }
    }
    

    public String Role
    {
        get { return role; }
        set { role = value; }
    }

   
    

   

  

 
  
   



}
// End