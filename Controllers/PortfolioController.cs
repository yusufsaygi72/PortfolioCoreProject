using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioCoreDay.Context;
using PortfolioCoreDay.Entities;

namespace PortfolioCoreDay.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioContext context=new PortfolioContext();
        public IActionResult ProjectList()
        {
            var values = context.Portfolios.Include(x=>x.Category).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            var values=new SelectList (context.Categories.ToList(),"CategoryId","CategoryName");
            ViewBag.v=values;
            return View();
        }
        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            context.Portfolios.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction("ProjectList");
        }
        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            
            var categories = new SelectList(context.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.v = categories;

          
            var value = context.Portfolios.Find(id);
            return View(value); 
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            
            context.Portfolios.Update(portfolio);
            context.SaveChanges();
            return RedirectToAction("ProjectList");
        }
        public IActionResult DeleteProject(int id)
        {
            var value = context.Portfolios.Find(id);  
            context.Portfolios.Remove(value);        
            context.SaveChanges();                   
            return RedirectToAction("ProjectList");  
        }
      
        public IActionResult PortfolioCards()
        {
            var values = context.Portfolios.Include(x => x.Category).ToList();

            
            return View(values);
        }
    }
}
