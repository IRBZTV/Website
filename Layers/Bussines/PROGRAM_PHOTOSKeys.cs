using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class PROGRAM_PHOTOSKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public PROGRAM_PHOTOSKeys(int iD)
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
