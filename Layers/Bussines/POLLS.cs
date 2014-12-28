using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class POLLS: BusinessObjectBase
	{

		#region InnerClass
		public enum POLLSFields
		{
			ID,
			TITLE,
			ACTIVE,
			ALLOWNEW,
			SHOWRESULT,
			DATETIME,
			CREATOR
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			bool? _aCTIVE;
			bool? _aLLOWNEW;
			bool? _sHOWRESULT;
			DateTime? _dATETIME;
			int? _cREATOR;

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

		public bool?  ALLOWNEW
		{
			 get { return _aLLOWNEW; }
			 set
			 {
				 if (_aLLOWNEW != value)
				 {
					_aLLOWNEW = value;
					 PropertyHasChanged("ALLOWNEW");
				 }
			 }
		}

		public bool?  SHOWRESULT
		{
			 get { return _sHOWRESULT; }
			 set
			 {
				 if (_sHOWRESULT != value)
				 {
					_sHOWRESULT = value;
					 PropertyHasChanged("SHOWRESULT");
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

		public int?  CREATOR
		{
			 get { return _cREATOR; }
			 set
			 {
				 if (_cREATOR != value)
				 {
					_cREATOR = value;
					 PropertyHasChanged("CREATOR");
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
