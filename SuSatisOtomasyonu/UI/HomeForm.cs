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
                    dataGridView1.Rows[i].Cells[0].Value = customers[i].customerID;
                    dataGridView1.Rows[i].Cells[1].Value = customers[i].firstName;
                    dataGridView1.Rows[i].Cells[2].Value = customers[i].lastName;
                    dataGridView1.Rows[i].Cells[3].Value = customers[i].phoneNumber;
                    dataGridView1.Rows[i].Cells[4].Value = customers[i].adress;
                }
            }
        }

        private void FillOrderDataGrid(List<Orders> orderList)
        {
            List<OrderModel> orders = OrderHelper.MapOrderEntity(orderList);

            if (orders.Count > 0)
            {
                dataGridView2.Rows.Clear();

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
                    dataGridView2.Rows[i].Cells[0].Value = orders[i].orderID;
                    dataGridView2.Rows[i].Cells[1].Value = orders[i].Customer.firstName;
                    dataGridView2.Rows[i].Cells[2].Value = orders[i].Customer.lastName;
                    dataGridView2.Rows[i].Cells[3].Value = orders[i].Customer.phoneNumber;
                    dataGridView2.Rows[i].Cells[4].Value = orders[i].Customer.address;
                    dataGridView2.Rows[i].Cells[5].Value = orders[i].price;

                    switch (orders[i].status)
                    {
                        case "processing":
                            dataGridView2.Rows[i].Cells[6].Value = "Sipariş Alındı";
                            break;
                        case "transit":
                            dataGridView2.Rows[i].Cells[6].Value = "Yola Çıktı";
                            break;
                        case "delivered":
                            dataGridView2.Rows[i].Cells[6].Value = "Teslim Edildi";
                            break;

                        default:
                            dataGridView2.Rows[i].Cells[6].Value = orders[i].status;
                            break;
                    }
                }
            }
        }

        private void ListOrders()
        {
            List<Orders> orders = OrderHelper.GetOrders();

            FillOrderDataGrid(orders);
        }

        private void UpdateOrderStatus(string orderStatus)
        {
            int orderID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value.ToString());

            bool success = OrderHelper.UpdateOrderStatus(orderID, orderStatus);

            if (success)
            {
                ListOrders();
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
            var customer = new Customers
            {
                customerID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()),
                firstName = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString(),
                lastName = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString(),
                phoneNumber = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString(),
                address = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString()
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

            var customer = new Customers
            {
                customerID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()),
                firstName = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString(),
                lastName = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString(),
                phoneNumber = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString(),
                address = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString()
            };

            AddOrderForm addOrderForm = new AddOrderForm(customer);
            addOrderForm.Show();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            ListOrders();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            string orderTransit = OrderStatus.transit.ToString();

            UpdateOrderStatus(orderTransit);
        }


        private void Button10_Click(object sender, EventArgs e)
        {
            string orderDelivered = OrderStatus.delivered.ToString();

            UpdateOrderStatus(orderDelivered);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value.ToString());

            bool deleted = OrderHelper.DeleteOrder(orderId);

            if (deleted)
            {
                MessageBox.Show("Sipariş Silindi");
                ListOrders();
            }
            else
            {
                MessageBox.Show("Sipariş Silinemedi");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            FillOrderDataGrid(OrderHelper.GetTodaysOrders());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            bool deleted = OrderHelper.DeleteAllOrders();

            if (deleted)
            {
                ListOrders();
            }
        }
    }
}
