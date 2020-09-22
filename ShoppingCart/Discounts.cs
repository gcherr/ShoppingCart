using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartLib
{
    public struct DiscountInfo
    {
        public int Quantity { get; }
        public decimal Price { get; }
        public DiscountInfo(int qty, decimal pr)
        {
            Quantity = qty;
            Price = pr;
        }
        public override string ToString()
        {
            return $"{Quantity}: {Price}";
        }
    }

    public class Discounts
    {
        private Dictionary<string, DiscountInfo> discounts;

        public Discounts()
        {
            discounts = new Dictionary<string, DiscountInfo>();
        }

        public bool HasDiscount(string code) { return discounts.ContainsKey(code); }
        public void SetDiscount(string code, int qty, decimal price) {
            DiscountInfo newDiscount = new DiscountInfo(qty, price);
            if (!this.HasDiscount(code))
            {
                discounts.Add(code, newDiscount);
            } else
            {
                discounts[code] = newDiscount;
            }
        }
        public DiscountInfo? GetProductDiscount(string code) { return discounts[code]; }
        public int GetProductDiscountQuantity(string code) { return discounts[code].Quantity; }
        public decimal GetProductDiscountPrice(string code) { return discounts[code].Price; }

    }
}
