using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Learning_Academy.Controllers
{
    public class SubscribeCourseController : ApiController
    {
        [HttpGet]
        [Route("api/SubscribeCourseService")]
        public HttpResponseMessage SubscribeCourse()
        {
            try
            {
                var data = SubscribeCourseService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/SubscribeCourseService/{id}")]
        public HttpResponseMessage SubscribeCourse(int id)
        {
            try
            {
                var data = SubscribeCourseService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }




        [HttpPost]
        [Route("api/SubCourse/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var exmp = SubscribeCourseService.Get(id);

            if (exmp != null)
            {
                try
                {
                    var res = SubscribeCourseService.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Course Deleted" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Subscribe Course not found" });
        }
    }
}
