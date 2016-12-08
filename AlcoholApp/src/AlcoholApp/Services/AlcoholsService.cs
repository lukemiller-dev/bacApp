using AlcoholApp.Data;
using AlcoholApp.Infrastructure;
using AlcoholApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Services
{
    public class AlcoholsService
    {
        private AlcoholsRepository _repo;

        public AlcoholsService(AlcoholsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<AlcoholDTO> ListAlcohols()
        {
            var alcohols = (from a in _repo.List()
                            select new AlcoholDTO
                            {
                                Id = a.Id,
                                Type = a.Type,
                                Brand = a.Brand,
                                Style = a.Style,
                                ABV = a.ABV,
                                Glasses = (from g in a.Glasses select new GlassDTO
                                {
                                    Id = g.Id,
                                    TimeConsumed = g.TimeConsumed,
                                    Volume = g.Volume,
                                    Night = new NightDTO
                                    {
                                        ApplicationUser = new ApplicationUserDTO
                                        {
                                            BirthDate = g.Night.ApplicationUser.BirthDate,
                                            FirstName = g.Night.ApplicationUser.FirstName,
                                            Height = g.Night.ApplicationUser.Height,
                                            IsMale = g.Night.ApplicationUser.IsMale,
                                            LastName = g.Night.ApplicationUser.LastName,
                                            Weight = g.Night.ApplicationUser.Weight
                                        },
                                        EndTime = g.Night.EndTime,
                                        Id = g.Night.Id,
                                        IsDriving = g.Night.IsDriving,
                                        StartTime = g.Night.StartTime
                                    }
                                }).ToList()
                                
                            }).ToList();
            return alcohols;
        }
    }
}
