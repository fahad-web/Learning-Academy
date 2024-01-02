using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AdminMentorDTO:AdminDTO
    {
        public List<MentorsDTO> Mentors { get; set; }
        public AdminMentorDTO() { 
            Mentors = new List<MentorsDTO>();
        }
    }
}
