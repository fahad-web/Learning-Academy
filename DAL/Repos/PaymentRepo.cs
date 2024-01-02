using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentRepo : Repo, IRepo<Payment, int, Payment>
    {
        public Payment Create(Payment obj)
        {
            db.Payments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> Get()
        {
            var data = db.Payments.ToList();
            return data;
        }

        public Payment Get(int id)
        {
            var data = db.Payments.Find(id);
            return data;
        }

        public Payment Update(Payment obj)
        {
            throw new NotImplementedException();
        }
    }
}
