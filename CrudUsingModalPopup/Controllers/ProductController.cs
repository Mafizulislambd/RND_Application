using CrudUsingModalPopup.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingModalPopup.Controllers
{
    public class ProductController : Controller
    {
        IServiceRepository<Product> _repository;
        public ProductController( IServiceRepository<Product> repository)
        {
                _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
       // [NonAction]
        public JsonResult GetProducts()
        {
            return Json(_repository.GetProducts());
        }
        public JsonResult PostProducts(Product product)
        {
            if(ModelState.IsValid)
            {
                _repository.SaveData(product);
                return Json("Data Save Succesfully.....");
            }
            else
            {
                return Json("Model Validation failed...");
            }
        }
        public JsonResult Edit(int id)
        {
          var product=  _repository.GetProductById(id);
            return Json(product);
        }
        public JsonResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateData(product);
                return Json("Data Update Succesfully.....");
            }
            else
            {
                return Json("Model Validation failed...");
            }
        }
        
        public JsonResult Delete(int id)
        {
            var product = _repository.GetProductById(id);          
            if (product != null)
            {
                _repository.DeleteData(id);
                return Json("Product details deleted...");
            }
            else
            {
                return Json("Product details Not found...");
            }
        }
    }
}
