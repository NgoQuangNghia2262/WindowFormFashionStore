using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FashionStore
{
    public partial class FormProductDetails : Form
    {
        private List<Product> productsWithName;
        private List<Product> productsWithCategory;
        private Product productSelected;
        private Bill bill;
        public FormProductDetails()
        {
            InitializeComponent();
        }
        public FormProductDetails(List<Product> productsWithName , List<Product> productsWithCategory,Bill bill)
        {
            InitializeComponent();
            this.productsWithName = productsWithName;
            this.productsWithCategory = productsWithCategory;
            this.bill = bill;
        }
        void LoadCbbSize(List<string> productSizes)
        {
            cbbSize.Items.Clear();
            foreach (string size in productSizes)
            {
                cbbSize.Items.Add(size);
            }
        }
        void LoadCbbColor(List<string> productColors)
        {
            
            cbbColor.Items.Clear();
            foreach (string color in productColors)
            {
                cbbColor.Items.Add(color);
            }
        }
        void LoadProductDetails(Product product)
        {
            lbName.Text = product.name;
            lbPrice.Text = product.price.ToString();
            lbInventory.Text = product.inventory.ToString();
            cbbColor.Text = product.color;
            cbbSize.Text = product.size;
            lbDes.Text = product.describe;
        }
        private void FormProductDetails_Load(object sender, EventArgs e)
        {
            List<string> productColors = new List<string>();
            List<string> productSizes = new List<string>();
            
            if(productsWithName == null) { return; }
            foreach (Product product in productsWithName)
            {
                for (int i = 0; i < productColors.Count; i++)
                {
                   if(product.color == productColors[i])
                    {
                        goto next;
                    }
                }
                productColors.Add(product.color);
            next:
                for (int i = 0; i < productSizes.Count; i++)
                {
                    if (product.size == productSizes[i])
                    {
                        goto next2;
                    }
                }
                productSizes.Add(product.size);
            next2:;
            }
            productSelected = productsWithName[0];
            LoadCbbColor(productColors);
            LoadCbbSize(productSizes);
            LoadProductDetails(productSelected);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FromBillingDetails form = new FromBillingDetails(bill);
            form.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbQuantity.Text = (int.Parse(tbQuantity.Text)+1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(tbQuantity.Text);
            if (quantity <= 1) { return; }
            tbQuantity.Text = (quantity - 1).ToString();

        }

        private void cbbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Product product in productsWithName)
            {
                if(product.size == cbbSize.Text && product.color == cbbColor.Text)
                {
                    productSelected = product;
                    LoadProductDetails(product);
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(productSelected == null) { return; }
            if(productSelected.inventory < int.Parse(tbQuantity.Text))
            {
                MessageBox.Show("Tồn kho không đủ");
                return;
            }
            BillingDetails details = new BillingDetails();
            details.idBill = bill.id;
            details.nameProduct = lbName.Text;
            details.colorProduct = cbbColor.Text;
            details.sizeProduct = cbbSize.Text;
            details.price = double.Parse(lbPrice.Text);
            details.quantity = int.Parse(tbQuantity.Text);
            details.Create();
            this.Hide();
            FromBillingDetails form = new FromBillingDetails(bill);
            form.ShowDialog();
            this.Close();
            
        }

        private void tbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            if(int.Parse(tbQuantity.Text) < 0)
            {
                tbQuantity.Text = "";
            }
            if(int.Parse(tbQuantity.Text) > int.Parse(lbInventory.Text))
            {
                MessageBox.Show("Tồn kho không đủ");
            }
        }
    }
}
