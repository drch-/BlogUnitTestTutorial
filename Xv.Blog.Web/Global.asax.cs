namespace Xv.Blog.Web
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Xv.Blog.Data;
    using Xv.Blog.Migrations;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
