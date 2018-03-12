using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TravelWebAPI.Security;


[assembly: OwinStartup(typeof(TravelWebAPI.Startup))]

namespace TravelWebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll); //enable cors origin request


            var myProvider = new AuthorizationServerProvider();
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
