<Query Kind="Program">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	// List the first and last name of all the employees who look after 7 or more territories
	// as well as the names of all the territories they are responsible for
	var result = from person in Employees
	where person.EmployeeTerritories.Count >= 7
	select new EmployeeSummary // the following Initializer defines the properties for an Anonymous Type
	{
	   First = person.FirstName,
	   Last = person.LastName,
	   Territories = (from place in person.EmployeeTerritories
	                 select place.Territory.TerritoryDescription).ToList()
	};
	result.Dump();
}

// Define other methods and classes here
public class EmployeeSummary
{
	public string First {get;set;}
	public string Last {get;set;}
	public List<string> Territories {get;set;}
}