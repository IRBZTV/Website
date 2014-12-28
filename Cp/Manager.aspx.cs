using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bazaar.Cp
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ModuleId = int.Parse(RouteData.Values["ModuleId"].ToString());
            if (!Page.IsPostBack)
            {

                DdlModuleContainer.Items.Clear();
                DdlModuleContainer.Items.Add(new ListItem("نمایش عنوان", "Title"));
                DdlModuleContainer.Items.Add(new ListItem("نمایش عنوان و تاریخ", "TitleTime"));
                DdlModuleContainer.Items.Add(new ListItem("نمایش خط", "Line"));
                DdlModuleContainer.Items.Add(new ListItem("بدون قالب", "None"));

                Bazaar.BusinessLayer.DataLayer.PAGESql PagesSql = new BusinessLayer.DataLayer.PAGESql();
                List<Bazaar.BusinessLayer.PAGE> PagesList = PagesSql.SelectAll();

                DdlPages.Items.Clear();
                foreach (Bazaar.BusinessLayer.PAGE item in PagesList)
                {
                    DdlPages.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }
                DdlPages_SelectedIndexChanged(new object(), new EventArgs());


                Bazaar.BusinessLayer.DataLayer.MODULESSql ModulesSql = new BusinessLayer.DataLayer.MODULESSql();
                List<Bazaar.BusinessLayer.MODULES> ModuleList = ModulesSql.SelectAll();

                DdlModules.Items.Clear();
                foreach (Bazaar.BusinessLayer.MODULES item in ModuleList)
                {
                    DdlModules.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                }
                //DdlModules_SelectedIndexChanged(new object(), new EventArgs());


                if (ModuleId != 0)
                {
                    Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql PageModules_Sql =
                   new BusinessLayer.DataLayer.PAGE_MODULESSql();

                    Bazaar.BusinessLayer.PAGE_MODULES Md = PageModules_Sql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULESKeys(ModuleId));

                    DdlPages.SelectedIndex = DdlPages.Items.IndexOf(DdlPages.Items.FindByValue(Md.PAGE_ID.ToString()));
                    DdlPages_SelectedIndexChanged(new object(), new EventArgs());
                    DdlPagePositions.SelectedIndex = DdlPagePositions.Items.IndexOf(DdlPagePositions.Items.FindByValue(Md.POSITION_ID.ToString()));
                    DdlModules.SelectedIndex = DdlModules.Items.IndexOf(DdlModules.Items.FindByValue(Md.MODULE_ID.ToString()));
                    DdlModuleContainer.SelectedIndex = DdlModuleContainer.Items.IndexOf(DdlModuleContainer.Items.FindByValue(Md.CONTAINER_LAYOUT.ToString()));
                    DdlModules_SelectedIndexChanged(new object(), new EventArgs());



                    DdlTemplates.SelectedIndex = DdlTemplates.Items.IndexOf(DdlTemplates.Items.FindByText(Md.TEMPLATE.ToString()));
                    DdlModules.Enabled = false;
                    txtModuleTitle.Text = Md.TITLE;

                }
                else
                {
                    DdlModules_SelectedIndexChanged(new object(), new EventArgs());
                }


            }
        }
        protected void LoadPositions()
        {
            Bazaar.BusinessLayer.DataLayer.PAGE_POSITIONSSql PagesPosSql = new BusinessLayer.DataLayer.PAGE_POSITIONSSql();
            List<Bazaar.BusinessLayer.PAGE_POSITIONS> PagesPosList = PagesPosSql.SelectByField("PAGE_ID", DdlPages.SelectedValue);

            DdlPagePositions.Items.Clear();
            foreach (Bazaar.BusinessLayer.PAGE_POSITIONS item in PagesPosList)
            {
                DdlPagePositions.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
            }

            if (int.Parse(RouteData.Values["ModuleId"].ToString()) != 0)
            {
                Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql PageModules_Sql =
               new BusinessLayer.DataLayer.PAGE_MODULESSql();

                Bazaar.BusinessLayer.PAGE_MODULES Md = PageModules_Sql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULESKeys(int.Parse(RouteData.Values["ModuleId"].ToString())));


                DdlPagePositions.SelectedIndex = DdlPagePositions.Items.IndexOf(DdlPagePositions.Items.FindByValue(Md.POSITION_ID.ToString()));
            }
        }

        protected void DdlPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPositions();

        }

        protected void DdlModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bazaar.BusinessLayer.DataLayer.MODULES_PARAMETERSSql ModulesParamSql = new BusinessLayer.DataLayer.MODULES_PARAMETERSSql();
            List<Bazaar.BusinessLayer.MODULES_PARAMETERS> ModulePramList = ModulesParamSql.SelectByField("Module_Id", DdlModules.SelectedValue);


            Bazaar.BusinessLayer.DataLayer.MODULES_TEMPLATESSql Temp_Sql = new BusinessLayer.DataLayer.MODULES_TEMPLATESSql();
            List<Bazaar.BusinessLayer.MODULES_TEMPLATES> Temp_List = Temp_Sql.SelectByField("Module_Id", DdlModules.SelectedValue);

            DdlTemplates.Items.Clear();
            foreach (Bazaar.BusinessLayer.MODULES_TEMPLATES item in Temp_List)
            {
                DdlTemplates.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));


            }




            GvModulesParams.DataSource = ModulePramList;
            GvModulesParams.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int ModuleId = int.Parse(RouteData.Values["ModuleId"].ToString());
            string Value = "";
            if (ModuleId == 0)
            {
                //Insert New Module + Config



                Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql PageModules_Sql =
                      new BusinessLayer.DataLayer.PAGE_MODULESSql();

                Bazaar.BusinessLayer.PAGE_MODULES Md = new BusinessLayer.PAGE_MODULES();

                Md.POSITION_ID = int.Parse(DdlPagePositions.SelectedValue);
                Md.TEMPLATE = DdlTemplates.SelectedItem.Text;
                Md.TITLE = txtModuleTitle.Text.Trim();
                Md.MODULE_ID = int.Parse(DdlModules.SelectedValue);
                Md.CONTAINER_LAYOUT = "2";
                Md.SORT = 0;
                Md.PAGE_ID = int.Parse(DdlPages.SelectedValue);
                Md.CONTAINER_LAYOUT = DdlModuleContainer.SelectedValue;
                Md.VISIBLE = false;



                ModuleId = PageModules_Sql.Insert(Md);



                for (int i = 0; i < GvModulesParams.Rows.Count; i++)
                {
                    //  DropDownList Ddl = (DropDownList)GvModulesParams.Rows[i].Cells[0].FindControl("DdlPolID");
                    string Kind = ((Label)GvModulesParams.Rows[i].Cells[2].FindControl("LblParamKind")).Text;

                    // e.Row.Cells[1].Text = "*" + Kind;
                    switch (Kind)
                    {
                        case "Poll_Id":
                            DropDownList Ddl = (DropDownList)GvModulesParams.Rows[i].FindControl("DdlPolID");
                            Value = Ddl.SelectedValue;
                            break;


                        case "Vertical":
                            RadioButtonList Rbl = (RadioButtonList)GvModulesParams.Rows[i].FindControl("RlbVertical");
                            Value = Rbl.SelectedValue;
                            break;



                        case "ImageWidth":
                            TextBox Txt = (TextBox)GvModulesParams.Rows[i].FindControl("TxtImageWidth");
                            Value = Txt.Text.Trim();
                            break;

                        case "Count":
                            DropDownList DdlCount = (DropDownList)GvModulesParams.Rows[i].FindControl("DdlCount");
                            Value = DdlCount.SelectedValue;
                            break;


                        case "CategoryId":
                            DropDownList DdlCat = (DropDownList)GvModulesParams.Rows[i].FindControl("DdlCat");
                            Value = DdlCat.SelectedValue;
                            break;


                        case "BodyText":
                            CKEditor.NET.CKEditorControl Editor = (CKEditor.NET.CKEditorControl)GvModulesParams.Rows[i].FindControl("EditorCk"); ;
                            Value = Editor.Text;
                            break;

                        case "ActiveMenuTabId":
                            DropDownList DdlActiveMenu = (DropDownList)GvModulesParams.Rows[i].FindControl("DdlActiveMenu");
                            Value = DdlActiveMenu.SelectedValue;
                            break;

                        case "ProgKind":
                            RadioButtonList Rbl2 = (RadioButtonList)GvModulesParams.Rows[i].FindControl("RlbProgKind");
                            Value = Rbl2.SelectedValue;
                            break;

                        default:
                            break;
                    }



                    Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql pmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                    Bazaar.BusinessLayer.PAGE_MODULES_CONFIG Config = new BusinessLayer.PAGE_MODULES_CONFIG();

                    Config.VALUE = Value;
                    Config.MODULE_PARAM_ID = int.Parse(GvModulesParams.DataKeys[i].Value.ToString());
                    Config.PAGE_MODULE_ID = ModuleId;
                    Config.PARAM_TITLE = ((Label)GvModulesParams.Rows[i].Cells[2].FindControl("LblParamKind")).Text;
                    pmConfigSql.Insert(Config);


                }

                Response.Redirect("/cp/modules");

            }
            else
            {
                //Update Module + Config
                for (int i = 0; i < GvModulesParams.Rows.Count; i++)
                {
                    //  DropDownList Ddl = (DropDownList)GvModulesParams.Rows[i].Cells[0].FindControl("DdlPolID");
                    string Kind = ((Label)GvModulesParams.Rows[i].Cells[2].FindControl("LblParamKind")).Text;

                    // e.Row.Cells[1].Text = "*" + Kind;
                    switch (Kind)
                    {
                        case "Poll_Id":
                            DropDownList Ddl = (DropDownList)GvModulesParams.Rows[i].FindControl("DdlPolID");
                            Value = Ddl.SelectedValue;
                            break;


                        case "Vertical":
                            RadioButtonList Rbl = (RadioButtonList)GvModulesParams.Rows[i].FindControl("RlbVertical");
                            Value = Rbl.SelectedValue;
                            break;



                        case "ImageWidth":
                            TextBox Txt = (TextBox)GvModulesParams.Rows[i].FindControl("TxtImageWidth");
                            Value = Txt.Text.Trim();
                            break;

                        case "Count":
                            DropDownList DdlCount = (DropDownList)GvModulesParams.Rows[i].FindControl("DdlCount");
                            Value = DdlCount.SelectedValue;
                            break;


                        case "CategoryId":
                            DropDownList DdlCat = (DropDownList)GvModulesParams.Rows[i].FindControl("DdlCat");
                            Value = DdlCat.SelectedValue;
                            break;

                        case "BodyText":
                            CKEditor.NET.CKEditorControl Editor = (CKEditor.NET.CKEditorControl)GvModulesParams.Rows[i].FindControl("EditorCk"); ;
                            Value = Editor.Text;
                            break;

                        case "ActiveMenuTabId":
                            DropDownList DdlActiveMenu = (DropDownList)GvModulesParams.Rows[i].FindControl("DdlActiveMenu");
                            Value = DdlActiveMenu.SelectedValue;
                            break;
                        case "ProgKind":
                            RadioButtonList Rbl2 = (RadioButtonList)GvModulesParams.Rows[i].FindControl("RlbProgKind");
                            Value = Rbl2.SelectedValue;
                            break;

                        default:
                            break;
                    }

                    if (((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value != "0")
                    {
                        int Id = int.Parse(((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value.ToString());

                        Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql pmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                        Bazaar.BusinessLayer.PAGE_MODULES_CONFIG Config = pmConfigSql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULES_CONFIGKeys(Id));

                        Config.VALUE = Value;
                        pmConfigSql.Update(Config);

                    }
                    else
                    {
                        Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql pmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                        Bazaar.BusinessLayer.PAGE_MODULES_CONFIG Config = new BusinessLayer.PAGE_MODULES_CONFIG();

                        Config.VALUE = Value;
                        Config.MODULE_PARAM_ID = int.Parse(GvModulesParams.DataKeys[i].Value.ToString());
                        Config.PAGE_MODULE_ID = ModuleId;
                        Config.PARAM_TITLE = ((Label)GvModulesParams.Rows[i].Cells[2].FindControl("LblParamKind")).Text;
                        pmConfigSql.Insert(Config);
                    }
                }



                Bazaar.BusinessLayer.DataLayer.PAGE_MODULESSql PageModules_Sql =
                      new BusinessLayer.DataLayer.PAGE_MODULESSql();

                Bazaar.BusinessLayer.PAGE_MODULES Md = PageModules_Sql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULESKeys(ModuleId));
                Md.PAGE_ID = int.Parse(DdlPages.SelectedValue);

                Md.POSITION_ID = int.Parse(DdlPagePositions.SelectedValue);
                Md.TEMPLATE = DdlTemplates.SelectedItem.Text;
                Md.TITLE = txtModuleTitle.Text.Trim();
                Md.CONTAINER_LAYOUT = DdlModuleContainer.SelectedValue;


                PageModules_Sql.Update(Md);
            }


        }

        protected void GvModulesParams_DataBound(object sender, EventArgs e)
        {


            int ModuleId = int.Parse(RouteData.Values["ModuleId"].ToString());

            for (int i = 0; i < GvModulesParams.Rows.Count; i++)
            {
                ((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value = "0";

                string Kind = "---";

                Kind = ((Label)GvModulesParams.Rows[i].FindControl("LblParamKind")).Text;

                // e.Row.Cells[1].Text = "*" + Kind;
                switch (Kind)
                {
                    case "Poll_Id":
                        DropDownList Ddl = new DropDownList();
                        Ddl.ID = "DdlPolID";
                        Ddl.EnableViewState = true;

                        Ddl.ViewStateMode = System.Web.UI.ViewStateMode.Enabled;
                        Ddl.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                        Bazaar.BusinessLayer.DataLayer.POLLSSql PollSql = new BusinessLayer.DataLayer.POLLSSql();
                        List<Bazaar.BusinessLayer.POLLS> Polls = PollSql.SelectAll();
                        Ddl.Items.Clear();
                        foreach (Bazaar.BusinessLayer.POLLS PollItem in Polls)
                        {
                            Ddl.Items.Add(new ListItem(PollItem.TITLE, PollItem.ID.ToString()));
                        }

                        if (ModuleId != 0)
                        {
                            Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql PmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                            Bazaar.BusinessLayer.PAGE_MODULES_CONFIG PmConfig = PmConfigSql.Select_Parameters_Value(Kind, ModuleId);
                            Ddl.SelectedIndex = Ddl.Items.IndexOf(Ddl.Items.FindByValue(PmConfig.VALUE.ToString()));
                            ((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value = PmConfig.ID.ToString();
                        }


                        GvModulesParams.Rows[i].Cells[0].Controls.Add(Ddl);
                        break;


                    case "Vertical":
                        RadioButtonList Rbl = new RadioButtonList();
                        Rbl.ID = "RlbVertical";
                        //Rbl.CssClass = "DdlControl";
                        Rbl.RepeatDirection = RepeatDirection.Horizontal;
                        Rbl.Items.Add(new ListItem("عمودی", "false"));
                        Rbl.Items.Add(new ListItem("افقی", "true"));
                        //Rbl.SelectedIndex = 1;

                        if (ModuleId != 0)
                        {
                            Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql PmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                            Bazaar.BusinessLayer.PAGE_MODULES_CONFIG PmConfig = PmConfigSql.Select_Parameters_Value(Kind, ModuleId);
                            try
                            {
                                Rbl.SelectedIndex = Rbl.Items.IndexOf(Rbl.Items.FindByValue(PmConfig.VALUE.ToString()));
                                ((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value = PmConfig.ID.ToString();
                            }
                            catch
                            {
                            }
                        }


                        GvModulesParams.Rows[i].Cells[0].Controls.Add(Rbl);
                        break;

                    case "ImageWidth":
                        TextBox Txt = new TextBox();
                        Txt.ID = "TxtImageWidth";
                        // Txt.CssClass = "TxtBoxes";

                        if (ModuleId != 0)
                        {
                            Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql PmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                            Bazaar.BusinessLayer.PAGE_MODULES_CONFIG PmConfig = PmConfigSql.Select_Parameters_Value(Kind, ModuleId);
                            ((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value = PmConfig.ID.ToString();

                            try
                            {
                                Txt.Text = PmConfig.VALUE;
                            }
                            catch
                            {
                            }

                        }
                        GvModulesParams.Rows[i].Cells[0].Controls.Add(Txt);
                        break;

                    case "Count":
                        DropDownList DdlCount = new DropDownList();
                        DdlCount.ID = "DdlCount";

                        DdlCount.Items.Clear();
                        for (int p = 1; p < 501; p++)
                        {
                            DdlCount.Items.Add(new ListItem(p.ToString(), p.ToString()));
                        }

                        if (ModuleId != 0)
                        {
                            Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql PmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                            Bazaar.BusinessLayer.PAGE_MODULES_CONFIG PmConfig = PmConfigSql.Select_Parameters_Value(Kind, ModuleId);
                            try
                            {
                                DdlCount.SelectedIndex = DdlCount.Items.IndexOf(DdlCount.Items.FindByValue(PmConfig.VALUE.ToString()));
                                ((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value = PmConfig.ID.ToString();
                            }
                            catch
                            {
                            }
                        }
                        GvModulesParams.Rows[i].Cells[0].Controls.Add(DdlCount);
                        break;


                    case "CategoryId":
                        {
                            DropDownList DdlCat = new DropDownList();
                            DdlCat.ID = "DdlCat";
                            Bazaar.BusinessLayer.DataLayer.CATEGORIESSql CatSql = new BusinessLayer.DataLayer.CATEGORIESSql();
                            List<Bazaar.BusinessLayer.CATEGORIES> Cats = CatSql.SelectAll();
                            DdlCat.Items.Clear();
                            foreach (Bazaar.BusinessLayer.CATEGORIES item in Cats)
                            {
                                DdlCat.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                            }

                            if (ModuleId != 0)
                            {
                                Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql PmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                                Bazaar.BusinessLayer.PAGE_MODULES_CONFIG PmConfig = PmConfigSql.Select_Parameters_Value(Kind, ModuleId);
                                DdlCat.SelectedIndex = DdlCat.Items.IndexOf(DdlCat.Items.FindByValue(PmConfig.VALUE.ToString()));
                                ((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value = PmConfig.ID.ToString();
                            }

                            GvModulesParams.Rows[i].Cells[0].Controls.Add(DdlCat);
                        }
                        break;

                    case "BodyText":
                        {
                            CKEditor.NET.CKEditorControl Editor = new CKEditor.NET.CKEditorControl();
                            Editor.ID = "EditorCk";
                            Editor.BasePath = "~/CP/Utility/ckeditor";
                            Editor.ForcePasteAsPlainText = true;
                            Editor.Height = 500;
                            Editor.ContentsLangDirection = CKEditor.NET.contentsLangDirections.Rtl;
                            GvModulesParams.Rows[i].Cells[0].Controls.Add(Editor);
                            if (ModuleId != 0)
                            {
                                Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql PmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                                Bazaar.BusinessLayer.PAGE_MODULES_CONFIG PmConfig = PmConfigSql.Select_Parameters_Value(Kind, ModuleId);
                                Editor.Text = PmConfig.VALUE;
                                ((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value = PmConfig.ID.ToString();
                            }

                        }
                        break;


                    case "ActiveMenuTabId":
                        {
                            DropDownList DdlActiveMenu = new DropDownList();
                            DdlActiveMenu.ID = "DdlActiveMenu";
                            Bazaar.BusinessLayer.DataLayer.MENUSSql MSql = new BusinessLayer.DataLayer.MENUSSql();
                            List<Bazaar.BusinessLayer.MENUS> MenuList = MSql.SelectCondition(" pid=0 and kind=2 order by sort");
                            DdlActiveMenu.Items.Clear();
                            foreach (Bazaar.BusinessLayer.MENUS item in MenuList)
                            {
                                DdlActiveMenu.Items.Add(new ListItem(item.TITLE, item.ID.ToString()));
                            }

                            if (ModuleId != 0)
                            {
                                Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql PmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                                Bazaar.BusinessLayer.PAGE_MODULES_CONFIG PmConfig = PmConfigSql.Select_Parameters_Value(Kind, ModuleId);
                                DdlActiveMenu.SelectedIndex = DdlActiveMenu.Items.IndexOf(DdlActiveMenu.Items.FindByValue(PmConfig.VALUE.ToString()));
                                ((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value = PmConfig.ID.ToString();
                            }

                            GvModulesParams.Rows[i].Cells[0].Controls.Add(DdlActiveMenu);

                        }
                        break;

                    case "ProgKind":
                        RadioButtonList RblProgK = new RadioButtonList();
                        RblProgK.ID = "RlbProgKind";
                        //Rbl.CssClass = "DdlControl";
                        RblProgK.RepeatDirection = RepeatDirection.Horizontal;
                        RblProgK.Items.Add(new ListItem("تولیدی", "1"));
                        RblProgK.Items.Add(new ListItem("بازرگانی", "2"));
                        RblProgK.Items.Add(new ListItem("کشاورزی", "3"));
                        //Rbl.SelectedIndex = 1;

                        if (ModuleId != 0)
                        {
                            Bazaar.BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql PmConfigSql = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();
                            Bazaar.BusinessLayer.PAGE_MODULES_CONFIG PmConfig = PmConfigSql.Select_Parameters_Value(Kind, ModuleId);
                            try
                            {
                                RblProgK.SelectedIndex = RblProgK.Items.IndexOf(RblProgK.Items.FindByValue(PmConfig.VALUE.ToString()));
                                ((HiddenField)GvModulesParams.Rows[i].Cells[0].FindControl("hfmoduleconfigid")).Value = PmConfig.ID.ToString();
                            }
                            catch
                            {
                            }
                        }
                        GvModulesParams.Rows[i].Cells[0].Controls.Add(RblProgK);
                        break;

                    default:
                        break;
                }
            }
        }

        protected override void CreateChildControls()
        {
            if (Page.IsPostBack)
            {
                GvModulesParams_DataBound(new object(), new EventArgs());
            }
            else
            {

            }

        }
    }
}