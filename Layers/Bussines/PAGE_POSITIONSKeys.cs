using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PAGE_POSITIONSKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public PAGE_POSITIONSKeys(int iD)
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
