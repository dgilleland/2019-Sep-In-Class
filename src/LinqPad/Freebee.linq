<Query Kind="Statements">
  <Connection>
    <ID>3d597064-2cba-4d85-8735-9bae812dcf31</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>GroceryList</Database>
  </Connection>
</Query>

// Select all orders a picker has done on a particular week (Sunday through Saturday). Group and sorted by picker. Sort the orders by picked date. Hint: DO NOT use the join operator.
// Explore to see what the last PickedDate is, and what day of week it is
// Orders.Max(x=>x.PickedDate).Value.DayOfWeek // Yay! it's a Sunday
DateTime start = new DateTime(2018,1,7) // Last date of a picked order, is a Sunday
                 .AddDays(-14);         // Go two weeks earlier
DateTime end = start.AddDays(7);
var diff = end - start;
diff.Dump("Time between two dates");
var result = from sale in Orders
             // We don't have a "between" operator in C#
             where sale.OrderDate >= start
			    && sale.OrderDate < end
			 orderby sale.PickedDate
			 group sale by sale.PickerID into pickedOrders
			 select new
			 {
			     Picker = //pickedOrders.Key,
				          Pickers.Single(x => x.PickerID == pickedOrders.Key),
				 Orders = from picked in pickedOrders
				          select new
						  {
						      Order = picked.OrderID,
							  Items = from item in picked.OrderLists
							          select new
									  {
									      Item = item.Product.Description,
										  Ordered = item.QtyOrdered,
										  Picked = item.QtyPicked
									  }
						  }
			 };
result.Dump();