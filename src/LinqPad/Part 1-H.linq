<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// H) List all the discontinued products, specifying the product name and unit price.
from item in Products
where item.Discontinued
select new
{
    Name = item.ProductName,
	Price = item.UnitPrice
}