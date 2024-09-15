using DropDownlistPartialView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DropDownlistPartialView.Controllers
{
    public class HomeController : Controller    {
        
        public ActionResult ManufacturerList()
        {
            var manufacturers = Manufacturer.GetManufacturers();
            bool isAjax = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return Json(new SelectList(manufacturers.ToArray(), "ManCode", "ManName"), 
                    System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult GetLaptops(string category)
        {
            var laptops = (from l in Laptop.GetProducts()
                           where l.Category == category
                           select l).AsEnumerable();
            return PartialView(laptops);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        ///////////-------------------
        
        public ActionResult CategoryList(string ID)
        {
            var categories = from c in Category.GetCategories()
                             where c.ManCode == ID
                             select c;
            bool isAjax = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {               
                return Json(new SelectList(categories.ToArray(),"CategoryID","CategoryName"),
                    System.Web.Mvc.JsonRequestBehavior.AllowGet);
            }
 
            return RedirectToAction("Index");
        }
        //////////////////
       
    }
}
