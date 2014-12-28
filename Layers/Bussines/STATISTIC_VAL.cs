using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class STATISTIC_VAL: BusinessObjectBase
	{

		#region InnerClass
		public enum STATISTIC_VALFields
		{
			ID,
			GROUPID,
			VAL,
			DIFF,
			TITLE,
			UNIT
		}
		#endregion

		#region Data Members

			int _iD;
			int? _gROUPID;
			string _vAL;
			string _dIFF;
			string _tITLE;
			string _uNIT;

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

		public int?  GROUPID
		{
			 get { return _gROUPID; }
			 set
			 {
				 if (_gROUPID != value)
				 {
					_gROUPID = value;
					 PropertyHasChanged("GROUPID");
				 }
			 }
		}

		public string  VAL
		{
			 get { return _vAL; }
			 set
			 {
				 if (_vAL != value)
				 {
					_vAL = value;
					 PropertyHasChanged("VAL");
				 }
			 }
		}

		public string  DIFF
		{
			 get { return _dIFF; }
			 set
			 {
				 if (_dIFF != value)
				 {
					_dIFF = value;
					 PropertyHasChanged("DIFF");
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

		public string  UNIT
		{
			 get { return _uNIT; }
			 set
			 {
				 if (_uNIT != value)
				 {
					_uNIT = value;
					 PropertyHasChanged("UNIT");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("VAL", "VAL",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("DIFF", "DIFF",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("UNIT", "UNIT",2147483647));
		}

		#endregion

	}
}
