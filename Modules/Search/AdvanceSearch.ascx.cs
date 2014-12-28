using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Search
{
    public partial class AdvanceSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                TxtDateStart.Text = Core.Utility.GD2JD(DateTime.Now.AddYears(-3));
                TxtDateEnd.Text = Core.Utility.GD2JD(DateTime.Now.AddDays(0));
                BusinessLayer.DataLayer.CATEGORIESSql Categories_Sql = new BusinessLayer.DataLayer.CATEGORIESSql();
                List<BusinessLayer.CATEGORIES> Cat_ObjList = Categories_Sql.SelectAll();

                StringBuilder Str = new StringBuilder();
                foreach (var item in Cat_ObjList)
                {
                    ChkLst.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }
                for (int i = 0; i < ChkLst.Items.Count; i++)
                {
                    ChkLst.Items[i].Selected = true;
                }

                try
                {
                    if (Page.RouteData.Values["SearchKey"].ToString().Trim().Length > 0)
                    {
                        TxtSearchKey.Text = Page.RouteData.Values["SearchKey"].ToString().Trim();
                        BtnSearch_Click(new object(), new EventArgs());
                    }
                }
                catch
                {

                }

            }
        }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            LtrGallery.Text = "";
            LtrNews.Text = "";
            LtrSessions.Text = "";


            try
            {
                //NEWS
                string Categories = "  ";
                for (int i = 0; i < ChkLst.Items.Count; i++)
                {
                    if (ChkLst.Items[i].Selected)
                    {
                        Categories += ChkLst.Items[i].Value.ToString() + ",";
                    }
                }
                DateTime Start = Core.Utility.JD2GD(TxtDateStart.Text.Trim());
                DateTime End = Core.Utility.JD2GD(TxtDateEnd.Text.Trim()).AddMinutes(1439);

                StringBuilder Str = new StringBuilder();
                string[] Words = TxtSearchKey.Text.Trim().Split(' ');
                Str.Append(" (");
                for (int i = 0; i < Words.Length; i++)
                {
                    Str.Append(" TITLE like N'%" + Words[i].Trim() + "%'  Or ");
                }

                for (int i = 0; i < Words.Length; i++)
                {
                    Str.Append(" [DESCRIPTION] like N'%" + Words[i].Trim() + "%' Or  ");
                }

                for (int i = 0; i < Words.Length; i++)
                {
                    Str.Append(" BODY like N'%" + Words[i].Trim() + "%'  Or ");
                }
                Str.Append(" )");


                string ContentCondition = "(" + Str.ToString().Remove(Str.Length - 5, 3) + " ) and CATEGORY_ID in (" + Categories.Remove(Categories.Length - 1, 1) + " )  and DATETIME_CREATE between CONVERT(datetime, '" + Start + "', 120)  and CONVERT(datetime, '" + End + "', 120)";
                Bazaar.BusinessLayer.DataLayer.CONTENTSSql Contents_Sql = new BusinessLayer.DataLayer.CONTENTSSql();
                List<Bazaar.BusinessLayer.CONTENTS> Contents_List = Contents_Sql.SelectSearch(ContentCondition);

                if (Contents_List.Count > 0)
                {
                    LtrNews.Text = " <ul class=\"item-titles\">";
                    foreach (Bazaar.BusinessLayer.CONTENTS item in Contents_List)
                    {
                        LtrNews.Text += " <li><a target=\"_blank\" href=\"" + "/news/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE) + "\">" + item.TITLE + "</a><span class=\"date\">" + Bazaar.Core.Utility.GD2StringDateTime(item.DATETIME_CREATE) + "</span> </li>";
                    }
                    LtrNews.Text += " </ul>";
                }
                else
                {
                    LtrNews.Text = "موردی یافت نشد.";
                }

                //   LtrNews.Text += ContentCondition;


                //Gallery    
                if (ChkGallery.Checked)
                {

                    StringBuilder StrGallery = new StringBuilder();

                    for (int i = 0; i < Words.Length; i++)
                    {
                        StrGallery.Append(" TITLE like N'%" + Words[i].Trim() + "%'  Or ");
                    }

                    for (int i = 0; i < Words.Length; i++)
                    {
                        StrGallery.Append(" [DESCRIPTION] like N'%" + Words[i].Trim() + "%' Or  ");
                    }




                    string GalleryCondition = "(" + StrGallery.ToString().Remove(StrGallery.Length - 5, 3) + " ) and DATETIME between CONVERT(datetime, '" + Start + "', 120)  and CONVERT(datetime, '" + End + "', 120)";
                    Bazaar.BusinessLayer.DataLayer.ALBUMSSql Albums_Sql = new BusinessLayer.DataLayer.ALBUMSSql();
                    List<Bazaar.BusinessLayer.ALBUMS> Albums_List = Albums_Sql.SelectSearch(GalleryCondition);

                    if (Albums_List.Count > 0)
                    {
                        LtrGallery.Text = "<ul class=\"list gallery-list\">";
                        foreach (Bazaar.BusinessLayer.ALBUMS item in Albums_List)
                        {
                            List<Bazaar.BusinessLayer.ALBUM_PHOTOS> PhotoLst = new List<BusinessLayer.ALBUM_PHOTOS>();
                            Bazaar.BusinessLayer.DataLayer.ALBUM_PHOTOSSql PhotoSql = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();

                            LtrGallery.Text += "<li>";
                            LtrGallery.Text += "<div class=\"image-holder\">";
                            LtrGallery.Text += "<a target=\"_blank\" href=\"" + "/Gallery/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE) + "\" title=\"\">";
                            PhotoLst = PhotoSql.SelectByField("ALBUM_ID", item.ID);
                            if (PhotoLst.Count > 0)
                            {
                                Random Rdm = new Random();
                                int indx = Rdm.Next(0, PhotoLst.Count - 1);
                                LtrGallery.Text += "	<img src=\"" + ThumbnailGenerator.Generate(PhotoLst[indx].PATH, 140, 0) + "\" alt=\"\" />";

                            }

                            LtrGallery.Text += "</a>";
                            LtrGallery.Text += "	</div>";
                            LtrGallery.Text += "	<h3><a target=\"_blank\" href=\"" + "/Gallery/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE) + "\" title=\"\">" + item.TITLE + "</a></h3>";
                            //LtrGallery.Text += "	<div class=\"date\">جمعه 14 تیر 1392 21:28</div>";
                            LtrGallery.Text += "	</li>";


                            // LtrGallery.Text += " <li><a target=\"_blank\" href=\"" + "/news/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE) + "\">" + item.TITLE + "</a><span class=\"date\">" + Bazaar.Core.Utility.GD2StringDateTime((DateTime)item.DATETIME) + "</span> </li>";
                        }
                        LtrGallery.Text += " </ul>";
                    }
                    else
                    {
                        LtrGallery.Text = "موردی یافت نشد.";
                    }

                    //   LtrGallery.Text += GalleryCondition;



                }
                else
                {
                    LtrGallery.Text = "جستجو در گالری تصاویر را فعال نمایید";
                }







                ////Programs          
                //if (ChkPrograms.Checked)
                //{
                //    StringBuilder StrProg = new StringBuilder();

                //    for (int i = 0; i < Words.Length; i++)
                //    {
                //        StrProg.Append(" TITLE like N'" + Words[i].Trim() + "%'  Or ");
                //    }

                //    for (int i = 0; i < Words.Length; i++)
                //    {
                //        StrProg.Append(" [DESCRIPTION] like N'" + Words[i].Trim() + "%' Or  ");
                //    }




                //    string ProgCondition = "(" + StrProg.ToString().Remove(StrProg.Length - 5, 3) + " ) and DATETIME between CONVERT(datetime, '" + Start + "', 120)  and CONVERT(datetime, '" + End + "', 120) and active=1";
                //    Bazaar.BusinessLayer.DataLayer.PROGRAMSSql Prog_Sql = new BusinessLayer.DataLayer.PROGRAMSSql();
                //    List<Bazaar.BusinessLayer.PROGRAMS> Prog_List = Prog_Sql.SelectSearch(ProgCondition);

                //    if (Prog_List.Count > 0)
                //    {
                //        LtrProg.Text = "<ul class=\"list programs-list\">";
                //        foreach (Bazaar.BusinessLayer.PROGRAMS Item in Prog_List)
                //        {
                //            LtrProg.Text += "<li>";
                //            LtrProg.Text += "  <div class=\"image-holder\">";
                //            LtrProg.Text += "    <a target=\"_blank\" href=\"" + "/program/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE) + "\" title=\"\">";
                //            LtrProg.Text += "     <img src=\"" + ThumbnailGenerator.Generate(Item.IMAGE, 140, 0) + "\" alt=\"\" />";
                //            LtrProg.Text += "    </a>";
                //            LtrProg.Text += "     </div>";
                //            LtrProg.Text += "    <h3><a target=\"_blank\" href=\"" + "/program/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE) + "\" title=\"\">" + Item.TITLE + "</a></h3>";
                //            LtrProg.Text += "   <div class=\"introtext\">";
                //            LtrProg.Text += "      <p>";
                //            LtrProg.Text += Item.DESCRIPTION;

                //            LtrProg.Text += "   </p>";
                //            LtrProg.Text += "   </div>";
                //            LtrProg.Text += " </li>";
                //        }
                //        LtrProg.Text += " </ul>";
                //    }
                //    else
                //    {
                //        LtrProg.Text = "موردی یافت نشد.";
                //    }

                //    //LtrProg.Text += ProgCondition;
                //}
                //else
                //{
                //    LtrProg.Text = "جستجو در   برنامه ها را فعال نمایید";
                //}

                //Session:

                if (ChkPrograms.Checked)
                {

                    StringBuilder StrSess = new StringBuilder();
                    for (int i = 0; i < Words.Length; i++)
                    {
                        StrSess.Append(" TITLE like N'%" + Words[i].Trim() + "%'  Or ");
                    }

                    for (int i = 0; i < Words.Length; i++)
                    {
                        StrSess.Append(" body like N'%" + Words[i].Trim() + "%' Or  ");
                    }



                    Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                    List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> SessionsList = SessionSql.Search(StrSess.ToString().Remove(StrSess.Length - 5, 3));

                    if (SessionsList.Count > 0)
                    {


                        StringBuilder Body = new StringBuilder();

                        Body.Append("<div id='schedules-page'>");
                        Body.Append("<table class=\"table table-hover table-condensed\"><tbody>");

                        foreach (Bazaar.BusinessLayer.PROGRAM_SESSIONS item in SessionsList)
                        {
                            BusinessLayer.DataLayer.PROGRAMSSql Con_Sql = new BusinessLayer.DataLayer.PROGRAMSSql();
                            BusinessLayer.PROGRAMS Prog_Item = Con_Sql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys((int)item.PROG_ID));
                            string PageAdr = "/program/" + Prog_Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Prog_Item.TITLE) + "/session/" + item.ID + "/" + Bazaar.Core.Utility.ClearTitle(item.TITLE);


                            Body.Append(" <tr class=\"hastip\" title=\"تاریخ پخش: " + Utility.GD2StringDate((DateTime)item.Play_DATETIME) + "\"><td class=\"item-time\"> <span class=\"time\">" + item.NUMBER + "</span> </td><td><span class=\"photo\">");
                            Body.Append("<img src=\"" + ThumbnailGenerator.Generate(item.IMAGE, 100, 0) + "\" title=\"" + item.TITLE + "\" alt=\"" + item.TITLE + "\" />");
                            Body.Append("</span><h3><a target=\"_blank\" href=\"" + PageAdr + "\">" + item.TITLE + "</a></h3></td>  </tr>");


                        }

                        Body.Append(" </tbody>            </table>        </div>");
                        LtrSessions.Text = Body.ToString();
                    }
                    else
                    {
                        LtrSessions.Text = "موردی یافت نشد.";
                    }


                }
                else
                {
                    LtrSessions.Text = "جستجو در   برنامه ها را فعال نمایید";
                }

            }
            catch (Exception Exp)
            {

                LtrSessions.Text = Exp.Message;
            }

        }
    }
}