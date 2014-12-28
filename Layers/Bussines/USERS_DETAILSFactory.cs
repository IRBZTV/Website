using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class USERS_DETAILSFactory
    {

        #region data Members

        USERS_DETAILSSql _dataObject = null;

        #endregion

        #region Constructor

        public USERS_DETAILSFactory()
        {
            _dataObject = new USERS_DETAILSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new USERS_DETAILS
        /// </summary>
        /// <param name="businessObject">USERS_DETAILS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(USERS_DETAILS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing USERS_DETAILS
        /// </summary>
        /// <param name="businessObject">USERS_DETAILS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(USERS_DETAILS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get USERS_DETAILS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public USERS_DETAILS GetByPrimaryKey(USERS_DETAILSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all USERS_DETAILSs
        /// </summary>
        /// <returns>list</returns>
        public List<USERS_DETAILS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of USERS_DETAILS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<USERS_DETAILS> GetAllBy(USERS_DETAILS.USERS_DETAILSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(USERS_DETAILSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete USERS_DETAILS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(USERS_DETAILS.USERS_DETAILSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
