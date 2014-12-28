using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class SERVICE_CATEGORIESKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public SERVICE_CATEGORIESKeys(int iD)
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
