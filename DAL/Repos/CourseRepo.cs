using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseRepo : Repo, IRepo<Course, int, Course>
    {
        public Course Create(Course obj)
        {
            db.Courses.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Courses.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Course> Get()
        {
            var data = db.Courses.ToList();
            return data;
        }

        public Course Get(int id)
        {
            var data = db.Courses.Find(id);
            return data;
        }

        public Course Update(Course obj)
        {
            var ex = Get(obj.ID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj; else return null;
        }
    }
}
