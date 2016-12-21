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

        public double GetBAC(string userName)
        {
            var user = (from b in _repo.GetUserByUserName(userName) select b).FirstOrDefault();
            var userB = (from b in _repo.GetUserByUserName(userName) select b);

            //var timeList = _repo.AppUserNotFavorite(userName).FirstOrDefault().Glasses.ToList();
            var timeList = _repo.GlassesToAdd(userName).ToList();
            var length = timeList.Count;
            TimeSpan timeFrame =DateTime.Now -  timeList[0].TimeConsumed;          
            var weight = user.Weight;
           
            double value = 0;

            for(int i = 0; i < length; i++)
            {
                //var ABV = timeList[i].Alcohol.ABV;
                var ABV = _alcRepo.GetById(timeList[i].AlcoholId).FirstOrDefault().ABV;

                var Volume = timeList[i].Volume;

                value = value + Volume * ABV * 0.075;
                               
            }
            return user.BAC = ((value) / weight) - (( timeFrame.Hours * 60 + timeFrame.Minutes)/60 * 0.015);
         
        }
    }
}
