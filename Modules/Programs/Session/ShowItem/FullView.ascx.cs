using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Programs.Session.ShowItem
{
    public partial class FullView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLayer.PROGRAMS Cont_Item = new BusinessLayer.PROGRAMS();

            BusinessLayer.DataLayer.PROGRAMSSql Con_Sql = new BusinessLayer.DataLayer.PROGRAMSSql();

            Cont_Item = Con_Sql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(int.Parse(Page.RouteData.Values["ProgramID"].ToString())));


            BusinessLayer.PROGRAM_SESSIONS Session_Item = new BusinessLayer.PROGRAM_SESSIONS();

            BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();

            Session_Item = SessionSql.SelectByPrimaryKey(new BusinessLayer.PROGRAM_SESSIONSKeys(int.Parse(Page.RouteData.Values["SessionNumber"].ToString())));


            Page.Title += "شبکه تلویزیونی بازار" + " :: " + Cont_Item.TITLE+" :: "+Session_Item.TITLE;

            string Content_Layout = "";

            Content_Layout = ReadFile(Server.MapPath("~/Modules/programs/Session/ShowItem/Templates/" + Template + "/main.html"));
           // string[] ImagesString = LayoutStrings(Content_Layout);

           // ImagesString[0] = ImagesString[0].Replace("[LEAD]", (String.IsNullOrEmpty(Cont_Item.DESCRIPTION) ? "" : ("<span class=\"lead\">" + Cont_Item.DESCRIPTION + "</span>")));
            Content_Layout = Content_Layout.Replace("[TITLE]", Cont_Item.TITLE + " - " + Session_Item.TITLE);
            Content_Layout = Content_Layout.Replace("[DESCRIPTION]", "قسمت " + Session_Item.NUMBER);
            Content_Layout = Content_Layout.Replace("[DATE]", Bazaar.Core.Utility.GD2StringDateTime((DateTime)Session_Item.DATETIME));
            Content_Layout = Content_Layout.Replace("[BODY]", Session_Item.BODY);
         //   ImagesString[0] = ImagesString[0].Replace("[ROLES]", Session_Item.);
            if (Cont_Item.IMAGE.Length > 5)
            {
                Content_Layout = Content_Layout.Replace("[IMAGETOP]", ThumbnailGenerator.Generate(Session_Item.IMAGE, 300, 0));
                Content_Layout = Content_Layout.Replace("[VISIBLEITEM]", "  ");
            }
            else
            {
                Content_Layout = Content_Layout.Replace("[VISIBLEITEM]", " hide  ");
            }
            Content_Layout = Content_Layout.Replace("[Video]", "/Files/Video/"+Session_Item.VIDEO);
            Content_Layout = Content_Layout.Replace("[DOWNLOAD]", "<a   href=\"" + "/Files/Video/" + Session_Item.VIDEO + "\" target=\"_blank\" class=\" icon-videocam btn btn-success pull-left\" > دانلود ویدیو </a>");






            ltNewsList.Text = Content_Layout;

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
        private string[] LayoutStringsEnd(string layout)
        {
            string layoutString = layout;
            string[] result = new string[3];
            int repeatStartIndex = layoutString.IndexOf("#!");
            int repeatStopIndex = layoutString.IndexOf("!#");
            result[0] = layoutString.Substring(0, repeatStartIndex);
            result[1] = layoutString.Substring(repeatStartIndex, repeatStopIndex - repeatStartIndex).Replace("#!", " ");
            result[2] = layoutString.Substring(repeatStopIndex).Replace("!#", " ");

            return result;
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

        public string Template { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
    }
}