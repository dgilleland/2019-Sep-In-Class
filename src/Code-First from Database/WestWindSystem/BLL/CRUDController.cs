using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class CRUDController
    {
        #region Products CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> ListProducts()
        {
            using (var context = new WestWindContext())
            {
                return context.Products.ToList();
            }
        }
        #endregion

        #region Suppliers CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Supplier> ListSuppliers()
        {
            using(var context = new WestWindContext())
            {
                return context.Suppliers.ToList();
            }
        }
        #endregion

        #region Categories CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Category> ListCategories()
        {
            using(var context = new WestWindContext())
            {
                return context.Categories.ToList();
            }
        }
        #endregion

        #region Addresses CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Address> ListAddresses()
        {
            using(var context = new WestWindContext())
            {
                return context.Addresses.ToList();
            }
        }
    }
}
