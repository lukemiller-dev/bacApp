using AlcoholApp.Data;
using AlcoholApp.Infrastructure;
using AlcoholApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Services
{
    public class AppUsersService
    {
        private AppUsersRepository _repo;

        public AppUsersService(AppUsersRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ApplicationUserDTO> ListAppUsers()
        {
            var appUsers = (from a in _repo.List()
                            select new ApplicationUserDTO
                            {
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                BirthDate = a.BirthDate,
                                Height = a.Height,
                                Weight = a.Weight,
                                IsMale = a.IsMale
                            });

            return appUsers;
        }
    }
}
