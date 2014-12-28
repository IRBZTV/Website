using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PROGRAM_SESSIONS: BusinessObjectBase
	{

		#region InnerClass
		public enum PROGRAM_SESSIONSFields
		{
			ID,
			TITLE,
			NUMBER,
			DATETIME,
			BODY,
			VIDEO,
			IMAGE,
			ACTIVE,
			PROG_ID,
            SaveDays,
            Play_DATETIME
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			int? _nUMBER;
			DateTime? _dATETIME;
			string _bODY;
			string _vIDEO;
			string _iMAGE;
			bool? _aCTIVE;
			int? _pROG_ID;
            int? _SaveDays;
            DateTime? _Play_DATETIME;

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

		public int?  NUMBER
		{
			 get { return _nUMBER; }
			 set
			 {
				 if (_nUMBER != value)
				 {
					_nUMBER = value;
					 PropertyHasChanged("NUMBER");
				 }
			 }
		}

        public int? SaveDays
        {
            get { return _SaveDays; }
            set
            {
                if (_SaveDays != value)
                {
                    _SaveDays = value;
                    PropertyHasChanged("SaveDays");
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
        public DateTime? Play_DATETIME
		{
            get { return _Play_DATETIME; }
			 set
			 {
                 if (_Play_DATETIME != value)
				 {
                     _Play_DATETIME = value;
                     PropertyHasChanged("Play_DATETIME");
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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("BODY", "BODY",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("VIDEO", "VIDEO",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("IMAGE", "IMAGE",2147483647));
		}

		#endregion

	}
}
