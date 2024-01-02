using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Learning_Academy.Controllers
{
    public class CourseController : ApiController
    {
        [HttpGet]
        [Route("api/Course")]
        public HttpResponseMessage Course()
        {
            try
            {
                var data = CourseService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }



        [HttpGet]
        [Route("api/Course/{id}")]
        public HttpResponseMessage Course(int id)
        {
            try
            {
                var data = CourseService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }




        [HttpPost]
        [Route("api/Course/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var exmp = CourseService.Get(id);

            if (exmp != null)
            {
                try
                {
                    var res = CourseService.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Course not found" });
        }




        [HttpPost]
        [Route("api/Course/update")]
        public HttpResponseMessage Update(CourseDTO data)
        {

            var exmp = CourseService.Get(data.ID);

            if (exmp != null)
            {
                try
                {
                    var res = CourseService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Student not found" });
        }


        [HttpGet]
        [Route("api/Course/{id}/Review")]
        public HttpResponseMessage CourseReview(int id)
        {
            try
            {
                var data = CourseService.GetwithReview(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
