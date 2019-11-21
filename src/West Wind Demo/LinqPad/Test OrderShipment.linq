<Query Kind="Expression">
  <Connection>
    <ID>427b867e-be0d-4dfa-a844-3e8558a6934e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from item in Shipments
where item.OrderID == 11081
select item