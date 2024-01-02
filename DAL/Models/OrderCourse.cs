using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderCourse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public int TotalCost { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }


        public virtual ICollection<BuyDetail> BuyDetails { get; set; }

        public OrderCourse() 
        {
            BuyDetails = new List<BuyDetail>();
        }
    }
}
