using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ShoppingBag
    {
        public ShoppingBag()
        {
            Items = new List<Item>();
        }
        public string Owner { get; set; }
        public string ShopName { get; set; }
        public List<Item> Items { get; set; }
    }
}
