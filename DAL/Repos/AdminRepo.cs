using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin, int, Admin>
    {
        public Admin Create(Admin obj)
        {
            db.Admins.Add(obj);
            if(db.SaveChanges()>0 ) return obj; 
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Admins.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            var data = db.Admins.ToList();
            return data;
        }

        public Admin Get(int id)
        {
            var data = db.Admins.Find(id);
            return data;
        }

        public Admin Update(Admin obj)
        {
            var ex = Get(obj.ID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0 ) return obj; else return null;
        }
    }
}
