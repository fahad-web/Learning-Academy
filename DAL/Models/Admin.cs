using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Admin
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<Mentors> Mentors { get; set; }
        public Admin()
        {
            Mentors = new List<Mentors>();
        }
    }
}
