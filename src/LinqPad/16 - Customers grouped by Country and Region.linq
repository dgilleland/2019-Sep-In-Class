<Query Kind="Expression">
  <Connection>
    <ID>fa9a30b7-40b2-418b-964d-abb7204b83e0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// List all the customers grouped by country and region.
from row in Customers
group row by new // TODO: ClassName for key
{
	Nation = row.Address.Country,
	row.Address.Region
}
into CustomerGroups
select new
{
   Key = CustomerGroups.Key,
   Country = CustomerGroups.Key.Nation,
   Region = CustomerGroups.Key.Region,
   Customers = from data in CustomerGroups
               select new
               {
                   Company = data.CompanyName,
                   City = data.Address.City
               }
}