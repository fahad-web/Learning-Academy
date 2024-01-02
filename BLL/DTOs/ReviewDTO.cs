using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReviewDTO
    {
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }

        
        public int CourseId { get; set; }

        
        public int StudentId { get; set; }
    }
}
