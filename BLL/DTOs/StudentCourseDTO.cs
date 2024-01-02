using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentCourseDTO:StudentDTO
    {
        public List<SubscribeCourseDTO> SubscribeCourses { get; set; }    
        public StudentCourseDTO() {
            SubscribeCourses = new List<SubscribeCourseDTO>();
        }
    }
}
