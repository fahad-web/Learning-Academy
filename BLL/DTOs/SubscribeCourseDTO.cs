﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SubscribeCourseDTO
    {
        public int ID { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }
    }
}
