namespace DemoSystem.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DemoSystem.Entities;

    public partial class DemoContext : DbContext
    {
        public DemoContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.LastName)
                .IsUnicode(false);
        }
    }
}
