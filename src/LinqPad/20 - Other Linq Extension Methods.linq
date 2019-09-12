<Query Kind="Program">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Other Linq Extension Methods
void Main()
{
    // .Distinct()
    var cityNames = Addresses.Select(x => x.City);
    cityNames.Dump("All customer cities");
    cityNames.Distinct().Dump("All cities - no duplicates");
    
    // .Take() & .Skip()
    cityNames.Take(5).Dump("First five cities");
    cityNames.Skip(5).Take(3).Dump("Next three cities");
    
    // .Any() - returns true if any of the items matches the condition
    Categories.Where(cat => cat.Products.Any(thing => thing.UnitPrice < 5.0m)).Dump("Categories with low-price items");
    // by the way, the value 5.0 is a double, while the literal value 5.0m is a decimal.
    
    // .All() - returns true only if ALL of the items match the condition
    Categories.Where(cat => cat.Products.All(thing => thing.UnitPrice > 7.5m)).Dump("Categories w. prices over $7.50");
    
}

// Define other methods and classes here