using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Bazaar.Modules.Programs.TwoCol
{
    public partial class ProgCol : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string SelectCondition = " where active=1 and kind=" + ProgKind + "  order by priority desc ";

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













            StringBuilder sb = new StringBuilder();
            string featured = "<div class=\"featured\">  <div class=\"image-holder\">   <a href=\"[LINK]\"> <img src=\"[IMGSRC]\" alt=\"[IMGALT]\" />   </a>    </div>        <h2><a href=\"[LINK]\">[TITLE]</a></h2>        <div class=\"introtext\">            [DESC]	        </div>        <div class=\"clearfix\"></div>    </div>";
            string Cols = "  <div class=\"item [CLASS]\">            <div class=\"image-holder\">                <a href=\"[LINK]\">                    <img src=\"[IMGSRC]\"  alt=\"[IMGALT]\" />                </a>            </div>            <h3><a href=\"[LINK]\">[TITLE]</a></h3>        </div>";
            string ThreeCols = " <div class=\"item [CLASS]\">        <div class=\"image-holder\">             <a href=\"[LINK]\">                    <img src=\"[IMGSRC]\"  alt=\"[IMGALT]\" />                </a>        </div>            <h3><a href=\"[LINK]\">[TITLE]</a></h3>    </div>            ";

            for (int i = 0; i < ProgLst.Count; i++)
            {
                if (i == 0)
                {
                    sb.Append(BuildProg(ProgLst[i], featured, 600, ""));
                }

                if (i > 0 && i < 5)
                {
                    sb.Append("<div class=\"cols\">");
                    for (int j = 1; j < 5; j++)
                    {
                        if (i < ProgLst.Count)
                        {
                            int a = i % 2;
                            if (a == 0)
                            {
                                sb.Append(BuildProg(ProgLst[i], Cols, 292, " even "));

                            }
                            else
                            {
                                sb.Append(BuildProg(ProgLst[i], Cols, 292, " odd "));
                            }
                        }
                        i++;
                    }
                    sb.Append("<div class=\"clearfix\"></div>");
                    sb.Append("</div>");
                }


                if (i > 5 && i < ProgLst.Count-1)
                {
                    sb.Append("<div class=\"cols-three\">");

                    for (int p = 6; p < ProgLst.Count - 1; p++)
                    {
                        if (i < ProgLst.Count-1)
                        {
                            int a = i % 3;
                            if (a == 0)
                            {
                                sb.Append("<div class=\"clearfix\"></div>");
                                sb.Append(BuildProg(ProgLst[i], ThreeCols, 187, "col-1"));
                            }
                            if (a == 1)
                            {
                                sb.Append(BuildProg(ProgLst[i], ThreeCols, 187, "col-2"));
                            }
                            if (a == 2)
                            {
                                sb.Append(BuildProg(ProgLst[i], ThreeCols, 187, "col-3"));
                            }
                        }

                        i++;
                    }
                    sb.Append("</div>");

                }
            }
            ltrAlbums.Text = sb.ToString();
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
        private string BuildProg(Bazaar.BusinessLayer.PROGRAMS Item, string layoutString, int thumbWidth, string Class)
        {

            Bazaar.BusinessLayer.PROGRAM_SESSIONS Session;
            Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
            List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> SessionsList =
                SessionSql.SelectByProgIDTop(Item.ID, 200, "Number");
            if (SessionsList.Count > 0)
            {
                int Rdm = 0;
                Random Rdmnum = new Random();
                Rdm = Rdmnum.Next(0, SessionsList.Count);
                Session = SessionsList[Rdm];
                layoutString = layoutString.Replace("[IMGSRC]", ThumbnailGenerator.Generate(Session.IMAGE, thumbWidth, 0));
            }
            else
            {
                layoutString = layoutString.Replace("[IMGSRC]", ThumbnailGenerator.Generate(Item.IMAGE, thumbWidth, 0));
            }

            layoutString = layoutString.Replace("[DESC]", Item.DESCRIPTION);
            layoutString = layoutString.Replace("[TITLE]", Item.TITLE);
            layoutString = layoutString.Replace("[LINK]","/program/" + Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Item.TITLE) + "/sessionlist/");
            layoutString = layoutString.Replace("[IMGALT]", Item.TITLE);
            layoutString = layoutString.Replace("[COUNT]", SessionsList.Count.ToString());
            layoutString = layoutString.Replace("[CLASS]", Class);
            return layoutString;
        }
        public int Count { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
        public int ProgKind { get; set; }
    }
}