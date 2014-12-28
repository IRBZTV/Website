using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class SERVICE_CATEGORIESFactory
    {

        #region data Members

        SERVICE_CATEGORIESSql _dataObject = null;

        #endregion

        #region Constructor

        public SERVICE_CATEGORIESFactory()
        {
            _dataObject = new SERVICE_CATEGORIESSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new SERVICE_CATEGORIES
        /// </summary>
        /// <param name="businessObject">SERVICE_CATEGORIES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(SERVICE_CATEGORIES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing SERVICE_CATEGORIES
        /// </summary>
        /// <param name="businessObject">SERVICE_CATEGORIES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(SERVICE_CATEGORIES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get SERVICE_CATEGORIES by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public SERVICE_CATEGORIES GetByPrimaryKey(SERVICE_CATEGORIESKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all SERVICE_CATEGORIESs
        /// </summary>
        /// <returns>list</returns>
        public List<SERVICE_CATEGORIES> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of SERVICE_CATEGORIES by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<SERVICE_CATEGORIES> GetAllBy(SERVICE_CATEGORIES.SERVICE_CATEGORIESFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(SERVICE_CATEGORIESKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete SERVICE_CATEGORIES by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(SERVICE_CATEGORIES.SERVICE_CATEGORIESFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
