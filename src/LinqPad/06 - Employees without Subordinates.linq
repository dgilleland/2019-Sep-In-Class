<Query Kind="Expression">
  <Connection>
    <ID>a1c24afb-9d45-4007-89ec-e11e5d82dc7e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the employees who do not manage anyone.
from person   in Employees
//   Employee    Table<Employee>
where person.ReportsToChildren.Count == 0
//   Employee  IEnumerable<Employee>
select new
{
  Name = person.FirstName + " " + person.LastName,
  Manager = person.ReportsToEmployee.FirstName + " " + person.ReportsToEmployee.LastName
}