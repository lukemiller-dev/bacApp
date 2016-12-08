using AlcoholApp.Data;
using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Infrastructure
{
    public class AlcoholsRepository : GenericRepository<Alcohol>
    {
        public AlcoholsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<Alcohol> GetById(int id)
        {
            return from a in _db.Alcohols where a.Id == id select a;
        }

        public IQueryable<Alcohol> GetByType(string type)
        {
            return from a in _db.Alcohols where a.Type == type select a;
        }
    }
}
