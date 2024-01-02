using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseDTO
    {
        public int ID { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string Discription { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int MentorsId { get; set; }
    }
}
