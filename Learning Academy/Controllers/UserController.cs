using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Learning_Academy.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/users/{Username}")]
        public HttpResponseMessage Users(string Username, AdminService adminService)
        {
            try
            {
                var data = UserService.Get(Username);
                if (data.Role == "Admin")
                {
                    UserService.Equals(Username, adminService);
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
