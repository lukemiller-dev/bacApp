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
    public class GlassesService
    {
        private GlassesRepository _repo;
        private AlcoholsRepository _ARepo;
        private NightsRepository _NRepo;

        public GlassesService(GlassesRepository repo, AlcoholsRepository ARepo, NightsRepository NRepo)
        {
            _repo = repo;
            _ARepo = ARepo;
            _NRepo = NRepo;
        }

        public IEnumerable<GlassDTO> ListGlasses()
        {
            var glasses = (from g in _repo.List()
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
                                   Type = g.Alcohol.Type
                               },
                               Night = new NightDTO
                               {
                                   ApplicationUser = new ApplicationUserDTO
                                   {
                                       Height =  g.Night.ApplicationUser.Height,
                                       BirthDate = g.Night.ApplicationUser.BirthDate,
                                       FirstName = g.Night.ApplicationUser.FirstName,
                                       LastName = g.Night.ApplicationUser.LastName,
                                       IsMale = g.Night.ApplicationUser.IsMale,
                                       Weight = g.Night.ApplicationUser.Weight
                                   },
                                   Id = g.Night.Id,
                                   EndTime = g.Night.EndTime,
                                   IsDriving = g.Night.IsDriving,
                                   StartTime = g.Night.StartTime
                               }
                           }).ToList();
            return glasses;
        }

        public void Add(GlassDTO glassDTO)
        {
            var glass = new Glass
            {
                Volume = glassDTO.Volume,
                TimeConsumed = glassDTO.TimeConsumed,
                Alcohol = _ARepo.GetById(glassDTO.Alcohol.Id).FirstOrDefault(),
                Night = _NRepo.GetById(glassDTO.Night.Id).FirstOrDefault()      
            };
            _repo.Add(glass);
        }
    }
}
