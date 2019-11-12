namespace WestWindSystem.DataModels
{
    public class OrderProductInformation
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short Qty { get; set; }
        public string QtyPerUnit { get; set; }
        public short Outstanding { get; set; }
        // NOTE: Outstanding <= OrderDetails.Quantity - Sum(ManifestItems.ShipQuantity) for that product/order
    }
}
