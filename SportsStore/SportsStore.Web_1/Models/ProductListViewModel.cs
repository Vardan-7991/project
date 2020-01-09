﻿using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Web_1.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products {  get;set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { set; get; }
    }
}