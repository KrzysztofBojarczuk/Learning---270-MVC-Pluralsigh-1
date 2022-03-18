using OdeToFoodData.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IResturantData db;

        public RestaurantsController(IResturantData db)
        {
            this.db = db;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
    }
}