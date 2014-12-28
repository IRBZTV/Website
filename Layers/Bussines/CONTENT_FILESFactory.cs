using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class CONTENT_FILESFactory
    {

        #region data Members

        CONTENT_FILESSql _dataObject = null;

        #endregion

        #region Constructor

        public CONTENT_FILESFactory()
        {
            _dataObject = new CONTENT_FILESSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new CONTENT_FILES
        /// </summary>
        /// <param name="businessObject">CONTENT_FILES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(CONTENT_FILES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing CONTENT_FILES
        /// </summary>
        /// <param name="businessObject">CONTENT_FILES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(CONTENT_FILES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get CONTENT_FILES by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public CONTENT_FILES GetByPrimaryKey(CONTENT_FILESKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all CONTENT_FILESs
        /// </summary>
        /// <returns>list</returns>
        public List<CONTENT_FILES> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of CONTENT_FILES by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<CONTENT_FILES> GetAllBy(CONTENT_FILES.CONTENT_FILESFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(CONTENT_FILESKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete CONTENT_FILES by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(CONTENT_FILES.CONTENT_FILESFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
