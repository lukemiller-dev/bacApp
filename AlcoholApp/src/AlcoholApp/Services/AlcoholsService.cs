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
    public class AlcoholsService
    {
        //Injection
        private AlcoholsRepository _repo;
        private GlassesService _glassService;

        //Constructor

        public AlcoholsService(AlcoholsRepository repo, GlassesService glassService)
        {
            _repo = repo;
            _glassService = glassService;
        }

        public List<decimal> GetAlcoholTypeVolumes(string type)
        {
            var beer = new List<decimal> { 8, 12, 16 };
            var spirit = new List<decimal> { 1.5m, 3, 4.5m };
            var wine = new List<decimal> { 5, 12, 16 };

            switch (type)
            {
                case "Beer":
                    return beer;
                case "Spirit":
                    return spirit;
                case "Wine":
                    return wine;
                default:
                    return null;
            }
        }

        //GetInNav 

        public AlcoholDTO ListId(int id)
        {
            var alcoholId = _repo.GetById(id).FirstOrDefault();
            return new AlcoholDTO
            {
                Id = alcoholId.Id,
                ABV = alcoholId.ABV,
                Brand = alcoholId.Brand,
                Style = alcoholId.Style,
                Type = alcoholId.Type
            };   
        }

        public IEnumerable<AlcoholDTO> ListUnsavedAlcohols(string userName)
        {
            IEnumerable<Alcohol> favorites = _glassService.GetRelations(userName);
            var alcohols = (from a in _repo.List().AsEnumerable()
                            where !favorites.Contains(a)
                            select new AlcoholDTO
                            {
                                Id = a.Id,
                                ABV = a.ABV,
                                Brand = a.Brand,
                                Style = a.Style,
                                Type = a.Type
                            }).ToList();

            return alcohols;
        }

        //Get
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
                                //Glasses = (from g in a.Glasses select new GlassDTO
                                //{
                                //    Id = g.Id,
                                //    TimeConsumed = g.TimeConsumed,
                                //    Volume = g.Volume,
                                //    Night = new NightDTO
                                //    {
                                //        ApplicationUser = new ApplicationUserDTO
                                //        {
                                //            BirthDate = g.Night.ApplicationUser.BirthDate,
                                //            FirstName = g.Night.ApplicationUser.FirstName,
                                //            Height = g.Night.ApplicationUser.Height,
                                //            IsMale = g.Night.ApplicationUser.IsMale,
                                //            LastName = g.Night.ApplicationUser.LastName,
                                //            Weight = g.Night.ApplicationUser.Weight
                                //        },
                                //        EndTime = g.Night.EndTime,
                                //        Id = g.Night.Id,
                                //        IsDriving = g.Night.IsDriving,
                                //        StartTime = g.Night.StartTime
                                //    }
                                //}).ToList()
                                
                            }).ToList();
            return alcohols;
        }

        //Get By Id

        public AlcoholDTO SelectAlcohols(int id)
        {
            var alcohols = (from a in _repo.List()
                            where a.Id == id
                            select new AlcoholDTO
                            {
                                Id = a.Id,
                                Type = a.Type,
                                Brand = a.Brand,
                                Style = a.Style,
                                ABV = a.ABV,
                                Volumes = GetAlcoholTypeVolumes(a.Type)
                            }).FirstOrDefault();
            return alcohols;
        }

        //Add
        public void Add(AlcoholDTO alcoholDTO)
        {
            var alcohol = new Alcohol
            {
                ABV = alcoholDTO.ABV,
                Brand = alcoholDTO.Brand,
                Style = alcoholDTO.Style,
                Type = alcoholDTO.Type
            };

            _repo.Add(alcohol);
        }
        
        //Edit
        //public void Edit(AlcoholDTO alcoholDTO, int id)
        //{
        //    var a = _repo.GetById(id).FirstOrDefault();
        //    a.ABV = alcoholDTO.ABV;
        //    a.Brand = alcoholDTO.Brand;
        //    a.Style = alcoholDTO.Style;
        //    a.Type = alcoholDTO.Type;
               
        //}
    }
}
