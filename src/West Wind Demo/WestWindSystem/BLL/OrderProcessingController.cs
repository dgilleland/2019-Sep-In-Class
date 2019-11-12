using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
    public class OrderProcessingController
    {
        #region Queries
        public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            throw new NotImplementedException();
            // TODO: Implement this method wit the following
            /*      Validation:
                        Make sure the supplier ID exists, otherwise throw an exception
                        [Advanced:] Make sure the logged-in user works for the identified supplier.
                        Query for outstanding orders, getting data from the following tables:
                        TODO: List table names
             */
        }

        public List<ShipperSelection> ListShippers()
        {
            using(var context = new WestWindContext())
            {
                var result = from shipper in context.Shippers
                             orderby shipper.CompanyName
                             select new ShipperSelection
                             {
                                 ShipperId = shipper.ShipperID,
                                 Shipper = shipper.CompanyName
                             };
                return result.ToList();
            }
        }
        #endregion

        #region Commands
        public void ShipOrder(int orderId, ShippingDirections shipping, List<ShippedItem> items)
        {
            throw new NotImplementedException();
            // TODO: Validation steps
            /* Validation:
                    OrderId must be valid
                    ShippingDirections is required (cannot be null)
                    List<ShippedItem> cannot be empty/null
                    The products must be on the order AND items that this supplier provides
                    Quantities must be greater than zero and less than or equal to the quantity outstanding
                    Shipper must exist
                    Freight charge must be either null (no charge) or > $0.00
             */
            // TODO: Process the order shipment
            /*Processing (tables/data that must be updated/inserted/deleted/whatever)
                Create new Shipment
                Add all manifest items
                Check if order is complete; if so, update Order.Shipped
             */
        }
        #endregion
    }
}
