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
    public partial class FromBillingDetails : Form
    {
        private double sec = 2;//Thời gian delay tìm kiếm product
        private Bill bill;
        public FromBillingDetails()
        {
            InitializeComponent();
        }
        public FromBillingDetails(Bill bill)
        {
            InitializeComponent();
            this.bill = bill;
        }
        async void LoadContainerDetails(Bill bill)
        {
            dgvDetails.DataSource = await bill.billingDetails();
        }
        async void LoadContainerCategory()
        {
            string[] categorys = await Product.FindCategory();
            foreach (string category in categorys)
            {
                Button btn = new Button();
                btn.Width = 100;
                btn.Height = 100;
                btn.Text = category;
                btn.Click += async (object sender, EventArgs e) =>
                {
                    List<Product> productsWithCategory = await Product.findProductByCategory(category);
                    LoadContainerProduct(productsWithCategory);
                };
                flpContainerLeft.Controls.Add(btn);
            }
        }
        void LoadContainerProduct(List<Product> products)
        {
            flpContainerProduct.Controls.Clear();
            foreach (Product product in products)
            {
                Button btn = new Button();
                btn.Width = 100;
                btn.Height = 100;
                btn.Text = product.name;
                btn.Click += async (object sender, EventArgs e) =>
                {
                    List<Product> productsWithName = await Product.FindProductByName(product.name);
                    List<Product> productsWithCategory = products;
                    this.Hide();
                    FormProductDetails form = new FormProductDetails(productsWithName , productsWithCategory , bill);
                    form.ShowDialog();
                    this.Close();
                };
                flpContainerProduct.Controls.Add(btn);
            }
        }
        private void tbSeach_TextChanged(object sender, EventArgs e)
        {
            if (tbSeach.Text == "")
            {
                lbSeach.Visible = true;
            }
            else
            {
                lbSeach.Visible = false;
            }
            timer1.Stop();
            sec = 0.5;
            timer1.Start();
        }

        private void lbSeach_Click(object sender, EventArgs e)
        {
            lbSeach.Visible = false;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            sec -= 0.5;
            if (sec == 0)
            {
                List<Product> products = await Product.FindProductByWord(tbSeach.Text);
                LoadContainerProduct(products);
                timer1.Stop();
                sec = 2;
            }
        }

        private async void FromBillingDetails_Load(object sender, EventArgs e)
        {
            LoadContainerCategory();
            LoadContainerDetails(bill);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBill form = new FormBill();
            form.ShowDialog();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e) 
        {
            DialogResult dia = MessageBox.Show("Bạn có muốn hủy không", "Hủy ?", MessageBoxButtons.OKCancel);
            if (dia == DialogResult.OK)
            {
                bill.status = "canceled";
                bill.Update();
                this.Hide();
                FormBill form = new FormBill();
                form.ShowDialog();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Bạn có muốn thanh toán không", "thanh toán ?", MessageBoxButtons.OKCancel);
            if (dia == DialogResult.OK)
            {
                bill.status = "paid";
                bill.Update();
                this.Hide();
                FormBill form = new FormBill();
                form.ShowDialog();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBill form = new FormBill();
            form.ShowDialog();
            this.Close();
        }
    }
}
