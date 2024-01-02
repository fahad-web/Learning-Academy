using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderCourseService
    {
        public static List<OrderCourseDTO> Get()
        {
            var data = DataAccessFactory.OrderCourseData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderCourse, OrderCourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderCourseDTO>>(data);
            return mapped;
        }




        public static OrderCourseDTO Get(int id)
        {
            var data = DataAccessFactory.OrderCourseData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderCourse, OrderCourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderCourseDTO>(data);
            return mapped;
        }




        public static OrderCourseDTO Create(OrderCourseDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderCourse, OrderCourseDTO>();
                c.CreateMap<OrderCourseDTO, OrderCourse>();

            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<OrderCourse>(obj);
            var result = DataAccessFactory.OrderCourseData().Create(data);


            var redata = mapper.Map<OrderCourseDTO>(result);
            return redata;
        }




        public static OrderCourseDTO Delete(int id)
        {
            var data = DataAccessFactory.OrderCourseData().Delete(id);

            if (data == null || !(data is OrderCourse))
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderCourse, OrderCourseDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderCourseDTO>(data);
            return mapped;
        }




        public static OrderCourseDTO Update(OrderCourseDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderCourse, OrderCourseDTO>();
                c.CreateMap<OrderCourseDTO, OrderCourse>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<OrderCourse>(obj);
            var result = DataAccessFactory.OrderCourseData().Update(data);
            var redata = mapper.Map<OrderCourseDTO>(result);
            return redata;
        }
    }
}
