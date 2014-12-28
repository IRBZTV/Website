using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class ALBUMS: BusinessObjectBase
	{

		#region InnerClass
		public enum ALBUMSFields
		{
			ID,
			TITLE,
			ACTIVE,
			DESCRIPTION,
			DATETIME,
			PHOTOGRAPHER,
			HomePage
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			bool? _aCTIVE;
			string _dESCRIPTION;
			DateTime? _dATETIME;
			string _pHOTOGRAPHER;
			bool? _homePage;

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

		public string  DESCRIPTION
		{
			 get { return _dESCRIPTION; }
			 set
			 {
				 if (_dESCRIPTION != value)
				 {
					_dESCRIPTION = value;
					 PropertyHasChanged("DESCRIPTION");
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

		public string  PHOTOGRAPHER
		{
			 get { return _pHOTOGRAPHER; }
			 set
			 {
				 if (_pHOTOGRAPHER != value)
				 {
					_pHOTOGRAPHER = value;
					 PropertyHasChanged("PHOTOGRAPHER");
				 }
			 }
		}

		public bool?  HomePage
		{
			 get { return _homePage; }
			 set
			 {
				 if (_homePage != value)
				 {
					_homePage = value;
					 PropertyHasChanged("HomePage");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("DESCRIPTION", "DESCRIPTION",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PHOTOGRAPHER", "PHOTOGRAPHER",500));
		}

		#endregion

	}
}
