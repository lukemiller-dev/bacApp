﻿using AlcoholApp.Data;
using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Infrastructure
{
    public class AlcoholsRepository : GenericRepository<Alcohol>
    {
        //Constructor
        public AlcoholsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //GetById
        public IQueryable<Alcohol> GetById(int id)
        {
            return (from a in _db.Alcohols where a.Id == id select a);
        }

        //GetByType
        public IQueryable<Alcohol> GetByType(string type)
        {
            return from a in _db.Alcohols where a.Type == type select a;
        }

        

        //internal void Delete(IQueryable<Alcohol> alcohol)
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<Alcohol> GetABV(decimal abv)
        //{
        //    return from a in _db.Alcohols where a.ABV == abv select a;
        //}
    }
}
