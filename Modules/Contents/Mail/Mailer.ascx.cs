using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Bazaar.Modules.Contents.Mail
{
    public partial class Mailer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        { }

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
        protected void commentsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
                if (Captcha1.UserValidated)
                {
                    if (TxtReceiver.Text.Trim().Length > 0)
                    {
                        BusinessLayer.CONTENTS Cont_Item = new BusinessLayer.CONTENTS();

                        BusinessLayer.DataLayer.CONTENTSSql Con_Sql = new BusinessLayer.DataLayer.CONTENTSSql();

                        Cont_Item = Con_Sql.SelectByPrimaryKey(new BusinessLayer.CONTENTSKeys(int.Parse(Page.RouteData.Values["NewsID"].ToString())));


                        Page.Title += "شبکه تلویزیونی بازار" + " :: " + Cont_Item.TITLE + " نسخه چاپی ";

                        string Content_Layout = "";

                        Content_Layout = ReadFile(Server.MapPath("~/Modules/contents/Mail/Templates/template1/source.html"));
                        Content_Layout = Content_Layout.Replace("[LEAD]", (String.IsNullOrEmpty(Cont_Item.LEAD) ? "" : ("<span class=\"lead\">" + Cont_Item.LEAD + "</span>")));
                        Content_Layout = Content_Layout.Replace("[TITLE]", Cont_Item.TITLE);
                        Content_Layout = Content_Layout.Replace("[DESCRIPTION]", Cont_Item.DESCRIPTION);
                        Content_Layout = Content_Layout.Replace("[DATE]", Bazaar.Core.Utility.GD2StringDateTime(Cont_Item.DATETIME_CREATE));
                        Content_Layout = Content_Layout.Replace("[BODY]", Cont_Item.BODY);
                        Content_Layout = Content_Layout.Replace("[LINK]", "/news/" + Cont_Item.ID + "/" + Cont_Item.TITLE.Trim().Replace(" ", "-"));



                        string Body = "";
                        Body += "با سلام";
                        Body += "\n";
                        Body += ":این پست الکنرونیکی به در خواست ";
                        Body += "\n";
                        Body += name.Text;
                        Body += "\n";
                        Body += "  :با پست الکترونیک";
                        Body += "\n";
                        Body += TxtSender.Text;
                        Body += "\n";
                        Body += "  ارسال شده است لطفا برای مشاهده مطلب روی لینک زیر کلیک بفرمایید";
                        Body += "\n";
                        Body += "http://www.bazaartv.ir/news/" + Cont_Item.ID + "/" + Cont_Item.TITLE.Trim().Replace(" ", "-");
                        Body += "\n";
                        SendMail(TxtReceiver.Text.Trim(), "شبکه تلویزیونی بازار" + " :: " + Cont_Item.TITLE, Body);
                    }
                }
            }
            catch
            {

            }

        }
        protected void SendMail(string toAddress, string subject, string body)
        {
            try
            {
                var fromAddress = "news@bazaartv.ir";
                const string fromPassword = "kimdanistvikez";
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "mail.bazaartv.ir";
                    smtp.Port = 25;
                    smtp.EnableSsl = false;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;
                }
                // Passing values to smtp object
                smtp.Send(fromAddress, toAddress, subject, body);
                PnlMain.Visible = false;
                PnlSent.Visible = true;

            }
            catch 
            {

              
            }
        }

    }
}
