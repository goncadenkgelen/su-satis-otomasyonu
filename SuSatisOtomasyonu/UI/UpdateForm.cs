using System;
using System.Windows.Forms;
using SuSatisOtomasyonu.DAL;

namespace SuSatisOtomasyonu.UI
{
    public partial class UpdateForm : Form
    {
        private readonly Customer customer;
        private void Button1_Click(object sender, EventArgs e)
        {
            Customer updatedCustomer = new Customer
            {
                CustomerID = customer.CustomerID,
                firstName = textBox1.Text,
                lastName = textBox2.Text,
                phoneNumber = maskedTextBox1.Text,
                adress = textBox4.Text
            };

            bool updated = CustomerHepler.UpdateCustomer(Convert.ToInt32(customer.CustomerID), updatedCustomer);
            if (updated)
            {
                MessageBox.Show("Kayıt Guncellendi");
                this.Close();

            }
            else
            {
                MessageBox.Show("Kayıt Guncellenemedi!!!");
            }
        }

        public UpdateForm(Customer customer)
        {
            this.customer = customer;
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = customer.firstName;
            textBox2.Text = customer.lastName;
            maskedTextBox1.Text = customer.phoneNumber;
            textBox4.Text = customer.adress;
        }
    }
}
