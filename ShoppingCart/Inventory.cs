using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartLib
{
    public class Inventory
    {
        
        private Dictionary<string, Product> inventory;

        public Inventory() { inventory = new Dictionary<string, Product>(); }

        public void AddProduct(string code, Product p) { inventory.Add(code, p); }
        public bool HasProduct(string code) { return inventory.ContainsKey(code); }
        public Product GetProduct(string code) { return inventory[code]; }
        
    }
}
