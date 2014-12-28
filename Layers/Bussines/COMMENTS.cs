using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class COMMENTS: BusinessObjectBase
	{

		#region InnerClass
		public enum COMMENTSFields
		{
			ID,
			ACTIVE,
			NAME,
			EMAIL,
			LOCATION,
			TEXT,
			DATETIME,
			NEWS_ID,
			PID
		}
		#endregion

		#region Data Members

			int _iD;
			bool? _aCTIVE;
			string _nAME;
			string _eMAIL;
			string _lOCATION;
			string _tEXT;
			DateTime? _dATETIME;
			int? _nEWS_ID;
			int? _pID;

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

		public string  NAME
		{
			 get { return _nAME; }
			 set
			 {
				 if (_nAME != value)
				 {
					_nAME = value;
					 PropertyHasChanged("NAME");
				 }
			 }
		}

		public string  EMAIL
		{
			 get { return _eMAIL; }
			 set
			 {
				 if (_eMAIL != value)
				 {
					_eMAIL = value;
					 PropertyHasChanged("EMAIL");
				 }
			 }
		}

		public string  LOCATION
		{
			 get { return _lOCATION; }
			 set
			 {
				 if (_lOCATION != value)
				 {
					_lOCATION = value;
					 PropertyHasChanged("LOCATION");
				 }
			 }
		}

		public string  TEXT
		{
			 get { return _tEXT; }
			 set
			 {
				 if (_tEXT != value)
				 {
					_tEXT = value;
					 PropertyHasChanged("TEXT");
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

		public int?  NEWS_ID
		{
			 get { return _nEWS_ID; }
			 set
			 {
				 if (_nEWS_ID != value)
				 {
					_nEWS_ID = value;
					 PropertyHasChanged("NEWS_ID");
				 }
			 }
		}

		public int?  PID
		{
			 get { return _pID; }
			 set
			 {
				 if (_pID != value)
				 {
					_pID = value;
					 PropertyHasChanged("PID");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("NAME", "NAME",50));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("EMAIL", "EMAIL",50));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LOCATION", "LOCATION",50));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TEXT", "TEXT",2147483647));
		}

		#endregion

	}
}
