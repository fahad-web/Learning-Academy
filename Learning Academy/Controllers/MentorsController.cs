using BLL.DTOs;
using BLL.Services;
using Learning_Academy.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Learning_Academy.Controllers
{
    public class MentorsController : ApiController
    {
        [Logged]
        [AdminAccess]
        [HttpPost]
        [Route("api/Mentors/create")]
        public HttpResponseMessage Create(MentorsDTO data)
        {
            try
            {
                var res = MentorsService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/Mentors")]
        public HttpResponseMessage Mentors()
        {
            try
            {
                var data = MentorsService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/Mentors/{id}")]
        public HttpResponseMessage Mentors(int id)
        {
            try
            {
                var data = MentorsService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/Mentors/update")]
        public HttpResponseMessage Update(MentorsDTO data)
        {

            var exmp = MentorsService.Get(data.ID);

            if (exmp != null)
            {
                try
                {
                    var res = MentorsService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Mentors Data Updated" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Mentors not found" });
        }
    }
}
