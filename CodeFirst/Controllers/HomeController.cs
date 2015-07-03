using EntityFramework.CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework.CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Student oStudent = new Student()
            {
                StudentName="Rahul"                
            };
            using (var ctx = new SchoolDB())
            {
                ctx.Students.Add(oStudent);
                ctx.SaveChanges();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}