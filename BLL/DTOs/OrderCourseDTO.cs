using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderCourseDTO
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public int TotalCost { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
