using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class COMMENTSFactory
    {

        #region data Members

        COMMENTSSql _dataObject = null;

        #endregion

        #region Constructor

        public COMMENTSFactory()
        {
            _dataObject = new COMMENTSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new COMMENTS
        /// </summary>
        /// <param name="businessObject">COMMENTS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(COMMENTS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing COMMENTS
        /// </summary>
        /// <param name="businessObject">COMMENTS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(COMMENTS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get COMMENTS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public COMMENTS GetByPrimaryKey(COMMENTSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all COMMENTSs
        /// </summary>
        /// <returns>list</returns>
        public List<COMMENTS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of COMMENTS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<COMMENTS> GetAllBy(COMMENTS.COMMENTSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(COMMENTSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete COMMENTS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(COMMENTS.COMMENTSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
