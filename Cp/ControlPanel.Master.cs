using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class ControlPanel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            StringBuilder Menu = new StringBuilder();

            Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
            Bazaar.BusinessLayer.USERS_DETAILS UserObj = User_Sql.SelectByField("USRNM", Context.User.Identity.Name)[0];

            long UserMenuSec = long.Parse(UserObj.MENU_SEC);

            Bazaar.BusinessLayer.DataLayer.MENUSSql MenuSql = new BusinessLayer.DataLayer.MENUSSql();
            List<Bazaar.BusinessLayer.MENUS> MenuList = MenuSql.SelectCondition(" pid=0 and kind=1 order by sort");
            foreach (Bazaar.BusinessLayer.MENUS item in MenuList)
            {
                if (long.Equals((Convert.ToInt64(UserMenuSec) & (Convert.ToInt64(item.VALUE))), (Convert.ToInt64(item.VALUE))))
                {
                    Menu.Append(" <li class='news dropdown '>");
                    Menu.Append(" <a class='dropdown-toggle' data-toggle='dropdown' href='#'>");
                    Menu.Append(" <span class='icon-globe'></span>");
                    Menu.Append(" " + item.TITLE + "&nbsp;<b class='caret'></b>");

                    List<Bazaar.BusinessLayer.MENUS> SubMenuList = MenuSql.SelectCondition(" pid=" + item.ID + " order by sort ");
                    if (SubMenuList.Count > 0)
                    {
                        Menu.Append("   <ul class='dropdown-menu'>");
                    }

                    foreach (Bazaar.BusinessLayer.MENUS SubItem in SubMenuList)
                    {
                        if (long.Equals((Convert.ToInt64(UserMenuSec) & (Convert.ToInt64(SubItem.VALUE))), (Convert.ToInt64(SubItem.VALUE))))
                        {
                            Menu.Append(" <li><a href='" + SubItem.PATH + "'><span class='icon-plus'></span>&nbsp;" + SubItem.TITLE + "</a></li>");
                        }
                    }

                    if (SubMenuList.Count > 0)
                    {
                        Menu.Append(" </ul>");
                    }

                    Menu.Append("  </li>");
                }
            }

            Literal1.Text = Menu.ToString();

        }
    }
}