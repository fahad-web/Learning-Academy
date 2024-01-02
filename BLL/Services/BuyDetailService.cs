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
    public class BuyDetailService
    {
        public static List<BuyDetailDTO> Get()
        {
            var data = DataAccessFactory.BuyDetailData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BuyDetail, BuyDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BuyDetailDTO>>(data);
            return mapped;
        }




        public static BuyDetailDTO Get(int id)
        {
            var data = DataAccessFactory.BuyDetailData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BuyDetail, BuyDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BuyDetailDTO>(data);
            return mapped;
        }
    }
}
