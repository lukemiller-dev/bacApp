using AlcoholApp.Infrastructure;
using AlcoholApp.Models;
using AlcoholApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Services
{
    public class FavoritesService
    {
        private FavoritesRepository _repo;
        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        public void AddFav(int alcoholId, string userName)
        {
            var user = _repo.GetUserByUserName(userName);
            var newFav = new Favorite
            {
                UserId = user.Id,
                AlcoholId = alcoholId
            };

            _repo.Add(newFav);  
                         
        }

        public IEnumerable<AlcoholDTO> GetFavoritesDtos(string userName)
        {
            var favorites = (from f in _repo.List()
                             where f.AppUser.UserName == userName
                             select new AlcoholDTO
                             {
                                 Id = f.Alcohol.Id,
                                 ABV = f.Alcohol.ABV,
                                 Brand = f.Alcohol.Brand,
                                 Style = f.Alcohol.Style,
                                 Type = f.Alcohol.Type
                             });

            return favorites;
        }

        public IQueryable<Alcohol> GetRelations(string userName)
        {
            return (from f in _repo.List()
                    where f.AppUser.UserName == userName
                    select f.Alcohol);
        }

        public IEnumerable<Alcohol> GetFavorites(string userName)
        {
            var favorites = (from f in _repo.List()
                             where f.AppUser.UserName == userName
                             select new Alcohol
                             {
                                 Id = f.Alcohol.Id,
                                 ABV = f.Alcohol.ABV,
                                 Brand = f.Alcohol.Brand,
                                 Style = f.Alcohol.Style,
                                 Type = f.Alcohol.Type
                             }).ToList();

            return favorites;
        }

        public void DeleteFav(string userId, int alcId)
        {
            var favorite = _repo.GetFavoriteById(userId, alcId);
            _repo.Delete(favorite);
        }
    }
}
