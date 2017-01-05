using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.ViewModels
{
    public class GlassDTO
    {
        public int Id { get; set; }
        public double Volume { get; set; }
        public DateTime TimeConsumed { get; set; }
        public bool IsFavorite { get; set; }
        public AlcoholDTO Alcohol { get; set; }
        public ApplicationUserDTO AppUser { get; set; }
        public List<string> Volumes { get; set; }
    }
}
