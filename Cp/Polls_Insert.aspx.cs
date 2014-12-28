using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Polls_Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DdlOptionPriority.Items.Clear();
                for (int i = 0; i < 51; i++)
                {
                    DdlOptionPriority.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                LoadPoll();
            }
            int PollId = int.Parse(RouteData.Values["PollId"].ToString());
            if (PollId != 0)
            {
                btnSave.Text = "ذخیره تغییرات";
                btnSaveOption.Visible = true;
            }
            else
            {
                btnSave.Text = "ثبت نظر سنجی جدید";
                btnSaveOption.Visible = false;
            }
        }
        protected void LoadPoll()
        {
            int PollId = int.Parse(RouteData.Values["PollId"].ToString());
            if (PollId != 0)
            {
                Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();
                Bazaar.BusinessLayer.POLLS Poll = PollSql.SelectByPrimaryKey(new BusinessLayer.POLLSKeys(PollId));
                TxtTitle.Text = Poll.TITLE;

                Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql Poll_OptionsSql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
                List<Bazaar.BusinessLayer.POLLS_OPTIONS> PollsOption = Poll_OptionsSql.SelectByField("POLL_ID", PollId);
                gvOptions.DataSource = PollsOption;
                gvOptions.DataBind();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();

            Bazaar.BusinessLayer.POLLS Pl = new BusinessLayer.POLLS();
            int PollId = int.Parse(RouteData.Values["PollId"].ToString());
            if (PollId != 0)
            {
                Pl = PollSql.SelectByPrimaryKey(new BusinessLayer.POLLSKeys(PollId));
                Pl.TITLE = TxtTitle.Text.Trim();
                PollSql.Update(Pl);
            }
            else
            {
                Pl.TITLE = TxtTitle.Text.Trim();
                Pl.SHOWRESULT = true;
                Pl.ACTIVE = false;
                Pl.ALLOWNEW = true;
                Pl.CREATOR = 1;
                Pl.DATETIME = DateTime.Now;

                int NewId = PollSql.Insert(Pl);
                if (NewId > 0)
                {
                    Response.Redirect("/cp/Pollsedit/" + NewId);
                }
            }
           
        }

        protected void btnSaveOption_Click(object sender, EventArgs e)
        {
            Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql Poll_OptionsSql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
            Bazaar.BusinessLayer.POLLS_OPTIONS PlOption = new BusinessLayer.POLLS_OPTIONS();
            PlOption.TITLE = txtOptionTitle.Text;
            PlOption.PRIORITY = byte.Parse(DdlOptionPriority.SelectedValue);
            PlOption.POLL_ID = int.Parse(RouteData.Values["PollId"].ToString());
            PlOption.COUNT = 0;

            Poll_OptionsSql.Insert(PlOption);
            LoadPoll();
        }

        protected void gvOptions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "UpPriority")
            {
                 int PlopId= int.Parse(e.CommandArgument.ToString());
                Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql Poll_OptionsSql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
                Bazaar.BusinessLayer.POLLS_OPTIONS Poll_Option_Obj =
                    Poll_OptionsSql.SelectByPrimaryKey(new BusinessLayer.POLLS_OPTIONSKeys (PlopId));

                Bazaar.BusinessLayer.POLLS_OPTIONS NewObj= Poll_Option_Obj;

                NewObj.PRIORITY +=1;
                Poll_OptionsSql.Update(NewObj);

            }
             if (e.CommandName == "DownPriority")
            {
                  int PlopId= int.Parse(e.CommandArgument.ToString());
                Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql Poll_OptionsSql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
                Bazaar.BusinessLayer.POLLS_OPTIONS Poll_Option_Obj =
                    Poll_OptionsSql.SelectByPrimaryKey(new BusinessLayer.POLLS_OPTIONSKeys (PlopId));

                Bazaar.BusinessLayer.POLLS_OPTIONS NewObj= Poll_Option_Obj;
                 if( NewObj.PRIORITY> 0)
                 {
                    NewObj.PRIORITY -=1;
                    Poll_OptionsSql.Update(NewObj);
                 }
                

            }
             if (e.CommandName == "DeletePollOption")
            {
                  int PlopId= int.Parse(e.CommandArgument.ToString());
                Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql Poll_OptionsSql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
               Poll_OptionsSql.Delete(new BusinessLayer.POLLS_OPTIONSKeys (PlopId));

            }
               if (e.CommandName == "SavePollOption")
            {
                    int Indx= int.Parse(e.CommandArgument.ToString());
                     int PlopId= int.Parse( gvOptions.DataKeys[Indx].Value.ToString());
                Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql Poll_OptionsSql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
                Bazaar.BusinessLayer.POLLS_OPTIONS Poll_Option_Obj =
                    Poll_OptionsSql.SelectByPrimaryKey(new BusinessLayer.POLLS_OPTIONSKeys (PlopId));

                Bazaar.BusinessLayer.POLLS_OPTIONS NewObj= Poll_Option_Obj;
                
                   NewObj.TITLE = ((TextBox)gvOptions.Rows[Indx].FindControl("OptionTxtTitle")).Text.Trim();

                    Poll_OptionsSql.Update(NewObj);
                
                

            }
            

            LoadPoll();
            
        }
    }
}