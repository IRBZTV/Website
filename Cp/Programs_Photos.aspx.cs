using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Programs_Photos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DdlImagePriority.Items.Clear();
                for (int i = 0; i < 51; i++)
                {
                    DdlImagePriority.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                LoadImages();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
             Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
              List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", User.Identity.Name);
              if (UserObj.Count > 0)
              {
                  if ((int)UserObj[0].PROG_ID == 0)
                  {
                      int ImageId = int.Parse(e.CommandArgument.ToString());

                      if (e.CommandName == "UpImagePriority")
                      {
                          Bazaar.BusinessLayer.DataLayer.PROGRAM_PHOTOSSql ProgPhotosSql = new BusinessLayer.DataLayer.PROGRAM_PHOTOSSql();
                          Bazaar.BusinessLayer.PROGRAM_PHOTOS File = ProgPhotosSql.SelectByPrimaryKey(new BusinessLayer.PROGRAM_PHOTOSKeys(ImageId));

                          if (File.PRIORITY >= 0)
                          {
                              File.PRIORITY += 1;
                              ProgPhotosSql.Update(File);
                          }
                      }
                      if (e.CommandName == "DownImagePriority")
                      {
                          Bazaar.BusinessLayer.DataLayer.PROGRAM_PHOTOSSql ProgPhotosSql = new BusinessLayer.DataLayer.PROGRAM_PHOTOSSql();
                          Bazaar.BusinessLayer.PROGRAM_PHOTOS File = ProgPhotosSql.SelectByPrimaryKey(new BusinessLayer.PROGRAM_PHOTOSKeys(ImageId));

                          if (File.PRIORITY > 0)
                          {
                              File.PRIORITY -= 1;
                              ProgPhotosSql.Update(File);
                          }
                      }
                      if (e.CommandName == "DeleteImage")
                      {
                          Bazaar.BusinessLayer.DataLayer.PROGRAM_PHOTOSSql ProgPhotosSql = new BusinessLayer.DataLayer.PROGRAM_PHOTOSSql();
                          Bazaar.BusinessLayer.PROGRAM_PHOTOS File = ProgPhotosSql.SelectByPrimaryKey(new BusinessLayer.PROGRAM_PHOTOSKeys(ImageId));

                          FileInfo Fl = new FileInfo(Server.MapPath("/Files/Images/Original/" + File.PATH));
                          try
                          {
                              ProgPhotosSql.Delete(new BusinessLayer.PROGRAM_PHOTOSKeys(ImageId));
                              Fl.SetAccessControl(new System.Security.AccessControl.FileSecurity(Fl.FullName, System.Security.AccessControl.AccessControlSections.All));
                              Fl.Delete();


                          }
                          catch
                          {


                          }

                      }

                      LoadImages();
                  }
              }


         
        }
        protected void LoadImages()
        {
            Bazaar.BusinessLayer.DataLayer.PROGRAM_PHOTOSSql ProgPhotosSql = new BusinessLayer.DataLayer.PROGRAM_PHOTOSSql();
            List<Bazaar.BusinessLayer.PROGRAM_PHOTOS> Photos =
                ProgPhotosSql.SelectByField("PID", RouteData.Values["PID"]);

            GridView1.DataSource = Photos;
            GridView1.DataBind();
            LblError.Text = "محل نمایش خطا";
            Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
            List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", User.Identity.Name);
            if (UserObj.Count > 0)
            {
                if ((int)UserObj[0].PROG_ID == 0)
                {

                }
                else
                {
                    Button1.Visible = false;                   
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (Path.GetExtension(FileUpload1.FileName).ToLower() == ".jpg")
                {
                    System.Drawing.Image imgFile =
System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                    if (imgFile.PhysicalDimension.Width == 610 && (imgFile.PhysicalDimension.Height == 343 ||  imgFile.PhysicalDimension.Height == 342))
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

                        Bazaar.BusinessLayer.PROGRAM_PHOTOS NewFile = new BusinessLayer.PROGRAM_PHOTOS();
                        NewFile.PATH = DateFormat + "/" + NewFileName;
                        NewFile.PRIORITY = byte.Parse(DdlImagePriority.SelectedValue);
                        NewFile.PID = int.Parse(RouteData.Values["PID"].ToString());



                        Bazaar.BusinessLayer.DataLayer.PROGRAM_PHOTOSSql ProgPhotosSql = new BusinessLayer.DataLayer.PROGRAM_PHOTOSSql();
                        ProgPhotosSql.Insert(NewFile);
                        LoadImages();

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
                LblError.Text = "لطفا از سیستم خود یک تصویر را برای ارسال انتخاب کنید";
            }

        }
    }
}