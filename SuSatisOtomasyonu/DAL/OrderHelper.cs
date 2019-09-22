using SuSatisOtomasyonu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuSatisOtomasyonu.DAL
{
    class OrderHelper
    {
        public static List<Ordering> GetOrders()
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                List<Ordering> orders = db.Ordering.Include("Customer").ToList();

                return orders;
            }
        }

        public static List<OrderModel> MapOrderEntity(List<Ordering> orders)
        {
            List<OrderModel> ordersModel = new List<OrderModel>();

            foreach (var order in orders)
            {
                OrderModel orderModel = new OrderModel
                {
                    orderID = order.orderID,
                    CustomerID = order.CustomerID,
                    status = order.status,
                    price = order.price,
                    Customer = order.Customer,
                };

                ordersModel.Add(orderModel);
            }

            return ordersModel;
        }
    }
}
