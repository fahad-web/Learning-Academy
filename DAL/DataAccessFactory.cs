using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Admin,int,Admin> AdminData()
        {
            return new AdminRepo();
        }

        public static IRepo<Student, int, Student> StudentData()
        {
            return new StudentRepo();
        }

        public static IRepo<Mentors, int, Mentors> MentorsData()
        {
            return new MentorsRepo();
        }

        public static IRepo<Course, int, Course> CourseData()
        {
            return new CourseRepo();
        }

        public static IRepo<Review, int, Review> ReviewData()
        {
            return new ReviewRepo();
        }

        public static IRepo<OrderCourse, int, OrderCourse> OrderCourseData()
        {
            return new OrderCourseRepo();
        }

        public static IRepo<SubscribeCourse, int, SubscribeCourse> SubscribeCourseData()
        {
            return new SubscribeCourseRepo();
        }

        public static IRepo<Payment, int, Payment> PaymentData()
        {
            return new PaymentRepo();
        }

        public static IRepo<BuyDetail, int, BuyDetail> BuyDetailData()
        {
            return new BuyDetailRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }

        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }

        
    }
}

