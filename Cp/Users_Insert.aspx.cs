using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Users_Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           

            
            if (!Page.IsPostBack)
            {
                BusinessLayer.DataLayer.PROGRAMSSql ProgSql = new BusinessLayer.DataLayer.PROGRAMSSql();
                List<BusinessLayer.PROGRAMS> ProgLst = ProgSql.SelectAll();

                DdlProg.Items.Clear();
                DdlProg.Items.Add(new ListItem("--------", "0"));
                foreach (BusinessLayer.PROGRAMS item in ProgLst)
                {
                    DdlProg.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }
                DdlProg.SelectedIndex = 0;

                if (RouteData.Values["UserID"].ToString() != "0")
                {
                    Guid UserGuid = Guid.Parse(RouteData.Values["UserID"].ToString());


                    Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
                    List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("UserID", UserGuid);

                    MembershipUser Usr = Membership.GetUser(UserGuid);


                    if (UserObj.Count == 1)
                    {
                        TxtFullName.Text = UserObj[0].FULLNAME;
                        TxtPass.Text = Usr.GetPassword();
                        TxtPassConfirm.Text = Usr.GetPassword();
                        TxtUserName.Text = Usr.UserName;
                        LoadMenus(Usr.UserName);
                        LoadAccess(Usr.UserName);

                        DdlProg.SelectedIndex=DdlProg.Items.IndexOf(DdlProg.Items.FindByValue(UserObj[0].PROG_ID.ToString()));

                        try
                        {
                            RadioProgKind.SelectedIndex = RadioProgKind.Items.IndexOf(RadioProgKind.Items.FindByValue(UserObj[0].PROGKIND.ToString()));
                        }
                        catch 
                        {
                            
                        }
                     

                        // = int.Parse(DdlProg.SelectedValue.ToString());



                    }
                    else
                    {

                    }
                }
                else
                {
                    LoadMenus();
                    LoadAccess();
                }
            }
        }
        protected void LoadMenus(string UserName)
        {
            Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
            Bazaar.BusinessLayer.USERS_DETAILS UserObj = User_Sql.SelectByField("USRNM", UserName)[0];

            long UserMenuSec = long.Parse(UserObj.MENU_SEC);

            Bazaar.BusinessLayer.DataLayer.MENUSSql MenuSql = new BusinessLayer.DataLayer.MENUSSql();
            List<Bazaar.BusinessLayer.MENUS> MenuList = MenuSql.SelectCondition(" pid=0 and kind=1 order by sort");
            foreach (Bazaar.BusinessLayer.MENUS item in MenuList)
            {
                TreeNode Tr = new TreeNode(item.TITLE, item.VALUE);

                if (long.Equals((Convert.ToInt64(UserMenuSec) & (Convert.ToInt64(item.VALUE))), (Convert.ToInt64(item.VALUE))))
                {
                    Tr.Checked = true;
                }
                else
                {
                    Tr.Checked = false;
                }

                List<Bazaar.BusinessLayer.MENUS> SubMenuList = MenuSql.SelectCondition(" pid=" + item.ID + " and kind=1 order by sort ");


                foreach (Bazaar.BusinessLayer.MENUS SubItem in SubMenuList)
                {
                    TreeNode TrChild = new TreeNode(SubItem.TITLE, SubItem.VALUE);

                    if (long.Equals((Convert.ToInt64(UserMenuSec) & (Convert.ToInt64(SubItem.VALUE))), (Convert.ToInt64(SubItem.VALUE))))
                    {
                        TrChild.Checked = true;
                    }
                    else
                    {
                        TrChild.Checked = false;
                    }
                    Tr.ChildNodes.Add(TrChild);
                }
                tvMenus.Nodes.Add(Tr);
            }

        }
        protected void LoadMenus()
        {


            Bazaar.BusinessLayer.DataLayer.MENUSSql MenuSql = new BusinessLayer.DataLayer.MENUSSql();
            List<Bazaar.BusinessLayer.MENUS> MenuList = MenuSql.SelectCondition(" pid=0  and kind=1 order  by sort");
            foreach (Bazaar.BusinessLayer.MENUS item in MenuList)
            {
                TreeNode Tr = new TreeNode(item.TITLE, item.VALUE);


                List<Bazaar.BusinessLayer.MENUS> SubMenuList = MenuSql.SelectCondition(" pid=" + item.ID + " and kind=1 order by sort ");


                foreach (Bazaar.BusinessLayer.MENUS SubItem in SubMenuList)
                {
                    TreeNode TrChild = new TreeNode(SubItem.TITLE, SubItem.VALUE);


                    Tr.ChildNodes.Add(TrChild);
                }
                tvMenus.Nodes.Add(Tr);
            }

        }

        protected void LoadAccess(string UserName)
        {
            Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
            Bazaar.BusinessLayer.USERS_DETAILS UserObj = User_Sql.SelectByField("USRNM", UserName)[0];

            long UserAccessSec = long.Parse(UserObj.ACCESS_SEC);

            Bazaar.BusinessLayer.DataLayer.ACCESSSql ACCESSSql = new BusinessLayer.DataLayer.ACCESSSql();
            List<Bazaar.BusinessLayer.ACCESS> ACCESSSqlList = ACCESSSql.SelectAll();
            foreach (Bazaar.BusinessLayer.ACCESS item in ACCESSSqlList)
            {
                TreeNode Tr = new TreeNode(item.TITLE, item.VALUE);

                if (long.Equals((Convert.ToInt64(UserAccessSec) & (Convert.ToInt64(item.VALUE))), (Convert.ToInt64(item.VALUE))))
                {
                    Tr.Checked = true;
                }

                tvAccess.Nodes.Add(Tr);
            }

        }
        protected void LoadAccess()
        {

            Bazaar.BusinessLayer.DataLayer.ACCESSSql ACCESSSql = new BusinessLayer.DataLayer.ACCESSSql();
            List<Bazaar.BusinessLayer.ACCESS> ACCESSSqlList = ACCESSSql.SelectAll();

            foreach (Bazaar.BusinessLayer.ACCESS item in ACCESSSqlList)
            {
                TreeNode Tr = new TreeNode(item.TITLE, item.VALUE);


                tvAccess.Nodes.Add(Tr);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (RouteData.Values["UserID"].ToString() != "0")
            {
                Guid UserGuid = Guid.Parse(RouteData.Values["UserID"].ToString());


                Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
                List<Bazaar.BusinessLayer.USERS_DETAILS> UserObj = User_Sql.SelectByField("UserID", UserGuid);

              

                MembershipUser Usr = Membership.GetUser(UserGuid);
                if (TxtPass.Text.Trim() == TxtPassConfirm.Text.Trim())
                {
                    if (Usr.GetPassword() != TxtPass.Text.Trim())
                    {
                        Usr.ChangePassword(Usr.GetPassword(), TxtPass.Text.Trim());
                    }
                }
                if (UserObj.Count == 1)
                {
                    if (TxtFullName.Text.Trim().Length > 0)
                    {
                        UserObj[0].FULLNAME = TxtFullName.Text.Trim();

                    }

                    long MenuSec = 0;
                    foreach (TreeNode item in tvMenus.Nodes)
                    {

                        if (item.Checked)
                        {
                            MenuSec += long.Parse(item.Value);
                            foreach (TreeNode itemChild in item.ChildNodes)
                            {
                                if (itemChild.Checked)
                                {
                                    MenuSec += long.Parse(itemChild.Value);
                                }
                            }
                        }

                    }
                    UserObj[0].MENU_SEC = MenuSec.ToString();
                    UserObj[0].PROG_ID = int.Parse(DdlProg.SelectedValue.ToString());
                    UserObj[0].PROGKIND = short.Parse(RadioProgKind.SelectedValue.ToString());




                    long AccessSec = 0;
                    foreach (TreeNode item2 in tvAccess.Nodes)
                    {
                        if (item2.Checked)
                        {
                            AccessSec += long.Parse(item2.Value);
                        }
                        foreach (TreeNode itemChild2 in item2.ChildNodes)
                        {
                            if (itemChild2.Checked)
                            {
                                AccessSec += long.Parse(itemChild2.Value);
                            }
                        }
                    }
                    UserObj[0].ACCESS_SEC = AccessSec.ToString();







                    User_Sql.Update(UserObj[0]);

                }
            }

            else
            {
                Bazaar.BusinessLayer.DataLayer.USERS_DETAILSSql User_Sql = new BusinessLayer.DataLayer.USERS_DETAILSSql();
                Bazaar.BusinessLayer.USERS_DETAILS UserObj = new BusinessLayer.USERS_DETAILS();

                MembershipUser Usr;
                if (TxtPass.Text.Trim() == TxtPassConfirm.Text.Trim())
                {
                    if (TxtUserName.Text.Trim().Length > 0)
                    {
                        Usr = Membership.CreateUser(TxtUserName.Text.Trim(), TxtPass.Text.Trim());
                        UserObj.USERID = Guid.Parse(Usr.ProviderUserKey.ToString());
                    }
                }



                if (TxtFullName.Text.Trim().Length > 0)
                {
                    UserObj.FULLNAME = TxtFullName.Text.Trim();

                }
                UserObj.USRNM = TxtUserName.Text;

                long MenuSec = 0;
                foreach (TreeNode item in tvMenus.Nodes)
                {

                    if (item.Checked)
                    {
                        MenuSec += long.Parse(item.Value);
                        foreach (TreeNode itemChild in item.ChildNodes)
                        {
                            MenuSec += long.Parse(itemChild.Value);
                        }
                    }

                }
                UserObj.MENU_SEC = MenuSec.ToString();


                long AccessSec = 0;
                foreach (TreeNode item2 in tvAccess.Nodes)
                {
                    if (item2.Checked)
                    {
                        AccessSec += long.Parse(item2.Value);
                    }
                    foreach (TreeNode itemChild2 in item2.ChildNodes)
                    {
                        AccessSec += long.Parse(itemChild2.Value);
                    }
                }
                UserObj.ACCESS_SEC = AccessSec.ToString();

                User_Sql.Insert(UserObj);
                Response.Redirect("/cp/users");

            }

        }
    }
}

