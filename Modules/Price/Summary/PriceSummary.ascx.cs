using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Price.Summary
{
    public partial class pricesummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.DataLayer.ECONOMY_TREESql Eco_Sql = new BusinessLayer.DataLayer.ECONOMY_TREESql();



                List<BusinessLayer.ECONOMY_TREE> Eco_Lst = Eco_Sql.SelectAll();

                //Load Template

                string Content_Layout = "";

                Content_Layout = ReadFile(Server.MapPath("~/Modules/Price/Summary/Templates/" + Template + "/main.html"));





                StringBuilder sb = new StringBuilder();


                string[] layoutStrings = LayoutStringsMain(Content_Layout);

                try
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
                            Container = Container.Replace("[TIME]", Bazaar.Core.Utility.GD2StringDateTime(DateTime.Parse(Eco_Lst[0].DATETIME.ToString())));

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


                    // layoutStrings[0] = layoutStrings[0].Replace("[LASTUPDATE]", Bazaar.Core.Utility.GD2StringDateTime(DateTime.Parse(Eco_Lst[0].DATETIME.ToString())));
                }
                catch
                {

                    // layoutStrings[0] = layoutStrings[0].Replace("[LASTUPDATE]", "");
                }

                sb.Append(layoutStrings[0]);


                for (int i = 0; i < Eco_Lst.Count; i++)
                {
                    string[] layoutRepeatMain = LayoutStrings(layoutStrings[1]);
                    layoutRepeatMain[0] = layoutRepeatMain[0].Replace("[GROUPTITLE]", Eco_Lst[i].TITLE);
                    layoutRepeatMain[0] = layoutRepeatMain[0].Replace("[ID]", Eco_Lst[i].ID.ToString());
                    //layoutRepeatMain[0] = layoutRepeatMain[0].Replace("[UNIT]", Eco_Lst[i].UNIT.ToString());

                    //if (i == 0)
                    //{
                    //    layoutRepeatMain[0] = layoutRepeatMain[0].Replace(" [CLASSOPEN]", " in ");
                    //    layoutRepeatMain[0] = layoutRepeatMain[0].Replace(" [ICONMODE]", " icon-down-open-1 ");


                    //}
                    //else
                    //{
                        layoutRepeatMain[0] = layoutRepeatMain[0].Replace(" [CLASSOPEN]", " ");
                        layoutRepeatMain[0] = layoutRepeatMain[0].Replace(" [ICONMODE]", " icon-left-open-1 ");

                    //}
                    sb.Append(layoutRepeatMain[0]);

                    //Loop on detail items

                    BusinessLayer.DataLayer.STATISTIC_VALSql EcoVal_Sql = new BusinessLayer.DataLayer.STATISTIC_VALSql();



                    List<BusinessLayer.STATISTIC_VAL> EcoVal_Lst = EcoVal_Sql.SelectByField("GROUPID", Eco_Lst[i].ID.ToString());
                    StringBuilder sb2 = new StringBuilder();
                    for (int j = 0; j < EcoVal_Lst.Count; j++)
                    {
                        try
                        {


                            string Str = layoutRepeatMain[1];

                            Str = Str.Replace("[ITEMTITLE]", EcoVal_Lst[j].TITLE);
                            Str = Str.Replace("[ITEMPRICE]", string.Format("{0:n3}", double.Parse(EcoVal_Lst[j].VAL.Trim())).Replace(".000", ""));
                            Str = Str.Replace("[UNIT]", EcoVal_Lst[j].UNIT);

                            if (double.Parse(EcoVal_Lst[j].DIFF) == 0)
                            {
                                Str = Str.Replace("[ITEMCHANGE]", "");
                                Str = Str.Replace("[CHANGEICON]", " ");
                                Str = Str.Replace("[CHANGECLASS]", " hide ");
                            }
                            else
                            {
                                if (double.Parse(EcoVal_Lst[j].DIFF) > 0)
                                {
                                    Str = Str.Replace("[ITEMCHANGE]", EcoVal_Lst[j].DIFF);
                                    Str = Str.Replace("[CHANGEICON]", "green");
                                    Str = Str.Replace("[CHANGECLASS]", " icon-up-open-1 ");
                                }
                                else
                                {
                                    Str = Str.Replace("[ITEMCHANGE]", EcoVal_Lst[j].DIFF.Replace("-", ""));
                                    Str = Str.Replace("[CHANGEICON]", "red");
                                    Str = Str.Replace("[CHANGECLASS]", " icon-down-open-1 ");
                                }
                            }



                            sb.Append(Str);
                        }
                        catch 
                        {

                        }

                    }
                    layoutRepeatMain[2] = layoutRepeatMain[2].Replace("[FULLLINKTEXT]", Eco_Lst[i].TITLE);
                    //layoutRepeatMain[2] = layoutRepeatMain[2].Replace("[FULLLINKURL]", "prices/" + Eco_Lst[i].ID + "/" + Bazaar.Core.Utility.ClearTitle(Eco_Lst[i].TITLE));
                    layoutRepeatMain[2] = layoutRepeatMain[2].Replace("[FULLLINKURL]", "/prices");

                    sb.Append(layoutRepeatMain[2]);
                }

                sb.Append(layoutStrings[2]);


                Literal1.Text = sb.ToString();
                //   Literal1.Text = "djjjjjjjjjjjj";
            }
            catch
            {


            }






        }
        private string BuildSchedule(BusinessLayer.SCHEDULES ScheduleItem, string layoutString, int thumbWidth, bool OnAir)
        {
            string OnAirIcon = "<span class='onair'>در حال پخش</span>";
            layoutString = layoutString.Replace("[DESCRIPTION]", ScheduleItem.DESCRIPTION);
            layoutString = layoutString.Replace("[TITLE]", ScheduleItem.TITLE);
            layoutString = layoutString.Replace("[TIME]", Bazaar.Core.Utility.ToTimeString(ScheduleItem.DATETIME));
            layoutString = layoutString.Replace("[LINK]", "Schedule/" + ScheduleItem.ID + "/" + Bazaar.Core.Utility.ClearTitle(ScheduleItem.TITLE));
            if (layoutString.Contains("[IMAGE]"))
            {
                layoutString = layoutString.Replace("[IMAGE]", CreateImage(ScheduleItem, thumbWidth));
            }
            if (OnAir)
            {
                layoutString = layoutString.Replace("[ONAIR]", OnAirIcon);
                layoutString = layoutString.Replace("[ONAIRCLASS]", " class='onair' ");

            }
            else
            {
                layoutString = layoutString.Replace("[ONAIR]", " ");
                layoutString = layoutString.Replace("[ONAIRCLASS]", "  ");
            }


            layoutString = layoutString.Replace("[LIVEURL]", "/LIVE");


            return layoutString;
        }
        private string CreateImage(BusinessLayer.SCHEDULES ScheduleItem, int ImageSize)
        {
            return ThumbnailGenerator.Generate(ScheduleItem.IMAGE, ImageSize, 0);
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

        private string[] LayoutStringsMain(string layout)
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
        private string[] LayoutStrings(string layout)
        {
            string layoutString = layout;
            string[] result = new string[3];
            int repeatStartIndex = layoutString.IndexOf("@!");
            int repeatStopIndex = layoutString.IndexOf("!@");
            result[0] = layoutString.Substring(0, repeatStartIndex);
            result[1] = layoutString.Substring(repeatStartIndex, repeatStopIndex - repeatStartIndex).Replace("@!", "");
            result[2] = layoutString.Substring(repeatStopIndex).Replace("!@", "");

            return result;
        }



        public string Template { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }

    }
}