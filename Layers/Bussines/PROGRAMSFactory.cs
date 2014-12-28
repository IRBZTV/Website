using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class PROGRAMSFactory
    {

        #region data Members

        PROGRAMSSql _dataObject = null;

        #endregion

        #region Constructor

        public PROGRAMSFactory()
        {
            _dataObject = new PROGRAMSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new PROGRAMS
        /// </summary>
        /// <param name="businessObject">PROGRAMS object</param>
        /// <returns>true for successfully saved</returns>
        public int Insert(PROGRAMS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing PROGRAMS
        /// </summary>
        /// <param name="businessObject">PROGRAMS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(PROGRAMS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get PROGRAMS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public PROGRAMS GetByPrimaryKey(PROGRAMSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all PROGRAMSs
        /// </summary>
        /// <returns>list</returns>
        public List<PROGRAMS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of PROGRAMS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<PROGRAMS> GetAllBy(PROGRAMS.PROGRAMSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(PROGRAMSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete PROGRAMS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(PROGRAMS.PROGRAMSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
