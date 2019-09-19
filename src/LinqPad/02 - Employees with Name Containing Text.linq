<Query Kind="Expression">
  <Connection>
    <ID>a1c24afb-9d45-4007-89ec-e11e5d82dc7e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// - Filter on partial name
// List employees who have an "an" in their first name
from person in Employees
where person.FirstName.Contains("an")
select person