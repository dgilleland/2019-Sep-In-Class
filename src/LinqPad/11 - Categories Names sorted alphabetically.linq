<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Lookup the category names, in alphabetical order
from row in Categories
orderby row.CategoryName // descending // uncomment for reverse alphabetical order
select row.CategoryName