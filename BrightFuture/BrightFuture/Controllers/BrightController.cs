using BrightFuture.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrightFuture.Controllers
{
    public class BrightController : Controller
    {
        UniversityDBEntities db = new UniversityDBEntities();
        // GET: Bright
        public ActionResult Index(string search)
        {
            if (search != null)
            {
                var filter = (from sdata in db.Students
                              where sdata.Name.Contains(search)
                              select sdata).ToList();
                return View(filter);
            }
            var s = db.Students.ToList();
            return View(s);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var d = db.Departments.ToList();
            return View(d);
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var d = db.Departments.ToList();
            return View(d);
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var data = db.Students.Find(Id);
            return View(data);
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var data = db.Students.Find(Id);
            ViewBag.Departments = db.Departments.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var uObj = db.Students.Find(s.Id);
            uObj.Name = s.Name;
            uObj.Contact = s.Contact;
            uObj.DeptId = s.DeptId;
            db.SaveChanges();
            ViewBag.Departments = db.Departments.ToList();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var data = db.Students.Find(Id);
            db.Students.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Department Control
        public ActionResult DeptIndex()
        {
            var d = db.Departments.ToList();
            return View(d);
        }


        [HttpGet]
        public ActionResult DeptCreate()
        {
            var d = db.Departments.ToList();
            return View(d);
        }

        [HttpPost]
        public ActionResult DeptCreate(Department dept)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(dept);
                db.SaveChanges();
                return RedirectToAction("DeptIndex");
            }
            var d = db.Departments;
            return View(d);
        }

        [HttpGet]
        public ActionResult DeptEdit(int Id)
        {
            var d = db.Departments.Find(Id);
            return View(d);
        }

        [HttpPost]
        public ActionResult DeptEdit(Department dep)
        {
            var dObj = db.Departments.Find(dep.Id);
            dObj.Name = dep.Name;
            db.SaveChanges();
            return RedirectToAction("DeptIndex");
        }

        [HttpGet]
        public ActionResult DeptDelete(int Id)
        {
            var d = db.Departments.Find(Id);
            db.Departments.Remove(d);
            db.SaveChanges();
            return RedirectToAction("DeptIndex");
        }
    }
}