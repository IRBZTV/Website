using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Menu
{
    public partial class MainMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bazaar.BusinessLayer.DataLayer.MENUSSql MSql = new BusinessLayer.DataLayer.MENUSSql();
            List<Bazaar.BusinessLayer.MENUS> MenuList = MSql.SelectCondition(" pid=0 and kind=2 order by sort");

            StringBuilder Str = new StringBuilder();
            Str.Append("<nav id=\"navbar\">");
            Str.Append("<div class=\"container\">");
            Str.Append(" <div class=\"row\">");
            Str.Append("   <nav class=\"span12\">");
            Str.Append(" <ul class=\"menu\">");


            foreach (Bazaar.BusinessLayer.MENUS item in MenuList)
            {
                string Css = " active ";
                if (item.ID != ActiveMenuTabId)
                {
                    Css = " ";
                }
                Str.Append(" <li class='" + Css + "'><a href='" + item.PATH + "'>" + item.TITLE + "</a></li>");
            }
            Str.Append("  </ul>");
                    Str.Append(" </nav>");
              Str.Append("   </div>");
           Str.Append("  </div>");
     
           Str.Append(" </nav>");

          

            Literal1.Text = Str.ToString();
        }
        public int ActiveMenuTabId { get; set; }
    }

}