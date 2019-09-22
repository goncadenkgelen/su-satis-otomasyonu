using SuSatisOtomasyonu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuSatisOtomasyonu.DAL
{
    class CustomerHepler
    {
        public static bool AddCustomer(Customer customer)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                db.Customer.Add(customer);
                db.SaveChanges();

                return true;
            }
        }

        public static List<Customer> GetCustomers(string searchQuery)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                return db.Customer
                    .Where(c => c.firstName.Contains(searchQuery))
                    .ToList();
            }
        }

        public static bool UpdateCustomer(int customerID, Customer updatedCustomer)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                Customer customer = db.Customer
                    .Where(c => c.CustomerID == customerID)
                    .FirstOrDefault();

                db.Customer.Remove(customer);
                db.Customer.Add(updatedCustomer);
                db.SaveChanges();

                return true;
            }
        }

        public static bool DeleteCustomer(int customerID)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                Customer customer = db.Customer
                    .Where(s => s.CustomerID == customerID)
                    .FirstOrDefault();
                db.Customer.Remove(customer);
                db.SaveChanges();

                return true;
            }
        }

        public static List<CustomerModel> MapCustomerEntity(List<Customer> customers)
        {
            List<CustomerModel> customersModels = new List<CustomerModel>();

            foreach (var customer in customers)
            {
                CustomerModel customerModel = new CustomerModel
                {
                    CustomerID = customer.CustomerID,
                    firstName = customer.firstName,
                    lastName = customer.lastName,
                    phoneNumber = customer.phoneNumber,
                    adress = customer.adress
                };

                customersModels.Add(customerModel);
            }

            return customersModels;
        }
    }
}
