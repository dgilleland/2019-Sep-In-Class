<Query Kind="Expression">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// B) List all the Customers sorted by Company Name. Include the Customer's company name, contact name, and other contact information in the result.
from vendor in Customers
orderby vendor.CompanyName
select new
{
    CompanyName = vendor.CompanyName,
	Contact = new // Didn't really need an object here, but hey....
	{
	    Name = vendor.ContactName,
	    Title = vendor.ContactTitle,
		Email = vendor.ContactEmail,
		Phone = vendor.Phone,
		Fax = vendor.Fax
	}
}