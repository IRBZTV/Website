using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class USERS_DETAILS: BusinessObjectBase
	{

		#region InnerClass
		public enum USERS_DETAILSFields
		{
			ID,
			USERID,
			FULLNAME,
			MENU_SEC,
			ACCESS_SEC,
			USRNM,
			PROG_ID,
            PROGKIND
		}
		#endregion

		#region Data Members

			int _iD;
			Guid? _uSERID;
			string _fULLNAME;
			string _mENU_SEC;
			string _aCCESS_SEC;
			string _uSRNM;
			int? _pROG_ID;
            short _PROGKIND;

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

		public Guid?  USERID
		{
			 get { return _uSERID; }
			 set
			 {
				 if (_uSERID != value)
				 {
					_uSERID = value;
					 PropertyHasChanged("USERID");
				 }
			 }
		}

		public string  FULLNAME
		{
			 get { return _fULLNAME; }
			 set
			 {
				 if (_fULLNAME != value)
				 {
					_fULLNAME = value;
					 PropertyHasChanged("FULLNAME");
				 }
			 }
		}

		public string  MENU_SEC
		{
			 get { return _mENU_SEC; }
			 set
			 {
				 if (_mENU_SEC != value)
				 {
					_mENU_SEC = value;
					 PropertyHasChanged("MENU_SEC");
				 }
			 }
		}

		public string  ACCESS_SEC
		{
			 get { return _aCCESS_SEC; }
			 set
			 {
				 if (_aCCESS_SEC != value)
				 {
					_aCCESS_SEC = value;
					 PropertyHasChanged("ACCESS_SEC");
				 }
			 }
		}

		public string  USRNM
		{
			 get { return _uSRNM; }
			 set
			 {
				 if (_uSRNM != value)
				 {
					_uSRNM = value;
					 PropertyHasChanged("USRNM");
				 }
			 }
		}

		public int?  PROG_ID
		{
			 get { return _pROG_ID; }
			 set
			 {
				 if (_pROG_ID != value)
				 {
					_pROG_ID = value;
					 PropertyHasChanged("PROG_ID");
				 }
			 }
		}

        public short PROGKIND
        {
            get { return _PROGKIND; }
            set
            {
                if (_PROGKIND != value)
                {
                    _PROGKIND = value;
                    PropertyHasChanged("PROGKIND");
                }
            }
        }


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("FULLNAME", "FULLNAME",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("MENU_SEC", "MENU_SEC",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ACCESS_SEC", "ACCESS_SEC",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("USRNM", "USRNM",2147483647));
		}

		#endregion

	}
}
