<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// A) List all the customer company names for those with more than 5 orders.
from company in Customers
where company.Orders.Count() > 5
select company.CompanyName