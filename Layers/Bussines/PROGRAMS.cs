using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PROGRAMS: BusinessObjectBase
	{

		#region InnerClass
		public enum PROGRAMSFields
		{
			ID,
			TITLE,
			DESCRIPTION,
			BODY,
			ROLES,
			IMAGE,
			HOMEPAGE,
			ACTIVE,
			Datetime,
			PRIORITY,
            Kind
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			string _dESCRIPTION;
			string _bODY;
			string _rOLES;
			string _iMAGE;
			bool? _hOMEPAGE;
			bool? _aCTIVE;
			DateTime? _datetime;
			int? _pRIORITY;
            short? _Kind;

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

		public string  BODY
		{
			 get { return _bODY; }
			 set
			 {
				 if (_bODY != value)
				 {
					_bODY = value;
					 PropertyHasChanged("BODY");
				 }
			 }
		}

		public string  ROLES
		{
			 get { return _rOLES; }
			 set
			 {
				 if (_rOLES != value)
				 {
					_rOLES = value;
					 PropertyHasChanged("ROLES");
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

		public bool?  HOMEPAGE
		{
			 get { return _hOMEPAGE; }
			 set
			 {
				 if (_hOMEPAGE != value)
				 {
					_hOMEPAGE = value;
					 PropertyHasChanged("HOMEPAGE");
				 }
			 }
		}

		public bool?  ACTIVE
		{
			 get { return _aCTIVE; }
			 set
			 {
				 if (_aCTIVE != value)
				 {
					_aCTIVE = value;
					 PropertyHasChanged("ACTIVE");
				 }
			 }
		}

		public DateTime?  Datetime
		{
			 get { return _datetime; }
			 set
			 {
				 if (_datetime != value)
				 {
					_datetime = value;
					 PropertyHasChanged("Datetime");
				 }
			 }
		}

		public int?  PRIORITY
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

        public short? Kind
        {
            get { return _Kind; }
            set
            {
                if (_Kind != value)
                {
                    _Kind = value;
                    PropertyHasChanged("KIND");
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
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("BODY", "BODY",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("ROLES", "ROLES",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("IMAGE", "IMAGE",2147483647));
		}

		#endregion

	}
}
