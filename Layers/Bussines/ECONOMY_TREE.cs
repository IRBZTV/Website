using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class ECONOMY_TREE: BusinessObjectBase
	{

		#region InnerClass
		public enum ECONOMY_TREEFields
		{
			ID,
			TITLE,
			UNIT,
			PRIORITY,
			DATETIME
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			string _uNIT;
			byte? _pRIORITY;
			DateTime? _dATETIME;

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

		public string  UNIT
		{
			 get { return _uNIT; }
			 set
			 {
				 if (_uNIT != value)
				 {
					_uNIT = value;
					 PropertyHasChanged("UNIT");
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


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",100));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("UNIT", "UNIT",50));
		}

		#endregion

	}
}
