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
public class Brevet_Rider
{
    private int riderID;
    private int brevetID;
    private string isCompleted;
    private string finishingTime;

   

    public Brevet_Rider()
    {
        brevetID = -1;
        riderID = -1;

    }
    
    public int RiderID
    {
        get { return riderID; }
        set { riderID = value; }
    }
    
    public string IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }
    

    public int BrevetID
    {
        get { return brevetID; }
        set { brevetID = value; }
    }

    public string FinishingTime
    {
        get { return finishingTime; }
        set { finishingTime = value; }
    }
   
    

   
    
    

   
  


}
// End