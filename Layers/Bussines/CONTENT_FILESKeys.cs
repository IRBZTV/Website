using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class CONTENT_FILESKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public CONTENT_FILESKeys(int iD)
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
