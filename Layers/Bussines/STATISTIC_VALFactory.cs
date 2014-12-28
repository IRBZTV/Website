using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class STATISTIC_VALFactory
    {

        #region data Members

        STATISTIC_VALSql _dataObject = null;

        #endregion

        #region Constructor

        public STATISTIC_VALFactory()
        {
            _dataObject = new STATISTIC_VALSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new STATISTIC_VAL
        /// </summary>
        /// <param name="businessObject">STATISTIC_VAL object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(STATISTIC_VAL businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing STATISTIC_VAL
        /// </summary>
        /// <param name="businessObject">STATISTIC_VAL object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(STATISTIC_VAL businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get STATISTIC_VAL by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public STATISTIC_VAL GetByPrimaryKey(STATISTIC_VALKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all STATISTIC_VALs
        /// </summary>
        /// <returns>list</returns>
        public List<STATISTIC_VAL> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of STATISTIC_VAL by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<STATISTIC_VAL> GetAllBy(STATISTIC_VAL.STATISTIC_VALFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(STATISTIC_VALKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete STATISTIC_VAL by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(STATISTIC_VAL.STATISTIC_VALFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
