using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class ACCESS: BusinessObjectBase
	{

		#region InnerClass
		public enum ACCESSFields
		{
			ID,
			TITLE,
			VALUE
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			string _vALUE;

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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("VALUE", "VALUE",2147483647));
		}

		#endregion

	}
}
