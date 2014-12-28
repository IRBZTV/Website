using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class SERVICE_REPORT: BusinessObjectBase
	{

		#region InnerClass
		public enum SERVICE_REPORTFields
		{
			ID,
			CAT_ID,
			KIND_ID,
			CLIENT_ID,
			LIST_ID,
			TEXT,
			DATETIME,
			USER_ID,
			SHIFT,
			MINUTE
		}
		#endregion

		#region Data Members

			int _iD;
			int? _cAT_ID;
			int? _kIND_ID;
			int? _cLIENT_ID;
			int? _lIST_ID;
			string _tEXT;
			DateTime? _dATETIME;
			int? _uSER_ID;
			int? _sHIFT;
			int? _mINUTE;

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

		public int?  CAT_ID
		{
			 get { return _cAT_ID; }
			 set
			 {
				 if (_cAT_ID != value)
				 {
					_cAT_ID = value;
					 PropertyHasChanged("CAT_ID");
				 }
			 }
		}

		public int?  KIND_ID
		{
			 get { return _kIND_ID; }
			 set
			 {
				 if (_kIND_ID != value)
				 {
					_kIND_ID = value;
					 PropertyHasChanged("KIND_ID");
				 }
			 }
		}

		public int?  CLIENT_ID
		{
			 get { return _cLIENT_ID; }
			 set
			 {
				 if (_cLIENT_ID != value)
				 {
					_cLIENT_ID = value;
					 PropertyHasChanged("CLIENT_ID");
				 }
			 }
		}

		public int?  LIST_ID
		{
			 get { return _lIST_ID; }
			 set
			 {
				 if (_lIST_ID != value)
				 {
					_lIST_ID = value;
					 PropertyHasChanged("LIST_ID");
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

		public int?  USER_ID
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

		public int?  SHIFT
		{
			 get { return _sHIFT; }
			 set
			 {
				 if (_sHIFT != value)
				 {
					_sHIFT = value;
					 PropertyHasChanged("SHIFT");
				 }
			 }
		}

		public int?  MINUTE
		{
			 get { return _mINUTE; }
			 set
			 {
				 if (_mINUTE != value)
				 {
					_mINUTE = value;
					 PropertyHasChanged("MINUTE");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TEXT", "TEXT",2147483647));
		}

		#endregion

	}
}
