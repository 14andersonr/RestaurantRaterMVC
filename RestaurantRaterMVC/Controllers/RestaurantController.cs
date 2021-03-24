using RestaurantRaterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _dB = new RestaurantDbContext();

        // GET: Restaurant/Index
        public ActionResult Index()
        {
            return View(_dB.Restaurants.ToList());
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View(_dB.Restaurants.ToList());
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _dB.Restaurants.Add(restaurant);
                _dB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }
    }
}