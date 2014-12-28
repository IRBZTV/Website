using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class CONTENTS_RELATIONFactory
    {

        #region data Members

        CONTENTS_RELATIONSql _dataObject = null;

        #endregion

        #region Constructor

        public CONTENTS_RELATIONFactory()
        {
            _dataObject = new CONTENTS_RELATIONSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new CONTENTS_RELATION
        /// </summary>
        /// <param name="businessObject">CONTENTS_RELATION object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(CONTENTS_RELATION businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing CONTENTS_RELATION
        /// </summary>
        /// <param name="businessObject">CONTENTS_RELATION object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(CONTENTS_RELATION businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get CONTENTS_RELATION by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public CONTENTS_RELATION GetByPrimaryKey(CONTENTS_RELATIONKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all CONTENTS_RELATIONs
        /// </summary>
        /// <returns>list</returns>
        public List<CONTENTS_RELATION> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of CONTENTS_RELATION by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<CONTENTS_RELATION> GetAllBy(CONTENTS_RELATION.CONTENTS_RELATIONFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(CONTENTS_RELATIONKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete CONTENTS_RELATION by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(CONTENTS_RELATION.CONTENTS_RELATIONFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
