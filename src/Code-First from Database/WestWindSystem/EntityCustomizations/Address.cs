using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.Entities
{
    public partial class Address
    {
        [NotMapped] // This is NOT a column in the database table
        public string FullAddress
        {
            get
            {
                string result = $"{Address1}, {City}, {Country}";
                return result;
            }
        }
    }
}
