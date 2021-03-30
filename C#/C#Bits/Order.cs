using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrders.DTO
{
    public class Order
    {
        public System.Guid OrderId { get; set; }
        public PizzaOrders.DTO.Enums.SizeType Size { get; set; }
        public PizzaOrders.DTO.Enums.CrustType Crust { get; set; }
        public bool Sausage { get; set; }
        public bool Pepperroni { get; set; }
        public bool Onions { get; set; }
        public bool GrnPeppers { get; set; }
        public decimal TotalCost { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public PizzaOrders.DTO.Enums.PaymentType PayType { get; set; }
        public bool Completed { get; set; }
    }
}
