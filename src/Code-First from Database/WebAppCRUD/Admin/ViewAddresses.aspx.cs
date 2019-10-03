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
            if (e.Exception == null)
                MessageUserControl.ShowInfo("Success!");
            else
                MessageUserControl.HandleDataBoundException(e);
        }
    }
}