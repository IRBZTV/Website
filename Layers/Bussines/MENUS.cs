using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class MENUS: BusinessObjectBase
	{

		#region InnerClass
		public enum MENUSFields
		{
			ID,
			TITLE,
			SORT,
			KIND,
			PATH,
			VALUE,
			PID
		}
		#endregion

		#region Data Members

			int _iD;
			string _tITLE;
			byte? _sORT;
			byte? _kIND;
			string _pATH;
			string _vALUE;
			int? _pID;

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

		public byte?  SORT
		{
			 get { return _sORT; }
			 set
			 {
				 if (_sORT != value)
				 {
					_sORT = value;
					 PropertyHasChanged("SORT");
				 }
			 }
		}

		public byte?  KIND
		{
			 get { return _kIND; }
			 set
			 {
				 if (_kIND != value)
				 {
					_kIND = value;
					 PropertyHasChanged("KIND");
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

		public string  VALUE
		{
			 get { return _vALUE; }
			 set
			 {
				 if (_vALUE != value)
				 {
					_vALUE = value;
					 PropertyHasChanged("VALUE");
				 }
			 }
		}

		public int?  PID
		{
			 get { return _pID; }
			 set
			 {
				 if (_pID != value)
				 {
					_pID = value;
					 PropertyHasChanged("PID");
				 }
			 }
		}


		#endregion

		#region Validation

		internal override void AddValidationRules()
		{
			ValidationRules.AddRules(new Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("TITLE", "TITLE",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PATH", "PATH",2147483647));
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("VALUE", "VALUE",2147483647));
		}

		#endregion

	}
}
