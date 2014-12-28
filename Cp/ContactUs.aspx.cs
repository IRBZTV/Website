using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtStartDate.Text = Core.Utility.GD2JD(DateTime.Now);
                txtEndDate.Text = Core.Utility.GD2JD(DateTime.Now);
                LoadRecords();
            }
        }
        protected void LoadRecords()
        {
            DateTime Start = Core.Utility.JD2GD(txtStartDate.Text.Trim());
            DateTime End = Core.Utility.JD2GD(txtEndDate.Text.Trim()).AddMinutes(1439);
            List<Bazaar.BusinessLayer.ContactUs> Lst = Bazaar.BusinessLayer.DataLayer.ContactUs.Select(Start, End);
            gvContents.DataSource = Lst;
            gvContents.DataBind();
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
        protected string SetKind(object KindId)
        {
            switch (KindId.ToString())
            {
                case "1":
                    return "انتقاد";
                case "2":
                    return "پیشنهاد";
                case "3":
                    return "درخواست";
                case "4":
                    return "متفرقه";
                default:
                    return "----";
            }
        }

        protected void gvContents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContents.PageIndex = e.NewPageIndex;
            LoadRecords();
            gvContents.DataBind();
        }
        protected bool CheckFilePath(object FilePath)
        {
            if (FilePath.ToString().Trim().Length > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void BtnLoadNews_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

    }
}