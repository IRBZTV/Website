using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Bazaar.BusinessLayer.DataLayer
{
    /// <summary>
    /// Data access layer class for SERVICE_REPORT
    /// </summary>
    class SERVICE_REPORTSql : DataLayerBase
    {

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public SERVICE_REPORTSql()
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
        public bool Insert(SERVICE_REPORT businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarSERVICE_REPORT_Insert]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CAT_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CAT_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@KIND_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KIND_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CLIENT_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CLIENT_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@LIST_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LIST_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@TEXT", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TEXT));
                sqlCommand.Parameters.Add(new SqlParameter("@DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME));
                sqlCommand.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.USER_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SHIFT", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SHIFT));
                sqlCommand.Parameters.Add(new SqlParameter("@MINUTE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MINUTE));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("SERVICE_REPORT::Insert::Error occured.", ex);
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
        public bool Update(SERVICE_REPORT businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarSERVICE_REPORT_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CAT_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CAT_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@KIND_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.KIND_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CLIENT_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CLIENT_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@LIST_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.LIST_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@TEXT", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TEXT));
                sqlCommand.Parameters.Add(new SqlParameter("@DATETIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.DATETIME));
                sqlCommand.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.USER_ID));
                sqlCommand.Parameters.Add(new SqlParameter("@SHIFT", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SHIFT));
                sqlCommand.Parameters.Add(new SqlParameter("@MINUTE", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MINUTE));


                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("SERVICE_REPORT::Update::Error occured.", ex);
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
        /// <returns>SERVICE_REPORT business object</returns>
        public SERVICE_REPORT SelectByPrimaryKey(SERVICE_REPORTKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarSERVICE_REPORT_SelectByPrimaryKey]";
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
                    SERVICE_REPORT businessObject = new SERVICE_REPORT();

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
                throw new Exception("SERVICE_REPORT::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of SERVICE_REPORT</returns>
        public List<SERVICE_REPORT> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarSERVICE_REPORT_SelectAll]";
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
                throw new Exception("SERVICE_REPORT::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }

        public List<SERVICE_REPORT> SelectByCondition(string Condition)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[Service_SelectByCondition]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@Cond", Condition));

            try
            {

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("SERVICE_REPORT::SelectAll::Error occured.", ex);
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
        /// <returns>list of SERVICE_REPORT</returns>
        public List<SERVICE_REPORT> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarSERVICE_REPORT_SelectByField]";
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
                throw new Exception("SERVICE_REPORT::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public int SelectCountByClientIdListId(string ClientId, string ListId,DateTime Start ,DateTime End)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " select count(*) from SERVICE_REPORT where CLIENT_ID=" + ClientId + " and LIST_ID="+ListId +" and  Datetime >  '"+ Start +"' "+" and  Datetime <  '"+ End +"' ";
            sqlCommand.CommandType = CommandType.Text;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                MainConnection.Open();



                return int.Parse(sqlCommand.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("SERVICE_REPORT::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public int SelectCountByListId(string ListId,DateTime Start ,DateTime End)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " select count(*) from SERVICE_REPORT where LIST_ID=" + ListId+" and  Datetime >  '"+ Start +"' "+" and  Datetime <  '"+ End +"' ";;
            sqlCommand.CommandType = CommandType.Text;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                MainConnection.Open();



                return int.Parse(sqlCommand.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("SERVICE_REPORT::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public int SelectCountByListIdKindId(string ListId,string KindId,DateTime Start ,DateTime End)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " select count(*) from SERVICE_REPORT where LIST_ID=" + ListId+" and kind_Id="+KindId+" and  Datetime >  '"+ Start +"' "+" and  Datetime <  '"+ End +"' ";;
            sqlCommand.CommandType = CommandType.Text;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                MainConnection.Open();



                return int.Parse(sqlCommand.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("SERVICE_REPORT::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public int SelectCountByCatId(string CatId,DateTime Start ,DateTime End)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " select count(*) from SERVICE_REPORT where CAT_ID=" + CatId + " and  Datetime >  '" + Start + "' " + " and  Datetime <  '" + End + "' "; ;
            sqlCommand.CommandType = CommandType.Text;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                MainConnection.Open();



                return int.Parse(sqlCommand.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("SERVICE_REPORT::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public int SelectCountByClientId(string Client, DateTime Start, DateTime End)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " select count(*) from SERVICE_REPORT where Client_Id=" + Client + " and  Datetime >  '" + Start + "' " + " and  Datetime <  '" + End + "' "; ;
            sqlCommand.CommandType = CommandType.Text;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                MainConnection.Open();



                return int.Parse(sqlCommand.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("SERVICE_REPORT::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public int SelectCountByKindId(string Kind, DateTime Start, DateTime End)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = " select count(*) from SERVICE_REPORT where kind_Id=" + Kind + " and  Datetime >  '" + Start + "' " + " and  Datetime <  '" + End + "' "; ;
            sqlCommand.CommandType = CommandType.Text;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                MainConnection.Open();



                return int.Parse(sqlCommand.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("SERVICE_REPORT::SelectByField::Error occured.", ex);
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
        public bool Delete(SERVICE_REPORTKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarSERVICE_REPORT_DeleteByPrimaryKey]";
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
                throw new Exception("SERVICE_REPORT::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[BazaarSERVICE_REPORT_DeleteByField]";
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
                throw new Exception("SERVICE_REPORT::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(SERVICE_REPORT businessObject, IDataReader dataReader)
        {


            businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.ID.ToString()));

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.CAT_ID.ToString())))
            {
                businessObject.CAT_ID = dataReader.GetInt32(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.CAT_ID.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.KIND_ID.ToString())))
            {
                businessObject.KIND_ID = dataReader.GetInt32(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.KIND_ID.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.CLIENT_ID.ToString())))
            {
                businessObject.CLIENT_ID = dataReader.GetInt32(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.CLIENT_ID.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.LIST_ID.ToString())))
            {
                businessObject.LIST_ID = dataReader.GetInt32(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.LIST_ID.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.TEXT.ToString())))
            {
                businessObject.TEXT = dataReader.GetString(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.TEXT.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.DATETIME.ToString())))
            {
                businessObject.DATETIME = dataReader.GetDateTime(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.DATETIME.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.USER_ID.ToString())))
            {
                businessObject.USER_ID = dataReader.GetInt32(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.USER_ID.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.SHIFT.ToString())))
            {
                businessObject.SHIFT = dataReader.GetInt32(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.SHIFT.ToString()));
            }

            if (!dataReader.IsDBNull(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.MINUTE.ToString())))
            {
                businessObject.MINUTE = dataReader.GetInt32(dataReader.GetOrdinal(SERVICE_REPORT.SERVICE_REPORTFields.MINUTE.ToString()));
            }


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of SERVICE_REPORT</returns>
        internal List<SERVICE_REPORT> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<SERVICE_REPORT> list = new List<SERVICE_REPORT>();

            while (dataReader.Read())
            {
                SERVICE_REPORT businessObject = new SERVICE_REPORT();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

    }
}
