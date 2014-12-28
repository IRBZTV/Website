using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class CONTENTSFactory
    {

        #region data Members

        CONTENTSSql _dataObject = null;

        #endregion

        #region Constructor

        public CONTENTSFactory()
        {
            _dataObject = new CONTENTSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new CONTENTS
        /// </summary>
        /// <param name="businessObject">CONTENTS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(CONTENTS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing CONTENTS
        /// </summary>
        /// <param name="businessObject">CONTENTS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(CONTENTS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get CONTENTS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public CONTENTS GetByPrimaryKey(CONTENTSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all CONTENTSs
        /// </summary>
        /// <returns>list</returns>
        public List<CONTENTS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of CONTENTS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<CONTENTS> GetAllBy(CONTENTS.CONTENTSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(CONTENTSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete CONTENTS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(CONTENTS.CONTENTSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
