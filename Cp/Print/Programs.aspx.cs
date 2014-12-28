using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp.Print
{
    public partial class Programs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
            List<Bazaar.BusinessLayer.PROGRAMS> ProgList = ProgSql.SelectAll();
            DataList1.DataSource = ProgList;
            DataList1.DataBind();
        }
    }
}