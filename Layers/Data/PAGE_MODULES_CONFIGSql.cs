using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Bazaar.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for PAGE_MODULES_CONFIG
	/// </summary>
	class PAGE_MODULES_CONFIGSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public PAGE_MODULES_CONFIGSql()
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
		public bool Insert(PAGE_MODULES_CONFIG businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_CONFIG_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@PAGE_MODULE_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PAGE_MODULE_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@MODULE_PARAM_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MODULE_PARAM_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@VALUE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VALUE));
				sqlCommand.Parameters.Add(new SqlParameter("@PARAM_TITLE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PARAM_TITLE));

								
				MainConnection.Open();
				
				sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

				return true;
			}
			catch(Exception ex)
			{				
				throw new Exception("PAGE_MODULES_CONFIG::Insert::Error occured.", ex);
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
        public bool Update(PAGE_MODULES_CONFIG businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_CONFIG_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@PAGE_MODULE_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PAGE_MODULE_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@MODULE_PARAM_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MODULE_PARAM_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@VALUE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VALUE));
				sqlCommand.Parameters.Add(new SqlParameter("@PARAM_TITLE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PARAM_TITLE));

                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PAGE_MODULES_CONFIG::Update::Error occured.", ex);
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
        /// <returns>PAGE_MODULES_CONFIG business object</returns>
        public PAGE_MODULES_CONFIG SelectByPrimaryKey(PAGE_MODULES_CONFIGKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_CONFIG_SelectByPrimaryKey]";
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
                    PAGE_MODULES_CONFIG businessObject = new PAGE_MODULES_CONFIG();

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
                throw new Exception("PAGE_MODULES_CONFIG::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of PAGE_MODULES_CONFIG</returns>
        public List<PAGE_MODULES_CONFIG> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_CONFIG_SelectAll]";
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
                throw new Exception("PAGE_MODULES_CONFIG::SelectAll::Error occured.", ex);
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
        /// <returns>list of PAGE_MODULES_CONFIG</returns>
        public List<PAGE_MODULES_CONFIG> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_CONFIG_SelectByField]";
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
                throw new Exception("PAGE_MODULES_CONFIG::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }


         public  PAGE_MODULES_CONFIG Select_Parameters_Value(string ParamTitle, int  Page_Module_Id)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[Page_Module_Config_Select_Values]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@ParamTitle", ParamTitle));
                sqlCommand.Parameters.Add(new SqlParameter("@PageModuleId", Page_Module_Id));

                MainConnection.Open();

                IDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.Read())
                {
                    PAGE_MODULES_CONFIG businessObject = new PAGE_MODULES_CONFIG();

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
                throw new Exception("PAGE_MODULES_CONFIG::Select_Parameters_Value::Error occured.", ex);
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
        public bool Delete(PAGE_MODULES_CONFIGKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_CONFIG_DeleteByPrimaryKey]";
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
                throw new Exception("PAGE_MODULES_CONFIG::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_CONFIG_DeleteByField]";
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
                throw new Exception("PAGE_MODULES_CONFIG::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(PAGE_MODULES_CONFIG businessObject, IDataReader dataReader)
        {


				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields.ID.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields.PAGE_MODULE_ID.ToString())))
				{
					businessObject.PAGE_MODULE_ID = dataReader.GetInt32(dataReader.GetOrdinal(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields.PAGE_MODULE_ID.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields.MODULE_PARAM_ID.ToString())))
				{
					businessObject.MODULE_PARAM_ID = dataReader.GetInt32(dataReader.GetOrdinal(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields.MODULE_PARAM_ID.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields.VALUE.ToString())))
				{
					businessObject.VALUE = dataReader.GetString(dataReader.GetOrdinal(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields.VALUE.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields.PARAM_TITLE.ToString())))
				{
					businessObject.PARAM_TITLE = dataReader.GetString(dataReader.GetOrdinal(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields.PARAM_TITLE.ToString()));
				}


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of PAGE_MODULES_CONFIG</returns>
        internal List<PAGE_MODULES_CONFIG> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<PAGE_MODULES_CONFIG> list = new List<PAGE_MODULES_CONFIG>();

            while (dataReader.Read())
            {
                PAGE_MODULES_CONFIG businessObject = new PAGE_MODULES_CONFIG();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
