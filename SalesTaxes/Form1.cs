using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            ItemCollection = new ItemCollection();
            groupBox1.Text += "\n\r";
            groupBox2.Text += "\n\r";
            

        }
        ItemCollection ItemCollection;
        private void button1_Click(object sender, EventArgs e)
        {
            ItemCollection.AddItems(textBox1.Text, textBox2.Text);

            groupBox2.Text += textBox1.Text + " at " + textBox2.Text;
            groupBox2.Text += "\n\r";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Text = ItemCollection.ShowItems();
            ItemCollection.itemTaxes.Clear();
        }
    }
}
