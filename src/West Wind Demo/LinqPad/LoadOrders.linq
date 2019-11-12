<Query Kind="Program">
  <Connection>
    <ID>427b867e-be0d-4dfa-a844-3e8558a6934e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
    int supplier; // 1, 2, 7, 8, 16, 19
    
}
void Scratchpad()
{
    from ord in Orders
    where !ord.Shipped // Still items to be shipped
       && ord.OrderDate.HasValue // The order has been placed and is ready to ship
    select ord
}
// Define other methods and classes here
        public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            throw new NotImplementedException();
            // TODO: Implement this method
            /* Validation:
                    Make sure the supplier ID exists, otherwise throw exception
                    [Advanced:] Make sure the logged-in user works for the identified supplier.
               Query for outstanding orders, getting data from the following tables:
                    TODO: List table names
             */
        }

// ---------------
    public class OutstandingOrder
    {
        public int OrderId { get; set; }
        public string ShipToName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredBy { get; set; }
        public TimeSpan DaysRemaining { get; } // TODO: Calculated
        public IEnumerable<OrderProductInformation> OutstandingItems { get; set; }
        public string FullShippingAddress { get; set; }
        public string Comments { get; set; }
    }
    public class OrderProductInformation
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short Qty { get; set; }
        public string QtyPerUnit { get; set; }
        public short Outstanding { get; set; }
        // NOTE: Outstanding <= OrderDetails.Quantity - Sum(ManifestItems.ShipQuantity) for that product/order
    }