using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BuyDetail
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("OrderCourse")]
        public int OrderId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual OrderCourse OrderCourse { get; set; }

        public virtual Course Course { get; set; }
    }
}
