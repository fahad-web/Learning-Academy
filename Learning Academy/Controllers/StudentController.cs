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
    public class StudentController : ApiController
    {
        
        [HttpPost]
        [Route("api/Student/create")]
        public HttpResponseMessage Create(StudentDTO data)
        {
            try
            {
                var res = StudentService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/Student")]
        public HttpResponseMessage Student()
        {
            try
            {
                var data = StudentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/Student/{id}")]
        public HttpResponseMessage Student(int id)
        {
            try
            {
                var data = StudentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }



        [HttpPost]
        [Route("api/Student/delete/{id}")] 
        public HttpResponseMessage Delete(int id)
        {
            var exmp = StudentService.Get(id);

            if (exmp != null)
            {
                try
                {
                    var res = StudentService.Delete(id);
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
        [Route("api/Student/update")]
        public HttpResponseMessage Update(StudentDTO data)
        {

            var exmp = StudentService.Get(data.ID);

            if (exmp != null)
            {
                try
                {
                    var res = StudentService.Update(data);

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
        [Route("api/Student/{id}/Course")]
        public HttpResponseMessage StudentCourse(int id)
        {
            try
            {
                var data = StudentService.GetwithCourse(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
