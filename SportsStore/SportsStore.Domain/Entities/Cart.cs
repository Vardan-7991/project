using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
  public  class Cart
    {
    private    List<CartLine> linecollection = new List<CartLine>();
        public void AddItem(Product product,int quantity)
        {
            CartLine line = linecollection
                .Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();
            if (line == null)
            {
                linecollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Product product)
        {
            linecollection.RemoveAll(x => x.Product.ProductId == product.ProductId);
        }
        public decimal ComputeTotalValue()
        {
           return linecollection.Sum(x => x.Product.Price*x.Quantity);
        }
        public void Clear()
        {
            linecollection.Clear();
        }
        public IEnumerable<CartLine> Lines => linecollection;
    }

    public class CartLine
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }
    }
}
