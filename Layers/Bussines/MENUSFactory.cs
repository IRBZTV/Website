using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class MENUSFactory
    {

        #region data Members

        MENUSSql _dataObject = null;

        #endregion

        #region Constructor

        public MENUSFactory()
        {
            _dataObject = new MENUSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new MENUS
        /// </summary>
        /// <param name="businessObject">MENUS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(MENUS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing MENUS
        /// </summary>
        /// <param name="businessObject">MENUS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(MENUS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get MENUS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public MENUS GetByPrimaryKey(MENUSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all MENUSs
        /// </summary>
        /// <returns>list</returns>
        public List<MENUS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of MENUS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<MENUS> GetAllBy(MENUS.MENUSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(MENUSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete MENUS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(MENUS.MENUSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
