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
    public partial class ConductorFeedGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime CurDate = DateTime.Now;
            DateTime Strt = DateTime.Parse(CurDate.ToShortDateString() + " 00:00:00 am");
            DateTime end = DateTime.Parse(CurDate.ToShortDateString() + " 23:59:59 pm");
            BusinessLayer.DataLayer.SCHEDULESSql Schedule_Sql = new BusinessLayer.DataLayer.SCHEDULESSql();
            List<BusinessLayer.SCHEDULES> Schedules_Lst = Schedule_Sql.SelectTopBetweenTime(500, Strt, end);




            Response.Clear();
            Response.ContentType = "application/rss+xml";
            XmlTextWriter objX = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
            objX.WriteStartDocument();
            objX.WriteStartElement("rss");
            objX.WriteAttributeString("version", "2.0");
            objX.WriteStartElement("channel");



            objX.WriteElementString("title", "جدول پخش برنامه های شبکه بازار" + Bazaar.Core.Utility.GD2StringDateTime(CurDate));
            objX.WriteElementString("link", "http://www.bazaartv.ir/schedules");
            objX.WriteElementString("description", "شبکه تلویزیونی بازار");
            objX.WriteElementString("language", "en-us");
            objX.WriteElementString("ttl", "60");
            objX.WriteElementString("image", "http://www.bazaartv.ir/App_Themes/Theme1/img/logo.png");
            objX.WriteElementString("lastBuildDate", String.Format("{0:R}", DateTime.Now));

            objX.WriteStartElement("Conductor");

            foreach (var item in Schedules_Lst)
            {
                Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                List<Bazaar.BusinessLayer.PROGRAMS> ProgLst = ProgSql.SelectByField("Id", item.URL);

                if (ProgLst.Count > 0)
                {
                    objX.WriteStartElement("item");
                    objX.WriteAttributeString("Title", item.TITLE);
                    objX.WriteAttributeString("StartTime", Bazaar.Core.Utility.ToTimeString(item.DATETIME));
                    objX.WriteAttributeString("Image", "http://www.bazaartv.ir"+CreateImage(ProgLst[0], 100));
                    objX.WriteAttributeString("Link", "http://www.bazaartv.ir/program/" + ProgLst[0].ID + "/" + Bazaar.Core.Utility.ClearTitle(ProgLst[0].TITLE));
                    objX.WriteEndElement();
                }
                else
                {
                    objX.WriteStartElement("item");
                    objX.WriteAttributeString("Title", item.TITLE);
                    objX.WriteAttributeString("StartTime", Bazaar.Core.Utility.ToTimeString(item.DATETIME));
                    objX.WriteAttributeString("Image", "http://www.bazaartv.ir/files/images/Bazaar.jpg");
                    objX.WriteAttributeString("Link", "http://www.bazaartv.ir/schedules");
                    objX.WriteEndElement();
                }



            }
            objX.WriteEndElement();

            objX.WriteEndElement();
            objX.WriteEndElement();
            objX.WriteEndDocument();
            objX.Flush();
            objX.Close();
            Response.End();
        }
        private string CreateImage(BusinessLayer.PROGRAMS ProgItem, int ImageSize)
        {

            return ThumbnailGenerator.Generate(ProgItem.IMAGE, ImageSize, 0);

        }
    }
}