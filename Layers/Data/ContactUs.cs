using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bazaar.BusinessLayer.DataLayer
{
    public class ContactUs
    {
        public static bool Insert(Bazaar.BusinessLayer.ContactUs businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"INSERT INTO [dbo].[CONTACTUS]
           ([NAME]
           ,[BODY]
           ,[DATETIME_INSERT]
           ,[DATETIME_CHECK]
           ,[ISREAD]
           ,[FILEPATH]
           ,[KIND]
           ,[EMAIL]
           ,[PHONE])
             VALUES
           (N'" + businessObject.Name + "',N'"
            + businessObject.Body + "', CONVERT(datetime, '"
            + businessObject.Datetime_Insert + "',102), CONVERT(datetime,'"
            + businessObject.Datetime_Check + "',102),'"
            + businessObject.Isread + "','"
            + businessObject.FilePath + "',"
            + businessObject.Kind + ",'"
            + businessObject.Email + "','"
            + businessObject.Phone + "')";
            sqlCommand.CommandType = CommandType.Text;
            // Use connection object of base class
            sqlCommand.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
            return true;
        }
        public static List<Bazaar.BusinessLayer.ContactUs> Select(DateTime StartDate, DateTime EndDate)
        {

            List<Bazaar.BusinessLayer.ContactUs> RetLst = new List<BusinessLayer.ContactUs>();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select * from  [dbo].[CONTACTUS]  where  Datetime_Insert between CONVERT(datetime, '" +
                StartDate.ToString() + "', 120)  and CONVERT(datetime, '" +
                EndDate.ToString() + "', 120) order by Datetime_Insert desc";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);
            sqlCommand.Connection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Bazaar.BusinessLayer.ContactUs Con = new BusinessLayer.ContactUs();
                Con.Body = dataReader.GetString(dataReader.GetOrdinal("body"));
                Con.Datetime_Check = dataReader.GetDateTime(dataReader.GetOrdinal("Datetime_Check"));
                Con.Datetime_Insert = dataReader.GetDateTime(dataReader.GetOrdinal("Datetime_Insert"));
                Con.Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
                Con.FilePath = dataReader.GetString(dataReader.GetOrdinal("FilePath"));
                Con.Id = dataReader.GetInt32(dataReader.GetOrdinal("Id"));
                Con.Isread = dataReader.GetBoolean(dataReader.GetOrdinal("Isread"));
                Con.Kind = dataReader.GetInt32(dataReader.GetOrdinal("Kind"));
                Con.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
                Con.Phone = dataReader.GetString(dataReader.GetOrdinal("Phone"));
                RetLst.Add(Con);
            }
            sqlCommand.Connection.Close();
            return RetLst;
        }
    }
}