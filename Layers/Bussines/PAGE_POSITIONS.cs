using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PAGE_POSITIONS: BusinessObjectBase
	{

		#region InnerClass
		public enum PAGE_POSITIONSFields
		{
			ID,
			PAGE_ID,
			TITLE,
			HTML_ID
		}
		#endregion

		#region Data Members

			int _iD;
			int? _pAGE_ID;
			string _tITLE;
			string _hTML_ID;

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

		public int?  PAGE_ID
		{
			 get { return _pAGE_ID; }
			 set
			 {
				 if (_pAGE_ID != value)
				 {
					_pAGE_ID = value;
					 PropertyHasChanged("PAGE_ID");
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

		public string  HTML_ID
		{
			 get { return _hTML_ID; }
			 set
			 {
				 if (_hTML_ID != value)
				 {
					_hTML_ID = value;
					 PropertyHasChanged("HTML_ID");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",500));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("HTML_ID", "HTML_ID",500));
		}

		#endregion

	}
}
