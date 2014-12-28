using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Modules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Bazaar.BusinessLayer.DataLayer.PAGESql PagesSql = new BusinessLayer.DataLayer.PAGESql();
                List<Bazaar.BusinessLayer.PAGE> PagesList = PagesSql.SelectAll();

                DdlPages.Items.Clear();
                DdlPages.Items.Add(new ListItem("همه صفحات", "0"));
                foreach (Bazaar.BusinessLayer.PAGE item in PagesList)
                {
                    DdlPages.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }


                DdlPages_SelectedIndexChanged(new object(), new EventArgs());


            }
        }
        protected void LoadModules()
        {

            Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql PageModules_Sql =
               new BusinessLayer.DataLayer.PAGE_MODULESSql();
            List<Bazaar.BusinessLayer.PAGE_MODULES> Modules_List = new List<BusinessLayer.PAGE_MODULES>();

            if (DdlPages.SelectedValue == "0")
            {
                Modules_List = PageModules_Sql.SelectAll();
            }
            else
            {
                if (DdlPagePositions.SelectedValue == "0")
                {

                    Modules_List = PageModules_Sql.Select_ByCondition(" where Page_ID=" + DdlPages.SelectedValue + " order by sort");
                }
                else
                {
                    Modules_List = PageModules_Sql.Select_ByCondition(" where Page_ID=" + DdlPages.SelectedValue + " and Position_id=" + DdlPagePositions.SelectedValue + " order by sort");
                }
            }





            gvModules.DataSource = Modules_List;
            gvModules.DataBind();
        }

        protected string PageTitle(object PageID)
        {
            Bazaar.BusinessLayer.DataLayer.PAGESql PgSql = new BusinessLayer.DataLayer.PAGESql();
            return PgSql.SelectByPrimaryKey(new BusinessLayer.PAGEKeys(int.Parse(PageID.ToString()))).TITLE;
        }

        protected string ModuleTitle(object ModuleID)
        {
            Bazaar.BusinessLayer.DataLayer.MODULESSql mdSql = new BusinessLayer.DataLayer.MODULESSql();
            return mdSql.SelectByPrimaryKey(new BusinessLayer.MODULESKeys(int.Parse(ModuleID.ToString()))).TITLE;
        }

        protected string PositionTitle(object psID)
        {
            Bazaar.BusinessLayer.DataLayer.PAGE_POSITIONSSql psSql = new BusinessLayer.DataLayer.PAGE_POSITIONSSql();
            return psSql.SelectByPrimaryKey(new BusinessLayer.PAGE_POSITIONSKeys(int.Parse(psID.ToString()))).TITLE;
        }
        protected string BoolToImage(object InValue)
        {
            if (bool.Parse(InValue.ToString()))
            {
                return "~/Cp/Theme/Icon/Yes.png";
            }
            else
            {
                return "~/Cp/Theme/Icon/No.png";
            }
        }

        protected void gvModules_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ModuleId = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Active")
            {
                Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql PageModules_Sql =
              new BusinessLayer.DataLayer.PAGE_MODULESSql();

                Bazaar.BusinessLayer.PAGE_MODULES Md = PageModules_Sql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULESKeys(ModuleId));
                if ((bool)Md.VISIBLE)
                {
                    Md.VISIBLE = false;
                }
                else
                {
                    Md.VISIBLE = true;
                }
                PageModules_Sql.Update(Md);

            }
            if (e.CommandName == "DownPriority")
            {
                Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql PageModules_Sql =
                    new BusinessLayer.DataLayer.PAGE_MODULESSql();

                Bazaar.BusinessLayer.PAGE_MODULES Md = PageModules_Sql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULESKeys(ModuleId));

                if (Md.SORT > 0)
                {
                    Md.SORT -= 1;
                    PageModules_Sql.Update(Md);
                }
            }
            if (e.CommandName == "UpPriority")
            {
                Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql PageModules_Sql =
                    new BusinessLayer.DataLayer.PAGE_MODULESSql();

                Bazaar.BusinessLayer.PAGE_MODULES Md = PageModules_Sql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULESKeys(ModuleId));


                Md.SORT += 1;
                PageModules_Sql.Update(Md);

            }
            if (e.CommandName == "DeleteModule")
            {
                Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql PgConf_Sql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                PgConf_Sql.DeleteByField("PAGE_MODULE_ID", ModuleId);

                Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql PageModules_Sql =
                    new BusinessLayer.DataLayer.PAGE_MODULESSql();

                PageModules_Sql.Delete(new BusinessLayer.PAGE_MODULESKeys(ModuleId));
            }

            LoadModules();
        }

        protected void DdlPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPositions();
        }
        protected void LoadPositions()
        {
            Bazaar.BusinessLayer.DataLayer.PAGE_POSITIONSSql PagesPosSql = new BusinessLayer.DataLayer.PAGE_POSITIONSSql();
            List<Bazaar.BusinessLayer.PAGE_POSITIONS> PagesPosList = PagesPosSql.SelectByField("PAGE_ID", DdlPages.SelectedValue);

            DdlPagePositions.Items.Clear();
            DdlPagePositions.Items.Add(new ListItem("همه موقعیت ها", "0"));
            foreach (Bazaar.BusinessLayer.PAGE_POSITIONS item in PagesPosList)
            {
                DdlPagePositions.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
            }
            DdlPagePositions_SelectedIndexChanged(new object(), new EventArgs());


        }

        protected void DdlPagePositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadModules();
        }
        protected string ContainerLayoutTitle(object ContainerLayout)
        {
            switch (ContainerLayout.ToString())
            {
                case "Title":
                    return "نمایش عنوان";

                case "TitleTime":
                    return "نمایش عنوان و تاریخ";

                case "Line":
                    return "نمایش خط";

                case "None":
                    return "بدون قالب";


                default:
                    return "----";
            }
        }

    }
}