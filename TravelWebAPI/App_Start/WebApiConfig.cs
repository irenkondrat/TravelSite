using System.Web.Http;
using Kondrat.PracticeTask.Travel.BL.Interface;
using Kondrat.PracticeTask.Travel.BL.Services;
using Kondrat.PracticeTask.Travel.Data.ConcreteEF;
using Kondrat.PracticeTask.Travel.Data.Interface;
using Kondrat.PracticeTask.TravelWebAPI.LoC;
using Unity;
using Unity.Lifetime;

namespace Kondrat.PracticeTask.TravelWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IUserServise, UserServise>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserCredentialsRepository, UserCredentialsRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserCredentialsServise, UserCredentialsServise>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhotoRepository,PhotoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPhotoServise, PhotoServise>(new HierarchicalLifetimeManager());
            container.RegisterType<ICityRepository, CityRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentRepository, CommentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentServise, CommentServise>(new HierarchicalLifetimeManager());
            container.RegisterType<IVisitingRepository, VisitingRepository>(new HierarchicalLifetimeManager());

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
