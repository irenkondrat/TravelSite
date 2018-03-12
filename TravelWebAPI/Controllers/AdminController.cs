using System;
using System.Web.Http;
using Kondrat.PracticeTask.Travel.BL.Exceptions;
using Kondrat.PracticeTask.Travel.BL.Interface;

namespace Kondrat.PracticeTask.TravelWebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : ApiController
    {
       private readonly ICommentServise _servise;
       public AdminController(ICommentServise servise)
       {
           _servise = servise;
       }

        // PUT: api/Admin
        public IHttpActionResult Put([FromBody]int id, [FromBody]string value)
        {
            int userId = Int32.Parse(RequestContext.Principal.Identity.Name);
            try
            {
                 _servise.Edit(id, userId,value);
                return Ok();
            }
            catch (IncorrectDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Server error");
            }

        }
    }
}
