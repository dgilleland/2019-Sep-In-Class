namespace WestWindSystem.DataModels
{
    public class ShippingDirections
    {
        public int ShipperId { get; set; }
        public string TrackingCode { get; set; }
        public decimal? FreightCharge { get; set; }
    }
}
