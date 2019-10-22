<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.
from person in Employees
orderby person.LastName, person.FirstName
select new
{
	person.FirstName,
	person.LastName,
	OrderCount = person.SalesRepOrders.Count()
}