using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCRUD.Admin
{
    public partial class ViewAddresses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckForExceptions(object sender, ObjectDataSourceStatusEventArgs e)
        {
            // Works for the OnInsert, OnUpdate, and OnDelete events of
            // the ObjectDataSource control.
            MessageUserControl.HandleDataBoundException(e);
        }
    }
}