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
        public static bool AddCustomer(Customers customer)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                customer.createdAt = DateTime.Now;
                db.Customers.Add(customer);
                db.SaveChanges();

                return true;
            }
        }

        public static List<Customers> GetCustomers(string searchQuery)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                return db.Customers
                    .Where(c => c.firstName.Contains(searchQuery))
                    .OrderByDescending(c => c.createdAt)
                    .ToList();
            }
        }

        public static bool UpdateCustomer(int customerID, Customers updatedCustomer)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                Customers customer = db.Customers
                    .Where(c => c.customerID == customerID)
                    .FirstOrDefault();

                db.Customers.Remove(customer);

                updatedCustomer.createdAt = DateTime.Now;
                db.Customers.Add(updatedCustomer);
                db.SaveChanges();

                return true;
            }
        }

        public static bool DeleteCustomer(int customerID)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                Customers customer = db.Customers
                    .Where(s => s.customerID == customerID)
                    .FirstOrDefault();
                db.Customers.Remove(customer);
                db.SaveChanges();

                return true;
            }
        }

        public static List<CustomerModel> MapCustomerEntity(List<Customers> customers)
        {
            List<CustomerModel> customersModels = new List<CustomerModel>();

            foreach (var customer in customers)
            {
                CustomerModel customerModel = new CustomerModel
                {
                    customerID = customer.customerID,
                    firstName = customer.firstName,
                    lastName = customer.lastName,
                    phoneNumber = customer.phoneNumber,
                    adress = customer.address
                };

                customersModels.Add(customerModel);
            }

            return customersModels;
        }
    }
}
