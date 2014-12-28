using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class CONTENTS_RELATION: BusinessObjectBase
	{

		#region InnerClass
		public enum CONTENTS_RELATIONFields
		{
			ID,
			NEWS_ID,
			R_NEWS_ID
		}
		#endregion

		#region Data Members

			int _iD;
			int? _nEWS_ID;
			int? _r_NEWS_ID;

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

		public int?  R_NEWS_ID
		{
			 get { return _r_NEWS_ID; }
			 set
			 {
				 if (_r_NEWS_ID != value)
				 {
					_r_NEWS_ID = value;
					 PropertyHasChanged("R_NEWS_ID");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
		}

		#endregion

	}
}
