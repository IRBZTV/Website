using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Feeds.Viewer
{
    public partial class FViewer : System.Web.UI.UserControl
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



            BusinessLayer.DataLayer.CATEGORIESSql Categories_Sql = new BusinessLayer.DataLayer.CATEGORIESSql();
            List<BusinessLayer.CATEGORIES> Cat_ObjList = Categories_Sql.SelectAll();

            StringBuilder Str = new StringBuilder();
            foreach (var item in Cat_ObjList)
            {
                string Url = "http://www.bazaartv.ir/feeds/news/" + item.ID;
                Str.Append("  <tr>");
                Str.Append("<td class=\"title\">");
                Str.Append("<a target=\"_blank\" href=\""+Url+"\">"+item.TITLE+"");
                Str.Append("			</a>");
                Str.Append("</td>");
                Str.Append("  <td class=\"link\">");
                Str.Append("      <input class=\"input-xlarge\" value=\""+Url+"\" />");
                Str.Append("  </td>");
                Str.Append("  <td class=\"img\">");
                Str.Append("      <a target=\"_blank\" href=\"" + Url + "\">");
                Str.Append("         <span class=\"icon-rss-alt\"></span>");
                Str.Append("    </a>");
                Str.Append("  </td>");
                Str.Append("</tr>       ");
            }

            string GalleryUrl = "http://www.bazaartv.ir/feeds/gallery/";
            Str.Append("  <tr>");
            Str.Append("<td class=\"title\">");
            Str.Append("<a target=\"_blank\" href=\"" + GalleryUrl + "\">" + "گالری تصاویر" + "");
            Str.Append("			</a>");
            Str.Append("</td>");
            Str.Append("  <td class=\"link\">");
            Str.Append("      <input class=\"input-xlarge\" value=\"" + GalleryUrl + "\" />");
            Str.Append("  </td>");
            Str.Append("  <td class=\"img\">");
            Str.Append("      <a target=\"_blank\" href=\"" + GalleryUrl + "\">");
            Str.Append("         <span class=\"icon-rss-alt\"></span>");
            Str.Append("    </a>");
            Str.Append("  </td>");
            Str.Append("</tr>       ");


            string PriceUrl = "http://www.bazaartv.ir/feeds/price/";
            Str.Append("  <tr>");
            Str.Append("<td class=\"title\">");
            Str.Append("<a target=\"_blank\" href=\"" + PriceUrl + "\">" + "قیمت ها" + "");
            Str.Append("			</a>");
            Str.Append("</td>");
            Str.Append("  <td class=\"link\">");
            Str.Append("      <input class=\"input-xlarge\" value=\"" + PriceUrl + "\" />");
            Str.Append("  </td>");
            Str.Append("  <td class=\"img\">");
            Str.Append("      <a target=\"_blank\" href=\"" + PriceUrl + "\">");
            Str.Append("         <span class=\"icon-rss-alt\"></span>");
            Str.Append("    </a>");
            Str.Append("  </td>");
            Str.Append("</tr>       ");
            LtrRss.Text = Str.ToString();

            string ConductorUrl = "http://www.bazaartv.ir/feeds/conductor/";
            Str.Append("  <tr>");
            Str.Append("<td class=\"title\">");
            Str.Append("<a target=\"_blank\" href=\"" + ConductorUrl + "\">" + "جدول پخش" + "");
            Str.Append("			</a>");
            Str.Append("</td>");
            Str.Append("  <td class=\"link\">");
            Str.Append("      <input class=\"input-xlarge\" value=\"" + ConductorUrl + "\" />");
            Str.Append("  </td>");
            Str.Append("  <td class=\"img\">");
            Str.Append("      <a target=\"_blank\" href=\"" + ConductorUrl + "\">");
            Str.Append("         <span class=\"icon-rss-alt\"></span>");
            Str.Append("    </a>");
            Str.Append("  </td>");
            Str.Append("</tr>       ");
            LtrRss.Text = Str.ToString();

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

        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
    }
}