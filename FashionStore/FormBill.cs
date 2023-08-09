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
    public partial class FormBill : Form
    {
        private List<Bill> bills;
        public FormBill()
        {
            InitializeComponent();
        }
        Button createButtonBill(Bill item)
        {
            Button btn = new Button();
            btn.Text = item.id;
            btn.Width = flpContainerBill.Width / 4 - 12;
            btn.Height = Convert.ToInt32(btn.Width * 0.625);
            btn.Click += (object sender, EventArgs e) =>
            {
                this.Hide();
                FromBillingDetails form = new FromBillingDetails(item);
                form.ShowDialog();
                this.Close();

            };
            return btn;
        }
        void LoadContainerBill(List<Bill> bills) 
        {
            foreach (Bill item in bills)
            {
                Button btn = createButtonBill(item);
                flpContainerBill.Controls.Add(btn);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.Create();
            bills.Add(bill);
            this.Hide();
            FromBillingDetails form = new FromBillingDetails(bill);
            form.ShowDialog();
            this.Close();
        }

        private async void FormBill_Load(object sender, EventArgs e)
        {
            List<Bill> unpaid = await Bill.FindAllBillByStatus("unpaid");
            List<Bill> delivering = await Bill.FindAllBillByStatus("delivering");
            foreach (Bill item in unpaid)
            {
                delivering.Add(item);
            }
            List<Bill> bills = delivering;
            this.bills = bills;
            LoadContainerBill(bills);
        }
    }
}
