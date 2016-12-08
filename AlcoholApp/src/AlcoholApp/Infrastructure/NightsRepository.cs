using AlcoholApp.Data;
using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Infrastructure
{
    public class NightsRepository : GenericRepository<Night>  // <Night> is <T>
    {
        public NightsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<Night> GetById(int id)
        {
            return from n in _db.Nights where n.Id == id select n;
        }
    }
}
