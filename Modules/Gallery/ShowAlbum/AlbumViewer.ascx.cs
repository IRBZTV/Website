using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Gallery.ShowAlbum
{
    public partial class AlbumViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLayer.ALBUMS Album_Item = new BusinessLayer.ALBUMS();

            BusinessLayer.DataLayer.ALBUMSSql Album_Sql = new BusinessLayer.DataLayer.ALBUMSSql();

            Album_Item = Album_Sql.SelectByPrimaryKey(new BusinessLayer.ALBUMSKeys(int.Parse(Page.RouteData.Values["GalleryID"].ToString())));


            if ((bool)Album_Item.ACTIVE)
            {

                // Page.Title += " :: "+Cont_Item.TITLE;

                string Content_Layout = "";

                Content_Layout = ReadFile(Server.MapPath("~/Modules/Gallery/ShowAlbum/Templates/" + Template + "/main.html"));
                string[] ImagesString = LayoutStrings(Content_Layout);


                ImagesString[0] = ImagesString[0].Replace("[TITLE]", Album_Item.TITLE);
                ImagesString[0] = ImagesString[0].Replace("[DESCRIPTION]", Album_Item.DESCRIPTION);
                ImagesString[0] = ImagesString[0].Replace("[DATE]", Bazaar.Core.Utility.GD2StringDateTime((DateTime)Album_Item.DATETIME));


                ImagesString[0] = ImagesString[0].Replace("[LINK]", "news/" + Album_Item.ID + "/" + Album_Item.TITLE.Trim().Replace(" ", "-"));




                //Load Images



                BusinessLayer.DataLayer.ALBUM_PHOTOSSql ALBUM_PHOTOS_Sql = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();

                List<BusinessLayer.ALBUM_PHOTOS> Photos_Lst = ALBUM_PHOTOS_Sql.SelectByField("ALBUM_ID", Album_Item.ID.ToString());

                if (Photos_Lst.Count > 0)
                {
                    if (ImagesString[0].Contains("[IMAGE]"))
                        ImagesString[0] = ImagesString[0].Replace("[IMAGE]", ThumbnailGenerator.Generate(Photos_Lst[0].PATH, 610, 0));
                }


                string Images = "";

                for (int i = 0; i < Photos_Lst.Count; i++)
                {
                    Images += ImagesString[1].Replace("[IMAGE]", ThumbnailGenerator.Generate(Photos_Lst[i].PATH, 610, 0)).Replace("[TITLE]", Album_Item.TITLE);
                 
                    if (i == 0)
                    {
                        Images = Images.Replace("[THUMBCLASS]", " class='active'  ");

                        if (ImagesString[0].Contains("[IMAGE2]"))
                            ImagesString[0] = ImagesString[0].Replace("[IMAGE2]", ThumbnailGenerator.Generate(Photos_Lst[i].PATH, 610, 0));
                    }
                    Images = Images.Replace("[THUMBCLASS]", "    ");

                }


                ltAlbum.Text = ImagesString[0] + Images + ImagesString[2];
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