using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.ViewModels
{
    public class AlcoholDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Style { get; set; }
        public decimal ABV { get; set; }
        public ICollection<GlassDTO> Glasses { get; set; }
    }
}
