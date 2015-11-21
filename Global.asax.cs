using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Bazaar
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        void RegisterRoutes(RouteCollection routes)
        {

            

            //HomePage
            routes.MapPageRoute("home", "home", "~/default.aspx");

            routes.MapPageRoute("news", "news/{NewsID}/{NewsTitle}", "~/Pages/news.aspx");

            routes.MapPageRoute("newsprint", "newsprint/{NewsID}", "~/Pages/newsprint.aspx");
            routes.MapPageRoute("newsmail", "newsmail/{NewsID}", "~/Pages/newssend.aspx");

            

            routes.MapPageRoute("NewsHome", "news", "~/Pages/NewsPage.aspx");

            routes.MapPageRoute("aboutus", "aboutus", "~/Pages/AboutUs.aspx");

            routes.MapPageRoute("advertising", "advertising", "~/Pages/Advertise.aspx");

            routes.MapPageRoute("ContactUs", "ContactUs", "~/Pages/ContactUs.aspx");

            routes.MapPageRoute("Live", "Live", "~/Pages/Live.aspx");


            //Photo Main Page
            routes.MapPageRoute("photos", "photos", "~/Pages/photos.aspx");
            routes.MapPageRoute("gallery", "gallery/{GalleryID}/{GalleryTitle}", "~/Pages/photos_Viewer.aspx");
            routes.MapPageRoute("photosPage", "galleries/{GalleryKind}", "~/Pages/photos.aspx");

            //Price
            routes.MapPageRoute("prices", "prices", "~/Pages/prices.aspx");


            routes.MapPageRoute("programs", "programs", "~/Pages/programs.aspx");
            routes.MapPageRoute("Showprogram", "program/{ProgramId}/{ProgramTitle}", "~/Pages/ShowProgram.aspx");
            routes.MapPageRoute("ShowSession", "program/{ProgramId}/{ProgramTitle}/session/{SessionNumber}/{SessionTitle}", "~/Pages/ShowSession.aspx");
            routes.MapPageRoute("ShowSessionList", "program/{ProgramId}/{ProgramTitle}/sessionlist", "~/Pages/ShowSessionList.aspx");

            routes.MapPageRoute("Links", "links", "~/Pages/Receive.aspx");

            routes.MapPageRoute("SearchKey", "search/{SearchKey}", "~/Pages/search.aspx");
            routes.MapPageRoute("SearchNoKey", "search", "~/Pages/search.aspx");

            routes.MapPageRoute("Schedules", "Schedules", "~/Pages/Schedules.aspx");

            routes.MapPageRoute("videos", "videos", "~/Pages/videos.aspx");
            routes.MapPageRoute("Feeds", "feeds", "~/Pages/feeds.aspx");
             routes.MapPageRoute("FeedsGenNews", "feeds/news/{Category}", "~/Pages/NewsFeedGenerator.aspx");
             routes.MapPageRoute("FeedsGenGallery", "feeds/gallery", "~/Pages/GalleryFeedGenerator.aspx");
             routes.MapPageRoute("FeedsGenPrice", "feeds/price", "~/Pages/priceFeedGenerator.aspx");
              routes.MapPageRoute("FeedsGenconductor", "feeds/conductor", "~/Pages/conductorFeedGenerator.aspx");


            //Control Panel
            routes.MapPageRoute("CpNewsEdit", "cp/newsedit/{NewsID}", "~/Cp/News_Insert.aspx");
            routes.MapPageRoute("CpNews", "cp/news", "~/Cp/News.aspx");
            routes.MapPageRoute("CpNewsFiles", "cp/newsfiles/{NewsID}", "~/Cp/News_Files.aspx");
            routes.MapPageRoute("CpNewsComments", "cp/news/comments/{NewsID}", "~/Cp/News_Comments.aspx");


            
            routes.MapPageRoute("CpPolls", "cp/Polls", "~/Cp/Polls.aspx");
            routes.MapPageRoute("CpPollsedit", "cp/Pollsedit/{PollId}", "~/Cp/Polls_Insert.aspx");
            routes.MapPageRoute("CpPollsSelector", "cp/Polls/Select", "~/Cp/Polls_Selector.aspx");


            //Admin Config.
            routes.MapPageRoute("CpModules", "cp/Modules", "~/Cp/Modules.aspx");
            routes.MapPageRoute("CpModulesEdit", "cp/Modules/edit/{ModuleId}", "~/Cp/Manager.aspx");

            routes.MapPageRoute("ControlPanel", "Login", "~/Login.aspx");
            routes.MapPageRoute("CpUsers", "cp/Users", "~/cp/Users.aspx");
            routes.MapPageRoute("CpUsersEdit", "cp/Users/Edit/{UserID}", "~/cp/Users_Insert.aspx");
            routes.MapPageRoute("CpDashBoard", "cp/DashBoard", "~/cp/DashBoard.aspx");


            routes.MapPageRoute("CpAlbums", "cp/Albums", "~/cp/Albums.aspx");
            routes.MapPageRoute("CpAlbumsEdit", "cp/Albums/Edit/{AlbumID}", "~/cp/Albums_Insert.aspx");

            routes.MapPageRoute("CpPrograms", "cp/Programs", "~/cp/Programs.aspx");
            routes.MapPageRoute("CpProgramsEdit", "cp/Programs/Edit/{ProgramID}", "~/cp/Programs_Insert.aspx");
            routes.MapPageRoute("CpProgramsSessions", "cp/Programs/Session/{ProgramID}", "~/cp/Programs_Sessions.aspx");
            routes.MapPageRoute("CpProgramsSessionsEdit", "cp/Programs/Session/Edit/{ProgramID}/{SessionId}", "~/cp/Programs_Sessions_Insert.aspx");
            routes.MapPageRoute("CpProgramsPhotos", "cp/Programs/Photos/{PID}", "~/cp/Programs_photos.aspx");
            
            routes.MapPageRoute("CpMenus", "cp/Menus", "~/cp/Menus.aspx");


            routes.MapPageRoute("ErrorPage", "error", "~/core/errors/error.aspx");
            routes.MapPageRoute("CpServiceList", "cp/Service/List", "~/cp/Services.aspx");

            routes.MapPageRoute("CpServiceInsert", "cp/Service/Edit/{RepId}", "~/cp/Services_Insert.aspx");


            routes.MapPageRoute("CpContactUsList", "cp/Contactus/list", "~/Cp/contactus.aspx");







            routes.MapPageRoute("AgriHome", "agriculture", "~/Pages/agri.aspx");
        }
    }
}