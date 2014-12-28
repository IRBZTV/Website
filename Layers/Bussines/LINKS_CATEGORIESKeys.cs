using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class LINKS_CATEGORIESKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public LINKS_CATEGORIESKeys(int iD)
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
