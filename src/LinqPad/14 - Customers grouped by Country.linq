<Query Kind="Expression">
  <Connection>
    <ID>fa9a30b7-40b2-418b-964d-abb7204b83e0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Display all the company names and contact names for our customers, grouped by country
from row in Customers
group  row   by   row.Address.Country
//    \what/      \       how       /
//                       (Key)
// The result of the above gives a 
// IOrderedQueryable< IGrouping<string, Customers> >

 	into CustomersByCountry
 //   IGrouping<string, Customers> 
select new
{
   Country = CustomersByCountry.Key, // the key is "how" we have sorted the data
   Customers = from data in CustomersByCountry
   //            Customer    Customer[]
               select new
               {
			       Company = data.CompanyName,
				   Contact = data.ContactName
               }
}