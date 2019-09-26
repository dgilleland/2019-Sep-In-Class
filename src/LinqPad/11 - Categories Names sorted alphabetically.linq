<Query Kind="Expression">
  <Connection>
    <ID>fa9a30b7-40b2-418b-964d-abb7204b83e0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Lookup the category names, in alphabetical order
from row in Categories
orderby row.CategoryName // descending // uncomment for reverse alphabetical order
select row.CategoryName