using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            //MSCaptcha.CaptchaControl Ms = (MSCaptcha.CaptchaControl)(Login1.FindControl("Captcha1"));
            //TextBox Txt = (TextBox)(Login1.FindControl("txtCaptcha"));



            //Ms.ValidateCaptcha(Txt.Text.Trim());
            //if (!Ms.UserValidated)
            // {
            //     Response.Redirect("/login");
            // }
        }
    }
}