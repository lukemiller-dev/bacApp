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
        public DateTime TimeConsumed { get; set; }
        public double Volume { get; set; }
        public bool IsFavorite { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser AppUser { get; set; }
        public int AlcoholId { get; set; }
        [ForeignKey("AlcoholId")]
        public Alcohol Alcohol { get; set; }
    }
}
