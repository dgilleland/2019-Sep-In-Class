<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// B) List all the Customers sorted by Company Name. Include the Customer's company name, contact name, and other contact information in the result.
from company in Customers
select new
{
	CompanyName = company.CompanyName,
	Contact = new
	          {
			  	  Name = company.ContactName,
				  Title = company.ContactTitle,
				  Email = company.ContactEmail,
				  Phone = company.Phone,
				  Fax = company.Fax
			  }
}