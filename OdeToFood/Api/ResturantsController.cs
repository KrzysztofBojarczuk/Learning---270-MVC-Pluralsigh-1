using OdeToFoodData.Models;
using OdeToFoodData.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Api
{
    public class ResturantsController : Controller
    {
        IResturantData db;

        public ResturantsController(IResturantData db)
        {
            this.db = db;
        }

        // GET: Resturants
        public IEnumerable<Resturant> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}