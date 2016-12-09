using AlcoholApp.Data;
using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Infrastructure
{
    public class GlassesRepository : GenericRepository<Glass>
    {
        //Constructor
        public GlassesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //GetById
        public IQueryable<Glass> GetGlassById(int id)
        {
            return from g in _db.Glasses where g.Id == id select g;
        }
    }
}
