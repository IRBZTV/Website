using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Bazaar.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for PROGRAM_SESSIONS
	/// </summary>
	class PROGRAM_SESSIONSSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public PROGRAM_SESSIONSSql()
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
		public bool Insert(PROGRAM_SESSIONS businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[BazaarPROGRAM_SESSIONS_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
				sqlCommand.Parameters.Add(new SqlParameter("@NUMBER", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.NUMBER));
				sqlCommand.Parameters.Add(new SqlParameter("@DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME));
				sqlCommand.Parameters.Add(new SqlParameter("@BODY", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BODY));
				sqlCommand.Parameters.Add(new SqlParameter("@VIDEO", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VIDEO));
				sqlCommand.Parameters.Add(new SqlParameter("@IMAGE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMAGE));
				sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
				sqlCommand.Parameters.Add(new SqlParameter("@PROG_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROG_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SaveDays", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SaveDays));
                sqlCommand.Parameters.Add(new SqlParameter("@Play_DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.Play_DATETIME));
                								
				MainConnection.Open();
				
				sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

				return true;
			}
			catch(Exception ex)
			{				
				throw new Exception("PROGRAM_SESSIONS::Insert::Error occured.", ex);
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
        public bool Update(PROGRAM_SESSIONS businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAM_SESSIONS_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
				sqlCommand.Parameters.Add(new SqlParameter("@NUMBER", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.NUMBER));
				sqlCommand.Parameters.Add(new SqlParameter("@DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME));
				sqlCommand.Parameters.Add(new SqlParameter("@BODY", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BODY));
				sqlCommand.Parameters.Add(new SqlParameter("@VIDEO", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VIDEO));
				sqlCommand.Parameters.Add(new SqlParameter("@IMAGE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.IMAGE));
				sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
				sqlCommand.Parameters.Add(new SqlParameter("@PROG_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PROG_ID));


                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAM_SESSIONS::Update::Error occured.", ex);
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
        /// <returns>PROGRAM_SESSIONS business object</returns>
        public PROGRAM_SESSIONS SelectByPrimaryKey(PROGRAM_SESSIONSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAM_SESSIONS_SelectByPrimaryKey]";
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
                    PROGRAM_SESSIONS businessObject = new PROGRAM_SESSIONS();

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
                throw new Exception("PROGRAM_SESSIONS::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of PROGRAM_SESSIONS</returns>
        public List<PROGRAM_SESSIONS> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAM_SESSIONS_SelectAll]";
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
                throw new Exception("PROGRAM_SESSIONS::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public List<PROGRAM_SESSIONS> SelectAllTop(int CountTop,int ProgKind)
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = @"  SELECT        TOP (" + CountTop + @") *
                                    FROM  PROGRAM_SESSIONS INNER JOIN
                                    PROGRAMS ON PROGRAM_SESSIONS.PROG_ID = PROGRAMS.ID
                                    WHERE (PROGRAMS.Kind = " + ProgKind + " and  PROGRAM_SESSIONS.active=1 and PROGRAMS.active=1 ) order by PROGRAM_SESSIONS.id desc";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = MainConnection;

            try
            {

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAM_SESSIONS::SelectAllTop::Error occured.", ex);
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
        /// <returns>list of PROGRAM_SESSIONS</returns>
        public List<PROGRAM_SESSIONS> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAM_SESSIONS_SelectByField]";
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
                throw new Exception("PROGRAM_SESSIONS::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public List<PROGRAM_SESSIONS> SelectByProgIDTop(int ProgId, int Count, string OrderField)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[BazaarPROGRAM_SESSIONS_SelectByProgID]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ProgId", ProgId.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@Count", Count.ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@OrderField", OrderField.ToString()));

                MainConnection.Open();
                
                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAM_SESSIONS::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<PROGRAM_SESSIONS> SelectByProgIDSessionNumber(int ProgId, int SessionNumber)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select * from [dbo].[PROGRAM_SESSIONS] where PROG_ID=" + ProgId.ToString() + " and NUMBER="+SessionNumber.ToString();
            sqlCommand.CommandType = CommandType.Text;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                //sqlCommand.Parameters.Add(new SqlParameter("@ProgId", ProgId.ToString()));
                //sqlCommand.Parameters.Add(new SqlParameter("@Count", Count.ToString()));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAM_SESSIONS::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<PROGRAM_SESSIONS> Search(string SearchKey)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select * from [dbo].[PROGRAM_SESSIONS] where     "+SearchKey+"   ";
            sqlCommand.CommandType = CommandType.Text;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                //sqlCommand.Parameters.Add(new SqlParameter("@ProgId", ProgId.ToString()));
                //sqlCommand.Parameters.Add(new SqlParameter("@Count", Count.ToString()));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("PROGRAM_SESSIONS:SEARCH::Error occured." + ex.Message + "****" + "select * from [dbo].[PROGRAM_SESSIONS] where     " + SearchKey + "   order by datetime desc", ex);
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
        public bool Delete(PROGRAM_SESSIONSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPROGRAM_SESSIONS_DeleteByPrimaryKey]";
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
                throw new Exception("PROGRAM_SESSIONS::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[BazaarPROGRAM_SESSIONS_DeleteByField]";
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
                throw new Exception("PROGRAM_SESSIONS::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(PROGRAM_SESSIONS businessObject, IDataReader dataReader)
        {


				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.ID.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.TITLE.ToString())))
				{
					businessObject.TITLE = dataReader.GetString(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.TITLE.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.NUMBER.ToString())))
				{
					businessObject.NUMBER = dataReader.GetInt32(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.NUMBER.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.DATETIME.ToString())))
				{
					businessObject.DATETIME = dataReader.GetDateTime(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.DATETIME.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.BODY.ToString())))
				{
					businessObject.BODY = dataReader.GetString(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.BODY.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.VIDEO.ToString())))
				{
					businessObject.VIDEO = dataReader.GetString(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.VIDEO.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.IMAGE.ToString())))
				{
					businessObject.IMAGE = dataReader.GetString(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.IMAGE.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.ACTIVE.ToString())))
				{
					businessObject.ACTIVE = dataReader.GetBoolean(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.ACTIVE.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.PROG_ID.ToString())))
				{
					businessObject.PROG_ID = dataReader.GetInt32(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.PROG_ID.ToString()));
				}
                if (!dataReader.IsDBNull(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.Play_DATETIME.ToString())))
                {
                    businessObject.Play_DATETIME = dataReader.GetDateTime(dataReader.GetOrdinal(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields.Play_DATETIME.ToString()));
                }

        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of PROGRAM_SESSIONS</returns>
        internal List<PROGRAM_SESSIONS> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<PROGRAM_SESSIONS> list = new List<PROGRAM_SESSIONS>();

            while (dataReader.Read())
            {
                PROGRAM_SESSIONS businessObject = new PROGRAM_SESSIONS();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
