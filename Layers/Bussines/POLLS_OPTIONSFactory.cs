using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class POLLS_OPTIONSFactory
    {

        #region data Members

        POLLS_OPTIONSSql _dataObject = null;

        #endregion

        #region Constructor

        public POLLS_OPTIONSFactory()
        {
            _dataObject = new POLLS_OPTIONSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new POLLS_OPTIONS
        /// </summary>
        /// <param name="businessObject">POLLS_OPTIONS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(POLLS_OPTIONS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing POLLS_OPTIONS
        /// </summary>
        /// <param name="businessObject">POLLS_OPTIONS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(POLLS_OPTIONS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get POLLS_OPTIONS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public POLLS_OPTIONS GetByPrimaryKey(POLLS_OPTIONSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all POLLS_OPTIONSs
        /// </summary>
        /// <returns>list</returns>
        public List<POLLS_OPTIONS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of POLLS_OPTIONS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<POLLS_OPTIONS> GetAllBy(POLLS_OPTIONS.POLLS_OPTIONSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(POLLS_OPTIONSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete POLLS_OPTIONS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(POLLS_OPTIONS.POLLS_OPTIONSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
