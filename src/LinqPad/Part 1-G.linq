<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// G) List all the product names that contain the word "chef" in the name.
from item in Products
where item.ProductName.Contains("chef")
select item.ProductName