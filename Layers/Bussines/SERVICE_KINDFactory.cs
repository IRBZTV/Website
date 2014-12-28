using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class SERVICE_KINDFactory
    {

        #region data Members

        SERVICE_KINDSql _dataObject = null;

        #endregion

        #region Constructor

        public SERVICE_KINDFactory()
        {
            _dataObject = new SERVICE_KINDSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new SERVICE_KIND
        /// </summary>
        /// <param name="businessObject">SERVICE_KIND object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(SERVICE_KIND businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing SERVICE_KIND
        /// </summary>
        /// <param name="businessObject">SERVICE_KIND object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(SERVICE_KIND businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get SERVICE_KIND by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public SERVICE_KIND GetByPrimaryKey(SERVICE_KINDKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all SERVICE_KINDs
        /// </summary>
        /// <returns>list</returns>
        public List<SERVICE_KIND> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of SERVICE_KIND by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<SERVICE_KIND> GetAllBy(SERVICE_KIND.SERVICE_KINDFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(SERVICE_KINDKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete SERVICE_KIND by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(SERVICE_KIND.SERVICE_KINDFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
