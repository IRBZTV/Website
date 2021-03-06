using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class MODULES: BusinessObjectBase
	{

		#region InnerClass
		public enum MODULESFields
		{
			ID,
			TITLE,
			FILEPATH
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			string _fILEPATH;

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

		public string  FILEPATH
		{
			 get { return _fILEPATH; }
			 set
			 {
				 if (_fILEPATH != value)
				 {
					_fILEPATH = value;
					 PropertyHasChanged("FILEPATH");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FILEPATH", "FILEPATH",500));
		}

		#endregion

	}
}
