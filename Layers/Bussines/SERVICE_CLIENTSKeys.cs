using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class SERVICE_CLIENTSKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public SERVICE_CLIENTSKeys(int iD)
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
