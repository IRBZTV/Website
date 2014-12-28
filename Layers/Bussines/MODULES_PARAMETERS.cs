using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class MODULES_PARAMETERS: BusinessObjectBase
	{

		#region InnerClass
		public enum MODULES_PARAMETERSFields
		{
			ID,
			MODULE_ID,
			TITLE,
			PRIORITY
		}
		#endregion

		#region Data Members

			int _iD;
			int? _mODULE_ID;
			string _tITLE;
			byte? _pRIORITY;

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

		public byte?  PRIORITY
		{
			 get { return _pRIORITY; }
			 set
			 {
				 if (_pRIORITY != value)
				 {
					_pRIORITY = value;
					 PropertyHasChanged("PRIORITY");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",500));
		}

		#endregion

	}
}
