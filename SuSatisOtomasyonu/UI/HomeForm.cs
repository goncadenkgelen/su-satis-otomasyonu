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
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            ListUsers();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void ListUsers()
        {
            dataGridView1.DataSource = CustomerHepler.ListCustomer(textBox1.Text);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            bool success = CustomerHepler.DeleteCustomer(Convert.ToInt32(id));

            if (success)
            {
                ListUsers();
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                CustomerID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["customerId"].Value.ToString()),
                firstName = dataGridView1.CurrentRow.Cells["firstName"].Value.ToString(),
                lastName = dataGridView1.CurrentRow.Cells["lastName"].Value.ToString(),
                phoneNumber = dataGridView1.CurrentRow.Cells["phoneNumber"].Value.ToString(),
                adress = dataGridView1.CurrentRow.Cells["adress"].Value.ToString()
            };
            UpdateForm updateForm = new UpdateForm(customer);
            updateForm.Show();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            ListUsers();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            ListUsers();
        }
    }
}
