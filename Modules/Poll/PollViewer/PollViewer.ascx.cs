using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Poll.PollViewer
{
    public partial class PollViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();
                    Bazaar.BusinessLayer.POLLS Pl = PollSql.SelectByPrimaryKey(new BusinessLayer.POLLSKeys(PollId));

                    if ((bool)Pl.ACTIVE)
                    {

                        string Container = "";
                        switch (Container_Layout)
                        {
                            case "Title":
                                Container = ReadFile(Server.MapPath("~/Core/ContainerTemplates/" + Container_Layout + ".html"));
                                Container = Container.Replace("[MODULETITILE]", ModuleTitle);
                                break;

                            case "TitleTime":
                                Container = ReadFile(Server.MapPath("~/Core/ContainerTemplates/" + Container_Layout + ".html"));
                                Container = Container.Replace("[MODULETITILE]", ModuleTitle);
                                Container = Container.Replace("[TIME]", Bazaar.Core.Utility.GD2StringDateTime((DateTime)Pl.DATETIME));

                                break;

                            case "None":
                                Container = "";
                                break;


                            case "Line":
                                Container = ReadFile(Server.MapPath("~/Core/ContainerTemplates/Title.html"));
                                Container = Container.Replace("[MODULETITILE]", "");
                                break;


                            default:
                                Container = "";
                                break;
                        }
                        LtrModuleTitle.Text = Container;











                        LblTitle.Text = Pl.TITLE;



                        Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql Poll_Option_Sql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
                        List<Bazaar.BusinessLayer.POLLS_OPTIONS> Pl_Options_Lst = Poll_Option_Sql.SelectByField("POLL_ID", PollId.ToString());

                        Literal1.Text += " <label id=\"PollId\" pollid=\"" + Pl.ID + "\" class=\"radio\" style=\"display:none;\"></label>";



                        HttpCookie Cook = new HttpCookie("BazaarPolls");
                        Cook.Expires = DateTime.Now.AddDays(100);



                        bool Voted = false;
                        if (Request.Cookies["BazaarPolls"] != null)
                        {
                            Cook = Request.Cookies["BazaarPolls"];
                            for (int i = 0; i < Cook.Values.Count; i++)
                            {
                                if (Pl.ID.ToString() == Cook.Values[i].ToString())
                                {
                                    Voted = true;
                                }
                            }
                        }


                        if (!Voted)
                        {
                            if ((bool)Pl.ALLOWNEW)
                            {

                                foreach (Bazaar.BusinessLayer.POLLS_OPTIONS item in Pl_Options_Lst)
                                {
                                    Literal1.Text += " <label class='radio'><input type='radio' name='poll-options' id='option" + item.ID + "' value='" + item.ID + "' >" + item.TITLE + "</label>";
                                }
                                Literal1.Text += "<div class=\"pull-left\"> <button class=\"btn\" id=\"submit-poll\" type=\"submit\">ثبت نظر</button> </div>";
                            }
                            else
                            {
                                if ((bool)Pl.SHOWRESULT)
                                {

                                    Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql PSql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
                                    List<Bazaar.BusinessLayer.POLLS_OPTIONS> OptionsLst = PSql.SelectByField("POLL_ID", Pl.ID);

                                    StringBuilder Result = new StringBuilder();


                                    long TotalCount = 0;

                                    foreach (Bazaar.BusinessLayer.POLLS_OPTIONS item in OptionsLst)
                                    {
                                        TotalCount += (long)item.COUNT;
                                    }

                                    foreach (Bazaar.BusinessLayer.POLLS_OPTIONS item in OptionsLst)
                                    {
                                        float Percent = 0;
                                        Percent = (((long.Parse(item.COUNT.ToString())) * 100) / TotalCount);


                                        Result.Append("<p>" + item.TITLE + "</p>");
                                        Result.Append("<div class=\"progress progress-striped\">");
                                        Result.Append(" <div class=\"bar\" style=\"width: " + string.Format("{0:0}", Percent) + "%\"><span>" + string.Format("{0:0}", Percent) + "%</span></div>");
                                        Result.Append("</div>");
                                    }
                                    Literal1.Text += Result;

                                }

                                else
                                {
                                    Literal1.Text += "<p class=\"red\">" + "نظر شما قبلا دریافت شده است." + "</p>";
                                }
                            }
                        }
                        else
                        {
                            if ((bool)Pl.SHOWRESULT)
                            {

                                Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql PSql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
                                List<Bazaar.BusinessLayer.POLLS_OPTIONS> OptionsLst = PSql.SelectByField("POLL_ID", Pl.ID);

                                StringBuilder Result = new StringBuilder();


                                long TotalCount = 0;

                                foreach (Bazaar.BusinessLayer.POLLS_OPTIONS item in OptionsLst)
                                {
                                    TotalCount += (long)item.COUNT;
                                }

                                foreach (Bazaar.BusinessLayer.POLLS_OPTIONS item in OptionsLst)
                                {
                                    float Percent = 0;
                                    Percent = (((long.Parse(item.COUNT.ToString())) * 100) / TotalCount);


                                    Result.Append("<p>" + item.TITLE + "</p>");
                                    Result.Append("<div class=\"progress progress-striped\">");
                                    Result.Append(" <div class=\"bar\" style=\"width: " + string.Format("{0:0}", Percent) + "%\"><span>" + string.Format("{0:0}", Percent) + "%</span></div>");
                                    Result.Append("</div>");
                                }
                                Literal1.Text += Result;

                            }

                            else
                            {
                                Literal1.Text += "<p class=\"red\">" + "نظر شما قبلا دریافت شده است." + "</p>";
                            }


                        }
                    }
                    else
                    {
                        LblTitle.Text = "نظر سنجی انتخاب شده غیرفعال است";

                    }


                }
            }
            catch
            {

                LblTitle.Text = "";
            }

        }
        private static string ReadFile(string path)
        {
            string result = "";
            System.IO.StreamReader sr = new System.IO.StreamReader(path);
            try
            {
                result = sr.ReadToEnd();
            }
            finally
            {
                sr.Close();
            }
            return result;
        }

        public int PollId { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }

    }
}