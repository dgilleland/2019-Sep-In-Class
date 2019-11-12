<Query Kind="Program">
  <Connection>
    <ID>a00a5aa6-ba7f-476f-b839-d9097fde871b</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	var output = ListShippers();
	output.Dump();
}

// Define other methods and classes here
        public List<ShipperSelection> ListShippers()
        {
            //throw new NotImplementedException();
            // TODO: Get all the shippers from the Db
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





