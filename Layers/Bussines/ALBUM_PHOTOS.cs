using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class ALBUM_PHOTOS: BusinessObjectBase
	{

		#region InnerClass
		public enum ALBUM_PHOTOSFields
		{
			ID,
			ACTIVE,
			PATH,
			TITLE,
			PRIORITY,
			ALBUM_ID
		}
		#endregion

		#region Data Members

			int _iD;
			bool? _aCTIVE;
			string _pATH;
			string _tITLE;
			int? _pRIORITY;
			int? _aLBUM_ID;

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

		public int?  ALBUM_ID
		{
			 get { return _aLBUM_ID; }
			 set
			 {
				 if (_aLBUM_ID != value)
				 {
					_aLBUM_ID = value;
					 PropertyHasChanged("ALBUM_ID");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PATH", "PATH",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
		}

		#endregion

	}
}
