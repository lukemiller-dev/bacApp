using AlcoholApp.Data;
using AlcoholApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlcoholApp.Infrastructure
{
    public class GenericRepository<T> where T : class
    {
        protected ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get User by UserName

        public IQueryable<ApplicationUser> GetUserByUserName(string userName)
        {
            return from u in _db.Users where u.UserName == userName select u;
        }

        //Get
        public IQueryable<T> List()
        {
            return _db.Set<T>();
        }

        //Post
        public void Add(T value)
        {
            _db.Set<T>().Add(value);
            _db.SaveChanges();
        }

        //Delete
        public void Delete(T value)
        {
            _db.Set<T>().Remove(value);
            _db.SaveChanges();
        }

        //Edit
        public void Edit(T value)
        {
            _db.Set<T>().Update(value);
            _db.SaveChanges();
        }
    }
}
