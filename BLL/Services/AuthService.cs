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
    public class AuthService
    {
        public static TokenDTO Authenticate(string username, string password)
        {
            var result = DataAccessFactory.AuthData().Authenticate(username, password);
            if (result)
            {
                
                var token = new Token();
                token.Username = username;
                token.CreatedAt = DateTime.Now;
                /*token.DeletedAt = DateTime.Now;*/
                token.TKey = Guid.NewGuid().ToString().Substring(1, 10);

                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }
                /*DataAccessFactory.TokenData().Update(token);*/
            }
            return null;
        }


        public static bool IsTokenValid(string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            if (existingToken != null && existingToken.DeletedAt == null)
            {
                return true;
            }
            return false;
        }

        public static bool Logout(string TKey)
        {
            var existingToken = DataAccessFactory.TokenData().Get(TKey);
            existingToken.DeletedAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(existingToken) != null)
            {
                return true;
            }
            return false;
        }


        public static bool IsAdmin(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (IsTokenValid(tkey) && extk.User.Role.Equals("Admin"))
            {
                return true;
            }
            return false;
        }
    }
}
