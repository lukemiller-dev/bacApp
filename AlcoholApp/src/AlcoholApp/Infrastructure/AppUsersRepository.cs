using AlcoholApp.Data;
using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Infrastructure
{
    public class AppUsersRepository : GenericRepository<ApplicationUser>
    {
        public AppUsersRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
