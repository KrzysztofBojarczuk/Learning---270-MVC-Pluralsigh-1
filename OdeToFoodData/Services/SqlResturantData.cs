using OdeToFoodData.Models;
using OdeToFoodData.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFoodData.Services
{
    public class SqlResturantData : IResturantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlResturantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public void Add(Resturant resturant)
        {
            db.Resturants.Add(resturant);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var resturant = db.Resturants.Find(id);
            db.Resturants.Remove(resturant);
            db.SaveChanges();
        }

        public Resturant Get(int id)
        {
            return db.Resturants.FirstOrDefault(x => x.Id == id);   
        }

        public IEnumerable<Resturant> GetAll()
        {
            return from r in db.Resturants
                   orderby r.Name
                   select r;
        }

        public void Update(Resturant resturant)
        {
           var entry = db.Entry(resturant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
