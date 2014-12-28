using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class PAGEFactory
    {

        #region data Members

        PAGESql _dataObject = null;

        #endregion

        #region Constructor

        public PAGEFactory()
        {
            _dataObject = new PAGESql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new PAGE
        /// </summary>
        /// <param name="businessObject">PAGE object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(PAGE businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing PAGE
        /// </summary>
        /// <param name="businessObject">PAGE object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(PAGE businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get PAGE by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public PAGE GetByPrimaryKey(PAGEKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all PAGEs
        /// </summary>
        /// <returns>list</returns>
        public List<PAGE> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of PAGE by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<PAGE> GetAllBy(PAGE.PAGEFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(PAGEKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete PAGE by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(PAGE.PAGEFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
