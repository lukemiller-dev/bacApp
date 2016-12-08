using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.ViewModels
{
    public class GlassDTO
    {
        public int Id { get; set; }
        public decimal Volume { get; set; }
        public DateTime TimeConsumed { get; set; }
        public NightDTO Night { get; set; }
        public AlcoholDTO Alcohol { get; set; }
    }
}
