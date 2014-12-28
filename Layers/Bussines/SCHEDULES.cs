using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class SCHEDULES: BusinessObjectBase
	{

		#region InnerClass
		public enum SCHEDULESFields
		{
			ID,
			TITLE,
			DATETIME,
			DESCRIPTION,
			URL,
			IMAGE,
			VIDEO
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			DateTime? _dATETIME;
			string _dESCRIPTION;
			string _uRL;
			string _iMAGE;
			string _vIDEO;

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

		public string  VIDEO
		{
			 get { return _vIDEO; }
			 set
			 {
				 if (_vIDEO != value)
				 {
					_vIDEO = value;
					 PropertyHasChanged("VIDEO");
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
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("URL", "URL",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("IMAGE", "IMAGE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("VIDEO", "VIDEO",2147483647));
		}

		#endregion

	}
}
