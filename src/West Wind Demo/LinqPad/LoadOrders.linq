<Query Kind="Program">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	int supplier = 8; // 2, 7, 8, 16, 19
	var output = LoadOrders(supplier);
	output.Dump();
}

// Define other methods and classes here
        public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            //throw new NotImplementedException();
			var result = 
			from sale in Orders
			where !sale.Shipped
			   && sale.OrderDate.HasValue
			select new OutstandingOrder
			{
				OrderId = sale.OrderID,
				ShipToName = sale.ShipName,
				OrderDate = sale.OrderDate.Value,
				RequiredBy = sale.RequiredDate.Value,
				// OutstandingItems
				// FullShippingAddress
				Comments = sale.Comments
			};
			return result.ToList();
            // TODO: Implement this method wit the following
            /*      Validation:
                        Make sure the supplier ID exists, otherwise throw an exception
                        [Advanced:] Make sure the logged-in user works for the identified supplier.
                        Query for outstanding orders, getting data from the following tables:
                        TODO: List table names
             */
        }

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

    public class OrderItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short Qty { get; set; }
        public string QtyPerUnit { get; set; }
        public short Outstanding { get; set; } // TODO: Calculated as OD.Quantity - Sum(Shipped qty)
    }
