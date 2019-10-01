<Query Kind="Expression">
  <Connection>
    <ID>427b867e-be0d-4dfa-a844-3e8558a6934e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from company in Suppliers
select new
{
	Company = company.CompanyName,
	Contact = company.ContactName,
	Phone = company.Phone,
	Products = from item in company.Products
	           select new
			   {
			   		Name = item.ProductName,
					Category = item.Category.CategoryName,
					Price = item.UnitPrice,
					QtyPerUnit = item.QuantityPerUnit
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