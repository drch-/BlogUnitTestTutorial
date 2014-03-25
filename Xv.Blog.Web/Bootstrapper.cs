namespace Xv.Blog.Web
{
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;
    using Unity.Mvc4;

    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }
    }
}