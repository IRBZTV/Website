using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PAGE_MODULES_CONFIG: BusinessObjectBase
	{

		#region InnerClass
		public enum PAGE_MODULES_CONFIGFields
		{
			ID,
			PAGE_MODULE_ID,
			MODULE_PARAM_ID,
			VALUE,
			PARAM_TITLE
		}
		#endregion

		#region Data Members

			int _iD;
			int? _pAGE_MODULE_ID;
			int? _mODULE_PARAM_ID;
			string _vALUE;
			string _pARAM_TITLE;

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

		public int?  PAGE_MODULE_ID
		{
			 get { return _pAGE_MODULE_ID; }
			 set
			 {
				 if (_pAGE_MODULE_ID != value)
				 {
					_pAGE_MODULE_ID = value;
					 PropertyHasChanged("PAGE_MODULE_ID");
				 }
			 }
		}

		public int?  MODULE_PARAM_ID
		{
			 get { return _mODULE_PARAM_ID; }
			 set
			 {
				 if (_mODULE_PARAM_ID != value)
				 {
					_mODULE_PARAM_ID = value;
					 PropertyHasChanged("MODULE_PARAM_ID");
				 }
			 }
		}

		public string  VALUE
		{
			 get { return _vALUE; }
			 set
			 {
				 if (_vALUE != value)
				 {
					_vALUE = value;
					 PropertyHasChanged("VALUE");
				 }
			 }
		}

		public string  PARAM_TITLE
		{
			 get { return _pARAM_TITLE; }
			 set
			 {
				 if (_pARAM_TITLE != value)
				 {
					_pARAM_TITLE = value;
					 PropertyHasChanged("PARAM_TITLE");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("VALUE", "VALUE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PARAM_TITLE", "PARAM_TITLE",2147483647));
		}

		#endregion

	}
}
