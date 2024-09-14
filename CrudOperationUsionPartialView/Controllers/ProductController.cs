using CrudOperationUsionPartialView.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationUsionPartialView.Controllers
{
    public class ProductController : Controller
    {
        IServiceRepository<Product> _repository;

        public ProductController(IServiceRepository<Product> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            List<Product> prodlist = new List<Product>();
            prodlist = _repository.GetProducts();
            return View(prodlist);
        }      
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
              if(product.Product_ID == 0)
                {
                    _repository.SaveData(product);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    _repository.UpdateData(product);
                    return RedirectToAction("Index", "Product");
                }
               
            }
            else
            {
                return Json("Model Validation failed...");
            }
        }
        public ActionResult Create(int id)
        {
            Product prod = new Product();
            prod =_repository.GetProductById(id);
            return PartialView("_EditParitial", prod);
        }
        public ActionResult Edit(int id)
        {
            Product prod = new Product();
            prod = _repository.GetProductById(id);
            return PartialView("_EditParitial", prod);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Product_ID == 0)
                {
                    _repository.SaveData(product);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    _repository.UpdateData(product);
                    return RedirectToAction("Index", "Product");
                }

            }
            else
            {
                return Json("Model Validation failed...");
            }
        }
        public ActionResult Delete (int id)
        {
            Product prod = new Product();
            prod = _repository.GetProductById(id);
            return PartialView("_DeletePartial", prod);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {            
            _repository.DeleteData(product.Product_ID);
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Details(int id)
        {
            Product prod = new Product();
            prod = _repository.GetProductById(id);
            return PartialView("_DeletePartial", prod);
        }
    }
}
