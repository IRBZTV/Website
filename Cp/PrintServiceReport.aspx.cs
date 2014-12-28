using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Bazaar.Cp
{
    public partial class PrintServiceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime StartDate = Bazaar.Core.Utility.JD2GD(Request.QueryString["Start"].ToString());
            DateTime EndDate = Bazaar.Core.Utility.JD2GD(Request.QueryString["End"].ToString()).AddMinutes(1439);



            BusinessLayer.DataLayer.SERVICE_CLIENTSSql Client_Sql = new BusinessLayer.DataLayer.SERVICE_CLIENTSSql();
            List<BusinessLayer.SERVICE_CLIENTS> Client_Lst = Client_Sql.SelectAll();


            BusinessLayer.DataLayer.SERVICE_KINDSql Kind_Sql = new BusinessLayer.DataLayer.SERVICE_KINDSql();
            List<BusinessLayer.SERVICE_KIND> Kind_Lst = Kind_Sql.SelectAll();


            BusinessLayer.DataLayer.SERVICE_CATEGORIESSql Cat_Sql = new BusinessLayer.DataLayer.SERVICE_CATEGORIESSql();
            List<BusinessLayer.SERVICE_CATEGORIES> Cat_Lst = Cat_Sql.SelectAll();






            StringBuilder Str = new StringBuilder();
            Str.Append("<table>");
            Str.Append("<thead>");
            Str.Append("<tr>");
            Str.Append("<th class=\"p2 rotate\" rowspan=\"2\"><div><span>ردیف</span></div></th>");
            Str.Append("<th class=\"p23\" rowspan=\"2\">فعالیت / خدمات</th>");
            Str.Append("<th colspan=\"" + Client_Lst.Count.ToString() + "\">واحد</th>");
            Str.Append("<th colspan=\"" + Kind_Lst.Count.ToString() + "\">نوع خدمات</th>");
            Str.Append("<th class=\"right\">از:" + Request.QueryString["Start"].ToString() + "</th>");
            Str.Append("<th class=\"right\">تا:" + Request.QueryString["End"].ToString() + "</th>");
            Str.Append("</tr>");
            Str.Append("<tr>");

            int Count1 = 1;
            foreach (BusinessLayer.SERVICE_CLIENTS item in Client_Lst)
            {
                if (Count1 == Client_Lst.Count)
                {

                    Str.Append("<th class=\"bl p3h rotate\"><div><span>" + item.TITLE + "</span></div></th>");
                }
                else
                {
                    Str.Append("<th class=\"p3h rotate\"><div><span>" + item.TITLE + "</span></div></th>");
                }
                Count1++;
            }

            foreach (BusinessLayer.SERVICE_KIND item in Kind_Lst)
            {
                Str.Append("<th class=\"p3h rotate\"><div><span>" + item.TITLE + "</span></div></th>");
            }


            Str.Append("<th class=\"p25\" colspan=\"2\">توضیحات</th>");
            Str.Append("</tr>");
            Str.Append("</thead>");
            Str.Append("<tbody>");
            foreach (BusinessLayer.SERVICE_CATEGORIES item in Cat_Lst)
            {
                BusinessLayer.DataLayer.SERVICE_REPORTSql Service_Sql = new BusinessLayer.DataLayer.SERVICE_REPORTSql();
                if (Service_Sql.SelectCountByCatId(item.ID.ToString(), StartDate, EndDate) > 0)
                {
                    Str.Append("<tr>");
                    Str.Append("<td class=\"title\" colspan=\"" + (Kind_Lst.Count + Client_Lst.Count + 4).ToString() + "\">");
                    Str.Append("<h2>" + item.TITLE + "</h2>");
                    Str.Append("</td>");
                    Str.Append("</tr>");


                    BusinessLayer.DataLayer.SERVICE_LISTSql List_Sql = new BusinessLayer.DataLayer.SERVICE_LISTSql();
                    List<BusinessLayer.SERVICE_LIST> List_Lst = List_Sql.SelectByField("SID", item.ID);


                    int i = 1;
                    foreach (BusinessLayer.SERVICE_LIST item2 in List_Lst)
                    {

                        if (Service_Sql.SelectCountByListId(item2.ID.ToString(), StartDate, EndDate) > 0)
                        {

                            Str.Append("<tr>");
                            Str.Append("<td>" + i.ToString() + "</td>");
                            Str.Append("<td>" + item2.TITLE + "</td>");
                            int Count2 = 1;
                            foreach (BusinessLayer.SERVICE_CLIENTS itemClient in Client_Lst)
                            {
                                if (Count2 == Client_Lst.Count)
                                {
                                    Str.Append("<td class=\"bl\"><div>" + Service_Sql.SelectCountByClientIdListId(itemClient.ID.ToString(), item2.ID.ToString(), StartDate, EndDate).ToString() + "</div></td>");
                                }
                                else
                                {
                                    Str.Append("<td>" + Service_Sql.SelectCountByClientIdListId(itemClient.ID.ToString(), item2.ID.ToString(), StartDate, EndDate).ToString() + "</td>");
                                }
                                Count2++;
                            }

                            foreach (BusinessLayer.SERVICE_KIND itemKind in Kind_Lst)
                            {
                                Str.Append("<td>" + Service_Sql.SelectCountByListIdKindId(item2.ID.ToString(), itemKind.ID.ToString(), StartDate, EndDate).ToString() + "</td>");
                            }
                            Str.Append("<td colspan=\"2\"></td>");
                            Str.Append("</tr>");
                            i++;
                        }
                    }


                }
            }
            

                            Str.Append("<tr>");
                            Str.Append("<td>*</td>");
                            Str.Append("<td>جمع کل:</td>");
                            BusinessLayer.DataLayer.SERVICE_REPORTSql Service_Sql2 = new BusinessLayer.DataLayer.SERVICE_REPORTSql();
                            int Count3 = 1;
                            foreach (BusinessLayer.SERVICE_CLIENTS itemClient in Client_Lst)
                            {
                                if (Count3 == Client_Lst.Count)
                                {
                                    Str.Append("<td class=\"bl\"><div>" + Service_Sql2.SelectCountByClientId(itemClient.ID.ToString(), StartDate, EndDate).ToString() + "</div></td>");
                                }
                                else
                                {
                                    Str.Append("<td>" + Service_Sql2.SelectCountByClientId(itemClient.ID.ToString(), StartDate, EndDate).ToString() + "</td>");
                                }
                                Count3++;
                               
                            }

                            foreach (BusinessLayer.SERVICE_KIND itemKind in Kind_Lst)
                            {
                                 Str.Append("<td>" + Service_Sql2.SelectCountByKindId(itemKind.ID.ToString(),StartDate, EndDate).ToString() + "</td>");
                            }
                            Str.Append("<td colspan=\"2\"></td>");
                            Str.Append("</tr>");
                          
                       
           


            Str.Append("</tbody>");
            Str.Append("</table>");
            LtrTbl.Text = Str.ToString();
        }
    }
}