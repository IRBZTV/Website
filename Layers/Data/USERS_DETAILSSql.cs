using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Bazaar.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for USERS_DETAILS
	/// </summary>
	class USERS_DETAILSSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public USERS_DETAILSSql()
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
		public bool Insert(USERS_DETAILS businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[BazaarUSERS_DETAILS_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@USERID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.USERID));
				sqlCommand.Parameters.Add(new SqlParameter("@FULLNAME", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FULLNAME));
				sqlCommand.Parameters.Add(new SqlParameter("@MENU_SEC", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MENU_SEC));
				sqlCommand.Parameters.Add(new SqlParameter("@ACCESS_SEC", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACCESS_SEC));
				sqlCommand.Parameters.Add(new SqlParameter("@USRNM", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.USRNM));
				sqlCommand.Parameters.Add(new SqlParameter("@PROG_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROG_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROGKIND", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROGKIND));

								
				MainConnection.Open();
				
				sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

				return true;
			}
			catch(Exception ex)
			{				
				throw new Exception("USERS_DETAILS::Insert::Error occured.", ex);
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
        public bool Update(USERS_DETAILS businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarUSERS_DETAILS_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@USERID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.USERID));
				sqlCommand.Parameters.Add(new SqlParameter("@FULLNAME", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.FULLNAME));
				sqlCommand.Parameters.Add(new SqlParameter("@MENU_SEC", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MENU_SEC));
				sqlCommand.Parameters.Add(new SqlParameter("@ACCESS_SEC", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACCESS_SEC));
				sqlCommand.Parameters.Add(new SqlParameter("@USRNM", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.USRNM));
				sqlCommand.Parameters.Add(new SqlParameter("@PROG_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROG_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PROGKIND", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROGKIND));

                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("USERS_DETAILS::Update::Error occured.", ex);
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
        /// <returns>USERS_DETAILS business object</returns>
        public USERS_DETAILS SelectByPrimaryKey(USERS_DETAILSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarUSERS_DETAILS_SelectByPrimaryKey]";
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
                    USERS_DETAILS businessObject = new USERS_DETAILS();

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
                throw new Exception("USERS_DETAILS::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of USERS_DETAILS</returns>
        public List<USERS_DETAILS> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarUSERS_DETAILS_SelectAll]";
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
                throw new Exception("USERS_DETAILS::SelectAll::Error occured.", ex);
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
        /// <returns>list of USERS_DETAILS</returns>
        public List<USERS_DETAILS> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarUSERS_DETAILS_SelectByField]";
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
                throw new Exception("USERS_DETAILS::SelectByField::Error occured.", ex);
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
        public bool Delete(USERS_DETAILSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarUSERS_DETAILS_DeleteByPrimaryKey]";
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
                throw new Exception("USERS_DETAILS::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[BazaarUSERS_DETAILS_DeleteByField]";
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
                throw new Exception("USERS_DETAILS::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(USERS_DETAILS businessObject, IDataReader dataReader)
        {


				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.ID.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.USERID.ToString())))
				{
					businessObject.USERID = dataReader.GetGuid(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.USERID.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.FULLNAME.ToString())))
				{
					businessObject.FULLNAME = dataReader.GetString(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.FULLNAME.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.MENU_SEC.ToString())))
				{
					businessObject.MENU_SEC = dataReader.GetString(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.MENU_SEC.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.ACCESS_SEC.ToString())))
				{
					businessObject.ACCESS_SEC = dataReader.GetString(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.ACCESS_SEC.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.USRNM.ToString())))
				{
					businessObject.USRNM = dataReader.GetString(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.USRNM.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.PROG_ID.ToString())))
				{
					businessObject.PROG_ID = dataReader.GetInt32(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.PROG_ID.ToString()));
				}

                if (!dataReader.IsDBNull(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.PROGKIND.ToString())))
                {
                    businessObject.PROGKIND = dataReader.GetInt16(dataReader.GetOrdinal(USERS_DETAILS.USERS_DETAILSFields.PROGKIND.ToString()));
                }


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of USERS_DETAILS</returns>
        internal List<USERS_DETAILS> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<USERS_DETAILS> list = new List<USERS_DETAILS>();

            while (dataReader.Read())
            {
                USERS_DETAILS businessObject = new USERS_DETAILS();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
