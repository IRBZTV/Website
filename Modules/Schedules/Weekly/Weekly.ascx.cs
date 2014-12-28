using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Schedules.Weekly
{
    public partial class Weekly : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            #region Container
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
                    Container = Container.Replace("[TIME]", Bazaar.Core.Utility.GD2StringDateTime(DateTime.Now));

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
            #endregion

            BusinessLayer.DataLayer.SCHEDULESSql Schedule_Sql = new BusinessLayer.DataLayer.SCHEDULESSql();
           int NextDays = Schedule_Sql.SCHEDULES_CountNextExistDays();
           // int NextDays = 2;
            int BeforeDays = 7 - NextDays;
            
            StringBuilder sb = new StringBuilder();
            sb.Append("<div id='schedules-page'>");

            string DaysLinkString = "";

            DaysLinkString += " <ul class='nav nav-tabs schedule-tab' id='schedule-tabs'>";
            StringBuilder Body = new StringBuilder();

            sb.Append(" <div class='tab-content schedule-tab-content'>");

            //Before Days
          
            #region Before
            for (int i = BeforeDays; i > 0; i--)
            {
                DateTime CurDate = DateTime.Now.AddDays(-i);
                string DateId ="Date-"+ string.Format("{0:0000}", CurDate.Year) +
                    string.Format("{0:00}",CurDate.Month) +
                    string.Format("{0:00}",CurDate.Day);

                string ActiveClass = "";

                DateTime Strt = DateTime.Parse(CurDate.ToShortDateString() + " 00:00:00 am");
                DateTime end = DateTime.Parse(CurDate.ToShortDateString() + " 23:59:59 pm");

                if (DateTime.Now > Strt && DateTime.Now < end)
                {
                    ActiveClass = " active";
                }


                DaysLinkString += "<li class=\"" + ActiveClass + "\" ><a href=\"#" + DateId + "\"><span class=\"day\">" + Bazaar.Core.Utility.GD2NameofDay(CurDate) +
                    "</span><br/>" + Bazaar.Core.Utility.GD2JD(CurDate).Split('/')[2] +
                    " " + Bazaar.Core.Utility.GD2NameofMonth(CurDate) + "</a></li>";


                Body.Append("<div class=\"tab-pane  " + ActiveClass + " \" id=\"" + DateId + "\">");
                Body.Append(" </div>");
            } 
            #endregion

           // Today + Nesxt Days

          
            #region TodayAndNext
            for (int i = 0; i < NextDays; i++)
            {
                DateTime CurDate = DateTime.Now.AddDays(i);
                     string DateId ="Date-"+ string.Format("{0:0000}", CurDate.Year) +
                    string.Format("{0:00}",CurDate.Month) +
                    string.Format("{0:00}",CurDate.Day);
                string ActiveClass = "";
                DateTime Strt = DateTime.Parse(CurDate.ToShortDateString() + " 00:00:00 am");
                DateTime end = DateTime.Parse(CurDate.ToShortDateString() + " 23:59:59 pm");
                if (DateTime.Now > Strt && DateTime.Now < end)
                {
                    ActiveClass = " active";
                }
                DaysLinkString += "<li class=\"" + ActiveClass + "\" ><a href=\"#" + DateId + "\"><span class=\"day\">" + Bazaar.Core.Utility.GD2NameofDay(CurDate) +
                    "</span><br/>" + Bazaar.Core.Utility.GD2JD(CurDate).Split('/')[2] +
                    " " + Bazaar.Core.Utility.GD2NameofMonth(CurDate) + "</a></li>";

                Body.Append("<div class=\"tab-pane  " + ActiveClass + " \" id=\"" + DateId + "\">");

                if (DateTime.Now<=end && DateTime.Now>=Strt)
                {
                    Body.Append("<table class=\"table table-hover table-condensed\"><tbody>");
                    List<BusinessLayer.SCHEDULES> Schedules_Lst = Schedule_Sql.SelectTopBetweenTime(500, Strt, end);

                    int OnAirId = -1;
                    for (int j = 0; j < Schedules_Lst.Count; j++)
                    {
                        if (j < Schedules_Lst.Count - 1)
                        {
                            if (DateTime.Now >= Schedules_Lst[j].DATETIME && DateTime.Now <= Schedules_Lst[j + 1].DATETIME)
                            {
                                OnAirId = Schedules_Lst[j].ID;
                            }

                        }
                    }

                    foreach (BusinessLayer.SCHEDULES item in Schedules_Lst)
                    {
                        if (!string.IsNullOrEmpty(item.URL))
                        {
                            try
                            {
                                Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                                List<Bazaar.BusinessLayer.PROGRAMS> ProgLst = ProgSql.SelectByField("Id", item.URL);


                                if (ProgLst.Count > 0)
                                {
                                    string Onair = "";
                                    string TrClass = "";
                                    if (item.ID == OnAirId)
                                    {
                                        Onair = "<span class=\"onair\">در حال پخش</span>";
                                        TrClass = "class=\"error\"";

                                    }

                                    if ((bool)ProgLst[0].ACTIVE)
                                    {
                                        Body.Append(" <tr " + TrClass + "><td class=\"item-time\"> <span class=\"time\">" + Bazaar.Core.Utility.ToTimeString(item.DATETIME) +
                                       "</span> </td><td> <a href=\"" + "program/" + ProgLst[0].ID + "/" + Bazaar.Core.Utility.ClearTitle(ProgLst[0].TITLE) + "\"  class=\"schedules-link\"><span class=\"photo\">");
                                    }
                                    else
                                    {
                                        Body.Append(" <tr " + TrClass + "><td class=\"item-time\"> <span class=\"time\">" + Bazaar.Core.Utility.ToTimeString(item.DATETIME) +
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


                                        // layoutString = layoutString.Replace("[IMG]", ThumbnailGenerator.Generate(Session.IMAGE, 300, 0));
                                        Body.Append("<img src=\"" + ThumbnailGenerator.Generate(Session.IMAGE, 100, 0) + "\" title=\"" + ProgLst[0].TITLE + "\" alt=\"" + ProgLst[0].TITLE + "\" />");
                                    }
                                    else
                                    {
                                        Body.Append("<img src=\"" + CreateImage(ProgLst[0], 100) + "\" title=\"" + ProgLst[0].TITLE + "\" alt=\"" + ProgLst[0].TITLE + "\" />");
                                    }
                                    Body.Append("</span><h3>" + ProgLst[0].TITLE + "<a href=\"/live\">" + Onair + "</a></h3> <p>" + item.DESCRIPTION + "</p></td>  </tr>");
                                }
                                else
                                {
                                    string Onair = "";
                                    string TrClass = "";
                                    if (item.ID == OnAirId)
                                    {
                                        Onair = "<span class=\"onair\">در حال پخش</span>";
                                        TrClass = "class=\"error\"";

                                    }

                                    Body.Append(" <tr " + TrClass + "><td class=\"item-time\"> <span class=\"time\">" + Bazaar.Core.Utility.ToTimeString(item.DATETIME) + "</span> </td><td><span class=\"photo\">");
                                    Body.Append("<img src=\"" + "/files/images/Bazaar.jpg" + "\" title=\"" + item.TITLE + "\" alt=\"" + item.TITLE + "\" />");
                                    Body.Append("</span><h3>" + item.TITLE + "<a href=\"/live\">" + Onair + "</a></h3><p>" + item.DESCRIPTION + "</p></td>  </tr>");
                                }


                            }
                            catch
                            {
                                string Onair = "";
                                string TrClass = "";
                                if (item.ID == OnAirId)
                                {
                                    Onair = "<span class=\"onair\">در حال پخش</span>";
                                    TrClass = "class=\"error\"";

                                }

                                Body.Append(" <tr " + TrClass + "><td class=\"item-time\"> <span class=\"time\">" + Bazaar.Core.Utility.ToTimeString(item.DATETIME) + "</span> </td><td><span class=\"photo\">");
                                Body.Append("<img src=\"" + "/files/images/Bazaar.jpg" + "\" title=\"" + item.TITLE + "\" alt=\"" + item.TITLE + "\" />");
                                Body.Append("</span><h3>" + item.TITLE + "<a href=\"/live\">" + Onair + "</a></h3></td>  </tr>");
                            }
                        }
                        else
                        {
                            string Onair = "";
                            string TrClass = "";
                            if (item.ID == OnAirId)
                            {
                                Onair = "<span class=\"onair\">در حال پخش</span>";
                                TrClass = "class=\"error\"";

                            }

                            Body.Append(" <tr " + TrClass + "><td class=\"item-time\"> <span class=\"time\">" + Bazaar.Core.Utility.ToTimeString(item.DATETIME) + "</span> </td><td><span class=\"photo\">");
                            Body.Append("<img src=\"" + "/files/images/Bazaar.jpg" + "\" title=\"" + item.TITLE + "\" alt=\"" + item.TITLE + "\" />");
                            Body.Append("</span><h3>" + item.TITLE + "<a href=\"/live\">" + Onair + "</a></h3></td>  </tr>");
                        }
                    }

                    Body.Append(" </tbody> </table>");
                }
                Body.Append("</div>");
            } 
            #endregion
            sb.Append(DaysLinkString);
            sb.Append("</ul>");
            sb.Append(Body.ToString());
            sb.Append(" </div>");
            sb.Append(" </div>");

            ltSchedules.Text = sb.ToString();
        }
      
        private string CreateImage(BusinessLayer.PROGRAMS ProgItem, int ImageSize)
        {

            return ThumbnailGenerator.Generate(ProgItem.IMAGE, ImageSize, 0);

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

        private string[] LayoutStrings(string layout)
        {
            string layoutString = layout;
            string[] result = new string[3];
            int repeatStartIndex = layoutString.IndexOf("<%");
            int repeatStopIndex = layoutString.IndexOf("%>");
            result[0] = layoutString.Substring(0, repeatStartIndex);
            result[1] = layoutString.Substring(repeatStartIndex, repeatStopIndex - repeatStartIndex).Replace("<%", "");
            result[2] = layoutString.Substring(repeatStopIndex).Replace("%>", "");

            return result;
        }

        public string Template { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
    }
}