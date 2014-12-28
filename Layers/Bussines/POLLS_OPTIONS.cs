using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class POLLS_OPTIONS: BusinessObjectBase
	{

		#region InnerClass
		public enum POLLS_OPTIONSFields
		{
			ID,
			TITLE,
			PRIORITY,
			POLL_ID,
			COUNT
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			byte? _pRIORITY;
			int _pOLL_ID;
			long? _cOUNT;

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

		public int  POLL_ID
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

		public long?  COUNT
		{
			 get { return _cOUNT; }
			 set
			 {
				 if (_cOUNT != value)
				 {
					_cOUNT = value;
					 PropertyHasChanged("COUNT");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("POLL_ID", "POLL_ID"));
		}

		#endregion

	}
}
