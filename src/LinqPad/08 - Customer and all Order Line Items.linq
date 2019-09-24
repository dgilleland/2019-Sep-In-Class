<Query Kind="Expression">
  <Connection>
    <ID>fa9a30b7-40b2-418b-964d-abb7204b83e0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// List all the customers and the name, qty & unit price of each
// of the items they purchased.
from   data      in       Customers
//   Customer           Table<Customers>
select new // TODO: Place class name here
{
    CompanyName = data.CompanyName,
    Sales = from purchase in data.Orders
            //    Order            Order[]
            from lineItem in purchase.OrderDetails
            // OrderDetail                OrderDetail[]
            select new
            {
                Name = lineItem.Product.ProductName,
                Qty = lineItem.Quantity,
                UnitPrice = lineItem.UnitPrice
            }
}