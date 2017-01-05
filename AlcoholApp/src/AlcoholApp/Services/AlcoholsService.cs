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

        //public GlassDTO GetLastGlass()
        //{
        //    var l
        //}

        public List<string> GetAlcoholTypeVolumes(string type)
        {
            var beer = new List<string> { "8 oz (Can)", "12 oz", "16 oz" };
            var spirit = new List<string> { "1.5 oz Shot", "3 oz Double Shot" };
            var wine = new List<string> { "5", "12", "16" };

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


        public string GetDrinkIcons(string type)
        {
            var beerI = "http://i.imgur.com/Vjrcg7e.png";
            var spiritI = "http://i.imgur.com/sHH0r9w.png";
            var wineI = "http://i.imgur.com/csqRohq.png";

            switch (type)
            {
                case "Beer":
                    return beerI;
                case "Spirit":
                    return spiritI;
                case "Wine":
                    return wineI;
                default:
                    return beerI;
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
                                Icon = GetDrinkIcons(a.Type),
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

        public void Delete(int id)
        {
            var alcohol = _repo.GetById(id).FirstOrDefault();
            _repo.Delete(alcohol);


        }
        public void editAlcohol(int id,AlcoholDTO Alco)
        {
            var alc = _repo.GetById(id).FirstOrDefault();
            alc.ABV = Alco.ABV;
            alc.Brand = Alco.Brand;
            alc.Style = Alco.Style;
            alc.Type = Alco.Type;
            _repo.Edit(alc);
        }
    }
}
