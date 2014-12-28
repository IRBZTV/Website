using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class LINKS: BusinessObjectBase
	{

		#region InnerClass
		public enum LINKSFields
		{
			ID,
			TITLE,
			URL,
			IMAGE,
			SORT
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			string _uRL;
			string _iMAGE;
			byte? _sORT;

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

		public string  URL
		{
			 get { return _uRL; }
			 set
			 {
				 if (_uRL != value)
				 {
					_uRL = value;
					 PropertyHasChanged("URL");
				 }
			 }
		}

		public string  IMAGE
		{
			 get { return _iMAGE; }
			 set
			 {
				 if (_iMAGE != value)
				 {
					_iMAGE = value;
					 PropertyHasChanged("IMAGE");
				 }
			 }
		}

		public byte?  SORT
		{
			 get { return _sORT; }
			 set
			 {
				 if (_sORT != value)
				 {
					_sORT = value;
					 PropertyHasChanged("SORT");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("URL", "URL",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("IMAGE", "IMAGE",2147483647));
		}

		#endregion

	}
}
