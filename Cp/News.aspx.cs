using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStartDate.Text = Core.Utility.GD2JD(DateTime.Now);
                txtEndDate.Text = Core.Utility.GD2JD(DateTime.Now);
                LoadNewsList();
            }
        }
        protected string CategoryTitle(object CatId)
        {
            Bazaar.BusinessLayer.DataLayer.CATEGORIESSql CatSql = new BusinessLayer.DataLayer.CATEGORIESSql();
            Bazaar.BusinessLayer.CATEGORIES Cat = CatSql.SelectByPrimaryKey(new BusinessLayer.CATEGORIESKeys(int.Parse(CatId.ToString())));
            return Cat.TITLE;
        }

        protected string StateTitle(object State)
        {
            switch (State.ToString())
            {
                case "1":
                    return "پیش نویس";

                case "2":
                    return "باکس دبیر";

                case "3":
                    return "باکس سر دبیر";


                default:
                    return "---";
            }
        }

        protected string PositionTitle(object Position)
        {
            switch (Position.ToString())
            {
                case "1":
                    return "اخبار عادی";

                case "2":
                    return "اخبار برجسته";


                default:
                    return "---";
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

        protected void gvContents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ContentId = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName.ToString() == "ToggleActive")
            {
                Bazaar.BusinessLayer.DataLayer.CONTENTSSql ContentsSql = new BusinessLayer.DataLayer.CONTENTSSql();
                Bazaar.BusinessLayer.CONTENTS Cont =
                   ContentsSql.SelectByPrimaryKey(new BusinessLayer.CONTENTSKeys(ContentId));

                Bazaar.BusinessLayer.CONTENTS NewCont = Cont;
                if ((bool)Cont.ACTIVE)
                {
                    NewCont.ACTIVE = false;
                }
                else
                {
                    NewCont.ACTIVE = true;
                }

                ContentsSql.Update(NewCont);
            }
            if (e.CommandName.ToString() == "ToggleComment")
            {
                Bazaar.BusinessLayer.DataLayer.CONTENTSSql ContentsSql = new BusinessLayer.DataLayer.CONTENTSSql();
                Bazaar.BusinessLayer.CONTENTS Cont =
                   ContentsSql.SelectByPrimaryKey(new BusinessLayer.CONTENTSKeys(ContentId));

                Bazaar.BusinessLayer.CONTENTS NewCont = Cont;
                if ((bool)Cont.NEWCOMENT)
                {
                    NewCont.NEWCOMENT = false;
                }
                else
                {
                    NewCont.NEWCOMENT = true;
                }

                ContentsSql.Update(NewCont);
            }
            if (e.CommandName.ToString() == "TogglePoll")
            {
                Bazaar.BusinessLayer.DataLayer.CONTENTSSql ContentsSql = new BusinessLayer.DataLayer.CONTENTSSql();
                Bazaar.BusinessLayer.CONTENTS Cont =
                   ContentsSql.SelectByPrimaryKey(new BusinessLayer.CONTENTSKeys(ContentId));

                Bazaar.BusinessLayer.CONTENTS NewCont = Cont;
                if ((bool)Cont.SHOWPOLL)
                {
                    NewCont.SHOWPOLL = false;
                }
                else
                {
                    NewCont.SHOWPOLL = true;
                }

                ContentsSql.Update(NewCont);
            }


            if (e.CommandName.ToString() == "DeleteContent")
            {
                Bazaar.BusinessLayer.DataLayer.CONTENTSSql ContentsSql = new BusinessLayer.DataLayer.CONTENTSSql();
                ContentsSql.Delete(new BusinessLayer.CONTENTSKeys(ContentId));
            }
            if (e.CommandName.ToString() == "ToggleShowComment")
            {
                Bazaar.BusinessLayer.DataLayer.CONTENTSSql ContentsSql = new BusinessLayer.DataLayer.CONTENTSSql();
                Bazaar.BusinessLayer.CONTENTS Cont =
                   ContentsSql.SelectByPrimaryKey(new BusinessLayer.CONTENTSKeys(ContentId));

                Bazaar.BusinessLayer.CONTENTS NewCont = Cont;
                if ((bool)Cont.SHOWCOMMENTS)
                {
                    NewCont.SHOWCOMMENTS = false;
                }
                else
                {
                    NewCont.SHOWCOMMENTS = true;
                }

                ContentsSql.Update(NewCont);
            }

            LoadNewsList();

        }
        protected void LoadNewsList()
        {

            DateTime Start = Core.Utility.JD2GD(txtStartDate.Text.Trim());
            DateTime End = Core.Utility.JD2GD(txtEndDate.Text.Trim()).AddMinutes(1439);
            Bazaar.BusinessLayer.DataLayer.CONTENTSSql ContentsSql = new BusinessLayer.DataLayer.CONTENTSSql();
            List<Bazaar.BusinessLayer.CONTENTS> Conts =
                ContentsSql.SelectSearch(" DATETIME_CREATE between CONVERT(datetime, '" + Start.ToString() + "', 120)  and CONVERT(datetime, '" + End.ToString() + "', 120)  ");
            gvContents.DataSource = Conts;
            gvContents.DataBind();
        }
        protected string GetUSer(object UserId)
        {
            try
            {
                Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql UsrSql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
                Bazaar.BusinessLayer.USERS_DETAILS Usr =
                    UsrSql.SelectByPrimaryKey(new BusinessLayer.USERS_DETAILSKeys(int.Parse(UserId.ToString())));
                return Usr.FULLNAME;
            }
            catch
            {
                return "----";
            }
        }
        protected string UnActiveComments(object NewsId)
        {

            Bazaar.BusinessLayer.DataLayer.COMMENTSSql ComSql = new BusinessLayer.DataLayer.COMMENTSSql();
            List<Bazaar.BusinessLayer.COMMENTS> ComList = ComSql.SelectByCondition(" News_Id=" + NewsId.ToString() + " and Active=0");
            return ComList.Count.ToString() + " تایید نشده ";
        }

        protected void BtnLoadNews_Click(object sender, EventArgs e)
        {
            LoadNewsList();
        }
    }
}