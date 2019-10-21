<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// E) Group all customers by city. Output the city name, along with the company name, contact name and title, and the phone number.
from buyer in Customers
group buyer by buyer.Address.City into cityVendors
select new
{
	City = cityVendors.Key,
	Company = from company in cityVendors
	          select new
			  {
			  	  company.CompanyName,
				  company.ContactName,
				  company.ContactTitle,
				  company.Phone
			  }
}