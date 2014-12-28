using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Programs.Top
{
    public partial class TopView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string SelectCondition = " where active=1 and kind="+ProgKind+"  order by priority desc ";

            List<Bazaar.BusinessLayer.PROGRAMS> ProgLst = new List<BusinessLayer.PROGRAMS>();
            Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
            ProgLst = ProgSql.SelectByConditionTop(SelectCondition, Count);

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

            //Load Template

            string Content_Layout = "";

            Content_Layout = ReadFile(Server.MapPath("~/Modules/Programs/top/Templates/" + Template + "/main.html"));

            StringBuilder sb = new StringBuilder();


            string[] layoutStrings = LayoutStrings(Content_Layout);

            string[] layoutStringsTop = LayoutStringsTop(Content_Layout);


            //sb.Append(layoutStrings[0]);
            for (int i = 0; i < ProgLst.Count; i++)
            {
                if (i == 0)
                {
                    sb.Append(BuildProg(ProgLst[0], layoutStringsTop[1], 300));
                }
                else
                {
                    sb.Append(BuildProg(ProgLst[i], layoutStrings[1], 140));
                }
            }

            sb.Append(layoutStrings[2]);
            Literal1.Text = sb.ToString();
        }

        private string BuildProg(Bazaar.BusinessLayer.PROGRAMS Item, string layoutString, int thumbWidth)
        {
            layoutString = layoutString.Replace("[DESC]", Item.DESCRIPTION);
            layoutString = layoutString.Replace("[TITLE]", Item.TITLE);
           // layoutString = layoutString.Replace("[LINK]", "/program/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE));

            layoutString = layoutString.Replace("[LINK]", "/program/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE) + "/sessionlist/");
             
           
                Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> SessionsList =
                    SessionSql.SelectByProgIDTop(Item.ID, 10000, "Number");
                if (SessionsList.Count > 0)
                {
                    int Rdm = 0;
                    Random Rdmnum = new Random();
                    Rdm = Rdmnum.Next(0, SessionsList.Count - 1);
                    Bazaar.BusinessLayer.PROGRAM_SESSIONS Session = SessionsList[Rdm];


                    layoutString = layoutString.Replace("[IMG]", ThumbnailGenerator.Generate(Session.IMAGE, 300, 0));
                }
                else
                {
                    layoutString = layoutString.Replace("[IMG]", ThumbnailGenerator.Generate(Item.IMAGE, 300, 0));
                }
           
           // layoutString = layoutString.Replace("[IMG]", ThumbnailGenerator.Generate(Item.IMAGE, thumbWidth, 0));

            layoutString = layoutString.Replace("[DESCRIPTION]", Item.DESCRIPTION);


            layoutString = layoutString.Replace("[DATE]", Utility.GD2StringDateTime((DateTime)Item.Datetime));

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
        private string[] LayoutStringsTop(string layout)
        {
            string layoutString = layout;
            string[] result = new string[3];
            int repeatStartIndex = layoutString.IndexOf("@!");
            int repeatStopIndex = layoutString.IndexOf("!@");
            result[0] = layoutString.Substring(0, repeatStartIndex);
            result[1] = layoutString.Substring(repeatStartIndex, repeatStopIndex - repeatStartIndex).Replace("@!", " ");
            result[2] = layoutString.Substring(repeatStopIndex).Replace("!@", " ");

            return result;
        }

        public int Count { get; set; }
        public string Template { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
        public int ProgKind { get; set; }
    }
}
