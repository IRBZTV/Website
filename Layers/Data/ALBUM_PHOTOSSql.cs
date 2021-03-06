using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Bazaar.BusinessLayer.DataLayer
{
	/// <summary>
	/// Data access layer class for ALBUM_PHOTOS
	/// </summary>
	class ALBUM_PHOTOSSql : DataLayerBase 
	{

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ALBUM_PHOTOSSql()
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
		public bool Insert(ALBUM_PHOTOS businessObject)
		{
			SqlCommand	sqlCommand = new SqlCommand();
			sqlCommand.CommandText = "dbo.[BazaarALBUM_PHOTOS_Insert]";
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Use connection object of base class
			sqlCommand.Connection = MainConnection;

			try
			{
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
				sqlCommand.Parameters.Add(new SqlParameter("@PATH", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PATH));
				sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
				sqlCommand.Parameters.Add(new SqlParameter("@PRIORITY", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PRIORITY));
				sqlCommand.Parameters.Add(new SqlParameter("@ALBUM_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ALBUM_ID));

								
				MainConnection.Open();
				
				sqlCommand.ExecuteNonQuery();
                businessObject.ID = (int)sqlCommand.Parameters["@ID"].Value;

				return true;
			}
			catch(Exception ex)
			{				
				throw new Exception("ALBUM_PHOTOS::Insert::Error occured.", ex);
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
        public bool Update(ALBUM_PHOTOS businessObject)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUM_PHOTOS_Update]";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Use connection object of base class
            sqlCommand.Connection = MainConnection;

            try
            {
                
				sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ID));
				sqlCommand.Parameters.Add(new SqlParameter("@ACTIVE", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ACTIVE));
				sqlCommand.Parameters.Add(new SqlParameter("@PATH", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PATH));
				sqlCommand.Parameters.Add(new SqlParameter("@TITLE", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.TITLE));
				sqlCommand.Parameters.Add(new SqlParameter("@PRIORITY", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.PRIORITY));
				sqlCommand.Parameters.Add(new SqlParameter("@ALBUM_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, businessObject.ALBUM_ID));

                
                MainConnection.Open();

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ALBUM_PHOTOS::Update::Error occured.", ex);
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
        /// <returns>ALBUM_PHOTOS business object</returns>
        public ALBUM_PHOTOS SelectByPrimaryKey(ALBUM_PHOTOSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUM_PHOTOS_SelectByPrimaryKey]";
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
                    ALBUM_PHOTOS businessObject = new ALBUM_PHOTOS();

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
                throw new Exception("ALBUM_PHOTOS::SelectByPrimaryKey::Error occured.", ex);
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
        /// <returns>list of ALBUM_PHOTOS</returns>
        public List<ALBUM_PHOTOS> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUM_PHOTOS_SelectAll]";
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
                throw new Exception("ALBUM_PHOTOS::SelectAll::Error occured.", ex);
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
        /// <returns>list of ALBUM_PHOTOS</returns>
        public List<ALBUM_PHOTOS> SelectByField(string fieldName, object value)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUM_PHOTOS_SelectByField]";
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
                throw new Exception("ALBUM_PHOTOS::SelectByField::Error occured.", ex);
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
        public bool Delete(ALBUM_PHOTOSKeys keys)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "dbo.[BazaarALBUM_PHOTOS_DeleteByPrimaryKey]";
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
                throw new Exception("ALBUM_PHOTOS::DeleteByKey::Error occured.", ex);
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
            sqlCommand.CommandText = "dbo.[BazaarALBUM_PHOTOS_DeleteByField]";
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
                throw new Exception("ALBUM_PHOTOS::DeleteByField::Error occured.", ex);
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
        internal void PopulateBusinessObjectFromReader(ALBUM_PHOTOS businessObject, IDataReader dataReader)
        {


				businessObject.ID = dataReader.GetInt32(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.ID.ToString()));

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.ACTIVE.ToString())))
				{
					businessObject.ACTIVE = dataReader.GetBoolean(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.ACTIVE.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.PATH.ToString())))
				{
					businessObject.PATH = dataReader.GetString(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.PATH.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.TITLE.ToString())))
				{
					businessObject.TITLE = dataReader.GetString(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.TITLE.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.PRIORITY.ToString())))
				{
					businessObject.PRIORITY = dataReader.GetInt32(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.PRIORITY.ToString()));
				}

				if (!dataReader.IsDBNull(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.ALBUM_ID.ToString())))
				{
					businessObject.ALBUM_ID = dataReader.GetInt32(dataReader.GetOrdinal(ALBUM_PHOTOS.ALBUM_PHOTOSFields.ALBUM_ID.ToString()));
				}


        }

        /// <summary>
        /// Populate business objects from the data reader
        /// </summary>
        /// <param name="dataReader">data reader</param>
        /// <returns>list of ALBUM_PHOTOS</returns>
        internal List<ALBUM_PHOTOS> PopulateObjectsFromReader(IDataReader dataReader)
        {

            List<ALBUM_PHOTOS> list = new List<ALBUM_PHOTOS>();

            while (dataReader.Read())
            {
                ALBUM_PHOTOS businessObject = new ALBUM_PHOTOS();
                PopulateBusinessObjectFromReader(businessObject, dataReader);
                list.Add(businessObject);
            }
            return list;

        }

        #endregion

	}
}
