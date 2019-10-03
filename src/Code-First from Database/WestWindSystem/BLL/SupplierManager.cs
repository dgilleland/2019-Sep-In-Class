using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.ReadModels;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class SupplierManager
    {
        public List<SupplierSummary> ListSupplierSummary()
        {
            using(var context = new WestWindContext())
            {
                var result = from vendor in context.Suppliers
                             select new SupplierSummary
                             {
                                 CompanyName = vendor.CompanyName,
                                 Contact = vendor.ContactName,
                                 Phone = vendor.Phone,
                                 Products = from item in vendor.Products
                                            select new SupplierProduct
                                            {
                                                Name = item.ProductName,
                                                Category = item.Category.CategoryName,
                                                Price = item.UnitPrice,
                                                PerUnitQuantity = item.QuantityPerUnit
                                            }
                             };
                return result.ToList();

            }
        }
    }
}
