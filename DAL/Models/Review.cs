using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set;}
    }
}
