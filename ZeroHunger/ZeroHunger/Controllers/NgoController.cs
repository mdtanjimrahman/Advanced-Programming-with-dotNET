using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class NgoController : Controller
    {
        HungerDBEntities db = new HungerDBEntities();

        // GET: Ngo
        public ActionResult Index()
        {
            var food = db.FoodStates.ToList();
            return View(food);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var r = db.Restuarants.ToList();
            return View(r);
        }

        [HttpPost]
        public ActionResult Create(FoodState food)
        {
            if (ModelState.IsValid)
            {
                db.FoodStates.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var r = db.Restuarants.ToList();
            return View(r);
        }
    }
}