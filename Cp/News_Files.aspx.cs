using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Bazaar.Cp
{
    public partial class News_Files : System.Web.UI.Page
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
            int ImageId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "UpImagePriority")
            {
                Bazaar.BusinessLayer.DataLayer.CONTENT_FILESSql FileSql = new BusinessLayer.DataLayer.CONTENT_FILESSql();
                Bazaar.BusinessLayer.CONTENT_FILES File = FileSql.SelectByPrimaryKey(new BusinessLayer.CONTENT_FILESKeys(ImageId));

                if (File.PRIORITY >= 0)
                {
                    FileSql.UpdatePriority(ImageId, (int)File.PRIORITY + 1);
                }
            }
            if (e.CommandName == "DownImagePriority")
            {
                Bazaar.BusinessLayer.DataLayer.CONTENT_FILESSql FileSql = new BusinessLayer.DataLayer.CONTENT_FILESSql();
                Bazaar.BusinessLayer.CONTENT_FILES File = FileSql.SelectByPrimaryKey(new BusinessLayer.CONTENT_FILESKeys(ImageId));

                if (File.PRIORITY > 0)
                {
                    FileSql.UpdatePriority(ImageId, (int)File.PRIORITY - 1);
                }
            }
            if (e.CommandName == "DeleteImage")
            {
                Bazaar.BusinessLayer.DataLayer.CONTENT_FILESSql FileSql = new BusinessLayer.DataLayer.CONTENT_FILESSql();
                Bazaar.BusinessLayer.CONTENT_FILES Filee = FileSql.SelectByPrimaryKey(new BusinessLayer.CONTENT_FILESKeys(ImageId));
                FileInfo Fl = new FileInfo(Server.MapPath("/Files/Images/Original/" + Filee.PATH));
                try
                {
                    FileSql.Delete(new BusinessLayer.CONTENT_FILESKeys(ImageId));
                    Fl.SetAccessControl(new System.Security.AccessControl.FileSecurity(Fl.FullName, System.Security.AccessControl.AccessControlSections.All));
                    Fl.Delete();


                }
                catch
                {


                }

            }

            LoadImages();
        }
        protected void LoadImages()
        {
            Bazaar.BusinessLayer.DataLayer.CONTENT_FILESSql FileSql = new BusinessLayer.DataLayer.CONTENT_FILESSql();
            List<Bazaar.BusinessLayer.CONTENT_FILES> FilesList =
                FileSql.SelectBy_NewsId_FileType(int.Parse(RouteData.Values["NewsID"].ToString()), 1);

            GridView1.DataSource = FilesList;
            GridView1.DataBind();
            LblError.Text = "محل نمایش خطا";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
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

                        Bazaar.BusinessLayer.CONTENT_FILES NewFile = new BusinessLayer.CONTENT_FILES();
                        NewFile.PATH = DateFormat + "/" + NewFileName;
                        NewFile.PRIORITY = byte.Parse(DdlImagePriority.SelectedValue);
                        NewFile.NEWS_ID = int.Parse(RouteData.Values["NewsID"].ToString());
                        NewFile.TYPE = 1;


                        Bazaar.BusinessLayer.DataLayer.CONTENT_FILESSql FileSql = new BusinessLayer.DataLayer.CONTENT_FILESSql();
                        FileSql.Insert(NewFile);
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