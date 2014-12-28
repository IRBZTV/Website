using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Bazaar.Modules.Contact.Public
{
    public partial class ConInserter : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {

        
            //Load Template

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
                    break;

                case "None":
                    Container = "";
                    break;


                case "Line":
                    Container = ReadFile(Server.MapPath("~/Core/ContainerTemplates/Title.html"));
                    Container = Container.Replace("[MODULETITILE]", "");
                    LtrModuleTitle.Text = Container;
                    break;


                default:
                    Container = "";
                    break;
            }
            LtrModuleTitle.Text = Container;
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

        protected void commentsubmit_Click(object sender, EventArgs e)
        {
            Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
            if (Captcha1.UserValidated)
            {
                BusinessLayer.ContactUs ContactObject = new BusinessLayer.ContactUs();
                if(FileUpload1.HasFile)
                {                  

                   string DateFormat = string.Format("{0:0000}", DateTime.Now.Year) + "-"
                        + string.Format("{0:00}", DateTime.Now.Month) + "-"
                        + string.Format("{0:00}", DateTime.Now.Day);
                   DirectoryInfo DestDirectory = new DirectoryInfo(Server.MapPath("/Files/UserFiles/" + DateFormat));

                   if (!DestDirectory.Exists)
                   {
                       DestDirectory.Create();
                   }

                   string NewFileName =
                       string.Format("{0:00}", DateTime.Now.Hour) + "-"
                       + string.Format("{0:00}", DateTime.Now.Minute) + "-"
                       + string.Format("{0:00}", DateTime.Now.Second) + "-"
                       + string.Format("{0:000}", DateTime.Now.Millisecond);
                   FileUpload1.SaveAs(Server.MapPath("files/UserFiles/"+DateFormat+"/"+ NewFileName +  Path.GetExtension(FileUpload1.FileName).ToLower()));
                  ContactObject.FilePath="/files/UserFiles/" + DateFormat + "/" + NewFileName + Path.GetExtension(FileUpload1.FileName).ToLower();
                }
                else
                {
                    ContactObject.FilePath = "";
                }
                ContactObject.Phone = phone.Text.Trim();
                ContactObject.Email = email.Text.Trim();
                ContactObject.Name = name.Text.Trim();
                ContactObject.Kind = int.Parse(kind.SelectedValue.Trim());
                ContactObject.Isread = false;              
                ContactObject.Datetime_Insert = DateTime.Now;
                ContactObject.Datetime_Check = DateTime.Now;
                ContactObject.Body = comment.Text.Trim();
                Bazaar.BusinessLayer.DataLayer.ContactUs.Insert(ContactObject);
                PnlContactInsert.Visible = false;
                PnlContactResult.Visible = true;
            }
            else
            {
                txtCaptcha.CssClass += "  error";
            }
        }

        public string Container_Layout { get; set; }
        public string ModuleTitle { get; set; }
    }
}