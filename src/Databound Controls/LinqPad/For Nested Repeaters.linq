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
	var result = from company in Suppliers
	select new
	{
		Company = company.CompanyName,
		Contact = company.ContactName,
		Phone = company.Phone,
		Products = from item in company.Products
		           select new SupplierProduct
				   {
				   		Name = item.ProductName,
						Category = item.Category.CategoryName,
						Price = item.UnitPrice,
						QtyPerUnit = item.QuantityPerUnit
				   }
	};
	result.Dump();
}

// Define other methods and classes here
public class SupplierProduct
{
	public string Name {get;set;}
	public string Category {get;set;}
	public decimal Price {get;set;}
	public string QtyPerUnit {get;set;}
}

public class SupplierSummary
{
	public string Company {get;set;}
	public string Contact {get;set;}
	public string Phone {get;set;}
	public IEnumerable<SupplierProduct> Products {get;set;}
}













