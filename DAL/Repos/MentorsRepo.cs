using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MentorsRepo : Repo, IRepo<Mentors, int, Mentors>
    {
        public Mentors Create(Mentors obj)
        {
            db.Mentors.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Mentors.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Mentors> Get()
        {
            var data = db.Mentors.ToList();
            return data;
        }

        public Mentors Get(int id)
        {
            var data = db.Mentors.Find(id);
            return data;
        }

        public Mentors Update(Mentors obj)
        {
            var ex = Get(obj.ID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj; else return null;
        }
    }
}
