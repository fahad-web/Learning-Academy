using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseService
    {
        public static CourseDTO Create(StudentDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseDTO>();
                c.CreateMap<CourseDTO, Course>();

            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Course>(obj);
            var result = DataAccessFactory.CourseData().Create(data);


            var redata = mapper.Map<CourseDTO>(result);
            return redata;
        }





        public static List<CourseDTO> Get()
        {
            var data = DataAccessFactory.CourseData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CourseDTO>>(data);
            return mapped;
        }




        public static CourseDTO Get(int id)
        {
            var data = DataAccessFactory.CourseData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CourseDTO>(data);
            return mapped;
        }





        public static CourseDTO Delete(int id)
        {
            var data = DataAccessFactory.CourseData().Delete(id);

            if (data == null || !(data is Course))
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CourseDTO>(data);
            return mapped;
        }



        public static CourseDTO Update(CourseDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseDTO>();
                c.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Course>(obj);
            var result = DataAccessFactory.CourseData().Update(data);
            var redata = mapper.Map<CourseDTO>(result);
            return redata;
        }



        public static CourseReviewDTO GetwithReview(int id)
        {
            var data = DataAccessFactory.CourseData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Course, CourseReviewDTO>();
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CourseReviewDTO>(data);
            return mapped;

        }
    }
}
