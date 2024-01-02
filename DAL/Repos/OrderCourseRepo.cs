using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderCourseRepo : Repo, IRepo<OrderCourse, int, OrderCourse>
    {
        public OrderCourse Create(OrderCourse obj)
        {
            db.OrderCourses.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.OrderCourses.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<OrderCourse> Get()
        {
            var data = db.OrderCourses.ToList();
            return data;
        }

        public OrderCourse Get(int id)
        {
            var data = db.OrderCourses.Find(id);
            return data;
        }

        public OrderCourse Update(OrderCourse obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj; else return null;
        }
    }
}
