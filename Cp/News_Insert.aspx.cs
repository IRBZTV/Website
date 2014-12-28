using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class News_Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Load Controls Value
                SetStaticValues();
                

                //Polls:
                Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();
                List<Bazaar.BusinessLayer.POLLS> Polls = PollSql.SelectAll();

                DdlPollSelector.Items.Clear();
                foreach (Bazaar.BusinessLayer.POLLS PollItem in Polls)
                {
                    DdlPollSelector.Items.Add(new ListItem(PollItem.TITLE, PollItem.ID.ToString()));
                }

                //Contents Categories
                Bazaar.BusinessLayer.DataLayer.CATEGORIESSql Catql = new BusinessLayer.DataLayer.CATEGORIESSql();
                List<Bazaar.BusinessLayer.CATEGORIES> Cats = Catql.SelectAll();

                DdlCategory.Items.Clear();
                foreach (Bazaar.BusinessLayer.CATEGORIES CatItem in Cats)
                {
                    DdlCategory.Items.Add(new ListItem(CatItem.TITLE, CatItem.ID.ToString()));
                }


                //Contents Positions
                DdlPositionSelector.Items.Clear();
                DdlPositionSelector.Items.Add(new ListItem("اخبار عادی", "1"));
                DdlPositionSelector.Items.Add(new ListItem("اخبار برجسته","2"));

                //Contents States
                DdlStateSelector.Items.Clear();
                DdlStateSelector.Items.Add(new ListItem("پیش نویس", "1"));
                DdlStateSelector.Items.Add(new ListItem("باکس دبیر", "2"));
                DdlStateSelector.Items.Add(new ListItem("باکس سردبیر", "3"));



                /////////////////////////////////////////


                //Load Content Record
                if (RouteData.Values["NewsID"].ToString().Trim() == "0")
                {
                    //Insert Mode
                    //Do Nothing....
                }
                else
                {
                    //Load Content Data For Edit Mode
                    Bazaar.BusinessLayer.DataLayer.CONTENTSSql ContentsSql = new BusinessLayer.DataLayer.CONTENTSSql();
                    Bazaar.BusinessLayer.CONTENTS Cont = 
                        ContentsSql.SelectByPrimaryKey(new BusinessLayer.CONTENTSKeys(int.Parse(RouteData.Values["NewsID"].ToString().Trim())));
                    TxtTitle.Text = Cont.TITLE;
                    CKEditorDescription.Text = Cont.DESCRIPTION;
                    CKEditorBody.Text = Cont.BODY;
                    ChkActive.Checked = (Boolean) Cont.ACTIVE;

                    ChkNewComment.Checked = (Boolean)Cont.NEWCOMENT;
                    ChkShowComments.Checked = (Boolean)Cont.SHOWCOMMENTS;
                    ChkShowPoll.Checked = (Boolean)Cont.SHOWPOLL;


                    string[] DateNow = Bazaar.Core.Utility.GD2JD(Cont.DATETIME_CREATE).Split('/');

                    DdlYear.SelectedIndex = DdlYear.Items.IndexOf(new ListItem(DateNow[0], DateNow[0]));

                    DdlMonth.SelectedIndex =
                        DdlMonth.Items.IndexOf(new ListItem(string.Format("{0:00}", int.Parse(DateNow[1])),
                            string.Format("{0:00}", int.Parse(DateNow[1]))));

                    DdlDay.SelectedIndex =
                        DdlDay.Items.IndexOf(new ListItem(string.Format("{0:00}", int.Parse(DateNow[2])), 
                            string.Format("{0:00}", int.Parse(DateNow[2]))));

                    DdlHour.SelectedIndex =
                       DdlHour.Items.IndexOf(new ListItem(string.Format("{0:00}", Cont.DATETIME_CREATE.Hour),
                           string.Format("{0:00}", Cont.DATETIME_CREATE.Hour)));

                    DdlMinute.SelectedIndex =
                     DdlMinute.Items.IndexOf(new ListItem(string.Format("{0:00}", Cont.DATETIME_CREATE.Minute),
                         string.Format("{0:00}", Cont.DATETIME_CREATE.Minute)));

                    DdlCategory.SelectedIndex = DdlCategory.Items.IndexOf(DdlCategory.Items.FindByValue(Cont.CATEGORY_ID.ToString()));

                }

            }
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Bazaar.BusinessLayer.CONTENTS Item = new BusinessLayer.CONTENTS();
            Item.ACTIVE = ChkActive.Checked;
            Item.AUTHOR = 1;
            Item.BODY = CKEditorBody.Text;
            Item.CATEGORY_ID = int.Parse(DdlCategory.SelectedValue);
            Item.DATETIME_MODIFIED = DateTime.Now;
            Item.DESCRIPTION = CKEditorDescription.Text;
            Item.LEAD = "";         
            if (ChkShowPoll.Checked)
            {
                Item.SHOWPOLL = true;
                Item.POLL_ID = int.Parse(DdlPollSelector.SelectedValue);
            }
            else
            {
                Item.SHOWPOLL = false;
                Item.POLL_ID = 0;
            }
            Item.NEWCOMENT = ChkNewComment.Checked;
            Item.SHOWCOMMENTS = ChkShowComments.Checked;
            Item.STATE = byte.Parse(DdlStateSelector.SelectedValue);
            Item.TITLE = TxtTitle.Text.Trim();
            Item.DATETIME_CREATE = DateTime.Now;
            Item.DATETIME_MODIFIED = DateTime.Now;
            Item.POSITION = byte.Parse(DdlPositionSelector.SelectedValue);
            Item.VIEWCOUNT = 0;
            Item.PUBLISHER=1;


            DateTime CreateTime =
                Bazaar.Core.Utility.JD2GD(DdlYear.SelectedValue + "/" + DdlMonth.SelectedValue + "/" + DdlDay.SelectedValue);
          CreateTime =  CreateTime.AddHours(double.Parse(DdlHour.SelectedValue));
          CreateTime = CreateTime.AddMinutes(double.Parse(DdlMinute.SelectedValue));

          Item.DATETIME_CREATE = CreateTime;




            Bazaar.BusinessLayer.DataLayer.CONTENTSSql ContentsSql = new BusinessLayer.DataLayer.CONTENTSSql();
          


            if (RouteData.Values["NewsID"].ToString().Trim() == "0")
            {
                //Insert Mode              
                ContentsSql.Insert(Item);
                Response.Redirect("/cp/news");
            }
            else
            {
                //Update Content
                Item.ID = int.Parse(RouteData.Values["NewsID"].ToString().Trim());
                Bazaar.BusinessLayer.CONTENTS Cont =
                      ContentsSql.SelectByPrimaryKey(new BusinessLayer.CONTENTSKeys(int.Parse(RouteData.Values["NewsID"].ToString().Trim())));
               
                Item.VIEWCOUNT = Cont.VIEWCOUNT;

                ContentsSql.Update(Item);
                Response.Redirect("/cp/news");
            }
        }

        protected void SetStaticValues()
        {
            string[] DateNow=Bazaar.Core.Utility.GD2JD(DateTime.Now).Split('/');
            

            DdlYear.Items.Clear();
            for (int i = 1391; i < 1400; i++)
            {
                DdlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                if (DateNow[0].ToString().Equals(i.ToString()))
                {
                    DdlYear.SelectedIndex = DdlYear.Items.IndexOf(new ListItem(i.ToString(), i.ToString()));
                }

            }
           
            DdlMonth.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                DdlMonth.Items.Add(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                if (DateNow[1].ToString().Equals(i.ToString()))
                {
                    DdlMonth.SelectedIndex = DdlMonth.Items.IndexOf(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                }
            }

            DdlDay.Items.Clear();
            for (int i = 1; i < 32; i++)
            {
                DdlDay.Items.Add(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                if (DateNow[2].ToString().Equals(i.ToString()))
                {
                    DdlDay.SelectedIndex = DdlDay.Items.IndexOf(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                }
            }

            DdlHour.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                DdlHour.Items.Add(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                if (DateTime.Now.Hour==i)
                {
                    DdlHour.SelectedIndex = DdlHour.Items.IndexOf(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                }

            }

            DdlMinute.Items.Clear();
            for (int i = 0; i < 60; i++)
            {
                DdlMinute.Items.Add(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                if (DateTime.Now.Minute == i)
                {
                    DdlMinute.SelectedIndex = DdlMinute.Items.IndexOf(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                }
            }
        }
    }
}