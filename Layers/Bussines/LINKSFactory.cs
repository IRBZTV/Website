using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class LINKSFactory
    {

        #region data Members

        LINKSSql _dataObject = null;

        #endregion

        #region Constructor

        public LINKSFactory()
        {
            _dataObject = new LINKSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new LINKS
        /// </summary>
        /// <param name="businessObject">LINKS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(LINKS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing LINKS
        /// </summary>
        /// <param name="businessObject">LINKS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(LINKS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get LINKS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public LINKS GetByPrimaryKey(LINKSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all LINKSs
        /// </summary>
        /// <returns>list</returns>
        public List<LINKS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of LINKS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<LINKS> GetAllBy(LINKS.LINKSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(LINKSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete LINKS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(LINKS.LINKSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
