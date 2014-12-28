using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MembershipUserCollection Users = Membership.GetAllUsers();
                GridView1.DataSource = Users;
                GridView1.DataBind();
            }
        }
        protected string GetUserFullName(object UserName)
        {
            string ReturnValue = "";
            Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
            List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", UserName);
            if (UserObj.Count==1)
            {
              ReturnValue= UserObj[0].FULLNAME;
            }
            else
            {
                ReturnValue = "----";
            }
            return ReturnValue;
        }
        protected string BoolToImage(object InValue)
        {
            if (bool.Parse(InValue.ToString()))
            {
                return "~/Cp/Theme/Icon/Yes.png";
            }
            else
            {
                return "~/Cp/Theme/Icon/No.png";
            }
        }
        protected string IsOnline(object InValue)
        {
            if (bool.Parse(InValue.ToString()))
            {
                return "~/Cp/Theme/Icon/globe_Green.png";
            }
            else
            {
                return "~/Cp/Theme/Icon/globe_Gray.png";
            }
        }
        protected string IsLock(object InValue)
        {
            if (bool.Parse(InValue.ToString()))
            {
                return "~/Cp/Theme/Icon/Lock.png";
            }
            else
            {
                return "~/Cp/Theme/Icon/unlock.png";
            }
        }
        protected string EditPage(object InValue)
        {
            string Url = "";
            Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
            List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", InValue);
            if (UserObj.Count == 1)
            {
                Url = "/cp/Users/Edit/" + UserObj[0].USERID;
            }
            return Url;
         }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Active")
            {
                Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
                List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", e.CommandArgument.ToString());


                Guid UserGuid = (Guid)UserObj[0].USERID;
                MembershipUser Usr = Membership.GetUser(UserGuid);
                if (Usr.IsApproved)
                {

                    Usr.IsApproved = false;
                }
                else
                {
                    Usr.IsApproved = true;
                }
                Membership.UpdateUser(Usr);
            }

            if (e.CommandName == "Lock")
            {
                Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
                List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", e.CommandArgument.ToString());

                Guid UserGuid = (Guid)UserObj[0].USERID;
                MembershipUser Usr = Membership.GetUser(UserGuid);
                if (Usr.IsLockedOut)
                {

                    Usr.UnlockUser();
                }
                Membership.UpdateUser(Usr);
            }

            if (e.CommandName == "DeleteUser")
            {
                Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
                List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("USRNM", e.CommandArgument.ToString());
                if (UserObj.Count > 0)
                {
                    Guid UserGuid = (Guid)UserObj[0].USERID;
                    MembershipUser Usr = Membership.GetUser(UserGuid);
                    Membership.DeleteUser(e.CommandArgument.ToString(), true);
                    User_Sql.Delete(new BusinessLayer.USERS_DETAILSKeys(UserObj[0].ID));
                }
            }



            MembershipUserCollection Users = Membership.GetAllUsers();
            GridView1.DataSource = Users;
            GridView1.DataBind();

        }
    }
}