using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
    public class OrderProcessingController
    {
        #region Queries
        public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            throw new NotImplementedException();
            // TODO: Implement this method
            /* Validation:
                    Make sure the supplier ID exists, otherwise throw exception
                    [Advanced:] Make sure the logged-in user works for the identified supplier.
               Query for outstanding orders, getting data from the following tables:
                    TODO: List table names
             */
        }

        public List<ShipperSelection> ListShippers()
        {
            throw new NotImplementedException();
            // TODO: Queries for all the shippers.
        }
        #endregion

        #region Commands
        public void ShipOrder(int orderId, ShippingDirections shipping, List<ProductShipment> products)
        {
            throw new NotImplementedException();
            // TODO: Validation:
            /*Validation:
                OrderId must be valid
                products cannot be an empty list
                Products identified must be on the order
                Quantity must be greater than zero and less than or equal to the quantity outstanding
                Shipper must exist
                Freight charge must either be null (no charge) or > $0.00
            */
            // TODO: Processing
            /*Processing (tables/data that must be updated/inserted/deleted/whatever)
                Create new Shipment
                Add all manifest items
                Check if order is complete; if so, update Order.Shipped
             */
        }
        #endregion
    }
}
