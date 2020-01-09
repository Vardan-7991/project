﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
namespace SportsStore.Web_1.Controllers
{
    public class NaviController : Controller
    {
        private IProductsRepository repository;

        public NaviController(IProductsRepository productsRepository)
        {
            repository = productsRepository;
        }
        // GET: Navi
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}