using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Learning_Academy.Controllers
{
    public class BuyDetailController : ApiController
    {
        [HttpGet]
        [Route("api/BuyDetail")]
        public HttpResponseMessage BuyDetail()
        {
            try
            {
                var data = BuyDetailService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/BuyDetail/{id}")]
        public HttpResponseMessage BuyDetail(int id)
        {
            try
            {
                var data = BuyDetailService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
