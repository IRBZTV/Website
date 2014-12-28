using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Programs.Session.Top
{
    public partial class TopViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
            List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> SessionsList = SessionSql.SelectByProgIDTop(int.Parse(Page.RouteData.Values["ProgramID"].ToString()), Count, "PLAY_DATETIME");

            BusinessLayer.DataLayer.PROGRAMSSql Con_Sql = new BusinessLayer.DataLayer.PROGRAMSSql();
            BusinessLayer.PROGRAMS Prog_Item = Con_Sql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(int.Parse(Page.RouteData.Values["ProgramID"].ToString())));


            if (SessionsList.Count > 0)
            {

                #region ModuleTitle
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
                #endregion





                string Content_Layout = "";

                Content_Layout = ReadFile(Server.MapPath("~/Modules/Programs/Session/Top/Templates/" + Template + "/main.html"));

                StringBuilder sb = new StringBuilder();


                string[] layoutStrings = LayoutStrings(Content_Layout);


                sb.Append(layoutStrings[0]);

                //sb.Append(layoutStrings[0]);
                for (int i = 0; i < SessionsList.Count; i++)
                {

                    sb.Append(BuildSession(SessionsList[i], layoutStrings[1], 140));

                }
              

                sb.Append(layoutStrings[2].Replace("[FullListUrl]", "/program/" + Prog_Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Prog_Item.TITLE) + "/sessionlist/"));
                Literal1.Text = sb.ToString();
            }
            

        }
        private string BuildSession(Bazaar.BusinessLayer.PROGRAM_SESSIONS Item, string layoutString, int thumbWidth)
        {
            BusinessLayer.DataLayer.PROGRAMSSql Con_Sql = new BusinessLayer.DataLayer.PROGRAMSSql();
            BusinessLayer.PROGRAMS Prog_Item = Con_Sql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(int.Parse(Page.RouteData.Values["ProgramID"].ToString())));

            layoutString = layoutString.Replace("[TITLE]", Item.TITLE);
            layoutString = layoutString.Replace("[URL]", "/program/" + Prog_Item.ID + "/" + Bazaar.Core.Utility.ClearTitle(Prog_Item.TITLE) + "/session/"+Item.ID+"/"+ Bazaar.Core.Utility.ClearTitle(Item.TITLE)) ;
            layoutString = layoutString.Replace("[IMG]", ThumbnailGenerator.Generate(Item.IMAGE, thumbWidth, 0));
            layoutString = layoutString.Replace("[SessionNum]", Item.NUMBER.ToString());
            layoutString = layoutString.Replace("[DATETIME]", Utility.GD2StringDateTime((DateTime)Item.DATETIME));

            if (string.IsNullOrEmpty(Item.Play_DATETIME.ToString()))
            {
                layoutString = layoutString.Replace("[PLAYDATE]", "---");
            }
            else
            {
                layoutString = layoutString.Replace("[PLAYDATE]", Utility.GD2StringDate((DateTime)Item.Play_DATETIME));
            }
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

        public int Count { get; set; }
        public string Template { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
    }
}