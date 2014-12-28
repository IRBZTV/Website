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
    public partial class PriceFeedGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            BusinessLayer.DataLayer.ECONOMY_TREESql Eco_Sql = new BusinessLayer.DataLayer.ECONOMY_TREESql();
            List<BusinessLayer.ECONOMY_TREE> Eco_Lst = Eco_Sql.SelectAll();


            Response.Clear();
            Response.ContentType = "application/rss+xml";
            XmlTextWriter objX = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
            objX.WriteStartDocument();
            objX.WriteStartElement("rss");
            objX.WriteAttributeString("version", "2.0");
            objX.WriteStartElement("channel");



            objX.WriteElementString("title", "قیمت های لحظه ای در  شبکه بازار");
            objX.WriteElementString("link", "http://www.bazaartv.ir/");
            objX.WriteElementString("description", "شبکه تلویزیونی بازار");
            objX.WriteElementString("language", "en-us");
            objX.WriteElementString("ttl", "60");
            objX.WriteElementString("image", "http://www.bazaartv.ir/App_Themes/Theme1/img/logo.png");
            objX.WriteElementString("lastBuildDate", String.Format("{0:R}", DateTime.Now));


        
            for (int i = 0; i < Eco_Lst.Count; i++)
            {

                BusinessLayer.DataLayer.STATISTIC_VALSql EcoVal_Sql = new BusinessLayer.DataLayer.STATISTIC_VALSql();
                List<BusinessLayer.STATISTIC_VAL> EcoVal_Lst = EcoVal_Sql.SelectByField("GROUPID", Eco_Lst[i].ID.ToString());
             
                objX.WriteStartElement("item");
                objX.WriteElementString("title", Eco_Lst[i].TITLE);
                objX.WriteElementString("author", "www.Bazaartv.ir");
                objX.WriteElementString("link", "http://www.bazaartv.ir/price");
                objX.WriteStartElement("guid");
                objX.WriteAttributeString("isPermaLink", "true");
                objX.WriteString("http://www.bazaartv.ir/price");
                objX.WriteEndElement();
                objX.WriteElementString("pubDate", Bazaar.Core.Utility.GD2StringDateTime((DateTime)Eco_Lst[i].DATETIME));
                objX.WriteEndElement();

                objX.WriteStartElement("price");
                for (int j = 0; j < EcoVal_Lst.Count; j++)
                {
                    objX.WriteStartElement("item");
                    objX.WriteAttributeString("Title", EcoVal_Lst[j].TITLE);
                    objX.WriteAttributeString("Value", string.Format("{0:n3}", double.Parse(EcoVal_Lst[j].VAL.Trim())).Replace(".000", ""));
                    objX.WriteAttributeString("Change", EcoVal_Lst[j].DIFF);
                    objX.WriteAttributeString("Unit", EcoVal_Lst[j].DIFF);
                    objX.WriteEndElement();
                  

                }
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