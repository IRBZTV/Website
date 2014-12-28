using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.CallBack
{
    public partial class CallBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Headers.Remove("Server");
        }
        [WebMethod]
        public static string PollInserter(int OptionId)
        {
            Bazaar.BusinessLayer.DataLayer.POLLS_OPTIONSSql PSql = new BusinessLayer.DataLayer.POLLS_OPTIONSSql();
            Bazaar.BusinessLayer.POLLS_OPTIONS PObj = PSql.SelectByPrimaryKey(new BusinessLayer.POLLS_OPTIONSKeys(OptionId));

            PObj.COUNT = PObj.COUNT + 1;
            PSql.Update(PObj);



            HttpCookie Cook = new HttpCookie("BazaarPolls");
            Cook.Expires = DateTime.Now.AddDays(100);
            if (HttpContext.Current.Request.Cookies["BazaarPolls"] != null)
            {
                Cook = HttpContext.Current.Request.Cookies["BazaarPolls"];
                Cook.Values[PObj.ID.ToString()] = PObj.POLL_ID.ToString();
                HttpContext.Current.Response.Cookies.Add(Cook);
            }
            else
            {
                Cook.Values[PObj.ID.ToString()] = PObj.POLL_ID.ToString();
                HttpContext.Current.Response.Cookies.Add(Cook);
            }

            Bazaar.BusinessLayer.DataLayer.POLLSSql PolSql = new BusinessLayer.DataLayer.POLLSSql();
            Bazaar.BusinessLayer.POLLS PolObj = PolSql.SelectByPrimaryKey(new BusinessLayer.POLLSKeys(PObj.POLL_ID));

            StringBuilder Result = new StringBuilder();

            if ((bool)PolObj.SHOWRESULT)
            {
                List<Bazaar.BusinessLayer.POLLS_OPTIONS> OptionsLst = PSql.SelectByField("POLL_ID", PObj.POLL_ID);


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
            }
            else
            {
                Result.Append("<p class=\"green\">" + "با تشکر ، نظر شما دریافت شد." + "</p>");
            }

            return Result.ToString();




        }

        [WebMethod]
        public static string LoadPrograms(int Skip, int Take)
        {
            StringBuilder Result = new StringBuilder();


            List<Bazaar.BusinessLayer.PROGRAMS> ProgLst = new List<BusinessLayer.PROGRAMS>();
            Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
            ProgLst = ProgSql.SelectByPaging(Take, Skip);

            if (ProgLst.Count > 0)
            {


                foreach (Bazaar.BusinessLayer.PROGRAMS Item in ProgLst)
                {

                    Result.Append("<li>");

                    Result.Append(" <div class=\"image-holder\">");
                    Result.Append("   <a href=\"" + "Programs/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE) + "\">");
                    if (Item.IMAGE.ToLower().Contains("bazaar"))
                    {
                        Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                        List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> SessionsList =
                            SessionSql.SelectByProgIDTop(Item.ID, 10000, "Number");
                        if (SessionsList.Count > 0)
                        {
                            int Rdm = 0;
                            Random Rdmnum = new Random();
                            Rdm = Rdmnum.Next(0, SessionsList.Count - 1);
                            Bazaar.BusinessLayer.PROGRAM_SESSIONS Session = SessionsList[Rdm];

                            Result.Append("      <img src=\"" + ThumbnailGenerator.Generate(Session.IMAGE, 140, 0) + "\" alt=\"" + Item.TITLE + "\" title=\"[DATE]\" style=\"display: block;\">");
                            //   layoutString = layoutString.Replace("[IMG]", ThumbnailGenerator.Generate(Session.IMAGE, 300, 0));
                        }
                        else
                        {
                            Result.Append("      <img src=\"" + ThumbnailGenerator.Generate(Item.IMAGE, 140, 0) + "\" alt=\"" + Item.TITLE + "\" title=\"[DATE]\" style=\"display: block;\">");
                            // layoutString = layoutString.Replace("[IMG]", ThumbnailGenerator.Generate(Item.IMAGE, 300, 0));
                        }
                    }
                    else
                    {
                        Result.Append("      <img src=\"" + ThumbnailGenerator.Generate(Item.IMAGE, 140, 0) + "\" alt=\"" + Item.TITLE + "\" title=\"[DATE]\" style=\"display: block;\">");
                    }
                    //  Result.Append("      <img src=\"" + ThumbnailGenerator.Generate(Item.IMAGE, 140, 0) + "\" alt=\"" + Item.TITLE + "\" title=\"[DATE]\" style=\"display: block;\">");
                    Result.Append("    </a>");
                    Result.Append("      </div>");
                    Result.Append("      <h3><a href=\"program/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE) + "\"" + ">" + Item.TITLE + "</a></h3>");
                    Result.Append("      <div class=\"introtext\">");
                    Result.Append(Item.DESCRIPTION);
                    Result.Append("      </div>");
                    Result.Append("      <div class=\"clearfix\"></div>");
                    Result.Append("    </li>");
                }
            }
            else
            {
                Result = new StringBuilder();
                Result.Append("No");
            }

            return Result.ToString();
        }
        [WebMethod]
        public static string LoadContents(int Skip, int Take, int CatId)
        {
            StringBuilder Result = new StringBuilder();


            List<Bazaar.BusinessLayer.CONTENTS> ContentsLst = new List<BusinessLayer.CONTENTS>();
            Bazaar.BusinessLayer.DataLayer.CONTENTSSql ContentSql = new BusinessLayer.DataLayer.CONTENTSSql();
            ContentsLst = ContentSql.SelectByPaging(Take, Skip, CatId);

            if (ContentsLst.Count > 0)
            {


                foreach (Bazaar.BusinessLayer.CONTENTS Item in ContentsLst)
                {

                    Result.Append("<li>");
                    Result.Append("<a href=\"/news/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE) + "\">" + Item.TITLE);
                    Result.Append("</a>");
                    Result.Append("</li>");



                }


            }
            else
            {
                Result = new StringBuilder();
                Result.Append("No");
            }

            return Result.ToString();
        }
        [WebMethod]
        public static string LoadContentsNewsPage(int Skip, int Take, int CatId)
        {
            StringBuilder Result = new StringBuilder();
            List<Bazaar.BusinessLayer.CONTENTS> ContentsLst = new List<BusinessLayer.CONTENTS>();
            Bazaar.BusinessLayer.DataLayer.CONTENTSSql ContentSql = new BusinessLayer.DataLayer.CONTENTSSql();
            ContentsLst = ContentSql.SelectByPaging(Take, Skip, CatId);

            if (ContentsLst.Count > 0)
            {
                foreach (Bazaar.BusinessLayer.CONTENTS Item in ContentsLst)
                {
                    Result.Append("<li>");
                    Result.Append(" <div class=\"image-holder\">");
                    Result.Append("<a href=\"/news/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE) + "\">");

                    BusinessLayer.DataLayer.CONTENT_FILESSql Content_File_Sql = new BusinessLayer.DataLayer.CONTENT_FILESSql();

                    List<BusinessLayer.CONTENT_FILES> Files_Lst = Content_File_Sql.SelectBy_NewsId_FileType(Item.ID, 1);

                    if (Files_Lst.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(Files_Lst[0].PATH))
                        {
                            int Rdm = 0;
                            Random Rdmnum = new Random();
                            Rdm = Rdmnum.Next(0, Files_Lst.Count);

                            Result.Append("  <img src=\"" + ThumbnailGenerator.Generate(Files_Lst[Rdm].PATH, 140, 0)
                                + "\" data-original=\"" + ThumbnailGenerator.Generate(Files_Lst[Rdm].PATH, 610, 0) + "\" class=\"hastip\" alt=\"" + Item.TITLE + "\" title=\"" + Item.TITLE + "\" />");

                        }
                    }

                    Result.Append(" </a>");
                    Result.Append("  </div>");
                    Result.Append(" <h3><a href=\"" + "/news/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE) + "\" class=\"hastip\" title=\"" + Bazaar.Core.Utility.GD2StringDateTime(Item.DATETIME_CREATE) + "\">" + Item.TITLE + "</a></h3>");
                    Result.Append(" <div class=\"introtext\">");
                    Result.Append(Item.DESCRIPTION);
                    Result.Append("  </div>");
                    Result.Append("  <div class=\"clearfix\"></div>");
                    Result.Append(" </li> ");

                }
            }
            else
            {
                Result = new StringBuilder();
                Result.Append("No");
            }

            return Result.ToString();
        }
        [WebMethod]
        public static string LoadSchedulesAjax(string DtId)
        {
            StringBuilder Body = new StringBuilder();
            BusinessLayer.DataLayer.SCHEDULESSql Schedule_Sql = new BusinessLayer.DataLayer.SCHEDULESSql();
            DateTime CurDate = DateTime.ParseExact(DtId.Trim(), "yyyyMMdd", CultureInfo.CurrentCulture);
            Body.Append("<table class=\"table table-hover table-condensed\"><tbody>");
            DateTime Strt = DateTime.Parse(CurDate.ToShortDateString() + " 00:00:00 am");
            DateTime end = DateTime.Parse(CurDate.ToShortDateString() + " 23:59:59 pm");
            List<BusinessLayer.SCHEDULES> Schedules_Lst = Schedule_Sql.SelectTopBetweenTime(500, Strt, end);
            if (Schedules_Lst.Count > 0)
            {
                foreach (BusinessLayer.SCHEDULES item in Schedules_Lst)
                {
                    Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                    List<Bazaar.BusinessLayer.PROGRAMS> ProgLst = ProgSql.SelectByField("Id", item.URL);
                    if (ProgLst.Count > 0)
                    {
                        if ((bool)ProgLst[0].ACTIVE)
                        {
                            Body.Append(" <tr><td class=\"item-time\"> <span class=\"time\">" + Bazaar.Core.Utility.ToTimeString(item.DATETIME) +
                           "</span> </td><td> <a href=\"" + "program/" + ProgLst[0].ID + "/" + Bazaar.Core.Utility.ClearTitle(ProgLst[0].TITLE) + "\"  class=\"schedules-link\"><span class=\"photo\">");
                        }
                        else
                        {
                            Body.Append(" <tr><td class=\"item-time\"> <span class=\"time\">" + Bazaar.Core.Utility.ToTimeString(item.DATETIME) +
                          "</span> </td><td> <span class=\"photo\">");
                        }
                        Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                        List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> SessionsList =
                            SessionSql.SelectByProgIDTop(ProgLst[0].ID, 10, "Number");
                        if (SessionsList.Count > 0)
                        {
                            int Rdm = 0;
                            Random Rdmnum = new Random();
                            Rdm = Rdmnum.Next(0, SessionsList.Count - 1);
                            Bazaar.BusinessLayer.PROGRAM_SESSIONS Session = SessionsList[Rdm];
                            Body.Append("<img src=\"" + ThumbnailGenerator.Generate(Session.IMAGE, 100, 0) + "\" title=\"" + ProgLst[0].TITLE + "\" alt=\"" + ProgLst[0].TITLE + "\" />");
                        }
                        else
                        {
                            Body.Append("<img src=\"" + ThumbnailGenerator.Generate(ProgLst[0].IMAGE, 100, 0) + "\" title=\"" + ProgLst[0].TITLE + "\" alt=\"" + ProgLst[0].TITLE + "\" />");
                        }
                        Body.Append("</span><h3>" + ProgLst[0].TITLE + "</h3> <p>" + item.DESCRIPTION + "</p></td>  </tr>");
                    }
                    else
                    {
                        Body.Append(" <tr><td class=\"item-time\"> <span class=\"time\">" + Bazaar.Core.Utility.ToTimeString(item.DATETIME) + "</span> </td><td><span class=\"photo\">");
                        Body.Append("<img src=\"" + "/files/images/Bazaar.jpg" + "\" title=\"" + item.TITLE + "\" alt=\"" + item.TITLE + "\" />");
                        Body.Append("</span><h3>" + item.TITLE + "</h3><p>" + item.DESCRIPTION + "</p></td>  </tr>");
                    }
                }
                Body.Append(" </tbody> </table>");
                return Body.ToString();
            }
            else
            {
                return "موردی یافت نشد";
            }
        }
    }
}