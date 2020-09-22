using System;
using System.Collections.Generic;

namespace ShoppingCartLib
{
    public class ShoppingCart : ITerminal
    {
        private Dictionary<string, int> cart;
        private decimal totalPrice;
        private IPriceCalculator calc;

        public ShoppingCart(IPriceCalculator c)
        {
            cart = new Dictionary<string, int>();
            totalPrice = 0;
            calc = c;
        }

        public void ScanItem(string element)
        {
            if (cart.ContainsKey(element))
                cart[element]++;
            else
                cart[element] = 1;
        }

        public void Scan(string item)
        {
            foreach (char c in item)
            {
                ScanItem(c.ToString());
            }
        }

        public decimal Total() {
            totalPrice = calc.Calculate(cart);
            return totalPrice;
        }

    }
}
