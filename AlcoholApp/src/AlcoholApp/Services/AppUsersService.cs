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
        private AlcoholsRepository _alcRepo;

        public AppUsersService(AppUsersRepository repo, AlcoholsRepository alcRepo)
        {
            _repo = repo;
            _alcRepo = alcRepo;
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

        public void SetWeight(int weight, string userName)
        {
            var user = (from u in _repo.GetUserByUserName(userName) select u).FirstOrDefault();
            user.Weight = weight;
            _repo.Edit(user);
        }

        public void GetBAC(string userName)
        {
            var user = (from b in _repo.GetUserByUserName(userName) select b).FirstOrDefault();
            var userB = (from b in _repo.GetUserByUserName(userName) select b);

            var timeList = user.Glasses.Where(g => g.IsFavorite == false).OrderBy(x => x).ToList();
            var length = user.Glasses.Where(g => g.IsFavorite == false).Count();
            TimeSpan timeFrame = timeList[length-1].TimeConsumed -  timeList[0].TimeConsumed;          
            var weight = user.Weight;
            var consumedOZ = user.Glasses.Where(a => a.IsFavorite == false).Sum(x => x.Volume);
            double value = 0;

            for(int i = 0; i < length; i++)
            {
                var ABV = userB.FirstOrDefault().Glasses.ToList()[i].Alcohol.ABV;

                var Volume = userB.FirstOrDefault().Glasses.ToList()[i].Volume;

                value = consumedOZ * ABV * 0.075;
                               
            }
            user.BAC = ((value) / weight) - (timeFrame.Hours * 0.015);
         
        }
    }
}
