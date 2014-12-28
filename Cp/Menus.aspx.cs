using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Menus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DdlMenuKindSelector_SelectedIndexChanged(new object(), new EventArgs());
            }
        }

        protected void DdlMenuKindSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenus();
        }
        protected void LoadMenus()
        {
            Bazaar.BusinessLayer.DataLayer.MENUSSql MenuSql = new BusinessLayer.DataLayer.MENUSSql();
            List<Bazaar.BusinessLayer.MENUS> MenuList = MenuSql.SelectCondition(" kind="+ DdlMenuKindSelector.SelectedValue+" order by sort");

            GridView1.DataSource = MenuList;
            GridView1.DataBind();
        }

        protected void imgBtnSaveMenus_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                 Bazaar.BusinessLayer.DataLayer.MENUSSql MenuSql = new BusinessLayer.DataLayer.MENUSSql();
                 Bazaar.BusinessLayer.MENUS MnObject = MenuSql.SelectByPrimaryKey(new BusinessLayer.MENUSKeys (int.Parse(GridView1.DataKeys[i].Value.ToString())));
                
                TextBox TxtTitle= (TextBox)GridView1.Rows[i].FindControl("txtTitle");
                TextBox txtSort= (TextBox)GridView1.Rows[i].FindControl("txtSort");

                MnObject.TITLE = TxtTitle.Text.Trim();
                MnObject.SORT = byte.Parse(txtSort.Text.Trim());
                 MenuSql.Update(MnObject);

            }
            LoadMenus();
        }
    }
}