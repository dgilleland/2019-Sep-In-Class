<Query Kind="Program">
  <Connection>
    <ID>427b867e-be0d-4dfa-a844-3e8558a6934e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
    // Act like I'm the Presentation Layer calling this...
    var output = ListShippers();
    output.Dump();
}

// Define other methods and classes here
        public List<ShipperSelection> ListShippers()
        {
            // throw new NotImplementedException();
            // TODO: Queries for all the shippers.
            var result = from shipper in Shippers
                         orderby shipper.CompanyName
                         select new ShipperSelection
                         {
                             ShipperId = shipper.ShipperID,
                             Shipper = shipper.CompanyName
                         };
            return result.ToList();
        }

public class ShipperSelection
{
    public int ShipperId { get; set; }
    public string Shipper { get; set; }
}
