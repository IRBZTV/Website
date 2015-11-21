using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Bazaar.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for ALBUMS
    /// </summary>
    class ALBUMSSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public ALBUMSSql()
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
        public int Insert(ALBUMS businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUMS_Insert]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
                sqlCommand.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DESCRIPTION));
                sqlCommand.Parameters.Add(new SqlParameter("@DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME));
                sqlCommand.Parameters.Add(new SqlParameter("@PHOTOGRAPHER", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PHOTOGRAPHER));
                sqlCommand.Parameters.Add(new SqlParameter("@HomePage", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.HomePage));
                sqlCommand.Parameters.Add(new SqlParameter("@Kind", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KIND));

                MainConnection.Open();

                sqlCommand.ExecuteScalar();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

                return businessObject.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("ALBUMS::Insert::Error occured.", ex);
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
        public bool Update(ALBUMS businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUMS_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
                sqlCommand.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DESCRIPTION));
                sqlCommand.Parameters.Add(new SqlParameter("@DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME));
                sqlCommand.Parameters.Add(new SqlParameter("@PHOTOGRAPHER", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PHOTOGRAPHER));
                sqlCommand.Parameters.Add(new SqlParameter("@HomePage", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.HomePage));
                sqlCommand.Parameters.Add(new SqlParameter("@Kind", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KIND));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ALBUMS::Update::Error occured.", ex);
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
        /// <returns>ALBUMS business object</returns>
        public ALBUMS SelectByPrimaryKey(ALBUMSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUMS_SelectByPrimaryKey]";
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
                    ALBUMS businessObject = new ALBUMS();

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
                throw new Exception("ALBUMS::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of ALBUMS</returns>
        public List<ALBUMS> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUMS_SelectAll]";
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
                throw new Exception("ALBUMS::SelectAll::Error occured.", ex);
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
        /// <returns>list of ALBUMS</returns>
        /// [dbo].[ALBUMS_SelectTopActive]
        public List<ALBUMS> SelectByField(string fieldName, object value, string SortString)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUMS_SelectByField]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@FieldName", fieldName));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", value));
                sqlCommand.Parameters.Add(new SqlParameter("@Sort", SortString));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("ALBUMS::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }


        public List<ALBUMS> SelectSearch(string Condition)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[BazaarAlbums_Search]";
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



        public List<ALBUMS> SelectTopActive(string Condition, string Count)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[ALBUMS_SelectTopActive]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@Condition", Condition));
                sqlCommand.Parameters.Add(new SqlParameter("@TopCount", Count));


                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("ALBUMS::SelectByField::Error occured.", ex);
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
        public bool Delete(ALBUMSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUMS_DeleteByPrimaryKey]";
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
                throw new Exception("ALBUMS::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[BazaarALBUMS_DeleteByField]";
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
                throw new Exception("ALBUMS::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(ALBUMS businessObject, IDataReader dataReader)
        {


            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.TITLE.ToString())))
            {
                businessObject.TITLE = dataReader.GetString(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.TITLE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.ACTIVE.ToString())))
            {
                businessObject.ACTIVE = dataReader.GetBoolean(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.ACTIVE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.DESCRIPTION.ToString())))
            {
                businessObject.DESCRIPTION = dataReader.GetString(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.DESCRIPTION.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.DATETIME.ToString())))
            {
                businessObject.DATETIME = dataReader.GetDateTime(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.DATETIME.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.PHOTOGRAPHER.ToString())))
            {
                businessObject.PHOTOGRAPHER = dataReader.GetString(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.PHOTOGRAPHER.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.HomePage.ToString())))
            {
                businessObject.HomePage = dataReader.GetBoolean(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.HomePage.ToString()));
            }
            if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.KIND.ToString())))
            {
                businessObject.KIND = dataReader.GetInt32(dataReader.GetOrdinal(ALBUMS.ALBUMSFields.KIND.ToString()));
            }


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of ALBUMS</returns>
        internal List<ALBUMS> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<ALBUMS> list = new List<ALBUMS>();

            while (dataReader.Read())
            {
                ALBUMS businessObject = new ALBUMS();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

    }
}
