<Query Kind="Expression">
  <Connection>
    <ID>a1c24afb-9d45-4007-89ec-e11e5d82dc7e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who do not have a manager
// (i.e.: they do not report to anyone).
from person   in    Employees
//   Employee     Table<Employees>
where person.ReportsToEmployee == null
//   Employee     Employee 
select new // Creating an anonymous data type
// The curly braces section below is called the Initializer List
{
  Name = person.FirstName + " " + person.LastName
}