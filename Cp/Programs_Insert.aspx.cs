using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Programs_Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ProgId = int.Parse(RouteData.Values["ProgramID"].ToString());

            if (!Page.IsPostBack)
            {
                if (ProgId != 0)
                {
                    LoadProgData();
                }
            }
        }
        protected void LoadProgData()
        {
            Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
            Bazaar.BusinessLayer.PROGRAMS Prog = ProgSql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(int.Parse(RouteData.Values["ProgramID"].ToString())));

            Image1.ImageUrl = Bazaar.Core.ThumbnailGenerator.Generate(Prog.IMAGE, 300, 0);
            txtTitle.Text = Prog.TITLE;
            txtBody.Text = Prog.BODY;
            txtDesc.Text = Prog.DESCRIPTION;
            txtRoles.Text = Prog.ROLES;
            TxtId.Text = RouteData.Values["ProgramID"].ToString();
            Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
            List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", User.Identity.Name);
            if (UserObj.Count > 0)
            {
                if ((int)UserObj[0].PROG_ID == 0)
                {

                }
                else
                {
                   // BtnSave.Visible = false;
                }
            }
           // LblError.Text = "محل نمایش خطا";

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
              int ProgId = int.Parse(RouteData.Values["ProgramID"].ToString());

              if (ProgId != 0)
              {
                  Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                  Bazaar.BusinessLayer.PROGRAMS Prog =
                      ProgSql.SelectByPrimaryKey(new BusinessLayer.PROGRAMSKeys(int.Parse(RouteData.Values["ProgramID"].ToString())));
                  Prog.ID = int.Parse(TxtId.Text.Trim());
                  Prog.TITLE = txtTitle.Text.Trim();
                  Prog.BODY = txtBody.Text.Trim();
                  Prog.DESCRIPTION = txtDesc.Text.Trim();
                  Prog.ROLES = txtRoles.Text.Trim();

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
                              Prog.IMAGE = DateFormat + "/" + NewFileName;

                              ProgSql.Update(Prog);

                          }
                          else
                          {
                              LblError.Text = "اندازه عکس انتخاب شده درست  نمی باشد";
                          }
                      }
                      else
                      {
                          LblError.Text = "فرمت تصویر درست نمی باشد";
                      }
                  }
                  else
                  {
                      ProgSql.Update(Prog);
                  }
                
              }
              else
              {
                  int Inserted_ID = 0;
                  Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                  Bazaar.BusinessLayer.PROGRAMS Prog = new BusinessLayer.PROGRAMS();
              

                  Prog.TITLE = txtTitle.Text.Trim();
                  Prog.BODY = txtBody.Text.Trim();
                  Prog.DESCRIPTION = txtDesc.Text.Trim();
                  Prog.ACTIVE = false;
                  Prog.Datetime = DateTime.Now;
                  Prog.HOMEPAGE = true;
                  Prog.IMAGE = "";
                  Prog.ROLES = txtRoles.Text.Trim();
                  Prog.ID = int.Parse(TxtId.Text.Trim());

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
                              Prog.IMAGE = DateFormat + "/" + NewFileName;

                              Inserted_ID = ProgSql.Insert(Prog);

                          }
                          else
                          {
                              LblError.Text = "اندازه عکس انتخاب شده درست  نمی باشد";
                          }
                      }
                      else
                      {
                          LblError.Text = "فرمت تصویر درست نمی باشد";
                      }
                  }
                  else
                  {
                      Inserted_ID= ProgSql.Insert(Prog);
                  }

                  Response.Redirect("/cp/Programs");
                
              }
              LoadProgData();
        }
    }
}