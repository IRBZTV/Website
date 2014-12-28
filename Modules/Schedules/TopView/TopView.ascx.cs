using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Schedules.TopView
{
    public partial class TopView : System.Web.UI.UserControl
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



            BusinessLayer.DataLayer.SCHEDULESSql Schedule_Sql = new BusinessLayer.DataLayer.SCHEDULESSql();

            //Select from Db

            DateTime StartTime = DateTime.Now.AddHours(-50);
            DateTime EndTime = DateTime.Now.AddDays(2);

            List<BusinessLayer.SCHEDULES> Schedules_Lst = Schedule_Sql.SelectTopBetweenTime(50000, StartTime, EndTime);

            //Load Template

            string Content_Layout = "";

            Content_Layout = ReadFile(Server.MapPath("~/Modules/Schedules/TopView/Templates/" + Template + "/main.html"));



            int OnAirIndex = -1;
            for (int j = 0; j < Schedules_Lst.Count; j++)
            {
                if (j < Schedules_Lst.Count - 1)
                {
                    if (DateTime.Now >= Schedules_Lst[j].DATETIME && DateTime.Now <= Schedules_Lst[j + 1].DATETIME)
                    {
                        OnAirIndex = j;
                    }

                }
            }
            StringBuilder sb = new StringBuilder();


            string[] layoutStrings = LayoutStrings(Content_Layout);
            sb.Append(layoutStrings[0]);
            //for (int i = 0; i < layoutStrings.Length; ++i)
            //{
            int AddeddItem = 0;

            if (OnAirIndex != -1)
            {
                if (OnAirIndex != 0)
                {
                    OnAirIndex--;
                    for (int j = OnAirIndex; j < Count + OnAirIndex; j++)
                    {
                        if (j < Schedules_Lst.Count)
                        {

                            if (j == OnAirIndex + 1)
                            {
                                sb.Append(BuildSchedule(Schedules_Lst[j], layoutStrings[1], ImageWidth, true));
                            }
                            else
                            {
                                sb.Append(BuildSchedule(Schedules_Lst[j], layoutStrings[1], ImageWidth, false));
                            }
                            AddeddItem++;
                        }
                    }
                }
                else
                {
                    for (int j = OnAirIndex; j < Count; j++)
                    {
                        if (j < Schedules_Lst.Count)
                        {

                            if (j == OnAirIndex)
                            {
                                sb.Append(BuildSchedule(Schedules_Lst[j], layoutStrings[1], ImageWidth, true));
                            }
                            else
                            {
                                sb.Append(BuildSchedule(Schedules_Lst[j], layoutStrings[1], ImageWidth, false));
                            }
                            AddeddItem++;
                        }
                    }
                }


            }
            if (AddeddItem > 0)
            {
                sb.Append(layoutStrings[2]);
                ltTopViewSchedules.Text = sb.ToString();
            }
            else
            {
                ltTopViewSchedules.Text = "";
            }




        }
        private string BuildSchedule(BusinessLayer.SCHEDULES ScheduleItem, string layoutString, int thumbWidth, bool OnAir)
        {
            string OnAirIcon = "<span class='onair'>در حال پخش</span>";

            if (!string.IsNullOrEmpty(ScheduleItem.URL))
            {
                try
                {
                    Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                    List<Bazaar.BusinessLayer.PROGRAMS> ProgLst = ProgSql.SelectByField("Id", ScheduleItem.URL);

                    layoutString = layoutString.Replace("[DESC]", ScheduleItem.DESCRIPTION);
                    
                    if (ProgLst.Count > 0)
                    {
                        //layoutString = layoutString.Replace("[DESCRIPTION]", ProgLst[0].DESCRIPTION);
                        layoutString = layoutString.Replace("[TITLE]", ProgLst[0].TITLE);
                        if ((bool)ProgLst[0].ACTIVE)
                        {
                            layoutString = layoutString.Replace("[PROGRAMLINK]", "/program/" + ProgLst[0].ID + "/" + Bazaar.Core.Utility.ClearTitle(ProgLst[0].TITLE));
                        }
                        else
                        {
                            layoutString = layoutString.Replace("[PROGRAMLINK]", "/schedules/");
                        }
                        if (layoutString.Contains("[IMAGE]"))
                        {
                            Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                            List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> SessionsList =
                                SessionSql.SelectByProgIDTop(ProgLst[0].ID, 10, "Number");
                            if (SessionsList.Count > 0)
                            {
                                int Rdm = 0;
                                Random Rdmnum = new Random();
                                Rdm = Rdmnum.Next(0, SessionsList.Count - 1);
                                Bazaar.BusinessLayer.PROGRAM_SESSIONS Session = SessionsList[Rdm];


                                layoutString = layoutString.Replace("[IMAGE]", ThumbnailGenerator.Generate(Session.IMAGE, ImageWidth, 0));
                            }
                            else
                            {
                                layoutString = layoutString.Replace("[IMAGE]", ThumbnailGenerator.Generate(ProgLst[0].IMAGE, ImageWidth, 0));
                            }



                            //layoutString = layoutString.Replace("[IMAGE]", CreateImage(ProgLst[0], thumbWidth));
                        }
                    }
                    else
                    {
                        layoutString = layoutString.Replace("[DESCRIPTION]", " ");
                        layoutString = layoutString.Replace("[TITLE]", ScheduleItem.TITLE);
                        layoutString = layoutString.Replace("[PROGRAMLINK]", "/schedules/");
                        if (layoutString.Contains("[IMAGE]"))
                        {

                            layoutString = layoutString.Replace("[IMAGE]", "/files/images/Bazaar.jpg");
                        }
                    }
                }
                catch
                {
                    layoutString = layoutString.Replace("[DESCRIPTION]", " ");
                    layoutString = layoutString.Replace("[TITLE]", ScheduleItem.TITLE);
                    layoutString = layoutString.Replace("[PROGRAMLINK]", "/schedules/");
                    if (layoutString.Contains("[IMAGE]"))
                    {

                        layoutString = layoutString.Replace("[IMAGE]", "/files/images/Bazaar.jpg");
                    }
                }
            }
            else
            {
                layoutString = layoutString.Replace("[DESCRIPTION]", " ");
                layoutString = layoutString.Replace("[TITLE]", ScheduleItem.TITLE);
                layoutString = layoutString.Replace("[PROGRAMLINK]", "/schedules/");
                if (layoutString.Contains("[IMAGE]"))
                {

                    layoutString = layoutString.Replace("[IMAGE]", "/files/images/Bazaar.jpg");
                }
            }
               
               
            layoutString = layoutString.Replace("[TIME]", Bazaar.Core.Utility.ToTimeString(ScheduleItem.DATETIME));


            if (OnAir)
            {
                layoutString = layoutString.Replace("[ONAIR]", OnAirIcon);
                layoutString = layoutString.Replace("[ONAIRCLASS]", " class='onair' ");
                layoutString = layoutString.Replace("[ONAIRLINKSTART]", " <a href='/live' title='برای مشاهده پخش زنده برنامه کلیک کنید'> ");
                layoutString = layoutString.Replace("[ONAIRLINKEND]", " </a> ");

            }
            else
            {
                layoutString = layoutString.Replace("[ONAIR]", " ");
                layoutString = layoutString.Replace("[ONAIRCLASS]", "  ");
                layoutString = layoutString.Replace("[ONAIRLINKSTART]", "   ");
                layoutString = layoutString.Replace("[ONAIRLINKEND]", "   ");
            }


            layoutString = layoutString.Replace("[LIVEURL]", "/LIVE");


            return layoutString;
        }
        private string CreateImage(BusinessLayer.PROGRAMS ProgItem, int ImageSize)
        {
           
                return ThumbnailGenerator.Generate(ProgItem.IMAGE, ImageSize, 0);
           
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
        public int ImageWidth { get; set; }
        public string Template { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
    }
}