using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class STATIC_CONTENTSKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public STATIC_CONTENTSKeys(int iD)
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
