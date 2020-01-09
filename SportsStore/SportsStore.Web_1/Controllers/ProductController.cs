using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Web_1.Infrastructure;
using SportsStore.Web_1.Models;

namespace SportsStore.Web_1.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int pageSize = 4;
        public ProductController(IProductsRepository productrepository)
        {
            repository = productrepository;
        }
        // GET: Product
        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products.
                Where(p => category == null || p.Category == category).
                OrderBy(p => p.ProductId).
                Skip((page - 1) * pageSize).
                Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? 
                    repository.Products.Count():
                   repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}