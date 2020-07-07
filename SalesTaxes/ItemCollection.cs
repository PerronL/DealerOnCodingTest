using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes
{
    class ItemCollection
    {
        public List<SaleItem> itemTaxes;
        public List<String> displayInput;
        public List<string> UntaxableItems;

        public ItemCollection()
        {
            itemTaxes = new List<SaleItem>();
            displayInput = new List<string>();

            //there is a text file with a list of "untaxable items" in the Debug folder
            //other items that shouldn't be charged the 10% tax can be added there
            UntaxableItems = System.IO.File.ReadAllLines(@".\UntaxableItems.txt").ToList<string>();

        }

        //turns the given title and price into an object and holds it in a list
        //this object calculates it tax and full price to display later
        //this class also holds a list of strings to show items input by the user before the full price and tax is calculated
        public void AddItems(string ItemTitle, string Price)
        {
            
            if (ItemTitle.Length > 0 && Price.Length > 0)//do not add an item if there is not both an item and a price
            {
                //if the item already exists, only increase the count,
                //otherwise, add a new item with the given title and price
                int index = itemTaxes.FindIndex(y => y.title == ItemTitle); 
                if (index >= 0)
                {
                    itemTaxes[index].count += 1;
                }
                else
                {
                    var isTaxable = UntaxableItems.FindIndex(y => ItemTitle.ToLower().Contains(y)) < 0;
                    itemTaxes.Add(new SaleItem(ItemTitle, decimal.Parse(Price), isTaxable));
                }
                
                displayInput.Add("1 " + ItemTitle + " at " + Price);
            }
        }

        public string ShowItems()
        {
            string display = "\n\r\n\r";
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
                display += "\n\r\n\r";
            }

            display += "Sales Tax : " + salesTax + "\n\r\n\r";
            display += "Total : " + total + "\n\r\n\r";

            return display;
        }
    }
}
