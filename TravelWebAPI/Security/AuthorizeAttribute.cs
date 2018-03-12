using System.Net;
using System.Net.Http;
using System.Web;

namespace Kondrat.PracticeTask.TravelWebAPI.Security
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }



    }

}