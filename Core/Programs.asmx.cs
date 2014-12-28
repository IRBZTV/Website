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
    public class Programs : System.Web.Services.WebService
    {
        [WebMethod]
        public int IsProgExist(int ProgId, string Usr, string Pwd)
        {
            if (Usr == "gASutRUwesW+XEmAhA7ruzaSTuswun" && Pwd == "b_w5t5AkUbuZEn-8h65+z#gespuP!#")
            {
                Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                List<Bazaar.BusinessLayer.PROGRAMS> ProgList = ProgSql.SelectByField("ID", ProgId);
                if (ProgList.Count > 0)
                { return ProgList[0].ID; }
                else
                { return 0; }
            }
            else
            { return -1; }
        }
        [WebMethod]
        public int ProgData(int ProgId, string TITLE, string DESCRIPTION, string ROLES, string IMAGE, bool HOMEPAGE, bool ACTIVE, DateTime Datetime, int Priority, string BODY, bool IsInsert, string Usr, string Pwd,short Kind)
        {
            if (Usr == "gASutRUwesW+XEmAhA7ruzaSTuswun" && Pwd == "b_w5t5AkUbuZEn-8h65+z#gespuP!#")
            {
                Bazaar.BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                Bazaar.BusinessLayer.PROGRAMS Prog = new BusinessLayer.PROGRAMS();
                Prog.ACTIVE = ACTIVE;
                Prog.BODY = BODY;
                Prog.Datetime = Datetime;
                Prog.DESCRIPTION = DESCRIPTION;
                Prog.HOMEPAGE = HOMEPAGE;
                Prog.ID = ProgId;
                Prog.IMAGE = IMAGE;
                Prog.PRIORITY = Priority;
                Prog.ROLES = ROLES;
                Prog.TITLE = TITLE;
                Prog.Kind = Kind;
                if (IsInsert)
                {
                    ProgSql.Insert(Prog);
                }
                else
                {
                    ProgSql.Update(Prog);
                }
                return Prog.ID;
            }
            else
            {
                return -1;
            }
        }
        [WebMethod]
        public int IsSessionExist(int ProgId, int SessionNumber, string Usr, string Pwd)
        {
            if (Usr == "gASutRUwesW+XEmAhA7ruzaSTuswun" && Pwd == "b_w5t5AkUbuZEn-8h65+z#gespuP!#")
            {
                Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql ProgSessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                List<Bazaar.BusinessLayer.PROGRAM_SESSIONS> ProgSessionList = ProgSessionSql.SelectByProgIDSessionNumber(ProgId, SessionNumber);
                if (ProgSessionList.Count > 0)
                { return ProgSessionList[0].ID; }
                else
                { return 0; }
            }
            else
            { return -1; }
        }

        [WebMethod]
        public bool SessionData(int ProgId, int SessionNumber, string Title, DateTime Datetime, string BODY, string VIDEO, string Image, bool Active, int Savemonth, bool IsInsert, string Usr, string Pwd,int SaveDays)
        {
            if (Usr == "gASutRUwesW+XEmAhA7ruzaSTuswun" && Pwd == "b_w5t5AkUbuZEn-8h65+z#gespuP!#")
            {
                Bazaar.BusinessLayer.DataLayer.PROGRAM_SESSIONSSql ProgSessionSql = new BusinessLayer.DataLayer.PROGRAM_SESSIONSSql();
                Bazaar.BusinessLayer.PROGRAM_SESSIONS ProgSession = new BusinessLayer.PROGRAM_SESSIONS();

                ProgSession.ACTIVE = Active;
                ProgSession.BODY = BODY;
                ProgSession.DATETIME = Datetime;
                ProgSession.IMAGE = Image;
                ProgSession.NUMBER = SessionNumber;
                ProgSession.PROG_ID = ProgId;
                ProgSession.TITLE = Title;
                ProgSession.VIDEO = VIDEO;
                ProgSession.SaveDays = SaveDays;

                if (IsInsert)
                {
                    ProgSessionSql.Insert(ProgSession);
                }
                else
                {
                    ProgSessionSql.Update(ProgSession);
                }
                return true;

            }
            else
            { return false; }
        }

    }
}
