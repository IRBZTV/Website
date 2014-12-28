using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class PAGE_MODULESFactory
    {

        #region data Members

        PAGE_MODULESSql _dataObject = null;

        #endregion

        #region Constructor

        public PAGE_MODULESFactory()
        {
            _dataObject = new PAGE_MODULESSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new PAGE_MODULES
        /// </summary>
        /// <param name="businessObject">PAGE_MODULES object</param>
        /// <returns>true for successfully saved</returns>
        public int Insert(PAGE_MODULES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing PAGE_MODULES
        /// </summary>
        /// <param name="businessObject">PAGE_MODULES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(PAGE_MODULES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get PAGE_MODULES by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public PAGE_MODULES GetByPrimaryKey(PAGE_MODULESKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all PAGE_MODULESs
        /// </summary>
        /// <returns>list</returns>
        public List<PAGE_MODULES> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of PAGE_MODULES by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<PAGE_MODULES> GetAllBy(PAGE_MODULES.PAGE_MODULESFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(PAGE_MODULESKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete PAGE_MODULES by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(PAGE_MODULES.PAGE_MODULESFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
