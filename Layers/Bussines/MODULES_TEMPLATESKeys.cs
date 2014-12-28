using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class MODULES_TEMPLATESKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public MODULES_TEMPLATESKeys(int iD)
		{
			 _iD = iD; 
		}

		#endregion

		#region Properties

		public int  ID
		{
			 get { return _iD; }
		}

		#endregion

	}
}
