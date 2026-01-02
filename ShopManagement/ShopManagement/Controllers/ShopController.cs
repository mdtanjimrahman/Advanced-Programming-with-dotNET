using ShopManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class ShopController : Controller
    {
        SuperShopEntities db = new SuperShopEntities();
        // GET: Shop
        public ActionResult Index(string search)
        {
            if (search != null)
            {
                var filter = (from pdata in db.Products
                              where pdata.Name.Contains(search)
                              select pdata).ToList();
                return View(filter);
            }
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
                return RedirectToAction("Index");
            }
            var cat = db.Categories.ToList();
            return View(cat);
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var data = db.Products.Find(Id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var data = db.Products.Find(Id);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = db.Products.Find(Id);
            ViewBag.Categories = db.Categories.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit (Product p)
        {
            var uObj = db.Products.Find(p.Id);
            uObj.Name = p.Name;
            uObj.Price = p.Price;
            uObj.Qty = p.Qty;
            uObj.CatId = p.CatId;
            db.SaveChanges();
            ViewBag.Categories = db.Categories.ToList();
            return RedirectToAction("Index");
        }


        //Department
        public ActionResult CatIndex()
        {
            var cat = db.Categories.ToList();
            return View(cat);
        }

        [HttpGet]
        public ActionResult CatDelete(int Id)
        {
            var cat = db.Categories.Find(Id);
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("CatIndex");
        }

        [HttpGet]
        public ActionResult CatCreate()
        {
            var cat = db.Categories.ToList();
            return View(cat);
        }

        [HttpPost]
        public ActionResult CatCreate(Category c)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(c);
                db.SaveChanges();
                return RedirectToAction("CatIndex");
            }
            var cat = db.Categories.ToList();
            return View(cat);
        }

        [HttpGet]
        public ActionResult CatUpdate(int Id)
        {
            var c = db.Categories.Find(Id);
            return View(c);
        }

        [HttpPost]
        public ActionResult CatUpdate(Category cat)
        {
            var catObj = db.Categories.Find(cat.Id);
            catObj.Name = cat.Name;
            db.SaveChanges();
            return RedirectToAction("CatIndex");
        }
    }
}