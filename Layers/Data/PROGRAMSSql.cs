using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Bazaar.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for PROGRAMS
	/// </summary>
	class PROGRAMSSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public PROGRAMSSql()
		{
			// Nothing for now.
		}

        #endregion

        #region Public Methods

        /// <summary>
        /// insert new row in the table
        /// </summary>
		/// <param name="businessObject">business object</param>
		/// <returns>true of successfully insert</returns>
		public int Insert(PROGRAMS businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[BazaarPROGRAMS_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{


                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
              //  sqlCommand.Parameters.Add(new SqlParameter("@OUTID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.OUTID));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DESCRIPTION));
                sqlCommand.Parameters.Add(new SqlParameter("@BODY", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BODY));
                sqlCommand.Parameters.Add(new SqlParameter("@ROLES", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ROLES));
                sqlCommand.Parameters.Add(new SqlParameter("@IMAGE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMAGE));
                sqlCommand.Parameters.Add(new SqlParameter("@HOMEPAGE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.HOMEPAGE));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
                sqlCommand.Parameters.Add(new SqlParameter("@Datetime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Datetime));
                sqlCommand.Parameters.Add(new SqlParameter("@PRIORITY", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PRIORITY));
                sqlCommand.Parameters.Add(new SqlParameter("@Kind", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Kind));
								
				MainConnection.Open();
				
				sqlCommand.ExecuteScalar();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

                return businessObject.ID;
			}
			catch(Exception ex)
			{				
				throw new Exception("PROGRAMS::Insert::Error occured.", ex);
			}
			finally
			{			
				MainConnection.Close();
				sqlCommand.Dispose();
			}
		}

         /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(PROGRAMS businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAMS_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DESCRIPTION));
                sqlCommand.Parameters.Add(new SqlParameter("@BODY", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BODY));
                sqlCommand.Parameters.Add(new SqlParameter("@ROLES", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ROLES));
                sqlCommand.Parameters.Add(new SqlParameter("@IMAGE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMAGE));
                sqlCommand.Parameters.Add(new SqlParameter("@HOMEPAGE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.HOMEPAGE));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
                sqlCommand.Parameters.Add(new SqlParameter("@Datetime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Datetime));
                sqlCommand.Parameters.Add(new SqlParameter("@PRIORITY", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PRIORITY));
                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAMS::Update::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Select by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>PROGRAMS business object</returns>
        public PROGRAMS SelectByPrimaryKey(PROGRAMSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAMS_SelectByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.ID));

                
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    PROGRAMS businessObject = new PROGRAMS();

                    PopulateBusinessObjectFromReader(businessObject, dataReader);

                    return businessObject;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAMS::SelectByPrimaryKey::Error occured.", ex);
            }
            finally
            {             
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select all rescords
        /// </summary>
        /// <returns>list of PROGRAMS</returns>
        public List<PROGRAMS> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAMS_SelectAll]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {                
                throw new Exception("PROGRAMS::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        /// <summary>
        /// Select records by field
        /// </summary>
        /// <param name="fieldName">name of field</param>
        /// <param name="value">value of field</param>
        /// <returns>list of PROGRAMS</returns>
        public List<PROGRAMS> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAMS_SelectByField]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@FieldName", fieldName));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", value));

                MainConnection.Open();
                
                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAMS::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public List<PROGRAMS> SelectByPaging(int Take, int Skip)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "Programs_SelectByPaging";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@Skip", Skip));
                sqlCommand.Parameters.Add(new SqlParameter("@Take", Take));

                MainConnection.Open();
                
                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAMS::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        

        /// <summary>
        /// Delete by primary key
        /// </summary>
        /// <param name="keys">primary keys</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(PROGRAMSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAMS_DeleteByPrimaryKey]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, keys.ID));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAMS::DeleteByKey::Error occured.", ex);
            }
            finally
            {                
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<PROGRAMS> SelectSearch(string Condition)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[BazaarProg_Search]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {


                sqlCommand.Parameters.Add(new SqlParameter("@Condition", Condition));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("CONTENTS::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }


        /// <summary>
        /// Delete records by field
        /// </summary>
        /// <param name="fieldName">name of field</param>
        /// <param name="value">value of field</param>
        /// <returns>true for successfully deleted</returns>
        public bool DeleteByField(string fieldName, object value)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAMS_DeleteByField]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@FieldName", fieldName));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", value));
                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {                
                throw new Exception("PROGRAMS::DeleteByField::Error occured.", ex);
            }
            finally
            {             
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }


        public List<PROGRAMS> SelectByConditionTop(string Condition, int TopCount)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[PROGRAMS_SelectByConditionTop]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@Condition", Condition));
                sqlCommand.Parameters.Add(new SqlParameter("@TopCount", TopCount));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAMS::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Populate business object from data reader
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <param name="dataReader">data reader</param>
        internal void PopulateBusinessObjectFromReader(PROGRAMS businessObject, IDataReader dataReader)
        {

            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.TITLE.ToString())))
            {
                businessObject.TITLE = dataReader.GetString(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.TITLE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.DESCRIPTION.ToString())))
            {
                businessObject.DESCRIPTION = dataReader.GetString(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.DESCRIPTION.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.BODY.ToString())))
            {
                businessObject.BODY = dataReader.GetString(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.BODY.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.ROLES.ToString())))
            {
                businessObject.ROLES = dataReader.GetString(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.ROLES.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.IMAGE.ToString())))
            {
                businessObject.IMAGE = dataReader.GetString(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.IMAGE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.HOMEPAGE.ToString())))
            {
                businessObject.HOMEPAGE = dataReader.GetBoolean(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.HOMEPAGE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.ACTIVE.ToString())))
            {
                businessObject.ACTIVE = dataReader.GetBoolean(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.ACTIVE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.Datetime.ToString())))
            {
                businessObject.Datetime = dataReader.GetDateTime(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.Datetime.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.PRIORITY.ToString())))
            {
                businessObject.PRIORITY = dataReader.GetInt32(dataReader.GetOrdinal(PROGRAMS.PROGRAMSFields.PRIORITY.ToString()));
            }

        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of PROGRAMS</returns>
        internal List<PROGRAMS> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<PROGRAMS> list = new List<PROGRAMS>();

            while (dataReader.Read())
            {
                PROGRAMS businessObject = new PROGRAMS();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
