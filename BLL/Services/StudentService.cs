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
    public class StudentService
    {
        public static List<StudentDTO> Get()
        {
            var data = DataAccessFactory.StudentData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Student, StudentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<StudentDTO>>(data);
            return mapped;
        }




        public static StudentDTO Get(int id)
        {
            var data = DataAccessFactory.StudentData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Student, StudentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<StudentDTO>(data);
            return mapped;
        }




        public static StudentDTO Create(StudentDTO obj) 
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Student, StudentDTO>();
                c.CreateMap<StudentDTO, Student>();
                
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Student>(obj);
            var result = DataAccessFactory.StudentData().Create(data);
           
            
            var redata = mapper.Map<StudentDTO>(result);
            return redata;
        }




        public static StudentDTO Delete(int id)
        {
            var data = DataAccessFactory.StudentData().Delete(id);

            if (data == null || !(data is Student))
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Student, StudentDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<StudentDTO>(data);
            return mapped;
        }




        public static StudentDTO Update(StudentDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Student, StudentDTO>();
                c.CreateMap<StudentDTO, Student>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Student>(obj);
            var result = DataAccessFactory.StudentData().Update(data);
            var redata = mapper.Map<StudentDTO>(result);
            return redata;
        }




        public static StudentCourseDTO GetwithCourse(int id)
        {
            var data = DataAccessFactory.StudentData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Student, StudentCourseDTO>();
                c.CreateMap<SubscribeCourse, SubscribeCourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<StudentCourseDTO>(data);
            return mapped;

        }
    }
}
