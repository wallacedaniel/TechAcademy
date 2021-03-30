using OrderManager.DTO;
using OrderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Persistence
{
    public class OrdersRepository
    {
        public static List<DTO.OrderTransfer> GetOrders()
        {
            // Retieve orders from the database.
            OrdersModel db = new OrdersModel();

            var dbOrders = db.Orders.OrderBy(p => p.Name).ToList();
            var dtoOrders = new List<DTO.OrderTransfer>();

            foreach (var dbOrder in dbOrders)
            {
                var dtoOrder = new DTO.OrderTransfer();
                dtoOrder.OrderId = dbOrder.OrderId;
                dtoOrder.Size = dbOrder.Size;
                dtoOrder.Crust = dbOrder.Crust;
                dtoOrder.Sausage = dbOrder.Sausage;
                dtoOrder.Pepperroni = dbOrder.Pepperroni;
                dtoOrder.Onions = dbOrder.Onions;
                dtoOrder.GrnPeppers = dbOrder.GrnPeppers;
                dtoOrder.TotalCost = dbOrder.TotalCost;
                dtoOrder.Name = dbOrder.Name;
                dtoOrder.Address = dbOrder.Address;
                dtoOrder.Zip = dbOrder.Zip;
                dtoOrder.Phone = dbOrder.Phone;
                dtoOrder.PayType = dbOrder.PayType;
                dtoOrder.Completed = dbOrder.Completed;
                dtoOrders.Add(dtoOrder);
            }

            return dtoOrders;
        }

        public static void AddOrder(DTO.OrderTransfer newOrder)
        {
            // Add orders to the database.
            OrdersModel db = new OrdersModel();

            var dbOrders = db.Orders;
            var order = new Order();

            // Validations...incomplete.
            if (newOrder.Name.Trim().Length == 0)
                throw new Exception("Name is a required field");
            if (newOrder.Address.Trim().Length == 0)
                throw new Exception("Address is a required field");
            if (newOrder.Zip.Trim().Length == 0)
                throw new Exception("Zip is a required field");
            if (newOrder.Phone.Trim().Length == 0)
                throw new Exception("Phone is a required field");

            order.OrderId = Guid.NewGuid();
            order.Size = newOrder.Size;
            order.Crust = newOrder.Crust;
            order.Sausage = newOrder.Sausage;
            order.Pepperroni = newOrder.Pepperroni;
            order.Onions = newOrder.Onions;
            order.GrnPeppers = newOrder.GrnPeppers;
            order.TotalCost = newOrder.TotalCost;
            order.Name = newOrder.Name;
            order.Address = newOrder.Address;
            order.Zip = newOrder.Zip;
            order.Phone = newOrder.Phone;
            order.PayType = newOrder.PayType;
            order.Completed = newOrder.Completed;

            try
            {
                dbOrders.Add(order);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                //Log 
                throw ex;
            }
        }

        // Marks order as completed thereby removing from view in the orders log.
        public static void CompleteOrder(Guid orderId)
        {
            var db = new OrdersModel();
            var order = db.Orders.FirstOrDefault(p => p.OrderId == orderId);
            order.Completed = true;
            db.SaveChanges();
        }
    }
}
