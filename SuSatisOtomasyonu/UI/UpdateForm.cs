using System;
using System.Windows.Forms;
using SuSatisOtomasyonu.DAL;

namespace SuSatisOtomasyonu.UI
{
    public partial class UpdateForm : Form
    {
        private readonly Customers customer;
        private void Button1_Click(object sender, EventArgs e)
        {
            Customers updatedCustomer = new Customers
            {
                customerID = customer.customerID,
                firstName = textBox1.Text,
                lastName = textBox2.Text,
                phoneNumber = maskedTextBox1.Text,
                address = textBox4.Text
            };

            bool updated = CustomerHepler.UpdateCustomer(Convert.ToInt32(customer.customerID), updatedCustomer);
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

        public UpdateForm(Customers customer)
        {
            this.customer = customer;
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = customer.firstName;
            textBox2.Text = customer.lastName;
            maskedTextBox1.Text = customer.phoneNumber;
            textBox4.Text = customer.address;
        }
    }
}
