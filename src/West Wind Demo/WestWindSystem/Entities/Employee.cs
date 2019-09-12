namespace WestWindSystem.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Employees1 = new HashSet<Employee>();
            Orders = new HashSet<Order>();
            Territories = new HashSet<Territory>();
        }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string TitleOfCourtesy { get; set; }

        [StringLength(30)]
        public string JobTitle { get; set; }

        public int? ReportsTo { get; set; }

        public DateTime HireDate { get; set; }

        [StringLength(24)]
        public string OfficePhone { get; set; }

        [StringLength(4)]
        public string Extension { get; set; }

        public DateTime BirthDate { get; set; }

        public int AddressID { get; set; }

        [Required]
        [StringLength(24)]
        public string HomePhone { get; set; }

        public byte[] Photo { get; set; }

        [StringLength(40)]
        public string PhotoMimeType { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        public bool? Active { get; set; }

        public DateTime? TerminationDate { get; set; }

        public bool OnLeave { get; set; }

        [StringLength(80)]
        public string LeaveReason { get; set; }

        public DateTime? ReturnDate { get; set; }

        public virtual Address Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees1 { get; set; }

        public virtual Employee Employee1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
