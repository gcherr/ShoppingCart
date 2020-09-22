using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartLib
{
    public class Product
    {
        private string code;
        private decimal price;

        public Product(string code, decimal price)
        {
            this.code = code;
            this.price = price;
        }

        public string GetCode() { return code; }
        public decimal GetPrice() { return price; }

        public void SetCode(string code)
        {
            if (code != string.Empty && code != null)
                this.code = code;
            else
                throw new ArgumentException("Code cannot be a null or an empty string", "code");
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Price cannot be null", "Price");
            else
                this.price = price;
        }

        public override int GetHashCode(){ return code.GetHashCode(); }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
            {
                Product p = (Product)obj;
                return this.code == p.code;
            }
        }
    }
}
