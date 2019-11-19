using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security;
using WestWindSystem.DataModels;

namespace WebApp.Sales
{
    public partial class OrderShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only allow suppliers to use/access this page
            if (!Request.IsAuthenticated || !User.IsInRole(Settings.SupplierRole))
                Response.Redirect("~", true);
            
            if(!IsPostBack) // GET - first visit to the page
            {
                // Load up the info on the supplier
                // TODO: Replace hard-coded supplier ID with the user's supplier ID
                // - Show Company name and contact
                SupplierInfo.Text = "Temp supplier: ID 2";
            }
        }

        protected void CurrentOrders_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "Ship")
            {
                // Extract data from the form & call the BLL to ship the order
                // Gather information from the form for the products to be shipped and the shipping information. This is sent to the void OrderProcessingController.ShipOrder(int orderId, ShippingDirections shipping, List<ProductShipment> products)

                int orderId;
                ShippingDirections shippingInfo = new ShippingDirections();
                Label idLabel = e.Item.FindControl("OrderIdLabel") as Label; // Safe cast to a label obj
                if(idLabel != null) // I successfully got the control
                {
                    orderId = int.Parse(idLabel.Text);
                }
                DropDownList shipVia = e.Item.FindControl("ShipperDropDown") as DropDownList;
                if(shipVia != null)
                {
                    shippingInfo.ShipperId = int.Parse(shipVia.SelectedValue);
                }

            }
        }
    }
}