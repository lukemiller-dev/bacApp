using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Models
{
    public class Alcohol
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Style { get; set; }
        public decimal ABV { get; set; }
        public ICollection<Glass> Glasses { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
    }
}
