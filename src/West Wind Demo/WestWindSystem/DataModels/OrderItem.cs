using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.DataModels
{
    public class OrderItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short Qty { get; set; }
        public string QtyPerUnit { get; set; }
        public short Outstanding { get; set; } // TODO: Calculated as OD.Quantity - Sum(Shipped qty)
    }
}
