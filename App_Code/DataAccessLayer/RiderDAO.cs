/* *************************************************************************
 * DepartmentDAO.cs   Original version: Kari Silpiö 20.3.2014 v1.0
 *                    Modified by     : -
 * ------------------------------------------------------------------------
 *  Application: Model Case
 *  Layer:       Data Access Layer
 *  Class:       SQL Server specific DAO class for Department entity objects
 * -------------------------------------------------------------------------
 * NOTICE: This is an over-simplified example for an introductory course. 
 * - Error processing is not robust (some error are not handled)
 * - No multi-user considerations, no transaction programming 
 * - No protection for attacks of type 'SQL injection'
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
using System;
using System.Collections.Generic;

using System.Data;

using Karis.DatabaseLibrary;

/// <summary>
/// DepartmentDAO - Data Access Layer interface class. Accesses the data storage.
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: -</remarks>
/// </summary>
public class RiderDAO
{
    private Database myDatabase;
    private String myConnectionString;
    

    public RiderDAO()
    {
        myConnectionString = ModelCaseConnectionString.Text;
        myDatabase = new Database();
    }

    /// <summary>
    /// Deletes a single Department row by DepartmentId from the database.
    /// </summary>
    /// <param name="DepartmentId"></param>
    /// <returns>0 = OK, 1 = delete not allowed, -1 = error</returns>
    public int DeleteRider(int riderno)
    {
        try
        {
            myDatabase.Open(myConnectionString);

         //   if (employeeExistsForDepartment(deptno) == true)
         //   {
         //       return 1;
         //   }

            String sqlText = String.Format(
              @"DELETE FROM Rider
                 WHERE riderId = {0}", riderno);

            myDatabase.ExecuteUpdate(sqlText);

            return 0;   // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }

    
    public List<Rider> GetAllRidersOrderedByName()
    {
        List<Rider> riderList = new List<Rider>();
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = 
              @"SELECT riderId, familyName, givenName FROM Rider ORDER BY familyName ASC";

            resultSet = myDatabase.ExecuteQuery(sqlText);
            while (resultSet.Read() == true)
            {
                Rider rider = new Rider();

               rider.RiderID = (int)resultSet["riderId"];
                rider.Surname = (String)resultSet["familyName"];
                rider.Firstname = (String)resultSet["givenName"];
                

                riderList.Add(rider);
            }

            resultSet.Close();

            return riderList;
        }
        catch (Exception)
        {
            return null; // An error occured
        }
        finally
        {
            myDatabase.Close();
        }
    }

    /// <summary>
   
    /// 
    public List <Rider> GetRiderByBrevetId(int brevetId)
    {
        IDataReader resultSet;
        List<Rider> riderList = new List<Rider>();
        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"SELECT Rider.familyName, Rider.givenName, Club.clubName
FROM Rider INNER JOIN Club ON Rider.clubId = Club.clubId
INNER JOIN Brevet_Rider ON Rider.riderId = Brevet_Rider.riderId
INNER JOIN Brevet ON Brevet_Rider.brevetId = Brevet.brevetId WHERE Brevet.brevetId = {0}", brevetId + " ORDER BY Rider.familyName, Rider.givenName, Club.clubName ASC");

            resultSet = myDatabase.ExecuteQuery(sqlText);

            while (resultSet.Read() == true)
            {
                Rider rider = new Rider();

               
                rider.Surname = (String)resultSet["familyName"];
                rider.Firstname = (String)resultSet["givenName"];
                
                rider.Clubname = (String)resultSet["clubName"];
                
                

                riderList.Add(rider);
                
            }

            resultSet.Close();
            return riderList;
           
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
















    public Rider GetRiderByRiderId(int riderId)
    {
        IDataReader resultSet;

        try
        {
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"SELECT Rider.riderId, Rider.familyName, Rider.givenName, Rider.gender, Rider.email, Rider.phone, Club.clubName, Rider.username, Rider.password, Rider.role FROM Rider INNER JOIN Club ON Rider.clubId = Club.clubId WHERE riderId = {0}", riderId);

            resultSet = myDatabase.ExecuteQuery(sqlText);

            if (resultSet.Read() == true)
            {
                Rider rider = new Rider();

                rider.RiderID = (int)resultSet["riderId"];
                rider.Surname = (String)resultSet["familyName"];
                rider.Firstname = (String)resultSet["givenName"];
                rider.Gender = (String)resultSet["gender"];

                rider.Email = (String)resultSet["email"];
                rider.Phone = (String)resultSet["phone"];
                rider.Clubname = (String)resultSet["clubName"];
                rider.Username = (String)resultSet["username"];
                rider.Password = (String)resultSet["password"];
                rider.Role = (String)resultSet["role"];
                resultSet.Close();

                return rider;
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

    /// <summary>
    /// Inserts a single Department row into the database.
    /// </summary>
    /// <param name="Department"></param>
    /// <returns>0 = OK, 1 = insert not allowed, -1 = error</returns>
    public int InsertRider(Rider rider)
    {
        IDataReader resultSet;
        int riderId = 0;
        try
        {
            
            myDatabase.Open(myConnectionString);
            
            if (riderExists(rider.RiderID) == true)
            {
                return 1;
            }
           
            String sqlText1 = String.Format(
                @"SELECT clubId FROM Club WHERE clubName = '{0}", rider.Clubname+ "'");
            
            resultSet = myDatabase.ExecuteQuery(sqlText1);
            if (resultSet.Read() == true)
            {
                riderId = (int)resultSet["clubId"];
            }

            myDatabase.Close();
           
            myDatabase.Open(myConnectionString);
            String sqlText = String.Format(
              @"INSERT INTO Rider (riderId, familyName, givenName, gender, email, phone, clubId, username, password, role)
                VALUES ({0}, '{1}', '{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}')",
                rider.RiderID,
                rider.Surname, 
                rider.Firstname,
                rider.Gender,
                rider.Email,
                rider.Phone,
                riderId,
                rider.Username,
                rider.Password,
                rider.Role);

            myDatabase.ExecuteUpdate(sqlText);

            return 0;  // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }

    /// <summary>
    /// Updates an existing Department row in the database.
    /// </summary>
    /// <param name="Department"></param>
    /// <returns>0 = OK, -1 = error</returns>
    public int UpdateRider(Rider rider)
    {
        try
        {
            IDataReader resultSet;
            int riderId = 0;
            myDatabase.Open(myConnectionString);

            

            String sqlText1 = String.Format(
                @"SELECT clubId FROM Club WHERE clubName = '{0}", rider.Clubname + "'");

            resultSet = myDatabase.ExecuteQuery(sqlText1);
            if (resultSet.Read() == true)
            {
                riderId = (int)resultSet["clubId"];
            }

            myDatabase.Close();
            myDatabase.Open(myConnectionString);

            String sqlText = String.Format(
              @"UPDATE Rider SET  
familyName = '{0}', givenName = '{1}', gender = '{2}', email = '{3}', 
phone = '{4}', clubId = {5}, username = '{6}', password = '{7}', 
role = '{8}' WHERE riderId  =  {9}",

                
                rider.Surname,
                rider.Firstname,
                rider.Gender,
                rider.Email,
                rider.Phone,
                riderId,
                rider.Username,
                rider.Password,
                rider.Role,
                rider.RiderID);

            myDatabase.ExecuteUpdate(sqlText);

            return 0;  // OK
        }
        catch (Exception)
        {
            return -1; // An error occurred
        }
        finally
        {
            myDatabase.Close();
        }
    }

    /// <summary>
    /// Checks if a Department row with the given Department id exists in the database.
    /// </summary>
    /// <param name="deptno"></param>
    /// <returns>true = row exists, otherwise false</returns>
    private bool riderExists(int riderno)
    {
        IDataReader resultSet;
        bool rowFound;

        String sqlText = String.Format(
          @"SELECT riderId 
              FROM Rider 
             WHERE riderId = {0}", riderno);

        resultSet = myDatabase.ExecuteQuery(sqlText);
        rowFound = resultSet.Read();
        resultSet.Close();

        return rowFound;   // true = row exists, otherwise false
    }

    /// <summary>
    /// Checks if the Department row is being referenced by another row. 
    /// </summary>
    /// <param name="deptno"></param>
    /// <returns>true = a child row exists, otherwise false</returns>
  //  private bool riderExistsForClub(int clubno)
  // {
     //  IDataReader resultSet;
    //    bool rowFound;

    //    String sqlText = String.Format(
      //    @"SELECT riderId
        //     FROM Rider
      //      WHERE riderId = {0}", riderId);

      //  resultSet = myDatabase.ExecuteQuery(sqlText);
      //  rowFound = resultSet.Read();
      // resultSet.Close();

      // return rowFound;   // true = row exists, otherwise false
    //}
}
// End
