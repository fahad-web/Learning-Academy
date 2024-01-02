using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseReviewDTO:CourseDTO
    {
        public List<ReviewDTO> Reviews { get; set; }

        public CourseReviewDTO()
        {
            Reviews = new List<ReviewDTO>();
        }
    }
}
