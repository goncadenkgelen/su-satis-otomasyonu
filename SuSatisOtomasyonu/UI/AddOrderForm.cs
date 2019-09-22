using SuSatisOtomasyonu.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuSatisOtomasyonu.UI
{
    public partial class AddOrderForm : Form
    {
        private readonly Customers customer;
        public AddOrderForm(Customers customer)
        {
            this.customer = customer;
            InitializeComponent();
        }

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = customer.firstName ;
            textBox2.Text = customer.lastName;
            maskedTextBox1.Text = customer.phoneNumber;
            textBox3.Text = customer.address;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Orders newOrder = new Orders
            {
                price = Convert.ToInt32(textBox4.Text),
                status = OrderStatus.processing.ToString(),
                customerID = this.customer.customerID,
            };

            bool success = OrderHelper.AddOrder(newOrder);
            if (success)
            {
                MessageBox.Show("Sipariş Kaydedildi");
                this.Close();

            }
            else
            {
                MessageBox.Show("Sipariş Kaydı Oluşturulamadı");
            }
        }
    }
}
