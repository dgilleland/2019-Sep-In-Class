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
    [DataObject] // for the <ObjectDataSource> control
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
            using (var context = new WestWindContext())
            {
                return context.Suppliers.Include(nameof(Supplier.Address)).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void AddSupplier(Supplier item)
        {
            using (var context = new WestWindContext())
            {
                context.Suppliers.Add(item);
                context.SaveChanges();
            }
        }
        #endregion

        #region Categories CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Category> ListCategorys()
        {
            using (var context = new WestWindContext())
            {
                return context.Categories.ToList();
            }
        }
        #endregion

        #region Addresses CRUD
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Address> ListAddresss()
        {
            using (var context = new WestWindContext())
            {
                return context.Addresses.ToList();
            }
        }
        #endregion

    }
}
