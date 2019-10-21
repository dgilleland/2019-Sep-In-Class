<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// F) List all the region and territory names as an "object graph"
//   - use a nested query
from place in Regions
select new
{
	Region = place.RegionDescription,
	Territories = from area in place.Territories
	              select area.TerritoryDescription
}