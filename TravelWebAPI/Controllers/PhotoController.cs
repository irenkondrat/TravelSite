using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Travel.BL.Exceptions;
using Travel.BL.Interface;

namespace TravelWebAPI.Controllers
{
    public class PhotoController : ApiController
    {
        private readonly IPhotoServise _servise;

        public PhotoController(IPhotoServise servise)
        {
            _servise = servise;
        }


        // GET: api/Photo/5
        public List<HttpResponseMessage> Get(int id)
        {
            try
            {
                List<HttpResponseMessage> responses = new List<HttpResponseMessage>();
                var photos =_servise.GetByIdComment(id);
                foreach (var p in photos)
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response.Content = new StreamContent(new FileStream(
                     System.Web.Hosting.HostingEnvironment.MapPath(@p.Address) ?? throw new InvalidOperationException(),FileMode.Open));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                    responses.Add(response);
                }
                return responses;
            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Request!"));
            }
        }

        // POST: api/Photo
        [Authorize]
        public IHttpActionResult Post(HttpPostedFileBase file)
        {
            try
            {
                int userId = Int32.Parse(RequestContext.Principal.Identity.Name);

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Image/"), fileName);
                    file.SaveAs(path);
                    _servise.AddToUser(fileName, userId);

                }
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

        // POST: api/Photo
        [Authorize]
        public IHttpActionResult Post(int id , HttpPostedFileBase file)
        {
            try
            {
                int userId = Int32.Parse(RequestContext.Principal.Identity.Name);

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Image/"), fileName);
                    file.SaveAs(path);
                    _servise.AddToComment(fileName, id);
                }
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
