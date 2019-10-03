<Query Kind="Expression">
  <Connection>
    <ID>427b867e-be0d-4dfa-a844-3e8558a6934e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.

// A) Group employees by region and show the results in this format:
/* ----------------------------------------------
 * | REGION        | EMPLOYEES                  |
 * ----------------------------------------------
 * | Eastern       | ------------------------   |
 * |               | | Nancy Devalio        |   |
 * |               | | Fred Flintstone      |   |
 * |               | | Bill Murray          |   |
 * |               | ------------------------   |
 * |---------------|----------------------------|
 * | ...           |                            |
 * 
from place in Territories
group place by place.Region.RegionDescription into bigPlace
select new
{
	Region = bigPlace.Key,
	Employees = (from terr in bigPlace
	            from emplTerr in terr.EmployeeTerritories
				select emplTerr.Employee.FirstName + " " + emplTerr.Employee.LastName).Distinct()
	 
}
 */
from place in Regions
select new
{
    Region = place.RegionDescription,
	Employees = (from area in place.Territories
	            from managedTerritory in area.EmployeeTerritories
				select managedTerritory.Employee.FirstName + " " + managedTerritory.Employee.LastName).Distinct()
}


// B) List all the Customers by Company Name. Include the Customer's company name, contact name, and other contact information in the result.

// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.

// D) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.

// E) Group all customers by city. Output the city name, aalong with the company name, contact name and title, and the phone number.

// F) List all the Suppliers, by Country