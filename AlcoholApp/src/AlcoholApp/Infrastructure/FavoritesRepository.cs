using AlcoholApp.Data;
using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Infrastructure
{
    public class FavoritesRepository : GenericRepository<Favorite>
    {
        public FavoritesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public Favorite GetFavoriteById(int id)
        {
            return (from f in _db.Favorites where f.Id == id select f).FirstOrDefault();
            
        }

    }
}
