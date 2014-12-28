using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Gallery.TopViewer
{
    public partial class TopViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
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



            string SelectCondition = " where active=1 and homepage=1  order by datetime desc ";

            List<Bazaar.BusinessLayer.ALBUMS> AlbumLst = new List<BusinessLayer.ALBUMS>();
            Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumSql = new BusinessLayer.DataLayer.ALBUMSSql();
            AlbumLst = AlbumSql.SelectTopActive(SelectCondition, Count.ToString());

            //Load Template

            string Content_Layout = "";

            Content_Layout = ReadFile(Server.MapPath("~/Modules/Gallery/TopViewer/Templates/" + Template + "/main.html"));

            StringBuilder sb = new StringBuilder();


            string[] layoutStrings = LayoutStrings(Content_Layout);
            sb.Append(layoutStrings[0]);

            foreach (Bazaar.BusinessLayer.ALBUMS item in AlbumLst)
            {
                sb.Append(BuildGallery(item, layoutStrings[1], ImageWidth, Vertical));
            }

            sb.Append(layoutStrings[2]);
            ltTopViewGallery.Text = sb.ToString();
        }

        private string BuildGallery(Bazaar.BusinessLayer.ALBUMS Item, string layoutString, int thumbWidth, bool Even)
        {

            List<Bazaar.BusinessLayer.ALBUM_PHOTOS> PhotoLst = new List<BusinessLayer.ALBUM_PHOTOS>();
            Bazaar.BusinessLayer.DataLayer.ALBUM_PHOTOSSql PhotoSql = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();
            PhotoLst = PhotoSql.SelectByField("ALBUM_ID", Item.ID);
            layoutString = layoutString.Replace("[DESC]", Item.DESCRIPTION);
            layoutString = layoutString.Replace("[TITLE]", Item.TITLE);
            layoutString = layoutString.Replace("[LINK]", "/Gallery/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE));

            layoutString = layoutString.Replace("[IMGALT]", Item.TITLE);

            layoutString = layoutString.Replace("[COUNT]", PhotoLst.Count.ToString());

            if (PhotoLst.Count > 0)
            {

                if (layoutString.Contains("[IMGSRC]"))
                {
                    Random Rdm = new Random();
                    int indx = Rdm.Next(0, PhotoLst.Count - 1);
                    layoutString = layoutString.Replace("[IMGSRC]", ThumbnailGenerator.Generate(PhotoLst[indx].PATH, thumbWidth, 0));
                }
            }

            if (Even)
            {
                layoutString = layoutString.Replace("[CLASS]", "even");
            }
            else
            {
                layoutString = layoutString.Replace("[CLASS]", "odd");
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

        public int Count { get; set; }
        public string Template { get; set; }
        public int ImageWidth { get; set; }
        public bool Vertical { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
    }

}