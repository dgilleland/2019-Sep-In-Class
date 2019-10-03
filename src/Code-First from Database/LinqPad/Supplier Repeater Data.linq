<Query Kind="Expression">
  <Connection>
    <ID>a1c24afb-9d45-4007-89ec-e11e5d82dc7e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from vendor in Suppliers
select new
{
	CompanyName = vendor.CompanyName,
	Contact = vendor.ContactName,
	Phone = vendor.Phone,
	Products = from item in vendor.Products
	           select new
			   {
			   		Name = item.ProductName,
					Category = item.Category.CategoryName,
					Price = item.UnitPrice,
					PerUnitQuantity = item.QuantityPerUnit
			   }
}
/*
Supplier:
	Company Name
	Contact Name
	Phone Number
	Product Summary:
		Product Name
		Category Name
		Unit Price
		Quantity/Unit
*/