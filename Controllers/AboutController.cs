using Microsoft.AspNetCore.Mvc;
using PortfolioCoreDay.Context;
using PortfolioCoreDay.Entities;
using System.Linq;

namespace PortfolioCoreDay.Controllers
{
    public class AboutController : Controller
    {
        PortfolioContext context = new PortfolioContext();

        [HttpGet]
        public IActionResult Index()
        {
           
            var value = context.Abouts.FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            context.Abouts.Update(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}