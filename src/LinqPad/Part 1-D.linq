<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// D) List all the regions and the number of territories in each region
from place in Regions
select new
{
	Region = place.RegionDescription,
	TerritoryCount = place.Territories.Count()
}