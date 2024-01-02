using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string Discription { get; set; }

        [Required]
        public int Price { get; set; }

        [ForeignKey("Mentors")]
        public int MentorsId { get; set; }

        public virtual Mentors Mentors { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<OrderCourse> OrderCosts { get; set; }

        public Course() 
        {
            Reviews = new List<Review>();
            OrderCosts = new List<OrderCourse>();
        }
    }
}
