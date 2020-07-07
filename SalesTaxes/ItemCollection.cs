using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes
{
    class ItemCollection
    {
        List<SaleItem> itemTaxes;
        List<String> displayInput;
        List<string> UntaxableItems;

        public ItemCollection()
        {
            itemTaxes = new List<SaleItem>();
            displayInput = new List<string>();

            UntaxableItems = System.IO.File.ReadAllLines(@".\UntaxableItems.txt").ToList<string>();

        }

        public void AddItems(string ItemTitle, string Price)
        {
            if (ItemTitle.Length > 0 && Price.Length > 0)
            {
                int index = itemTaxes.FindIndex(y => y.title == ItemTitle);
                if (index >= 0)
                {
                    itemTaxes[index].count += 1;
                }
                else
                {
                    var isTaxable = UntaxableItems.FindIndex(y => ItemTitle.ToLower().Contains(y)) >= 0;
                    itemTaxes.Add(new SaleItem(ItemTitle, decimal.Parse(Price), isTaxable));
                }

                displayInput.Add("1 " + ItemTitle + " at " + Price);
            }
        }

        public string ShowItems()
        {
            string display = "\n\r";
            decimal total = 0M;
            decimal salesTax = 0M;

            foreach (SaleItem item in itemTaxes)
            {
                //originally separated tax and price, but later realized it the separated prices included the taxes
                // i.e.,  imported box of chocolates: 23.70 (2 @ 11.85) 
                //the 11.85 includes the $0.60 tax
                display += item.title + " : " + (item.fullPrice * item.count);  //item.price + item.tax;
                if(item.count>1)
                {
                    display += "(" + item.count + " @ " + item.fullPrice + ")"; // (item.price + item.tax);
                }
                total += item.fullPrice; // (item.price + item.tax);
                salesTax += item.tax;
                display += "\n\r";
            }

            display += "Sales Tax : " + salesTax + "\n\r";
            display += "Total : " + total + "\n\r";

            return display;
        }
    }
}
