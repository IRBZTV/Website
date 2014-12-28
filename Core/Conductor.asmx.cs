using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Bazaar.Core
{
    /// <summary>
    /// Summary description for Conductor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Conductor : System.Web.Services.WebService
    {
        [WebMethod]
        public void DeleteConductors(DateTime Start,DateTime End, string Usr, string Pwd)
        {
            if (Usr == "gASutRUwesW+XEmAhA7ruzaSTuswun" && Pwd == "b_w5t5AkUbuZEn-8h65+z#gespuP!#")
            {
                Bazaar.BusinessLayer.DataLayer.SCHEDULESSql SchSql = new BusinessLayer.DataLayer.SCHEDULESSql();
                SchSql.DeleteStartEnd(Start, End);
            }
        }

        [WebMethod]
        public void InsertConductors(string Title,string Description,string Duration,DateTime Dt,string Url,  string Usr, string Pwd)
        {
            if (Usr == "gASutRUwesW+XEmAhA7ruzaSTuswun" && Pwd == "b_w5t5AkUbuZEn-8h65+z#gespuP!#")
            {
                Bazaar.BusinessLayer.DataLayer.SCHEDULESSql SchSql = new BusinessLayer.DataLayer.SCHEDULESSql();

                Bazaar.BusinessLayer.SCHEDULES Obj = new BusinessLayer.SCHEDULES();
                Obj.DATETIME = Dt;
                Obj.TITLE = Title;
                Obj.URL = Url;
                Obj.VIDEO = Duration;
                Obj.IMAGE = "";
                Obj.DESCRIPTION = Description;

                SchSql.Insert(Obj);


            }
        }
       
    }
}
