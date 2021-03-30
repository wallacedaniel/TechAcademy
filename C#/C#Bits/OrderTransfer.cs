using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DTO
{
    public class OrderTransfer
    {
        public System.Guid OrderId { get; set; }
        public OrderManager.DTO.Enums.SizeType Size { get; set; }
        public OrderManager.DTO.Enums.CrustType Crust { get; set; }
        public bool Sausage { get; set; }
        public bool Pepperroni { get; set; }
        public bool Onions { get; set; }
        public bool GrnPeppers { get; set; }
        public decimal TotalCost { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public OrderManager.DTO.Enums.PaymentType PayType { get; set; }
        public bool Completed { get; set; }
    }
}
