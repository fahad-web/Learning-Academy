using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("Mentors")]
        public int AddBy { get; set; }

        public virtual Mentors Mentors { get; set; }

        public virtual ICollection<SubscribeCourse> SubscribeCourses { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<OrderCourse> OrderCourses { get; set; }
        


        public Student() { 
            SubscribeCourses = new List<SubscribeCourse>();
            Payments = new List<Payment>();
            OrderCourses = new List<OrderCourse>();
        }
    }
}
