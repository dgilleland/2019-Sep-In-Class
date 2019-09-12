using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindConsole.Entities
{
    [Table("Addresses")]
    public class Address
    {
        public int AddressId { get; set; }

        [Column("Address")] // maps to the db column Address
        public string StreetAddress { get; set; }

    }
}
