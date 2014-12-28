using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PAGE_MODULES: BusinessObjectBase
	{

		#region InnerClass
		public enum PAGE_MODULESFields
		{
			ID,
			PAGE_ID,
			MODULE_ID,
			POSITION_ID,
			SORT,
			CONTAINER_LAYOUT,
			TEMPLATE,
			TITLE,
			VISIBLE
		}
		#endregion

		#region Data Members

			int _iD;
			int? _pAGE_ID;
			int? _mODULE_ID;
			int? _pOSITION_ID;
			byte? _sORT;
			string _cONTAINER_LAYOUT;
			string _tEMPLATE;
			string _tITLE;
			bool? _vISIBLE;

		#endregion

		#region Properties

		public int  ID
		{
			 get { return _iD; }
			 set
			 {
				 if (_iD != value)
				 {
					_iD = value;
					 PropertyHasChanged("ID");
				 }
			 }
		}

		public int?  PAGE_ID
		{
			 get { return _pAGE_ID; }
			 set
			 {
				 if (_pAGE_ID != value)
				 {
					_pAGE_ID = value;
					 PropertyHasChanged("PAGE_ID");
				 }
			 }
		}

		public int?  MODULE_ID
		{
			 get { return _mODULE_ID; }
			 set
			 {
				 if (_mODULE_ID != value)
				 {
					_mODULE_ID = value;
					 PropertyHasChanged("MODULE_ID");
				 }
			 }
		}

		public int?  POSITION_ID
		{
			 get { return _pOSITION_ID; }
			 set
			 {
				 if (_pOSITION_ID != value)
				 {
					_pOSITION_ID = value;
					 PropertyHasChanged("POSITION_ID");
				 }
			 }
		}

		public byte?  SORT
		{
			 get { return _sORT; }
			 set
			 {
				 if (_sORT != value)
				 {
					_sORT = value;
					 PropertyHasChanged("SORT");
				 }
			 }
		}

		public string  CONTAINER_LAYOUT
		{
			 get { return _cONTAINER_LAYOUT; }
			 set
			 {
				 if (_cONTAINER_LAYOUT != value)
				 {
					_cONTAINER_LAYOUT = value;
					 PropertyHasChanged("CONTAINER_LAYOUT");
				 }
			 }
		}

		public string  TEMPLATE
		{
			 get { return _tEMPLATE; }
			 set
			 {
				 if (_tEMPLATE != value)
				 {
					_tEMPLATE = value;
					 PropertyHasChanged("TEMPLATE");
				 }
			 }
		}

		public string  TITLE
		{
			 get { return _tITLE; }
			 set
			 {
				 if (_tITLE != value)
				 {
					_tITLE = value;
					 PropertyHasChanged("TITLE");
				 }
			 }
		}

		public bool?  VISIBLE
		{
			 get { return _vISIBLE; }
			 set
			 {
				 if (_vISIBLE != value)
				 {
					_vISIBLE = value;
					 PropertyHasChanged("VISIBLE");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("CONTAINER_LAYOUT", "CONTAINER_LAYOUT",500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TEMPLATE", "TEMPLATE",500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",500));
		}

		#endregion

	}
}
