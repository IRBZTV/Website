using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Bazaar.Pages
{
    public partial class GalleryFeedGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/rss+xml";
            XmlTextWriter objX = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
            objX.WriteStartDocument();
            objX.WriteStartElement("rss");
            objX.WriteAttributeString("version", "2.0");
            objX.WriteStartElement("channel");


            string SelectCondition = " where active=1   order by datetime desc ";
            List<Bazaar.BusinessLayer.ALBUMS> AlbumLst = new List<BusinessLayer.ALBUMS>();
            Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumSql = new BusinessLayer.DataLayer.ALBUMSSql();
            AlbumLst = AlbumSql.SelectTopActive(SelectCondition, "100");

            objX.WriteElementString("title", "گالری تصاویر شبکه بازار");
            objX.WriteElementString("link", "http://www.bazaartv.ir/");
            objX.WriteElementString("description", "شبکه تلویزیونی بازار");
            objX.WriteElementString("language", "en-us");
            objX.WriteElementString("ttl", "60");
            objX.WriteElementString("image", "http://www.bazaartv.ir/App_Themes/Theme1/img/logo.png");
            objX.WriteElementString("lastBuildDate", String.Format("{0:R}", DateTime.Now));



            foreach (var item in AlbumLst)
            {
                objX.WriteStartElement("item");
                objX.WriteElementString("title", item.TITLE);
                objX.WriteElementString("author", "www.Bazaartv.ir");
                objX.WriteElementString("link", "http://www.bazaartv.ir" + "/Gallery/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE));
                objX.WriteStartElement("guid");
                objX.WriteAttributeString("isPermaLink", "true");
                objX.WriteString("http://www.bazaartv.ir" + "/Gallery/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE));
                objX.WriteEndElement();
                objX.WriteElementString("pubDate", Bazaar.Core.Utility.GD2StringDateTime((DateTime)item.DATETIME));
                objX.WriteStartElement("category");
                objX.WriteString("گالری تصاویر");
                objX.WriteEndElement();
                objX.WriteElementString("description", item.DESCRIPTION + "..");
                objX.WriteEndElement();

                List<Bazaar.BusinessLayer.ALBUM_PHOTOS> PhotoLst = new List<BusinessLayer.ALBUM_PHOTOS>();
                Bazaar.BusinessLayer.DataLayer.ALBUM_PHOTOSSql PhotoSql = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();
                PhotoLst = PhotoSql.SelectByField("ALBUM_ID", item.ID);
                Random Rdm = new Random();
                int indx = Rdm.Next(0, PhotoLst.Count - 1);



                objX.WriteStartElement("image");
                objX.WriteStartElement("url");
                objX.WriteString("http://www.bazaartv.ir/"+ThumbnailGenerator.Generate(PhotoLst[indx].PATH, 140, 0));
                objX.WriteEndElement();
                objX.WriteStartElement("title");
                objX.WriteString(item.TITLE);
                objX.WriteEndElement();
                objX.WriteStartElement("link");
                objX.WriteString("http://www.bazaartv.ir"+"/Gallery/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE));
                objX.WriteEndElement();
                objX.WriteEndElement();
            }

            objX.WriteEndElement();
            objX.WriteEndElement();
            objX.WriteEndDocument();
            objX.Flush();
            objX.Close();
            Response.End();
        }
    }
}