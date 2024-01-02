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
    public class OrderCourseController : ApiController
    {
        [HttpPost]
        [Route("api/OrderCourse/create")]
        public HttpResponseMessage Create(OrderCourseDTO data)
        {
            try
            {
                var res = OrderCourseService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }




        [HttpGet]
        [Route("api/OrderCourse")]
        public HttpResponseMessage OrderCourse()
        {
            try
            {
                var data = OrderCourseService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/OrderCourse/{id}")]
        public HttpResponseMessage OrderCourse(int id)
        {
            try
            {
                var data = OrderCourseService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }



        [HttpPost]
        [Route("api/OrderCourse/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var exmp = OrderCourseService.Get(id);

            if (exmp != null)
            {
                try
                {
                    var res = OrderCourseService.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "OrderCourse not found" });
        }




        [HttpPost]
        [Route("api/OrderCourse/update")]
        public HttpResponseMessage Update(OrderCourseDTO data)
        {

            var exmp = OrderCourseService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = OrderCourseService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Order not found" });
        }
    }
}
