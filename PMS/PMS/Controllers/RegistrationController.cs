using AutoMapper;
using PMS.DTOs;
using PMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        PMSEntities db = new PMSEntities();

        public static Mapper GetMapper()
        {
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<>();
            //});
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
            });
            return new Mapper(config);
        }


        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" ensures lowercase hex format
                }
                return sb.ToString();
            }
        }


        public static Customer Convert(CustomerDTO cDTO)
        {
            return new Customer()
            {
                Name = cDTO.Name,
                Email = cDTO.Email,
                Username = cDTO.Username,
                Password = cDTO.Password
            };
        }

        public static CustomerDTO Convert(Customer c)
        {
            return new CustomerDTO()
            {
                Name = c.Name,
                Email = c.Email,
                Username = c.Username,
                Password = c.Password
            };
        }

        public static List<CustomerDTO> Convert(List<Customer> list)
        {
            var data = new List<CustomerDTO>();
            foreach (var item in list)
            {
                data.Add(Convert(item));
            }
            return data;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View(new CustomerDTO());
        }


        [HttpPost]
        public ActionResult Index(CustomerDTO c)
        {
            if (ModelState.IsValid)
            {
                var customer = GetMapper().Map<Customer>(c);
                customer.Password = CreateMD5(customer.Password);
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(c);
        }

        

        public ActionResult DashBoard()
        {
            var cus = db.Customers.ToList();
            return View(cus);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var cusData = db.Customers.Find(Id);
            db.Customers.Remove(cusData);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}