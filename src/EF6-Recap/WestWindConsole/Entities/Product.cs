﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindConsole.Entities
{
    // TODO: Begin reviewing entity attributes
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required, StringLength(40, ErrorMessage = "Product Name cannot be longer than 40 characters")]
        public string ProductName { get; set; }

        public int SupplierID { get; set; }

        public int CategoryID { get; set; }

        [Required, StringLength(20, ErrorMessage = "Quantity per Unit is restricted to 20 characters in length")]
        public string QuantityPerUnit { get; set; }

        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int UnitsOnOrder { get; set; }

        public bool Discontinued { get; set; }

        // TODO: Introducing Navigation Properties
        public virtual Category Category { get; set; }
    }
}
