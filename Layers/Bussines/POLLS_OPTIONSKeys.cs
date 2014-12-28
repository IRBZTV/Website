using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class POLLS_OPTIONSKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public POLLS_OPTIONSKeys(int iD)
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
