using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Programs_Sessions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HplinkNewSession.NavigateUrl = "/cp/Programs/Session/Edit/"
                + RouteData.Values["ProgramID"].ToString() + "/0";
            if (!Page.IsPostBack)
            {
                Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql ProgSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> ProgSqssionsList = ProgSql.SelectByField("Prog_ID", RouteData.Values["ProgramID"]);
                GridView1.DataSource = ProgSqssionsList;
                GridView1.DataBind();
            }
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
            List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", User.Identity.Name);
            if (UserObj.Count > 0)
            {
                if ((int)UserObj[0].PROG_ID == 0)
                {
                    int SessioId = int.Parse(e.CommandArgument.ToString());

                    if (e.CommandName == "Active")
                    {
                        Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql ProgSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                        Bazaar.BusinessLayer.PROGRAM_SESSIONS Progs = ProgSql.SelectByPrimaryKey(new BusinessLayer.PROGRAM_SESSIONSKeys(SessioId));

                        if ((bool)Progs.ACTIVE)
                        {
                            Progs.ACTIVE = false;
                        }
                        else
                        {
                            Progs.ACTIVE = true;
                        }
                        ProgSql.Update(Progs);

                        List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> ProgSqssionsList = ProgSql.SelectByField("Prog_ID", RouteData.Values["ProgramID"]);
                        GridView1.DataSource = ProgSqssionsList;
                        GridView1.DataBind();
                    }
                }
            }

        }
        protected string BuildEditUrl(object Id)
        {
            return "/cp/Programs/Session/Edit/" + RouteData.Values["ProgramID"].ToString() + "/" + Id.ToString();
        }

    }
}