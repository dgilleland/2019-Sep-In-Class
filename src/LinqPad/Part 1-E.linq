<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// E) List all the region and territory names in a "flat" list
from place in Territories
select new
{
	Region = place.Region.RegionDescription,
	Territory = place.TerritoryDescription
}