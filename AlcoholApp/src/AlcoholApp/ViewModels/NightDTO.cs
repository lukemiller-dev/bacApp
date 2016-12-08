using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.ViewModels
{
    public class NightDTO
    {
        public int Id { get; set; }
        public bool IsDriving { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<GlassDTO> Glasses { get; set; }
        public ApplicationUserDTO ApplicationUser { get; set; }
    }
}
