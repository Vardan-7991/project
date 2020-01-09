using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Web_1.Models
{
    public class CartIndexViewModels
    {
        public Cart Cart { set; get; }
        public string ReturnUrl { set; get; }
        
    }

}