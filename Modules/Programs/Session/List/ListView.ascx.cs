using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Programs.Session.List
{
    public partial class ListView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

              Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
              List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> SessionsList = SessionSql.SelectByProgIDTop(int.Parse(Page.RouteData.Values["ProgramID"].ToString()), 200, "PLAY_DATETIME");
            BusinessLayer.DataLayer.PROGRAMSSql Con_Sql = new BusinessLayer.DataLayer.PROGRAMSSql();
            BusinessLayer.PROGRAMS Prog_Item = Con_Sql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(int.Parse(Page.RouteData.Values["ProgramID"].ToString())));
            Page.Title += "شبکه تلویزیونی بازار" + " :: " + Prog_Item.TITLE + " :: " + "لیست کامل قسمت ها";

            string Container = "";
            switch (Container_Layout)
            {
                case "Title":
                    Container = ReadFile(Server.MapPath("~/Core/ContainerTemplates/" + Container_Layout + ".html"));
                    Container = Container.Replace("[MODULETITILE]", "<a href=\"/program/" + Prog_Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Prog_Item.TITLE) + "\" target=\"_blank\" >" + Prog_Item.TITLE + " </a> - " + ModuleTitle);
                    break;

                case "TitleTime":
                    Container = ReadFile(Server.MapPath("~/Core/ContainerTemplates/" + Container_Layout + ".html"));
                    Container = Container.Replace("[MODULETITILE]", "<a href=\"/program/" + Prog_Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Prog_Item.TITLE) + "\" target=\"_blank\" >" + Prog_Item.TITLE + "</a> - " + ModuleTitle);
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

          

            StringBuilder Body = new StringBuilder();
      
            Body.Append("<div id='schedules-page'>");
            Body.Append("<table class=\"table table-hover table-condensed\"><tbody>");
          
            foreach (Bazaar.BusinessLayer.PROGRAM_SESSIONS item in SessionsList)
            {
             
                string PageAdr= "/program/" + Prog_Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Prog_Item.TITLE) + "/session/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE);
                string No = "--";
                if (item.NUMBER != 1000)
                    No = item.NUMBER.ToString();

                Body.Append(" <tr class=\"hastip\" title=\"تاریخ پخش: "+Utility.GD2StringDate((DateTime)item.Play_DATETIME)+"\"><td class=\"item-time\"> <span class=\"time\">" +No+ "</span> </td><td><span class=\"photo\">");
                Body.Append("<img src=\"" + ThumbnailGenerator.Generate(item.IMAGE, 100, 0) + "\" title=\"" + item.TITLE + "\" alt=\"" + item.TITLE + "\" />");
                Body.Append("</span><h3><a target=\"_blank\" href=\""+PageAdr+"\">" + item.TITLE + "</a></h3></td>  </tr>");


            }

                Body.Append(" </tbody>            </table>        </div>");

                ltSchedules.Text = Body.ToString();
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