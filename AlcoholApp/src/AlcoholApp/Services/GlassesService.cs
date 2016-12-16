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
       

        //Constructor
        public GlassesService(GlassesRepository repo, AlcoholsRepository ARepo)
        {
            _repo = repo;
            _ARepo = ARepo;
           
        }

        //Get
       

        //Add
        public void Add(GlassDTO glassDTO)
        {
            var glass = new Glass
            {
                Volume = glassDTO.Volume,
                TimeConsumed = glassDTO.TimeConsumed,
                Alcohol = _ARepo.GetById(glassDTO.Alcohol.Id)
               
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
