<Query Kind="Expression">
  <Connection>
    <ID>fa9a30b7-40b2-418b-964d-abb7204b83e0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

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
from company in Suppliers
select new
{
}
