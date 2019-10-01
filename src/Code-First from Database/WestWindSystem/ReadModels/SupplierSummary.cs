using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.ReadModels
{
    public class SupplierSummary
    {
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public IEnumerable<SupplierProduct> Products { get; set; }
    }
}
