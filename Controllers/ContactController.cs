using Microsoft.AspNetCore.Mvc;
using PortfolioCoreDay.Context;
using PortfolioCoreDay.Entities;

namespace PortfolioCoreDay.Controllers
{
    public class ContactController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult Index()
        {
            var value = context.Contacts.Find(1);
            return View(value);
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
           
            var value = context.Contacts.Find(id);

            
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
           
            context.Contacts.Update(contact);

            
            context.SaveChanges();

           
            return RedirectToAction("Index");
        }
    }

}
