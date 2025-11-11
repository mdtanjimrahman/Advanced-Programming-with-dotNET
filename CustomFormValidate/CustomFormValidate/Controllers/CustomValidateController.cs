using CustomFormValidate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomFormValidate.Controllers
{
    public class CustomValidateController : Controller
    {
        // GET: CustomValidate
        [HttpGet]
        public ActionResult Index()
        {
            return View(new RegexValidation());
        }

        [HttpPost]
        public ActionResult Index(RegexValidation rv)
        {
            if (ModelState.IsValid)
            {
                TempData["Msg"] = "Registration Successfull";
                return RedirectToAction("Index");
            }
            return View(rv);
        }
    }
}