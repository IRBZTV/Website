using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PAGE_MODULESKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public PAGE_MODULESKeys(int iD)
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
