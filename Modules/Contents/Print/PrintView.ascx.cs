using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Contents.Print
{
    public partial class PrintView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLayer.CONTENTS Cont_Item = new BusinessLayer.CONTENTS();

            BusinessLayer.DataLayer.CONTENTSSql Con_Sql = new BusinessLayer.DataLayer.CONTENTSSql();

            Cont_Item = Con_Sql.SelectByPrimaryKey(new BusinessLayer.CONTENTSKeys(int.Parse(Page.RouteData.Values["NewsID"].ToString())));


            Page.Title += "شبکه تلویزیونی بازار" + " :: " + Cont_Item.TITLE+" نسخه چاپی ";

            string Content_Layout = "";

            Content_Layout = ReadFile(Server.MapPath("~/Modules/contents/print/Templates/template1/main.html"));
            Content_Layout = Content_Layout.Replace("[LEAD]", (String.IsNullOrEmpty(Cont_Item.LEAD) ? "" : ("<span class=\"lead\">" + Cont_Item.LEAD + "</span>")));
            Content_Layout = Content_Layout.Replace("[TITLE]", Cont_Item.TITLE);
            Content_Layout = Content_Layout.Replace("[DESCRIPTION]", Cont_Item.DESCRIPTION);
            Content_Layout = Content_Layout.Replace("[DATE]", Bazaar.Core.Utility.GD2StringDateTime(Cont_Item.DATETIME_CREATE));
            Content_Layout = Content_Layout.Replace("[BODY]", Cont_Item.BODY);
            Content_Layout = Content_Layout.Replace("[LINK]", "/news/" + Cont_Item.ID + "/" + Cont_Item.TITLE.Trim().Replace(" ", "-"));




            //Load Images



            BusinessLayer.DataLayer.CONTENT_FILESSql Content_File_Sql = new BusinessLayer.DataLayer.CONTENT_FILESSql();

            List<BusinessLayer.CONTENT_FILES> Files_Lst = Content_File_Sql.SelectBy_NewsId_FileType(Cont_Item.ID, 1);

            if (Files_Lst.Count > 0)
            {
                if (Content_Layout.Contains("[IMAGE]"))
                    Content_Layout = Content_Layout.Replace("[IMAGE]", ThumbnailGenerator.Generate(Files_Lst[0].PATH, 610, 0));
            }
            if (Files_Lst.Count == 0)
            {
                Content_Layout = Content_Layout.Replace("[VISIBLEITEM]", " hide ");

            }
            else
            {
                Content_Layout = Content_Layout.Replace("[VISIBLEITEM]", "  ");
            }


          


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

        //private string CreateImage(BusinessLayer.CONTENTS CONTENTSItem, int ImageSize)
        //{
        //    BusinessLayer.DataLayer.CONTENT_FILESSql Content_File_Sql = new BusinessLayer.DataLayer.CONTENT_FILESSql();

        //    List<BusinessLayer.CONTENT_FILES> Files_Lst = Content_File_Sql.SelectBy_NewsId_FileType(CONTENTSItem.ID, 1);

        //    for (int i = 0; i < Files_Lst.Count; i++)
        //    {



        //        return ThumbnailGenerator.Generate(Files_Lst[0].PATH, 610, 0);
        //    }

        //}

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
    }
}