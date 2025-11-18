using IntroShop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroShop.Controllers
{
    public class ShopController : Controller
    {
        ShopEntities db = new ShopEntities();

        // GET: Shop
        public ActionResult Index()
        {
            var p = db.Products.ToList();
            return View(p);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var cat = db.Categories.ToList();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid) 
            {
                db.Products.Add(p);
                db.SaveChanges();
                TempData["Msg"] = "Product Added";
                return RedirectToAction("Index");
            }
            var cat = db.Categories.ToList();
            return View(cat);
        }

        public ActionResult Details(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}