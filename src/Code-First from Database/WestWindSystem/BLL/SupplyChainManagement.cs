using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.ReadModels;

namespace WestWindSystem.BLL
{
    public class SupplyChainManagement
    {
        public List<SupplierSummary> GetSupplierSummaries()
        {
            using(var context = new WestWindContext())
            {
                var result = from company in context.Suppliers
                             select new SupplierSummary
                             {
                                 Company = company.CompanyName,
                                 Contact = company.ContactName,
                                 Phone = company.Phone,
                                 Products = from item in company.Products
                                            select new SupplierProduct
                                            {
                                                Name = item.ProductName,
                                                Category = item.Category.CategoryName,
                                                Price = item.UnitPrice,
                                                QtyPerUnit = item.QuantityPerUnit
                                            }
                             };
                return result.ToList();
            }
        }
    }
}
