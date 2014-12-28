using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace Bazaar.Core
{
    public class ModuleLoader
    {

        public static System.Web.UI.UserControl LoadUserControl(int ControlId)
        {
            Page Pg = new Page();


            BusinessLayer.DataLayer.PAGE_MODULESSql Page_Module_Sql = new BusinessLayer.DataLayer.PAGE_MODULESSql();
            BusinessLayer.PAGE_MODULES Page_Module = Page_Module_Sql.SelectByPrimaryKey(new BusinessLayer.PAGE_MODULESKeys(ControlId));


            BusinessLayer.DataLayer.MODULESSql Module_Sql = new BusinessLayer.DataLayer.MODULESSql();
            BusinessLayer.MODULES Module = Module_Sql.SelectByPrimaryKey(new BusinessLayer.MODULESKeys(int.Parse(Page_Module.MODULE_ID.ToString())));



            BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql Page_Module_Config_SQL = new BusinessLayer.DataLayer.PAGE_MODULES_CONFIGSql();

            switch (Module.FILEPATH)
            {
                case "Modules/Contents/List/Content_List.ascx":
                    Modules.Contents.List.Content_List myuc = (Modules.Contents.List.Content_List)Pg.LoadControl(Module.FILEPATH);
                    myuc.CategoryId = int.Parse(Page_Module_Config_SQL.
                        Select_Parameters_Value("CategoryId", int.Parse(Page_Module.ID.ToString())).VALUE);

                    myuc.Template = Page_Module.TEMPLATE;
                    myuc.ModuleTitle = Page_Module.TITLE;
                    myuc.Container_Layout = Page_Module.CONTAINER_LAYOUT;

                    myuc.Count = int.Parse(Page_Module_Config_SQL.
                        Select_Parameters_Value("Count", int.Parse(Page_Module.ID.ToString())).VALUE);

                    myuc.ImageWidth = int.Parse(Page_Module_Config_SQL.
                        Select_Parameters_Value("ImageWidth", int.Parse(Page_Module.ID.ToString())).VALUE);
                    myuc.Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc;


                case "Modules/Contents/fullview/fullview.ascx":
                    Modules.Contents.FullView.FullView myuc3 = (Modules.Contents.FullView.FullView)Pg.LoadControl(Module.FILEPATH);
                    myuc3.Template = Page_Module.TEMPLATE;
                    return myuc3;



                case "Modules/Schedules/TopView/TopView.ascx":
                    Modules.Schedules.TopView.TopView topviewuc = (Modules.Schedules.TopView.TopView)Pg.LoadControl(Module.FILEPATH);
                    topviewuc.Template = Page_Module.TEMPLATE;
                    topviewuc.Count = int.Parse(Page_Module_Config_SQL.
                        Select_Parameters_Value("Count", int.Parse(Page_Module.ID.ToString())).VALUE);
                    topviewuc.ImageWidth = int.Parse(Page_Module_Config_SQL.
                        Select_Parameters_Value("ImageWidth", int.Parse(Page_Module.ID.ToString())).VALUE);
                    topviewuc.ModuleTitle = Page_Module.TITLE;
                    topviewuc.Container_Layout = Page_Module.CONTAINER_LAYOUT;

                    return topviewuc;



                case "Modules/Poll/PollViewer/PollViewer.ascx":
                    Modules.Poll.PollViewer.PollViewer myuc4 = (Modules.Poll.PollViewer.PollViewer)Pg.LoadControl(Module.FILEPATH);
                    myuc4.PollId = int.Parse(Page_Module_Config_SQL.
                        Select_Parameters_Value("Poll_Id", int.Parse(Page_Module.ID.ToString())).VALUE);
                    myuc4.ModuleTitle = Page_Module.TITLE;
                    myuc4.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc4;


                case "Modules/Gallery/TopViewer/TopViewer.ascx":
                    Modules.Gallery.TopViewer.TopViewer myuc5 = (Modules.Gallery.TopViewer.TopViewer)Pg.LoadControl(Module.FILEPATH);
                    myuc5.Count = int.Parse(Page_Module_Config_SQL.
                        Select_Parameters_Value("Count", int.Parse(Page_Module.ID.ToString())).VALUE);
                    myuc5.ImageWidth = int.Parse(Page_Module_Config_SQL.
                       Select_Parameters_Value("ImageWidth", int.Parse(Page_Module.ID.ToString())).VALUE);
                    myuc5.Vertical = bool.Parse(Page_Module_Config_SQL.
                     Select_Parameters_Value("Vertical", int.Parse(Page_Module.ID.ToString())).VALUE);
                    myuc5.Template = Page_Module.TEMPLATE;
                    myuc5.ModuleTitle = Page_Module.TITLE;
                    myuc5.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc5;


                case "Modules/Programs/Top/TopView.ascx":
                    Modules.Programs.Top.TopView myuc6 = (Modules.Programs.Top.TopView)Pg.LoadControl(Module.FILEPATH);
                    myuc6.Count = int.Parse(Page_Module_Config_SQL.
                        Select_Parameters_Value("Count", int.Parse(Page_Module.ID.ToString())).VALUE);
                    myuc6.Template = Page_Module.TEMPLATE;
                    myuc6.ModuleTitle = Page_Module.TITLE;
                    myuc6.ProgKind=int.Parse(Page_Module_Config_SQL.
                        Select_Parameters_Value("ProgKind", int.Parse(Page_Module.ID.ToString())).VALUE);
                    myuc6.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc6;



                case "Modules/Price/Summary/PriceSummary.ascx":
                    Modules.Price.Summary.pricesummary myuc7 = (Modules.Price.Summary.pricesummary)Pg.LoadControl(Module.FILEPATH);
                    myuc7.Template = Page_Module.TEMPLATE;
                    myuc7.ModuleTitle = Page_Module.TITLE;
                    myuc7.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc7;

                case "Modules/Price/Crawl/Crawl.ascx":
                    Modules.Price.Crawl.Crawl myuc8 = (Modules.Price.Crawl.Crawl)Pg.LoadControl(Module.FILEPATH);
                    myuc8.Template = Page_Module.TEMPLATE;
                    myuc8.ModuleTitle = Page_Module.TITLE;
                    myuc8.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc8;

                case "Modules/Gallery/ShowAlbum/AlbumViewer.ascx":
                    Modules.Gallery.ShowAlbum.AlbumViewer myuc9 = (Modules.Gallery.ShowAlbum.AlbumViewer)Pg.LoadControl(Module.FILEPATH);
                    myuc9.Template = Page_Module.TEMPLATE;
                    return myuc9;

                case "Modules/Comments/Comment.ascx":
                    Modules.Comments.Comment myuc10 = (Modules.Comments.Comment)Pg.LoadControl(Module.FILEPATH);
                    myuc10.Template = Page_Module.TEMPLATE;
                    return myuc10;

                case "Modules/Live/LivePlayer.ascx":
                    Modules.Live.LivePlayer myuc11 = (Modules.Live.LivePlayer)Pg.LoadControl(Module.FILEPATH);
                    return myuc11;


                case "Modules/Static/StaticContents.ascx":
                    Modules.Static.StaticContents myuc12 = (Modules.Static.StaticContents)Pg.LoadControl(Module.FILEPATH);
                    myuc12.Template = Page_Module.TEMPLATE;
                    myuc12.HeaderTitle = Page_Module.TITLE;
                    myuc12.BodyText = Page_Module_Config_SQL.Select_Parameters_Value("BodyText", int.Parse(Page_Module.ID.ToString())).VALUE;
                    return myuc12;

                case "Modules/Menu/MainMenu.ascx":
                    Modules.Menu.MainMenu myuc13 = (Modules.Menu.MainMenu)Pg.LoadControl(Module.FILEPATH);
                    myuc13.ActiveMenuTabId = int.Parse(Page_Module_Config_SQL.
                       Select_Parameters_Value("ActiveMenuTabId", int.Parse(Page_Module.ID.ToString())).VALUE);
                    return myuc13;


                case "Modules/Schedules/Weekly/Weekly.ascx":
                    Modules.Schedules.Weekly.Weekly myuc14 = (Modules.Schedules.Weekly.Weekly)Pg.LoadControl(Module.FILEPATH);
                    myuc14.Template = Page_Module.TEMPLATE;
                    myuc14.ModuleTitle = Page_Module.TITLE;
                    myuc14.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc14;

                case "Modules/Gallery/Albums/AlbumsList.ascx":
                    Modules.Gallery.Albums.AlbumsList myuc15 = (Modules.Gallery.Albums.AlbumsList)Pg.LoadControl(Module.FILEPATH);
                    return myuc15;


                case "Modules/Programs/ShowProgram/FullView.ascx":
                    Modules.Programs.ShowProgram.FullView myuc16 = (Modules.Programs.ShowProgram.FullView)Pg.LoadControl(Module.FILEPATH);
                    myuc16.Template = Page_Module.TEMPLATE;
                    myuc16.ModuleTitle = Page_Module.TITLE;
                    myuc16.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc16;

                case "Modules/Programs/Session/Top/TopViewer.ascx":
                    Modules.Programs.Session.Top.TopViewer myuc17 = (Modules.Programs.Session.Top.TopViewer)Pg.LoadControl(Module.FILEPATH);
                    myuc17.Template = Page_Module.TEMPLATE;
                    myuc17.ModuleTitle = Page_Module.TITLE;
                    myuc17.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    myuc17.Count = int.Parse(Page_Module_Config_SQL.
                      Select_Parameters_Value("Count", int.Parse(Page_Module.ID.ToString())).VALUE);
                    return myuc17;

                case "Modules/Programs/Session/ShowItem/FullView.ascx":
                    Modules.Programs.Session.ShowItem.FullView myuc18 = (Modules.Programs.Session.ShowItem.FullView)Pg.LoadControl(Module.FILEPATH);
                    myuc18.Template = Page_Module.TEMPLATE;
                    myuc18.ModuleTitle = Page_Module.TITLE;
                    myuc18.Container_Layout = Page_Module.CONTAINER_LAYOUT;                    
                    return myuc18;

                case "Modules/Programs/Session/List/ListView.ascx":
                    Modules.Programs.Session.List.ListView myuc19 = (Modules.Programs.Session.List.ListView)Pg.LoadControl(Module.FILEPATH);
                    myuc19.Template = Page_Module.TEMPLATE;
                    myuc19.ModuleTitle = Page_Module.TITLE;
                    myuc19.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    //myuc19.Count = int.Parse(Page_Module_Config_SQL.
                    //  Select_Parameters_Value("Count", int.Parse(Page_Module.ID.ToString())).VALUE);
                    return myuc19;



                case "Modules/Feeds/Viewer/FViewer.ascx":
                    Modules.Feeds.Viewer.FViewer myuc20 = (Modules.Feeds.Viewer.FViewer)Pg.LoadControl(Module.FILEPATH);

                    myuc20.ModuleTitle = Page_Module.TITLE;
                    myuc20.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc20;


                case "Modules/Search/AdvanceSearch.ascx":
                    Modules.Search.AdvanceSearch myuc21 = (Modules.Search.AdvanceSearch)Pg.LoadControl(Module.FILEPATH);

                    myuc21.ModuleTitle = Page_Module.TITLE;
                    myuc21.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc21;


                case "Modules/Programs/Session/TopAll/TopViewerAll.ascx":
                    Modules.Programs.Session.Top.TopViewerAll myuc22 = (Modules.Programs.Session.Top.TopViewerAll)Pg.LoadControl(Module.FILEPATH);
                    myuc22.Template = Page_Module.TEMPLATE;
                    myuc22.ModuleTitle = Page_Module.TITLE;
                    myuc22.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    myuc22.Count = int.Parse(Page_Module_Config_SQL.
                      Select_Parameters_Value("Count", int.Parse(Page_Module.ID.ToString())).VALUE);
                    myuc22.ProgKind = int.Parse(Page_Module_Config_SQL.
                     Select_Parameters_Value("ProgKind", int.Parse(Page_Module.ID.ToString())).VALUE);
                    return myuc22;


                     case "Modules/Programs/TopTab/TopTabProg.ascx":
                    Modules.Programs.TopTab.TopTabProg myuc23 = (Modules.Programs.TopTab.TopTabProg)Pg.LoadControl(Module.FILEPATH);
                    myuc23.ModuleTitle = Page_Module.TITLE;
                    myuc23.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    myuc23.Count = int.Parse(Page_Module_Config_SQL.
                      Select_Parameters_Value("Count", int.Parse(Page_Module.ID.ToString())).VALUE);
                    myuc23.ProgKind = int.Parse(Page_Module_Config_SQL.
                    Select_Parameters_Value("ProgKind", int.Parse(Page_Module.ID.ToString())).VALUE);
                    return myuc23;


                     case "Modules/Programs/TwoCol/ProgCol.ascx":
                    Modules.Programs.TwoCol.ProgCol myuc24 = (Modules.Programs.TwoCol.ProgCol)Pg.LoadControl(Module.FILEPATH);
                    myuc24.ModuleTitle = Page_Module.TITLE;
                    myuc24.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    myuc24.Count = int.Parse(Page_Module_Config_SQL.
                      Select_Parameters_Value("Count", int.Parse(Page_Module.ID.ToString())).VALUE);
                    myuc24.ProgKind = int.Parse(Page_Module_Config_SQL.
                    Select_Parameters_Value("ProgKind", int.Parse(Page_Module.ID.ToString())).VALUE);
                    return myuc24;

                     case "Modules/Contact/Public/ConInserter.ascx":
                    Modules.Contact.Public.ConInserter myuc25 = (Modules.Contact.Public.ConInserter)Pg.LoadControl(Module.FILEPATH);
                    myuc25.ModuleTitle = Page_Module.TITLE;
                    myuc25.Container_Layout = Page_Module.CONTAINER_LAYOUT;
                    return myuc25;
                default:
                    UserControl myuc2 = new UserControl();
                    return myuc2;
            }
        }
    }
}





