/* *************************************************************************
 * LoginDAO.cs   Original version: Kari Silpiö 20.3.2014 v1.0
 *               Modified by     : -
 * ------------------------------------------------------------------------
 *  Application: Model Case
 *  Layer:       Data Access Layer
 *  Class:       DAO class for database services for login functionality
 * -------------------------------------------------------------------------
 * NOTICE: This is an over-simplified example for an introductory course. 
 * - Error processing is not robust (some error are not handled)
 * - No multi-user considerations, no transaction programming 
 * - No protection for attacks of type 'SQL injection'
 * - No password security etc.
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using Karis.DatabaseLibrary;

/// <summary>
/// LoginDAO - Data Access Layer interface class. Accesses the data storage.
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: -</remarks>
/// </summary>>
public class LoginDAO
{
    private Database myDatabase;
    private String myConnectionString;

    public LoginDAO()
    {
        myConnectionString = ModelCaseConnectionString.Text;
        myDatabase = new Database();
    }

    public LoginRole GetLoginRole(string username, string password)
    {
        LoginRole loginRole = new LoginRole();
        IDataReader resultSet;
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"SELECT username, password FROM Rider WHERE username = '{0}", username + "'");

            resultSet = myDatabase.ExecuteQuery(sqlText);
            if (resultSet.Read() == true)
            {
                string password1 = "";
                loginRole.Username = (String)resultSet["username"];
                password1 = (String)resultSet["password"];

                if (username == "Admin" && password == "admin")
                {
                    loginRole.Role = "administrator";
                }
                else
                {
                    loginRole.Role = "user";
                }


                resultSet.Close();

                return loginRole;
            }
            else
            {
                return null; // Not found
            }



        }
        catch (Exception)
        {
            return null;  // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }
}
// End
