using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Programs_Sessions_Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ProgId = int.Parse(RouteData.Values["ProgramID"].ToString());
            int Sid = int.Parse(RouteData.Values["SessionId"].ToString());
            if (!Page.IsPostBack)
            {
                HtmlGenericControl jqueryInclude = new HtmlGenericControl("script");
                jqueryInclude.Attributes.Add("type", "text/javascript");
                jqueryInclude.Attributes.Add("src", "/App_Themes/Theme1/mediaplayer/jwplayer.js");
                Page.Header.Controls.Add(jqueryInclude);
                if (Sid != 0)
                {
                    LoadSession();
                }
                else
                {
                    txtDate.Text = Core.Utility.GD2JD(DateTime.Now);
                    txtTime.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                }
            }
        }
        protected void LoadSession()
        {
            int Sid = int.Parse(RouteData.Values["SessionId"].ToString());
            Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql PsSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
            Bazaar.BusinessLayer.PROGRAM_SESSIONS ProgS = PsSql.SelectByPrimaryKey(new BusinessLayer.PROGRAM_SESSIONSKeys(Sid));
            txtTitle.Text = ProgS.TITLE;
            txtBody.Text = ProgS.BODY;
            txtNumber.Text = ProgS.NUMBER.ToString();
            Image1.ImageUrl = Bazaar.Core.ThumbnailGenerator.Generate(ProgS.IMAGE, 300, 0);
            txtDate.Text = Core.Utility.GD2JD((DateTime)ProgS.DATETIME);
            txtTime.Text = ((DateTime)ProgS.DATETIME).Hour.ToString() + ":" + ((DateTime)ProgS.DATETIME).Minute.ToString();
            if (ProgS.VIDEO.Trim().Length > 5)
            {
                StringBuilder Video = new StringBuilder();
                Video.Append("<div id=\"liveplayer\">");
                Video.Append("      <div id=\"player_wrapper\" style=\"position: relative; width: 460px; height: 260px;\">");
                Video.Append("       <object type=\"application/x-shockwave-flash\" data=\"/App_themes/Theme1/mediaplayer/player.swf\" width=\"100%\" height=\"100%\" bgcolor=\"#000000\" id=\"player\" name=\"player\" tabindex=\"0\" __idm_id__=\"332939265\">");
                Video.Append("           <param name=\"allowfullscreen\" value=\"true\">");
                Video.Append("           <param name=\"allowscriptaccess\" value=\"always\">");
                Video.Append("           <param name=\"seamlesstabbing\" value=\"true\">");
                Video.Append("           <param name=\"wmode\" value=\"opaque\">");
                Video.Append("          <param name=\"flashvars\" value=\"netstreambasepath=http%3A%2F%2Fbazaartv.ir%2Flive&amp;id=player&amp;file=pooya_500&amp;provider=rtmp&amp;streamer=rtmp%3A%2F%2Flive.iransima.ir%2Flive&amp;bufferlength=5&amp;repeat=none&amp;stretching=uniform&amp;smoothing=false&amp;autostart=true&amp;backcolor=%23efefef&amp;skin=%2FApp_themes%2FTheme1%2Fmediaplayer%2Fskins%2Fbekle%2Fbekle.zip&amp;allowscriptaccess=always&amp;controlbar.position=bottom\">");
                Video.Append("        </object>");
                Video.Append("    </div>");
                Video.Append("<a href=\"/files/video/" + ProgS.VIDEO + "\" target=\"_blank\">دانلود فایل ویدئو</a>");
                Video.Append("<script type=\"text/javascript\">");
                Video.Append("    jwplayer('player').setup({");
                Video.Append("    'file': '/files/video/" + ProgS.VIDEO + "',");
                Video.Append("    image: \"/files/images/Bazaar.jpg\",");
                Video.Append("   height: 576,         ");
                Video.Append("   width: 720,");
                Video.Append("   bufferlength: 5,     ");
                Video.Append("   'modes': [");
                Video.Append("   { 'type': 'html5' },");
                Video.Append("   { 'type': 'flash', src: '/App_themes/Theme1/mediaplayer/player.swf' },");
                Video.Append("   { 'type': 'download' }");
                Video.Append("   ],");
                Video.Append("   'autostart': 'false',");
                Video.Append("   'backcolor': '#efefef',     ");
                Video.Append("   'skin': '/App_themes/Theme1/mediaplayer/skins/bekle/bekle.zip',");
                Video.Append("   allowscriptaccess: 'always'");
                Video.Append(" });");
                Video.Append(" </script>");
                Video.Append(" </div>");
                LtrVideoPlayer.Text = Video.ToString();
            }
            else
            {
                LtrVideoPlayer.Text = "";
            }


             Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
            List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", User.Identity.Name);
            if (UserObj.Count > 0)
            {
                if ((int)UserObj[0].PROG_ID != 0)
                {
                    if ((bool)ProgS.ACTIVE)
                    {
                        BtnSave.Visible = false;
                    }
                }
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int ProgId = int.Parse(RouteData.Values["ProgramID"].ToString());
            int Sid = int.Parse(RouteData.Values["SessionId"].ToString());
            if (Sid == 0)
            {
                Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql PsSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                Bazaar.BusinessLayer.PROGRAM_SESSIONS ProgS = new BusinessLayer.PROGRAM_SESSIONS();
                ProgS.BODY = txtBody.Text;
                ProgS.DATETIME = DateTime.Now;
                ProgS.NUMBER = int.Parse(txtNumber.Text.Trim());
                ProgS.TITLE = txtTitle.Text.Trim();
                ProgS.IMAGE = "";
                ProgS.VIDEO = "";
                ProgS.PROG_ID = ProgId;
                ProgS.ACTIVE = false;
                ProgS.DATETIME = DateTime.Parse((Core.Utility.JD2GD(txtDate.Text.Trim()).ToShortDateString() + " " + txtTime.Text.Trim()));
                if (FileUpload1.HasFile)
                {
                    if (Path.GetExtension(FileUpload1.FileName).ToLower() == ".jpg")
                    {
                        System.Drawing.Image imgFile =
                             System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                        if (imgFile.PhysicalDimension.Width == 610 && (imgFile.PhysicalDimension.Height == 343 || imgFile.PhysicalDimension.Height == 342))
                        {
                            string NewFileName =
                                string.Format("{0:00}", DateTime.Now.Hour) + "-"
                                + string.Format("{0:00}", DateTime.Now.Minute) + "-"
                                + string.Format("{0:00}", DateTime.Now.Second) + "-"
                                + string.Format("{0:000}", DateTime.Now.Millisecond) + ".jpg";

                            string DateFormat = string.Format("{0:0000}", DateTime.Now.Year) + "-"
                                + string.Format("{0:00}", DateTime.Now.Month) + "-"
                                + string.Format("{0:00}", DateTime.Now.Day);
                            DirectoryInfo DestDirectory = new DirectoryInfo(Server.MapPath("/Files/Images/Original/" + DateFormat));

                            if (!DestDirectory.Exists)
                            {
                                DestDirectory.Create();
                            }

                            FileUpload1.SaveAs(DestDirectory + "/" + NewFileName);
                            ProgS.IMAGE = DateFormat + "/" + NewFileName;
                        }
                    }
                }
                if (hfvideo.Value.Trim().Length > 5)
                {
                    ProgS.VIDEO = hfvideo.Value.Trim();
                }
                PsSql.Insert(ProgS);
                Response.Redirect("/cp/Programs/Session/" + ProgId.ToString());
            }
            else
            {
                Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql PsSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                Bazaar.BusinessLayer.PROGRAM_SESSIONS ProgS = PsSql.SelectByPrimaryKey(new BusinessLayer.PROGRAM_SESSIONSKeys(Sid));
                ProgS.BODY = txtBody.Text;
                ProgS.NUMBER = int.Parse(txtNumber.Text.Trim());
                ProgS.TITLE = txtTitle.Text.Trim();
                ProgS.DATETIME = DateTime.Parse((Core.Utility.JD2GD(txtDate.Text.Trim()).ToShortDateString() + " " + txtTime.Text.Trim()));
                if (FileUpload1.HasFile)
                {
                    if (Path.GetExtension(FileUpload1.FileName).ToLower() == ".jpg")
                    {
                        System.Drawing.Image imgFile =
                            System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                        if (imgFile.PhysicalDimension.Width == 610 && (imgFile.PhysicalDimension.Height == 343 || imgFile.PhysicalDimension.Height == 342))
                        {
                            string NewFileName =
                                string.Format("{0:00}", DateTime.Now.Hour) + "-"
                                + string.Format("{0:00}", DateTime.Now.Minute) + "-"
                                + string.Format("{0:00}", DateTime.Now.Second) + "-"
                                + string.Format("{0:000}", DateTime.Now.Millisecond) + ".jpg";

                            string DateFormat = string.Format("{0:0000}", DateTime.Now.Year) + "-"
                                + string.Format("{0:00}", DateTime.Now.Month) + "-"
                                + string.Format("{0:00}", DateTime.Now.Day);
                            DirectoryInfo DestDirectory = new DirectoryInfo(Server.MapPath("/Files/Images/Original/" + DateFormat));

                            if (!DestDirectory.Exists)
                            {
                                DestDirectory.Create();
                            }
                            FileUpload1.SaveAs(DestDirectory + "/" + NewFileName);
                            ProgS.IMAGE = DateFormat + "/" + NewFileName;
                        }
                    }

                }
                if (hfvideo.Value.Trim().Length > 5)
                {
                    ProgS.VIDEO = hfvideo.Value.Trim();
                }
                PsSql.Update(ProgS);
                Response.Redirect("/cp/Programs/Session/" + ProgId.ToString());
            }
        }
    }
}