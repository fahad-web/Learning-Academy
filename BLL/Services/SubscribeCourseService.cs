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
    public class SubscribeCourseService
    {
        public static List<SubscribeCourseDTO> Get()
        {
            var data = DataAccessFactory.SubscribeCourseData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SubscribeCourse, SubscribeCourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SubscribeCourseDTO>>(data);
            return mapped;
        }




        public static SubscribeCourseDTO Get(int id)
        {
            var data = DataAccessFactory.SubscribeCourseData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SubscribeCourse, SubscribeCourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SubscribeCourseDTO>(data);
            return mapped;
        }



        public static SubscribeCourseDTO Delete(int id)
        {
            var data = DataAccessFactory.SubscribeCourseData().Delete(id);

            if (data == null || !(data is DAL.Models.SubscribeCourse))
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SubscribeCourse, SubscribeCourseDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SubscribeCourseDTO>(data);
            return mapped;
        }
    }
}
