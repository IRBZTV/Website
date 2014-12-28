using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Bazaar.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for CONTENTS
    /// </summary>
    class CONTENTSSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public CONTENTSSql()
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
        public bool Insert(CONTENTS businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarCONTENTS_Insert]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
                sqlCommand.Parameters.Add(new SqlParameter("@LEAD", SqlDbType.NVarChar, 300, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LEAD));
                sqlCommand.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DESCRIPTION));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 300, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@BODY", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BODY));
                sqlCommand.Parameters.Add(new SqlParameter("@DATETIME_CREATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME_CREATE));
                sqlCommand.Parameters.Add(new SqlParameter("@CATEGORY_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CATEGORY_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SHOWCOMMENTS", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SHOWCOMMENTS));
                sqlCommand.Parameters.Add(new SqlParameter("@NEWCOMENT", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.NEWCOMENT));
                sqlCommand.Parameters.Add(new SqlParameter("@SHOWPOLL", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SHOWPOLL));
                sqlCommand.Parameters.Add(new SqlParameter("@POLL_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.POLL_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DATETIME_MODIFIED", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME_MODIFIED));
                sqlCommand.Parameters.Add(new SqlParameter("@AUTHOR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AUTHOR));
                sqlCommand.Parameters.Add(new SqlParameter("@PUBLISHER", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PUBLISHER));
                sqlCommand.Parameters.Add(new SqlParameter("@STATE", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATE));
                sqlCommand.Parameters.Add(new SqlParameter("@POSITION", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.POSITION));
                sqlCommand.Parameters.Add(new SqlParameter("@SOURCE_URL", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SOURCE_URL));
                sqlCommand.Parameters.Add(new SqlParameter("@VIEWCOUNT", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VIEWCOUNT));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("CONTENTS::Insert::Error occured.", ex);
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
        public bool Update(CONTENTS businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarCONTENTS_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
                sqlCommand.Parameters.Add(new SqlParameter("@LEAD", SqlDbType.NVarChar, 300, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LEAD));
                sqlCommand.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DESCRIPTION));
                sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 300, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@BODY", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.BODY));
                sqlCommand.Parameters.Add(new SqlParameter("@DATETIME_CREATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME_CREATE));
                sqlCommand.Parameters.Add(new SqlParameter("@CATEGORY_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CATEGORY_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SHOWCOMMENTS", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SHOWCOMMENTS));
                sqlCommand.Parameters.Add(new SqlParameter("@NEWCOMENT", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.NEWCOMENT));
                sqlCommand.Parameters.Add(new SqlParameter("@SHOWPOLL", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SHOWPOLL));
                sqlCommand.Parameters.Add(new SqlParameter("@POLL_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.POLL_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@DATETIME_MODIFIED", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME_MODIFIED));
                sqlCommand.Parameters.Add(new SqlParameter("@AUTHOR", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.AUTHOR));
                sqlCommand.Parameters.Add(new SqlParameter("@PUBLISHER", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PUBLISHER));
                sqlCommand.Parameters.Add(new SqlParameter("@STATE", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.STATE));
                sqlCommand.Parameters.Add(new SqlParameter("@POSITION", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.POSITION));
                sqlCommand.Parameters.Add(new SqlParameter("@SOURCE_URL", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SOURCE_URL));
                sqlCommand.Parameters.Add(new SqlParameter("@VIEWCOUNT", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VIEWCOUNT));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("CONTENTS::Update::Error occured.", ex);
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
        /// <returns>CONTENTS business object</returns>
        public CONTENTS SelectByPrimaryKey(CONTENTSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarCONTENTS_SelectByPrimaryKey]";
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
                    CONTENTS businessObject = new CONTENTS();

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
                throw new Exception("CONTENTS::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of CONTENTS</returns>
        public List<CONTENTS> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarCONTENTS_SelectAll]";
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
                throw new Exception("CONTENTS::SelectAll::Error occured.", ex);
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
        /// <returns>list of CONTENTS</returns>
        public List<CONTENTS> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarCONTENTS_SelectByField]";
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
                throw new Exception("CONTENTS::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<CONTENTS> SelectByCondition(int Top, int Category_Id)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[Contents_SelectByCondition]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@Top", Top));
                sqlCommand.Parameters.Add(new SqlParameter("@Category_Id", Category_Id));

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
        public List<CONTENTS> SelectSearch(string Condition)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[BazaarCONTENTS_Search]";
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

        public List<CONTENTS> SelectByPaging(int Take, int Skip, int CatId)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "Contents_SelectByPaging";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@Skip", Skip));
                sqlCommand.Parameters.Add(new SqlParameter("@Take", Take));
                sqlCommand.Parameters.Add(new SqlParameter("@CatId", CatId));

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
        public bool Delete(CONTENTSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarCONTENTS_DeleteByPrimaryKey]";
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
                throw new Exception("CONTENTS::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[BazaarCONTENTS_DeleteByField]";
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
                throw new Exception("CONTENTS::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(CONTENTS businessObject, IDataReader dataReader)
        {


            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.ACTIVE.ToString())))
            {
                businessObject.ACTIVE = dataReader.GetBoolean(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.ACTIVE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.LEAD.ToString())))
            {
                businessObject.LEAD = dataReader.GetString(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.LEAD.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.DESCRIPTION.ToString())))
            {
                businessObject.DESCRIPTION = dataReader.GetString(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.DESCRIPTION.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.TITLE.ToString())))
            {
                businessObject.TITLE = dataReader.GetString(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.TITLE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.BODY.ToString())))
            {
                businessObject.BODY = dataReader.GetString(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.BODY.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.DATETIME_CREATE.ToString())))
            {
                businessObject.DATETIME_CREATE = dataReader.GetDateTime(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.DATETIME_CREATE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.CATEGORY_ID.ToString())))
            {
                businessObject.CATEGORY_ID = dataReader.GetInt32(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.CATEGORY_ID.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.SHOWCOMMENTS.ToString())))
            {
                businessObject.SHOWCOMMENTS = dataReader.GetBoolean(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.SHOWCOMMENTS.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.NEWCOMENT.ToString())))
            {
                businessObject.NEWCOMENT = dataReader.GetBoolean(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.NEWCOMENT.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.SHOWPOLL.ToString())))
            {
                businessObject.SHOWPOLL = dataReader.GetBoolean(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.SHOWPOLL.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.POLL_ID.ToString())))
            {
                businessObject.POLL_ID = dataReader.GetInt32(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.POLL_ID.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.DATETIME_MODIFIED.ToString())))
            {
                businessObject.DATETIME_MODIFIED = dataReader.GetDateTime(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.DATETIME_MODIFIED.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.AUTHOR.ToString())))
            {
                businessObject.AUTHOR = dataReader.GetInt32(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.AUTHOR.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.PUBLISHER.ToString())))
            {
                businessObject.PUBLISHER = dataReader.GetInt32(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.PUBLISHER.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.STATE.ToString())))
            {
                businessObject.STATE = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.STATE.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.POSITION.ToString())))
            {
                businessObject.POSITION = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.POSITION.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.SOURCE_URL.ToString())))
            {
                businessObject.SOURCE_URL = dataReader.GetString(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.SOURCE_URL.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.VIEWCOUNT.ToString())))
            {
                businessObject.VIEWCOUNT = dataReader.GetInt64(dataReader.GetOrdinal(CONTENTS.CONTENTSFields.VIEWCOUNT.ToString()));
            }


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of CONTENTS</returns>
        internal List<CONTENTS> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<CONTENTS> list = new List<CONTENTS>();

            while (dataReader.Read())
            {
                CONTENTS businessObject = new CONTENTS();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

    }
}
