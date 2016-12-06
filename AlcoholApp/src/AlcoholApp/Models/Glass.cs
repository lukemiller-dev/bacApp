using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Models
{
    public class Glass
    {
        public int Id { get; set; }
        public decimal Volume { get; set; }
        public DateTime TimeConsumed { get; set; }
        public Alcohol Alcohol { get; set; }
        public int NightId { get; set; }
        [ForeignKey("NightId")]
        public Night Night { get; set; }
    }
}
