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
        public GlassesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public Glass GetGlassById(string userId, int alcId)
        {
            return (from f in _db.Glasses where (f.Id == alcId) select f).FirstOrDefault();
        }

        public IQueryable<Glass> GetGlassByUserNotFavorite(string userName)
        {
            return (from f in _db.Glasses where (f.AppUser.UserName == userName) && (f.IsFavorite == false) orderby f.TimeConsumed descending select f);
        }

        public Glass GetNDeleteFalse(string userId, int glassId)
        {
           return (from g in _db.Glasses where (g.Id == glassId) select g).FirstOrDefault();
        }

        public IQueryable<Glass> DeleteAllFalseGlasses(string userName)
        {
            return (from g in _db.Glasses where (g.AppUser.UserName == userName) && (g.IsFavorite == false) select g);
        }

        public IQueryable<Glass> GetGlassByUserFavorite(string userName)
        {
            return (from g in _db.Glasses where ((g.AppUser.UserName == userName) && (g.IsFavorite == true)) select g);
        }

        public IEnumerable<Glass> GetGlassByUser(string userName)
        {
            return (from g in _db.Glasses where (g.AppUser.UserName == userName) select g).ToList();
        }

        public IQueryable<Glass> GetLastGlass()
        {
            return (from g in _db.Glasses orderby g.TimeConsumed ascending select g);
        }

    }
}
