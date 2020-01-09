using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Web_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Web_1.Controllers
{
    public class CartController : Controller
    {
        private IProductsRepository repository;
        private IOrderProcerssor orderProcerssor;
        public CartController(IProductsRepository repo,IOrderProcerssor orderProcerssor)
        {
            repository = repo;
            this.orderProcerssor = orderProcerssor;
        }

        public object GetCart { get; private set; }

        // GET: Cart
        public RedirectToRouteResult AddToCart(Cart cart, int productId,string returnUrl )
        {
            Product product = repository.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
                
            }
            return RedirectToAction("Index", new { returnUrl });
           
        }
        public RedirectToRouteResult RemoveToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                cart.RemoveLine(product);

            }
            return RedirectToAction("Index", new { returnUrl });

        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            
            return View(new CartIndexViewModels { Cart=cart,ReturnUrl=returnUrl});
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShopinngDetalis());
        }
        [HttpPost]
        public ViewResult Checkout(Cart c,ShopinngDetalis shopinngDetalis)
        {
            if (c.Lines.Count() == 0)
                ModelState.AddModelError("", "Sorri,your cart is Empty!!");
            if (ModelState.IsValid)
            { orderProcerssor.ProcessOrder(c, shopinngDetalis);
                c.Clear();
                return View("Complated");
            }
            else
            {
                return View(shopinngDetalis);
            }
        }
    }
}