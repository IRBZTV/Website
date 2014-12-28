using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Modules.Comments
{
    public partial class Comment : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
                BusinessLayer.CONTENTS Cont_Item = new BusinessLayer.CONTENTS();

                BusinessLayer.DataLayer.CONTENTSSql Con_Sql = new BusinessLayer.DataLayer.CONTENTSSql();

                Cont_Item = Con_Sql.SelectByPrimaryKey(new BusinessLayer.CONTENTSKeys(int.Parse(Page.RouteData.Values["NewsID"].ToString())));


                if ((bool)Cont_Item.NEWCOMENT)
                {
                    PnlNewComent.Visible = true;
                }
                else
                {
                    PnlNewComent.Visible = false;
                }

                if ((bool)Cont_Item.SHOWCOMMENTS)
                {


                    List<Bazaar.BusinessLayer.COMMENTS> Com_ObjLst = new List<BusinessLayer.COMMENTS>();
                    Bazaar.BusinessLayer.DataLayer.COMMENTSSql ComSql = new BusinessLayer.DataLayer.COMMENTSSql();
                    Com_ObjLst = ComSql.SelectByCondition( " NEWS_ID="+ Page.RouteData.Values["NewsID"].ToString()+" and Active=1 order by datetime desc");

                    string Content_Layout = "";

                    Content_Layout = ReadFile(Server.MapPath("~/Modules/Comments/Templates/" + Template + "/main.html"));
                    string[] ImagesString = LayoutStrings(Content_Layout);


                    Literal1.Text = ImagesString[0];
                    for (int i = 0; i < Com_ObjLst.Count; i++)
                    {
                        string Sb = ImagesString[1];
                        Sb = Sb.Replace("[TEXT]", Com_ObjLst[i].TEXT);
                        Sb = Sb.Replace("[NAME]", Com_ObjLst[i].NAME);
                        Sb = Sb.Replace("[DATETIME]", Bazaar.Core.Utility.GD2StringDateTime((DateTime)Com_ObjLst[i].DATETIME));
                        Literal1.Text += Sb;
                    }

                    Literal1.Text += ImagesString[2];
                    if(Com_ObjLst.Count==0)                   
                    PnlShowComment.Visible = false;
                }
                else
                {
                    PnlShowComment.Visible = false;
                }
                

                
            

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

        protected void commentsubmit_Click(object sender, EventArgs e)
        {
            Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
            if (Captcha1.UserValidated)
            {
                if (comment.Text.Trim().Length > 0)
                {
                    Bazaar.BusinessLayer.COMMENTS Com = new BusinessLayer.COMMENTS();
                    Com.ACTIVE = false;
                    Com.DATETIME = DateTime.Now;
                    Com.EMAIL = email.Text.Trim();
                    Com.LOCATION = "";
                    Com.NEWS_ID = int.Parse(Page.RouteData.Values["NewsID"].ToString());
                    Com.PID = 0;
                    Com.TEXT = comment.Text;
                    Com.NAME = name.Text;


                    Bazaar.BusinessLayer.DataLayer.COMMENTSSql ComSql = new BusinessLayer.DataLayer.COMMENTSSql();
                    ComSql.Insert(Com);

                    email.Text = "";
                    comment.Text = "";
                    name.Text = "";





                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Msgjdh", "<script language=javascript> var commentSuccess=true; </script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Msgjdhssssss", "<script language=javascript> var commentSuccess=false; </script>");

                }
            }
            else
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "InValid";
            }


           
        }
    }
}