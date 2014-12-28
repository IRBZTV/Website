using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BusinessLayer.DataLayer.SERVICE_CATEGORIESSql Cat_Sql = new BusinessLayer.DataLayer.SERVICE_CATEGORIESSql();
                List<BusinessLayer.SERVICE_CATEGORIES> Cat_Lst = Cat_Sql.SelectAll();

                DdlCat.Items.Clear();
                DdlCat.Items.Add(new ListItem("گروه", "0"));
                foreach (BusinessLayer.SERVICE_CATEGORIES item in Cat_Lst)
                {
                    DdlCat.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }
                DdlCat_SelectedIndexChanged(new object(), new EventArgs());

                BusinessLayer.DataLayer.SERVICE_KINDSql Kind_Sql = new BusinessLayer.DataLayer.SERVICE_KINDSql();
                List<BusinessLayer.SERVICE_KIND> Kind_Lst = Kind_Sql.SelectAll();


                DdlKind.Items.Clear();
                DdlKind.Items.Add(new ListItem("نوع", "0"));
                foreach (BusinessLayer.SERVICE_KIND item in Kind_Lst)
                {
                    DdlKind.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }


                BusinessLayer.DataLayer.SERVICE_CLIENTSSql Client_Sql = new BusinessLayer.DataLayer.SERVICE_CLIENTSSql();
                List<BusinessLayer.SERVICE_CLIENTS> Client_Lst = Client_Sql.SelectAll();


                DdlClient.Items.Clear();
                DdlClient.Items.Add(new ListItem("واحد", "0"));
                foreach (BusinessLayer.SERVICE_CLIENTS item in Client_Lst)
                {
                    DdlClient.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }


                BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
                List<BusinessLayer.USERS_DETAILS> UserLst = User_Sql.SelectAll();


                DdlUser.Items.Clear();
                DdlUser.Items.Add(new ListItem("کاربر", "0"));
                foreach (BusinessLayer.USERS_DETAILS item in UserLst)
                {
                    DdlUser.Items.Add(new ListItem(item.FULLNAME, item.ID.ToString()));
                }
                txtStartDate.Text = Core.Utility.GD2JD(DateTime.Now);
                txtEndDate.Text = Core.Utility.GD2JD(DateTime.Now);
                LoadServiceList();
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

            LoadServiceList();

        }
        protected void LoadServiceList()
        {
            DateTime Start = Core.Utility.JD2GD(txtStartDate.Text.Trim());
            DateTime End = Core.Utility.JD2GD(txtEndDate.Text.Trim()).AddMinutes(1439);

            string Condition = "  where  DATETIME between CONVERT(datetime, '" + Start.ToString() + "', 120)  and CONVERT(datetime, '" + End.ToString() + "', 120)  and";
            if (DdlCat.SelectedIndex > 0)
            {
                Condition += " CAT_ID=" + DdlCat.SelectedValue + "  and";
            }
            if (DdlList.SelectedIndex > 0)
            {
                Condition += " LIST_ID=" + DdlList.SelectedValue + "  and";
            }
            if (DdlClient.SelectedIndex > 0)
            {
                Condition += " CLIENT_ID=" + DdlClient.SelectedValue + "  and";
            }
            if (DdlKind.SelectedIndex > 0)
            {
                Condition += " Kind_ID=" + DdlKind.SelectedValue + "  and";
            }
            if (DdlShift.SelectedIndex > 0)
            {
                Condition += " SHIFT=" + DdlShift.SelectedValue + "  and";
            }

            if (DdlUser.SelectedIndex > 0)
            {
                Condition += " USER_ID=" + DdlUser.SelectedValue + "  and";
            }
            if (TxtBody.Text.Trim().Length > 0)
            {
                Condition += " TEXT like N'%" + TxtBody.Text.Trim() + "%'  and";
            }
            Bazaar.BusinessLayer.DataLayer.SERVICE_REPORTSql ServSql = new BusinessLayer.DataLayer.SERVICE_REPORTSql();
            List<Bazaar.BusinessLayer.SERVICE_REPORT> Conts =
                ServSql.SelectByCondition(Condition.Remove(Condition.Length - 3, 3)+" order by datetime desc");
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
            PrintUrl.NavigateUrl = "/cp/printservicereport.aspx?start="+txtStartDate.Text.Trim()+"&end=" + txtEndDate.Text.Trim();
            LoadServiceList();
        }
        protected string GetListTitle(object ListId)
        {
            BusinessLayer.DataLayer.SERVICE_LISTSql List_Sql = new BusinessLayer.DataLayer.SERVICE_LISTSql();
            return List_Sql.SelectByPrimaryKey(new BusinessLayer.SERVICE_LISTKeys(int.Parse(ListId.ToString()))).TITLE;
        }
        protected string GetCatTitle(object CatId)
        {
            try
            {
                BusinessLayer.DataLayer.SERVICE_CATEGORIESSql Cat_Sql = new BusinessLayer.DataLayer.SERVICE_CATEGORIESSql();
                return Cat_Sql.SelectByPrimaryKey(new BusinessLayer.SERVICE_CATEGORIESKeys(int.Parse(CatId.ToString()))).TITLE;
            }
            catch
            {

                return "-----";
            }

        }
        protected string ShiftTitle(object ShiftId)
        {
            try
            {
                switch (ShiftId.ToString())
                {
                    case "1":
                        return "شیفت 1";

                    case "2":
                        return "شیفت 2";

                    case "3":
                        return "شیفت 3";


                    default:
                        return "-----";

                }
            }
            catch
            {

                return "-----";
            }

        }
        protected string GetClientTitle(object ClientId)
        {
            BusinessLayer.DataLayer.SERVICE_CLIENTSSql Cat_Sql = new BusinessLayer.DataLayer.SERVICE_CLIENTSSql();
            return Cat_Sql.SelectByPrimaryKey(new BusinessLayer.SERVICE_CLIENTSKeys(int.Parse(ClientId.ToString()))).TITLE;
        }
        protected string GetKindTitle(object KindId)
        {
            BusinessLayer.DataLayer.SERVICE_KINDSql Kind_Sql = new BusinessLayer.DataLayer.SERVICE_KINDSql();
            return Kind_Sql.SelectByPrimaryKey(new BusinessLayer.SERVICE_KINDKeys(int.Parse(KindId.ToString()))).TITLE;
        }
        protected string CutText(object Text)
        {
            string Txt = Text.ToString();
            if (Txt.Length > 20)
            {
                return Txt.Substring(0, 19) + "...";
            }
            else
            {
                return Txt;
            }
        }
        protected void DdlCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusinessLayer.DataLayer.SERVICE_LISTSql List_Sql = new BusinessLayer.DataLayer.SERVICE_LISTSql();
            List<BusinessLayer.SERVICE_LIST> List_Lst = List_Sql.SelectByField("SID", DdlCat.SelectedValue);

            DdlList.Items.Clear();
            DdlList.Items.Add(new ListItem("فعالیت", "0"));
            foreach (BusinessLayer.SERVICE_LIST item in List_Lst)
            {
                DdlList.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
            }
        }

        protected void gvContents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContents.PageIndex = e.NewPageIndex;
            LoadServiceList();
            gvContents.DataBind();
        }
    }
}