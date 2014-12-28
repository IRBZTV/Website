using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Gallery.Albums
{
    public partial class AlbumsList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string SelectCondition = " where active=1   order by datetime desc ";

            List<Bazaar.BusinessLayer.ALBUMS> AlbumLst = new List<BusinessLayer.ALBUMS>();
            Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumSql = new BusinessLayer.DataLayer.ALBUMSSql();
            AlbumLst = AlbumSql.SelectTopActive(SelectCondition, "100");

            StringBuilder sb = new StringBuilder();



            string featured = "<div class=\"featured\">  <div class=\"image-holder\">   <a href=\"[LINK]\"> <img src=\"[IMGSRC]\"  alt=\"[IMGALT]\" />   </a>    </div>        <h2><a href=\"[LINK]\">[TITLE]</a></h2>        <div class=\"introtext\">            [DESC]	        </div>        <div class=\"clearfix\"></div>    </div>";

            string Cols = "  <div class=\"item [CLASS]\">            <div class=\"image-holder\">                <a href=\"[LINK]\">                    <img src=\"[IMGSRC]\" alt=\"[IMGALT]\" />                </a>            </div>            <h3><a href=\"[LINK]\">[TITLE]</a></h3>        </div>";
            string ThreeCols = " <div class=\"item [CLASS]\">        <div class=\"image-holder\">             <a href=\"[LINK]\">                    <img src=\"[IMGSRC]\"  alt=\"[IMGALT]\" />                </a>        </div>            <h3><a href=\"[LINK]\">[TITLE]</a></h3>    </div>            ";




            for (int i = 0; i < AlbumLst.Count; i++)
            {
                if (i == 0)
                {
                    sb.Append(BuildGallery(AlbumLst[i], featured, 600, ""));
                }

                if (i > 0 && i < 5)
                {
                    sb.Append("<div class=\"cols\">");
                    for (int j = 1; j < 5; j++)
                    {
                        if (i < AlbumLst.Count)
                        {
                            int a = i % 2;
                            if (a == 0)
                            {
                                sb.Append(BuildGallery(AlbumLst[i], Cols, 292, " even "));

                            }
                            else
                            {
                                sb.Append(BuildGallery(AlbumLst[i], Cols, 292, " odd "));
                            }
                        }
                        i++;
                    }
                    sb.Append("<div class=\"clearfix\"></div>");
                    sb.Append("</div>");
                }


                if (i > 5 && i < 51)
                {
                    sb.Append("<div class=\"cols-three\">");

                    for (int p = 5; p < 51; p++)
                    {
                        if (i < AlbumLst.Count)
                        {
                            int a = i % 3;
                            if (a == 0)
                            {
                                sb.Append("<div class=\"clearfix\"></div>");
                                sb.Append(BuildGallery(AlbumLst[i], ThreeCols, 187, "col-1"));
                            }
                            if (a == 1)
                            {
                                sb.Append(BuildGallery(AlbumLst[i], ThreeCols, 187, "col-2"));
                            }
                            if (a == 2)
                            {
                                sb.Append(BuildGallery(AlbumLst[i], ThreeCols, 187, "col-3"));
                            }
                        }

                        i++;
                    }
                    sb.Append("</div>");

                }
            }
            ltrAlbums.Text = sb.ToString();
        }
        private string BuildGallery(Bazaar.BusinessLayer.ALBUMS Item, string layoutString, int thumbWidth, string Class)
        {
            List<Bazaar.BusinessLayer.ALBUM_PHOTOS> PhotoLst = new List<BusinessLayer.ALBUM_PHOTOS>();
            Bazaar.BusinessLayer.DataLayer.ALBUM_PHOTOSSql PhotoSql = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();
            PhotoLst = PhotoSql.SelectByField("ALBUM_ID", Item.ID);
            layoutString = layoutString.Replace("[DESC]", Item.DESCRIPTION);
            layoutString = layoutString.Replace("[TITLE]", Item.TITLE);
            layoutString = layoutString.Replace("[LINK]", "Gallery/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE));

            layoutString = layoutString.Replace("[IMGALT]", Item.TITLE);

            layoutString = layoutString.Replace("[COUNT]", PhotoLst.Count.ToString());

            if (PhotoLst.Count > 0)
            {
                Random Rdm = new Random();
                int indx = Rdm.Next(0, PhotoLst.Count - 1);
                layoutString = layoutString.Replace("[IMGSRC]", ThumbnailGenerator.Generate(PhotoLst[indx].PATH, thumbWidth, 0));

            }


            layoutString = layoutString.Replace("[CLASS]", Class);

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
    }

}