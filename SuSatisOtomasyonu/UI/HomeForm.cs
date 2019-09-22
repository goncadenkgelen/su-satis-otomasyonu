using SuSatisOtomasyonu.DAL;
using SuSatisOtomasyonu.Model;
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
            ListCustomers();
            ListOrders();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void ListCustomers()
        {
            List<CustomerModel> customers = CustomerHepler
                .MapCustomerEntity(CustomerHepler.GetCustomers(textBox1.Text));

            if (customers.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.ColumnCount = 5;

                dataGridView1.Columns[0].Name = "ID";
                dataGridView1.Columns[1].Name = "Ad";
                dataGridView1.Columns[2].Name = "Soyad";
                dataGridView1.Columns[3].Name = "Telefon";
                dataGridView1.Columns[4].Name = "Adres";


                for (int i = 0; i < customers.Count; i++)
                {
                    i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = customers[i].CustomerID;
                    dataGridView1.Rows[i].Cells[1].Value = customers[i].firstName;
                    dataGridView1.Rows[i].Cells[2].Value = customers[i].lastName;
                    dataGridView1.Rows[i].Cells[3].Value = customers[i].phoneNumber;
                    dataGridView1.Rows[i].Cells[3].Value = customers[i].adress;
                }
            }
        }

        private void ListOrders()
        {
            List<OrderModel> orders = OrderHelper.MapOrderEntity(OrderHelper.GetOrders());

            if (orders.Count > 0)
            {
                dataGridView2.ColumnCount = 7;
                dataGridView2.Columns[0].Name = "ID";
                dataGridView2.Columns[1].Name = "Ad";
                dataGridView2.Columns[2].Name = "Soyad";
                dataGridView2.Columns[3].Name = "Telefon";
                dataGridView2.Columns[4].Name = "Adres";
                dataGridView2.Columns[5].Name = "Tutar";
                dataGridView2.Columns[6].Name = "Durum";

                for (int i = 0; i < orders.Count; i++)
                {
                    i = dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = orders[i].Customer.firstName;
                    dataGridView2.Rows[i].Cells[1].Value = orders[i].Customer.lastName;
                    dataGridView2.Rows[i].Cells[2].Value = orders[i].Customer.phoneNumber;
                    dataGridView2.Rows[i].Cells[3].Value = orders[i].Customer.adress;
                    dataGridView2.Rows[i].Cells[4].Value = orders[i].price;
                    dataGridView2.Rows[i].Cells[5].Value = orders[i].status;
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            bool success = CustomerHepler.DeleteCustomer(Convert.ToInt32(id));

            if (success)
            {
                ListCustomers();
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
            ListCustomers();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            ListCustomers();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            AddOrderForm addOrderForm = new AddOrderForm();
            addOrderForm.Show();
        }
    }
}
