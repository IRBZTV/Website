using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class PAGE_MODULES_CONFIGFactory
    {

        #region data Members

        PAGE_MODULES_CONFIGSql _dataObject = null;

        #endregion

        #region Constructor

        public PAGE_MODULES_CONFIGFactory()
        {
            _dataObject = new PAGE_MODULES_CONFIGSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new PAGE_MODULES_CONFIG
        /// </summary>
        /// <param name="businessObject">PAGE_MODULES_CONFIG object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(PAGE_MODULES_CONFIG businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing PAGE_MODULES_CONFIG
        /// </summary>
        /// <param name="businessObject">PAGE_MODULES_CONFIG object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(PAGE_MODULES_CONFIG businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get PAGE_MODULES_CONFIG by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public PAGE_MODULES_CONFIG GetByPrimaryKey(PAGE_MODULES_CONFIGKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all PAGE_MODULES_CONFIGs
        /// </summary>
        /// <returns>list</returns>
        public List<PAGE_MODULES_CONFIG> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of PAGE_MODULES_CONFIG by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<PAGE_MODULES_CONFIG> GetAllBy(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(PAGE_MODULES_CONFIGKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete PAGE_MODULES_CONFIG by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(PAGE_MODULES_CONFIG.PAGE_MODULES_CONFIGFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
