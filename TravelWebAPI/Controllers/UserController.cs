using System;
using System.Web.Http;
using Kondrat.PracticeTask.Travel.BL.Exceptions;
using Kondrat.PracticeTask.Travel.BL.Interface;
using Kondrat.PracticeTask.Travel.Data.Entities;


namespace Kondrat.PracticeTask.TravelWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserServise _servise;

        public UserController(IUserServise servise)
        {
            _servise = servise;
        }

        // GET: api/User
        [Authorize]
        public IHttpActionResult Get()
        {
            try
            {
                int userId = Int32.Parse(RequestContext.Principal.Identity.Name);
                var user = _servise.GetById(userId);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest("Server error");
            }
        }

        // GET: api/User/5
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var user = _servise.GetById(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest("Server error");
            }
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]UserCredentials userCredentials, [FromBody]User user)
        {
            try
            {
                var id = _servise.Add(user, userCredentials);
                return Ok(id);
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

        // PUT: api/User
        public IHttpActionResult Put([FromBody]User user)
        {
            try
            {
                int userId = Int32.Parse(RequestContext.Principal.Identity.Name);
                _servise.Edit(user, userId);
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
