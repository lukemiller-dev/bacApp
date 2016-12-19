﻿using AlcoholApp.Data;
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
            return (from f in _db.Glasses where ((f.AppUser.UserName == userId) && (f.AlcoholId == alcId)) select f).FirstOrDefault();
        }

        public IQueryable<Glass> GetGlassByUserNotFavorite(string userName)
        {
            return (from f in _db.Glasses where (f.AppUser.UserName == userName) && (f.IsFavorite == false) select f);
        }

        public IEnumerable<Glass> GetGlassByUserFavorite(string userName)
        {
            return (from g in _db.Glasses where ((g.AppUser.UserName == userName) && (g.IsFavorite == true)) select g).ToList();
        }

        public IEnumerable<Glass> GetGlassByUser(string userName)
        {
            return (from g in _db.Glasses where (g.AppUser.UserName == userName) select g).ToList();
        }

    }
}
