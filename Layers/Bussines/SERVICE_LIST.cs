using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class SERVICE_LIST: BusinessObjectBase
	{

		#region InnerClass
		public enum SERVICE_LISTFields
		{
			ID,
			TITLE,
			SID
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			int? _sID;

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

		public int?  SID
		{
			 get { return _sID; }
			 set
			 {
				 if (_sID != value)
				 {
					_sID = value;
					 PropertyHasChanged("SID");
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
