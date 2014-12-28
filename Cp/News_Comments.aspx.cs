using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class News_Comments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadComemnts();
            }
        }
        protected void LoadComemnts()
        {
            int News_Id=int.Parse(RouteData.Values["NewsId"].ToString());

            Bazaar.BusinessLayer.DataLayer.COMMENTSSql ComSql = new BusinessLayer.DataLayer.COMMENTSSql();
            List<Bazaar.BusinessLayer.COMMENTS> ComList = ComSql.SelectByField("NEWS_ID", News_Id);
            gvComments.DataSource = ComList;
            gvComments.DataBind();
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

        protected void gvComments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Active")
            {
                Bazaar.BusinessLayer.DataLayer.COMMENTSSql ComSql = new BusinessLayer.DataLayer.COMMENTSSql();
                Bazaar.BusinessLayer.COMMENTS Com = ComSql.SelectByPrimaryKey(new BusinessLayer.COMMENTSKeys(Id));
                if ((bool)Com.ACTIVE)
                {
                    Com.ACTIVE = false;
                }
                else
                {
                    Com.ACTIVE = true;
                }
                ComSql.Update(Com);
                LoadComemnts();
            }
            if (e.CommandName == "DeleteCom")
            {
                Bazaar.BusinessLayer.DataLayer.COMMENTSSql ComSql = new BusinessLayer.DataLayer.COMMENTSSql();
                ComSql.Delete(new BusinessLayer.COMMENTSKeys(Id));              
                LoadComemnts();
            }
            if (e.CommandName == "SaveContent")
            {
                TextBox TxtCom = (TextBox) gvComments.Rows[int.Parse(e.CommandArgument.ToString())].FindControl("TxtComment");
                int ComId = int.Parse(gvComments.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                Bazaar.BusinessLayer.DataLayer.COMMENTSSql ComSql = new BusinessLayer.DataLayer.COMMENTSSql();
                BusinessLayer.COMMENTS Com = ComSql.SelectByPrimaryKey(new BusinessLayer.COMMENTSKeys(ComId));
                Com.TEXT = TxtCom.Text.Trim();
                ComSql.Update(Com);
                LoadComemnts();
            }
        }

        protected void ImgBtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            LoadComemnts();
        }
    }
}