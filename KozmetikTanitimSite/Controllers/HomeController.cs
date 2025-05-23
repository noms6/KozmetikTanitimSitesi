using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KozmetikTanitimSite.Models; 


namespace KozmetikTanitimSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Arama(string query)
        {
            if (string.IsNullOrEmpty(query))
                return View(new List<Product>());

            var results = _context.Products
                .Where(p => p.Name.Contains(query) || p.Description.Contains(query))
                .ToList();

            return View(results);
        }

        public ActionResult Index()
        {
            var featuredProducts = _context.Products.Where(p => p.IsFeatured).ToList();

            return View(featuredProducts);
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