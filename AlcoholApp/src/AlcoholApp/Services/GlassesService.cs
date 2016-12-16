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
        //Injections
        private GlassesRepository _repo;
        private AlcoholsRepository _ARepo;
        private NightsRepository _NRepo;

        //Constructor
        public GlassesService(GlassesRepository repo, AlcoholsRepository ARepo, NightsRepository NRepo)
        {
            _repo = repo;
            _ARepo = ARepo;
            _NRepo = NRepo;
        }

        //Get
        public IEnumerable<GlassDTO> GetGlassesDtos(int nightId)
        {
            var glasses = (from g in _repo.List()
                           where g.NightId == nightId
                           select new GlassDTO
                           {
                               Id = g.Id,
                               TimeConsumed = g.TimeConsumed,
                               Volume = g.Volume,
                               Night = new NightDTO
                               {
                                   Id = g.NightId
                               },
                               Alcohol = new AlcoholDTO
                               {
                                   Id = g.AlcoholId,
                                   ABV = g.Alcohol.ABV,
                                   Brand = g.Alcohol.Brand,
                                   Style = g.Alcohol.Style,
                                   Type = g.Alcohol.Type,

                               }


                           }).ToList();
            return glasses;
        }

        //Add
        public void Add(GlassDTO glassDTO)
        {
            var glass = new Glass
            {
                Volume = glassDTO.Volume,
                TimeConsumed = glassDTO.TimeConsumed,
                Alcohol = _ARepo.GetById(glassDTO.Alcohol.Id),
                Night = _NRepo.GetById(glassDTO.Night.Id).FirstOrDefault()
            };
            _repo.Add(glass);
        }

        //Edit
        public void Edit(GlassDTO glassDTO, int id)
        {
            var g = _repo.GetGlassById(id).FirstOrDefault();
            //g.Alcohol = _ARepo.GetById(glassDTO.Alcohol.Id).FirstOrDefault();
            g.TimeConsumed = glassDTO.TimeConsumed;
            g.Volume = glassDTO.Volume;
            //g.Night = _NRepo.GetById(glassDTO.Night.Id).FirstOrDefault();
            _repo.Edit(g);
        }

        //Delete
        public void Delete(int id)
        {
            var glass = _repo.GetGlassById(id).FirstOrDefault();
            _repo.Delete(glass);
        }
    }
}
