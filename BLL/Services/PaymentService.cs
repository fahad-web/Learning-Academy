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
    public class PaymentService
    {
        public static List<PaymentDTO> Get()
        {
            var data = DataAccessFactory.PaymentData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PaymentDTO>>(data);
            return mapped;
        }




        public static PaymentDTO Get(int id)
        {
            var data = DataAccessFactory.PaymentData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PaymentDTO>(data);
            return mapped;
        }




        public static PaymentDTO Create(PaymentDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Payment, PaymentDTO>();
                c.CreateMap<PaymentDTO, Payment>();

            });
            var mapper = new Mapper(cfg);
            var data = mapper.Map<Payment>(obj);
            var result = DataAccessFactory.PaymentData().Create(data);


            var redata = mapper.Map<PaymentDTO>(result);
            return redata;
        }
    }
}
