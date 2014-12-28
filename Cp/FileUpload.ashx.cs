using System;
using System.Web;
using System.IO;

namespace FileUploaderSol
{
    /// <summary>
    /// File Upload httphandler to receive files and save them to the server.
    /// </summary>
    public class FileUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string path = "/Files/video";
            String filename = HttpContext.Current.Request.Headers["X-File-Name"];

            if (string.IsNullOrEmpty(filename) && HttpContext.Current.Request.Files.Count <= 0)
            {
                context.Response.Write("{success:false}");
            }
            else
            {


                string NewFileName =
                           string.Format("{0:00}", DateTime.Now.Hour) + "-"
                           + string.Format("{0:00}", DateTime.Now.Minute) + "-"
                           + string.Format("{0:00}", DateTime.Now.Second) + "-"
                           + string.Format("{0:000}", DateTime.Now.Millisecond) + ".flv";

                string DateFormat = string.Format("{0:0000}", DateTime.Now.Year) + "-"
                    + string.Format("{0:00}", DateTime.Now.Month) + "-"
                    + string.Format("{0:00}", DateTime.Now.Day);
                DirectoryInfo DestDirectory = new DirectoryInfo(HttpContext.Current.Server.MapPath("/Files/Video/" + DateFormat));

                if (!DestDirectory.Exists)
                {
                    DestDirectory.Create();
                }

                //  FileUpload2.SaveAs(DestDirectory + "/" + NewFileName);





                string mapPath = HttpContext.Current.Server.MapPath(path);
                //if (Directory.Exists(mapPath) == false)
                //{
                //    Directory.CreateDirectory(mapPath);
                //}

                FileStream fileStream = new FileStream(DestDirectory + "/" + NewFileName, FileMode.OpenOrCreate);

                try
                {
                    Stream inputStream = HttpContext.Current.Request.InputStream;
                    inputStream.CopyTo(fileStream);
                    context.Response.Write("{success:true, name:\"" + filename + "\", path:\"" + path + "/" + filename + "\" , fullname:\"" + DateFormat + "/" + NewFileName + "\"}");

                }
                catch (Exception Exp)
                {
                    context.Response.Write(Exp.Message);
                    // context.Response.Write("{success:false}");
                }
                finally
                {
                    fileStream.Close();
                }

            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


    }
}