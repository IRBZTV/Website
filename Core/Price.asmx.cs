using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Bazaar.Core
{
    /// <summary>
    /// Summary description for Price
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Price : System.Web.Services.WebService
    {
      
        [WebMethod]
        public  void DeletePrices(string Usr,string Pwd)
        {
            if (Usr == "gASutRUwesW+XEmAhA7ruzaSTuswun" && Pwd == "b_w5t5AkUbuZEn-8h65+z#gespuP!#")
            {
                Bazaar.BusinessLayer.DataLayer.ECONOMY_TREESql EcoSql = new BusinessLayer.DataLayer.ECONOMY_TREESql();
                EcoSql.DeleteAll();
                Bazaar.BusinessLayer.DataLayer.STATISTIC_VALSql Stval = new BusinessLayer.DataLayer.STATISTIC_VALSql();
                Stval.DeleteAll();
            }
        }


        [WebMethod]
        public int InsertTree(string Title, short Priority, string Usr, string Pwd)
        {
            if (Usr == "gASutRUwesW+XEmAhA7ruzaSTuswun" && Pwd == "b_w5t5AkUbuZEn-8h65+z#gespuP!#")
            {
                Bazaar.BusinessLayer.DataLayer.ECONOMY_TREESql EcoSql = new BusinessLayer.DataLayer.ECONOMY_TREESql();

                Bazaar.BusinessLayer.ECONOMY_TREE EcoTreeObj = new BusinessLayer.ECONOMY_TREE();
                EcoTreeObj.DATETIME = DateTime.Now;
                EcoTreeObj.PRIORITY = byte.Parse(Priority.ToString());
                EcoTreeObj.TITLE = Title;
                EcoTreeObj.UNIT = "";
                return int.Parse(EcoSql.Insert(EcoTreeObj).ToString());
            }
            else
            { return 0; }

        }

        [WebMethod]
        public void InsertValue(string Title, string Value, string Diff, string Unit, int GroupId, string Usr, string Pwd)
        {
            if (Usr == "gASutRUwesW+XEmAhA7ruzaSTuswun" && Pwd == "b_w5t5AkUbuZEn-8h65+z#gespuP!#")
            {
                Bazaar.BusinessLayer.DataLayer.STATISTIC_VALSql EcoSql = new BusinessLayer.DataLayer.STATISTIC_VALSql();

                Bazaar.BusinessLayer.STATISTIC_VAL ValObj = new BusinessLayer.STATISTIC_VAL();
                ValObj.DIFF = Diff;
                ValObj.GROUPID = GroupId;
                ValObj.TITLE = Title;
                ValObj.UNIT = Unit;
                ValObj.VAL = Value;


                EcoSql.Insert(ValObj);
            }
        }
    }
}
