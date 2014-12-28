using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PAGE: BusinessObjectBase
	{

		#region InnerClass
		public enum PAGEFields
		{
			ID,
			TITLE,
			FILEPATH,
			PRIORITY,
			AuthorizedRoles,
			ParentTabID
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			string _fILEPATH;
			byte? _pRIORITY;
			string _authorizedRoles;
			int? _parentTabID;

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

		public byte?  PRIORITY
		{
			 get { return _pRIORITY; }
			 set
			 {
				 if (_pRIORITY != value)
				 {
					_pRIORITY = value;
					 PropertyHasChanged("PRIORITY");
				 }
			 }
		}

		public string  AuthorizedRoles
		{
			 get { return _authorizedRoles; }
			 set
			 {
				 if (_authorizedRoles != value)
				 {
					_authorizedRoles = value;
					 PropertyHasChanged("AuthorizedRoles");
				 }
			 }
		}

		public int?  ParentTabID
		{
			 get { return _parentTabID; }
			 set
			 {
				 if (_parentTabID != value)
				 {
					_parentTabID = value;
					 PropertyHasChanged("ParentTabID");
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
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("AuthorizedRoles", "AuthorizedRoles",500));
		}

		#endregion

	}
}
