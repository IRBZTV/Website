using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class MODULES_TEMPLATES: BusinessObjectBase
	{

		#region InnerClass
		public enum MODULES_TEMPLATESFields
		{
			ID,
			TITLE,
			MODULE_ID
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			int? _mODULE_ID;

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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
		}

		#endregion

	}
}
