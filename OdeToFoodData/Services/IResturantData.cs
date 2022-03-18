using OdeToFoodData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFoodData.Service
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetAll(); 
        Resturant Get(int id);
        void Add(Resturant resturant);
        void Update(Resturant resturant);
    }
    public class InMemoryResturantData : IResturantData
    {
        List<Resturant> restaurants;

        public InMemoryResturantData()
        {
            restaurants = new List<Resturant>()
            {
                new Resturant { Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Indian},
                new Resturant { Id = 2,  Name = "Tersiquels",Cuisine = CuisineType.French},
                new Resturant { Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Italian}
            };
        }

        public void Add(Resturant resturant)
        {
            restaurants.Add(resturant);
            resturant.Id = restaurants.Max(r => r.Id) +1;
            
        }

        public Resturant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id); 
        }

        public IEnumerable<Resturant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Update(Resturant resturant)
        {
            var existing = Get(resturant.Id);
            if (existing != null)
            {
                existing.Name = resturant.Name;
                existing.Cuisine = resturant.Cuisine;
            }
        }
    }
}
