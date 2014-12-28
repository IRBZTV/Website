using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Bazaar.Cp
{
    public partial class Services_Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TxtDate.Text = Core.Utility.GD2JD(DateTime.Now, true);


                BusinessLayer.DataLayer.USERS_DETAILSSql Usr_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
                List<BusinessLayer.USERS_DETAILS> Usr = Usr_Sql.SelectByField("USRNM", Context.User.Identity.Name);
                if (Usr.Count == 1)
                {
                    TxtUser.Text = Usr[0].FULLNAME;
                }

                BusinessLayer.DataLayer.SERVICE_CATEGORIESSql Cat_Sql = new BusinessLayer.DataLayer.SERVICE_CATEGORIESSql();
                List<BusinessLayer.SERVICE_CATEGORIES> Cat_Lst = Cat_Sql.SelectAll();

                DdlCat.Items.Clear();
                foreach (BusinessLayer.SERVICE_CATEGORIES item in Cat_Lst)
                {
                    DdlCat.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }
                DdlCat_SelectedIndexChanged(new object(), new EventArgs());

                BusinessLayer.DataLayer.SERVICE_KINDSql Kind_Sql = new BusinessLayer.DataLayer.SERVICE_KINDSql();
                List<BusinessLayer.SERVICE_KIND> Kind_Lst = Kind_Sql.SelectAll();

                DdlKind.Items.Clear();
                foreach (BusinessLayer.SERVICE_KIND item in Kind_Lst)
                {
                    DdlKind.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }


                BusinessLayer.DataLayer.SERVICE_CLIENTSSql Client_Sql = new BusinessLayer.DataLayer.SERVICE_CLIENTSSql();
                List<BusinessLayer.SERVICE_CLIENTS> Client_Lst = Client_Sql.SelectAll();

                DdlClient.Items.Clear();
                foreach (BusinessLayer.SERVICE_CLIENTS item in Client_Lst)
                {
                    DdlClient.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }


                if (RouteData.Values["RepId"].ToString().Trim() != "0")
                {
                    BusinessLayer.DataLayer.SERVICE_REPORTSql Rtp_Sql = new BusinessLayer.DataLayer.SERVICE_REPORTSql();
                    BusinessLayer.SERVICE_REPORT Rtp = Rtp_Sql.SelectByPrimaryKey(new BusinessLayer.SERVICE_REPORTKeys(int.Parse(RouteData.Values["RepId"].ToString().Trim())));
                    Txtbody.Text = Rtp.TEXT;
                    TxtDate.Text = Core.Utility.GD2JD((DateTime)Rtp.DATETIME, true);

                    DdlCat.SelectedIndex = DdlCat.Items.IndexOf(DdlCat.Items.FindByValue(Rtp.CAT_ID.ToString()));
                    DdlCat_SelectedIndexChanged(new object(), new EventArgs());
                    DdlClient.SelectedIndex = DdlClient.Items.IndexOf(DdlClient.Items.FindByValue(Rtp.CLIENT_ID.ToString()));
                    DdlKind.SelectedIndex = DdlKind.Items.IndexOf(DdlKind.Items.FindByValue(Rtp.KIND_ID.ToString()));
                    DdlList.SelectedIndex = DdlList.Items.IndexOf(DdlList.Items.FindByValue(Rtp.LIST_ID.ToString()));
                    DdlShift.SelectedIndex = DdlShift.Items.IndexOf(DdlShift.Items.FindByValue(Rtp.SHIFT.ToString()));
                    TxtMinute.Text = Rtp.MINUTE.ToString();

                    List<BusinessLayer.USERS_DETAILS> UsrRtp = Usr_Sql.SelectByField("ID", Rtp.USER_ID);
                    if (UsrRtp.Count == 1)
                    {
                        TxtUser.Text = UsrRtp[0].FULLNAME;
                    }
                    else
                    {
                        TxtUser.Text = "User Id : "+Rtp.USER_ID+" Deleted";
                    }


                    if (Usr.Count == 1)
                    {
                        if (Rtp.USER_ID != Usr[0].ID && Context.User.Identity.Name.ToLower() != "admin")
                        {
                            BtnSave.Enabled = false;
                        }
                    }
                    else
                    {
                        //  Rtp.USER_ID = 0;
                    }
                }
            }

        }

        protected void DdlCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusinessLayer.DataLayer.SERVICE_LISTSql List_Sql = new BusinessLayer.DataLayer.SERVICE_LISTSql();
            List<BusinessLayer.SERVICE_LIST> List_Lst = List_Sql.SelectByField("SID", DdlCat.SelectedValue);

            DdlList.Items.Clear();
            foreach (BusinessLayer.SERVICE_LIST item in List_Lst)
            {
                DdlList.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            BusinessLayer.DataLayer.SERVICE_REPORTSql Rtp_Sql = new BusinessLayer.DataLayer.SERVICE_REPORTSql();
            BusinessLayer.SERVICE_REPORT Rtp = new BusinessLayer.SERVICE_REPORT();

            if (RouteData.Values["RepId"].ToString().Trim() == "0")
            {
                BusinessLayer.DataLayer.USERS_DETAILSSql Usr_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
                List<BusinessLayer.USERS_DETAILS> Usr = Usr_Sql.SelectByField("USRNM", Context.User.Identity.Name);            
               
                Rtp.CAT_ID = int.Parse(DdlCat.SelectedValue);
                Rtp.CLIENT_ID = int.Parse(DdlClient.SelectedValue);
                Rtp.KIND_ID = int.Parse(DdlKind.SelectedValue);
                Rtp.LIST_ID = int.Parse(DdlList.SelectedValue);
                Rtp.DATETIME = DateTime.Now;
                Rtp.TEXT = Txtbody.Text;
                Rtp.SHIFT = int.Parse(DdlShift.SelectedValue);
                Rtp.MINUTE = int.Parse(TxtMinute.Text.Trim());
                if (Usr.Count == 1)
                {
                    Rtp.USER_ID = Usr[0].ID;
                }
                else
                {
                    Rtp.USER_ID = 0;
                }

                Rtp_Sql.Insert(Rtp);
                Response.Redirect("/cp/Service/List");
            }
            else
            {
                BusinessLayer.SERVICE_REPORT RtpOrig = Rtp_Sql.SelectByPrimaryKey(new BusinessLayer.SERVICE_REPORTKeys(int.Parse(RouteData.Values["RepId"].ToString().Trim())));
                RtpOrig.CAT_ID = int.Parse(DdlCat.SelectedValue);
                RtpOrig.CLIENT_ID = int.Parse(DdlClient.SelectedValue);
                RtpOrig.KIND_ID = int.Parse(DdlKind.SelectedValue);
                RtpOrig.LIST_ID = int.Parse(DdlList.SelectedValue);
                RtpOrig.TEXT = Txtbody.Text;
                RtpOrig.SHIFT = int.Parse(DdlShift.SelectedValue);
                RtpOrig.ID = int.Parse(RouteData.Values["RepId"].ToString().Trim());
                RtpOrig.MINUTE = int.Parse(TxtMinute.Text.Trim());
                DateTime Dt= (DateTime)RtpOrig.DATETIME;
                
                RtpOrig.DATETIME = DateTime.Parse(Bazaar.Core.Utility.JD2GD(TxtDate.Text.Trim()).ToShortDateString()+" "+Dt.TimeOfDay.ToString());
                Rtp_Sql.Update(RtpOrig);
            }
        }


    }
}