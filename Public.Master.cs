using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar
{
    public partial class Public : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Headers.Remove("Server");
            LblDateTime.Text = Bazaar.Core.Utility.GD2StringDateTime(DateTime.Now);
        }
    }
}