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
        public float price;
        public float tax;
        public bool getsUSTax;
        public bool getsImportTax;

        public SaleItem(string t, float p)
        {
            title = t;
            price = p;
            tax = 0;
            getsUSTax = false;
            getsImportTax = false;
        }

        public float SalesTax()
        {
            return 0;
        }

    }
}
