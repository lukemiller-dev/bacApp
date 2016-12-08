using AlcoholApp.Data;
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
    }
}
