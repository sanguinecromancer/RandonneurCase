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
public class Brevet
{
    private int brevetID;
    private int distance;
    private DateTime brevetDate;
    private String location;
    private int climbing;

    public Brevet()
    {
       

    }


    public int BrevetID
    {
        get { return brevetID; }
        set { brevetID = value; }
    }
    

    public int Distance
    {
        get { return distance; }
        set { distance = value; }
    }
    

    public DateTime BrevetDate
    {
        get { return brevetDate; }
        set { brevetDate = value; }
    }
    

    public String Location
    {
        get { return location; }
        set { location = value; }
    }
   

    public int Climbing
    {
        get { return climbing; }
        set { climbing = value; }
    }
    
    

   
  


}
// End