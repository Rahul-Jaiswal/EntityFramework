using EntityFramework.CodeFirst.Common.Filters;
using EntityFramework.CodeFirst.Models;
using EntityFramework.CodeFirst.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework.CodeFirst.Controllers
{
    [EFHandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                Student oStudent = new Student()
                {
                    StudentName = "Rahul"
                };
                using (var ctx = new SchoolDB())
                {
                    ctx.Students.Add(oStudent);
                    ctx.SaveChanges();
                }
                return View();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ActionResult About()
        {
            try
            {
                throw new NullReferenceException();
                ViewBag.Message = "Your application description page.";

                return View();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}