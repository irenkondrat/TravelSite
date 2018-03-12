using System;
using System.Web.Http;
using Kondrat.PracticeTask.Travel.BL.Interface;
using Kondrat.PracticeTask.Travel.BL.Services;
using Kondrat.PracticeTask.Travel.Data.ConcreteEF;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Kondrat.PracticeTask.TravelWebAPI.Security;


[assembly: OwinStartup(typeof(Kondrat.PracticeTask.TravelWebAPI.Startup))]

namespace Kondrat.PracticeTask.TravelWebAPI
{
    public class Startup
    {
        private readonly IUserCredentialsServise _servise;
        public Startup(IUserCredentialsServise servise)
        {
            _servise = servise;
        }
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll); //enable cors origin request


            var myProvider = new AuthorizationServerProvider(_servise);
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1), 
                Provider = myProvider
            };



            //Token Generation            
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()).UseStageMarker(PipelineStage.Authenticate);
            app.UseOAuthAuthorizationServer(options); //we tell the app user our configuration

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);


        }

        
    }
}
