using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar
{
    public partial class ShowProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildPage();
        }

        private void BuildPage()
        {

            BusinessLayer.DataLayer.PAGE_MODULESSql Page_Module_Sql = new BusinessLayer.DataLayer.PAGE_MODULESSql();
            List<BusinessLayer.PAGE_MODULES> Page_Modules = Page_Module_Sql.Select_ByPageId_Position(1016, 1053);


            foreach (BusinessLayer.PAGE_MODULES item in Page_Modules)
            {
                PnlRight.Controls.Add(Core.ModuleLoader.LoadUserControl(item.ID));
            }



            BusinessLayer.DataLayer.PAGE_MODULESSql Page_Module_Sql2 = new BusinessLayer.DataLayer.PAGE_MODULESSql();
            List<BusinessLayer.PAGE_MODULES> Page_Modules2 = Page_Module_Sql.Select_ByPageId_Position(1016, 1052);

            foreach (BusinessLayer.PAGE_MODULES item in Page_Modules2)
            {
                PnlLeft.Controls.Add(Core.ModuleLoader.LoadUserControl(item.ID));
            }



            BusinessLayer.DataLayer.PAGE_MODULESSql Page_Module_Sql3 = new BusinessLayer.DataLayer.PAGE_MODULESSql();
            List<BusinessLayer.PAGE_MODULES> Page_Modules3 = Page_Module_Sql.Select_ByPageId_Position(1016, 1054);

            foreach (BusinessLayer.PAGE_MODULES item in Page_Modules3)
            {
                PnlTop.Controls.Add(Core.ModuleLoader.LoadUserControl(item.ID));
            }



            BusinessLayer.DataLayer.PAGE_MODULESSql Page_Module_Sql4 = new BusinessLayer.DataLayer.PAGE_MODULESSql();
            List<BusinessLayer.PAGE_MODULES> Page_Modules4 = Page_Module_Sql.Select_ByPageId_Position(1016, 1055);

            foreach (BusinessLayer.PAGE_MODULES item in Page_Modules4)
            {
                PnlMenu.Controls.Add(Core.ModuleLoader.LoadUserControl(item.ID));
            }

        }
    }
}