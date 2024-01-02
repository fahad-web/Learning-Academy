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
    public class MentorsService
    {
        public static List<MentorsDTO> Get()
        {
            var data = DataAccessFactory.MentorsData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Mentors, MentorsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<MentorsDTO>>(data);
            return mapped;
        }



        public static MentorsDTO Get(int id)
        {
            var data = DataAccessFactory.MentorsData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Mentors, MentorsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<MentorsDTO>(data);
            return mapped;
        }




        public static MentorsDTO Delete(int id)
        {
            var data = DataAccessFactory.MentorsData().Delete(id);

            if (data == null || !(data is Mentors))
            {
                return null;
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Mentors, MentorsDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<MentorsDTO>(data);
            return mapped;
        }



        public static MentorsDTO Update(MentorsDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Mentors, MentorsDTO>();
                c.CreateMap<MentorsDTO, Mentors>();
            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Mentors>(obj);
            var result = DataAccessFactory.MentorsData().Update(data);
            var redata = mapper.Map<MentorsDTO>(result);
            return redata;
        }
    }
}
