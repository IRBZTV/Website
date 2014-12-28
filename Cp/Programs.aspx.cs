using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Programs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadPrograms();
            }
        }
        protected void LoadPrograms()
        {
            Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
            List<Bazaar.BusinessLayer.PROGRAMS> ProgList = new List<BusinessLayer.PROGRAMS>();
            Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
            List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", User.Identity.Name);
            if (UserObj.Count > 0)
            {
                if ((int)UserObj[0].PROG_ID != 0)
                {
                    ProgList = new List<BusinessLayer.PROGRAMS>();
                    ProgList.Add(ProgSql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(int.Parse(UserObj[0].PROG_ID.ToString()))));
                }
                else
                {
                    if (UserObj[0].PROGKIND == 0)
                    {
                        ProgList = ProgSql.SelectAll();
                    }
                    else
                    {
                        ProgList = ProgSql.SelectByField("kind", UserObj[0].PROGKIND);
                    }

                }
            }




            GridView1.DataSource = ProgList;
            GridView1.DataBind();
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
            int ProgId = 0;

            Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
              List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", User.Identity.Name);
              if (UserObj.Count > 0)
              {
                  if ((int)UserObj[0].PROG_ID == 0)
                  {
                      if (e.CommandName == "Active")
                      {
                          ProgId = int.Parse(e.CommandArgument.ToString());
                          Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                          Bazaar.BusinessLayer.PROGRAMS Prog = ProgSql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(ProgId));

                          if ((bool)Prog.ACTIVE)
                          {
                              Prog.ACTIVE = false;
                          }
                          else
                          {
                              Prog.ACTIVE = true;
                          }
                          ProgSql.Update(Prog);
                          LoadPrograms();
                      }
                      if (e.CommandName == "HomePage")
                      {
                          ProgId = int.Parse(e.CommandArgument.ToString());
                          Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                          Bazaar.BusinessLayer.PROGRAMS Prog = ProgSql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(ProgId));

                          if ((bool)Prog.HOMEPAGE)
                          {
                              Prog.HOMEPAGE = false;
                          }
                          else
                          {
                              Prog.HOMEPAGE = true;
                          }
                          ProgSql.Update(Prog);
                          LoadPrograms();
                      }

                      if (e.CommandName == "DeleteProg")
                      {
                          ProgId = int.Parse(e.CommandArgument.ToString());
                          Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                          ProgSql.Delete(new BusinessLayer.PROGRAMSKeys(ProgId));
                          LoadPrograms();
                      }
                      if (e.CommandName == "Priority")
                      {
                          ProgId = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                          Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                          Bazaar.BusinessLayer.PROGRAMS Prog = ProgSql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(ProgId));
                          Prog.PRIORITY = int.Parse(((TextBox)GridView1.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("TxtPriority")).Text.Trim());
                          ProgSql.Update(Prog);
                          LoadPrograms();
                      }
                  }
              }
          
           




        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadPrograms();
            GridView1.DataBind();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
              //Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
              //List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", User.Identity.Name);
              //if (UserObj.Count > 0)
              //{
              //    if ((int)UserObj[0].PROG_ID == 0)
              //    {
              //    }
              //    else
              //    {
              //      //  GridView1.Columns[GridView1.Columns.Count - 1].Visible = false;
              //    }
              //}
            
        }
    }
}