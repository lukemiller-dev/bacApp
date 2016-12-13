using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.ViewModels
{
    public class FavoriteDTO
    {
        public string UserId { get; set; }
        public int AlcoholId { get; set; }
        public Alcohol Alcohol { get; set; }
        public ApplicationUser AppUser { get; set; }
    }
}
