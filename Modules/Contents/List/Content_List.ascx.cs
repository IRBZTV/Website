using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using Bazaar.Core;

namespace Bazaar.Modules.Contents.List
{
    public partial class Content_List : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {

            BusinessLayer.DataLayer.CONTENTSSql Content_Sql = new BusinessLayer.DataLayer.CONTENTSSql();

            //Select from Db
            List<BusinessLayer.CONTENTS> Contents_Lst = Content_Sql.SelectByCondition(Count, CategoryId);

            //Load Template

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
                    if (Contents_Lst.Count > 0)
                    {
                        Container = Container.Replace("[TIME]", Bazaar.Core.Utility.GD2StringDateTime(Contents_Lst[0].DATETIME_CREATE));
                    }
                    else
                    {

                    }
                    break;

                case "None":
                    Container = "";
                    break;


                case "Line":
                    Container = ReadFile(Server.MapPath("~/Core/ContainerTemplates/Title.html"));
                    Container = Container.Replace("[MODULETITILE]", "");
                    ltNewsList.Text = Container;
                    break;


                default:
                    Container = "";
                    break;
            }
            ltNewsList.Text = Container;



            string Content_Layout = "";

            Content_Layout = ReadFile(Server.MapPath("~/Modules/contents/list/Templates/" + Template + "/main.html"));


            StringBuilder sb = new StringBuilder();






            string[] layoutStrings = LayoutStrings(Content_Layout);




            string[] ContentTop = LayoutStringsTop(Content_Layout);

            if (Contents_Lst.Count > 0)
            {
                Random Rdm = new Random();
                ContentTop[1] = ContentTop[1].Replace("[ID]", Rdm.Next().ToString());
                ContentTop[1] = ContentTop[1].Replace("[TITLE]", Contents_Lst[0].TITLE);
                ContentTop[1] = ContentTop[1].Replace("[DESCRIPTION]", Contents_Lst[0].DESCRIPTION);
                ContentTop[1] = ContentTop[1].Replace("[LINK]", "/news/" + Contents_Lst[0].ID + "/" + Bazaar.Core.Utility.ClearTitle(Contents_Lst[0].TITLE));


                BusinessLayer.DataLayer.CONTENT_FILESSql Content_File_Sql = new BusinessLayer.DataLayer.CONTENT_FILESSql();

                List<BusinessLayer.CONTENT_FILES> Files_Lst = Content_File_Sql.SelectBy_NewsId_FileType(Contents_Lst[0].ID, 1);

                if (Files_Lst.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Files_Lst[0].PATH))
                    {
                        int Rdm2 = 0;
                        Random Rdmnum = new Random();
                        Rdm2 = Rdmnum.Next(0, Files_Lst.Count);


                        ContentTop[1] = ContentTop[1].Replace("[IMAGE]", ThumbnailGenerator.Generate(Files_Lst[Rdm2].PATH, 610, 0));


                    }
                    else
                    {
                        ContentTop[1] = ContentTop[1].Replace("[IMAGE]", "/files/images/Bazaar.jpg");
                    }
                }
                else
                {
                    ContentTop[1] = ContentTop[1].Replace("[IMAGE]", "/files/images/Bazaar.jpg");
                }




                ContentTop[1] = ContentTop[1].Replace("[DATE]", Bazaar.Core.Utility.GD2StringDateTime(Contents_Lst[0].DATETIME_CREATE));
                sb.Append(ContentTop[1].ToString());
            }

            if (Template == "NewsPage")
            {
                for (int i = 1; i < Contents_Lst.Count; ++i)
                {

                    sb.Append(BuildNews(Contents_Lst[i], layoutStrings[1], ImageWidth, -1));

                }


                //layoutStrings[2] = layoutStrings[2].Replace("[MOREBTN]",
                //    "<div class=\"pull-left\"> <button class=\"btn-info\" id=\"content-more-newspage\"  catid=\"" + CategoryId + "\" tmpl=\"" + Template + "\" type=\"submit\">بیشتر</button> </div>  <div class=\"clearfix\"></div>");
                layoutStrings[2] = layoutStrings[2].Replace("[MOREBTN]",
                                      " <a class=\"schedules-link pull-left handmouse\" id=\"content-more-newspage\"  catid=\"" + CategoryId + "\" tmpl=\"" + Template + "\" type=\"submit\"><div class=\"clearfix\"></div>بیشتر<span class=\"icon-left-open-1\"></span></a><div class=\"clearfix\">");
            }
            else
            {
                for (int i = 0; i < Contents_Lst.Count; ++i)
                {

                    sb.Append(BuildNews(Contents_Lst[i], layoutStrings[1], ImageWidth, -1));

                }
                if (Template == "StoryList")
                {
                    //layoutStrings[2] = layoutStrings[2].Replace("[MOREBTN]",
                    //    "<div class=\"pull-left\"> <button class=\"btn-info\" id=\"content-more-list\"  catid=\"" + CategoryId + "\" tmpl=\"" + Template + "\" type=\"submit\">بیشتر</button> </div> <div class=\"clearfix\"></div>");

                    layoutStrings[2] = layoutStrings[2].Replace("[MOREBTN]",
                        " <a class=\"schedules-link pull-left handmouse\" id=\"content-more-list\"  catid=\"" + CategoryId + "\" tmpl=\"" + Template + "\" type=\"submit\"><div class=\"clearfix\"></div>بیشتر<span class=\"icon-left-open-1\"></span></a><div class=\"clearfix\">");
                   
                }
            }

            sb.Append(layoutStrings[2]);

            ltNewsList.Text += sb.ToString();

        }
        private string BuildNews(BusinessLayer.CONTENTS CONTENTSItem, string layoutString, int thumbWidth, int imageIndex)
        {
            layoutString = layoutString.Replace("[LEAD]", (String.IsNullOrEmpty(CONTENTSItem.LEAD) ? "" : ("<span class=\"lead\">" + CONTENTSItem.LEAD + "</span>")));
            layoutString = layoutString.Replace("[TITLE]", CONTENTSItem.TITLE);
            layoutString = layoutString.Replace("[DESCRIPTION]", CONTENTSItem.DESCRIPTION);
            layoutString = layoutString.Replace("[DATE]", Bazaar.Core.Utility.GD2StringDateTime(CONTENTSItem.DATETIME_CREATE));
            layoutString = layoutString.Replace("[LINK]", "/news/" + CONTENTSItem.ID + "/" + Bazaar.Core.Utility.ClearTitle(CONTENTSItem.TITLE));

            BusinessLayer.DataLayer.CONTENT_FILESSql Content_File_Sql = new BusinessLayer.DataLayer.CONTENT_FILESSql();

            List<BusinessLayer.CONTENT_FILES> Files_Lst = Content_File_Sql.SelectBy_NewsId_FileType(CONTENTSItem.ID, 1);

            if (Files_Lst.Count > 0)
            {
                if (!string.IsNullOrEmpty(Files_Lst[0].PATH))
                {
                    int Rdm = 0;
                    Random Rdmnum = new Random();
                    Rdm = Rdmnum.Next(0, Files_Lst.Count);

                    if (layoutString.Contains("[IMAGE]"))
                        layoutString = layoutString.Replace("[IMAGE]", ThumbnailGenerator.Generate(Files_Lst[Rdm].PATH, 140, 0));


                    if (layoutString.Contains("[IMAGESOURCE]"))
                        layoutString = layoutString.Replace("[IMAGESOURCE]", ThumbnailGenerator.Generate(Files_Lst[Rdm].PATH, 610, 0));
                }
                else
                {
                    layoutString = layoutString.Replace("[IMAGE]", "/files/images/Bazaar.jpg");
                }
            }
            else
            {
                layoutString = layoutString.Replace("[IMAGE]", "/files/images/Bazaar.jpg");
            }



            return layoutString;
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

        public int CategoryId { get; set; }
        public string Template { get; set; }
        public int Count { get; set; }
        public string Layout { get; set; }
        public int ImageWidth { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }

    }
}