﻿using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReviewRepo : Repo, IRepo<Review, int, Review>
    {
        public Review Create(Review obj)
        {
            db.Reviews.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            else return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Reviews.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Review> Get()
        {
            var data = db.Reviews.ToList();
            return data;
        }

        public Review Get(int id)
        {
            var data = db.Reviews.Find(id);
            return data;
        }

        public Review Update(Review obj)
        {
            var ex = Get(obj.ID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj; else return null;
        }
    }
}
