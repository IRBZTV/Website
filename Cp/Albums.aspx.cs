using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Albums : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumsSql = new BusinessLayer.DataLayer.ALBUMSSql();
                List<Bazaar.BusinessLayer.ALBUMS> AlbumsList = AlbumsSql.SelectAll();

                GridView1.DataSource = AlbumsList;
                GridView1.DataBind();
            }
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

         

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Active")
            {
                Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumsSql = new BusinessLayer.DataLayer.ALBUMSSql();
                Bazaar.BusinessLayer.ALBUMS Alb = 
                    AlbumsSql.SelectByPrimaryKey(new BusinessLayer.ALBUMSKeys(int.Parse(e.CommandArgument.ToString())));

                if ((bool)Alb.ACTIVE)
                {
                    Alb.ACTIVE = false;
                }
                else
                {
                    Alb.ACTIVE = true;
                }

                AlbumsSql.Update(Alb);
              
                List<Bazaar.BusinessLayer.ALBUMS> AlbumsList = AlbumsSql.SelectAll();

                GridView1.DataSource = AlbumsList;
                GridView1.DataBind();

            }

            if (e.CommandName == "HomePage")
            {
                Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumsSql = new BusinessLayer.DataLayer.ALBUMSSql();
                Bazaar.BusinessLayer.ALBUMS Alb =
                    AlbumsSql.SelectByPrimaryKey(new BusinessLayer.ALBUMSKeys(int.Parse(e.CommandArgument.ToString())));

                if ((bool)Alb.HomePage)
                {
                    Alb.HomePage = false;
                }
                else
                {
                    Alb.HomePage = true;
                }

                AlbumsSql.Update(Alb);

                List<Bazaar.BusinessLayer.ALBUMS> AlbumsList = AlbumsSql.SelectAll();

                GridView1.DataSource = AlbumsList;
                GridView1.DataBind();

            }

            if (e.CommandName == "DeleteAlbum")
            {
                Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumsSql = new BusinessLayer.DataLayer.ALBUMSSql();

                AlbumsSql.Delete(new BusinessLayer.ALBUMSKeys(int.Parse(e.CommandArgument.ToString())));

                List<Bazaar.BusinessLayer.ALBUMS> AlbumsList = AlbumsSql.SelectAll();

                GridView1.DataSource = AlbumsList;
                GridView1.DataBind();

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Bazaar.BusinessLayer.DataLayer.ALBUMSSql AlbumsSql = new BusinessLayer.DataLayer.ALBUMSSql();
            List<Bazaar.BusinessLayer.ALBUMS> AlbumsList = AlbumsSql.SelectAll();
            GridView1.DataSource = AlbumsList;
            GridView1.DataBind();
        } 
    }
}