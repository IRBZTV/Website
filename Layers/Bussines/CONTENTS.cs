using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class CONTENTS: BusinessObjectBase
	{

		#region InnerClass
		public enum CONTENTSFields
		{
			ID,
			ACTIVE,
			LEAD,
			DESCRIPTION,
			TITLE,
			BODY,
			DATETIME_CREATE,
			CATEGORY_ID,
			SHOWCOMMENTS,
			NEWCOMENT,
			SHOWPOLL,
			POLL_ID,
			DATETIME_MODIFIED,
			AUTHOR,
			PUBLISHER,
			STATE,
			POSITION,
			SOURCE_URL,
			VIEWCOUNT
		}
		#endregion

		#region Data Members

			int _iD;
			bool? _aCTIVE;
			string _lEAD;
			string _dESCRIPTION;
			string _tITLE;
			string _bODY;
			DateTime _dATETIME_CREATE;
			int? _cATEGORY_ID;
			bool? _sHOWCOMMENTS;
			bool? _nEWCOMENT;
			bool? _sHOWPOLL;
			int? _pOLL_ID;
			DateTime? _dATETIME_MODIFIED;
			int? _aUTHOR;
			int? _pUBLISHER;
			byte? _sTATE;
			byte? _pOSITION;
			string _sOURCE_URL;
			long? _vIEWCOUNT;

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

		public string  LEAD
		{
			 get { return _lEAD; }
			 set
			 {
				 if (_lEAD != value)
				 {
					_lEAD = value;
					 PropertyHasChanged("LEAD");
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

		public DateTime  DATETIME_CREATE
		{
			 get { return _dATETIME_CREATE; }
			 set
			 {
				 if (_dATETIME_CREATE != value)
				 {
					_dATETIME_CREATE = value;
					 PropertyHasChanged("DATETIME_CREATE");
				 }
			 }
		}

		public int?  CATEGORY_ID
		{
			 get { return _cATEGORY_ID; }
			 set
			 {
				 if (_cATEGORY_ID != value)
				 {
					_cATEGORY_ID = value;
					 PropertyHasChanged("CATEGORY_ID");
				 }
			 }
		}

		public bool?  SHOWCOMMENTS
		{
			 get { return _sHOWCOMMENTS; }
			 set
			 {
				 if (_sHOWCOMMENTS != value)
				 {
					_sHOWCOMMENTS = value;
					 PropertyHasChanged("SHOWCOMMENTS");
				 }
			 }
		}

		public bool?  NEWCOMENT
		{
			 get { return _nEWCOMENT; }
			 set
			 {
				 if (_nEWCOMENT != value)
				 {
					_nEWCOMENT = value;
					 PropertyHasChanged("NEWCOMENT");
				 }
			 }
		}

		public bool?  SHOWPOLL
		{
			 get { return _sHOWPOLL; }
			 set
			 {
				 if (_sHOWPOLL != value)
				 {
					_sHOWPOLL = value;
					 PropertyHasChanged("SHOWPOLL");
				 }
			 }
		}

		public int?  POLL_ID
		{
			 get { return _pOLL_ID; }
			 set
			 {
				 if (_pOLL_ID != value)
				 {
					_pOLL_ID = value;
					 PropertyHasChanged("POLL_ID");
				 }
			 }
		}

		public DateTime?  DATETIME_MODIFIED
		{
			 get { return _dATETIME_MODIFIED; }
			 set
			 {
				 if (_dATETIME_MODIFIED != value)
				 {
					_dATETIME_MODIFIED = value;
					 PropertyHasChanged("DATETIME_MODIFIED");
				 }
			 }
		}

		public int?  AUTHOR
		{
			 get { return _aUTHOR; }
			 set
			 {
				 if (_aUTHOR != value)
				 {
					_aUTHOR = value;
					 PropertyHasChanged("AUTHOR");
				 }
			 }
		}

		public int?  PUBLISHER
		{
			 get { return _pUBLISHER; }
			 set
			 {
				 if (_pUBLISHER != value)
				 {
					_pUBLISHER = value;
					 PropertyHasChanged("PUBLISHER");
				 }
			 }
		}

		public byte?  STATE
		{
			 get { return _sTATE; }
			 set
			 {
				 if (_sTATE != value)
				 {
					_sTATE = value;
					 PropertyHasChanged("STATE");
				 }
			 }
		}

		public byte?  POSITION
		{
			 get { return _pOSITION; }
			 set
			 {
				 if (_pOSITION != value)
				 {
					_pOSITION = value;
					 PropertyHasChanged("POSITION");
				 }
			 }
		}

		public string  SOURCE_URL
		{
			 get { return _sOURCE_URL; }
			 set
			 {
				 if (_sOURCE_URL != value)
				 {
					_sOURCE_URL = value;
					 PropertyHasChanged("SOURCE_URL");
				 }
			 }
		}

		public long?  VIEWCOUNT
		{
			 get { return _vIEWCOUNT; }
			 set
			 {
				 if (_vIEWCOUNT != value)
				 {
					_vIEWCOUNT = value;
					 PropertyHasChanged("VIEWCOUNT");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("LEAD", "LEAD",300));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("DESCRIPTION", "DESCRIPTION",1000));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",300));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("BODY", "BODY",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("SOURCE_URL", "SOURCE_URL",2147483647));
		}

		#endregion

	}
}
