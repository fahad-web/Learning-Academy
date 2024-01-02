using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BuyDetailRepo : Repo, IRepo<BuyDetail, int, BuyDetail>
    {
        public BuyDetail Create(BuyDetail obj)
        {
            db.BuyDetails.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BuyDetail> Get()
        {
            var data = db.BuyDetails.ToList();
            return data;
        }

        public BuyDetail Get(int id)
        {
            var data = db.BuyDetails.Find(id);
            return data;
        }

        public BuyDetail Update(BuyDetail obj)
        {
            throw new NotImplementedException();
        }
    }
}
