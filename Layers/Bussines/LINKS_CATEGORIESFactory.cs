using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class LINKS_CATEGORIESFactory
    {

        #region data Members

        LINKS_CATEGORIESSql _dataObject = null;

        #endregion

        #region Constructor

        public LINKS_CATEGORIESFactory()
        {
            _dataObject = new LINKS_CATEGORIESSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new LINKS_CATEGORIES
        /// </summary>
        /// <param name="businessObject">LINKS_CATEGORIES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(LINKS_CATEGORIES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing LINKS_CATEGORIES
        /// </summary>
        /// <param name="businessObject">LINKS_CATEGORIES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(LINKS_CATEGORIES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get LINKS_CATEGORIES by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public LINKS_CATEGORIES GetByPrimaryKey(LINKS_CATEGORIESKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all LINKS_CATEGORIESs
        /// </summary>
        /// <returns>list</returns>
        public List<LINKS_CATEGORIES> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of LINKS_CATEGORIES by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<LINKS_CATEGORIES> GetAllBy(LINKS_CATEGORIES.LINKS_CATEGORIESFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(LINKS_CATEGORIESKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete LINKS_CATEGORIES by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(LINKS_CATEGORIES.LINKS_CATEGORIESFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
