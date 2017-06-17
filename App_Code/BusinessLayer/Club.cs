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
public class Club
{
    private int clubno;
    private String clubname;
    private String city;
    private String email;
    public String City
    {
        get { return city; }
        set { city = value; }
    }
    

    public Club()
    {
        clubno = -1;
        clubname = "";
        city = "";
        email = "";
    }

    public int Clubno
    {
        get { return clubno; }
        set { clubno = value; }
    }

    public String Clubname
    {
        get { return clubname; }
        set { clubname = value; }
    }
    
  
   

    public String Email
    {
        get { return email; }
        set { email = value; }
    }


}
// End