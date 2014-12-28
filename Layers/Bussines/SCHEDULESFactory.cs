using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class SCHEDULESFactory
    {

        #region data Members

        SCHEDULESSql _dataObject = null;

        #endregion

        #region Constructor

        public SCHEDULESFactory()
        {
            _dataObject = new SCHEDULESSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new SCHEDULES
        /// </summary>
        /// <param name="businessObject">SCHEDULES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(SCHEDULES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing SCHEDULES
        /// </summary>
        /// <param name="businessObject">SCHEDULES object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(SCHEDULES businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get SCHEDULES by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public SCHEDULES GetByPrimaryKey(SCHEDULESKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all SCHEDULESs
        /// </summary>
        /// <returns>list</returns>
        public List<SCHEDULES> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of SCHEDULES by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<SCHEDULES> GetAllBy(SCHEDULES.SCHEDULESFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(SCHEDULESKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete SCHEDULES by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(SCHEDULES.SCHEDULESFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
