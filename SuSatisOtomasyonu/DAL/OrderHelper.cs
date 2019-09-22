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
        public static bool AddOrder(Orders order)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                order.createdAt = DateTime.Now;

                db.Orders.Add(order);
                db.SaveChanges();

                return true;
            }
        }

        public static List<Orders> GetOrders()
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                List<Orders> orders = db.Orders
                    .Include("Customers")
                    .OrderByDescending(o => o.createdAt)
                    .ToList();

                return orders;
            }
        }

        public static List<Orders> GetTodaysOrders()
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                DateTime today = DateTime.Now;

                List<Orders> orders = db.Orders
                    .Include("Customers")
                    .OrderByDescending(o => o.createdAt)
                    .Where(o => (
                        o.createdAt.Year == today.Year &&
                        o.createdAt.Month == today.Month &&
                        o.createdAt.Day == today.Day
                    ))
                    .ToList();

                return orders;
            }
        }

        public static bool UpdateOrderStatus(int orderId, string orderStatus)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                Orders order = db.Orders.Where(o => o.orderID == orderId).FirstOrDefault();

                order.status = orderStatus;
                order.createdAt = DateTime.Now;

                db.SaveChanges();

                return true;
            }
        }

        public static bool DeleteOrder(int orderId)
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                Orders order = db.Orders
                    .Where(s => s.orderID == orderId)
                    .FirstOrDefault();

                db.Orders.Remove(order);
                db.SaveChanges();

                return true;
            }
        }

        public static bool DeleteAllOrders()
        {
            using (SuSatisEntities db = new SuSatisEntities())
            {
                List<Orders> orders = GetOrders();

                db.Orders.RemoveRange(db.Orders);

                db.SaveChanges();

                return true;
            }
        }

        public static List<OrderModel> MapOrderEntity(List<Orders> orders)
        {
            List<OrderModel> ordersModel = new List<OrderModel>();

            foreach (var order in orders)
            {
                OrderModel orderModel = new OrderModel
                {
                    orderID = order.orderID,
                    customerID = order.customerID,
                    status = order.status,
                    price = order.price,
                    Customer = order.Customers,
                };

                ordersModel.Add(orderModel);
            }

            return ordersModel;
        }
    }

    public enum OrderStatus
    {
        processing,
        transit,
        delivered
    };
}
