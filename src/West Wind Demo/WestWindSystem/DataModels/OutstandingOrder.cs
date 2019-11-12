using System;
using System.Collections.Generic;

namespace WestWindSystem.DataModels
{
    public class OutstandingOrder
    {
        public int OrderId { get; set; }
        public string ShipToName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredBy { get; set; }
        public int DaysRemaining { get; } // TODO: Calculated
        public IEnumerable<OrderItem> OutstandingItems { get; set; }
        public string FullShippingAddress { get; set; }
        public string Comments { get; set; }
    }
}
