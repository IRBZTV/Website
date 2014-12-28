using System;
using System.Collections.Generic;
using System.Text;
namespace Bazaar.BusinessLayer
{
	public class CONTENTS_RELATIONKeys
	{

		#region Data Members

		int _iD;

		#endregion

		#region Constructor

		public CONTENTS_RELATIONKeys(int iD)
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
