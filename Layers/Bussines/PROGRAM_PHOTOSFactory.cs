using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bazaar.BusinessLayer.DataLayer;

namespace Bazaar.BusinessLayer
{
    public class PROGRAM_PHOTOSFactory
    {

        #region data Members

        PROGRAM_PHOTOSSql _dataObject = null;

        #endregion

        #region Constructor

        public PROGRAM_PHOTOSFactory()
        {
            _dataObject = new PROGRAM_PHOTOSSql();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Insert new PROGRAM_PHOTOS
        /// </summary>
        /// <param name="businessObject">PROGRAM_PHOTOS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Insert(PROGRAM_PHOTOS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Insert(businessObject);

        }

        /// <summary>
        /// Update existing PROGRAM_PHOTOS
        /// </summary>
        /// <param name="businessObject">PROGRAM_PHOTOS object</param>
        /// <returns>true for successfully saved</returns>
        public bool Update(PROGRAM_PHOTOS businessObject)
        {
            if (!businessObject.IsValid)
            {
                throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
            }


            return _dataObject.Update(businessObject);
        }

        /// <summary>
        /// get PROGRAM_PHOTOS by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public PROGRAM_PHOTOS GetByPrimaryKey(PROGRAM_PHOTOSKeys keys)
        {
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all PROGRAM_PHOTOSs
        /// </summary>
        /// <returns>list</returns>
        public List<PROGRAM_PHOTOS> GetAll()
        {
            return _dataObject.SelectAll(); 
        }

        /// <summary>
        /// get list of PROGRAM_PHOTOS by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public List<PROGRAM_PHOTOS> GetAllBy(PROGRAM_PHOTOS.PROGRAM_PHOTOSFields fieldName, object value)
        {
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public bool Delete(PROGRAM_PHOTOSKeys keys)
        {
            return _dataObject.Delete(keys); 
        }

        /// <summary>
        /// delete PROGRAM_PHOTOS by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public bool Delete(PROGRAM_PHOTOS.PROGRAM_PHOTOSFields fieldName, object value)
        {
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
