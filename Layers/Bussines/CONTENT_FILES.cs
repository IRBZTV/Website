using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class CONTENT_FILES: BusinessObjectBase
	{

		#region InnerClass
		public enum CONTENT_FILESFields
		{
			ID,
			PATH,
			TYPE,
			PRIORITY,
			NEWS_ID
		}
		#endregion

		#region Data Members

			int _iD;
			string _pATH;
			byte? _tYPE;
			byte? _pRIORITY;
			int? _nEWS_ID;

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

		public string  PATH
		{
			 get { return _pATH; }
			 set
			 {
				 if (_pATH != value)
				 {
					_pATH = value;
					 PropertyHasChanged("PATH");
				 }
			 }
		}

		public byte?  TYPE
		{
			 get { return _tYPE; }
			 set
			 {
				 if (_tYPE != value)
				 {
					_tYPE = value;
					 PropertyHasChanged("TYPE");
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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PATH", "PATH",2147483647));
		}

		#endregion

	}
}
