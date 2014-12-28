using System;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace Bazaar.Core
{
    public class ThumbnailGenerator
    {
        public static string Generate(string path, int thumbWidth, int thumbHeight)
        {
            string OutPutValue = "/files/images/Bazaar.jpg";
            
            string savePath = "";
            string[] OrigPath = path.Split('/');
            FileInfo ImageFile = new FileInfo(HttpContext.Current.Server.MapPath("/Files/Images/Original/"+path));
            DirectoryInfo ThumbDir = new DirectoryInfo(HttpContext.Current.Server.MapPath("/Files/Images/Thumbnail/" + OrigPath[0].ToString()));
            if (!ThumbDir.Exists)
            {
                ThumbDir.Create();
            }
            
                if (ImageFile.Exists)
                {

                    System.Drawing.Image originalImage = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("/Files/Images/Original/" + path));

                    // Calculate thumbnail Height
                    if (thumbHeight > 0 && thumbWidth > 0)
                    {
                        int tmbHeight = Convert.ToInt32(Math.Round((Convert.ToDouble(thumbWidth) / originalImage.Width) * originalImage.Height));
                        if (tmbHeight > thumbHeight)
                            thumbWidth = Convert.ToInt32(Math.Round((Convert.ToDouble(thumbHeight) / originalImage.Height) * originalImage.Width));
                        else
                            thumbHeight = tmbHeight;

                    }
                    else if (thumbWidth > 0)
                    {
                        thumbHeight = Convert.ToInt32(Math.Round((Convert.ToDouble(thumbWidth) / originalImage.Width) * originalImage.Height));
                    }
                    else if (thumbHeight > 0)
                    {
                        thumbWidth = Convert.ToInt32(Math.Round((Convert.ToDouble(thumbHeight) / originalImage.Height) * originalImage.Width));
                    }
                    else
                    {
                        thumbHeight = 1;
                        thumbWidth = 1;
                    }
                    // create thumbnail image
                    System.Drawing.Image thumbnail = new Bitmap(thumbWidth, thumbHeight, originalImage.PixelFormat);
                    Graphics oGraphic = Graphics.FromImage(thumbnail);

                    //setting drawing properties
                    oGraphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
                    oGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                    oGraphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;

                    Rectangle oRectangle = new Rectangle(0, 0, thumbWidth, thumbHeight);
                    oGraphic.DrawImage(originalImage, oRectangle);


                    savePath = HttpContext.Current.Server.MapPath("/Files/Images/Thumbnail/" + OrigPath[0].ToString() + "/" + Path.GetFileNameWithoutExtension(ImageFile.FullName) + "--" + thumbWidth.ToString()+".jpg");
                    FileInfo DestFile = new FileInfo(savePath);
                    if (!DestFile.Exists)
                    {
                        thumbnail.Save(savePath, ImageFormat.Jpeg);
                        thumbnail.Dispose();
                    }
                    originalImage.Dispose();
                    thumbnail.Dispose();
                    OutPutValue = "/Files/Images/Thumbnail/" + OrigPath[0].ToString() + "/" + Path.GetFileNameWithoutExtension(ImageFile.FullName) + "--" + thumbWidth.ToString() + ".jpg";                  
                

            }

          //  ImageFile.
            return OutPutValue;
        }

    }
}