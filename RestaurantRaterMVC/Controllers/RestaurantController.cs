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

        // GET: Restaurant/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _dB.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurant/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _dB.Restaurants.Find(id);
            _dB.Restaurants.Remove(restaurant);
            _dB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}