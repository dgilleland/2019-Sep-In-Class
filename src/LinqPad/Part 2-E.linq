<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// E) Group all customers by city. Output the city name, along with the company name, contact name and title, and the phone number.
from company in Customers
group company by company.Address.City into customersByCity
select new
{
	City = customersByCity.Key,
	Customers = from buyer in customersByCity
	            select new
				{
					buyer.CompanyName,
					buyer.ContactName,
					buyer.ContactTitle,
					buyer.Phone
				}
}
