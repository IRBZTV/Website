using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class ECONOMY_TREEFactory
    {

        #region data Members

        ECONOMY_TREESql _dataObject = null;

        #endregion

        #region Constructor

        public ECONOMY_TREEFactory()
        {
            _dataObject = new ECONOMY_TREESql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new ECONOMY_TREE
        /// </summary>
        /// <param name="businessObject">ECONOMY_TREE object</param>
        /// <returns>true for successfully saved</returns>
        public int Insert(ECONOMY_TREE businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing ECONOMY_TREE
        /// </summary>
        /// <param name="businessObject">ECONOMY_TREE object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(ECONOMY_TREE businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get ECONOMY_TREE by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public ECONOMY_TREE GetByPrimaryKey(ECONOMY_TREEKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ECONOMY_TREEs
        /// </summary>
        /// <returns>list</returns>
        public List<ECONOMY_TREE> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of ECONOMY_TREE by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<ECONOMY_TREE> GetAllBy(ECONOMY_TREE.ECONOMY_TREEFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(ECONOMY_TREEKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete ECONOMY_TREE by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(ECONOMY_TREE.ECONOMY_TREEFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
