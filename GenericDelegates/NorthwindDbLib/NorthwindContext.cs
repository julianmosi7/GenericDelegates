namespace NorthwindDbLib
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindContext")
        {
        }

        public virtual DbSet<Adress> Adresses { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>()
                .HasMany(e => e.Persons)
                .WithOptional(e => e.Adress)
                .HasForeignKey(e => e.Adress_id);
        }
    }
}
