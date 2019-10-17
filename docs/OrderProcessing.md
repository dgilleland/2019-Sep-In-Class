# Order Processing

> Orders are shipped directly from our suppliers to our customers. As such, suppliers log onto our system to see what orders there are for the products that they provide.

## User Interface

Suppliers will be interacting with a page that shows the following information.

![Mockup](./Shipping-Orders.svg)

The information shown here will be displayed in a **ListView**, using the *SelectedItemTemplate* as the part that shows the details for a given order.

## POCOs

### Commands

### Queries

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
