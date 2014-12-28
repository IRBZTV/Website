using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Polls_Selector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetPolls();
            }
        }
        protected void GetPolls()
        {
            Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql Conf_Sql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
            List<Bazaar.BusinessLayer.PAGE_MODULES_CONFIG> ConfLst= Conf_Sql.SelectByField("PARAM_TITLE", "Poll_Id");
            gvPolls.DataSource = ConfLst;
            gvPolls.DataBind();
        }

        protected void gvPolls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SaveValue")
            {
                string Value = "";
                DropDownList Ddl = (DropDownList)gvPolls.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("DdlPolID");
                Value = Ddl.SelectedValue;
                if (((HiddenField)gvPolls.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].FindControl("hfmoduleconfigid")).Value != "0")
                {
                    int Id = int.Parse(((HiddenField)gvPolls.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].FindControl("hfmoduleconfigid")).Value.ToString());

                    Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql pmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                    Bazaar.BusinessLayer.PAGE_MODULES_CONFIG Config = pmConfigSql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULES_CONFIGKeys(Id));

                    Config.VALUE = Value;
                    pmConfigSql.Update(Config);

                }
                else
                {

                }
            }
        }

        protected void gvPolls_DataBound(object sender, EventArgs e)
        {

            int ModuleId = 0;

            for (int i = 0; i < gvPolls.Rows.Count; i++)
            {
                ModuleId = int.Parse(gvPolls.DataKeys[i].Value.ToString());

                ((HiddenField)gvPolls.Rows[i].Cells[2].FindControl("hfmoduleconfigid")).Value = "0";

              

                        DropDownList Ddl = new DropDownList();
                        Ddl.ID = "DdlPolID";
                        Ddl.CssClass = "badge-warning";
                        Ddl.EnableViewState = true;
                        Ddl.Width = Unit.Percentage(90);
                        Ddl.ViewStateMode = System.Web.UI.ViewStateMode.Enabled;
                        Ddl.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();
                        List<Bazaar.BusinessLayer.POLLS> Polls = PollSql.SelectAll();
                        Ddl.Items.Clear();
                        foreach (Bazaar.BusinessLayer.POLLS PollItem in Polls)
                        {
                            Ddl.Items.Add(new ListItem(PollItem.TITLE, PollItem.ID.ToString()));
                        }

                        if (ModuleId != 0)
                        {
                            Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql PmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                            Bazaar.BusinessLayer.PAGE_MODULES_CONFIG PmConfig = PmConfigSql.Select_Parameters_Value("Poll_Id", ModuleId);
                            Ddl.SelectedIndex = Ddl.Items.IndexOf(Ddl.Items.FindByValue(PmConfig.VALUE.ToString()));
                            ((HiddenField)gvPolls.Rows[i].Cells[2].FindControl("hfmoduleconfigid")).Value = PmConfig.ID.ToString();
                        }


                        gvPolls.Rows[i].Cells[2].Controls.Add(Ddl);
                       
            }
        }

        protected string GetPageTitle()
        {
            return "";
        }

        protected string GetPageModuleTitle(object PageModuleId)
        {
            Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql Pg_Sql = new BusinessLayer.DataLayer.PAGE_MODULESSql();
            Bazaar.BusinessLayer.PAGE_MODULES Pg =
                Pg_Sql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULESKeys(int.Parse(PageModuleId.ToString())));
            return Pg.TITLE;
        }
        protected string GetPageTitle(object PageModuleId)
        {
            Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql Pg_Sql = new BusinessLayer.DataLayer.PAGE_MODULESSql();
            Bazaar.BusinessLayer.PAGE_MODULES Pg = 
                Pg_Sql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULESKeys(int.Parse(PageModuleId.ToString())));

            Bazaar.BusinessLayer.DataLayer.PAGESql PageSql = new BusinessLayer.DataLayer.PAGESql();
            Bazaar.BusinessLayer.PAGE PageObj = PageSql.SelectByPrimaryKey(new BusinessLayer.PAGEKeys((int)Pg.PAGE_ID));

            return PageObj.TITLE;
        }
        protected override void CreateChildControls()
        {
            if (Page.IsPostBack)
            {
                gvPolls_DataBound(new object(), new EventArgs());
            }
            else
            {

            }

        }
    }
}