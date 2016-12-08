using AlcoholApp.Data;
using AlcoholApp.Infrastructure;
using AlcoholApp.Models;
using AlcoholApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Services
{
    public class NightsService
    {
        private NightsRepository _repo;

        public NightsService(NightsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<NightDTO> ListNights()
        {
            var nights = (from n in _repo.List()
                          select new NightDTO
                          {
                              ApplicationUser = new ApplicationUserDTO
                              {
                                  FirstName = n.ApplicationUser.FirstName,
                                  LastName = n.ApplicationUser.LastName,
                                  BirthDate = n.ApplicationUser.BirthDate,
                                  Height = n.ApplicationUser.Height,
                                  IsMale = n.ApplicationUser.IsMale,
                                  Weight = n.ApplicationUser.Weight
                              },
                              EndTime = n.EndTime,
                              IsDriving = n.IsDriving,
                              StartTime = n.StartTime,
                              Id = n.Id,
                              Glasses = (from g in n.Glasses
                                         select new GlassDTO
                                         {
                                             Id = g.Id,
                                             TimeConsumed = g.TimeConsumed,
                                             Volume = g.Volume,
                                             Alcohol = new AlcoholDTO
                                             {
                                                 ABV = g.Alcohol.ABV,
                                                 Brand = g.Alcohol.Brand,
                                                 Id = g.Alcohol.Id,
                                                 Style = g.Alcohol.Style,
                                                 Type = g.Alcohol.Type
                                             }
                                         }).ToList()


                          }
                ).ToList();
            return nights;
        }

        public void Add(NightDTO nightDTO)
        {
            var night = new Night
            {
                StartTime = nightDTO.StartTime,
                EndTime = nightDTO.EndTime,
                IsDriving = nightDTO.IsDriving
            };
            _repo.Add(night);
        }
    }
}
