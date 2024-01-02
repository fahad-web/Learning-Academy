using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StudentRepo : Repo, IRepo<Student, int, Student>
    {
        public Student Create(Student obj)
        {
            db.Students.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Students.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Student> Get()
        {
            var data = db.Students.ToList();
            return data;
        }

        public Student Get(int id)
        {
            var data = db.Students.Find(id);
            return data;
        }

        public Student Update(Student obj)
        {
            var ex = Get(obj.ID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj; else return null;
        }
    }
}
