using System;
using System.Web.Http;
using Travel.BL.Exceptions;
using Travel.BL.Interface;


namespace TravelWebAPI.Controllers
{
    public class UserCredentialsController : ApiController
    {
        private readonly IUserCredentialsServise _servise;

        public UserCredentialsController(IUserCredentialsServise servise)
        {
            _servise = servise;
        }

        // Post: api/UserCredentials
        public IHttpActionResult Post([FromBody] string email)
        {
            try
            {
                if(_servise.CheckByEmail(email))
                    return BadRequest("Email booked");

                else
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

        // PUT: api/UserCredentials/5
        [Authorize]
        public IHttpActionResult Put( [FromBody] string oldPassword, string newPassword)
        {
            try
            {
                int userId = Int32.Parse(RequestContext.Principal.Identity.Name);
               _servise.EditPassword(userId, oldPassword, newPassword);
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