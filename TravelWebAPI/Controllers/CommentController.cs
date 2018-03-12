using System;
using System.Web.Http;
using Kondrat.PracticeTask.Travel.BL.Exceptions;
using Kondrat.PracticeTask.Travel.BL.Interface;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.TravelWebAPI.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentServise _servise;

        public CommentController(ICommentServise servise)
        {
            _servise = servise;
        }
        // GET: api/Comment
        public IHttpActionResult Get([FromBody]int id)
        {
            try
            {
                var comment = _servise.GetAllByIdCity(id);
                return Ok(comment);
            }
            catch (Exception)
            {
                return BadRequest("Server error");
            }
        }


        // POST: api/Comment
        [Authorize]
        public IHttpActionResult Post([FromBody]Comment value)
        {
            try
            {
                _servise.Add(value);
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


        // DELETE: api/Comment/5
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            int userId = Int32.Parse(RequestContext.Principal.Identity.Name);
            try
            {
                _servise.Delete(id, userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Server error");
            }
        }
    }
}
