<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

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
 */
from place in Regions
select new
{
	Region = place.RegionDescription,
	// Getting employees and removing duplicates
	Employees = (from area in place.Territories
	            from manager in area.EmployeeTerritories
				select manager.Employee.FirstName + " " + manager.Employee.LastName)
				.Distinct(),
	Employees2 = from area in place.Territories
	             from manager in area.EmployeeTerritories
				 group manager by manager.Employee into areaManagers
				 select areaManagers.Key.FirstName + " " + areaManagers.Key.LastName
}









