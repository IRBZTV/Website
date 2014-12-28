using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Bazaar.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for PAGE_MODULES
	/// </summary>
	class PAGE_MODULESSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public PAGE_MODULESSql()
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
		public int Insert(PAGE_MODULES businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@PAGE_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PAGE_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@MODULE_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MODULE_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@POSITION_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.POSITION_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@SORT", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SORT));
				sqlCommand.Parameters.Add(new SqlParameter("@CONTAINER_LAYOUT", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CONTAINER_LAYOUT));
				sqlCommand.Parameters.Add(new SqlParameter("@TEMPLATE", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TEMPLATE));
				sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@VISIBLE", SqlDbType.Bit, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VISIBLE));

								
				MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                businessObject.ID = int.Parse(sqlCommand.Parameters["@ID"].Value.ToString());

                return businessObject.ID;
			}
			catch(Exception ex)
			{				
				throw new Exception("PAGE_MODULES::Insert::Error occured.", ex);
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
        public bool Update(PAGE_MODULES businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@PAGE_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PAGE_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@MODULE_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.MODULE_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@POSITION_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.POSITION_ID));
				sqlCommand.Parameters.Add(new SqlParameter("@SORT", SqlDbType.SmallInt, 2, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.SORT));
				sqlCommand.Parameters.Add(new SqlParameter("@CONTAINER_LAYOUT", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.CONTAINER_LAYOUT));
				sqlCommand.Parameters.Add(new SqlParameter("@TEMPLATE", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TEMPLATE));
				sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
                sqlCommand.Parameters.Add(new SqlParameter("@VISIBLE", SqlDbType.Bit, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.VISIBLE));
                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("PAGE_MODULES::Update::Error occured.", ex);
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
        /// <returns>PAGE_MODULES business object</returns>
        public PAGE_MODULES SelectByPrimaryKey(PAGE_MODULESKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_SelectByPrimaryKey]";
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
                    PAGE_MODULES businessObject = new PAGE_MODULES();

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
                throw new Exception("PAGE_MODULES::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of PAGE_MODULES</returns>
        public List<PAGE_MODULES> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_SelectAll]";
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
                throw new Exception("PAGE_MODULES::SelectAll::Error occured.", ex);
            }
            finally
            {
                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }







        public List<PAGE_MODULES> Select_ByPageId_Position(int PageId,int PostitionId)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "Page_Modules_Select_ByPageId_Position";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {

                sqlCommand.Parameters.Add(new SqlParameter("@PageId", PageId));
                sqlCommand.Parameters.Add(new SqlParameter("@PositionId", PostitionId));

                MainConnection.Open();
                
                IDataReader dataReader = sqlCommand.ExecuteReader();

                return PopulateObjectsFromReader(dataReader);

            }
            catch (Exception ex)
            {
                throw new Exception("PAGE_MODULES::SelectByField::Error occured.", ex);
            }
            finally
            {

                MainConnection.Close();
                sqlCommand.Dispose();
            }

        }
        public List<PAGE_MODULES> Select_ByCondition(string Condition)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "[dbo].[BazaarPAGE_MODULES_SelectByCondition]";
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
                throw new Exception("PAGE_MODULES::SelectByField::Error occured.", ex);
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
        /// <returns>list of PAGE_MODULES</returns>
        public List<PAGE_MODULES> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_SelectByField]";
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
                throw new Exception("PAGE_MODULES::SelectByField::Error occured.", ex);
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
        public bool Delete(PAGE_MODULESKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_DeleteByPrimaryKey]";
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
                throw new Exception("PAGE_MODULES::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[BazaarPAGE_MODULES_DeleteByField]";
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
                throw new Exception("PAGE_MODULES::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(PAGE_MODULES businessObject, IDataReader dataReader)
        {


				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.ID.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.PAGE_ID.ToString())))
				{
					businessObject.PAGE_ID = dataReader.GetInt32(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.PAGE_ID.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.MODULE_ID.ToString())))
				{
					businessObject.MODULE_ID = dataReader.GetInt32(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.MODULE_ID.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.POSITION_ID.ToString())))
				{
					businessObject.POSITION_ID = dataReader.GetInt32(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.POSITION_ID.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.SORT.ToString())))
				{
					businessObject.SORT = (byte?)dataReader.GetInt16(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.SORT.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.CONTAINER_LAYOUT.ToString())))
				{
					businessObject.CONTAINER_LAYOUT = dataReader.GetString(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.CONTAINER_LAYOUT.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.TEMPLATE.ToString())))
				{
					businessObject.TEMPLATE = dataReader.GetString(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.TEMPLATE.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.TITLE.ToString())))
				{
					businessObject.TITLE = dataReader.GetString(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.TITLE.ToString()));
				}
                if (!dataReader.IsDBNull(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.VISIBLE.ToString())))
                {
                    businessObject.VISIBLE = dataReader.GetBoolean(dataReader.GetOrdinal(PAGE_MODULES.PAGE_MODULESFields.VISIBLE.ToString()));
                }


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of PAGE_MODULES</returns>
        internal List<PAGE_MODULES> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<PAGE_MODULES> list = new List<PAGE_MODULES>();

            while (dataReader.Read())
            {
                PAGE_MODULES businessObject = new PAGE_MODULES();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
