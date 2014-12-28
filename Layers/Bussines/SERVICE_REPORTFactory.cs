using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class SERVICE_REPORTFactory
    {

        #region data Members

        SERVICE_REPORTSql _dataObject = null;

        #endregion

        #region Constructor

        public SERVICE_REPORTFactory()
        {
            _dataObject = new SERVICE_REPORTSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new SERVICE_REPORT
        /// </summary>
        /// <param name="businessObject">SERVICE_REPORT object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(SERVICE_REPORT businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing SERVICE_REPORT
        /// </summary>
        /// <param name="businessObject">SERVICE_REPORT object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(SERVICE_REPORT businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get SERVICE_REPORT by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public SERVICE_REPORT GetByPrimaryKey(SERVICE_REPORTKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all SERVICE_REPORTs
        /// </summary>
        /// <returns>list</returns>
        public List<SERVICE_REPORT> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of SERVICE_REPORT by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<SERVICE_REPORT> GetAllBy(SERVICE_REPORT.SERVICE_REPORTFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(SERVICE_REPORTKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete SERVICE_REPORT by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(SERVICE_REPORT.SERVICE_REPORTFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
