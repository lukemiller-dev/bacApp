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
        
        public IQueryable<ApplicationUser> AppUserNotFavorite(string userName)
        {
            return from a in _db.Users
                   where a.UserName == userName
                   from g in a.Glasses
                   where g.IsFavorite == false
                   select a;
        }

        public IQueryable<Glass> GlassesToAdd(string userName)
        {
            return from a in _db.Users
                   where a.UserName == userName
                   from g in a.Glasses
                   where g.IsFavorite == false
                   select g;
        }
      
    }
}
