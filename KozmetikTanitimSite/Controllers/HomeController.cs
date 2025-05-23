using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KozmetikTanitimSite.Models;

namespace KozmetikTanitimSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var featuredProducts = _context.Products.ToList();
            return View(featuredProducts);
        }
        [AllowAnonymous]
        public ActionResult Arama(string query)
        {
            var results = _context.Products.Where(p => p.Name.Contains(query) || p.Description.Contains(query)).ToList();

            return View("Arama", results);
        }


        [AllowAnonymous]
        public ActionResult Detail(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
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
