using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
namespace SportsStore.Web_1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        IProductsRepository repository;
        // GET: Admin
        public AdminController(IProductsRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index()
        {
            return View(repository.Products);
        }
        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(x => x.ProductId == productId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image!=null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.Save(product);
                TempData["message"] = string.Format("{0}has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product delprd = repository.DeleteProduct(productId);
            if (delprd!=null)
            {
                TempData["messege"] = string.Format("{0} has been deleted", delprd.Name);
            }
            return RedirectToAction("Index");
        }
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
    }
}