using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes
{
    class SaleItem
    {
        public string title;
        public decimal fullPrice;
        public decimal tax;
        public int count;
        public bool taxable;

        public SaleItem(string t, decimal p, bool taxable)
        {
            title = t;
            tax = SalesTax(Math.Round(p, 2));
            fullPrice = p + tax;
            count = 1;

        }

        public decimal SalesTax(decimal price)
        {
            decimal x = 0;


            if(title.ToLower().Contains("import"))
            {
                x = price / 20;
                
            }

            if (taxable)
            {
                x = price / 10;
            }

            roundTo5Cents(x);

            return x;
        }

        public decimal roundTo5Cents(decimal x)
        {
            x = Math.Round(x, 2);
            while( x % 5 !=0 )
            {
                x += 1;
            }
            return (decimal)x;
        }

    }
}
