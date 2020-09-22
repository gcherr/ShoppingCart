using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartLib
{
    public interface ITerminal
    {
        void Scan(string item);
        decimal Total();
    }

    public interface IPriceCalculator
    {
        decimal Calculate(Dictionary<string, int> items);
    }
}
