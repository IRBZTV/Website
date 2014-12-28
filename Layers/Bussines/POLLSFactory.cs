using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class POLLSFactory
    {

        #region data Members

        POLLSSql _dataObject = null;

        #endregion

        #region Constructor

        public POLLSFactory()
        {
            _dataObject = new POLLSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new POLLS
        /// </summary>
        /// <param name="businessObject">POLLS object</param>
        /// <returns>true for successfully saved</returns>
        public int Insert(POLLS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing POLLS
        /// </summary>
        /// <param name="businessObject">POLLS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(POLLS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get POLLS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public POLLS GetByPrimaryKey(POLLSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all POLLSs
        /// </summary>
        /// <returns>list</returns>
        public List<POLLS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of POLLS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<POLLS> GetAllBy(POLLS.POLLSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(POLLSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete POLLS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(POLLS.POLLSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
