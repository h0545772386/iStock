namespace iStock
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ConvUOM> ConvUOMs { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConvUOM>()
                .Property(e => e.QTY1)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ConvUOM>()
                .Property(e => e.QTY2)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Material>()
                .Property(e => e.Price1)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Material>()
                .Property(e => e.Price2)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Material>()
                .Property(e => e.Price3)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Material>()
                .Property(e => e.MinQTY)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Material>()
                .Property(e => e.MaxQTY)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Material>()
                .Property(e => e.TotalQTY)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.TrnQTY)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Price1)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Price2)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Price3)
                .HasPrecision(10, 2);
        }
    }
}
