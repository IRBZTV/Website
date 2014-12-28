using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class MODULESFactory
    {

        #region data Members

        MODULESSql _dataObject = null;

        #endregion

        #region Constructor

        public MODULESFactory()
        {
            _dataObject = new MODULESSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new MODULES
        /// </summary>
        /// <param name="businessObject">MODULES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(MODULES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing MODULES
        /// </summary>
        /// <param name="businessObject">MODULES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(MODULES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get MODULES by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public MODULES GetByPrimaryKey(MODULESKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all MODULESs
        /// </summary>
        /// <returns>list</returns>
        public List<MODULES> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of MODULES by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<MODULES> GetAllBy(MODULES.MODULESFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(MODULESKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete MODULES by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(MODULES.MODULESFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
