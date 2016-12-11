using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_Test.Client
{
    public class CalculatePrice
    {
        public decimal GetSubtotal(decimal Price, int Quantity, bool Discounted)
        {
            decimal subtotal = Price * Quantity;

            if(Discounted)
            {
                subtotal = subtotal - (subtotal * 0.1m);
            }

            return subtotal;
        }

        public decimal GetTotal(decimal Subtotal, decimal Tax)
        {
            decimal total = Subtotal + (Subtotal * Tax);

            return total;
        }
    }
}