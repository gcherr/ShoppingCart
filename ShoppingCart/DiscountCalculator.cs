using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartLib
{
    public class DiscountCalculator : IPriceCalculator
    {
        private Inventory inventory;
        private Discounts discounts;

        public DiscountCalculator(Inventory inv, Discounts disc)
        {
            inventory = inv;
            discounts = disc;
        }

        public decimal Calculate(string items)
        {
            return 0;
        }

        public decimal Calculate(Dictionary<string, int> dict)
        {
            decimal total = 0; 
            foreach(KeyValuePair<string, int> kvp in dict)
            {
                decimal basePrice = inventory.GetProduct(kvp.Key).GetPrice();
                int currentQuantity = kvp.Value;

                if (discounts.HasDiscount(kvp.Key))
                {
                    decimal discountCost = discounts.GetProductDiscountPrice(kvp.Key);
                    int discountQuantity = discounts.GetProductDiscountQuantity(kvp.Key);

                    decimal discountGroupCost = (currentQuantity / discountQuantity) * discountCost;
                    decimal remainderCost = (currentQuantity % discountQuantity) * basePrice;

                    total += discountGroupCost + remainderCost;
                } else
                {
                    total += currentQuantity * basePrice;
                }
             
            }

            return total;
        }
    }
}
