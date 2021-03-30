using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Domain
{
    public class OrdersManager
    {
        // Calls to repository to retrieve orders from the database.
        public static List<DTO.OrderTransfer> GetOrders()
        {
            var orders = Persistence.OrdersRepository.GetOrders();
            return orders;
        }

        // Calls to repository to add orders to the database.
         public static void AddOrder(DTO.OrderTransfer order)
        {
            try
            {
                Persistence.OrdersRepository.AddOrder(order);
            }
            catch (Exception ex)
            {
                // Log 
                throw ex;
            }
        }

        // Calls to repository to mark order as completed thereby removing from view in the orders log.
        public static void CompleteOrder(Guid orderId)
        {
            Persistence.OrdersRepository.CompleteOrder(orderId);
        }
    }
}
