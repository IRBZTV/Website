using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class CATEGORIESFactory
    {

        #region data Members

        CATEGORIESSql _dataObject = null;

        #endregion

        #region Constructor

        public CATEGORIESFactory()
        {
            _dataObject = new CATEGORIESSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new CATEGORIES
        /// </summary>
        /// <param name="businessObject">CATEGORIES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(CATEGORIES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing CATEGORIES
        /// </summary>
        /// <param name="businessObject">CATEGORIES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(CATEGORIES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get CATEGORIES by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public CATEGORIES GetByPrimaryKey(CATEGORIESKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all CATEGORIESs
        /// </summary>
        /// <returns>list</returns>
        public List<CATEGORIES> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of CATEGORIES by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<CATEGORIES> GetAllBy(CATEGORIES.CATEGORIESFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(CATEGORIESKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete CATEGORIES by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(CATEGORIES.CATEGORIESFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
