using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class ECONOMY_TREEKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public ECONOMY_TREEKeys(int iD)
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
