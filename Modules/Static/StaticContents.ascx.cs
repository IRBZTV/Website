using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Static
{
    public partial class StaticContents : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Content_Layout = "";

            Content_Layout = ReadFile(Server.MapPath("~/Modules/Static/Templates/" + Template + "/main.html"));

            StringBuilder sb = new StringBuilder();


            string[] layoutStrings = LayoutStrings(Content_Layout);

            layoutStrings[1] = layoutStrings[1].Replace("[HEADERTITLE]", HeaderTitle);
            layoutStrings[1] = layoutStrings[1].Replace("[BODYTEXT]", BodyText);

            Literal1.Text = layoutStrings[1].ToString();

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
        public string BodyText { get; set; }
        public string Template { get; set; }
        public string HeaderTitle { get; set; }

    }

}