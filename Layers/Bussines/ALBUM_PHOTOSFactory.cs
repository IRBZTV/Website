using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class ALBUM_PHOTOSFactory
    {

        #region data Members

        ALBUM_PHOTOSSql _dataObject = null;

        #endregion

        #region Constructor

        public ALBUM_PHOTOSFactory()
        {
            _dataObject = new ALBUM_PHOTOSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new ALBUM_PHOTOS
        /// </summary>
        /// <param name="businessObject">ALBUM_PHOTOS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(ALBUM_PHOTOS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing ALBUM_PHOTOS
        /// </summary>
        /// <param name="businessObject">ALBUM_PHOTOS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(ALBUM_PHOTOS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get ALBUM_PHOTOS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public ALBUM_PHOTOS GetByPrimaryKey(ALBUM_PHOTOSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ALBUM_PHOTOSs
        /// </summary>
        /// <returns>list</returns>
        public List<ALBUM_PHOTOS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of ALBUM_PHOTOS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<ALBUM_PHOTOS> GetAllBy(ALBUM_PHOTOS.ALBUM_PHOTOSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(ALBUM_PHOTOSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete ALBUM_PHOTOS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(ALBUM_PHOTOS.ALBUM_PHOTOSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
