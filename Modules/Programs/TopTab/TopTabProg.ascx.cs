using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Programs.TopTab
{
    public partial class TopTabProg : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string SelectCondition = " where active=1 and kind=" + ProgKind + "  order by priority desc ";

            List<Bazaar.BusinessLayer.PROGRAMS> ProgLst = new List<BusinessLayer.PROGRAMS>();
            Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
            ProgLst = ProgSql.SelectByConditionTop(SelectCondition, Count);

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

            //Load Template

            StringBuilder sb = new StringBuilder();
            sb.Append("<div id='schedules-page'>");

            string DaysLinkString = "";

            DaysLinkString += " <ul class='nav nav-tabs schedule-tab' id='schedule-tabs'>";
            StringBuilder Body = new StringBuilder();

            sb.Append(" <div class='tab-content schedule-tab-content'>");


            //Random Rdm = new Random();
            //int Indx = Rdm.Next(0, ProgLst.Count);
            bool First = true;
            for (int i = 0; i < ProgLst.Count; i++)
            {
                Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> SessionsList = SessionSql.SelectByProgIDTop(ProgLst[i].ID, 200, "Play_DATETIME");
                if (SessionsList.Count > 0)
                {
                    string ProgLiId = "Progtb-" + ProgLst[i].ID;

                    string ActiveClass = "";
                    if (First)
                    {
                        ActiveClass = " active";
                        First = false;
                    }


                    DaysLinkString += "<li class=\"" + ActiveClass + "\" ><a href=\"#" + ProgLiId + "\"><span class=\"day\">" + ProgLst[i].TITLE + "</span></a></li>";
                    Body.Append("<div class=\"tab-pane  " + ActiveClass + " \" id=\"" + ProgLiId + "\">   <table class=\"table table-hover table-condensed\"><tbody>");

                    string Onair = "";
                    string TrClass = "";





                    Body.Append(" <tr " + TrClass + "><td>  <div class=\"introtext\">" + ProgLst[i].DESCRIPTION + "</div></td></tr>");
                    //   Body.Append("<img src=\"" + ThumbnailGenerator.Generate(ProgLst[i].IMAGE, 100, 0) + "\" title=\"" + Utility.GD2StringDateTime((DateTime)ProgLst[i].Datetime) + "\" alt=\"" + ProgLst[i].TITLE + "\" />");

                    //   Body.Append("</span><h3>" + ProgLst[i].TITLE + "<a href=\"/live\">" + Onair + "</a></h3></td>  </tr>");


                    if (SessionsList.Count > 0)
                    {
                        foreach (var item in SessionsList)
                        {
                            Body.Append(" <tr " + TrClass + "><td> <a href=\"" +"/program/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE) + "/sessionlist/" + "\"  class=\"schedules-link\"><span class=\"photo\">");
                            Body.Append("<img src=\"" + ThumbnailGenerator.Generate(item.IMAGE, 100, 0) + "\" title=\"" + Utility.GD2StringDateTime((DateTime)item.DATETIME) + "\" alt=\"" + item.TITLE + "\" />");

                            Body.Append("</span><h3>" + item.TITLE + "-" + Utility.GD2StringDate((DateTime)item.Play_DATETIME) + "<a href=\"/live\">" + Onair + "</a></h3></td>  </tr>");
                        }

                    }
                    else
                    {
                        Body.Append(" <tr " + TrClass + "><td><h3>" + "رکوردی برای نمایش وجود ندارد" + "</h3></td>  </tr>");
                    }
                    Body.Append(" </tbody>            </table>        </div>");

                }
            }

            sb.Append(DaysLinkString);
            sb.Append("</ul>");
            sb.Append(Body.ToString());
            sb.Append(" </div>");
            sb.Append(" </div>");


            Literal1.Text = sb.ToString();
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
        private string[] LayoutStringsTop(string layout)
        {
            string layoutString = layout;
            string[] result = new string[3];
            int repeatStartIndex = layoutString.IndexOf("@!");
            int repeatStopIndex = layoutString.IndexOf("!@");
            result[0] = layoutString.Substring(0, repeatStartIndex);
            result[1] = layoutString.Substring(repeatStartIndex, repeatStopIndex - repeatStartIndex).Replace("@!", " ");
            result[2] = layoutString.Substring(repeatStopIndex).Replace("!@", " ");

            return result;
        }
        public int Count { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
        public int ProgKind { get; set; }
    }


}
