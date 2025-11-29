using NewFormValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewFormValidation.Controllers
{
    public class CustomFormController : Controller
    {
        // GET: CustomForm
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Validation());
        }
        [HttpPost]
        public ActionResult Index(Validation val)
        {
            if (ModelState.IsValid)
            {
                TempData["Msg"] = "Registration Successful";
                return RedirectToAction("Index");
            }
            return View(val);
        }
    }
}