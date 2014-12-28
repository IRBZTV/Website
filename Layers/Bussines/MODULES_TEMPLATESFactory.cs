using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class MODULES_TEMPLATESFactory
    {

        #region data Members

        MODULES_TEMPLATESSql _dataObject = null;

        #endregion

        #region Constructor

        public MODULES_TEMPLATESFactory()
        {
            _dataObject = new MODULES_TEMPLATESSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new MODULES_TEMPLATES
        /// </summary>
        /// <param name="businessObject">MODULES_TEMPLATES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(MODULES_TEMPLATES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing MODULES_TEMPLATES
        /// </summary>
        /// <param name="businessObject">MODULES_TEMPLATES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(MODULES_TEMPLATES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get MODULES_TEMPLATES by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public MODULES_TEMPLATES GetByPrimaryKey(MODULES_TEMPLATESKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all MODULES_TEMPLATESs
        /// </summary>
        /// <returns>list</returns>
        public List<MODULES_TEMPLATES> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of MODULES_TEMPLATES by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<MODULES_TEMPLATES> GetAllBy(MODULES_TEMPLATES.MODULES_TEMPLATESFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(MODULES_TEMPLATESKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete MODULES_TEMPLATES by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(MODULES_TEMPLATES.MODULES_TEMPLATESFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
