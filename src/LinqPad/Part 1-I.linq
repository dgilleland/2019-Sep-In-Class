<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// I) List the company names of all Suppliers in North America (Canada, USA, Mexico)
from vendor in Suppliers
where vendor.Address.Country == "Canada"
   || vendor.Address.Country == "USA"
   || vendor.Address.Country == "Mexico"
select vendor.CompanyName