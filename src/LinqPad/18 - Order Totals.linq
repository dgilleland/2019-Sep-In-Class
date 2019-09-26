<Query Kind="Expression">
  <Connection>
    <ID>fa9a30b7-40b2-418b-964d-abb7204b83e0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// List all the orders showing the order ID, Company Name, Freight Charge,
// and Subtotal (no discounts) as well as the Subtotal of the discount.
from sale in Orders
select new
{
    OrderId = sale.OrderID,
    Company = sale.Customer.CompanyName,
    FreightCharge = sale.Freight,
    Subtotal = sale.OrderDetails.Sum(lineItem => lineItem.Quantity * lineItem.UnitPrice),
	//                             \OrderDetail/
    DiscountSubtotal = 
        sale.OrderDetails.Sum(lineItem =>
                              lineItem.Quantity * lineItem.UnitPrice * (decimal)lineItem.Discount)
}