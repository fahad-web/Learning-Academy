using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class LearningAcademyContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Mentors> Mentors { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<OrderCourse> OrderCourses { get; set; }

        public DbSet<SubscribeCourse> SubscribeCourses { get; set; }

        public DbSet<BuyDetail> BuyDetails { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Token> Tokens { get; set; }
    }
}
