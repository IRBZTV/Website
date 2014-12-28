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
    public partial class NewsFeedGenerator : System.Web.UI.Page
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

            BusinessLayer.DataLayer.CONTENTSSql Content_Sql = new BusinessLayer.DataLayer.CONTENTSSql();

            //Select from Db
            int CategoryId = int.Parse(RouteData.Values["Category"].ToString());
            List<BusinessLayer.CONTENTS> Contents_Lst = Content_Sql.SelectByCondition(100, CategoryId);

            
            BusinessLayer.DataLayer.CATEGORIESSql Categories_Sql = new BusinessLayer.DataLayer.CATEGORIESSql();
            BusinessLayer.CATEGORIES Cat_Obj = Categories_Sql.SelectByPrimaryKey(new BusinessLayer.CATEGORIESKeys(CategoryId));
            string CategoryTitle = Cat_Obj.TITLE;
           
            objX.WriteElementString("title", Cat_Obj.TITLE);
            objX.WriteElementString("link", "http://www.bazartv.ir/");
            objX.WriteElementString("description", "شبکه تلویزیونی بازار");
            objX.WriteElementString("language", "en-us");
            objX.WriteElementString("ttl", "60");
            objX.WriteElementString("image", "http://www.bazartv.ir/App_Themes/Theme1/img/logo.png");
            objX.WriteElementString("lastBuildDate", String.Format("{0:R}", DateTime.Now));

            foreach (var item in Contents_Lst)
            {
                //ContentTop[1] = ContentTop[1].Replace("[TITLE]", Contents_Lst[0].TITLE);
                //ContentTop[1] = ContentTop[1].Replace("[DESCRIPTION]", Contents_Lst[0].DESCRIPTION);
                //ContentTop[1] = ContentTop[1].Replace("[LINK]", "/news/" + Contents_Lst[0].ID + "/" + Bazaar.Core.Utility.ClearTitle(Contents_Lst[0].TITLE));
                //ContentTop[1] = ContentTop[1].Replace("[IMAGE]", CreateImage(Contents_Lst[0], 610));
                //ContentTop[1] = ContentTop[1].Replace("[DATE]", Bazaar.Core.Utility.GD2StringDateTime(Contents_Lst[0].DATETIME_CREATE));

                objX.WriteStartElement("item");
                objX.WriteElementString("title", item.TITLE);
                objX.WriteElementString("author", "www.Bazaartv.ir");
                objX.WriteElementString("link", "http://www.bazaartv.ir" + "/news/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE));
                objX.WriteStartElement("guid");
                objX.WriteAttributeString("isPermaLink", "true");
                objX.WriteString("http://www.bazaartv.ir" + "/news/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE));
                objX.WriteEndElement();
                objX.WriteElementString("pubDate", Bazaar.Core.Utility.GD2StringDateTime(item.DATETIME_CREATE));
                objX.WriteStartElement("category");
                objX.WriteString(CategoryTitle);
                objX.WriteEndElement();
                objX.WriteElementString("description", item.DESCRIPTION + "..");
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