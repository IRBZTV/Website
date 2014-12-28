using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PROGRAM_PHOTOS: BusinessObjectBase
	{

		#region InnerClass
		public enum PROGRAM_PHOTOSFields
		{
			ID,
			PATH,
			PRIORITY,
			PID
		}
		#endregion

		#region Data Members

			int _iD;
			string _pATH;
			byte? _pRIORITY;
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
			ValidationRules.AddRules(new Validation.ValidateRuleStringMaxLength("PATH", "PATH",2147483647));
		}

		#endregion

	}
}
