using System;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Kondrat.PracticeTask.Travel.BL.Interface;
using Microsoft.Owin.Security.OAuth;

namespace Kondrat.PracticeTask.TravelWebAPI.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserCredentialsServise _servise;

        public AuthorizationServerProvider(IUserCredentialsServise servise)
        {
            _servise = servise;
        }
        //This method is used to validate clients in the application
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //client has been validated
        }

        //In this method we will validate the credentials of the user. If credentials are valid we create the signed token
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var user = _servise.GetByEmailAndPassword(context.UserName, context.Password);
                if(user==null)
                    throw new Exception();             
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));
                    context.Validated(identity);
            }catch(Exception)
            {
                context.SetError("Invalid Grant", "Provided username and password incorrect");
            }

        }
    }
}