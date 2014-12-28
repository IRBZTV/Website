using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Contents.FullView
{
    public partial class FullView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BusinessLayer.CONTENTS Cont_Item = new BusinessLayer.CONTENTS();

                BusinessLayer.DataLayer.CONTENTSSql Con_Sql = new BusinessLayer.DataLayer.CONTENTSSql();

                Cont_Item = Con_Sql.SelectByPrimaryKey(new BusinessLayer.CONTENTSKeys(int.Parse(Page.RouteData.Values["NewsID"].ToString())));

                try
                {
                    Cont_Item.VIEWCOUNT += 1;
                }
                catch
                {

                    Cont_Item.VIEWCOUNT = 0;
                    Cont_Item.VIEWCOUNT += 1;
                }
                Con_Sql.Update(Cont_Item);


                 Page.Title += "شبکه تلویزیونی بازار" + " :: " + Cont_Item.TITLE;
               // Page.Title += " * " + Page.Title + "&" + Cont_Item.VIEWCOUNT;
                string Content_Layout = "";

                Content_Layout = ReadFile(Server.MapPath("~/Modules/contents/fullview/Templates/" + Template + "/main.html"));
                string[] ImagesString = LayoutStrings(Content_Layout);

                ImagesString[0] = ImagesString[0].Replace("[LEAD]", (String.IsNullOrEmpty(Cont_Item.LEAD) ? "" : ("<span class=\"lead\">" + Cont_Item.LEAD + "</span>")));
                ImagesString[0] = ImagesString[0].Replace("[TITLE]", Cont_Item.TITLE);
                ImagesString[0] = ImagesString[0].Replace("[VISIT]", "تعداد بازدید:" + Math.Floor(double.Parse((Cont_Item.VIEWCOUNT/2).ToString())));
                ImagesString[0] = ImagesString[0].Replace("[DESCRIPTION]", Cont_Item.DESCRIPTION);
                ImagesString[0] = ImagesString[0].Replace("[DATE]", Bazaar.Core.Utility.GD2StringDateTime(Cont_Item.DATETIME_CREATE));
                ImagesString[0] = ImagesString[0].Replace("[BODY]", Cont_Item.BODY);
                ImagesString[0] = ImagesString[0].Replace("[LINK]", "/news/" + Cont_Item.ID + "/" + Cont_Item.TITLE.Trim().Replace(" ", "-"));
                ImagesString[0] = ImagesString[0].Replace("[PRINTURL]", "/newsprint/" + Cont_Item.ID);
                ImagesString[0] = ImagesString[0].Replace("[MAILURL]", "/newsmail/" + Cont_Item.ID);




                //Load Images



                BusinessLayer.DataLayer.CONTENT_FILESSql Content_File_Sql = new BusinessLayer.DataLayer.CONTENT_FILESSql();

                List<BusinessLayer.CONTENT_FILES> Files_Lst = Content_File_Sql.SelectBy_NewsId_FileType(Cont_Item.ID, 1);

                if (Files_Lst.Count > 0)
                {
                    if (ImagesString[0].Contains("[IMAGE]"))
                        ImagesString[0] = ImagesString[0].Replace("[IMAGE]", ThumbnailGenerator.Generate(Files_Lst[0].PATH, 610, 0));
                }


                string Images = "";

                for (int i = 0; i < Files_Lst.Count; i++)
                {
                    Images += ImagesString[1].Replace("[IMAGE]", ThumbnailGenerator.Generate(Files_Lst[i].PATH, 610, 0)).Replace("[TITLE]", Cont_Item.TITLE);

                    if (i == 0)
                    {
                        Images = Images.Replace("[THUMBCLASS]", " class='active'  ");

                        if (ImagesString[0].Contains("[IMAGE2]"))
                            ImagesString[0] = ImagesString[0].Replace("[IMAGE2]", ThumbnailGenerator.Generate(Files_Lst[i].PATH, 610, 0));
                    }
                    Images = Images.Replace("[THUMBCLASS]", "    ");
                }
                if (Files_Lst.Count <= 1)
                {
                    ImagesString[0] = ImagesString[0].Replace("[VISIBLEITEMGALLERY]", " hide ");

                }
                else
                {
                    ImagesString[0] = ImagesString[0].Replace("[VISIBLEITEMGALLERY]", "  ");
                }


                if (Files_Lst.Count == 0)
                {
                    ImagesString[0] = ImagesString[0].Replace("[VISIBLEITEM]", " hide ");

                }
                else
                {
                    ImagesString[0] = ImagesString[0].Replace("[VISIBLEITEM]", "  ");
                }


                ltNewsList.Text = ImagesString[0] + Images + ImagesString[2];

            }
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

        public string Template { get; set; }
    }
}