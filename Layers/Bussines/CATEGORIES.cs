using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class CATEGORIES: BusinessObjectBase
	{

		#region InnerClass
		public enum CATEGORIESFields
		{
			ID,
			TITLE,
			PID
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
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
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",50));
		}

		#endregion

	}
}
