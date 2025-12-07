using IntroShop.DTOs;
using IntroShop.EF;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroShop.Controllers
{
    public class ShopController : Controller
    {
        ShopEntities db = new ShopEntities();

        public static Product Convert(ProductDTO p)
        {
            return new Product()
            {
                Name = p.Name,
                CId = p.CId,
                Price = p.Price,
                Qty = p.Qty
            };

        }

        public static ProductDTO Convert(Product p)
        {
            return new ProductDTO()
            {
                Name = p.Name,
                CId = p.CId,
                Price = p.Price,
                Qty = p.Qty
            };

        }

        public static List<ProductDTO> Convert(List<Product> list)
        {
            var data = new List<ProductDTO>();
            foreach (var item in list)
            {
                data.Add(Convert(item));
            }
            return data;
        }

        // GET: Shop
        public ActionResult Index()
        {
            var p = db.Products.ToList();
            return View(p);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Cats = db.Categories.ToList();
            return View(new ProductDTO());
        }

        [HttpPost]
        public ActionResult Create(ProductDTO p)
        {
            if (ModelState.IsValid) 
            {
                var pdata = Convert(p);
                db.Products.Add(pdata);
                db.SaveChanges();
                TempData["Msg"] = "Product Added";
                return RedirectToAction("Index");
            }
            ViewBag.Cats = db.Categories.ToList();
            return View(p);
        }

        public ActionResult Details(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(ProductDTO p)
        {
            var pObj = db.Products.Find(p.Id);
            db.Entry(pObj).CurrentValues.SetValues(p);
            db.SaveChanges();
            TempData["Msg"] = "Data Updated";
            return RedirectToAction("Update");
        }

        public ActionResult Delete(int Id)
        {
            var pObj = db.Products.Find(Id);
            db.Products.Remove(pObj);
            db.SaveChanges();
            TempData["DelMsg"] = pObj.Name+" Deleted";
            return RedirectToAction("Index");
        }
    }
}