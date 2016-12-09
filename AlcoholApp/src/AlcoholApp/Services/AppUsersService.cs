using AlcoholApp.Data;
using AlcoholApp.Infrastructure;
using AlcoholApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Services
{
    public class AppUsersService
    {
        private AppUsersRepository _repo;

        public AppUsersService(AppUsersRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ApplicationUserDTO> ListAppUsers()
        {
            var appUsers = (from a in _repo.List()
                            select new ApplicationUserDTO
                            {
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                BirthDate = a.BirthDate,
                                Height = a.Height,
                                Weight = a.Weight,
                                IsMale = a.IsMale,
                                Nights = (from n in a.Nights
                                          select new NightDTO
                                          {
                                              EndTime = n.EndTime,
                                              StartTime = n.StartTime,
                                              Id = n.Id,
                                              IsDriving = n.IsDriving,
                                              Glasses = (from g in n.Glasses
                                                         select new GlassDTO
                                                         {
                                                             Id = g.Id,
                                                             TimeConsumed = g.TimeConsumed,
                                                             Volume = g.Volume,
                                                             Alcohol = new AlcoholDTO
                                                             {
                                                                 Id = g.Alcohol.Id,
                                                                 ABV = g.Alcohol.ABV,
                                                                 Brand = g.Alcohol.Brand,
                                                                 Style = g.Alcohol.Style,
                                                                 Type = g.Alcohol.Type,
                                                                
                                                             }
                                                         }).ToList()
                                          }).ToList()

                            }).ToList();
            return appUsers;
        }
    }
}
