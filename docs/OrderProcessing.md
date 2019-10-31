# Order Processing

> Orders are shipped directly from our suppliers to our customers. As such, suppliers log onto our system to see what orders there are for the products that they provide.

## User Interface

Suppliers will be interacting with a page that shows the following information.

![Mockup](./Shipping-Orders.svg)

The information shown here will be displayed in a **ListView**, using the *EditItemTemplate* as the part that shows the details for a given order.

## Events and Interactions

![Plan](Shipping-Orders-Plan.svg)

- ![](1.svg) - **Page_Load** event
  - ![](A.svg) - Supplier/Contact names obtained from who the logged-in user is.
  - ![](B.svg) - Load the ListView data from BLL
    - **`List<OutstandingOrder> OrderProcessingController.LoadOrders(supplierId)`**
  - ![](C.svg) - Load the list of shippers from BLL
    - **`List<ShipperSelection> OrderProcessingController.ListShippers()`
- ![](2.svg) - **EditCommand** click event
  - Default EditCommand behaviour of the ListView
  - `<EditItemTemplate>` will display the extended information of the products ![](D.svg) and other details of the order.
- ![](3.svg) - **ShipOrder** click
  - Use a custom command name of "ShipOrder" and handle in the ListView's `ItemCommand` event.
  - Gather information from the form of the products to be shipped and the shipping information. This is sent to the following method in the BLL for processing:
    ```csharp
    void OrderProcessingController.ShipOrder(int orderId, ShippingDirections shipping, List<ShippedItem> items)
    ```

## POCOs/DTOs

The POCOs/DTOs are simply classes that will hold our data when we are performing Queries or issuing Commands to the BLL.

### Commands

```csharp
public class ShippingDirections
{
    public int ShipperId { get;set; }
    public string TrackingCode { get;set; }
    public decimal? FreightCharge { get;set; }
}
```

```csharp
public class ShippedItem
{
    public int ProductId { get; set; }
    public int ShipQuantity { get; set; }
}
```

### Queries

```csharp
public class ShipperSelection
{
    public int ShipperId { get; set; }
    public string Shipper { get; set; }
}
```

```csharp
public class OutstandingOrder
{
    public int OrderId { get; set; }
    public string ShipToName { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime RequiredBy { get; set; }
    public int DaysRemaining { get; } // Calculated
    public IEnumerable<OrderItem> OutstandingItems { get; set; }
    public string FullShippingAddress { get; set; }
    public string Comments { get; set; }
}
```

```csharp
public class OrderItem
{
    public int ProductID {get;set;}
    public string ProductName {get;set;}
    public short Qty {get;set;}
    public string QtyPerUnit {get;set;}
    public short Outstanding {get;set;} // Calculated as OD.Quantity - Sum(Shipped qty)
}
```

## BLL Processing

All product shipments are handled by the **`OrderProcessingController`**. It supports the following methods.

- **`List<OutstandingOrder> LoadOrders(int supplierId)`**
  - **Validation:**
    - Make sure the supplier ID exists, otherwise throw an exception
    - [Advanced:] *Make sure the logged-in user works for the identified supplier.*
  - Query for outstanding orders, getting data from the following tables:
    - TODO: List table names
- **`List<ShipperSelection> ListShippers()`**
  - Get all the shippers from the Db
- **`void ShipOrder(int orderId, ShippingDirections shipping, List<ShippedItem> items)`**
  - **Validation:**
    - OrderId must be valid
    - `ShippingDirections` is required (cannot be `null`)
    - `List<ShippedItem>` cannot be empty/null
    - The products must be on the order AND items that this supplier provides
    - Quantities must be greater than zero and less than or equal to the quantity outstanding
    - Shipper must exist
    - Freight charge must be either null (no charge) or > $0.00
  - **Processing** (tables/data that must be updated/inserted/deleted/whatever)
    - Create new Shipment
    - Add all manifest items
    - Check if order is complete; if so, update Order.Shipped
