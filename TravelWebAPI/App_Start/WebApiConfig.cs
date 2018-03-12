using System.Web.Http;
using Travel.BL.Interface;
using Travel.BL.Services;
using Travel.Data.ConcreteEF;
using Travel.Data.Interface;
using TravelWebAPI.LoC;
using Unity;
using Unity.Lifetime;

namespace TravelWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IUserServise, UserServise>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepositoty, UserRepositoty>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserCredentialsRepositoty, UserCredentialsRepositoty>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserCredentialsServise, UserCredentialsServise>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhotoRepositoty, IPhotoRepositoty>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhotoServise, PhotoServise>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
