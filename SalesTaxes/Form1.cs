using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesTaxes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            itemTaxes = new List<SaleItem>();

        }
        List<SaleItem> itemTaxes;
        Dictionary<SaleItem, float> KVPitemTaxes;
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0 && textBox2.Text.Length >0)
            {
                itemTaxes.Add(new SaleItem(textBox1.Text, float.Parse(textBox2.Text)));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var total = 0.0;
            var salesTax = 0.0;
            foreach(SaleItem item in itemTaxes)
            {
                groupBox1.Text += item.title + " : " + item.price + item.tax;
                total += (item.price + item.tax);
                salesTax += item.tax;
                groupBox1.Text += "\n\r";
            }

            groupBox1.Text += "Sales Tax : " + salesTax + "\n\r";
            groupBox1.Text += "Total : " + total + "\n\r";

        }
    }
}
