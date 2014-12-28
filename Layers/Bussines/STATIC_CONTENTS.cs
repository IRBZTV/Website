using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class STATIC_CONTENTS: BusinessObjectBase
	{

		#region InnerClass
		public enum STATIC_CONTENTSFields
		{
			ID,
			TITLE,
			BODY,
			LEAD,
			DATETIME,
			USER_ID,
			ACTIVE
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			string _bODY;
			string _lEAD;
			DateTime? _dATETIME;
			string _uSER_ID;
			bool? _aCTIVE;

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

		public string  BODY
		{
			 get { return _bODY; }
			 set
			 {
				 if (_bODY != value)
				 {
					_bODY = value;
					 PropertyHasChanged("BODY");
				 }
			 }
		}

		public string  LEAD
		{
			 get { return _lEAD; }
			 set
			 {
				 if (_lEAD != value)
				 {
					_lEAD = value;
					 PropertyHasChanged("LEAD");
				 }
			 }
		}

		public DateTime?  DATETIME
		{
			 get { return _dATETIME; }
			 set
			 {
				 if (_dATETIME != value)
				 {
					_dATETIME = value;
					 PropertyHasChanged("DATETIME");
				 }
			 }
		}

		public string  USER_ID
		{
			 get { return _uSER_ID; }
			 set
			 {
				 if (_uSER_ID != value)
				 {
					_uSER_ID = value;
					 PropertyHasChanged("USER_ID");
				 }
			 }
		}

		public bool?  ACTIVE
		{
			 get { return _aCTIVE; }
			 set
			 {
				 if (_aCTIVE != value)
				 {
					_aCTIVE = value;
					 PropertyHasChanged("ACTIVE");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("BODY", "BODY",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LEAD", "LEAD",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("USER_ID", "USER_ID",10));
		}

		#endregion

	}
}
