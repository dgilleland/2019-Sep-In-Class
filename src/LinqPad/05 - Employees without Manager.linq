<Query Kind="Expression">
  <Connection>
    <ID>fa9a30b7-40b2-418b-964d-abb7204b83e0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// List all the employees who do not have a manager
// (i.e.: they do not report to anyone).
from person in Employees
//   thing      thing[] 
where person.ReportsToEmployee == null
//   thing     thing 
select new
// These curly braces are called the "initializer list"
{
  Name = person.FirstName + " " + person.LastName
}