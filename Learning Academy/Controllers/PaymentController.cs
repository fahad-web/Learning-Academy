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
    public class PaymentController : ApiController
    {
        [HttpPost]
        [Route("api/Payment/create")]
        public HttpResponseMessage Create(PaymentDTO data)
        {
            try
            {
                var res = PaymentService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/Payment")]
        public HttpResponseMessage Payment()
        {
            try
            {
                var data = PaymentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Payment/{id}")]
        public HttpResponseMessage Payment(int id)
        {
            try
            {
                var data = PaymentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
