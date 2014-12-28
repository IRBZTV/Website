using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Programs.ShowProgram
{
    public partial class FullView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLayer.PROGRAMS Cont_Item = new BusinessLayer.PROGRAMS();

            BusinessLayer.DataLayer.PROGRAMSSql Con_Sql = new BusinessLayer.DataLayer.PROGRAMSSql();

            Cont_Item = Con_Sql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(int.Parse(Page.RouteData.Values["ProgramID"].ToString())));


            Page.Title += "شبکه تلویزیونی بازار" + " :: " + Cont_Item.TITLE;

            string Content_Layout = "";

            Content_Layout = ReadFile(Server.MapPath("~/Modules/programs/ShowProgram/Templates/" + Template + "/main.html"));
            string[] ImagesString = LayoutStrings(Content_Layout);

            ImagesString[0] = ImagesString[0].Replace("[LEAD]", (String.IsNullOrEmpty(Cont_Item.DESCRIPTION) ? "" : ("<span class=\"lead\">" + Cont_Item.DESCRIPTION + "</span>")));
            ImagesString[0] = ImagesString[0].Replace("[TITLE]", Cont_Item.TITLE);
            ImagesString[0] = ImagesString[0].Replace("[DESCRIPTION]", Cont_Item.DESCRIPTION);
            ImagesString[0] = ImagesString[0].Replace("[DATE]", Bazaar.Core.Utility.GD2StringDateTime((DateTime)Cont_Item.Datetime));
            ImagesString[0] = ImagesString[0].Replace("[BODY]", Cont_Item.BODY);
            ImagesString[0] = ImagesString[0].Replace("[ROLES]", Cont_Item.ROLES);
            if (Cont_Item.IMAGE.Length > 5)
            {
                if (Cont_Item.IMAGE.ToLower().Contains("bazaar"))
                {
                    Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql SessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                    List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> SessionsList =
                        SessionSql.SelectByProgIDTop(int.Parse(Page.RouteData.Values["ProgramID"].ToString()), 10000,"Number");
                    if (SessionsList.Count > 0)
                    {
                        int Rdm = 0;
                        Random Rdmnum = new Random();
                        Rdm = Rdmnum.Next(0, SessionsList.Count - 1);
                        Bazaar.BusinessLayer.PROGRAM_SESSIONS Session = SessionsList[Rdm];


                        ImagesString[0] = ImagesString[0].Replace("[IMAGETOP]", ThumbnailGenerator.Generate(Session.IMAGE, 300, 0));
                    }
                    else
                    {
                        ImagesString[0] = ImagesString[0].Replace("[IMAGETOP]", ThumbnailGenerator.Generate(Cont_Item.IMAGE, 300, 0));
                    }
                }
                else
                {
                    ImagesString[0] = ImagesString[0].Replace("[IMAGETOP]", ThumbnailGenerator.Generate(Cont_Item.IMAGE, 300, 0));
                }
               
                ImagesString[0] = ImagesString[0].Replace("[VISIBLEITEM]", "  ");
            }
            else
            {
                ImagesString[0] = ImagesString[0].Replace("[VISIBLEITEM]", " hide  ");
            }





            Bazaar.BusinessLayer.DataLayer.PROGRAM_PHOTOSSql Content_File_Sql = new BusinessLayer.DataLayer.PROGRAM_PHOTOSSql();
            List<Bazaar.BusinessLayer.PROGRAM_PHOTOS> Files_Lst =
                Content_File_Sql.SelectByField("PID", Cont_Item.ID);

            //if (Files_Lst.Count > 0)
            //{
            //    if (ImagesString[0].Contains("[IMAGE]"))
            //        ImagesString[0] = ImagesString[0].Replace("[IMAGE]", ThumbnailGenerator.Generate(Files_Lst[0].PATH, 300, 0));
            //}

            string Images = "";

            for (int i = 0; i < Files_Lst.Count; i++)
            {
                Images += ImagesString[1].Replace("[IMAGE]", ThumbnailGenerator.Generate(Files_Lst[i].PATH, 610, 0)).Replace("[TITLE]", Cont_Item.TITLE);

                if (i == 0)
                {
                    Images = Images.Replace("[THUMBCLASS]", " class='active'  ");

                    if (ImagesString[0].Contains("[IMAGE2]"))
                        ImagesString[0] = ImagesString[0].Replace("[IMAGE2]", ThumbnailGenerator.Generate(Files_Lst[i].PATH, 610, 0));
                }
                Images = Images.Replace("[THUMBCLASS]", "    ");
            }
            if (Files_Lst.Count <= 1)
            {
                ImagesString[0] = ImagesString[0].Replace("[VISIBLEITEMGALLERY]", " hide ");

            }
            else
            {
                ImagesString[0] = ImagesString[0].Replace("[VISIBLEITEMGALLERY]", "  ");
            }


            if (Files_Lst.Count == 0)
            {
                ImagesString[0] = ImagesString[0].Replace("[VISIBLEITEM]", " hide ");

            }
            else
            {
                ImagesString[0] = ImagesString[0].Replace("[VISIBLEITEM]", "  ");
            }









            ltNewsList.Text = ImagesString[0] + Images + ImagesString[2];

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
        private string[] LayoutStringsEnd(string layout)
        {
            string layoutString = layout;
            string[] result = new string[3];
            int repeatStartIndex = layoutString.IndexOf("#!");
            int repeatStopIndex = layoutString.IndexOf("!#");
            result[0] = layoutString.Substring(0, repeatStartIndex);
            result[1] = layoutString.Substring(repeatStartIndex, repeatStopIndex - repeatStartIndex).Replace("#!", " ");
            result[2] = layoutString.Substring(repeatStopIndex).Replace("!#", " ");

            return result;
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

        public string Template { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
    }
}