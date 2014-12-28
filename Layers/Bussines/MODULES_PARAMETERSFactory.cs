using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class MODULES_PARAMETERSFactory
    {

        #region data Members

        MODULES_PARAMETERSSql _dataObject = null;

        #endregion

        #region Constructor

        public MODULES_PARAMETERSFactory()
        {
            _dataObject = new MODULES_PARAMETERSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new MODULES_PARAMETERS
        /// </summary>
        /// <param name="businessObject">MODULES_PARAMETERS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(MODULES_PARAMETERS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing MODULES_PARAMETERS
        /// </summary>
        /// <param name="businessObject">MODULES_PARAMETERS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(MODULES_PARAMETERS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get MODULES_PARAMETERS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public MODULES_PARAMETERS GetByPrimaryKey(MODULES_PARAMETERSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all MODULES_PARAMETERSs
        /// </summary>
        /// <returns>list</returns>
        public List<MODULES_PARAMETERS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of MODULES_PARAMETERS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<MODULES_PARAMETERS> GetAllBy(MODULES_PARAMETERS.MODULES_PARAMETERSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(MODULES_PARAMETERSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete MODULES_PARAMETERS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(MODULES_PARAMETERS.MODULES_PARAMETERSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
