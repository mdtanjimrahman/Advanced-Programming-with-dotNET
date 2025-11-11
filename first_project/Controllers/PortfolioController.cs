using first_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace first_project.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Education()
        {
            List<Education> edu = new List<Education>();
            var time = 2020;
            for (int i = 1; i <= 4; i++)
            {
                edu.Add(new Education()
                {
                    Degree = "Degree" + i,
                    Year = time,
                });
                time = time + 2;
            }
            return View(edu);
        }
        public ActionResult Projects()
        {
            List<Project> projects = new List<Project>();
            for (int i = 1; i<=10; i++)
            {
                projects.Add(new Project()
                {
                    Name = "Project"+i,
                    Language = "lang"+i,
                    Duration = i,
                });
            }
            return View(projects);
        }
        public ActionResult Reference()
        {
            var reference = new Reference
            {
                Name = new string[] {"Xiu Lang", "Mahmud"},
                Status = new string[] {"Associate Prof., UH", "Senior Head, UH"}
            };
            return View(reference);
        }
    }
}