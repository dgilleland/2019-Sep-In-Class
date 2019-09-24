using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCRUD.Admin
{
    public partial class ViewSuppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SuppliersListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            // This fires just before the ListView calls
            // the ObjectDataSource control to do an Insert.
            ; // no-op
        }

        protected void SuppliersListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            // This event is fired after the ObjectDataSource
            // has returned from performing an Insert.
            ;
        }

        protected void SuppliersDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            ; // Before calling BLL
        }

        protected void SuppliersDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ; // After the call to the BLL
            if(e.Exception != null)
            {
                Exception inner = e.Exception;
                while (inner.InnerException != null)
                    inner = inner.InnerException;

                string message = $"Problem inserting: { inner.GetType().Name }<blockquote>{ inner.Message }</blockquote>";

                if(inner is DbEntityValidationException)
                {
                    // Safe Type-Cast
                    var actual = inner as DbEntityValidationException;
                    message += "<ul>";
                    foreach(var detail in actual.EntityValidationErrors)
                    {
                        message += $"<li>{detail.Entry.Entity.GetType().Name}";
                        message += "<ol>";
                        foreach(var error in detail.ValidationErrors)
                        {
                            message += $"<li>{error.ErrorMessage}</li>";
                        }
                        message += "</ol></li>";
                    }
                }

                MessageLabel.Text = message;

                e.ExceptionHandled = true;
            }
        }
    }
}