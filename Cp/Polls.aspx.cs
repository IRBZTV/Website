using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Polls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadPolls();
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
        protected void LoadPolls()
        {
            Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();
            List< Bazaar.BusinessLayer.POLLS> PollsLst = PollSql.SelectAll();
            gvPolls.DataSource = PollsLst;
            gvPolls.DataBind();
        }

        protected void gvPolls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int PollId = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.ToString() == "Active")
            {
                Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();
                Bazaar.BusinessLayer.POLLS Poll = PollSql.SelectByPrimaryKey(new BusinessLayer.POLLSKeys(PollId));

                Bazaar.BusinessLayer.POLLS NewPoll = Poll;
                if ((bool)Poll.ACTIVE)
                {
                    NewPoll.ACTIVE = false;
                }
                else
                {
                    NewPoll.ACTIVE = true;
                }

                PollSql.Update(NewPoll);
            }

            if (e.CommandName.ToString() == "ALLOWNEW")
            {
                Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();
                Bazaar.BusinessLayer.POLLS Poll = PollSql.SelectByPrimaryKey(new BusinessLayer.POLLSKeys(PollId));



                Bazaar.BusinessLayer.POLLS NewPoll = Poll;
                if ((bool)Poll.ALLOWNEW)
                {
                    NewPoll.ALLOWNEW = false;
                }
                else
                {
                    NewPoll.ALLOWNEW = true;
                }

                PollSql.Update(NewPoll);
            }

            if (e.CommandName.ToString() == "ToggleSHOWRESULT")
            {
                Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();
                Bazaar.BusinessLayer.POLLS Poll = PollSql.SelectByPrimaryKey(new BusinessLayer.POLLSKeys(PollId));

                Bazaar.BusinessLayer.POLLS NewPoll = Poll;
                if ((bool)Poll.SHOWRESULT)
                {
                    NewPoll.SHOWRESULT = false;
                }
                else
                {
                    NewPoll.SHOWRESULT = true;
                }

                PollSql.Update(NewPoll);
            }

            if (e.CommandName.ToString() == "DeletePoll")
            {
                Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();
                PollSql.Delete(new BusinessLayer.POLLSKeys(PollId));

                Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql PolOpSql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
                PolOpSql.DeleteByField("POLL_ID", PollId);
            }
            
            LoadPolls();
        }
    }
}