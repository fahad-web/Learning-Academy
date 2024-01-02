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
    public class ReviewController : ApiController
    {
        [HttpPost]
        [Route("api/Review/create")]
        public HttpResponseMessage Create(ReviewDTO data)
        {
            try
            {
                var res = ReviewService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/Review")]
        public HttpResponseMessage Review()
        {
            try
            {
                var data = ReviewService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Review/{id}")]
        public HttpResponseMessage Review(int id)
        {
            try
            {
                var data = ReviewService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }



        [HttpPost]
        [Route("api/Review/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var exmp = ReviewService.Get(id);

            if (exmp != null)
            {
                try
                {
                    var res = ReviewService.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Student not found" });
        }



        [HttpPost]
        [Route("api/Review/update")]
        public HttpResponseMessage Update(ReviewDTO data)
        {

            var exmp = ReviewService.Get(data.ID);

            if (exmp != null)
            {
                try
                {
                    var res = ReviewService.Update(data);

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



        
    }
}
