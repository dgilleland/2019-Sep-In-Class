<Query Kind="Expression">
  <Connection>
    <ID>a1c24afb-9d45-4007-89ec-e11e5d82dc7e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from buyer in Customers
select new
{
	ID = buyer.CustomerID,
	Company = buyer.CompanyName,
	Orders = from sale in buyer.Orders
	         orderby sale.OrderDate
	         select new
			 {
			 	Rep = sale.SalesRep.FirstName + " " + sale.SalesRep.LastName,
				OrderDate = sale.OrderDate,
				RequiredDate = sale.RequiredDate,
				ShipName = sale.ShipName,
				Items = from item in sale.OrderDetails
				        select new
						{
							Product = new { ID = item.ProductID, Name = item.Product.ProductName },
							Quantity = item.Quantity,
							UnitPrice = item.UnitPrice,
							Discount = item.Discount,
							Supplier = new { ID = item.Product.Supplier.SupplierID, Name = item.Product.Supplier.CompanyName }
						}
			 }
}