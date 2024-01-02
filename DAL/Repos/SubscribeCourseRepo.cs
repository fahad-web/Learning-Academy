using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SubscribeCourseRepo : Repo, IRepo<SubscribeCourse, int, SubscribeCourse>
    {
        public SubscribeCourse Create(SubscribeCourse obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.SubscribeCourses.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<SubscribeCourse> Get()
        {
            var data = db.SubscribeCourses.ToList();
            return data;
        }

        public SubscribeCourse Get(int id)
        {
            var data = db.SubscribeCourses.Find(id);
            return data;
        }

        public SubscribeCourse Update(SubscribeCourse obj)
        {
            throw new NotImplementedException();
        }
    }
}
