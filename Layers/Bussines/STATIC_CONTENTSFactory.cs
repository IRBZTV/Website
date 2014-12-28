using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class STATIC_CONTENTSFactory
    {

        #region data Members

        STATIC_CONTENTSSql _dataObject = null;

        #endregion

        #region Constructor

        public STATIC_CONTENTSFactory()
        {
            _dataObject = new STATIC_CONTENTSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new STATIC_CONTENTS
        /// </summary>
        /// <param name="businessObject">STATIC_CONTENTS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(STATIC_CONTENTS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing STATIC_CONTENTS
        /// </summary>
        /// <param name="businessObject">STATIC_CONTENTS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(STATIC_CONTENTS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get STATIC_CONTENTS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public STATIC_CONTENTS GetByPrimaryKey(STATIC_CONTENTSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all STATIC_CONTENTSs
        /// </summary>
        /// <returns>list</returns>
        public List<STATIC_CONTENTS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of STATIC_CONTENTS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<STATIC_CONTENTS> GetAllBy(STATIC_CONTENTS.STATIC_CONTENTSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(STATIC_CONTENTSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete STATIC_CONTENTS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(STATIC_CONTENTS.STATIC_CONTENTSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
