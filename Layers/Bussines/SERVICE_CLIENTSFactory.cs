using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class SERVICE_CLIENTSFactory
    {

        #region data Members

        SERVICE_CLIENTSSql _dataObject = null;

        #endregion

        #region Constructor

        public SERVICE_CLIENTSFactory()
        {
            _dataObject = new SERVICE_CLIENTSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new SERVICE_CLIENTS
        /// </summary>
        /// <param name="businessObject">SERVICE_CLIENTS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(SERVICE_CLIENTS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing SERVICE_CLIENTS
        /// </summary>
        /// <param name="businessObject">SERVICE_CLIENTS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(SERVICE_CLIENTS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get SERVICE_CLIENTS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public SERVICE_CLIENTS GetByPrimaryKey(SERVICE_CLIENTSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all SERVICE_CLIENTSs
        /// </summary>
        /// <returns>list</returns>
        public List<SERVICE_CLIENTS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of SERVICE_CLIENTS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<SERVICE_CLIENTS> GetAllBy(SERVICE_CLIENTS.SERVICE_CLIENTSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(SERVICE_CLIENTSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete SERVICE_CLIENTS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(SERVICE_CLIENTS.SERVICE_CLIENTSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
