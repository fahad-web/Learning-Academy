using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class AdminService
    {

        public static List<AdminDTO> Get()
        {
            var data = DataAccessFactory.AdminData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AdminDTO>>(data);
            return mapped;
        }



        public static AdminDTO Get(int id)
        {
            var data = DataAccessFactory.AdminData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AdminDTO>(data);
            return mapped;
        }



        public static AdminMentorDTO GetwithMentors(int id)
        {
            var data = DataAccessFactory.AdminData().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Admin, AdminMentorDTO>();
                c.CreateMap<Mentors, MentorsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AdminMentorDTO>(data);
            return mapped;

        }
    }
}
