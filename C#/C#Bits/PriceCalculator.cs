using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Domain
{
    // Calculates the total cost of the order.

    public class PriceCalculator
    {
        public static decimal CalculateOrder(DTO.OrderTransfer newOrder)
        {
            if (newOrder.Size == DTO.Enums.SizeType.Small) newOrder.TotalCost += 12M;
            if (newOrder.Size == DTO.Enums.SizeType.Medium) newOrder.TotalCost += 14M;
            if (newOrder.Size == DTO.Enums.SizeType.Large) newOrder.TotalCost += 16M;
            if (newOrder.Crust == DTO.Enums.CrustType.Thick) newOrder.TotalCost += 2M;
            if (newOrder.Sausage) newOrder.TotalCost += 2M;
            if (newOrder.Pepperroni) newOrder.TotalCost += 1.5M;
            if (newOrder.Onions) newOrder.TotalCost += .5M;
            if (newOrder.GrnPeppers) newOrder.TotalCost += .5M;
            return newOrder.TotalCost;
        }
    }
}
