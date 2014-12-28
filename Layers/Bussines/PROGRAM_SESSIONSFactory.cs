using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class PROGRAM_SESSIONSFactory
    {

        #region data Members

        PROGRAM_SESSIONSSql _dataObject = null;

        #endregion

        #region Constructor

        public PROGRAM_SESSIONSFactory()
        {
            _dataObject = new PROGRAM_SESSIONSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new PROGRAM_SESSIONS
        /// </summary>
        /// <param name="businessObject">PROGRAM_SESSIONS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(PROGRAM_SESSIONS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing PROGRAM_SESSIONS
        /// </summary>
        /// <param name="businessObject">PROGRAM_SESSIONS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(PROGRAM_SESSIONS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get PROGRAM_SESSIONS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public PROGRAM_SESSIONS GetByPrimaryKey(PROGRAM_SESSIONSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all PROGRAM_SESSIONSs
        /// </summary>
        /// <returns>list</returns>
        public List<PROGRAM_SESSIONS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of PROGRAM_SESSIONS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<PROGRAM_SESSIONS> GetAllBy(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(PROGRAM_SESSIONSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete PROGRAM_SESSIONS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(PROGRAM_SESSIONS.PROGRAM_SESSIONSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
