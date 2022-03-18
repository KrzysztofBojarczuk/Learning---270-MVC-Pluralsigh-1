using OdeToFoodData.Models;
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
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resturant resturant)
        {
            //if (String.IsNullOrEmpty(resturant.Name))
           // {
           //     ModelState.AddModelError(nameof(resturant.Name), "The name is required");
           // }

            if (ModelState.IsValid)
            {
                db.Add(resturant);

                return RedirectToAction("Details", new {id = resturant.Id});
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Resturant resturant)
        {
            if (ModelState.IsValid)
            {
                db.Update(resturant);
                return RedirectToAction("Details", new { id = resturant.Id });
            }

            return View(resturant);
        }
    }
}