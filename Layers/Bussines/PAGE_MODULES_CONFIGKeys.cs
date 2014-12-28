using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PAGE_MODULES_CONFIGKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public PAGE_MODULES_CONFIGKeys(int iD)
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
