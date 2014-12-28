using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class PAGE_POSITIONSFactory
    {

        #region data Members

        PAGE_POSITIONSSql _dataObject = null;

        #endregion

        #region Constructor

        public PAGE_POSITIONSFactory()
        {
            _dataObject = new PAGE_POSITIONSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new PAGE_POSITIONS
        /// </summary>
        /// <param name="businessObject">PAGE_POSITIONS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(PAGE_POSITIONS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing PAGE_POSITIONS
        /// </summary>
        /// <param name="businessObject">PAGE_POSITIONS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(PAGE_POSITIONS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get PAGE_POSITIONS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public PAGE_POSITIONS GetByPrimaryKey(PAGE_POSITIONSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all PAGE_POSITIONSs
        /// </summary>
        /// <returns>list</returns>
        public List<PAGE_POSITIONS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of PAGE_POSITIONS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<PAGE_POSITIONS> GetAllBy(PAGE_POSITIONS.PAGE_POSITIONSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(PAGE_POSITIONSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete PAGE_POSITIONS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(PAGE_POSITIONS.PAGE_POSITIONSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
