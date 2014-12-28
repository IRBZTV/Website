using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Albums_Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Load Controls Value
                SetStaticValues();

                int AlbumId = int.Parse(RouteData.Values["AlbumId"].ToString());
                if (AlbumId != 0)
                {
                    Button1.Enabled = true;
                    Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumsSql = new BusinessLayer.DataLayer.ALBUMSSql();
                    Bazaar.BusinessLayer.ALBUMS Alb = AlbumsSql.SelectByPrimaryKey(new BusinessLayer.ALBUMSKeys(AlbumId));

                    txtTitle.Text = Alb.TITLE;
                    txtDescription.Text = Alb.DESCRIPTION;
                    txtPhotographer.Text = Alb.PHOTOGRAPHER;

                    Bazaar.BusinessLayer.DataLayer.ALBUM_PHOTOSSql PhotoSql = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();
                    List<Bazaar.BusinessLayer.ALBUM_PHOTOS> PhotosList = PhotoSql.SelectByField("Album_Id", Alb.ID);
                    GridView1.DataSource = PhotosList;
                    GridView1.DataBind();


                    DdlImagePriority.Items.Clear();
                    for (int i = 0; i < 51; i++)
                    {
                        DdlImagePriority.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }


                    string[] DateNow = Bazaar.Core.Utility.GD2JD((DateTime)Alb.DATETIME).Split('/');

                    DdlYear.SelectedIndex = DdlYear.Items.IndexOf(new ListItem(DateNow[0], DateNow[0]));

                    DdlMonth.SelectedIndex =
                        DdlMonth.Items.IndexOf(new ListItem(string.Format("{0:00}", int.Parse(DateNow[1])),
                            string.Format("{0:00}", int.Parse(DateNow[1]))));

                    DdlDay.SelectedIndex =
                        DdlDay.Items.IndexOf(new ListItem(string.Format("{0:00}", int.Parse(DateNow[2])),
                            string.Format("{0:00}", int.Parse(DateNow[2]))));

                    DdlHour.SelectedIndex =
                       DdlHour.Items.IndexOf(new ListItem(string.Format("{0:00}", ((DateTime)Alb.DATETIME).Hour),
                           string.Format("{0:00}", ((DateTime)Alb.DATETIME).Hour)));

                    DdlMinute.SelectedIndex =
                     DdlMinute.Items.IndexOf(new ListItem(string.Format("{0:00}", ((DateTime)Alb.DATETIME).Minute),
                         string.Format("{0:00}", ((DateTime)Alb.DATETIME).Minute)));



                }
                else
                {
                    Button1.Enabled = false;
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ImageId = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "UpImagePriority")
            {
                Bazaar.BusinessLayer.DataLayer.ALBUM_PHOTOSSql PhotoSql = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();
                Bazaar.BusinessLayer.ALBUM_PHOTOS Pic =
                    PhotoSql.SelectByPrimaryKey(new BusinessLayer.ALBUM_PHOTOSKeys(ImageId));

                if (Pic.PRIORITY >= 0)
                {
                    Pic.PRIORITY += 1;
                    PhotoSql.Update(Pic);
                }
            }
            if (e.CommandName == "DownImagePriority")
            {
                Bazaar.BusinessLayer.DataLayer.ALBUM_PHOTOSSql PhotoSql = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();
                Bazaar.BusinessLayer.ALBUM_PHOTOS Pic =
                    PhotoSql.SelectByPrimaryKey(new BusinessLayer.ALBUM_PHOTOSKeys(ImageId));

                if (Pic.PRIORITY > 0)
                {
                    Pic.PRIORITY -= 1;
                    PhotoSql.Update(Pic);
                }
            }
            if (e.CommandName == "DeleteImage")
            {
                Bazaar.BusinessLayer.DataLayer.ALBUM_PHOTOSSql PhotoSql = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();
                Bazaar.BusinessLayer.ALBUM_PHOTOS Pic =
                    PhotoSql.SelectByPrimaryKey(new BusinessLayer.ALBUM_PHOTOSKeys(ImageId));

                FileInfo Fl = new FileInfo(Server.MapPath("/Files/Images/Original/" + Pic.PATH));
                try
                {
                    PhotoSql.Delete(new BusinessLayer.ALBUM_PHOTOSKeys(ImageId));
                    Fl.SetAccessControl(new System.Security.AccessControl.FileSecurity(Fl.FullName, System.Security.AccessControl.AccessControlSections.All));
                    Fl.Delete();


                }
                catch
                {


                }
            }

            int AlbumId = int.Parse(RouteData.Values["AlbumId"].ToString());
            Bazaar.BusinessLayer.DataLayer.ALBUM_PHOTOSSql PhotoSqls = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();
            List<Bazaar.BusinessLayer.ALBUM_PHOTOS> PhotosList = PhotoSqls.SelectByField("Album_Id", AlbumId);
            GridView1.DataSource = PhotosList;
            GridView1.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int AlbumId = int.Parse(RouteData.Values["AlbumId"].ToString());
            if (AlbumId != 0)
            {
                Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumsSql = new BusinessLayer.DataLayer.ALBUMSSql();
                Bazaar.BusinessLayer.ALBUMS Alb = AlbumsSql.SelectByPrimaryKey(new BusinessLayer.ALBUMSKeys(AlbumId));
                Alb.TITLE = txtTitle.Text;
                Alb.DESCRIPTION = txtDescription.Text;
                Alb.PHOTOGRAPHER = txtPhotographer.Text;



                DateTime CreateTime =
                Bazaar.Core.Utility.JD2GD(DdlYear.SelectedValue + "/" + DdlMonth.SelectedValue + "/" + DdlDay.SelectedValue);
                CreateTime = CreateTime.AddHours(double.Parse(DdlHour.SelectedValue));
                CreateTime = CreateTime.AddMinutes(double.Parse(DdlMinute.SelectedValue));

                Alb.DATETIME = CreateTime;

                AlbumsSql.Update(Alb);
            }
            else
            {
                Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumsSql = new BusinessLayer.DataLayer.ALBUMSSql();
                Bazaar.BusinessLayer.ALBUMS Alb = new BusinessLayer.ALBUMS();
                Alb.TITLE = txtTitle.Text;
                Alb.DESCRIPTION = txtDescription.Text;
                Alb.PHOTOGRAPHER = txtPhotographer.Text;
                DateTime CreateTime =
                 Bazaar.Core.Utility.JD2GD(DdlYear.SelectedValue + "/" + DdlMonth.SelectedValue + "/" + DdlDay.SelectedValue);
                CreateTime = CreateTime.AddHours(double.Parse(DdlHour.SelectedValue));
                CreateTime = CreateTime.AddMinutes(double.Parse(DdlMinute.SelectedValue));

                Alb.DATETIME = CreateTime;
                Alb.ACTIVE = false;
                Alb.HomePage = true;
                int RetId = AlbumsSql.Insert(Alb);
                if (RetId > 0)
                {
                    Response.Redirect("/cp/Albums/Edit/" + RetId.ToString());
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int AlbumId = int.Parse(RouteData.Values["AlbumId"].ToString());
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

                        Bazaar.BusinessLayer.ALBUM_PHOTOS Pic = new BusinessLayer.ALBUM_PHOTOS();
                        Pic.PATH = DateFormat + "/" + NewFileName;
                        Pic.PRIORITY = byte.Parse(DdlImagePriority.SelectedValue);
                        Pic.TITLE = "";
                        Pic.ALBUM_ID = AlbumId;
                        Pic.ACTIVE = true;





                        Bazaar.BusinessLayer.DataLayer.ALBUM_PHOTOSSql PhotoSqls = new BusinessLayer.DataLayer.ALBUM_PHOTOSSql();
                        PhotoSqls.Insert(Pic);
                        List<Bazaar.BusinessLayer.ALBUM_PHOTOS> PhotosList = PhotoSqls.SelectByField("Album_Id", AlbumId);
                        GridView1.DataSource = PhotosList;
                        GridView1.DataBind();

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
        }
        protected void SetStaticValues()
        {
            string[] DateNow = Bazaar.Core.Utility.GD2JD(DateTime.Now).Split('/');


            DdlYear.Items.Clear();
            for (int i = 1391; i < 1400; i++)
            {
                DdlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                if (DateNow[0].ToString().Equals(i.ToString()))
                {
                    DdlYear.SelectedIndex = DdlYear.Items.IndexOf(new ListItem(i.ToString(), i.ToString()));
                }

            }

            DdlMonth.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                DdlMonth.Items.Add(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                if (DateNow[1].ToString().Equals(i.ToString()))
                {
                    DdlMonth.SelectedIndex = DdlMonth.Items.IndexOf(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                }
            }

            DdlDay.Items.Clear();
            for (int i = 1; i < 32; i++)
            {
                DdlDay.Items.Add(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                if (DateNow[2].ToString().Equals(i.ToString()))
                {
                    DdlDay.SelectedIndex = DdlDay.Items.IndexOf(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                }
            }

            DdlHour.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                DdlHour.Items.Add(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                if (DateTime.Now.Hour == i)
                {
                    DdlHour.SelectedIndex = DdlHour.Items.IndexOf(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                }

            }

            DdlMinute.Items.Clear();
            for (int i = 0; i < 60; i++)
            {
                DdlMinute.Items.Add(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                if (DateTime.Now.Minute == i)
                {
                    DdlMinute.SelectedIndex = DdlMinute.Items.IndexOf(new ListItem(string.Format("{0:00}", i), string.Format("{0:00}", i)));
                }
            }
        }
    }
}

