using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class ACCESSFactory
    {

        #region data Members

        ACCESSSql _dataObject = null;

        #endregion

        #region Constructor

        public ACCESSFactory()
        {
            _dataObject = new ACCESSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new ACCESS
        /// </summary>
        /// <param name="businessObject">ACCESS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(ACCESS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing ACCESS
        /// </summary>
        /// <param name="businessObject">ACCESS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(ACCESS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get ACCESS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public ACCESS GetByPrimaryKey(ACCESSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ACCESSs
        /// </summary>
        /// <returns>list</returns>
        public List<ACCESS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of ACCESS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<ACCESS> GetAllBy(ACCESS.ACCESSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(ACCESSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete ACCESS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(ACCESS.ACCESSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
