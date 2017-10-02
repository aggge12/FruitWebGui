using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebGui.Models
{
    public class CartableItem
    {
        public int id { get; set; }
        public int amount { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        
        public CartableItem()
        {

        }

        public CartableItem(int id, int amount, string name, int price)
        {
            this.id = id;
            this.amount = amount;
            this.name = name;
            this.price = price;
        }
    }
}