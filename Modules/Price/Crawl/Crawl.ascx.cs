using Bazaar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Price.Crawl
{
    public partial class Crawl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.DataLayer.ECONOMY_TREESql Eco_Sql = new BusinessLayer.DataLayer.ECONOMY_TREESql();



                List<BusinessLayer.ECONOMY_TREE> Eco_Lst = Eco_Sql.SelectAll();

                //Load Template

                string Content_Layout = "";

                Content_Layout = ReadFile(Server.MapPath("~/Modules/Price/Crawl/Templates/" + Template + "/main.html"));





                StringBuilder sb = new StringBuilder();


                string[] layoutStrings = LayoutStringsMain(Content_Layout);





                Random random = new Random();
                int maxValue = Eco_Lst.Count;

                int r = random.Next(maxValue);







                BusinessLayer.DataLayer.STATISTIC_VALSql EcoVal_Sql = new BusinessLayer.DataLayer.STATISTIC_VALSql();



                List<BusinessLayer.STATISTIC_VAL> EcoVal_Lst;
                int Loop = 0;

                //try
                //{
                EcoVal_Lst = EcoVal_Sql.SelectByField("GROUPID", Eco_Lst[r].ID.ToString());
                while (Loop == 0)
                {
                    r = random.Next(maxValue);
                    EcoVal_Lst = EcoVal_Sql.SelectByField("GROUPID", Eco_Lst[r].ID.ToString());
                    Loop = EcoVal_Lst.Count;
                }

                sb.Append(layoutStrings[0].Replace("[GROUPTITLE]", Eco_Lst[r].TITLE));




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
                        Container = Container.Replace("[TIME]", Bazaar.Core.Utility.GD2StringDateTime(DateTime.Parse(Eco_Lst[r].DATETIME.ToString())));

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










                //}
                //catch 
                //{

                //    Loop = 0;
                //    EcoVal_Lst = null;

                //}






                for (int j = 0; j < Loop; j++)
                {










                    try
                    {
                        string Str = layoutStrings[1];
                        //  Str = Str.Replace("[GROUPTITLE]", Eco_Lst[r].TITLE);
                        Str = Str.Replace("[ITEMTITLE]", EcoVal_Lst[j].TITLE);
                        Str = Str.Replace("[ITEMPRICE]", string.Format("{0:n3}", double.Parse(EcoVal_Lst[j].VAL.Trim())).Replace(".000", ""));
                        Str = Str.Replace("[UNIT]", EcoVal_Lst[j].UNIT);

                        if (double.Parse(EcoVal_Lst[j].DIFF) == 0)
                        {
                            Str = Str.Replace("[ITEMCHANGE]", "");
                            Str = Str.Replace("[CHANGEICON]", "");
                            Str = Str.Replace("[CHANGECLASS]", "");
                        }
                        else
                        {

                            //         [ITEMCHANGE]
                            //[CHANGECLASS]
                            //<i class="change [CHANGEICON]">[ITEMCHANGE] </i>
                            //<i class=" [CHANGEICON] [CHANGECLASS]"></i>

                            if (double.Parse(EcoVal_Lst[j].DIFF) > 0)
                            {
                                Str = Str.Replace("[ITEMCHANGE]", "<i class=\"change green\">" + EcoVal_Lst[j].DIFF.Replace("-", "") + "</i>");
                                Str = Str.Replace("[CHANGECLASS]", "<i class=\" green icon-up-open-1\"></i>");

                            }
                            else
                            {
                                Str = Str.Replace("[ITEMCHANGE]", "<i class=\"change red\">" + EcoVal_Lst[j].DIFF.Replace("-", "") + "</i>");
                                Str = Str.Replace("[CHANGECLASS]", "<i class=\" red icon-down-open-1\"></i>");
                            }

                        }

                        sb.Append(Str);

                        if (EcoVal_Lst.Count < 7 && j == EcoVal_Lst.Count - 1)
                        {
                            // j = 0;
                            sb.Append(Str);
                        }

                    }
                    catch
                    {

                    }

                    ///////////
                }


                sb.Append(layoutStrings[2]);


                Literal1.Text = sb.ToString();

            }
            catch
            {


            }






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



        public string Template { get; set; }
        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
    }
}