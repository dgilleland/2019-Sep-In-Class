using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security;

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
    }
}