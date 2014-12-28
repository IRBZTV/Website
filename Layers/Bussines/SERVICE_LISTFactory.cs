using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class SERVICE_LISTFactory
    {

        #region data Members

        SERVICE_LISTSql _dataObject = null;

        #endregion

        #region Constructor

        public SERVICE_LISTFactory()
        {
            _dataObject = new SERVICE_LISTSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new SERVICE_LIST
        /// </summary>
        /// <param name="businessObject">SERVICE_LIST object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(SERVICE_LIST businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing SERVICE_LIST
        /// </summary>
        /// <param name="businessObject">SERVICE_LIST object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(SERVICE_LIST businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get SERVICE_LIST by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public SERVICE_LIST GetByPrimaryKey(SERVICE_LISTKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all SERVICE_LISTs
        /// </summary>
        /// <returns>list</returns>
        public List<SERVICE_LIST> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of SERVICE_LIST by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<SERVICE_LIST> GetAllBy(SERVICE_LIST.SERVICE_LISTFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(SERVICE_LISTKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete SERVICE_LIST by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(SERVICE_LIST.SERVICE_LISTFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
